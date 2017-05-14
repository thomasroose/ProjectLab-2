#ifndef NRFNETWORK
#define NRFNETWORK

#include <stdint.h>
#include <string>
#include <iostream>
#include <sstream>
#include <stdio.h>
#include <string.h>

#include "mbed.h"
#include "Nrf.h"
#include "Packet.h"
#include "Communication.h"


#define TRANSFER_SIZE 4

/**
 *  The NrfNetwork class is used for implementing the NRF24L01+ chip 
 */
class NrfNetwork{
    public:
        /**
         *  The init method is used for initializing the NRF24L01+ network
         *  @param nrf      reference to the nrf chip
         */
        void init(Nrf &nrf);
        
        /** 
         *  The receive method is used for receiving data via the NRF24L01+ chip
         *  @param nrf      reference to the nrf chip
         *  @param packet   reference to the packet
         *  @param com      reference to the com object
         */
        void receive(Nrf &nrf, Packet &packet, Communication &com); 
        
        /**
         *  The send method is used for sending data via the NRF24L01+ chip
         *  @param nrf      reference to the nrf chip
         *  @param packet   reference to the packet
         */
        void send (Nrf &nrf, Packet &packet);
        
        /**
         *  The readIntFromBuffer method is used to read the char array and convert the read data to integer 
         *  @param buffer[] char array that is read
         */
        int readIntFromBuffer(char buffer[]);
        
    private:
    
        char rxData[TRANSFER_SIZE], txData[TRANSFER_SIZE];
        int txDataCnt, rxDataCnt;    
};

#endif
