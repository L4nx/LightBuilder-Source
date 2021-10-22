using System;
using System.Windows.Forms;

namespace Client
{
	// Token: 0x02000028 RID: 40
	public class iTalk_MenuStrip : MenuStrip
	{
		// Token: 0x060001AD RID: 429 RVA: 0x0000ECF4 File Offset: 0x0000CEF4
		public iTalk_MenuStrip()
		{
			this.Renderer = new ControlRenderer();
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060001AE RID: 430 RVA: 0x0000ED07 File Offset: 0x0000CF07
		// (set) Token: 0x060001AF RID: 431 RVA: 0x0000ED14 File Offset: 0x0000CF14
		public new ControlRenderer Renderer
		{
			get
			{
				return (ControlRenderer)base.Renderer;
			}
			set
			{
				base.Renderer = value;
			}
		}
	}
}
