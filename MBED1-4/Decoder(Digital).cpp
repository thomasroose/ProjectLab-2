#include "mbed.h"
#include "C12832.h"

void poll();
void decode();
void Rotate(int arr[], int d, int n);
void RotatebyOne(int arr[], int n);

C12832 lcd(p5, p7, p6, p8, p11);
DigitalOut led1 (LED1);
DigitalOut led2 (LED2);
DigitalIn input1(p21);
DigitalIn input2(p22);
DigitalIn input3(p23);
int frequency =2000; // must be way higher than the frequency with which data is send.
int period = 1000000/frequency;
int data [42]; // received data
int message[16]; // actual message send
int pollArray[10]; //polling for the start of the data
bool startDataFound;
int counter;
bool startHammingFound = false; //boolean used to determine the first bit of the message
int c,c1,c2,c3,c4,c5; // used for the hamming decoding
int DigitalNew; //used to be able to detect a transition
int DigitalOld; //used to be able to detect a transition

void poll()
{
  while(startDataFound != true)
  {
    counter = 0;
    for (size_t p = 0; p < 10; p++)
    {
      if  (input1.read()== 1)
      {counter++;}
      else
      {break;}
      wait_us(period/5);
    }
    if (counter == 10)
    {
    startDataFound = true;
    led1 =true;
    }
  }
}

void decode() // decoding the received data to the actual message
{
  DigitalOld = 0;
  DigitalNew = 0;
  int n = 0;// used in for loops

  while (DigitalOld == DigitalNew) // no transistion
  {
    wait_us(1000000/(10*frequency)); // wait a bit
    DigitalNew = ~(input1.read()); // read the input
  }
  wait_us (period*1.25);

  for (int i = 0; i < 42; i++) // filling up the data array
  {
    //data[i] = ~(input1.read()); // read the bit value and store this in data array

    int newData = input1.read();

    if(newData>=1){
        data[i] = 0;
    }else{
        data[i] = 1;
        }


    wait_us(period); //

  }

  while(startHammingFound == false) // look for the start of the message
  {
    if (n>40) // failsafe incase SOF can't be found;
    {
      n = 0;
    }
    if ((data[n] == 0) && (data[n+2] == 1) && (data[n+3] == 0) && (data[n+4] == 1)) // based on SOF used in the message
    {
      if(n>=2)
      {
        Rotate(data,(n-2),42); //rotate so SOF starts at data[2]
      }
      else
      {
        if(n==0)
        {
          Rotate(data,42,42);//rotate so SOF starts at data[2]
        }
        if(n==1)
        {
          Rotate(data,41,42);//rotate so SOF starts at data[2]
        }
      }
      startHammingFound = true ; //Start has been found,exit the while
    }
    else
    {
      n++;
    }
  }

  c1=data[0]^data[2]^data[4]^data[6]^data[8]^data[10]^data[12]^data[14]^data[16]^data[18]^data[20];
  c2=data[1]^data[2]^data[5]^data[6]^data[9]^data[10]^data[13]^data[14]^data[17]^data[18]^data[20];
  c3=data[3]^data[4]^data[5]^data[6]^data[11]^data[12]^data[13]^data[14]^data[19]^data[20];
  c4=data[7]^data[8]^data[9]^data[10]^data[11]^data[12]^data[13]^data[14];
  c5=data[15]^data[16]^data[17]^data[18]^data[19]^data[20];
  c=c5*16+c4*8+c3*4+c2*2+c1 ; //determining if a bit-error happened checking even parity
  if(c!=0)
  {
    if(data[c-1]==0)
    {
      data[c-1]=1;
    }
    else{
      data[c-1]=0;
    }
  }
  message[0]=data[2]; // filling up the message array with the actual message send
  for (size_t v = 1; v < 5; v++)
  {
    message[v] = data[v+3];
  }
  // message[1]=data[4];
  // message[2]=data[5];
  // message[3]=data[6];
  for (size_t w = 4; w < 11; w++) {
    message[w] = data[w+4];
  }
  // message[4]=data[8];
  // message[5]=data[9];
  // message[6]=data[10];
  // message[7]=data[11];
  // message[8]=data[12];
  // message[9]=data[13];
  // message[10]=data[14];
  for (size_t x = 11; x < 16; x++) {
    message[x] = data[x+5];
  }
  // message[11]=data[16];
  // message[12]=data[17];
  // message[13]=data[18];
  // message[14]=data[19];
  // message[15]=data[20];

lcd.cls();
  lcd.locate(1,0);
  for (size_t l = 0; l < 16; l++)
  {
    lcd.printf("%d", message[l]);
  }
}

void Rotate(int arr[], int d, int n)
{
  int i;
  for (i = 0; i < d; i++)
  RotatebyOne(arr, n);
}

void RotatebyOne(int arr[], int n)
{
  int i, temp;
  temp = arr[0];
  for (i = 0; i < n-1; i++)
  arr[i] = arr[i+1];
  arr[i] = temp;
}

int main()
{
  poll();
  decode();
}
