#include "stdint.h"
#include "mbed.h"
#include "C12832.h"
#include "RGB.h"

/**
* <h1> Encoder </h1>
* The Encoder program implements an application that
* detects a setting chosen by the joystick and outputs
* selected data through an RGB.
*
* @author  Pedro Cattrysse
* @version 1.0
* @since   2017-05-17
*/

void fillArray();/*!< prototype function*/
void OutputData();/*!< prototype function*/

const int LENGTH = 21;/*!< constant used for the length of the data array*/
int data[LENGTH];/*!< data array that contains the message*/
int ID;/*!< info that needs to be transmitted*/
int light;/*!< info that needs to be transmitted*/
int frequency = 2000;/*!< frequency at which Manchester encoding functions,half this frequency is the datarate*/
C12832 lcd(p5, p7, p6, p8, p11);/*!< used to print text*/
RGB RGBled(p23,p24,p25);/*!< RGB used to transmit data*/
BusIn joystick(p12,p13,p15,p16);/*!< joystick to select a state*/
enum States {Init,Send};/*!< states of the state machine*/
States State = Init;/*!< Initialize State to Init */

/**
* This is the main method which makes use of the fillArray en OutputData methods.
* @return Nothing.
*/

int main()
{

  while(true){
    switch (State)/*!< state machine */
    {
      case Init:/*!< state "Init" */
      {
        RGBled.write(0,0,0);/*!<  put the RGB to off */
        ID =0;/*!< initialize ID to 0 */
        light =0;/*!< initialize light to 0 */
        State = Send;/*!< goes to the next state */
        break;
      }

      case Send:/*!< state "Send" */
      {
        lcd.cls();
        lcd.locate(1,0);
        lcd.printf("Please select 1 of 4 locations(up,down,left,right)");/*!< text that will be printed on the screen during the selection of the state */
        wait(0.25);
        switch (joystick)/*!< joystick that selects a state */
        {
          case 0x8: {
            ID =1;/*!< put the ID to the required value*/
            light =1;/*!< put the light to the required value*/
            lcd.cls();
            lcd.locate(1,0);
            lcd.printf("Pokemon #1 has been  sighted in this location");/*!< text that will be printed on the screen during the ouput of data */
            fillArray();/*!< call the method fillArray() */
            while(true)/*!< keep outputing data */
            {
              RGBled.write(1,0,0);/*!< RGB on = high */
              wait_us(2*(1000000/frequency));/*!< wait 2 periods */
              OutputData();/*!< call the method OutputData() */
            }
            break;
          }

          case 0x4: {
            ID =2;/*!< put the ID to the required value*/
            light =2;/*!< put the light to the required value*/
            lcd.cls();
            lcd.locate(1,0);
            lcd.printf("Pokemon #2 has been  sighted in this location");/*!< text that will be printed on the screen during the ouput of data */
            fillArray();/*!< call the method fillArray() */
            while(true)/*!< keep outputing data */
            {
              RGBled.write(0,1,0);/*!< RGB on = high */
              wait_us(2*(1000000/frequency));/*!< wait 2 periods */
              OutputData();/*!< call the method OutputData() */
            }
            break;
          }

          case 0x2: {
            ID =3;/*!< put the ID to the required value*/
            light =3;/*!< put the light to the required value*/
            lcd.cls();
            lcd.locate(1,0);
            lcd.printf("Pokemon #3 has been  sighted in this location");/*!< text that will be printed on the screen during the ouput of data */
            fillArray();/*!< call the method fillArray() */
            while(true)/*!< keep outputing data */
            {
              RGBled.write(0,0,1);/*!< RGB on = high */
              wait_us(2*(1000000/frequency));/*!< wait 2 periods */
              OutputData();/*!< call the method OutputData() */
            }
            break;
          }

          case 0x1: {
            ID =4;/*!< put the ID to the required value*/
            light =4;/*!< put the light to the required value*/
            lcd.cls();
            lcd.locate(1,0);
            lcd.printf("Pokemon #4 has been  sighted in this location");/*!< text that will be printed on the screen during the ouput of data */
            fillArray();/*!< call the method fillArray() */
            while(true)/*!< keep outputing data */
            {
              RGBled.write(1,1,1);/*!< RGB on = high */
              wait_us(2*(1000000/frequency));/*!< wait 2 periods */
              OutputData();/*!< call the method OutputData() */
            }
            break;
          }
        }
        break;
      }
    }
  }
}

/**
* Method to fill an array of integers that contain a message and encode it with Hamming encoding
*/

void fillArray()
{
  data[2] =0;/*!< SOF */
  data[4] =1;/*!< SOF */
  data[5] =0;/*!< SOF */
  data[6] =1;/*!< SOF */
  data[8] =0;/*!< empty data bit */
  data[9] =0;/*!< empty data bit */
  if (ID == 1 || ID == 2)/*!< binary = 00 or 01 */
  {
    data[10] = 0; /*!< second ID bit */
    data[12] = 0; /*!< second LED bit */
  }
  else/*!< binary = 10 or 11 */
  {
    data[10] = 1; /*!< second ID bit */
    data[12] = 1; /*!< second LED bit */
  }
  if (ID == 1 || ID == 3)/*!< binary = 00 or 10 */
  {
    data[11] = 0; /*!< first ID bit */
    data[13] = 0; /*!< first LED bit */
  }
  else/*!< binary = 01 or 11 */
  {
    data[11] = 1; /*!< first ID bit */
    data[13] = 1; /*!< first LED bit */
  }
  data[14] =0;/*!< empty data bit */
  data[16] =0;/*!< empty data bit */
  data[17] =1;/*!< EOF,can be used as data bit if necesarry */
  data[18] =0;/*!< EOF,can be used as data bit if necesarry */
  data[19] =1;/*!< EOF,can be used as data bit if necesarry */
  data[20] =0;/*!< EOF,can be used as data bit if necesarry */

  data[0]=data[2]^data[4]^data[6]^data[8]^data[10]^data[12]^data[14]^data[16]^data[18]^data[20];/*!< calculating parity bit */
  data[1]=data[2]^data[5]^data[6]^data[9]^data[10]^data[13]^data[14]^data[17]^data[18]^data[20];/*!< calculating parity bit */
  data[3]=data[4]^data[5]^data[6]^data[11]^data[12]^data[13]^data[14]^data[19]^data[20];/*!< calculating parity bit */
  data[7]=data[8]^data[9]^data[10]^data[11]^data[12]^data[13]^data[14];/*!< calculating parity bit */
  data[15]=data[16]^data[17]^data[18]^data[19]^data[20];/*!< calculating parity bit */
}

/**
* Method to output an array of integers on an RGB using Manchester encoding
*/

void OutputData()

{
  int i = 0;/*!< used for the for-loops */

  switch (ID)/*!< switch case depending on ID */
  {
    case 1:/*!< RGB color = red */
    {
      /*!< send a 1 using manchester encoding*/
      RGBled.write(1,0,0);/*!< RGB on = high */
      wait_us(1000000/frequency/2);/*!< wait half a period */
      RGBled.write(0,0,0);/*!< RGB off = low */
      wait_us(1000000/frequency/2);/*!< wait half a period */

      for (i=0;i<LENGTH;i++)/*!< run through the data array */
      {
        if(data[i]==1)/*!< transition from low to high */
        {
          /*!< send a 1 using manchester encoding*/
          RGBled.write(0,0,0);/*!< RGB off = low */
          wait_us(1000000/frequency/2);/*!< wait half a period */
          RGBled.write(1,0,0);/*!< RGB on = high */
          wait_us(1000000/frequency/2);/*!< wait half a period */
        }
        else/*!< transition from high to low */
        {
          /*!< send a 0 using manchester encoding*/
          RGBled.write(1,0,0);/*!< RGB on = high */
          wait_us(1000000/frequency/2);/*!< wait half a period */
          RGBled.write(0,0,0);/*!< RGB off = low */
          wait_us(1000000/frequency/2);/*!< wait half a period */
        }

      }
      break;
    }
    case 2:/*!< RGB color = green */
    {
      /*!< send a 1 using manchester encoding*/
      RGBled.write(0,1,0);/*!< RGB on = high */
      wait_us(1000000/frequency/2);/*!< wait half a period */
      RGBled.write(0,0,0);/*!< RGB off = low */
      wait_us(1000000/frequency/2);/*!< wait half a period */

      for (i=0;i<LENGTH;i++)/*!< run through the data array */
      {
        if(data[i]==1)/*!< transition from low to high */
        {
          /*!< send a 1 using manchester encoding*/
          RGBled.write(0,0,0);/*!< RGB off = low */
          wait_us(1000000/frequency/2);/*!< wait half a period */
          RGBled.write(0,1,0);/*!< RGB on = high */
          wait_us(1000000/frequency/2);/*!< wait half a period */
        }
        else/*!< transition from high to low */
        {
          /*!< send a 0 using manchester encoding*/
          RGBled.write(0,1,0);/*!< RGB on = high */
          wait_us(1000000/frequency/2);/*!< wait half a period */
          RGBled.write(0,0,0);/*!< RGB off = low */
          wait_us(1000000/frequency/2);/*!< wait half a period */
        }
      }
      break;
    }
    case 3:/*!< RGB color = blue */
    {

      RGBled.write(0,0,1);/*!< RGB on = high */
      wait_us(1000000/frequency/2);/*!< wait half a period */
      RGBled.write(0,0,0);/*!< RGB off = low */
      wait_us(1000000/frequency/2);/*!< wait half a period */

      for (i=0;i<LENGTH;i++)/*!< run through the data array */
      {
        if(data[i]==1)/*!< transition from low to high */
        {
          RGBled.write(0,0,0);/*!< RGB off = low */
          wait_us(1000000/frequency/2);/*!< wait half a period */
          RGBled.write(0,0,1);/*!< RGB on = high */
          wait_us(1000000/frequency/2);/*!< wait half a period */
        }
        else/*!< transition from high to low */
        {
          RGBled.write(0,0,1);/*!< RGB on = high */
          wait_us(1000000/frequency/2);/*!< wait half a period */
          RGBled.write(0,0,0);/*!< RGB off = low */
          wait_us(1000000/frequency/2);/*!< wait half a period */
        }
      }
      break;
    }
    case 4:/*!< RGB color = white */
    {

      RGBled.write(1,1,1);/*!< RGB on = high */
      wait_us(1000000/frequency/2);/*!< wait half a period */
      RGBled.write(0,0,0);/*!< RGB off = low */
      wait_us(1000000/frequency/2);/*!< wait half a period */

      for (i=0;i<LENGTH;i++)/*!< run through the data array */
      {
        if(data[i]==1)/*!< transition from low to high */
        {
          RGBled.write(0,0,0);/*!< RGB off = low */
          wait_us(1000000/frequency/2);/*!< wait half a period */
          RGBled.write(1,1,1);/*!< RGB on = high */
          wait_us(1000000/frequency/2);/*!< wait half a period */
        }
        else/*!< transition from high to low */
        {
          RGBled.write(1,1,1);/*!< RGB on = high */
          wait_us(1000000/frequency/2);/*!< wait half a period */
          RGBled.write(0,0,0);/*!< RGB off = low */
          wait_us(1000000/frequency/2);/*!< wait half a period */
        }
      }
      break;
    }
  }
}
