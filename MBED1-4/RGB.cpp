#include "mbed.h"
#include "RGB.h"
//Class to control an RGB LED using three PWM pins


RGB::RGB (PinName redpin, PinName greenpin, PinName bluepin)
: _redpin(redpin), _greenpin(greenpin), _bluepin(bluepin)
{
}

void RGB::write(int red,int green, int blue)
{
    _redpin = red;
    _greenpin = green;
    _bluepin = blue;
}
