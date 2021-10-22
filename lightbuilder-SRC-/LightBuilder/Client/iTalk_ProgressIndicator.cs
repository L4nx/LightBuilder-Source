using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Client
{
	// Token: 0x02000025 RID: 37
	internal class iTalk_ProgressIndicator : Control
	{
		// Token: 0x17000065 RID: 101
		// (get) Token: 0x0600017D RID: 381 RVA: 0x0000DCD8 File Offset: 0x0000BED8
		// (set) Token: 0x0600017E RID: 382 RVA: 0x0000DCE5 File Offset: 0x0000BEE5
		public Color P_BaseColor
		{
			get
			{
				return this.BaseColor.Color;
			}
			set
			{
				this.BaseColor.Color = value;
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x0600017F RID: 383 RVA: 0x0000DCF3 File Offset: 0x0000BEF3
		// (set) Token: 0x06000180 RID: 384 RVA: 0x0000DD00 File Offset: 0x0000BF00
		public Color P_AnimationColor
		{
			get
			{
				return this.AnimationColor.Color;
			}
			set
			{
				this.AnimationColor.Color = value;
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000181 RID: 385 RVA: 0x0000DD0E File Offset: 0x0000BF0E
		// (set) Token: 0x06000182 RID: 386 RVA: 0x0000DD1B File Offset: 0x0000BF1B
		public int P_AnimationSpeed
		{
			get
			{
				return this.AnimationSpeed.Interval;
			}
			set
			{
				this.AnimationSpeed.Interval = value;
			}
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0000DD29 File Offset: 0x0000BF29
		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			this.SetStandardSize();
			this.UpdateGraphics();
			this.SetPoints();
		}

		// Token: 0x06000184 RID: 388 RVA: 0x0000DD44 File Offset: 0x0000BF44
		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);
			this.AnimationSpeed.Enabled = base.Enabled;
		}

		// Token: 0x06000185 RID: 389 RVA: 0x0000DD5E File Offset: 0x0000BF5E
		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			this.AnimationSpeed.Tick += this.AnimationSpeed_Tick;
			this.AnimationSpeed.Start();
		}

		// Token: 0x06000186 RID: 390 RVA: 0x0000DD89 File Offset: 0x0000BF89
		private void AnimationSpeed_Tick(object sender, EventArgs e)
		{
			if (this.IndicatorIndex.Equals(0))
			{
				this.IndicatorIndex = this.FloatPoint.Length - 1;
			}
			else
			{
				this.IndicatorIndex--;
			}
			base.Invalidate(false);
		}

		// Token: 0x06000187 RID: 391 RVA: 0x0000DDC0 File Offset: 0x0000BFC0
		public iTalk_ProgressIndicator()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.Size = new Size(80, 80);
			this.Text = string.Empty;
			this.MinimumSize = new Size(80, 80);
			this.SetPoints();
			this.AnimationSpeed.Interval = 100;
		}

		// Token: 0x06000188 RID: 392 RVA: 0x0000DE54 File Offset: 0x0000C054
		private void SetStandardSize()
		{
			int num = Math.Max(base.Width, base.Height);
			base.Size = new Size(num, num);
		}

		// Token: 0x06000189 RID: 393 RVA: 0x0000DE80 File Offset: 0x0000C080
		private void SetPoints()
		{
			Stack<PointF> stack = new Stack<PointF>();
			PointF startingFloatPoint = new PointF((float)base.Width / 2f, (float)base.Height / 2f);
			for (float num = 0f; num < 360f; num += 45f)
			{
				this.SetValue(startingFloatPoint, (int)Math.Round((double)base.Width / 2.0 - 15.0), (double)num);
				PointF endPoint = this.EndPoint;
				endPoint = new PointF(endPoint.X - 7.5f, endPoint.Y - 7.5f);
				stack.Push(endPoint);
			}
			this.FloatPoint = stack.ToArray();
		}

		// Token: 0x0600018A RID: 394 RVA: 0x0000DF34 File Offset: 0x0000C134
		private void UpdateGraphics()
		{
			if (base.Width > 0 && base.Height > 0)
			{
				Size maximumBuffer = new Size(base.Width + 1, base.Height + 1);
				this.GraphicsContext.MaximumBuffer = maximumBuffer;
				this.BuffGraphics = this.GraphicsContext.Allocate(base.CreateGraphics(), base.ClientRectangle);
				this.BuffGraphics.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			}
		}

		// Token: 0x0600018B RID: 395 RVA: 0x0000DFA4 File Offset: 0x0000C1A4
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			this.BuffGraphics.Graphics.Clear(this.BackColor);
			int num = this.FloatPoint.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				if (this.IndicatorIndex == i)
				{
					this.BuffGraphics.Graphics.FillEllipse(this.AnimationColor, this.FloatPoint[i].X, this.FloatPoint[i].Y, 15f, 15f);
				}
				else
				{
					this.BuffGraphics.Graphics.FillEllipse(this.BaseColor, this.FloatPoint[i].X, this.FloatPoint[i].Y, 15f, 15f);
				}
			}
			this.BuffGraphics.Render(e.Graphics);
		}

		// Token: 0x0600018C RID: 396 RVA: 0x0000E08B File Offset: 0x0000C28B
		private X AssignValues<X>(ref X Run, X Length)
		{
			Run = Length;
			return Length;
		}

		// Token: 0x0600018D RID: 397 RVA: 0x0000E098 File Offset: 0x0000C298
		private void SetValue(PointF StartingFloatPoint, int Length, double Angle)
		{
			double num = 3.141592653589793 * Angle / 180.0;
			this._StartingFloatPoint = StartingFloatPoint;
			this.Rise = this.AssignValues<double>(ref this.Run, (double)Length);
			this.Rise = Math.Sin(num) * this.Rise;
			this.Run = Math.Cos(num) * this.Run;
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x0600018E RID: 398 RVA: 0x0000E0FC File Offset: 0x0000C2FC
		private PointF EndPoint
		{
			get
			{
				float y = Convert.ToSingle((double)this._StartingFloatPoint.Y + this.Rise);
				return new PointF(Convert.ToSingle((double)this._StartingFloatPoint.X + this.Run), y);
			}
		}

		// Token: 0x040000D5 RID: 213
		private readonly SolidBrush BaseColor = new SolidBrush(Color.DarkGray);

		// Token: 0x040000D6 RID: 214
		private readonly SolidBrush AnimationColor = new SolidBrush(Color.DimGray);

		// Token: 0x040000D7 RID: 215
		private readonly Timer AnimationSpeed = new Timer();

		// Token: 0x040000D8 RID: 216
		private PointF[] FloatPoint;

		// Token: 0x040000D9 RID: 217
		private BufferedGraphics BuffGraphics;

		// Token: 0x040000DA RID: 218
		private int IndicatorIndex;

		// Token: 0x040000DB RID: 219
		private readonly BufferedGraphicsContext GraphicsContext = BufferedGraphicsManager.Current;

		// Token: 0x040000DC RID: 220
		private double Rise;

		// Token: 0x040000DD RID: 221
		private double Run;

		// Token: 0x040000DE RID: 222
		private PointF _StartingFloatPoint;
	}
}
