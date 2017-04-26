#ifndef RGB_H
#define RGB_H


class RGB

{
public:
    RGBLed(PinName redpin, PinName greenpin, PinName bluepin);
    void write(float red,float green, float blue);

private:
    PwmOut _redpin;
    PwmOut _greenpin;
    PwmOut _bluepin;

};

#endif
