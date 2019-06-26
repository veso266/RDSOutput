using System.Net.Sockets;

namespace SDRSharp.RDSOutput
{
    public delegate void TCPTerminal_MessageRecivedDel(string message);
    public delegate void TCPTerminal_ConnectDel(Socket socket);
    public delegate void TCPTerminal_DisconnectDel(Socket socket);
}
