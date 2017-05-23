#include "mbed.h"
#include "RGB.h"

/**
* <h1> RGB </h1>
* The RGB program implements Class to control an RGB LED using three PWM pins
*
* @author  Pedro Cattrysse
* @version 1.0
* @since   2017-05-17
*/

/**
* Constructor
*/

RGB::RGB (PinName redpin, PinName greenpin, PinName bluepin)
: _redpin(redpin), _greenpin(greenpin), _bluepin(bluepin)
{
}

/**
* Method to change the values of the 3 components of the RGB
*/

void RGB::write(int red,int green, int blue)
{
    _redpin = red;
    _greenpin = green;
    _bluepin = blue;
}
