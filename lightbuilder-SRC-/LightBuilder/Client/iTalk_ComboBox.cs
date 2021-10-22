using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Client
{
	// Token: 0x02000022 RID: 34
	internal class iTalk_ComboBox : ComboBox
	{
		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000160 RID: 352 RVA: 0x0000D465 File Offset: 0x0000B665
		// (set) Token: 0x06000161 RID: 353 RVA: 0x0000D470 File Offset: 0x0000B670
		public int StartIndex
		{
			get
			{
				return this._StartIndex;
			}
			set
			{
				this._StartIndex = value;
				try
				{
					base.SelectedIndex = value;
				}
				catch
				{
				}
				base.Invalidate();
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000162 RID: 354 RVA: 0x0000D4A8 File Offset: 0x0000B6A8
		// (set) Token: 0x06000163 RID: 355 RVA: 0x0000D4B0 File Offset: 0x0000B6B0
		public Color HoverSelectionColor
		{
			get
			{
				return this._HoverSelectionColor;
			}
			set
			{
				this._HoverSelectionColor = value;
				base.Invalidate();
			}
		}

		// Token: 0x06000164 RID: 356 RVA: 0x0000D4C0 File Offset: 0x0000B6C0
		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
			{
				e.Graphics.FillRectangle(new SolidBrush(this._HoverSelectionColor), e.Bounds);
			}
			else
			{
				e.Graphics.FillRectangle(Brushes.White, e.Bounds);
			}
			if (e.Index != -1)
			{
				e.Graphics.DrawString(base.GetItemText(base.Items[e.Index]), e.Font, Brushes.DimGray, e.Bounds);
			}
		}

		// Token: 0x06000165 RID: 357 RVA: 0x0000D54D File Offset: 0x0000B74D
		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
			base.SuspendLayout();
			base.Update();
			base.ResumeLayout();
		}

		// Token: 0x06000166 RID: 358 RVA: 0x0000D568 File Offset: 0x0000B768
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);
		}

		// Token: 0x06000167 RID: 359 RVA: 0x0000D574 File Offset: 0x0000B774
		public iTalk_ComboBox()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.Opaque | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.SetStyle(ControlStyles.Selectable, false);
			base.DrawMode = DrawMode.OwnerDrawFixed;
			base.DropDownStyle = ComboBoxStyle.DropDownList;
			this.BackColor = Color.FromArgb(246, 246, 246);
			this.ForeColor = Color.FromArgb(142, 142, 142);
			base.Size = new Size(135, 26);
			base.ItemHeight = 20;
			base.DropDownHeight = 100;
			this.Font = new Font("Segoe UI", 10f, FontStyle.Regular);
		}

		// Token: 0x06000168 RID: 360 RVA: 0x0000D634 File Offset: 0x0000B834
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			e.Graphics.Clear(this.BackColor);
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			GraphicsPath graphicsPath = RoundRectangle.RoundRect(0, 0, base.Width - 1, base.Height - 1, 5);
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(base.ClientRectangle, Color.FromArgb(241, 241, 241), Color.FromArgb(241, 241, 241), 90f);
			e.Graphics.SetClip(graphicsPath);
			e.Graphics.FillRectangle(linearGradientBrush, base.ClientRectangle);
			e.Graphics.ResetClip();
			e.Graphics.DrawPath(new Pen(Color.FromArgb(204, 204, 204)), graphicsPath);
			e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(Color.FromArgb(142, 142, 142)), new Rectangle(3, 0, base.Width - 20, base.Height), new StringFormat
			{
				LineAlignment = StringAlignment.Center,
				Alignment = StringAlignment.Near
			});
			e.Graphics.DrawLine(new Pen(Color.FromArgb(160, 160, 160), 2f), new Point(base.Width - 18, 10), new Point(base.Width - 14, 14));
			e.Graphics.DrawLine(new Pen(Color.FromArgb(160, 160, 160), 2f), new Point(base.Width - 14, 14), new Point(base.Width - 10, 10));
			e.Graphics.DrawLine(new Pen(Color.FromArgb(160, 160, 160)), new Point(base.Width - 14, 15), new Point(base.Width - 14, 14));
			graphicsPath.Dispose();
			linearGradientBrush.Dispose();
		}

		// Token: 0x040000CE RID: 206
		private int _StartIndex;

		// Token: 0x040000CF RID: 207
		private Color _HoverSelectionColor = Color.FromArgb(241, 241, 241);
	}
}
