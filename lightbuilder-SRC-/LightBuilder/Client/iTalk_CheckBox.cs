using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Client
{
	// Token: 0x0200001E RID: 30
	[DefaultEvent("CheckedChanged")]
	internal class iTalk_CheckBox : Control
	{
		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000143 RID: 323 RVA: 0x0000CBE4 File Offset: 0x0000ADE4
		// (remove) Token: 0x06000144 RID: 324 RVA: 0x0000CC1C File Offset: 0x0000AE1C
		public event iTalk_CheckBox.CheckedChangedEventHandler CheckedChanged;

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000145 RID: 325 RVA: 0x0000CC51 File Offset: 0x0000AE51
		// (set) Token: 0x06000146 RID: 326 RVA: 0x0000CC59 File Offset: 0x0000AE59
		public bool Checked
		{
			get
			{
				return this._Checked;
			}
			set
			{
				this._Checked = value;
				if (this.CheckedChanged != null)
				{
					this.CheckedChanged(this);
				}
				base.Invalidate();
			}
		}

		// Token: 0x06000147 RID: 327 RVA: 0x0000CC7C File Offset: 0x0000AE7C
		public iTalk_CheckBox()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.BackColor = Color.Transparent;
			this.DoubleBuffered = true;
			this.Font = new Font("Segoe UI", 10f);
			base.Size = new Size(120, 26);
		}

		// Token: 0x06000148 RID: 328 RVA: 0x0000CCD1 File Offset: 0x0000AED1
		protected override void OnClick(EventArgs e)
		{
			this._Checked = !this._Checked;
			if (this.CheckedChanged != null)
			{
				this.CheckedChanged(this);
			}
			base.Invalidate();
			base.OnClick(e);
		}

		// Token: 0x06000149 RID: 329 RVA: 0x0000CD03 File Offset: 0x0000AF03
		protected override void OnTextChanged(EventArgs e)
		{
			base.Invalidate();
			base.OnTextChanged(e);
		}

		// Token: 0x0600014A RID: 330 RVA: 0x0000CD14 File Offset: 0x0000AF14
		protected override void OnResize(EventArgs e)
		{
			if (base.Width > 0 && base.Height > 0)
			{
				this.Shape = new GraphicsPath();
				this.R1 = new Rectangle(17, 0, base.Width, base.Height + 1);
				this.R2 = new Rectangle(0, 0, base.Width, base.Height);
				this.GB = new LinearGradientBrush(new Rectangle(0, 0, 25, 25), Color.FromArgb(250, 250, 250), Color.FromArgb(240, 240, 240), 90f);
				GraphicsPath shape = this.Shape;
				shape.AddArc(0, 0, 7, 7, 180f, 90f);
				shape.AddArc(7, 0, 7, 7, -90f, 90f);
				shape.AddArc(7, 7, 7, 7, 0f, 90f);
				shape.AddArc(0, 7, 7, 7, 90f, 90f);
				shape.CloseAllFigures();
				base.Height = 15;
			}
			base.Invalidate();
			base.OnResize(e);
		}

		// Token: 0x0600014B RID: 331 RVA: 0x0000CE2C File Offset: 0x0000B02C
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Graphics graphics = e.Graphics;
			graphics.Clear(Color.FromArgb(246, 246, 246));
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			graphics.FillPath(this.GB, this.Shape);
			graphics.DrawPath(new Pen(Color.FromArgb(160, 160, 160)), this.Shape);
			graphics.DrawString(this.Text, this.Font, new SolidBrush(Color.FromArgb(142, 142, 142)), this.R1, new StringFormat
			{
				LineAlignment = StringAlignment.Center
			});
			if (this.Checked)
			{
				graphics.DrawString("ü", new Font("Wingdings", 14f), new SolidBrush(Color.FromArgb(142, 142, 142)), new Rectangle(-2, 1, base.Width, base.Height), new StringFormat
				{
					LineAlignment = StringAlignment.Center
				});
			}
			e.Dispose();
		}

		// Token: 0x040000C4 RID: 196
		private GraphicsPath Shape;

		// Token: 0x040000C5 RID: 197
		private LinearGradientBrush GB;

		// Token: 0x040000C6 RID: 198
		private Rectangle R1;

		// Token: 0x040000C7 RID: 199
		private Rectangle R2;

		// Token: 0x040000C8 RID: 200
		private bool _Checked;

		// Token: 0x02000035 RID: 53
		// (Invoke) Token: 0x060001D4 RID: 468
		public delegate void CheckedChangedEventHandler(object sender);
	}
}
