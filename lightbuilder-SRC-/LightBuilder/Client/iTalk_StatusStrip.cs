using System;
using System.Windows.Forms;

namespace Client
{
	// Token: 0x0200002A RID: 42
	public class iTalk_StatusStrip : StatusStrip
	{
		// Token: 0x060001B3 RID: 435 RVA: 0x0000ED46 File Offset: 0x0000CF46
		public iTalk_StatusStrip()
		{
			this.Renderer = new ControlRenderer();
			base.SizingGrip = false;
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060001B4 RID: 436 RVA: 0x0000ED60 File Offset: 0x0000CF60
		// (set) Token: 0x060001B5 RID: 437 RVA: 0x0000ED6D File Offset: 0x0000CF6D
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
