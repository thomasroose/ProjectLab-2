#include "Packet.h"

Packet::Packet(){}

Packet::Packet(int pokemon){
    packet[0] = 0xAA;
    packet[1] = 0x55;
    packet[2] = pokemon;
    packet[3] = 0x55;
    packet[4] = 0xAA;
}

void Packet::sendPacket(char * sendpacket){
    strcpy(sendpacket,packet);
}

void Packet::receivePacket(char * receivepacket){
    strcpy(packet,receivepacket);
}

int Packet::getPokemon(){
    return (int) packet[2];
}

void Packet::addPokemon(int pokemon){
    packet[2] = pokemon;
}

void Packet::incrementPokemon(){
    int temp = getPokemon();    
    temp++;
    addPokemon(temp);
}