using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Client
{
	// Token: 0x02000027 RID: 39
	[DefaultEvent("ValueChanged")]
	internal class iTalk_TrackBar : Control
	{
		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000193 RID: 403 RVA: 0x0000E713 File Offset: 0x0000C913
		// (set) Token: 0x06000194 RID: 404 RVA: 0x0000E71B File Offset: 0x0000C91B
		public int Minimum
		{
			get
			{
				return this._Minimum;
			}
			set
			{
				if (value >= this._Maximum)
				{
					value = this._Maximum - 10;
				}
				if (this._Value < value)
				{
					this._Value = value;
				}
				this._Minimum = value;
				base.Invalidate();
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000195 RID: 405 RVA: 0x0000E74E File Offset: 0x0000C94E
		// (set) Token: 0x06000196 RID: 406 RVA: 0x0000E756 File Offset: 0x0000C956
		public int Maximum
		{
			get
			{
				return this._Maximum;
			}
			set
			{
				if (value <= this._Minimum)
				{
					value = this._Minimum + 10;
				}
				if (this._Value > value)
				{
					this._Value = value;
				}
				this._Maximum = value;
				base.Invalidate();
			}
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000197 RID: 407 RVA: 0x0000E78C File Offset: 0x0000C98C
		// (remove) Token: 0x06000198 RID: 408 RVA: 0x0000E7C4 File Offset: 0x0000C9C4
		public event iTalk_TrackBar.ValueChangedEventHandler ValueChanged;

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000199 RID: 409 RVA: 0x0000E7F9 File Offset: 0x0000C9F9
		// (set) Token: 0x0600019A RID: 410 RVA: 0x0000E804 File Offset: 0x0000CA04
		public int Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				if (this._Value != value)
				{
					if (value < this._Minimum)
					{
						this._Value = this._Minimum;
					}
					else if (value > this._Maximum)
					{
						this._Value = this._Maximum;
					}
					else
					{
						this._Value = value;
					}
					base.Invalidate();
					if (this.ValueChanged != null)
					{
						this.ValueChanged();
					}
				}
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x0600019B RID: 411 RVA: 0x0000E868 File Offset: 0x0000CA68
		// (set) Token: 0x0600019C RID: 412 RVA: 0x0000E870 File Offset: 0x0000CA70
		public iTalk_TrackBar.ValueDivisor ValueDivison
		{
			get
			{
				return this.DividedValue;
			}
			set
			{
				this.DividedValue = value;
				base.Invalidate();
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x0600019D RID: 413 RVA: 0x0000E87F File Offset: 0x0000CA7F
		// (set) Token: 0x0600019E RID: 414 RVA: 0x0000E891 File Offset: 0x0000CA91
		[Browsable(false)]
		public float ValueToSet
		{
			get
			{
				return (float)((double)this._Value / (double)this.DividedValue);
			}
			set
			{
				this.Value = (int)Math.Round((double)(value * (float)this.DividedValue));
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x0600019F RID: 415 RVA: 0x0000E8A9 File Offset: 0x0000CAA9
		// (set) Token: 0x060001A0 RID: 416 RVA: 0x0000E8B1 File Offset: 0x0000CAB1
		public Color ValueColour
		{
			get
			{
				return this._ValueColour;
			}
			set
			{
				this._ValueColour = value;
				base.Invalidate();
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060001A1 RID: 417 RVA: 0x0000E8C0 File Offset: 0x0000CAC0
		// (set) Token: 0x060001A2 RID: 418 RVA: 0x0000E8C8 File Offset: 0x0000CAC8
		public bool DrawHatch
		{
			get
			{
				return this._DrawHatch;
			}
			set
			{
				this._DrawHatch = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060001A3 RID: 419 RVA: 0x0000E8D7 File Offset: 0x0000CAD7
		// (set) Token: 0x060001A4 RID: 420 RVA: 0x0000E8DF File Offset: 0x0000CADF
		public bool DrawValueString
		{
			get
			{
				return this._DrawValueString;
			}
			set
			{
				this._DrawValueString = value;
				if (this._DrawValueString)
				{
					base.Height = 40;
				}
				else
				{
					base.Height = 22;
				}
				base.Invalidate();
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060001A5 RID: 421 RVA: 0x0000E908 File Offset: 0x0000CB08
		// (set) Token: 0x060001A6 RID: 422 RVA: 0x0000E910 File Offset: 0x0000CB10
		public bool JumpToMouse
		{
			get
			{
				return this._JumpToMouse;
			}
			set
			{
				this._JumpToMouse = value;
			}
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x0000E91C File Offset: 0x0000CB1C
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (this.Cap && e.X > -1 && e.X < base.Width + 1)
			{
				this.Value = this._Minimum + (int)Math.Round((double)(this._Maximum - this._Minimum) * ((double)e.X / (double)base.Width));
			}
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x0000E984 File Offset: 0x0000CB84
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (e.Button == MouseButtons.Left)
			{
				this.ValueDrawer = (int)Math.Round((double)(this._Value - this._Minimum) / (double)(this._Maximum - this._Minimum) * (double)(base.Width - 11));
				this.TrackBarHandleRect = new Rectangle(this.ValueDrawer, 0, 10, 20);
				this.Cap = this.TrackBarHandleRect.Contains(e.Location);
				if (this._JumpToMouse)
				{
					this.Value = this._Minimum + (int)Math.Round((double)(this._Maximum - this._Minimum) * ((double)e.X / (double)base.Width));
				}
			}
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x0000EA44 File Offset: 0x0000CC44
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.Cap = false;
		}

		// Token: 0x060001AA RID: 426 RVA: 0x0000EA54 File Offset: 0x0000CC54
		public iTalk_TrackBar()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
			this._DrawHatch = true;
			base.Size = new Size(80, 22);
			this.MinimumSize = new Size(37, 22);
		}

		// Token: 0x060001AB RID: 427 RVA: 0x0000EAC8 File Offset: 0x0000CCC8
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			if (this._DrawValueString)
			{
				base.Height = 40;
				return;
			}
			base.Height = 22;
		}

		// Token: 0x060001AC RID: 428 RVA: 0x0000EAEC File Offset: 0x0000CCEC
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Graphics graphics = e.Graphics;
			HatchBrush brush = new HatchBrush(HatchStyle.WideDownwardDiagonal, Color.FromArgb(20, Color.Black), Color.Transparent);
			graphics.Clear(base.Parent.BackColor);
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			checked
			{
				this.PipeBorder = RoundRectangle.RoundRect(1, 6, base.Width - 3, 8, 3);
				try
				{
					this.ValueDrawer = (int)Math.Round(unchecked(checked((double)(this._Value - this._Minimum) / (double)(this._Maximum - this._Minimum)) * (double)(checked(base.Width - 11))));
				}
				catch (Exception)
				{
				}
				this.TrackBarHandleRect = new Rectangle(this.ValueDrawer, 0, 10, 20);
				graphics.SetClip(this.PipeBorder);
				this.ValueRect = new Rectangle(1, 7, this.TrackBarHandleRect.X + this.TrackBarHandleRect.Width - 2, 7);
				this.VlaueLGB = new LinearGradientBrush(this.ValueRect, this._ValueColour, this._ValueColour, 90f);
				graphics.FillRectangle(this.VlaueLGB, this.ValueRect);
				if (this._DrawHatch)
				{
					graphics.FillRectangle(brush, this.ValueRect);
				}
				graphics.ResetClip();
				graphics.SmoothingMode = SmoothingMode.AntiAlias;
				graphics.DrawPath(new Pen(Color.FromArgb(180, 180, 180)), this.PipeBorder);
				this.TrackBarHandle = RoundRectangle.RoundRect(this.TrackBarHandleRect, 3);
				this.TrackBarHandleLGB = new LinearGradientBrush(base.ClientRectangle, SystemColors.Control, SystemColors.Control, 90f);
				graphics.FillPath(this.TrackBarHandleLGB, this.TrackBarHandle);
				graphics.DrawPath(new Pen(Color.FromArgb(180, 180, 180)), this.TrackBarHandle);
				if (this._DrawValueString)
				{
					graphics.DrawString(Convert.ToString(this.ValueToSet), this.Font, Brushes.Gray, 0f, 25f);
				}
			}
		}

		// Token: 0x040000DF RID: 223
		private GraphicsPath PipeBorder;

		// Token: 0x040000E0 RID: 224
		private GraphicsPath TrackBarHandle;

		// Token: 0x040000E1 RID: 225
		private Rectangle TrackBarHandleRect;

		// Token: 0x040000E2 RID: 226
		private Rectangle ValueRect;

		// Token: 0x040000E3 RID: 227
		private LinearGradientBrush VlaueLGB;

		// Token: 0x040000E4 RID: 228
		private LinearGradientBrush TrackBarHandleLGB;

		// Token: 0x040000E5 RID: 229
		private bool Cap;

		// Token: 0x040000E6 RID: 230
		private int ValueDrawer;

		// Token: 0x040000E7 RID: 231
		private int _Minimum;

		// Token: 0x040000E8 RID: 232
		private int _Maximum = 10;

		// Token: 0x040000E9 RID: 233
		private int _Value;

		// Token: 0x040000EA RID: 234
		private Color _ValueColour = Color.FromArgb(224, 224, 224);

		// Token: 0x040000EB RID: 235
		private bool _DrawHatch = true;

		// Token: 0x040000EC RID: 236
		private bool _DrawValueString;

		// Token: 0x040000ED RID: 237
		private bool _JumpToMouse;

		// Token: 0x040000EE RID: 238
		private iTalk_TrackBar.ValueDivisor DividedValue = iTalk_TrackBar.ValueDivisor.By1;

		// Token: 0x02000039 RID: 57
		public enum ValueDivisor
		{
			// Token: 0x04000113 RID: 275
			By1 = 1,
			// Token: 0x04000114 RID: 276
			By10 = 10,
			// Token: 0x04000115 RID: 277
			By100 = 100,
			// Token: 0x04000116 RID: 278
			By1000 = 1000
		}

		// Token: 0x0200003A RID: 58
		// (Invoke) Token: 0x060001DC RID: 476
		public delegate void ValueChangedEventHandler();
	}
}
