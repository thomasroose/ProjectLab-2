#include "NrfNetwork.h"

void NrfNetwork::init(Nrf &nrf){
    nrf.powerUp();
    nrf.disable();
    
    printf( "nRF24L01+ Frequency    : %d MHz\r\n",  nrf.getRfFrequency() );
    printf( "nRF24L01+ Output power : %d dBm\r\n",  nrf.getRfOutputPower() );
    printf( "nRF24L01+ Data Rate    : %d kbps\r\n", nrf.getAirDataRate() );
    printf( "nRF24L01+ TX Address   : 0x%010llX\r\n", nrf.getTxAddress() );
    printf( "nRF24L01+ RX Address   : 0x%010llX\r\n", nrf.getRxAddress() );
    
    nrf.setTransferSize( TRANSFER_SIZE);
    nrf.setReceiveMode();
    nrf.enable();
}

void NrfNetwork::send(Nrf &nrf, Packet &packet){
    printf("\r\nSend mode\r\n");
    
    while (true) {
        // ...add it to the transmit buffer    
        int pokemon = packet.getPokemon();
        string result;
        ostringstream convert;
        convert << pokemon;
        result = convert.str();
        char *dummy = (char*)result.c_str();

        //Increment method
        pokemon = pokemon + 1;
        packet.addPokemon(pokemon);
    
        for(int i = 0; i < sizeof(dummy); i++){
            txData[i] = dummy[i];
        }
        
        for (int i = sizeof(dummy)-1; i < 4; i++){
            txData[i] = '|';
        } 
    
        for (int i = 0; i < 4; i++){
            printf("%c", txData[i]);
        }
         
        // Send the transmitbuffer via the nRF24L01+
        nrf.write( 0, txData, 4); 
        printf("\r\n%d",readIntFromBuffer(txData));
        break;
    }
}

void NrfNetwork::receive(Nrf &nrf, Packet &packet){
    printf("Receive mode\r\n");
    
    txDataCnt = 0;
    rxDataCnt = 0;

    while (1) {
        // If we've received anything in the nRF24L01+...
        if ( nrf.readable() ) {
            // ...read the data into the receive buffer
            rxDataCnt = nrf.read( NRF24L01P_PIPE_P0, rxData, 4);
            
            int number = readIntFromBuffer(rxData);
            packet.addPokemon(number);
        }
    }
}

int NrfNetwork::readIntFromBuffer(char buffer []){
    int pokemon = 0;
    for(int i = 0; i < sizeof(buffer); i++){
        int ascii = (int)buffer[i];
        if(ascii >=  48 && ascii <= 57){
            int number = ascii - 48;
            pokemon = pokemon * 10 + number;
        }
    }  
    return pokemon;
}




