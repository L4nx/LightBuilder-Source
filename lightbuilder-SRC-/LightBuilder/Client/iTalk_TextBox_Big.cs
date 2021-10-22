using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Client
{
	// Token: 0x02000015 RID: 21
	[DefaultEvent("TextChanged")]
	internal class iTalk_TextBox_Big : Control
	{
		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000DA RID: 218 RVA: 0x0000ACCA File Offset: 0x00008ECA
		// (set) Token: 0x060000DB RID: 219 RVA: 0x0000ACD2 File Offset: 0x00008ED2
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

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000DC RID: 220 RVA: 0x0000ACE1 File Offset: 0x00008EE1
		// (set) Token: 0x060000DD RID: 221 RVA: 0x0000ACE9 File Offset: 0x00008EE9
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

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000DE RID: 222 RVA: 0x0000AD09 File Offset: 0x00008F09
		// (set) Token: 0x060000DF RID: 223 RVA: 0x0000AD11 File Offset: 0x00008F11
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

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x0000AD31 File Offset: 0x00008F31
		// (set) Token: 0x060000E1 RID: 225 RVA: 0x0000AD39 File Offset: 0x00008F39
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

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000E2 RID: 226 RVA: 0x0000AD56 File Offset: 0x00008F56
		// (set) Token: 0x060000E3 RID: 227 RVA: 0x0000AD60 File Offset: 0x00008F60
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
						this.iTalkTB.Height = base.Height - 23;
						return;
					}
					base.Height = this.iTalkTB.Height + 23;
				}
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060000E4 RID: 228 RVA: 0x0000ADB4 File Offset: 0x00008FB4
		// (set) Token: 0x060000E5 RID: 229 RVA: 0x0000ADBC File Offset: 0x00008FBC
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
				if (this.Image == null)
				{
					this.iTalkTB.Location = new Point(8, 10);
				}
				else
				{
					this.iTalkTB.Location = new Point(35, 11);
				}
				base.Invalidate();
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060000E6 RID: 230 RVA: 0x0000AE23 File Offset: 0x00009023
		protected Size ImageSize
		{
			get
			{
				return this._ImageSize;
			}
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0000AE2B File Offset: 0x0000902B
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			this.iTalkTB.Text = this.Text;
			base.Invalidate();
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x0000AE4B File Offset: 0x0000904B
		private void OnBaseTextChanged(object s, EventArgs e)
		{
			this.Text = this.iTalkTB.Text;
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x0000AE5E File Offset: 0x0000905E
		protected override void OnForeColorChanged(EventArgs e)
		{
			base.OnForeColorChanged(e);
			this.iTalkTB.ForeColor = this.ForeColor;
			base.Invalidate();
		}

		// Token: 0x060000EA RID: 234 RVA: 0x0000AE7E File Offset: 0x0000907E
		protected override void OnFontChanged(EventArgs e)
		{
			base.OnFontChanged(e);
			this.iTalkTB.Font = this.Font;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x0000AE98 File Offset: 0x00009098
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);
		}

		// Token: 0x060000EC RID: 236 RVA: 0x0000AEA4 File Offset: 0x000090A4
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

		// Token: 0x060000ED RID: 237 RVA: 0x0000AEFC File Offset: 0x000090FC
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			if (this._Multiline)
			{
				this.iTalkTB.Height = base.Height - 23;
			}
			else
			{
				base.Height = this.iTalkTB.Height + 23;
			}
			this.Shape = new GraphicsPath();
			GraphicsPath shape = this.Shape;
			shape.AddArc(0, 0, 10, 10, 180f, 90f);
			shape.AddArc(base.Width - 11, 0, 10, 10, -90f, 90f);
			shape.AddArc(base.Width - 11, base.Height - 11, 10, 10, 0f, 90f);
			shape.AddArc(0, base.Height - 11, 10, 10, 90f, 90f);
			shape.CloseAllFigures();
		}

		// Token: 0x060000EE RID: 238 RVA: 0x0000AFD0 File Offset: 0x000091D0
		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			this.iTalkTB.Focus();
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0000AFE8 File Offset: 0x000091E8
		public void AddTextBox()
		{
			TextBox textBox = this.iTalkTB;
			textBox.Location = new Point(7, 10);
			textBox.Text = string.Empty;
			textBox.BorderStyle = BorderStyle.None;
			textBox.TextAlign = HorizontalAlignment.Left;
			textBox.Font = new Font("Tahoma", 11f);
			textBox.UseSystemPasswordChar = this.UseSystemPasswordChar;
			textBox.Multiline = false;
			this.iTalkTB.KeyDown += this._OnKeyDown;
			this.iTalkTB.TextChanged += this.OnBaseTextChanged;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x0000B078 File Offset: 0x00009278
		public iTalk_TextBox_Big()
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
			base.Size = new Size(135, 43);
			this.DoubleBuffered = true;
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x0000B148 File Offset: 0x00009348
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			if (this.Image == null)
			{
				this.iTalkTB.Width = base.Width - 18;
			}
			else
			{
				this.iTalkTB.Width = base.Width - 45;
			}
			this.iTalkTB.TextAlign = this.TextAlignment;
			this.iTalkTB.UseSystemPasswordChar = this.UseSystemPasswordChar;
			graphics.Clear(Color.Transparent);
			graphics.FillPath(this.B1, this.Shape);
			graphics.DrawPath(this.P1, this.Shape);
			if (this.Image != null)
			{
				graphics.DrawImage(this._Image, 5, 8, 24, 24);
			}
			e.Graphics.DrawImage((Image)bitmap.Clone(), 0, 0);
			graphics.Dispose();
			bitmap.Dispose();
		}

		// Token: 0x04000098 RID: 152
		public TextBox iTalkTB = new TextBox();

		// Token: 0x04000099 RID: 153
		private GraphicsPath Shape;

		// Token: 0x0400009A RID: 154
		private int _maxchars = 32767;

		// Token: 0x0400009B RID: 155
		private bool _ReadOnly;

		// Token: 0x0400009C RID: 156
		private bool _Multiline;

		// Token: 0x0400009D RID: 157
		private Image _Image;

		// Token: 0x0400009E RID: 158
		private Size _ImageSize;

		// Token: 0x0400009F RID: 159
		private HorizontalAlignment ALNType;

		// Token: 0x040000A0 RID: 160
		private bool isPasswordMasked;

		// Token: 0x040000A1 RID: 161
		private Pen P1;

		// Token: 0x040000A2 RID: 162
		private SolidBrush B1;
	}
}
