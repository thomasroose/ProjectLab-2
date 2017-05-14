#include "Nrf.h"

Nrf::Nrf(PinName mosi, PinName miso, PinName sck, PinName csn, PinName ce, PinName irq):nRF24L01P(mosi,miso,sck,csn,ce,irq){
    this->mosi = mosi;
    this->miso = miso;
    this->sck = sck;
    this->csn = csn;
    this->ce = ce;
    this->irq = irq;
}
