using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Client
{
	// Token: 0x0200000D RID: 13
	public class iTalk_ThemeContainer : ContainerControl
	{
		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000081 RID: 129 RVA: 0x0000840C File Offset: 0x0000660C
		// (set) Token: 0x06000082 RID: 130 RVA: 0x00008414 File Offset: 0x00006614
		public bool Sizable
		{
			get
			{
				return this._Sizable;
			}
			set
			{
				this._Sizable = value;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000083 RID: 131 RVA: 0x0000841D File Offset: 0x0000661D
		// (set) Token: 0x06000084 RID: 132 RVA: 0x00008425 File Offset: 0x00006625
		public bool SmartBounds
		{
			get
			{
				return this._SmartBounds;
			}
			set
			{
				this._SmartBounds = value;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000085 RID: 133 RVA: 0x0000842E File Offset: 0x0000662E
		protected bool IsParentForm
		{
			get
			{
				return this._IsParentForm;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000086 RID: 134 RVA: 0x00008436 File Offset: 0x00006636
		protected bool IsParentMdi
		{
			get
			{
				return base.Parent != null && base.Parent.Parent != null;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000087 RID: 135 RVA: 0x00008450 File Offset: 0x00006650
		// (set) Token: 0x06000088 RID: 136 RVA: 0x00008458 File Offset: 0x00006658
		protected bool ControlMode
		{
			get
			{
				return this._ControlMode;
			}
			set
			{
				this._ControlMode = value;
				base.Invalidate();
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000089 RID: 137 RVA: 0x00008467 File Offset: 0x00006667
		// (set) Token: 0x0600008A RID: 138 RVA: 0x0000848B File Offset: 0x0000668B
		public FormStartPosition StartPosition
		{
			get
			{
				if (this._IsParentForm && !this._ControlMode)
				{
					return base.ParentForm.StartPosition;
				}
				return this._StartPosition;
			}
			set
			{
				this._StartPosition = value;
				if (this._IsParentForm && !this._ControlMode)
				{
					base.ParentForm.StartPosition = value;
				}
			}
		}

		// Token: 0x0600008B RID: 139 RVA: 0x000084B0 File Offset: 0x000066B0
		protected sealed override void OnParentChanged(EventArgs e)
		{
			base.OnParentChanged(e);
			if (base.Parent == null)
			{
				return;
			}
			this._IsParentForm = (base.Parent is Form);
			if (!this._ControlMode)
			{
				this.InitializeMessages();
				if (this._IsParentForm)
				{
					base.ParentForm.FormBorderStyle = FormBorderStyle.None;
					base.ParentForm.TransparencyKey = Color.Fuchsia;
					if (!base.DesignMode)
					{
						base.ParentForm.Shown += this.FormShown;
					}
				}
				base.Parent.BackColor = this.BackColor;
				base.Parent.MinimumSize = new Size(126, 39);
			}
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00008557 File Offset: 0x00006757
		protected sealed override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			if (!this._ControlMode)
			{
				this.HeaderRect = new Rectangle(0, 0, base.Width - 14, this.MoveHeight - 7);
			}
			base.Invalidate();
		}

		// Token: 0x0600008D RID: 141 RVA: 0x0000858C File Offset: 0x0000678C
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (e.Button == MouseButtons.Left)
			{
				this.SetState(iTalk_ThemeContainer.MouseState.Down);
			}
			if ((!this._IsParentForm || base.ParentForm.WindowState != FormWindowState.Maximized) && !this._ControlMode)
			{
				if (this.HeaderRect.Contains(e.Location))
				{
					base.Capture = false;
					this.WM_LMBUTTONDOWN = true;
					this.DefWndProc(ref this.Messages[0]);
					return;
				}
				if (this._Sizable && this.Previous != 0)
				{
					base.Capture = false;
					this.WM_LMBUTTONDOWN = true;
					this.DefWndProc(ref this.Messages[this.Previous]);
				}
			}
		}

		// Token: 0x0600008E RID: 142 RVA: 0x0000863B File Offset: 0x0000683B
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.Cap = false;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x0000864C File Offset: 0x0000684C
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if ((!this._IsParentForm || base.ParentForm.WindowState != FormWindowState.Maximized) && this._Sizable && !this._ControlMode)
			{
				this.InvalidateMouse();
			}
			if (this.Cap)
			{
				base.Parent.Location = (Point)(Convert.ToDouble(Control.MousePosition) - Convert.ToDouble(this.MouseP));
			}
		}

		// Token: 0x06000090 RID: 144 RVA: 0x000086C9 File Offset: 0x000068C9
		protected override void OnInvalidated(InvalidateEventArgs e)
		{
			base.OnInvalidated(e);
			base.ParentForm.Text = this.Text;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x000086E3 File Offset: 0x000068E3
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000086EC File Offset: 0x000068EC
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			base.Invalidate();
		}

		// Token: 0x06000093 RID: 147 RVA: 0x000086FC File Offset: 0x000068FC
		private void FormShown(object sender, EventArgs e)
		{
			if (this._ControlMode || this.HasShown)
			{
				return;
			}
			if (this._StartPosition == FormStartPosition.CenterParent || this._StartPosition == FormStartPosition.CenterScreen)
			{
				Rectangle bounds = Screen.PrimaryScreen.Bounds;
				Rectangle bounds2 = base.ParentForm.Bounds;
				base.ParentForm.Location = new Point(bounds.Width / 2 - bounds2.Width / 2, bounds.Height / 2 - bounds2.Width / 2);
			}
			this.HasShown = true;
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00008780 File Offset: 0x00006980
		private void SetState(iTalk_ThemeContainer.MouseState current)
		{
			this.State = current;
			base.Invalidate();
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00008790 File Offset: 0x00006990
		private int GetIndex()
		{
			this.GetIndexPoint = base.PointToClient(Control.MousePosition);
			this.B1x = (this.GetIndexPoint.X < 7);
			this.B2x = (this.GetIndexPoint.X > base.Width - 7);
			this.B3 = (this.GetIndexPoint.Y < 7);
			this.B4 = (this.GetIndexPoint.Y > base.Height - 7);
			if (this.B1x && this.B3)
			{
				return 4;
			}
			if (this.B1x && this.B4)
			{
				return 7;
			}
			if (this.B2x && this.B3)
			{
				return 5;
			}
			if (this.B2x && this.B4)
			{
				return 8;
			}
			if (this.B1x)
			{
				return 1;
			}
			if (this.B2x)
			{
				return 2;
			}
			if (this.B3)
			{
				return 3;
			}
			if (this.B4)
			{
				return 6;
			}
			return 0;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00008880 File Offset: 0x00006A80
		private void InvalidateMouse()
		{
			this.Current = this.GetIndex();
			if (this.Current == this.Previous)
			{
				return;
			}
			this.Previous = this.Current;
			int previous = this.Previous;
			if (previous == 0)
			{
				this.Cursor = Cursors.Default;
				return;
			}
			switch (previous)
			{
			case 6:
				this.Cursor = Cursors.SizeNS;
				return;
			case 7:
				this.Cursor = Cursors.SizeNESW;
				return;
			case 8:
				this.Cursor = Cursors.SizeNWSE;
				return;
			default:
				return;
			}
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00008904 File Offset: 0x00006B04
		private void InitializeMessages()
		{
			this.Messages[0] = Message.Create(base.Parent.Handle, 161, new IntPtr(2), IntPtr.Zero);
			for (int i = 1; i <= 8; i++)
			{
				this.Messages[i] = Message.Create(base.Parent.Handle, 161, new IntPtr(i + 9), IntPtr.Zero);
			}
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00008978 File Offset: 0x00006B78
		private void CorrectBounds(Rectangle bounds)
		{
			if (base.Parent.Width > bounds.Width)
			{
				base.Parent.Width = bounds.Width;
			}
			if (base.Parent.Height > bounds.Height)
			{
				base.Parent.Height = bounds.Height;
			}
			int num = base.Parent.Location.X;
			int num2 = base.Parent.Location.Y;
			if (num < bounds.X)
			{
				num = bounds.X;
			}
			if (num2 < bounds.Y)
			{
				num2 = bounds.Y;
			}
			int num3 = bounds.X + bounds.Width;
			int num4 = bounds.Y + bounds.Height;
			if (num + base.Parent.Width > num3)
			{
				num = num3 - base.Parent.Width;
			}
			if (num2 + base.Parent.Height > num4)
			{
				num2 = num4 - base.Parent.Height;
			}
			base.Parent.Location = new Point(num, num2);
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00008A90 File Offset: 0x00006C90
		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);
			if (this.WM_LMBUTTONDOWN && m.Msg == 513)
			{
				this.WM_LMBUTTONDOWN = false;
				this.SetState(iTalk_ThemeContainer.MouseState.Over);
				if (!this._SmartBounds)
				{
					return;
				}
				if (this.IsParentMdi)
				{
					this.CorrectBounds(new Rectangle(Point.Empty, base.Parent.Parent.Size));
					return;
				}
				this.CorrectBounds(Screen.FromControl(base.Parent).WorkingArea);
			}
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00008B0F File Offset: 0x00006D0F
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			base.ParentForm.FormBorderStyle = FormBorderStyle.None;
			base.ParentForm.TransparencyKey = Color.Fuchsia;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00008B33 File Offset: 0x00006D33
		protected override void CreateHandle()
		{
			base.CreateHandle();
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00008B3C File Offset: 0x00006D3C
		public iTalk_ThemeContainer()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.Opaque | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.Dock = DockStyle.Fill;
			this.MoveHeight = 25;
			base.Padding = new Padding(3, 28, 3, 28);
			this.Font = new Font("Segoe UI", 8f, FontStyle.Regular);
			this.ForeColor = Color.FromArgb(142, 142, 142);
			this.BackColor = Color.FromArgb(246, 246, 246);
			this.DoubleBuffered = true;
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00008BF0 File Offset: 0x00006DF0
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			Rectangle rectangle = new Rectangle(0, 0, base.Width - 1, base.Height - 1);
			Color transparencyKey = base.ParentForm.TransparencyKey;
			graphics.SmoothingMode = SmoothingMode.Default;
			graphics.Clear(transparencyKey);
			graphics.FillPath(new SolidBrush(Color.FromArgb(15, 71, 0)), RoundRectangle.RoundRect(rectangle, 7));
			graphics.FillPath(new SolidBrush(Color.FromArgb(246, 246, 246)), RoundRectangle.RoundRect(new Rectangle(2, 20, base.Width - 5, base.Height - 42), 7));
			graphics.FillPath(new SolidBrush(Color.FromArgb(15, 71, 0)), RoundRectangle.RoundRect(new Rectangle(2, 2, base.Width / 2 + 2, 16), 7));
			graphics.FillPath(new SolidBrush(Color.FromArgb(15, 71, 0)), RoundRectangle.RoundRect(new Rectangle(base.Width / 2 - 3, 2, base.Width / 2, 16), 7));
			graphics.FillRectangle(new SolidBrush(Color.FromArgb(15, 71, 0)), new Rectangle(2, 15, base.Width - 5, 10));
			graphics.DrawPath(new Pen(Color.FromArgb(15, 71, 0)), RoundRectangle.RoundRect(new Rectangle(2, 2, base.Width - 5, base.Height - 5), 7));
			graphics.DrawPath(new Pen(Color.FromArgb(15, 71, 0)), RoundRectangle.RoundRect(rectangle, 7));
			graphics.DrawString(this.Text, new Font("Trebuchet MS", 10f, FontStyle.Bold), new SolidBrush(Color.FromArgb(234, 255, 34)), new Rectangle(7, 3, base.Width - 1, 22), new StringFormat
			{
				Alignment = StringAlignment.Center,
				LineAlignment = StringAlignment.Near
			});
			graphics.FillRectangle(new SolidBrush(Color.FromArgb(15, 71, 0)), 0, base.Height - 25, base.Width - 3, 20);
			graphics.DrawLine(new Pen(Color.FromArgb(15, 71, 0)), 5, base.Height - 5, base.Width - 6, base.Height - 5);
			graphics.DrawLine(new Pen(Color.FromArgb(15, 71, 0)), 7, base.Height - 4, base.Width - 7, base.Height - 4);
			graphics.DrawString(this._TextBottom, new Font("Trebuchet MS", 10f, FontStyle.Bold), new SolidBrush(Color.FromArgb(221, 221, 221)), 5f, (float)(base.Height - 23));
			e.Graphics.DrawImage((Image)bitmap.Clone(), 0, 0);
			graphics.Dispose();
			bitmap.Dispose();
		}

		// Token: 0x0400005E RID: 94
		private Point MouseP = new Point(0, 0);

		// Token: 0x0400005F RID: 95
		private bool Cap;

		// Token: 0x04000060 RID: 96
		private int MoveHeight;

		// Token: 0x04000061 RID: 97
		private string _TextBottom;

		// Token: 0x04000062 RID: 98
		private const int BorderCurve = 7;

		// Token: 0x04000063 RID: 99
		protected iTalk_ThemeContainer.MouseState State;

		// Token: 0x04000064 RID: 100
		private bool HasShown;

		// Token: 0x04000065 RID: 101
		private Rectangle HeaderRect;

		// Token: 0x04000066 RID: 102
		private bool _Sizable = true;

		// Token: 0x04000067 RID: 103
		private bool _SmartBounds;

		// Token: 0x04000068 RID: 104
		private bool _IsParentForm;

		// Token: 0x04000069 RID: 105
		private bool _ControlMode;

		// Token: 0x0400006A RID: 106
		private FormStartPosition _StartPosition;

		// Token: 0x0400006B RID: 107
		private Point GetIndexPoint;

		// Token: 0x0400006C RID: 108
		private bool B1x;

		// Token: 0x0400006D RID: 109
		private bool B2x;

		// Token: 0x0400006E RID: 110
		private bool B3;

		// Token: 0x0400006F RID: 111
		private bool B4;

		// Token: 0x04000070 RID: 112
		private int Current;

		// Token: 0x04000071 RID: 113
		private int Previous;

		// Token: 0x04000072 RID: 114
		private Message[] Messages = new Message[9];

		// Token: 0x04000073 RID: 115
		private bool WM_LMBUTTONDOWN;

		// Token: 0x0200002F RID: 47
		public enum MouseState
		{
			// Token: 0x040000F9 RID: 249
			None,
			// Token: 0x040000FA RID: 250
			Over,
			// Token: 0x040000FB RID: 251
			Down
		}
	}
}
