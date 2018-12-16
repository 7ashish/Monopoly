using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

static class NetworkManager
{
    static Socket UDPSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
    static Socket TCPSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    static Socket ActiveSocket;
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
                    ActiveSocket = TCPSocket.Accept();
                    Announce = false;
                }),
                Task.Run(() =>
                {
                    while (Announce)
                    {
                        UDPSocket.SendTo(Encoding.ASCII.GetBytes("Monopoly Server Here"), point);
                        Thread.Sleep(1000);
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
            ActiveSocket = TCPSocket;
        });
    }
    static public async Task<string[]> Cin()
    {
        if(ActiveSocket == null || !ActiveSocket.Connected)
        {
            throw new Exception("Not Connected, try calling connection functions first");
        }
        byte[] buffer = new byte[1024];
        int n=0;
        await Task.Run(() =>
        {
            n = ActiveSocket.Receive(buffer);
        });
        if(n == 0)
        {
            ActiveSocket.Shutdown(SocketShutdown.Both);
            ActiveSocket.Close();
            ActiveSocket = null;
            return null;
        }
        return Encoding.ASCII.GetString(buffer, 0, n).Split('#');
    }
    static public void Cout(params string[] strings)
    {
        foreach (string s in strings)
        {
            if (ActiveSocket == null || !ActiveSocket.Connected)
            {
                throw new Exception("Not Connected, try calling connection functions first");
            }
            if (s.Contains('#'))
            {
                throw new FormatException("Unexpected Command" + "#");
            }
            ActiveSocket.Send(Encoding.ASCII.GetBytes(s + "#"));
        }
    }
    static public string GetConnectedIP()
    {
        return ((IPEndPoint)ActiveSocket.RemoteEndPoint).ToString();
    }
}
