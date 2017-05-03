#include "mbed.h"
#include "C12832.h"

void poll();
void decode();
void Rotate(int arr[], int d, int n);
void RotatebyOne(int arr[], int n);

C12832 lcd(p5, p7, p6, p8, p11);
AnalogIn input(p21);
Timer t; // timer used to find the frequency of the received data
int frequency = 100000; // must be way higher than the frequency with which data is send.
int counter = 0; //transition counter
int sample = 0; // initialising sample to zero,used to temporary store the measured period
int period = 1000000; // initialising period to 1 second,used to temporary store the smallest measured period
int measuredPeriod = 0; // initialising the actually received period
bool synchronisation = true; // boolean used to stop looking for the received period
bool counting = false;// boolean to see if you're alraedy counting
int data [41]; // received data
int message[21]; // actual message send
bool startHammingFound = false; //boolean used to determine the first bit of the message
int c,c1,c2,c3,c4,c5; // used for the hamming decoding
float AnalogNew; //used to be able to detect a transition
float AnalogOld; //used to be able to detect a transition

void poll() // Method to get the period of the dataeived data
{
    AnalogNew = 0;
    AnalogOld = 0;


    while(synchronisation)
    {
        if (abs(AnalogOld - AnalogNew) < 0.005) //No transition
        {
            wait_us(100000/frequency); //wait a bit
            AnalogNew = input.read();    //read the input
        }
        else // transition happened
        {
            counter ++; //transition counter goes up by 1
            if (counting == true) // you're already counting (transition has happened before)
            {
                t.stop(); // stops the timer
                sample = t.read_us(); // reads the value of the timer and stores it in sample
                t.reset(); // resets the timer
                if (sample < period)
                {
                    period = sample; // lowest period = frequency
                }
                counting = false; //timer has stopped counting
                AnalogOld = AnalogNew;
                AnalogNew = input.read();
            }
            else // timer hasn't started counting yet
            {
                t.start(); //starts timer
                counting = true; // boolean to indicate timer has started
                AnalogOld = AnalogNew;
                AnalogNew = input.read();
            }
        }
        if (counter > 21) // goes through half of the data to see if there are transistions
        {
            synchronisation = false; // boolean to indicate we have found the period
            measuredPeriod = period; // period that was found
            lcd.cls();
            lcd.locate(1,0);
            lcd.printf("Period: %d", measuredPeriod);
            lcd.printf("Frequency: %d", 1000000/measuredPeriod);
        }
    }
}

void decode() // decoding the received data to the actual message
{

    AnalogOld = 0;
    AnalogNew = 0;
    int n = 0;// used in for loops


    while (abs(AnalogOld - AnalogNew) < 0.005) // no transistion
    {
        wait_us(100000/frequency); // wait a bit
        AnalogNew = input.read(); // read the input
    }

    for (int i = 0; i < 42; i++) // filling up the data array
    {
        data[i] = input.read(); // read the bit value and store this in data array
        wait_us(measuredPeriod); //
    }

    while(startHammingFound == false) // look for the start of the message
    {
        if (n>40) // failsafe incase SOF can't be found;
        {
            n = 0;
        }
        if ((data[n] == 0) && (data[n+2] == 1) && (data[n+3] == 0) && (data[n+4] == 1)) // based on SOF used in the message
        {
            Rotate(data,n,41); //rotate so SOF starts at data[0]
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
