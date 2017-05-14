#ifndef NRF
#define NRF

#include "mbed.h"
#include "nRF24L01P.h"

/**
 *  The Nrf class is used for declaring the NRF24L01+ chip
 *  The Nrf class inherits from the nRF24L01P library
 */
class Nrf: public nRF24L01P{
    public:
        
        /**
         *  The Nrf constructor
         *  @param mosi     SPI Slave Data Input
         *  @param miso     SPI Slave Data Output, with tri-state option
         *  @param sck      SPI Clock
         *  @param csn      SPI Chip Select
         *  @param ce       Chip Enable Activates RX or TX mode
         *  @param irq      Maskable interrupt pin. Active low
         */
        Nrf(PinName mosi, PinName miso, PinName sck, PinName csn, PinName ce, PinName irq);
        
    private:
    
        PinName mosi, miso, sck, csn, ce, irq;
};

#endif