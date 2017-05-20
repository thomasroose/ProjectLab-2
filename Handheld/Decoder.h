#ifndef DECODER
#define DECODER

#include "mbed.h"

/**
 *  Decoder class does the decoding of the Visible Light Communication
 */
class Decoder{
    public:
        /**
         *  Default constructor
         */
        Decoder();
 
        /**
         * Listen until a correct start sequence is found
         * @param   led     this led is on when a correct sequence is detected
         */
        void poll(DigitalOut led);

        /**
         * Decoding the received data to the actual message
         */
        void decode();
        
        /**
         * Get the pokémon integer
         */
        int getID();
        
        /**
         * Select the correct pins for reading the data
         */
        void selectPin(DigitalIn input1, DigitalIn input2, DigitalIn input3);
        
        /**
         * Check for the correct start sequence and decode if the sequence is found
         */
        void run(DigitalOut led);
        
    private:
        int frequency, period, counter, DigitalNew, DigitalOld; 
        int c, c1, c2, c3, c4, c5;
        int data [42]; 
        int message[16]; 
        bool startDataFound, startHammingFound, DataFound, SOFFound;
        DigitalIn *input;
        PinName a;
};

#endif