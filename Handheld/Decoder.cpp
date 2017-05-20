#include "Decoder.h"

Decoder::Decoder(){
    frequency = 2000; 
    period = 1000000/frequency;
    startHammingFound = false;
    startDataFound = false;
}

void Decoder::selectPin(DigitalIn input1, DigitalIn input2, DigitalIn input3){
    while (DataFound == false){
        if ((input1.read() ==0) && (input2.read() !=0) && (input3.read() !=0)){//red light{
            a= p21;
            DataFound = true;
        }else if ((input2.read() ==0) && (input3.read() !=0) && (input1.read() !=0)){//green light
            a=p22;
            DataFound = true;
        }else if ((input3.read() ==0) && (input1.read() !=0) && (input2.read() !=0)){//blue light
            a=p23;
            DataFound = true;
        }if ((input3.read() ==0) && (input1.read() ==0) && (input2.read() ==0)){//white light
            a=p21;
            DataFound = true;
        }
    }
    input = new DigitalIn(a);
}

void Decoder::poll(DigitalOut led){
    while(startDataFound != true)
    {
        counter = 0;
        for (size_t p = 0; p < 10; p++){
            if ((*input).read()== 0){
                counter++;
            }else{
                break;
            }
        wait_us(period/5);
        }
        if (counter == 10){
            startDataFound = true;
            led = true;
        }
    }
}

void Decoder::decode(){
    printf("Decode method");
    DigitalOld = 0;
    DigitalNew = 0;
    int n = 0;

    while (DigitalOld == DigitalNew){
        wait_us(1000000/(10*frequency)); 
        DigitalNew = ((*input).read()); 
    }
    wait_us (period+50);

    for (int i = 0; i < 42; i++){
        int newData = (*input).read();

        if(newData>=1){
            data[i] = 0;
        }else{
            data[i] = 1;
        }
        wait_us(period); 
    }

    while(startHammingFound == false){
        if (n>40){
            break;
        }
        if ((data[n] == 0) && (data[n+2] == 1) && (data[n+3] == 0) && (data[n+4] == 1)){
            //Start has been found,exit the while
            startHammingFound = true ; 
        }else{
            n++;
        }
    }

    c1=data[0]^data[2]^data[4]^data[6]^data[8]^data[10]^data[12]^data[14]^data[16]^data[18]^data[20];
    c2=data[1]^data[2]^data[5]^data[6]^data[9]^data[10]^data[13]^data[14]^data[17]^data[18]^data[20];
    c3=data[3]^data[4]^data[5]^data[6]^data[11]^data[12]^data[13]^data[14]^data[19]^data[20];
    c4=data[7]^data[8]^data[9]^data[10]^data[11]^data[12]^data[13]^data[14];
    c5=data[15]^data[16]^data[17]^data[18]^data[19]^data[20];
    
    //Determin if a bit-error happened checking even parity
    c=c5*16+c4*8+c3*4+c2*2+c1 ; 
  
    if(c!=0){
        if(data[c-1]==0){
            data[c-1]=1;
        }else{
            data[c-1]=0;
        }
    }
    
    //Filling up the message array with the actual message send
    message[0]=data[2]; 
    for (size_t v = 1; v < 5; v++)
    {
        message[v] = data[v+3];
    }

    for (size_t w = 4; w < 11; w++) {
        message[w] = data[w+4];
    }
  
    for (size_t x = 11; x < 16; x++) {
        message[x] = data[x+5];
    }
  
    for (size_t l = 0; l < 16; l++){
        printf("%d", message[l]);
    }
    SOFFound = true;
}

int Decoder::getID(){
    int ID =0;
  
    if(message[8]==1){
        if(message[9]==1){
            ID=4;
        }else{
            ID=3;
        }
    }else{
        if(message[9]==1){
            ID=2;
        }else{
            ID=1;
        }
    }
    printf("getID: %d",ID);
    return ID;
}

void Decoder::run(DigitalOut led){
    SOFFound = false;
    while(!SOFFound){
        poll(led);
        decode();
    }
}