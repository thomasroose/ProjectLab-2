#include<stdio.h>
#include<conio.h>

int main() {
	int data[21],rec[21],i,c1,c2,c3,c4,c5,c;
	printf("this works for message of 16 bits in size \nenter message bit one by one:  ");
	scanf("%d %d %d %d %d %d %d %d %d %d %d %d %d %d %d %d",
	&data[2],&data[4],&data[5],&data[6],&data[8],&data[9],&data[10],&data[11],&data[12],&data[13],&data[14],&data[16],&data[17],&data[18],&data[19],&data[20]);
	data[0]=data[2]^data[4]^data[6]^data[8]^data[10]^data[12]^data[14]^data[16]^data[18]^data[20];
	data[1]=data[2]^data[5]^data[6]^data[9]^data[10]^data[13]^data[14]^data[17]^data[18]^data[20];
	data[3]=data[4]^data[5]^data[6]^data[11]^data[12]^data[13]^data[14]^data[19]^data[20];
	data[7]=data[8]^data[9]^data[10]^data[11]^data[12]^data[13]^data[14];
	data[15]=data[16]^data[17]^data[18]^data[19]^data[20];
	printf("\nthe encoded bits are given below: \n");
	for (i=0;i<21;i++) {
		printf("%d ",data[i]);
	}


	printf("\nenter the received data bits one by one: ");
	for (i=0;i<21;i++) {
		scanf("%d",&rec[i]);
	}
	c1=rec[0]^rec[2]^rec[4]^rec[6]^rec[8]^rec[10]^rec[12]^rec[14]^rec[16]^rec[18]^rec[20];
	c2=rec[1]^rec[2]^rec[5]^rec[6]^rec[9]^rec[10]^rec[13]^rec[14]^rec[17]^rec[18]^rec[20];
	c3=rec[3]^rec[4]^rec[5]^rec[6]^rec[11]^rec[12]^rec[13]^rec[14]^rec[19]^rec[20];
	c4=rec[7]^rec[8]^rec[9]^rec[10]^rec[11]^rec[12]^rec[13]^rec[14];
	c5=rec[15]^rec[16]^rec[17]^rec[18]^rec[19]^rec[20];
	c=c5*16+c4*8+c3*4+c2*2+c1 ;
	if(c==0) {
		printf("\ncongratulations there is no error: ");
		printf("\nyour message is: ");
		printf("%d %d %d %d %d %d %d %d %d %d %d %d %d %d %d %d",rec[2],rec[4],rec[5],rec[6],rec[8],rec[9],rec[10],rec[11],rec[12],rec[13],rec[14],rec[16],rec[17],rec[18],rec[19],rec[20]);
	} else {
		printf("\nerron on the postion: %d\nthe correct message is \n",c);
		if(rec[c-1]==0)
		 			rec[c-1]=1; else
		 			rec[c-1]=0;
		for (i=0;i<21;i++) {
			printf("%d ",rec[i]);
		}
		printf("\nyour message is: ");
		printf("%d %d %d %d %d %d %d %d %d %d %d %d %d %d %d %d",rec[2],rec[4],rec[5],rec[6],rec[8],rec[9],rec[10],rec[11],rec[12],rec[13],rec[14],rec[16],rec[17],rec[18],rec[19],rec[20]);
	}
	getch();
}
