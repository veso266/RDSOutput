using SDRSharp.Common;
using SDRSharp.Radio;
using System;
using System.Windows.Forms;


namespace SDRSharp.RDSOutput
{
	public class RDSOutput : ISharpPlugin
	{
		private const string MyDisplayName = "RDS Output";
		
		private ISharpControl _controlInterface;
		
		private RDSOutputPanel _rdsOutputPanel;
		
		public bool HasGui
		{
			get
			{
				return true;
			}
		}

        public UserControl Gui
        {
            get
            {
                return this._rdsOutputPanel;
            }
        }	

		public UserControl GuiControl
		{
			get
			{
				return this._rdsOutputPanel;
			}
		}
		
		public string DisplayName
		{
			get
			{
				return "RDS Output";
			}
		}
		
		public void Close()
		{
		}
		
		public void Initialize(ISharpControl control)
		{
			this._controlInterface = control;
			this._rdsOutputPanel = new RDSOutputPanel(this._controlInterface);
			control.RegisterStreamHook(new RDSHandle(this._rdsOutputPanel), ProcessorType.RDSBitStream);
		}
	}
}