﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TcpServerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Listen
            IPAddress address = IPAddress.Parse("127.0.0.1");
            TcpListener listener = new TcpListener(address, 8888);
            listener.Start();
            Socket socket = listener.AcceptSocket();
            //2. Receive
            byte[] data = new byte[1024];
            socket.Receive(data);
            string str = Encoding.ASCII.GetString(data);
            //3. Send
            socket.Send(Encoding.ASCII.GetBytes("Hello, " + str));
            //4. Close
            socket.Close();
            listener.Stop();
        }
    }
}
