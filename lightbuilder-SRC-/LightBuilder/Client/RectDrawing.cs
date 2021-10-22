using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Client
{
	// Token: 0x0200000C RID: 12
	public class RectDrawing
	{
		// Token: 0x0600007E RID: 126 RVA: 0x00008124 File Offset: 0x00006324
		public static void DrawSelection(Graphics G, xColorTable ColorTable, Rectangle Rect)
		{
			Rectangle rect = default(Rectangle);
			Rectangle rect2 = default(Rectangle);
			Rectangle rectangle = new Rectangle(Rect.X + 1, Rect.Y + 1, Rect.Width - 1, Rect.Height - 1);
			rect = rectangle;
			rect.Height -= Convert.ToInt32(rect.Height / 2);
			rect2 = new Rectangle(rect.X, rect.Bottom, rect.Width, rectangle.Height - rect.Height);
			using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, ColorTable.SelectionTopGradient, ColorTable.SelectionMidGradient, LinearGradientMode.Vertical))
			{
				G.FillRectangle(linearGradientBrush, rect);
			}
			using (SolidBrush solidBrush = new SolidBrush(ColorTable.SelectionBottomGradient))
			{
				G.FillRectangle(solidBrush, rect2);
			}
			using (Pen pen = new Pen(ColorTable.SelectionBorder))
			{
				RectDrawing.DrawRoundedRectangle(G, pen, Convert.ToSingle(Rect.X), Convert.ToSingle(Rect.Y), Convert.ToSingle(Rect.Width), Convert.ToSingle(Rect.Height), 2f);
			}
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00008284 File Offset: 0x00006484
		public static void DrawRoundedRectangle(Graphics G, Pen P, float X, float Y, float W, float H, float Rad)
		{
			using (GraphicsPath graphicsPath = new GraphicsPath())
			{
				graphicsPath.AddLine(X + Rad, Y, X + W - Rad * 2f, Y);
				graphicsPath.AddArc(X + W - Rad * 2f, Y, Rad * 2f, Rad * 2f, 270f, 90f);
				graphicsPath.AddLine(X + W, Y + Rad, X + W, Y + H - Rad * 2f);
				graphicsPath.AddArc(X + W - Rad * 2f, Y + H - Rad * 2f, Rad * 2f, Rad * 2f, 0f, 90f);
				graphicsPath.AddLine(X + W - Rad * 2f, Y + H, X + Rad, Y + H);
				graphicsPath.AddArc(X, Y + H - Rad * 2f, Rad * 2f, Rad * 2f, 90f, 90f);
				graphicsPath.AddLine(X, Y + H - Rad * 2f, X, Y + Rad);
				graphicsPath.AddArc(X, Y, Rad * 2f, Rad * 2f, 180f, 90f);
				graphicsPath.CloseFigure();
				G.SmoothingMode = SmoothingMode.AntiAlias;
				G.DrawPath(P, graphicsPath);
				G.SmoothingMode = SmoothingMode.Default;
			}
		}
	}
}
