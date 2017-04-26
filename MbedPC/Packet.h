#ifndef PACKET
#define PACKET

#include "mbed.h"
#include <string>



/**
 * Packet class is responsible for the creation of a packet
 */
class Packet{
    public:
    
        /**
         * Packet default constructor
         */
        Packet();
        Packet(int pokemon);
        void receivePacket(char * receivepacket);
        void sendPacket(char * sendpacket);
        
        int getPokemon();
        void addPokemon(int pokemon);
        
    private:
        char packet[100]; 
};

#endif