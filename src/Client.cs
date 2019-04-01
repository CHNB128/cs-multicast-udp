using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

class Programm {

  public static void Main () {
    Task.Run (async () => {
      using (var udpClient = new UdpClient (9999)) {
        while (true) {
          var receivedResults = await udpClient.ReceiveAsync ();
          Console.WriteLine (Encoding.ASCII.GetString (receivedResults.Buffer));
        }
      }
    });
    while (true) { }
  }
}