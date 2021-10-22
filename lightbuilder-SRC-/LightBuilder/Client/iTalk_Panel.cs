using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Client
{
	// Token: 0x0200001C RID: 28
	internal class iTalk_Panel : ContainerControl
	{
		// Token: 0x0600013E RID: 318 RVA: 0x0000C86C File Offset: 0x0000AA6C
		public iTalk_Panel()
		{
			base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			base.SetStyle(ControlStyles.UserPaint, true);
			this.BackColor = Color.Transparent;
			base.Size = new Size(187, 117);
			base.Padding = new Padding(5, 5, 5, 5);
			this.DoubleBuffered = true;
		}

		// Token: 0x0600013F RID: 319 RVA: 0x0000C8C8 File Offset: 0x0000AAC8
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.Shape = new GraphicsPath();
			GraphicsPath shape = this.Shape;
			shape.AddArc(0, 0, 10, 10, 180f, 90f);
			shape.AddArc(base.Width - 11, 0, 10, 10, -90f, 90f);
			shape.AddArc(base.Width - 11, base.Height - 11, 10, 10, 0f, 90f);
			shape.AddArc(0, base.Height - 11, 10, 10, 90f, 90f);
			shape.CloseAllFigures();
		}

		// Token: 0x06000140 RID: 320 RVA: 0x0000C96C File Offset: 0x0000AB6C
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			graphics.Clear(Color.Transparent);
			graphics.FillPath(Brushes.White, this.Shape);
			graphics.DrawPath(new Pen(Color.FromArgb(180, 180, 180)), this.Shape);
			graphics.Dispose();
			e.Graphics.DrawImage((Image)bitmap.Clone(), 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x040000C3 RID: 195
		private GraphicsPath Shape;
	}
}
