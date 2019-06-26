using SDRSharp.Radio;
using System;

namespace SDRSharp.RDSOutput
{
	public class RDSHandle : IRdsBitStreamProcessor, IBaseProcessor
	{
		private RDSOutputPanel _rdsDataLoggerPanel;
		private bool _enabled = true;
	
		public bool Enabled
		{
			get
			{
				return this._enabled;
			}
			set
			{
				this._enabled = value;
			}
		}
		
		public RDSHandle(RDSOutputPanel _rdsPanelRef)
		{
			this._rdsDataLoggerPanel = _rdsPanelRef;
		}
		
		public void Process(ref RdsFrame _rdsFrame)
		{
			string text = string.Format("{0:X}", _rdsFrame.GroupA);
			if (text.Length == 4)
			{
				this._rdsDataLoggerPanel.printData(ref _rdsFrame);
			}
			
		}
	}
}
