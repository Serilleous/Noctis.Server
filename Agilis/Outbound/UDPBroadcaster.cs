using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace Agilis.Outbound
{
    public class UDPBroadcaster
    {
        UdpClient client;
        IPAddress multicastIP;

        public UDPBroadcaster()
        {
            client = new UdpClient();
            client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            client.ExclusiveAddressUse = false;

            multicastIP = IPAddress.Parse("192.168.1.1");
            client.JoinMulticastGroup(multicastIP);
        }

        public void Broadcast(Byte[] message)
        {
            client.Send(message, message.Length);
        }


        //public void Subscribe(IPAddress address)
        //{
        //    client.JoinMulticastGroup(address);
        //}
    }
}