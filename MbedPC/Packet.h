#ifndef PACKET
#define PACKET

#include <string>

#include "mbed.h"

/**
 * Packet class is responsible for the creation of a packet
 */
class Packet{
    public:
    
        /**
         * Packet default constructor
         */
        Packet();
        
        /**
         *  Packet constructor
         *  @param pokemon      integer value of a pokemon
         */
        Packet(int pokemon);
        
        /**
         * The receivePacket method puts the elements of the received packet into the packet array
         * @param receivepacket     char array that stores received elements into packet array
         */
        void receivePacket(char * receivepacket);
        
        /**
         * The sendPacket method puts the elements of the packet array into a send packet
         * @param sendpacket    char array where the packet elements are stored in
         */
        void sendPacket(char * sendpacket);
        
        /**
         *  The addPokemon method adds the pokemon integer to the packet
         *  @param pokemon      integer value of a pokemon
         */
        void addPokemon(int pokemon);
        
        /**
         *  The getPokemon method gets the pokemon integer from the packet
         *  @return pokemon integer
         */
        int getPokemon();
        
    private:
    
        char packet[100]; 
};

#endif