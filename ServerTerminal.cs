using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace SDRSharp.RDSOutput
{
    public class ServerTerminal
    {
        Socket m_socket;
        SocketListener m_listener;
        
        private bool m_Closed;
        private Socket m_socWorker;

        public event TCPTerminal_MessageRecivedDel MessageRecived;
        public event TCPTerminal_ConnectDel ClientConnect;
        public event TCPTerminal_DisconnectDel ClientDisconnect;
        
        public void StartListen(int port)
        {
            IPEndPoint ipLocal = new IPEndPoint(IPAddress.Any, port);

            m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
            //bind to local IP Address...
            //if ip address is allready being used write to log log
            try
            {
                m_socket.Bind(ipLocal);
            }
            catch(Exception ex)
            {
                Debug.Fail(ex.ToString(),string.Format("Can't connect to port {0}!", port));
                return;
            }
            //start listening...
            m_socket.Listen(4);
            // create the call back for any client connections...
            m_socket.BeginAccept(new AsyncCallback(OnClientConnection), null);
            
        }

        private void OnClientConnection(IAsyncResult asyn)
        {
            if (m_Closed)
            {
                return;
            }

            try
            {
                m_socWorker = m_socket.EndAccept(asyn);

                RaiseClientConnected(m_socWorker);
                
                m_listener = new SocketListener();
                m_listener.MessageRecived += OnMessageRecived;
                m_listener.Disconnected += OnClientDisconnection;

                m_listener.StartReciving(m_socWorker);
            }
            catch (ObjectDisposedException odex)
            {
                Debug.Fail(odex.ToString(), "OnClientConnection: Socket has been closed");
            }
            catch (Exception sex)
            {
                Debug.Fail(sex.ToString(), "OnClientConnection: Socket failed");
            }

        }

        private void OnClientDisconnection(Socket socket)
        {
            RaiseClientDisconnected(socket);

            // Try to re-establish connection
            m_socket.BeginAccept(new AsyncCallback(OnClientConnection), null);

        }

        public void SendMessage(string mes)
        {
            if (m_socWorker == null)
            {
                return;
            }

            try
            {
                Object objData = mes;
                byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
                m_socWorker.Send(byData);
            }
            catch(SocketException se)
            {
            	
            }
          /*  catch (SocketException se)
            {
                Debug.Fail(se.ToString(), string.Format("Message '{0}' could not be sent", mes));
            }*/

        }

        public void Close()
        {
            try
            {
                if (m_socket != null)
                {
                    m_Closed = true;

                    if (m_listener != null)
                    {
                        m_listener.StopListening();
                    }

                    m_socket.Close();

                    m_listener = null;
                    m_socWorker = null;
                    m_socket = null;
                }
            }
            catch (ObjectDisposedException odex)
            {
                Debug.Fail(odex.ToString(), "Stop failed");
            }
        }

        private void OnMessageRecived(string message)
        {
            if (MessageRecived != null)
            {
                MessageRecived(message);
            }
        }

        private void RaiseClientConnected(Socket socket)
        {
            if (ClientConnect != null)
            {
                ClientConnect(socket);
            }
        }

        private void RaiseClientDisconnected(Socket socket)
        {
            if (ClientDisconnect != null)
            {
                ClientDisconnect(socket);
            }
        }
    }
}

