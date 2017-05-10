#ifndef RGB_H
#define RGB_H


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
