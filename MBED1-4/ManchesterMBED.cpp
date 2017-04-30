#include "stdint.h"
#include "mbed.h"
#include "C12832.h"
#include "RGB.h"


void fillArray();
void OutputData();

const int LENGTH = 21;
int data[LENGTH];
int ID;
int light;
int frequency = 2000;
C12832 lcd(p5, p7, p6, p8, p11);
RGB RGBled(p23,p24,p25);
BusIn joystick(p12,p13,p15,p16);
enum States {Init,Send};
States State = Init;
DigitalOut ledInit(LED1);
DigitalOut ledSend(LED2);

int main()
{

  while(true){
    switch (State)
    {
      case Init:
      {
        ledInit=true;
        RGBled.write(1.0,1.0,1.0);
        ID =0;
        light =0;
        State = Send;
        break;
      }

      case Send:
      {
        ledInit=false;
        ledSend = true;
        lcd.cls();
        lcd.locate(1,0);
        lcd.printf("Please select 1 of 4 locations(up,down,left,right)");
        wait(0.25);
        switch (joystick)
        {
          case 0x8: {
            ID =1;
            light =1;
            lcd.cls();
            lcd.locate(1,0);
            lcd.printf("Pokemon #1 has been  sighted in this location");
            fillArray();
            while(true)
            {
              OutputData();
            }
            break;
          }

          case 0x4: {
            ID =2;
            light =2;
            lcd.cls();
            lcd.locate(1,0);
            lcd.printf("Pokemon #2 has been  sighted in this location");
            fillArray();
            while(true)
            {
              OutputData();
            }
            break;
          }

          case 0x2: {
            ID =3;
            light =3;
            lcd.cls();
            lcd.locate(1,0);
            lcd.printf("Pokemon #3 has been  sighted in this location");
            fillArray();
            while(true)
            {
              OutputData();
            }
            break;
          }

          case 0x1: {
            ID =4;
            light =4;
            lcd.cls();
            lcd.locate(1,0);
            lcd.printf("Pokemon #4 has been  sighted in this location");
            fillArray();
            while(true)
            {
              OutputData();
            }
            break;
          }
        }
        break;
      }
    }
  }
}

void fillArray()
{
  data[2] =0;//SOF
  data[4] =1;//SOF
  data[5] =0;//SOF
  data[6] =1;//SOF
  data[8] =0;
  data[9] =0;
  if (ID == 1 || ID == 2)
  {
    data[10] = 0; //second ID bit
    data[12] = 0; //second LED bit
  }
  else
  {
    data[10] = 1; //second ID bit
    data[12] = 1; //second LED bit
  }
  if (ID == 1 || ID == 3)
  {
    data[11] = 0; //first ID bit
    data[13] = 0; //first LED bit
  }
  else
  {
    data[11] = 1; //first ID bit
    data[13] = 1; //first LED bit
  }
  data[14] =0;
  data[16] =0;
  data[17] =1;//EOF
  data[18] =0;//EOF
  data[19] =1;//EOF
  data[20] =0;//EOF

  data[0]=data[2]^data[4]^data[6]^data[8]^data[10]^data[12]^data[14]^data[16]^data[18]^data[20];
  data[1]=data[2]^data[5]^data[6]^data[9]^data[10]^data[13]^data[14]^data[17]^data[18]^data[20];
  data[3]=data[4]^data[5]^data[6]^data[11]^data[12]^data[13]^data[14]^data[19]^data[20];
  data[7]=data[8]^data[9]^data[10]^data[11]^data[12]^data[13]^data[14];
  data[15]=data[16]^data[17]^data[18]^data[19]^data[20];
}

void OutputData()

{
  int i = 0;

  switch (ID)
  {
    case 1:
    {
      for (i=0;i<LENGTH;i++)
      {
        if(data[i]==1)      //transition 0 => 1
        {
          RGBled.write(1.0,1.0,1.0);
          wait_us(1000000/frequency/2);
          RGBled.write(0.0,1.0,1.0);
          wait_us(1000000/frequency/2);
        }
        else               //transition 1 => 0
        {
          RGBled.write(0.0,1.0,1.0);
          wait_us(1000000/frequency/2);
          RGBled.write(1.0,1.0,1.0);
          wait_us(1000000/frequency/2);
        }

      }
      break;
    }
    case 2:
    {
      for (i=0;i<LENGTH;i++)
      {
        if(data[i]==1)      //transition 0 => 1
        {
          RGBled.write(1.0,1.0,1.0);
          wait_us(1000000/frequency/2);
          RGBled.write(1.0,0.0,1.0);
          wait_us(1000000/frequency/2);
        }
        else               //transition 1 => 0
        {
          RGBled.write(1.0,0.0,1.0);
          wait_us(1000000/frequency/2);
          RGBled.write(1.0,1.0,1.0);
          wait_us(1000000/frequency/2);
        }
      }
      break;
    }
    case 3:
    {
      for (i=0;i<LENGTH;i++)
      {
        if(data[i]==1)      //transition 0 => 1
        {
          RGBled.write(1.0,1.0,1.0);
          wait_us(1000000/frequency/2);
          RGBled.write(1.0,1.0,0.0);
          wait_us(1000000/frequency/2);
        }
        else               //transition 1 => 0
        {
          RGBled.write(1.0,1.0,0.0);
          wait_us(1000000/frequency/2);
          RGBled.write(1.0,1.0,1.0);
          wait_us(1000000/frequency/2);
        }
      }
      break;
    }
    case 4:
    {
      for (i=0;i<LENGTH;i++)
      {
        if(data[i]==1)      //transition 0 => 1
        {
          RGBled.write(1.0,1.0,1.0);
          wait_us(1000000/frequency/2);
          RGBled.write(0.0,0.0,0.0);
          wait_us(1000000/frequency/2);
        }
        else               //transition 1 => 0
        {
          RGBled.write(0.0,0.0,0.0);
          wait_us(1000000/frequency/2);
          RGBled.write(1.0,1.0,1.0);
          wait_us(1000000/frequency/2);
        }
      }
      break;
    }
  }
}
