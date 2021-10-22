using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
	// Token: 0x0200001B RID: 27
	public class iTalk_Separator : Control
	{
		// Token: 0x0600013C RID: 316 RVA: 0x0000C816 File Offset: 0x0000AA16
		public iTalk_Separator()
		{
			base.SetStyle(ControlStyles.ResizeRedraw, true);
			base.Size = new Size(120, 10);
		}

		// Token: 0x0600013D RID: 317 RVA: 0x0000C836 File Offset: 0x0000AA36
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			e.Graphics.DrawLine(new Pen(Color.FromArgb(184, 183, 188)), 0, 5, base.Width, 5);
		}
	}
}
