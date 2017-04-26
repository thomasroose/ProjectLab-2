#include "mbed.h"
#include "Communication.h"

//Lcd screen(p5,p7,p6,p8,p11);
BusIn joystick(p12,p13,p14,p15,p16);
//nRF24L01P nrf(p5,p6,p7,p8,p9,p10);

int main() {
    
    Packet packet(0);
    Communication com;
    //com.connect(screen);
    com.connect();
    while(true){
        switch(joystick){
            case 0b00100:
                com.send(packet);
                //com.send();
                break;
            case 0b00001:
                com.receive(packet);
                break;
            default:
                break;
        }
    }   
}
