using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Client
{
	// Token: 0x0200002B RID: 43
	internal class iTalk_Icon_Info : Control
	{
		// Token: 0x060001B6 RID: 438 RVA: 0x0000ED78 File Offset: 0x0000CF78
		public iTalk_Icon_Info()
		{
			this.ForeColor = Color.DimGray;
			this.BackColor = Color.FromArgb(246, 246, 246);
			base.Size = new Size(33, 33);
			this.DoubleBuffered = true;
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x0000EDC8 File Offset: 0x0000CFC8
		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
			e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			e.Graphics.FillEllipse(new SolidBrush(Color.Gray), new Rectangle(1, 1, 29, 29));
			e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(246, 246, 246)), new Rectangle(3, 3, 25, 25));
			e.Graphics.DrawString("¡", new Font("Segoe UI", 25f, FontStyle.Bold), new SolidBrush(Color.Gray), new Rectangle(4, -14, base.Width, 43), new StringFormat
			{
				Alignment = StringAlignment.Near,
				LineAlignment = StringAlignment.Near
			});
		}
	}
}
