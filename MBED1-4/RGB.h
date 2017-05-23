#ifndef RGB_H
#define RGB_H

/**
* <h1> RGB.h </h1>
* The header file for the RGB class
*
* @author  Pedro Cattrysse
* @version 1.0
* @since   2017-05-17
*/

class RGB

{
public:
    RGB(PinName redpin, PinName greenpin, PinName bluepin);
    void write(int red,int green, int blue);

private:
    DigitalOut _redpin;
    DigitalOut _greenpin;
    DigitalOut _bluepin;

};

#endif
