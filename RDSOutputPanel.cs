
using SDRSharp.Common;
using SDRSharp.Radio;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Timers;
using System.Windows.Forms;
using System.Threading;



using System.Net;
using System.Net.Sockets;
//using System.Text;



namespace  SDRSharp.RDSOutput
{
	public partial class RDSOutputPanel : UserControl
	{
		private readonly ISharpControl _controlInterface;
		
		private bool m_terminalIsOpen = false;
		
		ServerTerminal m_serverTerminal;
		
		public RDSOutputPanel()
		{
			InitializeComponent();
		}
		
		public RDSOutputPanel(ISharpControl control)
		{
			try
			{
				this.InitializeComponent();
				this._controlInterface = control;
			}
			catch (Exception ex)
			{
				string text = string.Format("Error {0}", ex.Message);
				MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}		
		

		
		static void SendUdp2(int srcPort, string dstIp, int dstPort, byte[] sendBytes)
		{
			
			IPEndPoint  Dymola = new IPEndPoint(IPAddress.Parse (dstIp), dstPort);

			
			using(UdpClient udpClient = new UdpClient(srcPort))
			{
				
				
				udpClient.Send(sendBytes, sendBytes.Length, Dymola);
			}
		}		
		
		
		public void printData(ref RdsFrame _rdsFrame)
		{
			
			if(m_terminalIsOpen)
			{
				
				if (checkBoxRFtapOn.Checked == true) {
					byte[] header = {
						0x52,
						0x46,
						0x74,
						0x61,
						4,
						0,
						0,
						0,
						0x10,
						0,
						3,
						0xFF,
						0x72,
						0x64,
						0x73,
						0
					};
				
					byte[] payload = {0,0,0,0,0,0,0,0,0x41,0x42,0x43,0x44};
					
					MemoryStream MS = new MemoryStream();
			
					BinaryWriter Writer1 = new BinaryWriter(MS);
        
					Writer1.Write(header);
        
					payload[0] = (byte) (_rdsFrame.GroupA >> 8 );
					payload[1] = (byte) (_rdsFrame.GroupA & 0x00FF );
					
					payload[2] = (byte) (_rdsFrame.GroupB >> 8 );
					payload[3] = (byte) (_rdsFrame.GroupB & 0x00FF );
					
					payload[4] = (byte) (_rdsFrame.GroupC >> 8 );
					payload[5] = (byte) (_rdsFrame.GroupC & 0x00FF );
					
					payload[6] = (byte) (_rdsFrame.GroupD >> 8 );
					payload[7] = (byte) (_rdsFrame.GroupD & 0x00FF );
					
					Writer1.Write(payload);
		
					var byts = MS.ToArray();
	
					SendUdp2(56148, "101.64.121.21", 52001, byts);
					
					MS.Dispose();		
				}
				
				m_serverTerminal.SendMessage("G:\r\n");
				
				m_serverTerminal.SendMessage(_rdsFrame.GroupA.ToString("X4"));
				m_serverTerminal.SendMessage(_rdsFrame.GroupB.ToString("X4"));
				m_serverTerminal.SendMessage(_rdsFrame.GroupC.ToString("X4"));
				m_serverTerminal.SendMessage(_rdsFrame.GroupD.ToString("X4"));
				
				m_serverTerminal.SendMessage("\r\n\r\n");
			}
		}
		
		void m_Terminal_ClientDisConnected(System.Net.Sockets.Socket socket)
		{
			PublishMessage(listBox1 , string.Format("Client {0} disconnected!", socket.LocalEndPoint));
		}

		void m_Terminal_ClientConnected(System.Net.Sockets.Socket socket)
		{
			PublishMessage(listBox1, string.Format("Client {0} connected!", socket.LocalEndPoint));
		}

		
        private void createTerminal(int alPort)
        {
        	m_serverTerminal = new ServerTerminal();
        	
        	m_serverTerminal.ClientConnect += m_Terminal_ClientConnected;
        	m_serverTerminal.ClientDisconnect += m_Terminal_ClientDisConnected;
        	
        	m_serverTerminal.StartListen(alPort);
        	
        	m_terminalIsOpen = true;
        }
		
        private void closeTerminal()
        {
        	m_terminalIsOpen = false; 
        	
            m_serverTerminal.ClientConnect -= new TCPTerminal_ConnectDel(m_Terminal_ClientConnected);
            m_serverTerminal.ClientDisconnect -= new TCPTerminal_DisconnectDel(m_Terminal_ClientDisConnected);

            m_serverTerminal.Close();
        }
         
 		
        private void PublishMessage(ListBox listBox, string mes)
        {
            if (InvokeRequired)
            {
                BeginInvoke((ThreadStart) delegate { PublishMessage(listBox, mes); });
                return;
            }

            listBox.Items.Add(mes);
        }
        

		void CheckBoxRFtapOnCheckedChanged(object sender, EventArgs e)
		{
			/*	
			if (checkBoxPlugOn.Checked == true) {
				try {
					int alPort = 23;
				
					createTerminal(alPort);
				} catch (Exception se) {
					MessageBox.Show(se.Message);
				}
			}
			else
			{
				closeTerminal();
			}*/
		}
		
		void CheckBoxPDSSpyOnCheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxRDSSpyOn.Checked == true) {
				try {
					const int alPort = 23;
				
					createTerminal(alPort);
				} catch (Exception se) {
					MessageBox.Show(se.Message);
				}
			}
			else
			{
				closeTerminal();
			}
		}		
	}
}
