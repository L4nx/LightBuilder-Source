using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Client
{
	// Token: 0x02000023 RID: 35
	public class iTalk_ProgressBar : Control
	{
		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000169 RID: 361 RVA: 0x0000D849 File Offset: 0x0000BA49
		// (set) Token: 0x0600016A RID: 362 RVA: 0x0000D851 File Offset: 0x0000BA51
		public long Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				if (value > this._Maximum)
				{
					value = this._Maximum;
				}
				this._Value = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x0600016B RID: 363 RVA: 0x0000D871 File Offset: 0x0000BA71
		// (set) Token: 0x0600016C RID: 364 RVA: 0x0000D879 File Offset: 0x0000BA79
		public long Maximum
		{
			get
			{
				return this._Maximum;
			}
			set
			{
				if (value < 1L)
				{
					value = 1L;
				}
				this._Maximum = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x0600016D RID: 365 RVA: 0x0000D891 File Offset: 0x0000BA91
		// (set) Token: 0x0600016E RID: 366 RVA: 0x0000D899 File Offset: 0x0000BA99
		public Color ProgressColor1
		{
			get
			{
				return this._ProgressColor1;
			}
			set
			{
				this._ProgressColor1 = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x0600016F RID: 367 RVA: 0x0000D8A8 File Offset: 0x0000BAA8
		// (set) Token: 0x06000170 RID: 368 RVA: 0x0000D8B0 File Offset: 0x0000BAB0
		public Color ProgressColor2
		{
			get
			{
				return this._ProgressColor2;
			}
			set
			{
				this._ProgressColor2 = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000171 RID: 369 RVA: 0x0000D8BF File Offset: 0x0000BABF
		// (set) Token: 0x06000172 RID: 370 RVA: 0x0000D8C7 File Offset: 0x0000BAC7
		public iTalk_ProgressBar._ProgressShape ProgressShape
		{
			get
			{
				return this.ProgressShapeVal;
			}
			set
			{
				this.ProgressShapeVal = value;
				base.Invalidate();
			}
		}

		// Token: 0x06000173 RID: 371 RVA: 0x0000D8D6 File Offset: 0x0000BAD6
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.SetStandardSize();
		}

		// Token: 0x06000174 RID: 372 RVA: 0x0000D8E5 File Offset: 0x0000BAE5
		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			this.SetStandardSize();
		}

		// Token: 0x06000175 RID: 373 RVA: 0x0000D8F4 File Offset: 0x0000BAF4
		protected override void OnPaintBackground(PaintEventArgs p)
		{
			base.OnPaintBackground(p);
		}

		// Token: 0x06000176 RID: 374 RVA: 0x0000D900 File Offset: 0x0000BB00
		public iTalk_ProgressBar()
		{
			base.Size = new Size(130, 130);
			this.Font = new Font("Segoe UI", 15f);
			this.MinimumSize = new Size(100, 100);
			this.DoubleBuffered = true;
		}

		// Token: 0x06000177 RID: 375 RVA: 0x0000D980 File Offset: 0x0000BB80
		private void SetStandardSize()
		{
			int num = Math.Max(base.Width, base.Height);
			base.Size = new Size(num, num);
		}

		// Token: 0x06000178 RID: 376 RVA: 0x0000D9AC File Offset: 0x0000BBAC
		public void Increment(int Val)
		{
			this._Value += (long)Val;
			base.Invalidate();
		}

		// Token: 0x06000179 RID: 377 RVA: 0x0000D9C3 File Offset: 0x0000BBC3
		public void Decrement(int Val)
		{
			this._Value -= (long)Val;
			base.Invalidate();
		}

		// Token: 0x0600017A RID: 378 RVA: 0x0000D9DC File Offset: 0x0000BBDC
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			using (Bitmap bitmap = new Bitmap(base.Width, base.Height))
			{
				using (Graphics graphics = Graphics.FromImage(bitmap))
				{
					graphics.SmoothingMode = SmoothingMode.AntiAlias;
					graphics.Clear(this.BackColor);
					using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(base.ClientRectangle, this._ProgressColor1, this._ProgressColor2, LinearGradientMode.ForwardDiagonal))
					{
						using (Pen pen = new Pen(linearGradientBrush, 14f))
						{
							iTalk_ProgressBar._ProgressShape progressShapeVal = this.ProgressShapeVal;
							if (progressShapeVal != iTalk_ProgressBar._ProgressShape.Round)
							{
								if (progressShapeVal == iTalk_ProgressBar._ProgressShape.Flat)
								{
									pen.StartCap = LineCap.Flat;
									pen.EndCap = LineCap.Flat;
								}
							}
							else
							{
								pen.StartCap = LineCap.Round;
								pen.EndCap = LineCap.Round;
							}
							graphics.DrawArc(pen, 18, 18, base.Width - 35 - 2, base.Height - 35 - 2, -90, (int)Math.Round(360.0 / (double)this._Maximum * (double)this._Value));
						}
					}
					using (LinearGradientBrush linearGradientBrush2 = new LinearGradientBrush(base.ClientRectangle, Color.FromArgb(52, 52, 52), Color.FromArgb(52, 52, 52), LinearGradientMode.Vertical))
					{
						graphics.FillEllipse(linearGradientBrush2, 24, 24, base.Width - 48 - 1, base.Height - 48 - 1);
					}
					SizeF sizeF = graphics.MeasureString(Convert.ToString(Convert.ToInt32(100L / this._Maximum * this._Value)), this.Font);
					graphics.DrawString(Convert.ToString(Convert.ToInt32(100L / this._Maximum * this._Value)), this.Font, Brushes.White, (float)Convert.ToInt32((float)(base.Width / 2) - sizeF.Width / 2f), (float)Convert.ToInt32((float)(base.Height / 2) - sizeF.Height / 2f));
					e.Graphics.DrawImage(bitmap, 0, 0);
					graphics.Dispose();
					bitmap.Dispose();
				}
			}
		}

		// Token: 0x040000D0 RID: 208
		private long _Value;

		// Token: 0x040000D1 RID: 209
		private long _Maximum = 100L;

		// Token: 0x040000D2 RID: 210
		private Color _ProgressColor1 = Color.FromArgb(92, 92, 92);

		// Token: 0x040000D3 RID: 211
		private Color _ProgressColor2 = Color.FromArgb(92, 92, 92);

		// Token: 0x040000D4 RID: 212
		private iTalk_ProgressBar._ProgressShape ProgressShapeVal;

		// Token: 0x02000038 RID: 56
		public enum _ProgressShape
		{
			// Token: 0x04000110 RID: 272
			Round,
			// Token: 0x04000111 RID: 273
			Flat
		}
	}
}
