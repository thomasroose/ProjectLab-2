#include "Lcd.h"

Lcd::Lcd(PinName mosi, PinName sck, PinName reset, PinName a0, PinName ncs):C12832(mosi, sck, reset, a0, ncs){
    this->mosi = mosi;
    this->sck = sck;
    this->reset = reset;
    this->a0 = a0;
    this->ncs = ncs;
}

