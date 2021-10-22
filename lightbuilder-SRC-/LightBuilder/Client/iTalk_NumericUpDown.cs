using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Client
{
	// Token: 0x02000018 RID: 24
	public class iTalk_NumericUpDown : Control
	{
		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000118 RID: 280 RVA: 0x0000BA7B File Offset: 0x00009C7B
		// (set) Token: 0x06000119 RID: 281 RVA: 0x0000BA83 File Offset: 0x00009C83
		public long Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				if (value <= this._Maximum & value >= this._Minimum)
				{
					this._Value = value;
				}
				base.Invalidate();
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x0600011A RID: 282 RVA: 0x0000BAAD File Offset: 0x00009CAD
		// (set) Token: 0x0600011B RID: 283 RVA: 0x0000BAB5 File Offset: 0x00009CB5
		public long Minimum
		{
			get
			{
				return this._Minimum;
			}
			set
			{
				if (value < this._Maximum)
				{
					this._Minimum = value;
				}
				if (this._Value < this._Minimum)
				{
					this._Value = this.Minimum;
				}
				base.Invalidate();
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x0600011C RID: 284 RVA: 0x0000BAE7 File Offset: 0x00009CE7
		// (set) Token: 0x0600011D RID: 285 RVA: 0x0000BAEF File Offset: 0x00009CEF
		public long Maximum
		{
			get
			{
				return this._Maximum;
			}
			set
			{
				if (value > this._Minimum)
				{
					this._Maximum = value;
				}
				if (this._Value > this._Maximum)
				{
					this._Value = this._Maximum;
				}
				base.Invalidate();
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x0600011E RID: 286 RVA: 0x0000BB21 File Offset: 0x00009D21
		// (set) Token: 0x0600011F RID: 287 RVA: 0x0000BB29 File Offset: 0x00009D29
		public iTalk_NumericUpDown._TextAlignment TextAlignment
		{
			get
			{
				return this.MyStringAlignment;
			}
			set
			{
				this.MyStringAlignment = value;
				base.Invalidate();
			}
		}

		// Token: 0x06000120 RID: 288 RVA: 0x0000BB38 File Offset: 0x00009D38
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Height = 28;
			this.Shape = new GraphicsPath();
			this.Shape.AddArc(0, 0, 10, 10, 180f, 90f);
			this.Shape.AddArc(base.Width - 11, 0, 10, 10, -90f, 90f);
			this.Shape.AddArc(base.Width - 11, base.Height - 11, 10, 10, 0f, 90f);
			this.Shape.AddArc(0, base.Height - 11, 10, 10, 90f, 90f);
			this.Shape.CloseAllFigures();
		}

		// Token: 0x06000121 RID: 289 RVA: 0x0000BBF8 File Offset: 0x00009DF8
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			this.Xval = e.Location.X;
			this.Yval = e.Location.Y;
			base.Invalidate();
			if (e.X < base.Width - 24)
			{
				this.Cursor = Cursors.IBeam;
				return;
			}
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000122 RID: 290 RVA: 0x0000BC64 File Offset: 0x00009E64
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseClick(e);
			if (this.Xval > base.Width - 23 && this.Xval < base.Width - 3)
			{
				if (this.Yval < 15)
				{
					if (this.Value + 1L <= this._Maximum)
					{
						this._Value += 1L;
					}
				}
				else if (this.Value - 1L >= this._Minimum)
				{
					this._Value -= 1L;
				}
			}
			else
			{
				this.KeyboardNum = !this.KeyboardNum;
				base.Focus();
			}
			base.Invalidate();
		}

		// Token: 0x06000123 RID: 291 RVA: 0x0000BD04 File Offset: 0x00009F04
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			base.OnKeyPress(e);
			try
			{
				if (this.KeyboardNum)
				{
					this._Value = long.Parse(this._Value.ToString() + e.KeyChar.ToString().ToString());
				}
				if (this._Value > this._Maximum)
				{
					this._Value = this._Maximum;
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000124 RID: 292 RVA: 0x0000BD80 File Offset: 0x00009F80
		protected override void OnKeyUp(KeyEventArgs e)
		{
			base.OnKeyUp(e);
			if (e.KeyCode == Keys.Back)
			{
				string text = this._Value.ToString();
				text = text.Remove(Convert.ToInt32(text.Length - 1));
				if (text.Length == 0)
				{
					text = "0";
				}
				this._Value = (long)Convert.ToInt32(text);
			}
			base.Invalidate();
		}

		// Token: 0x06000125 RID: 293 RVA: 0x0000BDE0 File Offset: 0x00009FE0
		protected override void OnMouseWheel(MouseEventArgs e)
		{
			base.OnMouseWheel(e);
			if (e.Delta > 0)
			{
				if (this.Value + 1L <= this._Maximum)
				{
					this._Value += 1L;
				}
				base.Invalidate();
				return;
			}
			if (this.Value - 1L >= this._Minimum)
			{
				this._Value -= 1L;
			}
			base.Invalidate();
		}

		// Token: 0x06000126 RID: 294 RVA: 0x0000BE4C File Offset: 0x0000A04C
		public iTalk_NumericUpDown()
		{
			base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			base.SetStyle(ControlStyles.UserPaint, true);
			this.P1 = new Pen(Color.FromArgb(180, 180, 180));
			this.B1 = new SolidBrush(Color.White);
			this.BackColor = Color.Transparent;
			this.ForeColor = Color.DimGray;
			this._Minimum = 0L;
			this._Maximum = 100L;
			this.Font = new Font("Tahoma", 11f);
			base.Size = new Size(70, 28);
			this.MinimumSize = new Size(62, 28);
			this.DoubleBuffered = true;
		}

		// Token: 0x06000127 RID: 295 RVA: 0x0000BF03 File Offset: 0x0000A103
		public void Increment(int Value)
		{
			this._Value += (long)Value;
			base.Invalidate();
		}

		// Token: 0x06000128 RID: 296 RVA: 0x0000BF1A File Offset: 0x0000A11A
		public void Decrement(int Value)
		{
			this._Value -= (long)Value;
			base.Invalidate();
		}

		// Token: 0x06000129 RID: 297 RVA: 0x0000BF34 File Offset: 0x0000A134
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			graphics.Clear(Color.Transparent);
			graphics.FillPath(this.B1, this.Shape);
			graphics.DrawPath(this.P1, this.Shape);
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Rectangle(base.Width - 23, 4, 19, 19), Color.FromArgb(241, 241, 241), Color.FromArgb(241, 241, 241), 90f);
			graphics.FillRectangle(linearGradientBrush, linearGradientBrush.Rectangle);
			graphics.DrawRectangle(new Pen(Color.FromArgb(252, 252, 252)), new Rectangle(base.Width - 22, 5, 17, 17));
			graphics.DrawRectangle(new Pen(Color.FromArgb(180, 180, 180)), new Rectangle(base.Width - 23, 4, 19, 19));
			graphics.DrawLine(new Pen(Color.FromArgb(250, 252, 250)), new Point(base.Width - 22, base.Height - 16), new Point(base.Width - 5, base.Height - 16));
			graphics.DrawLine(new Pen(Color.FromArgb(180, 180, 180)), new Point(base.Width - 22, base.Height - 15), new Point(base.Width - 5, base.Height - 15));
			graphics.DrawLine(new Pen(Color.FromArgb(250, 250, 250)), new Point(base.Width - 22, base.Height - 14), new Point(base.Width - 5, base.Height - 14));
			graphics.DrawString("+", new Font("Tahoma", 8f), Brushes.Gray, (float)(base.Width - 19), (float)(base.Height - 26));
			graphics.DrawString("-", new Font("Tahoma", 12f), Brushes.Gray, (float)(base.Width - 19), (float)(base.Height - 20));
			iTalk_NumericUpDown._TextAlignment myStringAlignment = this.MyStringAlignment;
			if (myStringAlignment != iTalk_NumericUpDown._TextAlignment.Near)
			{
				if (myStringAlignment == iTalk_NumericUpDown._TextAlignment.Center)
				{
					graphics.DrawString(Convert.ToString(this.Value), this.Font, new SolidBrush(this.ForeColor), new Rectangle(0, 0, base.Width - 1, base.Height - 1), new StringFormat
					{
						Alignment = StringAlignment.Center,
						LineAlignment = StringAlignment.Center
					});
				}
			}
			else
			{
				graphics.DrawString(Convert.ToString(this.Value), this.Font, new SolidBrush(this.ForeColor), new Rectangle(5, 0, base.Width - 1, base.Height - 1), new StringFormat
				{
					Alignment = StringAlignment.Near,
					LineAlignment = StringAlignment.Center
				});
			}
			e.Graphics.DrawImage((Image)bitmap.Clone(), 0, 0);
			graphics.Dispose();
			bitmap.Dispose();
		}

		// Token: 0x040000B1 RID: 177
		private GraphicsPath Shape;

		// Token: 0x040000B2 RID: 178
		private Pen P1;

		// Token: 0x040000B3 RID: 179
		private SolidBrush B1;

		// Token: 0x040000B4 RID: 180
		private long _Value;

		// Token: 0x040000B5 RID: 181
		private long _Minimum;

		// Token: 0x040000B6 RID: 182
		private long _Maximum;

		// Token: 0x040000B7 RID: 183
		private int Xval;

		// Token: 0x040000B8 RID: 184
		private int Yval;

		// Token: 0x040000B9 RID: 185
		private bool KeyboardNum;

		// Token: 0x040000BA RID: 186
		private iTalk_NumericUpDown._TextAlignment MyStringAlignment;

		// Token: 0x02000034 RID: 52
		public enum _TextAlignment
		{
			// Token: 0x04000108 RID: 264
			Near,
			// Token: 0x04000109 RID: 265
			Center
		}
	}
}
