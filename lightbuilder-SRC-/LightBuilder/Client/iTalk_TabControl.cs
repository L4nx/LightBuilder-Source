﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Client
{
	// Token: 0x02000026 RID: 38
	internal class iTalk_TabControl : TabControl
	{
		// Token: 0x0600018F RID: 399 RVA: 0x0000E140 File Offset: 0x0000C340
		public iTalk_TabControl()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
			this.DoubleBuffered = true;
			base.SizeMode = TabSizeMode.Fixed;
			base.ItemSize = new Size(44, 135);
			base.DrawMode = TabDrawMode.OwnerDrawFixed;
			foreach (object obj in base.TabPages)
			{
				((TabPage)obj).BackColor = Color.FromArgb(246, 246, 246);
			}
		}

		// Token: 0x06000190 RID: 400 RVA: 0x0000E1E4 File Offset: 0x0000C3E4
		protected override void CreateHandle()
		{
			base.CreateHandle();
			base.DoubleBuffered = true;
			base.SizeMode = TabSizeMode.Fixed;
			base.Appearance = TabAppearance.Normal;
			base.Alignment = TabAlignment.Left;
		}

		// Token: 0x06000191 RID: 401 RVA: 0x0000E208 File Offset: 0x0000C408
		protected override void OnControlAdded(ControlEventArgs e)
		{
			base.OnControlAdded(e);
			if (e.Control is TabPage)
			{
				try
				{
					foreach (object obj in base.Controls)
					{
						TabPage tabPage = (TabPage)obj;
						new TabPage();
					}
				}
				finally
				{
					e.Control.BackColor = Color.FromArgb(246, 246, 246);
				}
			}
		}

		// Token: 0x06000192 RID: 402 RVA: 0x0000E284 File Offset: 0x0000C484
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			Graphics graphics2 = graphics;
			graphics2.Clear(Color.FromArgb(5, 12, 43));
			graphics2.SmoothingMode = SmoothingMode.HighSpeed;
			graphics2.CompositingQuality = CompositingQuality.HighSpeed;
			graphics2.CompositingMode = CompositingMode.SourceOver;
			graphics2.FillRectangle(new SolidBrush(Color.FromArgb(2, 6, 15)), new Rectangle(-5, 0, base.ItemSize.Height + 4, base.Height));
			graphics2.DrawLine(new Pen(Color.FromArgb(44, 46, 51)), base.ItemSize.Height - 1, 0, base.ItemSize.Height - 1, base.Height);
			for (int i = 0; i <= base.TabCount - 1; i++)
			{
				if (i == base.SelectedIndex)
				{
					Rectangle rectangle = new Rectangle(new Point(base.GetTabRect(i).Location.X - 2, base.GetTabRect(i).Location.Y - 2), new Size(base.GetTabRect(i).Width + 3, base.GetTabRect(i).Height - 8));
					graphics2.FillRectangle(new SolidBrush(Color.FromArgb(8, 11, 18)), rectangle.X, rectangle.Y, rectangle.Width - 4, rectangle.Height + 3);
					Rectangle rect = new Rectangle(new Point(base.GetTabRect(i).X - 2, base.GetTabRect(i).Location.Y - ((i == 0) ? 1 : 1)), new Size(4, base.GetTabRect(i).Height - 7));
					graphics2.FillRectangle(new SolidBrush(Color.FromArgb(0, 255, 0)), rect);
					graphics2.DrawString(base.TabPages[i].Text, new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold), new SolidBrush(Color.FromArgb(254, 255, 255)), new Rectangle(rectangle.Left + 40, rectangle.Top + 12, rectangle.Width - 40, rectangle.Height), new StringFormat
					{
						Alignment = StringAlignment.Near
					});
					if (base.ImageList != null && base.TabPages[i].ImageIndex != -1)
					{
						graphics2.DrawImage(base.ImageList.Images[base.TabPages[i].ImageIndex], rectangle.X + 9, rectangle.Y + 6, 24, 24);
					}
				}
				else
				{
					Rectangle rectangle2 = new Rectangle(new Point(base.GetTabRect(i).Location.X - 2, base.GetTabRect(i).Location.Y - 2), new Size(base.GetTabRect(i).Width + 3, base.GetTabRect(i).Height - 8));
					graphics2.DrawString(base.TabPages[i].Text, new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold), new SolidBrush(Color.FromArgb(159, 162, 167)), new Rectangle(rectangle2.Left + 40, rectangle2.Top + 12, rectangle2.Width - 40, rectangle2.Height), new StringFormat
					{
						Alignment = StringAlignment.Near
					});
					if (base.ImageList != null && base.TabPages[i].ImageIndex != -1)
					{
						graphics2.DrawImage(base.ImageList.Images[base.TabPages[i].ImageIndex], rectangle2.X + 9, rectangle2.Y + 6, 24, 24);
					}
				}
			}
			e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
			e.Graphics.DrawImage((Image)bitmap.Clone(), 0, 0);
			graphics.Dispose();
			bitmap.Dispose();
		}
	}
}
