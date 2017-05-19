#include "mbed.h"
#include "NrfNetwork.h"
#include "Decoder.h"

Nrf nrf(p5,p6,p7,p8,p9,p10);
Packet packet(0);   
NrfNetwork network;
Decoder decoder; 
InterruptIn button(p14);
	
DigitalOut led1(LED1);
DigitalIn input1(p21);
DigitalIn input2(p22);
DigitalIn input3(p23);

void edge(){
    decoder.selectPin(input1,input2,input3);
    decoder.run(led1);
    packet.addPokemon(decoder.getID());
    printf("%c", packet.getPokemon());
    network.send(nrf,packet);  
    wait(1);
}

int main() {
    network.init(nrf);
    button.rise(&edge); 
}