#ifndef COMMUNICATION
#define COMMUNICATION

#include "mbed.h"
#include "EthernetInterface.h"
#include "Lcd.h"
#include "Packet.h"

#include <string>

#define ECHO_SERVER_PORT 4000

class Communication{
    public:
        Communication();
        //void connect(Lcd &screen);
        void connect();
        void receive(Packet &packet);
        void send(Packet &packet);
    private:
        EthernetInterface * ethernet;
        TCPSocketServer * server;       
};
#endif
