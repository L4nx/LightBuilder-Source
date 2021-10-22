using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Client
{
	// Token: 0x0200000F RID: 15
	internal class iTalk_Button_1 : Control
	{
		// Token: 0x060000A7 RID: 167 RVA: 0x000094CC File Offset: 0x000076CC
		private static PointF ImageLocation(StringFormat SF, SizeF Area, SizeF ImageArea)
		{
			PointF result = default(PointF);
			switch (SF.Alignment)
			{
			case StringAlignment.Near:
				result.X = 2f;
				break;
			case StringAlignment.Center:
				result.X = Convert.ToSingle((Area.Width - ImageArea.Width) / 2f);
				break;
			case StringAlignment.Far:
				result.X = Area.Width - ImageArea.Width - 2f;
				break;
			}
			switch (SF.LineAlignment)
			{
			case StringAlignment.Near:
				result.Y = 2f;
				break;
			case StringAlignment.Center:
				result.Y = Convert.ToSingle((Area.Height - ImageArea.Height) / 2f);
				break;
			case StringAlignment.Far:
				result.Y = Area.Height - ImageArea.Height - 2f;
				break;
			}
			return result;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x000095B4 File Offset: 0x000077B4
		private StringFormat GetStringFormat(ContentAlignment _ContentAlignment)
		{
			StringFormat stringFormat = new StringFormat();
			if (_ContentAlignment <= ContentAlignment.MiddleCenter)
			{
				switch (_ContentAlignment)
				{
				case ContentAlignment.TopLeft:
					stringFormat.LineAlignment = StringAlignment.Near;
					stringFormat.Alignment = StringAlignment.Near;
					break;
				case ContentAlignment.TopCenter:
					stringFormat.LineAlignment = StringAlignment.Near;
					stringFormat.Alignment = StringAlignment.Center;
					break;
				case (ContentAlignment)3:
					break;
				case ContentAlignment.TopRight:
					stringFormat.LineAlignment = StringAlignment.Near;
					stringFormat.Alignment = StringAlignment.Far;
					break;
				default:
					if (_ContentAlignment != ContentAlignment.MiddleLeft)
					{
						if (_ContentAlignment == ContentAlignment.MiddleCenter)
						{
							stringFormat.LineAlignment = StringAlignment.Center;
							stringFormat.Alignment = StringAlignment.Center;
						}
					}
					else
					{
						stringFormat.LineAlignment = StringAlignment.Center;
						stringFormat.Alignment = StringAlignment.Near;
					}
					break;
				}
			}
			else if (_ContentAlignment <= ContentAlignment.BottomLeft)
			{
				if (_ContentAlignment != ContentAlignment.MiddleRight)
				{
					if (_ContentAlignment == ContentAlignment.BottomLeft)
					{
						stringFormat.LineAlignment = StringAlignment.Far;
						stringFormat.Alignment = StringAlignment.Near;
					}
				}
				else
				{
					stringFormat.LineAlignment = StringAlignment.Center;
					stringFormat.Alignment = StringAlignment.Far;
				}
			}
			else if (_ContentAlignment != ContentAlignment.BottomCenter)
			{
				if (_ContentAlignment == ContentAlignment.BottomRight)
				{
					stringFormat.LineAlignment = StringAlignment.Far;
					stringFormat.Alignment = StringAlignment.Far;
				}
			}
			else
			{
				stringFormat.LineAlignment = StringAlignment.Far;
				stringFormat.Alignment = StringAlignment.Center;
			}
			return stringFormat;
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000A9 RID: 169 RVA: 0x000096B7 File Offset: 0x000078B7
		// (set) Token: 0x060000AA RID: 170 RVA: 0x000096BF File Offset: 0x000078BF
		public Image Image
		{
			get
			{
				return this._Image;
			}
			set
			{
				if (value == null)
				{
					this._ImageSize = Size.Empty;
				}
				else
				{
					this._ImageSize = value.Size;
				}
				this._Image = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000AB RID: 171 RVA: 0x000096EA File Offset: 0x000078EA
		protected Size ImageSize
		{
			get
			{
				return this._ImageSize;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000AC RID: 172 RVA: 0x000096F2 File Offset: 0x000078F2
		// (set) Token: 0x060000AD RID: 173 RVA: 0x000096FA File Offset: 0x000078FA
		public ContentAlignment ImageAlign
		{
			get
			{
				return this._ImageAlign;
			}
			set
			{
				this._ImageAlign = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000AE RID: 174 RVA: 0x00009709 File Offset: 0x00007909
		// (set) Token: 0x060000AF RID: 175 RVA: 0x00009711 File Offset: 0x00007911
		public StringAlignment TextAlignment
		{
			get
			{
				return this._TextAlignment;
			}
			set
			{
				this._TextAlignment = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x00009720 File Offset: 0x00007920
		// (set) Token: 0x060000B1 RID: 177 RVA: 0x00009728 File Offset: 0x00007928
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

		// Token: 0x060000B2 RID: 178 RVA: 0x00009737 File Offset: 0x00007937
		protected override void OnMouseUp(MouseEventArgs e)
		{
			this.MouseState = 0;
			base.Invalidate();
			base.OnMouseUp(e);
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000974D File Offset: 0x0000794D
		protected override void OnMouseDown(MouseEventArgs e)
		{
			this.MouseState = 1;
			base.Invalidate();
			base.OnMouseDown(e);
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00009763 File Offset: 0x00007963
		protected override void OnMouseLeave(EventArgs e)
		{
			this.MouseState = 0;
			base.Invalidate();
			base.OnMouseLeave(e);
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00009779 File Offset: 0x00007979
		protected override void OnTextChanged(EventArgs e)
		{
			base.Invalidate();
			base.OnTextChanged(e);
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00009788 File Offset: 0x00007988
		public iTalk_Button_1()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.BackColor = Color.Transparent;
			this.DoubleBuffered = true;
			this.Font = new Font("Segoe UI", 12f);
			this.ForeColor = Color.FromArgb(150, 150, 150);
			base.Size = new Size(166, 40);
			this._TextAlignment = StringAlignment.Center;
			this.P1 = new Pen(Color.FromArgb(190, 190, 190));
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0000984C File Offset: 0x00007A4C
		protected override void OnResize(EventArgs e)
		{
			if (base.Width > 0 && base.Height > 0)
			{
				this.Shape = new GraphicsPath();
				this.R1 = new Rectangle(0, 0, base.Width, base.Height);
				this.InactiveGB = new LinearGradientBrush(new Rectangle(0, 0, base.Width, base.Height), Color.FromArgb(251, 251, 251), Color.FromArgb(225, 225, 225), 90f);
				this.PressedGB = new LinearGradientBrush(new Rectangle(0, 0, base.Width, base.Height), Color.FromArgb(235, 235, 235), Color.FromArgb(223, 223, 223), 90f);
				this.PressedContourGB = new LinearGradientBrush(new Rectangle(0, 0, base.Width, base.Height), Color.FromArgb(167, 167, 167), Color.FromArgb(167, 167, 167), 90f);
				this.P3 = new Pen(this.PressedContourGB);
			}
			GraphicsPath shape = this.Shape;
			shape.AddArc(0, 0, 10, 10, 180f, 90f);
			shape.AddArc(base.Width - 11, 0, 10, 10, -90f, 90f);
			shape.AddArc(base.Width - 11, base.Height - 11, 10, 10, 0f, 90f);
			shape.AddArc(0, base.Height - 11, 10, 10, 90f, 90f);
			shape.CloseAllFigures();
			base.Invalidate();
			base.OnResize(e);
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00009A18 File Offset: 0x00007C18
		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			PointF pointF = iTalk_Button_1.ImageLocation(this.GetStringFormat(this.ImageAlign), base.Size, this.ImageSize);
			int mouseState = this.MouseState;
			if (mouseState != 0)
			{
				if (mouseState == 1)
				{
					graphics.FillPath(this.PressedGB, this.Shape);
					graphics.DrawPath(this.P3, this.Shape);
					if (this.Image == null)
					{
						graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), this.R1, new StringFormat
						{
							Alignment = this._TextAlignment,
							LineAlignment = StringAlignment.Center
						});
					}
					else
					{
						graphics.DrawImage(this._Image, pointF.X, pointF.Y, (float)this.ImageSize.Width, (float)this.ImageSize.Height);
						graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), this.R1, new StringFormat
						{
							Alignment = this._TextAlignment,
							LineAlignment = StringAlignment.Center
						});
					}
				}
			}
			else
			{
				graphics.FillPath(this.InactiveGB, this.Shape);
				graphics.DrawPath(this.P1, this.Shape);
				if (this.Image == null)
				{
					graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), this.R1, new StringFormat
					{
						Alignment = this._TextAlignment,
						LineAlignment = StringAlignment.Center
					});
				}
				else
				{
					graphics.DrawImage(this._Image, pointF.X, pointF.Y, (float)this.ImageSize.Width, (float)this.ImageSize.Height);
					graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), this.R1, new StringFormat
					{
						Alignment = this._TextAlignment,
						LineAlignment = StringAlignment.Center
					});
				}
			}
			base.OnPaint(e);
		}

		// Token: 0x04000078 RID: 120
		private int MouseState;

		// Token: 0x04000079 RID: 121
		private GraphicsPath Shape;

		// Token: 0x0400007A RID: 122
		private LinearGradientBrush InactiveGB;

		// Token: 0x0400007B RID: 123
		private LinearGradientBrush PressedGB;

		// Token: 0x0400007C RID: 124
		private LinearGradientBrush PressedContourGB;

		// Token: 0x0400007D RID: 125
		private Rectangle R1;

		// Token: 0x0400007E RID: 126
		private Pen P1;

		// Token: 0x0400007F RID: 127
		private Pen P3;

		// Token: 0x04000080 RID: 128
		private Image _Image;

		// Token: 0x04000081 RID: 129
		private Size _ImageSize;

		// Token: 0x04000082 RID: 130
		private StringAlignment _TextAlignment = StringAlignment.Center;

		// Token: 0x04000083 RID: 131
		private Color _TextColor = Color.FromArgb(150, 150, 150);

		// Token: 0x04000084 RID: 132
		private ContentAlignment _ImageAlign = ContentAlignment.MiddleLeft;
	}
}
