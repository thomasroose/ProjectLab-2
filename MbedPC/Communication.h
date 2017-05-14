#ifndef COMMUNICATION
#define COMMUNICATION

#include <string>

#include "mbed.h"
#include "EthernetInterface.h"
#include "Packet.h"

#define ECHO_SERVER_PORT 4000

/**
 *  The Communication class is used for implementing Ethernet
 */
class Communication{
    public:
        /**
         *  Communication default constructor
         */
        Communication();
        
        /**
         *  Method that initializes the communication
         */
        void connect();
        
        /**
         *  Method that is used for receiving a packet
         *  @param packet   reference to the packet
         */
        void receive(Packet &packet);
        
        /**
         *  Method that is used for sending a packet
         *  @param packet   reference to the packet
         */
        void send(Packet &packet);
        
    private:
    
        EthernetInterface * ethernet;
        TCPSocketServer * server;       
};

#endif
