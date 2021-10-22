using System;
using System.Windows.Forms;

namespace Client
{
	// Token: 0x02000029 RID: 41
	public class iTalk_ContextMenuStrip : ContextMenuStrip
	{
		// Token: 0x060001B0 RID: 432 RVA: 0x0000ED1D File Offset: 0x0000CF1D
		public iTalk_ContextMenuStrip()
		{
			this.Renderer = new ControlRenderer();
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060001B1 RID: 433 RVA: 0x0000ED30 File Offset: 0x0000CF30
		// (set) Token: 0x060001B2 RID: 434 RVA: 0x0000ED3D File Offset: 0x0000CF3D
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
