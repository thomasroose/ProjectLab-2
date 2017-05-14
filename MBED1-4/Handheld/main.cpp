#include "mbed.h"
#include "NrfNetwork.h"
#include "DebounceIn.h"
#include "PinDetect.h"

Nrf nrf(p5,p6,p7,p8,p9,p10);
InterruptIn button(p14);

Packet packet(1);
NrfNetwork network;

void edge(){
    network.send(nrf,packet);  
}

int main() {
    network.init(nrf);
      
    //button.rise(&edge);
    
    while(true){
        network.send(nrf,packet);
        wait(1);
    }
}
