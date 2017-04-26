using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCP
{
    /*class Packet
    {
        private char[] packet = new char[100];
        
        public Packet() { }

        public Packet (int pokemon)
        {
            packet[0] = (char) 0xAA;
            packet[1] = (char) 0x55;
            packet[2] = (char) pokemon;
            packet[3] = (char) 0x55;
            packet[4] = (char) 0xAA;
        }

        public int getPokemon()
        {
            return packet[2];
        }

        public void addPokemon(int pokemon)
        {
            packet[2] = (char) pokemon;
        }

        public void addReceivedPacket(char [] receivePacket)
        {
            receivePacket.CopyTo(packet,0);
        }

        public void addSendPacket(char [] sendPacket)
        {
            packet.CopyTo(sendPacket, 0);
        }
    }*/

    class Packet
    {
        private byte[] packet = new byte[100];

        public Packet() { }

        public Packet(int pokemon)
        {
            packet[0] = (byte)0xAA;
            packet[1] = (byte)0x55;
            packet[2] = (byte)pokemon;
            packet[3] = (byte)0x55;
            packet[4] = (byte)0xAA;
        }

        public int getPokemon()
        {
            return packet[2];
        }

        public void addPokemon(int pokemon)
        {
            packet[2] = (byte)pokemon;
        }

        public void addReceivedPacket(byte[] receivePacket)
        {
            receivePacket.CopyTo(packet, 0);
        }

        public void addSendPacket(byte[] sendPacket)
        {
            packet.CopyTo(sendPacket, 0);
        }
    }
}
