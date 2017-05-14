#include "mbed.h"
#include "nRF24L01P.h"
 
Serial pc(USBTX, USBRX); // tx, rx
 
nRF24L01P my_nrf24l01p(p5, p6, p7, p8, p9, p10);    // mosi, miso, sck, csn, ce, irq
BusIn joystick(p12,p13,p14,p15,p16);

DigitalOut myled1(LED1);
DigitalOut myled2(LED2);
 
int main() {
 
	// The nRF24L01+ supports transfers from 1 to 32 bytes, but Sparkfun's
	//  "Nordic Serial Interface Board" (http://www.sparkfun.com/products/9019)
	//  only handles 4 byte transfers in the ATMega code.
	#define TRANSFER_SIZE   4
 
    char txData[TRANSFER_SIZE];
    
    my_nrf24l01p.powerUp();
    my_nrf24l01p.disable();
    
	//Display the (default) setup of the nRF24L01+ chip
    pc.printf( "nRF24L01+ Frequency    : %d MHz\r\n",  my_nrf24l01p.getRfFrequency() );
    pc.printf( "nRF24L01+ Output power : %d dBm\r\n",  my_nrf24l01p.getRfOutputPower() );
    pc.printf( "nRF24L01+ Data Rate    : %d kbps\r\n", my_nrf24l01p.getAirDataRate() );
    pc.printf( "nRF24L01+ TX Address   : 0x%010llX\r\n", my_nrf24l01p.getTxAddress() );
    pc.printf( "nRF24L01+ RX Address   : 0x%010llX\r\n", my_nrf24l01p.getRxAddress() );
 
    pc.printf( "Send");
 
    my_nrf24l01p.setTransferSize( TRANSFER_SIZE );
 
    my_nrf24l01p.setReceiveMode();
    my_nrf24l01p.enable();
 
    while (1) {
		// ...add it to the transmit buffer
        txData[0] = 'a';
        txData[1] = 'b';
        txData[2] = 'c';
        txData[3] = 'd';
   
        if(joystick == 0b00100){
            // Send the transmitbuffer via the nRF24L01+
            my_nrf24l01p.write( 0, txData, 4 );
            // Toggle LED1 (to help debug Host -> nRF24L01+ communication)
            myled1 = !myled1;
            //break;
		}
    }
}     