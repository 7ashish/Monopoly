using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

static class NetworkManager
{
    static Socket UDPSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
    static Socket TCPSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    static Socket ClientSocket, ServerSocket;
    static public async Task AnnouncePresence()
    {
        UDPSocket.EnableBroadcast = true;
        EndPoint point = new IPEndPoint(IPAddress.Broadcast, 7124);
        TCPSocket.Bind(new IPEndPoint(IPAddress.Any, 7123));
        TCPSocket.Listen(1);
        bool Announce = true;
        await Task.WhenAll(new Task[]
        {
                Task.Run(() =>
                {
                    ClientSocket = TCPSocket.Accept();
                    Announce = false;
                }),
                Task.Run(() =>
                {
                    while (Announce)
                    {
                        UDPSocket.SendTo(Encoding.ASCII.GetBytes("Monopoly Server Here"), point);
                    }
                })
        });
    }
    static public async Task FindServer()
    {
        UDPSocket.EnableBroadcast = true;
        EndPoint Point = new IPEndPoint(IPAddress.Any, 7124);
        UDPSocket.Bind(Point);
        byte[] buffer = new byte[1024];
        await Task.Run(() =>
        {
            UDPSocket.ReceiveFrom(buffer, ref Point);
            TCPSocket.Connect(new IPEndPoint(((IPEndPoint)Point).Address, 7123));
            ServerSocket = TCPSocket;
        });
    }
    static public string Cin()
    {
        throw new NotImplementedException();
    }
    static public void Cout(string s)
    {
        throw new NotImplementedException();
    }
    static public string GetConnectedIP()
    {
        if(ClientSocket == null)
        {
            return ((IPEndPoint)ClientSocket.RemoteEndPoint).ToString();
        }
        else
        {
            return ((IPEndPoint)ServerSocket.RemoteEndPoint).ToString();
        }
    }
}
