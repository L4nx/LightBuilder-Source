using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Client
{
	// Token: 0x0200002C RID: 44
	internal class iTalk_Icon_Tick : Control
	{
		// Token: 0x060001B8 RID: 440 RVA: 0x0000EE90 File Offset: 0x0000D090
		public iTalk_Icon_Tick()
		{
			this.ForeColor = Color.DimGray;
			this.BackColor = Color.FromArgb(246, 246, 246);
			base.Size = new Size(33, 33);
			this.DoubleBuffered = true;
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x0000EEE0 File Offset: 0x0000D0E0
		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
			e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			e.Graphics.FillEllipse(new SolidBrush(Color.Gray), new Rectangle(1, 1, 29, 29));
			e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(246, 246, 246)), new Rectangle(3, 3, 25, 25));
			e.Graphics.DrawString("ü", new Font("Wingdings", 25f, FontStyle.Bold), new SolidBrush(Color.Gray), new Rectangle(0, -3, base.Width, 43), new StringFormat
			{
				Alignment = StringAlignment.Near,
				LineAlignment = StringAlignment.Near
			});
		}
	}
}
