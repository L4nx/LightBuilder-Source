using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Client
{
	// Token: 0x0200001D RID: 29
	public class iTalk_GroupBox : ContainerControl
	{
		// Token: 0x06000141 RID: 321 RVA: 0x0000CA04 File Offset: 0x0000AC04
		public iTalk_GroupBox()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
			this.BackColor = Color.Transparent;
			this.DoubleBuffered = true;
			base.Size = new Size(212, 104);
			this.MinimumSize = new Size(136, 50);
			base.Padding = new Padding(5, 28, 5, 5);
		}

		// Token: 0x06000142 RID: 322 RVA: 0x0000CA6C File Offset: 0x0000AC6C
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			Rectangle rectangle = new Rectangle(51, 3, base.Width - 103, 18);
			Rectangle rectangle2 = new Rectangle(0, 0, base.Width - 1, base.Height - 10);
			graphics.Clear(Color.Transparent);
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			graphics.FillPath(Brushes.White, RoundRectangle.RoundRect(new Rectangle(1, 12, base.Width - 3, rectangle2.Height - 1), 8));
			graphics.DrawPath(new Pen(Color.FromArgb(159, 159, 161)), RoundRectangle.RoundRect(new Rectangle(1, 12, base.Width - 3, base.Height - 13), 8));
			graphics.FillPath(Brushes.White, RoundRectangle.RoundRect(rectangle, 1));
			graphics.DrawPath(new Pen(Color.FromArgb(182, 180, 186)), RoundRectangle.RoundRect(rectangle, 4));
			graphics.DrawString(this.Text, new Font("Tahoma", 9f, FontStyle.Regular), new SolidBrush(Color.FromArgb(53, 53, 53)), rectangle, new StringFormat
			{
				Alignment = StringAlignment.Center,
				LineAlignment = StringAlignment.Center
			});
			e.Graphics.DrawImage((Image)bitmap.Clone(), 0, 0);
			graphics.Dispose();
			bitmap.Dispose();
		}
	}
}
