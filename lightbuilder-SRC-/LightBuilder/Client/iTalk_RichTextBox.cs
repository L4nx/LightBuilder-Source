using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Client
{
	// Token: 0x02000017 RID: 23
	[DefaultEvent("TextChanged")]
	internal class iTalk_RichTextBox : Control
	{
		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000107 RID: 263 RVA: 0x0000B709 File Offset: 0x00009909
		// (set) Token: 0x06000108 RID: 264 RVA: 0x0000B716 File Offset: 0x00009916
		public override string Text
		{
			get
			{
				return this.iTalkRTB.Text;
			}
			set
			{
				this.iTalkRTB.Text = value;
				base.Invalidate();
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000109 RID: 265 RVA: 0x0000B72A File Offset: 0x0000992A
		// (set) Token: 0x0600010A RID: 266 RVA: 0x0000B732 File Offset: 0x00009932
		public bool ReadOnly
		{
			get
			{
				return this._ReadOnly;
			}
			set
			{
				this._ReadOnly = value;
				if (this.iTalkRTB != null)
				{
					this.iTalkRTB.ReadOnly = value;
				}
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x0600010B RID: 267 RVA: 0x0000B74F File Offset: 0x0000994F
		// (set) Token: 0x0600010C RID: 268 RVA: 0x0000B757 File Offset: 0x00009957
		public bool WordWrap
		{
			get
			{
				return this._WordWrap;
			}
			set
			{
				this._WordWrap = value;
				if (this.iTalkRTB != null)
				{
					this.iTalkRTB.WordWrap = value;
				}
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600010D RID: 269 RVA: 0x0000B774 File Offset: 0x00009974
		// (set) Token: 0x0600010E RID: 270 RVA: 0x0000B77C File Offset: 0x0000997C
		public bool AutoWordSelection
		{
			get
			{
				return this._AutoWordSelection;
			}
			set
			{
				this._AutoWordSelection = value;
				if (this.iTalkRTB != null)
				{
					this.iTalkRTB.AutoWordSelection = value;
				}
			}
		}

		// Token: 0x0600010F RID: 271 RVA: 0x0000B799 File Offset: 0x00009999
		protected override void OnForeColorChanged(EventArgs e)
		{
			base.OnForeColorChanged(e);
			this.iTalkRTB.ForeColor = this.ForeColor;
			base.Invalidate();
		}

		// Token: 0x06000110 RID: 272 RVA: 0x0000B7B9 File Offset: 0x000099B9
		protected override void OnFontChanged(EventArgs e)
		{
			base.OnFontChanged(e);
			this.iTalkRTB.Font = this.Font;
		}

		// Token: 0x06000111 RID: 273 RVA: 0x0000B7D3 File Offset: 0x000099D3
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);
		}

		// Token: 0x06000112 RID: 274 RVA: 0x0000B7DC File Offset: 0x000099DC
		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			this.iTalkRTB.Size = new Size(base.Width - 13, base.Height - 11);
		}

		// Token: 0x06000113 RID: 275 RVA: 0x0000B808 File Offset: 0x00009A08
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.Shape = new GraphicsPath();
			GraphicsPath shape = this.Shape;
			shape.AddArc(0, 0, 10, 10, 180f, 90f);
			shape.AddArc(base.Width - 11, 0, 10, 10, -90f, 90f);
			shape.AddArc(base.Width - 11, base.Height - 11, 10, 10, 0f, 90f);
			shape.AddArc(0, base.Height - 11, 10, 10, 90f, 90f);
			shape.CloseAllFigures();
		}

		// Token: 0x06000114 RID: 276 RVA: 0x0000B8AA File Offset: 0x00009AAA
		public void _TextChanged(object s, EventArgs e)
		{
			this.iTalkRTB.Text = this.Text;
		}

		// Token: 0x06000115 RID: 277 RVA: 0x0000B8C0 File Offset: 0x00009AC0
		public void AddRichTextBox()
		{
			RichTextBox richTextBox = this.iTalkRTB;
			richTextBox.BackColor = Color.White;
			richTextBox.Size = new Size(base.Width - 10, 100);
			richTextBox.Location = new Point(7, 5);
			richTextBox.Text = string.Empty;
			richTextBox.BorderStyle = BorderStyle.None;
			richTextBox.Font = new Font("Tahoma", 10f);
			richTextBox.Multiline = true;
		}

		// Token: 0x06000116 RID: 278 RVA: 0x0000B930 File Offset: 0x00009B30
		public iTalk_RichTextBox()
		{
			base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			base.SetStyle(ControlStyles.UserPaint, true);
			this.AddRichTextBox();
			base.Controls.Add(this.iTalkRTB);
			this.BackColor = Color.Transparent;
			this.ForeColor = Color.DimGray;
			this.Text = null;
			this.Font = new Font("Tahoma", 10f);
			base.Size = new Size(150, 100);
			this.WordWrap = true;
			this.AutoWordSelection = false;
			this.DoubleBuffered = true;
			base.TextChanged += this._TextChanged;
		}

		// Token: 0x06000117 RID: 279 RVA: 0x0000B9E4 File Offset: 0x00009BE4
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			graphics.Clear(Color.Transparent);
			graphics.FillPath(Brushes.White, this.Shape);
			graphics.DrawPath(new Pen(Color.FromArgb(180, 180, 180)), this.Shape);
			graphics.Dispose();
			e.Graphics.DrawImage((Image)bitmap.Clone(), 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x040000AC RID: 172
		public RichTextBox iTalkRTB = new RichTextBox();

		// Token: 0x040000AD RID: 173
		private bool _ReadOnly;

		// Token: 0x040000AE RID: 174
		private bool _WordWrap;

		// Token: 0x040000AF RID: 175
		private bool _AutoWordSelection;

		// Token: 0x040000B0 RID: 176
		private GraphicsPath Shape;
	}
}
