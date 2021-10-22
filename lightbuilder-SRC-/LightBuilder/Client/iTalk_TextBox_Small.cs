using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Client
{
	// Token: 0x02000016 RID: 22
	[DefaultEvent("TextChanged")]
	internal class iTalk_TextBox_Small : Control
	{
		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060000F2 RID: 242 RVA: 0x0000B23D File Offset: 0x0000943D
		// (set) Token: 0x060000F3 RID: 243 RVA: 0x0000B245 File Offset: 0x00009445
		public HorizontalAlignment TextAlignment
		{
			get
			{
				return this.ALNType;
			}
			set
			{
				this.ALNType = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060000F4 RID: 244 RVA: 0x0000B254 File Offset: 0x00009454
		// (set) Token: 0x060000F5 RID: 245 RVA: 0x0000B25C File Offset: 0x0000945C
		public int MaxLength
		{
			get
			{
				return this._maxchars;
			}
			set
			{
				this._maxchars = value;
				this.iTalkTB.MaxLength = this.MaxLength;
				base.Invalidate();
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060000F6 RID: 246 RVA: 0x0000B27C File Offset: 0x0000947C
		// (set) Token: 0x060000F7 RID: 247 RVA: 0x0000B284 File Offset: 0x00009484
		public bool UseSystemPasswordChar
		{
			get
			{
				return this.isPasswordMasked;
			}
			set
			{
				this.iTalkTB.UseSystemPasswordChar = this.UseSystemPasswordChar;
				this.isPasswordMasked = value;
				base.Invalidate();
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060000F8 RID: 248 RVA: 0x0000B2A4 File Offset: 0x000094A4
		// (set) Token: 0x060000F9 RID: 249 RVA: 0x0000B2AC File Offset: 0x000094AC
		public bool ReadOnly
		{
			get
			{
				return this._ReadOnly;
			}
			set
			{
				this._ReadOnly = value;
				if (this.iTalkTB != null)
				{
					this.iTalkTB.ReadOnly = value;
				}
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060000FA RID: 250 RVA: 0x0000B2C9 File Offset: 0x000094C9
		// (set) Token: 0x060000FB RID: 251 RVA: 0x0000B2D4 File Offset: 0x000094D4
		public bool Multiline
		{
			get
			{
				return this._Multiline;
			}
			set
			{
				this._Multiline = value;
				if (this.iTalkTB != null)
				{
					this.iTalkTB.Multiline = value;
					if (value)
					{
						this.iTalkTB.Height = base.Height - 10;
						return;
					}
					base.Height = this.iTalkTB.Height + 10;
				}
			}
		}

		// Token: 0x060000FC RID: 252 RVA: 0x0000B328 File Offset: 0x00009528
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			this.iTalkTB.Text = this.Text;
			base.Invalidate();
		}

		// Token: 0x060000FD RID: 253 RVA: 0x0000B348 File Offset: 0x00009548
		private void OnBaseTextChanged(object s, EventArgs e)
		{
			this.Text = this.iTalkTB.Text;
		}

		// Token: 0x060000FE RID: 254 RVA: 0x0000B35B File Offset: 0x0000955B
		protected override void OnForeColorChanged(EventArgs e)
		{
			base.OnForeColorChanged(e);
			this.iTalkTB.ForeColor = this.ForeColor;
			base.Invalidate();
		}

		// Token: 0x060000FF RID: 255 RVA: 0x0000B37B File Offset: 0x0000957B
		protected override void OnFontChanged(EventArgs e)
		{
			base.OnFontChanged(e);
			this.iTalkTB.Font = this.Font;
		}

		// Token: 0x06000100 RID: 256 RVA: 0x0000B395 File Offset: 0x00009595
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);
		}

		// Token: 0x06000101 RID: 257 RVA: 0x0000B3A0 File Offset: 0x000095A0
		private void _OnKeyDown(object Obj, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.A)
			{
				this.iTalkTB.SelectAll();
				e.SuppressKeyPress = true;
			}
			if (e.Control && e.KeyCode == Keys.C)
			{
				this.iTalkTB.Copy();
				e.SuppressKeyPress = true;
			}
		}

		// Token: 0x06000102 RID: 258 RVA: 0x0000B3F8 File Offset: 0x000095F8
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			if (this._Multiline)
			{
				this.iTalkTB.Height = base.Height - 10;
			}
			else
			{
				base.Height = this.iTalkTB.Height + 10;
			}
			this.Shape = new GraphicsPath();
			GraphicsPath shape = this.Shape;
			shape.AddArc(0, 0, 10, 10, 180f, 90f);
			shape.AddArc(base.Width - 11, 0, 10, 10, -90f, 90f);
			shape.AddArc(base.Width - 11, base.Height - 11, 10, 10, 0f, 90f);
			shape.AddArc(0, base.Height - 11, 10, 10, 90f, 90f);
			shape.CloseAllFigures();
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0000B4CC File Offset: 0x000096CC
		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			this.iTalkTB.Focus();
		}

		// Token: 0x06000104 RID: 260 RVA: 0x0000B4E4 File Offset: 0x000096E4
		public void AddTextBox()
		{
			TextBox textBox = this.iTalkTB;
			textBox.Size = new Size(base.Width - 10, 33);
			textBox.Location = new Point(7, 5);
			textBox.Text = string.Empty;
			textBox.BorderStyle = BorderStyle.None;
			textBox.TextAlign = HorizontalAlignment.Left;
			textBox.Font = new Font("Tahoma", 11f);
			textBox.UseSystemPasswordChar = this.UseSystemPasswordChar;
			textBox.Multiline = false;
			this.iTalkTB.KeyDown += this._OnKeyDown;
			this.iTalkTB.TextChanged += this.OnBaseTextChanged;
		}

		// Token: 0x06000105 RID: 261 RVA: 0x0000B588 File Offset: 0x00009788
		public iTalk_TextBox_Small()
		{
			base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			base.SetStyle(ControlStyles.UserPaint, true);
			this.AddTextBox();
			base.Controls.Add(this.iTalkTB);
			this.P1 = new Pen(Color.FromArgb(180, 180, 180));
			this.B1 = new SolidBrush(Color.White);
			this.BackColor = Color.Transparent;
			this.ForeColor = Color.DimGray;
			this.Text = null;
			this.Font = new Font("Tahoma", 11f);
			base.Size = new Size(135, 33);
			this.DoubleBuffered = true;
		}

		// Token: 0x06000106 RID: 262 RVA: 0x0000B658 File Offset: 0x00009858
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			TextBox textBox = this.iTalkTB;
			textBox.Width = base.Width - 10;
			textBox.TextAlign = this.TextAlignment;
			textBox.UseSystemPasswordChar = this.UseSystemPasswordChar;
			graphics.Clear(Color.Transparent);
			graphics.FillPath(this.B1, this.Shape);
			graphics.DrawPath(this.P1, this.Shape);
			e.Graphics.DrawImage((Image)bitmap.Clone(), 0, 0);
			graphics.Dispose();
			bitmap.Dispose();
		}

		// Token: 0x040000A3 RID: 163
		public TextBox iTalkTB = new TextBox();

		// Token: 0x040000A4 RID: 164
		private GraphicsPath Shape;

		// Token: 0x040000A5 RID: 165
		private int _maxchars = 32767;

		// Token: 0x040000A6 RID: 166
		private bool _ReadOnly;

		// Token: 0x040000A7 RID: 167
		private bool _Multiline;

		// Token: 0x040000A8 RID: 168
		private HorizontalAlignment ALNType;

		// Token: 0x040000A9 RID: 169
		private bool isPasswordMasked;

		// Token: 0x040000AA RID: 170
		private Pen P1;

		// Token: 0x040000AB RID: 171
		private SolidBrush B1;
	}
}
