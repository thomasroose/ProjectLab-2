using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCP
{
    public class Packet
    {
        private byte[] packet = new byte[100];

        public Packet() { }

        public Packet(int pokemon)
        {
            packet[0] = (byte)pokemon;
        }

        public int getPokemon()
        {
            return packet[0];
        }

        public void addPokemon(int pokemon)
        {
            packet[0] = (byte)pokemon;
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
