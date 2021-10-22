using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Client
{
	// Token: 0x0200000E RID: 14
	public class iTalk_ControlBox : Control
	{
		// Token: 0x0600009E RID: 158 RVA: 0x00008EC8 File Offset: 0x000070C8
		protected override void OnMouseClick(MouseEventArgs e)
		{
			base.OnMouseClick(e);
			if (this.i > 0 & this.i < 28)
			{
				base.FindForm().WindowState = FormWindowState.Minimized;
			}
			else if (this.i > 30 & this.i < 75)
			{
				base.FindForm().Close();
			}
			this.State = iTalk_ControlBox.MouseState.Down;
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00008F29 File Offset: 0x00007129
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = iTalk_ControlBox.MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00008F3F File Offset: 0x0000713F
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = iTalk_ControlBox.MouseState.None;
			base.Invalidate();
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00008F55 File Offset: 0x00007155
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = iTalk_ControlBox.MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00008F6C File Offset: 0x0000716C
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			this.i = e.Location.X;
			base.Invalidate();
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00008F9A File Offset: 0x0000719A
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Width = 77;
			base.Height = 19;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00008FB4 File Offset: 0x000071B4
		public iTalk_ControlBox()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
			this.BackColor = Color.Transparent;
			this.DoubleBuffered = true;
			this.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00009010 File Offset: 0x00007210
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			Point location = new Point(checked(base.FindForm().Width - 81), -1);
			base.Location = location;
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00009040 File Offset: 0x00007240
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			GraphicsPath graphicsPath = new GraphicsPath();
			GraphicsPath graphicsPath2 = new GraphicsPath();
			graphicsPath.AddRectangle(this.MinimizeRect);
			graphicsPath2.AddRectangle(this.CloseRect);
			graphics.Clear(this.BackColor);
			iTalk_ControlBox.MouseState state = this.State;
			if (state != iTalk_ControlBox.MouseState.None)
			{
				if (state != iTalk_ControlBox.MouseState.Over)
				{
					goto IL_44E;
				}
				if (this.i > 0 & this.i < 28)
				{
					LinearGradientBrush brush = new LinearGradientBrush(this.MinimizeRect, Color.FromArgb(76, 76, 76, 76), Color.FromArgb(48, 48, 48), 90f);
					graphics.FillPath(brush, graphicsPath);
					graphics.DrawPath(new Pen(Color.FromArgb(40, 40, 40)), graphicsPath);
					graphics.DrawString("0", new Font("Marlett", 11f, FontStyle.Regular), new SolidBrush(Color.FromArgb(221, 221, 221)), (float)(this.MinimizeRect.Width - 22), (float)(this.MinimizeRect.Height - 16));
					LinearGradientBrush brush2 = new LinearGradientBrush(this.CloseRect, Color.FromArgb(73, 73, 73), Color.FromArgb(58, 58, 58), 90f);
					graphics.FillPath(brush2, graphicsPath2);
					graphics.DrawPath(new Pen(Color.FromArgb(40, 40, 40)), graphicsPath2);
					graphics.DrawString("r", new Font("Marlett", 11f, FontStyle.Regular), new SolidBrush(Color.FromArgb(221, 221, 221)), (float)(this.CloseRect.Width - 4), (float)(this.CloseRect.Height - 16));
					goto IL_44E;
				}
				if (this.i > 30 & this.i < 75)
				{
					LinearGradientBrush brush3 = new LinearGradientBrush(this.CloseRect, Color.FromArgb(76, 76, 76, 76), Color.FromArgb(48, 48, 48), 90f);
					graphics.FillPath(brush3, graphicsPath2);
					graphics.DrawPath(new Pen(Color.FromArgb(40, 40, 40)), graphicsPath2);
					graphics.DrawString("r", new Font("Marlett", 11f, FontStyle.Regular), new SolidBrush(Color.FromArgb(221, 221, 221)), (float)(this.CloseRect.Width - 4), (float)(this.CloseRect.Height - 16));
					LinearGradientBrush brush4 = new LinearGradientBrush(this.MinimizeRect, Color.FromArgb(73, 73, 73), Color.FromArgb(58, 58, 58), 90f);
					graphics.FillPath(brush4, RoundRectangle.RoundRect(this.MinimizeRect, 1));
					graphics.DrawPath(new Pen(Color.FromArgb(40, 40, 40)), graphicsPath);
					graphics.DrawString("0", new Font("Marlett", 11f, FontStyle.Regular), new SolidBrush(Color.FromArgb(221, 221, 221)), (float)(this.MinimizeRect.Width - 22), (float)(this.MinimizeRect.Height - 16));
					goto IL_44E;
				}
			}
			LinearGradientBrush brush5 = new LinearGradientBrush(this.MinimizeRect, Color.FromArgb(73, 73, 73), Color.FromArgb(58, 58, 58), 90f);
			graphics.FillPath(brush5, graphicsPath);
			graphics.DrawPath(new Pen(Color.FromArgb(40, 40, 40)), graphicsPath);
			graphics.DrawString("0", new Font("Marlett", 11f, FontStyle.Regular), new SolidBrush(Color.FromArgb(221, 221, 221)), (float)(this.MinimizeRect.Width - 22), (float)(this.MinimizeRect.Height - 16));
			LinearGradientBrush brush6 = new LinearGradientBrush(this.CloseRect, Color.FromArgb(73, 73, 73), Color.FromArgb(58, 58, 58), 90f);
			graphics.FillPath(brush6, graphicsPath2);
			graphics.DrawPath(new Pen(Color.FromArgb(40, 40, 40)), graphicsPath2);
			graphics.DrawString("r", new Font("Marlett", 11f, FontStyle.Regular), new SolidBrush(Color.FromArgb(221, 221, 221)), (float)(this.CloseRect.Width - 4), (float)(this.CloseRect.Height - 16));
			IL_44E:
			e.Graphics.DrawImage((Image)bitmap.Clone(), 0, 0);
			graphics.Dispose();
			graphicsPath2.Dispose();
			graphicsPath.Dispose();
			bitmap.Dispose();
		}

		// Token: 0x04000074 RID: 116
		private iTalk_ControlBox.MouseState State;

		// Token: 0x04000075 RID: 117
		private int i;

		// Token: 0x04000076 RID: 118
		private Rectangle CloseRect = new Rectangle(28, 0, 47, 18);

		// Token: 0x04000077 RID: 119
		private Rectangle MinimizeRect = new Rectangle(0, 0, 28, 18);

		// Token: 0x02000030 RID: 48
		public enum MouseState : byte
		{
			// Token: 0x040000FD RID: 253
			None,
			// Token: 0x040000FE RID: 254
			Over,
			// Token: 0x040000FF RID: 255
			Down,
			// Token: 0x04000100 RID: 256
			Block
		}
	}
}
