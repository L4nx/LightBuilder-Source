using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Client
{
	// Token: 0x02000019 RID: 25
	public class iTalk_ChatBubble_L : Control
	{
		// Token: 0x17000054 RID: 84
		// (get) Token: 0x0600012A RID: 298 RVA: 0x0000C273 File Offset: 0x0000A473
		// (set) Token: 0x0600012B RID: 299 RVA: 0x0000C27B File Offset: 0x0000A47B
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

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x0600012C RID: 300 RVA: 0x0000C28A File Offset: 0x0000A48A
		// (set) Token: 0x0600012D RID: 301 RVA: 0x0000C292 File Offset: 0x0000A492
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

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x0600012E RID: 302 RVA: 0x0000C2A1 File Offset: 0x0000A4A1
		// (set) Token: 0x0600012F RID: 303 RVA: 0x0000C2A9 File Offset: 0x0000A4A9
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

		// Token: 0x06000130 RID: 304 RVA: 0x0000C2B8 File Offset: 0x0000A4B8
		public iTalk_ChatBubble_L()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			base.Size = new Size(152, 38);
			this.BackColor = Color.Transparent;
			this.ForeColor = Color.FromArgb(52, 52, 52);
			this.Font = new Font("Segoe UI", 10f);
		}

		// Token: 0x06000131 RID: 305 RVA: 0x0000C354 File Offset: 0x0000A554
		protected override void OnResize(EventArgs e)
		{
			this.Shape = new GraphicsPath();
			GraphicsPath shape = this.Shape;
			shape.AddArc(9, 0, 10, 10, 180f, 90f);
			shape.AddArc(base.Width - 11, 0, 10, 10, -90f, 90f);
			shape.AddArc(base.Width - 11, base.Height - 11, 10, 10, 0f, 90f);
			shape.AddArc(9, base.Height - 11, 10, 10, 90f, 90f);
			shape.CloseAllFigures();
			base.Invalidate();
			base.OnResize(e);
		}

		// Token: 0x06000132 RID: 306 RVA: 0x0000C400 File Offset: 0x0000A600
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
			graphics2.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), new Rectangle(15, 4, base.Width - 17, base.Height - 5));
			if (this._DrawBubbleArrow)
			{
				Point[] points = new Point[]
				{
					new Point(9, base.Height - 19),
					new Point(0, base.Height - 25),
					new Point(9, base.Height - 30)
				};
				graphics2.FillPolygon(new SolidBrush(this._BubbleColor), points);
				graphics2.DrawPolygon(new Pen(new SolidBrush(this._BubbleColor)), points);
			}
			graphics.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x040000BB RID: 187
		private GraphicsPath Shape;

		// Token: 0x040000BC RID: 188
		private Color _TextColor = Color.FromArgb(52, 52, 52);

		// Token: 0x040000BD RID: 189
		private Color _BubbleColor = Color.FromArgb(217, 217, 217);

		// Token: 0x040000BE RID: 190
		private bool _DrawBubbleArrow = true;
	}
}
