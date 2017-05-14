#include "Packet.h"

Packet::Packet(){}

Packet::Packet(int pokemon){
    packet[0] = (char) pokemon;
}

void Packet::sendPacket(char * sendpacket){
    strcpy(sendpacket,packet);
}

void Packet::receivePacket(char * receivepacket){
    strcpy(packet,receivepacket);
}

int Packet::getPokemon(){
    return (int) packet[0];
}

void Packet::addPokemon(int pokemon){
    packet[0] = pokemon;
}
