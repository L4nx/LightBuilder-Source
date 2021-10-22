using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Client
{
	// Token: 0x0200001A RID: 26
	public class iTalk_ChatBubble_R : Control
	{
		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000133 RID: 307 RVA: 0x0000C53D File Offset: 0x0000A73D
		// (set) Token: 0x06000134 RID: 308 RVA: 0x0000C545 File Offset: 0x0000A745
		public override Color ForeColor
		{
			get
			{
				return this._TextColor;
			}
			set
			{
				this._TextColor = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000135 RID: 309 RVA: 0x0000C554 File Offset: 0x0000A754
		// (set) Token: 0x06000136 RID: 310 RVA: 0x0000C55C File Offset: 0x0000A75C
		public Color BubbleColor
		{
			get
			{
				return this._BubbleColor;
			}
			set
			{
				this._BubbleColor = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000137 RID: 311 RVA: 0x0000C56B File Offset: 0x0000A76B
		// (set) Token: 0x06000138 RID: 312 RVA: 0x0000C573 File Offset: 0x0000A773
		public bool DrawBubbleArrow
		{
			get
			{
				return this._DrawBubbleArrow;
			}
			set
			{
				this._DrawBubbleArrow = value;
				base.Invalidate();
			}
		}

		// Token: 0x06000139 RID: 313 RVA: 0x0000C584 File Offset: 0x0000A784
		public iTalk_ChatBubble_R()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			base.Size = new Size(152, 38);
			this.BackColor = Color.Transparent;
			this.ForeColor = Color.FromArgb(52, 52, 52);
			this.Font = new Font("Segoe UI", 10f);
		}

		// Token: 0x0600013A RID: 314 RVA: 0x0000C620 File Offset: 0x0000A820
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.Shape = new GraphicsPath();
			GraphicsPath shape = this.Shape;
			shape.AddArc(0, 0, 10, 10, 180f, 90f);
			shape.AddArc(base.Width - 18, 0, 10, 10, -90f, 90f);
			shape.AddArc(base.Width - 18, base.Height - 11, 10, 10, 0f, 90f);
			shape.AddArc(0, base.Height - 11, 10, 10, 90f, 90f);
			shape.CloseAllFigures();
			base.Invalidate();
		}

		// Token: 0x0600013B RID: 315 RVA: 0x0000C6C8 File Offset: 0x0000A8C8
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			Graphics graphics2 = graphics;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.Clear(this.BackColor);
			graphics2.FillPath(new SolidBrush(this._BubbleColor), this.Shape);
			graphics2.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), new Rectangle(6, 4, base.Width - 15, base.Height));
			if (this._DrawBubbleArrow)
			{
				Point[] points = new Point[]
				{
					new Point(base.Width - 8, base.Height - 19),
					new Point(base.Width, base.Height - 25),
					new Point(base.Width - 8, base.Height - 30)
				};
				graphics2.FillPolygon(new SolidBrush(this._BubbleColor), points);
				graphics2.DrawPolygon(new Pen(new SolidBrush(this._BubbleColor)), points);
			}
			graphics.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x040000BF RID: 191
		private GraphicsPath Shape;

		// Token: 0x040000C0 RID: 192
		private Color _TextColor = Color.FromArgb(52, 52, 52);

		// Token: 0x040000C1 RID: 193
		private Color _BubbleColor = Color.FromArgb(192, 206, 215);

		// Token: 0x040000C2 RID: 194
		private bool _DrawBubbleArrow = true;
	}
}
