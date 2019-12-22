using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace quotesServerApp {
  class Server {
    private const string ipAddr = "127.0.0.1";
    private const string mipAddr = "224.0.1.0";
    private const int port = 9999;

    private IPEndPoint UDPEndPoint;
    private Socket UDPSocket;

    public Server () {
      UDPEndPoint = new IPEndPoint (IPAddress.Parse (ipAddr), port);
      UDPSocket = new Socket (AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
      UDPSocket.Bind (UDPEndPoint);

      MulticastOption mcastOption;
      mcastOption = new MulticastOption (IPAddress.Parse (mipAddr), IPAddress.Parse (ipAddr));

      UDPSocket.SetSocketOption (SocketOptionLevel.IP,
        SocketOptionName.AddMembership,
        mcastOption);

      EndPoint ipep = new IPEndPoint (IPAddress.Parse (mipAddr), 9999);

      Random r = new Random ();

      while (true) {
        double number = r.NextDouble () * 100;

        UDPSocket.SendTo (Encoding.UTF8.GetBytes (number.ToString ()), ipep);
      }
    }

  }

  class Program {

    static void Main (string[] args) {
      Console.ReadKey ();

      var server = new Server ();

      Console.ReadKey ();
    }

  }
}