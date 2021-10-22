using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Client
{
	// Token: 0x0200000B RID: 11
	public class ControlRenderer : ToolStripProfessionalRenderer
	{
		// Token: 0x0600006D RID: 109 RVA: 0x000073E9 File Offset: 0x000055E9
		public ControlRenderer() : this(new MSColorTable())
		{
		}

		// Token: 0x0600006E RID: 110 RVA: 0x000073F6 File Offset: 0x000055F6
		public ControlRenderer(ColorTable ColorTable)
		{
			this.ColorTable = ColorTable;
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x0600006F RID: 111 RVA: 0x00007405 File Offset: 0x00005605
		// (set) Token: 0x06000070 RID: 112 RVA: 0x00007420 File Offset: 0x00005620
		public new ColorTable ColorTable
		{
			get
			{
				if (this._ColorTable == null)
				{
					this._ColorTable = new MSColorTable();
				}
				return this._ColorTable;
			}
			set
			{
				this._ColorTable = value;
			}
		}

		// Token: 0x06000071 RID: 113 RVA: 0x0000742C File Offset: 0x0000562C
		protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
		{
			base.OnRenderToolStripBackground(e);
			using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(e.AffectedBounds, this.ColorTable.BackgroundTopGradient, this.ColorTable.BackgroundBottomGradient, LinearGradientMode.Vertical))
			{
				e.Graphics.FillRectangle(linearGradientBrush, e.AffectedBounds);
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00007494 File Offset: 0x00005694
		protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
		{
			if (e.ToolStrip.Parent == null)
			{
				Rectangle rect = new Rectangle(0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1);
				using (Pen pen = new Pen(this.ColorTable.CommonColorTable.DropdownBorder))
				{
					e.Graphics.DrawRectangle(pen, rect);
				}
				using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.DroppedDownItemBackground))
				{
					e.Graphics.FillRectangle(solidBrush, e.ConnectedArea);
				}
			}
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00007550 File Offset: 0x00005750
		protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
		{
			if (e.Item.Enabled)
			{
				if (e.Item.Selected)
				{
					if (!e.Item.IsOnDropDown)
					{
						Rectangle rect = new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1);
						RectDrawing.DrawSelection(e.Graphics, this.ColorTable.CommonColorTable, rect);
					}
					else
					{
						Rectangle rect2 = new Rectangle(2, 0, e.Item.Width - 4, e.Item.Height - 1);
						RectDrawing.DrawSelection(e.Graphics, this.ColorTable.CommonColorTable, rect2);
					}
				}
				if (((ToolStripMenuItem)e.Item).DropDown.Visible && !e.Item.IsOnDropDown)
				{
					Rectangle rectangle = new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height);
					Rectangle rect3 = new Rectangle(1, 1, e.Item.Width - 2, e.Item.Height + 2);
					using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.DroppedDownItemBackground))
					{
						e.Graphics.FillRectangle(solidBrush, rect3);
					}
					using (Pen pen = new Pen(this.ColorTable.CommonColorTable.DropdownBorder))
					{
						RectDrawing.DrawRoundedRectangle(e.Graphics, pen, Convert.ToSingle(rectangle.X), Convert.ToSingle(rectangle.Y), Convert.ToSingle(rectangle.Width), Convert.ToSingle(rectangle.Height), 2f);
					}
				}
				e.Item.ForeColor = this.ColorTable.CommonColorTable.TextColor;
			}
		}

		// Token: 0x06000074 RID: 116 RVA: 0x0000773C File Offset: 0x0000593C
		protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
		{
			e.TextColor = this.ColorTable.CommonColorTable.TextColor;
			base.OnRenderItemText(e);
		}

		// Token: 0x06000075 RID: 117 RVA: 0x0000775C File Offset: 0x0000595C
		protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
		{
			base.OnRenderItemCheck(e);
			Rectangle rect = new Rectangle(3, 1, e.Item.Height - 3, e.Item.Height - 3);
			Color color = default(Color);
			if (e.Item.Selected)
			{
				color = this.ColorTable.CommonColorTable.CheckedSelectedBackground;
			}
			else
			{
				color = this.ColorTable.CommonColorTable.CheckedBackground;
			}
			using (SolidBrush solidBrush = new SolidBrush(color))
			{
				e.Graphics.FillRectangle(solidBrush, rect);
			}
			using (Pen pen = new Pen(this.ColorTable.CommonColorTable.SelectionBorder))
			{
				e.Graphics.DrawRectangle(pen, rect);
			}
			e.Graphics.DrawString("ü", new Font("Wingdings", 13f, FontStyle.Regular), Brushes.Black, new Point(4, 2));
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00007868 File Offset: 0x00005A68
		protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
		{
			base.OnRenderSeparator(e);
			int x = 28;
			int x2 = Convert.ToInt32(e.Item.Width);
			int num = 3;
			using (Pen pen = new Pen(this.ColorTable.Separator))
			{
				e.Graphics.DrawLine(pen, x, num, x2, num);
			}
		}

		// Token: 0x06000077 RID: 119 RVA: 0x000078D0 File Offset: 0x00005AD0
		protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
		{
			base.OnRenderImageMargin(e);
			Rectangle rect = new Rectangle(0, -1, e.ToolStrip.Width, e.ToolStrip.Height + 1);
			using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, this.ColorTable.DropdownTopGradient, this.ColorTable.DropdownBottomGradient, LinearGradientMode.Vertical))
			{
				e.Graphics.FillRectangle(linearGradientBrush, rect);
			}
			using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.ImageMargin))
			{
				e.Graphics.FillRectangle(solidBrush, e.AffectedBounds);
			}
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00007988 File Offset: 0x00005B88
		protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
		{
			Rectangle rect = new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1);
			bool flag = Convert.ToBoolean(((ToolStripButton)e.Item).Checked);
			bool flag2 = false;
			if (flag)
			{
				flag2 = true;
				if (e.Item.Selected && !e.Item.Pressed)
				{
					using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.CommonColorTable.CheckedSelectedBackground))
					{
						e.Graphics.FillRectangle(solidBrush, rect);
						goto IL_121;
					}
				}
				using (SolidBrush solidBrush2 = new SolidBrush(this.ColorTable.CommonColorTable.CheckedBackground))
				{
					e.Graphics.FillRectangle(solidBrush2, rect);
					goto IL_121;
				}
			}
			if (e.Item.Pressed)
			{
				flag2 = true;
				using (SolidBrush solidBrush3 = new SolidBrush(this.ColorTable.CommonColorTable.PressedBackground))
				{
					e.Graphics.FillRectangle(solidBrush3, rect);
					goto IL_121;
				}
			}
			if (e.Item.Selected)
			{
				flag2 = true;
				RectDrawing.DrawSelection(e.Graphics, this.ColorTable.CommonColorTable, rect);
			}
			IL_121:
			if (flag2)
			{
				using (Pen pen = new Pen(this.ColorTable.CommonColorTable.SelectionBorder))
				{
					e.Graphics.DrawRectangle(pen, rect);
				}
			}
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00007B20 File Offset: 0x00005D20
		protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
		{
			Rectangle rect = new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1);
			bool flag = false;
			if (e.Item.Pressed)
			{
				flag = true;
				using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.CommonColorTable.PressedBackground))
				{
					e.Graphics.FillRectangle(solidBrush, rect);
					goto IL_89;
				}
			}
			if (e.Item.Selected)
			{
				flag = true;
				RectDrawing.DrawSelection(e.Graphics, this.ColorTable.CommonColorTable, rect);
			}
			IL_89:
			if (flag)
			{
				using (Pen pen = new Pen(this.ColorTable.CommonColorTable.SelectionBorder))
				{
					e.Graphics.DrawRectangle(pen, rect);
				}
			}
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00007C04 File Offset: 0x00005E04
		protected override void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e)
		{
			base.OnRenderSplitButtonBackground(e);
			bool flag = false;
			bool flag2 = true;
			ToolStripSplitButton toolStripSplitButton = (ToolStripSplitButton)e.Item;
			checked
			{
				Rectangle rect = new Rectangle(0, 0, toolStripSplitButton.ButtonBounds.Width - 1, toolStripSplitButton.ButtonBounds.Height - 1);
				Rectangle rect2 = new Rectangle(0, 0, toolStripSplitButton.Bounds.Width - 1, toolStripSplitButton.Bounds.Height - 1);
				if (toolStripSplitButton.DropDownButtonPressed)
				{
					flag = true;
					flag2 = false;
					using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.CommonColorTable.PressedBackground))
					{
						e.Graphics.FillRectangle(solidBrush, rect2);
						goto IL_D2;
					}
				}
				if (toolStripSplitButton.DropDownButtonSelected)
				{
					flag = true;
					RectDrawing.DrawSelection(e.Graphics, this.ColorTable.CommonColorTable, rect2);
				}
				IL_D2:
				if (toolStripSplitButton.ButtonPressed)
				{
					using (SolidBrush solidBrush2 = new SolidBrush(this.ColorTable.CommonColorTable.PressedBackground))
					{
						e.Graphics.FillRectangle(solidBrush2, rect);
					}
				}
				if (flag)
				{
					using (Pen pen = new Pen(this.ColorTable.CommonColorTable.SelectionBorder))
					{
						e.Graphics.DrawRectangle(pen, rect2);
						if (flag2)
						{
							e.Graphics.DrawRectangle(pen, rect);
						}
					}
					this.DrawCustomArrow(e.Graphics, toolStripSplitButton);
				}
			}
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00007DA4 File Offset: 0x00005FA4
		private void DrawCustomArrow(Graphics g, ToolStripSplitButton item)
		{
			int num = Convert.ToInt32(item.DropDownButtonBounds.Width - 1);
			int num2 = Convert.ToInt32(item.DropDownButtonBounds.Height - 1);
			float num3 = (float)num / 2f + 1f;
			float x = Convert.ToSingle((float)item.DropDownButtonBounds.Left + ((float)num - num3) / 2f);
			float num4 = num3 / 2f;
			float y = Convert.ToSingle((float)item.DropDownButtonBounds.Top + ((float)num2 - num4) / 2f + 1f);
			RectangleF value = new RectangleF(x, y, num3, num4);
			this.DrawCustomArrow(g, item, Rectangle.Round(value));
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00007E60 File Offset: 0x00006060
		private void DrawCustomArrow(Graphics g, ToolStripItem item, Rectangle rect)
		{
			ToolStripArrowRenderEventArgs e = new ToolStripArrowRenderEventArgs(g, item, rect, this.ColorTable.CommonColorTable.Arrow, ArrowDirection.Down);
			base.OnRenderArrow(e);
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00007E90 File Offset: 0x00006090
		protected override void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e)
		{
			Rectangle rect = default(Rectangle);
			Rectangle rectangle = default(Rectangle);
			rect = new Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 2);
			rectangle = new Rectangle(rect.X - 5, rect.Y, rect.Width - 5, rect.Height);
			if (e.Item.Pressed)
			{
				using (SolidBrush solidBrush = new SolidBrush(this.ColorTable.CommonColorTable.PressedBackground))
				{
					e.Graphics.FillRectangle(solidBrush, rect);
					goto IL_F3;
				}
			}
			if (e.Item.Selected)
			{
				RectDrawing.DrawSelection(e.Graphics, this.ColorTable.CommonColorTable, rect);
			}
			else
			{
				using (SolidBrush solidBrush2 = new SolidBrush(this.ColorTable.CommonColorTable.OverflowBackground))
				{
					e.Graphics.FillRectangle(solidBrush2, rect);
				}
			}
			IL_F3:
			using (Pen pen = new Pen(this.ColorTable.CommonColorTable.Background))
			{
				RectDrawing.DrawRoundedRectangle(e.Graphics, pen, Convert.ToSingle(rectangle.X), Convert.ToSingle(rectangle.Y), Convert.ToSingle(rectangle.Width), Convert.ToSingle(rectangle.Height), 3f);
			}
			int num = Convert.ToInt32(rect.Width - 1);
			int num2 = Convert.ToInt32(rect.Height - 1);
			float num3 = (float)num / 2f + 1f;
			float num4 = Convert.ToSingle((float)rect.Left + ((float)num - num3) / 2f + 3f);
			float num5 = num3 / 2f;
			float num6 = Convert.ToSingle((float)rect.Top + ((float)num2 - num5) / 2f + 7f);
			RectangleF value = new RectangleF(num4, num6, num3, num5);
			this.DrawCustomArrow(e.Graphics, e.Item, Rectangle.Round(value));
			using (Pen pen2 = new Pen(this.ColorTable.CommonColorTable.Arrow))
			{
				e.Graphics.DrawLine(pen2, num4 + 2f, num6 - 2f, num4 + num3 - 2f, num6 - 2f);
			}
		}

		// Token: 0x0400005D RID: 93
		private ColorTable _ColorTable;
	}
}
