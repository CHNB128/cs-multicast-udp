using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Programm {
  public static void Main () {
    var MULTICAST_ADDR = "224.0.1.0";
    var client = new UdpClient ();

    client.JoinMulticastGroup (IPAddress.Parse (MULTICAST_ADDR));
    IPEndPoint remoteEndPoint = new IPEndPoint (IPAddress.Parse (MULTICAST_ADDR), 9999);

    while (true) {
      Random r = new Random ();
      double number = r.NextDouble () * 100;
      byte[] buffer = Encoding.ASCII.GetBytes (number.ToString ());
      client.Send (buffer, buffer.Length, remoteEndPoint);
    }
  }
}