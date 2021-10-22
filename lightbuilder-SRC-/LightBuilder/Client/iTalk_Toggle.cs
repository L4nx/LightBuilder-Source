using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Client
{
	// Token: 0x02000011 RID: 17
	[DefaultEvent("ToggledChanged")]
	internal class iTalk_Toggle : Control
	{
		// Token: 0x060000C9 RID: 201 RVA: 0x0000A368 File Offset: 0x00008568
		public GraphicsPath Pill(Rectangle Rectangle, iTalk_Toggle.PillStyle PillStyle)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			if (PillStyle.Left)
			{
				graphicsPath.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, Rectangle.Height, Rectangle.Height), -270f, 180f);
			}
			else
			{
				graphicsPath.AddLine(Rectangle.X, Rectangle.Y + Rectangle.Height, Rectangle.X, Rectangle.Y);
			}
			if (PillStyle.Right)
			{
				graphicsPath.AddArc(new Rectangle(Rectangle.X + Rectangle.Width - Rectangle.Height, Rectangle.Y, Rectangle.Height, Rectangle.Height), -90f, 180f);
			}
			else
			{
				graphicsPath.AddLine(Rectangle.X + Rectangle.Width, Rectangle.Y, Rectangle.X + Rectangle.Width, Rectangle.Y + Rectangle.Height);
			}
			graphicsPath.CloseAllFigures();
			return graphicsPath;
		}

		// Token: 0x060000CA RID: 202 RVA: 0x0000A46E File Offset: 0x0000866E
		public object Pill(int X, int Y, int Width, int Height, iTalk_Toggle.PillStyle PillStyle)
		{
			return this.Pill(new Rectangle(X, Y, Width, Height), PillStyle);
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x060000CB RID: 203 RVA: 0x0000A484 File Offset: 0x00008684
		// (remove) Token: 0x060000CC RID: 204 RVA: 0x0000A4BC File Offset: 0x000086BC
		public event iTalk_Toggle.ToggledChangedEventHandler ToggledChanged;

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000CD RID: 205 RVA: 0x0000A4F1 File Offset: 0x000086F1
		// (set) Token: 0x060000CE RID: 206 RVA: 0x0000A4F9 File Offset: 0x000086F9
		public bool Toggled
		{
			get
			{
				return this._Toggled;
			}
			set
			{
				this._Toggled = value;
				base.Invalidate();
				if (this.ToggledChanged != null)
				{
					this.ToggledChanged();
				}
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000CF RID: 207 RVA: 0x0000A51B File Offset: 0x0000871B
		// (set) Token: 0x060000D0 RID: 208 RVA: 0x0000A523 File Offset: 0x00008723
		public iTalk_Toggle._Type Type
		{
			get
			{
				return this.ToggleType;
			}
			set
			{
				this.ToggleType = value;
				base.Invalidate();
			}
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0000A532 File Offset: 0x00008732
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Width = 41;
			base.Height = 23;
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0000A54B File Offset: 0x0000874B
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.Toggled = !this.Toggled;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0000A564 File Offset: 0x00008764
		public iTalk_Toggle()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
			this.AnimationTimer.Tick += this.AnimationTimer_Tick;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0000A5BB File Offset: 0x000087BB
		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			this.AnimationTimer.Start();
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0000A5D0 File Offset: 0x000087D0
		private void AnimationTimer_Tick(object sender, EventArgs e)
		{
			if (this._Toggled)
			{
				if (this.ToggleLocation < 100)
				{
					this.ToggleLocation += 10;
					base.Invalidate(false);
					return;
				}
			}
			else if (this.ToggleLocation > 0)
			{
				this.ToggleLocation -= 10;
				base.Invalidate(false);
			}
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0000A628 File Offset: 0x00008828
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Graphics graphics = e.Graphics;
			graphics.Clear(base.Parent.BackColor);
			checked
			{
				Point point = new Point(0, (int)Math.Round(unchecked((double)base.Height / 2.0 - (double)this.cHandle.Height / 2.0)));
				Point point2 = new Point(0, (int)Math.Round(unchecked((double)base.Height / 2.0 + (double)this.cHandle.Height / 2.0)));
				LinearGradientBrush linearGradientBrush = new LinearGradientBrush(point, point2, Color.FromArgb(250, 250, 250), Color.FromArgb(240, 240, 240));
				this.Bar = new Rectangle(8, 10, base.Width - 21, base.Height - 21);
				graphics.SmoothingMode = SmoothingMode.AntiAlias;
				graphics.FillPath(linearGradientBrush, (GraphicsPath)this.Pill(0, (int)Math.Round(unchecked((double)base.Height / 2.0 - (double)this.cHandle.Height / 2.0)), base.Width - 1, this.cHandle.Height - 5, new iTalk_Toggle.PillStyle
				{
					Left = true,
					Right = true
				}));
				graphics.DrawPath(new Pen(Color.FromArgb(177, 177, 176)), (GraphicsPath)this.Pill(0, (int)Math.Round(unchecked((double)base.Height / 2.0 - (double)this.cHandle.Height / 2.0)), base.Width - 1, this.cHandle.Height - 5, new iTalk_Toggle.PillStyle
				{
					Left = true,
					Right = true
				}));
				linearGradientBrush.Dispose();
				switch (this.ToggleType)
				{
				case iTalk_Toggle._Type.YesNo:
					if (this.Toggled)
					{
						graphics.DrawString("Yes", new Font("Segoe UI", 7f, FontStyle.Regular), Brushes.Gray, (float)(this.Bar.X + 7), (float)this.Bar.Y, new StringFormat
						{
							Alignment = StringAlignment.Center,
							LineAlignment = StringAlignment.Center
						});
					}
					else
					{
						graphics.DrawString("No", new Font("Segoe UI", 7f, FontStyle.Regular), Brushes.Gray, (float)(this.Bar.X + 18), (float)this.Bar.Y, new StringFormat
						{
							Alignment = StringAlignment.Center,
							LineAlignment = StringAlignment.Center
						});
					}
					break;
				case iTalk_Toggle._Type.OnOff:
					if (this.Toggled)
					{
						graphics.DrawString("On", new Font("Segoe UI", 7f, FontStyle.Regular), Brushes.Gray, (float)(this.Bar.X + 7), (float)this.Bar.Y, new StringFormat
						{
							Alignment = StringAlignment.Center,
							LineAlignment = StringAlignment.Center
						});
					}
					else
					{
						graphics.DrawString("Off", new Font("Segoe UI", 7f, FontStyle.Regular), Brushes.Gray, (float)(this.Bar.X + 18), (float)this.Bar.Y, new StringFormat
						{
							Alignment = StringAlignment.Center,
							LineAlignment = StringAlignment.Center
						});
					}
					break;
				case iTalk_Toggle._Type.IO:
					if (this.Toggled)
					{
						graphics.DrawString("I", new Font("Segoe UI", 7f, FontStyle.Regular), Brushes.Gray, (float)(this.Bar.X + 7), (float)this.Bar.Y, new StringFormat
						{
							Alignment = StringAlignment.Center,
							LineAlignment = StringAlignment.Center
						});
					}
					else
					{
						graphics.DrawString("O", new Font("Segoe UI", 7f, FontStyle.Regular), Brushes.Gray, (float)(this.Bar.X + 18), (float)this.Bar.Y, new StringFormat
						{
							Alignment = StringAlignment.Center,
							LineAlignment = StringAlignment.Center
						});
					}
					break;
				}
				graphics.FillEllipse(new SolidBrush(Color.FromArgb(249, 249, 249)), this.Bar.X + (int)Math.Round(unchecked((double)this.Bar.Width * ((double)this.ToggleLocation / 80.0))) - (int)Math.Round((double)this.cHandle.Width / 2.0), this.Bar.Y + (int)Math.Round((double)this.Bar.Height / 2.0) - (int)Math.Round(unchecked((double)this.cHandle.Height / 2.0 - 1.0)), this.cHandle.Width, this.cHandle.Height - 5);
				graphics.DrawEllipse(new Pen(Color.FromArgb(177, 177, 176)), this.Bar.X + (int)Math.Round(unchecked((double)this.Bar.Width * ((double)this.ToggleLocation / 80.0) - (double)(checked((int)Math.Round((double)this.cHandle.Width / 2.0))))), this.Bar.Y + (int)Math.Round((double)this.Bar.Height / 2.0) - (int)Math.Round(unchecked((double)this.cHandle.Height / 2.0 - 1.0)), this.cHandle.Width, this.cHandle.Height - 5);
			}
		}

		// Token: 0x04000091 RID: 145
		private Timer AnimationTimer = new Timer
		{
			Interval = 1
		};

		// Token: 0x04000092 RID: 146
		private int ToggleLocation;

		// Token: 0x04000094 RID: 148
		private bool _Toggled;

		// Token: 0x04000095 RID: 149
		private iTalk_Toggle._Type ToggleType;

		// Token: 0x04000096 RID: 150
		private Rectangle Bar;

		// Token: 0x04000097 RID: 151
		private Size cHandle = new Size(15, 20);

		// Token: 0x02000031 RID: 49
		public class PillStyle
		{
			// Token: 0x04000101 RID: 257
			public bool Left;

			// Token: 0x04000102 RID: 258
			public bool Right;
		}

		// Token: 0x02000032 RID: 50
		public enum _Type
		{
			// Token: 0x04000104 RID: 260
			YesNo,
			// Token: 0x04000105 RID: 261
			OnOff,
			// Token: 0x04000106 RID: 262
			IO
		}

		// Token: 0x02000033 RID: 51
		// (Invoke) Token: 0x060001D0 RID: 464
		public delegate void ToggledChangedEventHandler();
	}
}
