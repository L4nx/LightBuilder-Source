using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Client
{
	// Token: 0x02000024 RID: 36
	internal class OvalPictureBox : PictureBox
	{
		// Token: 0x0600017B RID: 379 RVA: 0x0000DC64 File Offset: 0x0000BE64
		public OvalPictureBox()
		{
			this.BackColor = Color.DarkGray;
		}

		// Token: 0x0600017C RID: 380 RVA: 0x0000DC78 File Offset: 0x0000BE78
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			using (GraphicsPath graphicsPath = new GraphicsPath())
			{
				graphicsPath.AddEllipse(new Rectangle(0, 0, base.Width - 1, base.Height - 1));
				base.Region = new Region(graphicsPath);
			}
		}
	}
}
