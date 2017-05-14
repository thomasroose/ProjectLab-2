#include "Communication.h"

Communication::Communication(){}

void Communication::connect(){
    ethernet = new EthernetInterface();
    
    char ip[14] = "192.168.0.2";
    ethernet->init(ip,"255.255.255.0","192.168.0.1");
    
    ethernet->connect();
    printf("\nServer IP Address is %s\r\n",ethernet->getIPAddress());
    server = new TCPSocketServer();
    server->bind(ECHO_SERVER_PORT);
    server->listen();
    printf("\nListening...\r\n"); 
}

void Communication::receive(Packet &packet){
    printf("\r\nReceive mode\n");
    printf("\rWait for new connection...\r\n\n");
    
    TCPSocketConnection client;
    server->accept(client);
    client.set_blocking(false, 1500);
    
    char buffer[100];
    
    printf("Connection from: %s\r\n", client.get_address());
    while (true) {
        int n = client.receive(buffer, sizeof(buffer));
        if (n <= 0) {
            break;    
        }else{
        packet.receivePacket(buffer);
        buffer[n] = '\0';
        client.close();
        
        //Print message to terminal
        printf("\r\nPokemon Number = %d\r\n",packet.getPokemon());
        break;
        }
    }
}

void Communication::send(Packet &packet){
    printf("\nSend mode\r\n");
    TCPSocketConnection client;
    
    while(client.connect("192.168.0.3",ECHO_SERVER_PORT)){
        wait(1);    
    }

    char sendpacket[100];
    packet.sendPacket(sendpacket);
    client.send_all(sendpacket,sizeof(sendpacket)-1);
    
    printf("\nPokemon Number = %d\r\n",packet.getPokemon());
    client.close(); 
}