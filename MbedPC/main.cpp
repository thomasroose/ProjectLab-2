#include "mbed.h"
#include "NrfNetwork.h"

Nrf nrf(p5,p6,p7,p8,p9,p10);

int main() {
    
    Packet packet(0);
    Communication com;
    com.connect();
    
    NrfNetwork network;
    network.init(nrf);
    
    while(true){
        network.receive(nrf,packet,com);
    } 
}
