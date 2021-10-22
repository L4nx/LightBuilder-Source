using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Client
{
	// Token: 0x0200001F RID: 31
	[DefaultEvent("CheckedChanged")]
	internal class iTalk_RadioButton : Control
	{
		// Token: 0x14000003 RID: 3
		// (add) Token: 0x0600014C RID: 332 RVA: 0x0000CF48 File Offset: 0x0000B148
		// (remove) Token: 0x0600014D RID: 333 RVA: 0x0000CF80 File Offset: 0x0000B180
		public event iTalk_RadioButton.CheckedChangedEventHandler CheckedChanged;

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x0600014E RID: 334 RVA: 0x0000CFB5 File Offset: 0x0000B1B5
		// (set) Token: 0x0600014F RID: 335 RVA: 0x0000CFBD File Offset: 0x0000B1BD
		public bool Checked
		{
			get
			{
				return this._Checked;
			}
			set
			{
				this._Checked = value;
				this.InvalidateControls();
				if (this.CheckedChanged != null)
				{
					this.CheckedChanged(this);
				}
				base.Invalidate();
			}
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0000CFE6 File Offset: 0x0000B1E6
		protected override void OnTextChanged(EventArgs e)
		{
			base.Invalidate();
			base.OnTextChanged(e);
		}

		// Token: 0x06000151 RID: 337 RVA: 0x0000CFF5 File Offset: 0x0000B1F5
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Height = 15;
		}

		// Token: 0x06000152 RID: 338 RVA: 0x0000D006 File Offset: 0x0000B206
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (!this._Checked)
			{
				this.Checked = true;
			}
			base.OnMouseDown(e);
		}

		// Token: 0x06000153 RID: 339 RVA: 0x0000D01E File Offset: 0x0000B21E
		public iTalk_RadioButton()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.BackColor = Color.Transparent;
			this.Font = new Font("Segoe UI", 10f);
			base.Width = 132;
		}

		// Token: 0x06000154 RID: 340 RVA: 0x0000D060 File Offset: 0x0000B260
		private void InvalidateControls()
		{
			if (!base.IsHandleCreated || !this._Checked)
			{
				return;
			}
			foreach (object obj in base.Parent.Controls)
			{
				Control control = (Control)obj;
				if (control != this && control is iTalk_RadioButton)
				{
					((iTalk_RadioButton)control).Checked = false;
				}
			}
		}

		// Token: 0x06000155 RID: 341 RVA: 0x0000D0E0 File Offset: 0x0000B2E0
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Graphics graphics = e.Graphics;
			graphics.Clear(Color.FromArgb(246, 246, 246));
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(new Point(0, 0), new Size(14, 14)), Color.FromArgb(250, 250, 250), Color.FromArgb(240, 240, 240), 90f);
			graphics.FillEllipse(brush, new Rectangle(new Point(0, 0), new Size(14, 14)));
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddEllipse(new Rectangle(0, 0, 14, 14));
			graphics.SetClip(graphicsPath);
			graphics.ResetClip();
			graphics.DrawEllipse(new Pen(Color.FromArgb(160, 160, 160)), new Rectangle(new Point(0, 0), new Size(14, 14)));
			if (this._Checked)
			{
				SolidBrush brush2 = new SolidBrush(Color.FromArgb(142, 142, 142));
				graphics.FillEllipse(brush2, new Rectangle(new Point(4, 4), new Size(6, 6)));
			}
			graphics.DrawString(this.Text, this.Font, new SolidBrush(Color.FromArgb(142, 142, 142)), 16f, 8f, new StringFormat
			{
				LineAlignment = StringAlignment.Center
			});
			e.Dispose();
		}

		// Token: 0x040000CA RID: 202
		private bool _Checked;

		// Token: 0x02000036 RID: 54
		public enum MouseState : byte
		{
			// Token: 0x0400010B RID: 267
			None,
			// Token: 0x0400010C RID: 268
			Over,
			// Token: 0x0400010D RID: 269
			Down,
			// Token: 0x0400010E RID: 270
			Block
		}

		// Token: 0x02000037 RID: 55
		// (Invoke) Token: 0x060001D8 RID: 472
		public delegate void CheckedChangedEventHandler(object sender);
	}
}
