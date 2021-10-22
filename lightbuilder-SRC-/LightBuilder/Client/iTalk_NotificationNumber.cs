using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Client
{
	// Token: 0x02000020 RID: 32
	internal class iTalk_NotificationNumber : Control
	{
		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000156 RID: 342 RVA: 0x0000D25B File Offset: 0x0000B45B
		// (set) Token: 0x06000157 RID: 343 RVA: 0x0000D26D File Offset: 0x0000B46D
		public int Value
		{
			get
			{
				if (this._Value == 0)
				{
					return 0;
				}
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

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000158 RID: 344 RVA: 0x0000D28D File Offset: 0x0000B48D
		// (set) Token: 0x06000159 RID: 345 RVA: 0x0000D295 File Offset: 0x0000B495
		public int Maximum
		{
			get
			{
				return this._Maximum;
			}
			set
			{
				if (value < this._Value)
				{
					this._Value = value;
				}
				this._Maximum = value;
				base.Invalidate();
			}
		}

		// Token: 0x0600015A RID: 346 RVA: 0x0000D2B4 File Offset: 0x0000B4B4
		public iTalk_NotificationNumber()
		{
			base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			base.SetStyle(ControlStyles.UserPaint, true);
			this.Text = null;
			this.DoubleBuffered = true;
		}

		// Token: 0x0600015B RID: 347 RVA: 0x0000D2E6 File Offset: 0x0000B4E6
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Height = 20;
			base.Width = 20;
		}

		// Token: 0x0600015C RID: 348 RVA: 0x0000D300 File Offset: 0x0000B500
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Graphics graphics = e.Graphics;
			string s = this._Value.ToString();
			graphics.Clear(this.BackColor);
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(new Point(0, 0), new Size(18, 20)), Color.FromArgb(197, 69, 68), Color.FromArgb(176, 52, 52), 90f);
			graphics.FillEllipse(brush, new Rectangle(new Point(0, 0), new Size(18, 18)));
			graphics.DrawEllipse(new Pen(Color.FromArgb(205, 70, 66)), new Rectangle(new Point(0, 0), new Size(18, 18)));
			graphics.DrawString(s, new Font("Segoe UI", 8f, FontStyle.Bold), new SolidBrush(Color.FromArgb(255, 255, 253)), new Rectangle(0, 0, base.Width - 2, base.Height), new StringFormat
			{
				Alignment = StringAlignment.Center,
				LineAlignment = StringAlignment.Center
			});
			e.Dispose();
		}

		// Token: 0x040000CC RID: 204
		private int _Value;

		// Token: 0x040000CD RID: 205
		private int _Maximum = 99;
	}
}
