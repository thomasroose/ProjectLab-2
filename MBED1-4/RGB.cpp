#include "mbed.h"
#include "RGB.h"
//Class to control an RGB LED using three PWM pins


RGBLed::RGBLed (PinName redpin, PinName greenpin, PinName bluepin)
: _redpin(redpin), _greenpin(greenpin), _bluepin(bluepin)
{
    //50Hz PWM clock default a bit too low, go to 2000Hz (less flicker)
    _redpin.period(0.0005);
    _greenpin.period(0.0005);
    _bluepin.period(0.0005);
}

void RGBLed::write(float red,float green, float blue)
{
    _redpin = red;
    _greenpin = green;
    _bluepin = blue;
}
