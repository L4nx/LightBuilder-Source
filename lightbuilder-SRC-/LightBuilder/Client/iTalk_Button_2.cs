using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Client
{
	// Token: 0x02000010 RID: 16
	internal class iTalk_Button_2 : Control
	{
		// Token: 0x060000B9 RID: 185 RVA: 0x00009C4C File Offset: 0x00007E4C
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

		// Token: 0x060000BA RID: 186 RVA: 0x00009D34 File Offset: 0x00007F34
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

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000BB RID: 187 RVA: 0x00009E37 File Offset: 0x00008037
		// (set) Token: 0x060000BC RID: 188 RVA: 0x00009E3F File Offset: 0x0000803F
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

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000BD RID: 189 RVA: 0x00009E6A File Offset: 0x0000806A
		// (set) Token: 0x060000BE RID: 190 RVA: 0x00009E72 File Offset: 0x00008072
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

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000BF RID: 191 RVA: 0x00009E81 File Offset: 0x00008081
		protected Size ImageSize
		{
			get
			{
				return this._ImageSize;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x00009E89 File Offset: 0x00008089
		// (set) Token: 0x060000C1 RID: 193 RVA: 0x00009E91 File Offset: 0x00008091
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

		// Token: 0x060000C2 RID: 194 RVA: 0x00009EA0 File Offset: 0x000080A0
		protected override void OnMouseUp(MouseEventArgs e)
		{
			this.MouseState = 0;
			base.Invalidate();
			base.OnMouseUp(e);
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00009EB6 File Offset: 0x000080B6
		protected override void OnMouseDown(MouseEventArgs e)
		{
			this.MouseState = 1;
			base.Invalidate();
			base.OnMouseDown(e);
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00009ECC File Offset: 0x000080CC
		protected override void OnMouseLeave(EventArgs e)
		{
			this.MouseState = 0;
			base.Invalidate();
			base.OnMouseLeave(e);
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00009EE2 File Offset: 0x000080E2
		protected override void OnTextChanged(EventArgs e)
		{
			base.Invalidate();
			base.OnTextChanged(e);
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00009EF4 File Offset: 0x000080F4
		public iTalk_Button_2()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.BackColor = Color.Transparent;
			this.DoubleBuffered = true;
			this.Font = new Font("Segoe UI", 14f);
			this.ForeColor = Color.White;
			base.Size = new Size(166, 40);
			this._TextAlignment = StringAlignment.Center;
			this.P1 = new Pen(Color.FromArgb(0, 118, 176));
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00009F88 File Offset: 0x00008188
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			if (base.Width > 0 && base.Height > 0)
			{
				this.Shape = new GraphicsPath();
				this.R1 = new Rectangle(0, 0, base.Width, base.Height);
				this.InactiveGB = new LinearGradientBrush(new Rectangle(0, 0, base.Width, base.Height), Color.FromArgb(0, 176, 231), Color.FromArgb(0, 152, 224), 90f);
				this.PressedGB = new LinearGradientBrush(new Rectangle(0, 0, base.Width, base.Height), Color.FromArgb(0, 118, 176), Color.FromArgb(0, 149, 222), 90f);
				this.PressedContourGB = new LinearGradientBrush(new Rectangle(0, 0, base.Width, base.Height), Color.FromArgb(0, 118, 176), Color.FromArgb(0, 118, 176), 90f);
				this.P3 = new Pen(this.PressedContourGB);
			}
			GraphicsPath shape = this.Shape;
			shape.AddArc(0, 0, 10, 10, 180f, 90f);
			shape.AddArc(base.Width - 11, 0, 10, 10, -90f, 90f);
			shape.AddArc(base.Width - 11, base.Height - 11, 10, 10, 0f, 90f);
			shape.AddArc(0, base.Height - 11, 10, 10, 90f, 90f);
			shape.CloseAllFigures();
			base.Invalidate();
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x0000A134 File Offset: 0x00008334
		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			PointF pointF = iTalk_Button_2.ImageLocation(this.GetStringFormat(this.ImageAlign), base.Size, this.ImageSize);
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

		// Token: 0x04000085 RID: 133
		private int MouseState;

		// Token: 0x04000086 RID: 134
		private GraphicsPath Shape;

		// Token: 0x04000087 RID: 135
		private LinearGradientBrush InactiveGB;

		// Token: 0x04000088 RID: 136
		private LinearGradientBrush PressedGB;

		// Token: 0x04000089 RID: 137
		private LinearGradientBrush PressedContourGB;

		// Token: 0x0400008A RID: 138
		private Rectangle R1;

		// Token: 0x0400008B RID: 139
		private Pen P1;

		// Token: 0x0400008C RID: 140
		private Pen P3;

		// Token: 0x0400008D RID: 141
		private Image _Image;

		// Token: 0x0400008E RID: 142
		private Size _ImageSize;

		// Token: 0x0400008F RID: 143
		private StringAlignment _TextAlignment = StringAlignment.Center;

		// Token: 0x04000090 RID: 144
		private ContentAlignment _ImageAlign = ContentAlignment.MiddleLeft;
	}
}
