#include "mbed.h"
#include "C12832.h"

void Poll();/*!< prototype function*/
void Decode();/*!< prototype function*/
int GetID();/*!< prototype function*/
void Run();/*!< prototype function*/

/**
* <h1> Decoder </h1>
* The Decoder program implements an application that
* detects data on a pin,selects this pin,polls for the start of the message.
* It then reads the data,decodes it using a Hamming and Manchester decoder
* and returns the necesarry info.
*
* @author  Pedro Cattrysse
* @version 1.0
* @since   2017-05-17
*/

C12832 lcd(p5, p7, p6, p8, p11);/*!< used to print text*/
PinName a;/*!< used to initialize input*/
DigitalIn *input;/*!< digital in that hasn't been assigned to a pin yet*/
DigitalIn input1(p21);/*!< 1 of the 3 digital inputs that might detect data*/
DigitalIn input2(p22);/*!< 1 of the 3 digital inputs that might detect data*/
DigitalIn input3(p23);/*!< 1 of the 3 digital inputs that might detect data*/
int ID;/*!< info that's extracted from the message*/
int frequency =2000;/*!< frequency at which the sampling of the data happens*/
int period = 1000000/frequency;/*!< period between samples*/
int data [42]; /*!< received data*/
int message[16]; /*!< actual message send*/
int counter; /*!< counter to count 10 samples of high level which means the line was high for 2 periods*/
bool SOFFound = false;/*!< boolean to check if SOF was found*/
bool startDataFound = false;/*!< boolean to check if the start of the data was found*/
bool DataFound = false;/*!< boolean to check if the data was found*/
bool startHammingFound = false; /*!< boolean used to determine the first bit of the message*/
int c,c1,c2,c3,c4,c5; /*!< used for the hamming decoding*/
int DigitalNew; /*!< used to be able to detect a transition*/
int DigitalOld; /*!< used to be able to detect a transition*/

/**
* Method to detect data on a pin and then select this pin to read the data from
*/

void SelectPin()
{
  while (DataFound == false)/*!< loop until data has been detected*/
  {
    if ((input1.read() ==0) && (input2.read() !=0) && (input3.read() !=0))/*!< red light*/
    {
      a= p21;/*!< set a to p21*/
      DataFound = true;/*!< break the while loop*/
    }
    else if ((input2.read() ==0) && (input3.read() !=0) && (input1.read() !=0))/*!< green light*/
    {
      a=p22;/*!< set a to p22*/
      DataFound = true;/*!< break the while loop*/
    }
    else if ((input3.read() ==0) && (input1.read() !=0) && (input2.read() !=0))/*!< blue light*/
    {
      a=p23;/*!< set a to p23*/
      DataFound = true;/*!< break the while loop*/
    }
    if ((input3.read() ==0) && (input1.read() ==0) && (input2.read() ==0))/*!< white light*/
    {
      a=p21;/*!< set a to p21*/
      DataFound = true;/*!< break the while loop*/
    }
  }
  input = new DigitalIn(a);/*!< input is the pin that's detecting data */
}

/**
* Method to detect the 2 periods of high send by the sender,inverse is measured due to the circuit
*/

void Poll()
{
  while(startDataFound != true)/*!< loop until start of the data has been detected*/
  {
    counter = 0;
    for (size_t p = 0; p < 10; p++)/*!< take 10 samples*/
    {
      if  ((*input).read()== 0)/*!< detect a low level*/
      {
        counter++;/*!< increase the counter*/
      }
      else
      {
        break;/*!< restart the while loop*/
      }
      wait_us(period/5);/*!< sample 5 times per period*/
    }
    if (counter == 10)/*!< 10 samples of low level = 2 periods of low detected*/
    {
      startDataFound = true;/*!< break the while loop*/
    }
  }
}

/**
* Method to read the data and decode it using a Hamming and Manchester decoder
*/

void Decode()
{
  DigitalOld = 0;/*!< set to zero*/
  DigitalNew = 0;/*!< set to zero*/
  int n = 0;/*!< used in the for loop*/

  while (DigitalOld == DigitalNew) /*!< no transition*/
  {
    wait_us(1000000/(10*frequency)); /*!< wait 1/10th of a period*/
    DigitalNew = ((*input).read()); /*!< read the input again*/
  }
  wait_us (period+100);/*!< wait 1.2 x period to ignore the first 1 send*/

  for (int i = 0; i < 42; i++) // /*!< for loop to fill up the data array*/
  {
    int newData = (*input).read();/*!< read the input and fill up an element of the data array*/
    if(newData>=1)/*!< read a 1*/
    {
      data[i] = 0;/*!< write away a 0 due to inverse input*/
    }
    else
    {
      data[i] = 1;/*!< read a 0*/
    }
    wait_us(period);/*!< write away a 1 due to inverse input*/
  }

  while(startHammingFound == false) /*!< loop until start of the Hamming has been detected*/
  {
    if (n>40)/*!< SOF has not been found,break out*/
    {
      break;
    }

    if ((data[n] == 0) && (data[n+2] == 1) && (data[n+3] == 0) && (data[n+4] == 1)) /*!< SOF has been found,SOF placed like this because of Hamming*/
    {
      startHammingFound = true ;/*!< break out of the while loop*/
    }
    else
    {
      n++;/*!< shift the array 1 to the left to see if SOF has been detected somewhere else*/
    }
  }

  c1=data[0]^data[2]^data[4]^data[6]^data[8]^data[10]^data[12]^data[14]^data[16]^data[18]^data[20];/*!< calculating parity bit */
  c2=data[1]^data[2]^data[5]^data[6]^data[9]^data[10]^data[13]^data[14]^data[17]^data[18]^data[20];/*!< calculating parity bit */
  c3=data[3]^data[4]^data[5]^data[6]^data[11]^data[12]^data[13]^data[14]^data[19]^data[20];/*!< calculating parity bit */
  c4=data[7]^data[8]^data[9]^data[10]^data[11]^data[12]^data[13]^data[14];/*!< calculating parity bit */
  c5=data[15]^data[16]^data[17]^data[18]^data[19]^data[20];/*!< calculating parity bit */
  c=c5*16+c4*8+c3*4+c2*2+c1 ; /*!< determining if a bit-error happened by checking even parity */
  if(c!=0)/*!< if biterror happened */
  {
    if(data[c-1]==0)/*!< position n = array[n-1] is 0*/
    {
      data[c-1]=1;/*!< put to 1 */
    }
    else/*!< position n = array[n-1] is 1*/
    {
      data[c-1]=0;/*!< put to 0 */
    }
  }
  message[0]=data[2];/*!< filling up the message array with the actual message send*/
  for (size_t v = 1; v < 5; v++)
  {
    message[v] = data[v+3];
  }
  /*!< message[1]=data[4]*/
  /*!< message[2]=data[5]*/
  /*!< message[3]=data[6]*/
  for (size_t w = 4; w < 11; w++)
  {
    message[w] = data[w+4];
  }
  /*!< message[4]=data[8]*/
  /*!< message[5]=data[9]*/
  /*!< message[6]=data[10]*/
  /*!< message[7]=data[11]*/
  /*!< message[8]=data[12]*/
  /*!< message[9]=data[13]*/
  /*!< message[10]=data[14]*/
  for (size_t x = 11; x < 16; x++)
  {
    message[x] = data[x+5];
  }
  /*!< message[11]=data[16]*/
  /*!< message[12]=data[17]*/
  /*!< message[13]=data[18]*/
  /*!< message[14]=data[19]*/
  /*!< message[15]=data[20]*/
  SOFFound = true;  /*!< break out of the while loop from Run()*/
}

/**
* Method to get the ID info from the message
*/

int GetID()
{
  if(message[8]==1)
  {
    if(message[9]==1)
    {
      ID=4;/*!< binary 11*/
    }
    else
    {
      ID=3;/*!< binary 10*/
    }
  }
  else
  {
    if(message[9]==1)
    {
      ID=2;/*!< binary 01*/
    }
    else
    {
      ID=1;/*!< binary 00*/
    }
  }
  return ID;/*!< return the ID*/
}

/**
* Method to keep running the poll and decode method until a SOF has been detected in the received data
*/

void Run()
{
  SOFFound = false; /*!< boolean to check if SOF was found*/
  while(!= SOFFound)/*!< loop until SOF has been detected*/
  {
    Poll();/*!< call the method Poll() */
    Decode();/*!< call the method Decode() */
  }
}

/**
* This is the main method which makes use of the SelectPin,Run and GetID methods.
* @return Nothing.
*/

int main()
{
  SelectPin();/*!< call the method SelectPin() */
  Run();/*!< call the method Run() */
  lcd.cls();
  lcd.locate(1,0);
  lcd.printf("%d",GetID());/*!< print the received ID on the screen*/
}
