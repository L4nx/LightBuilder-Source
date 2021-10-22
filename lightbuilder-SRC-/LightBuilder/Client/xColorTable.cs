using System;
using System.Drawing;

namespace Client
{
	// Token: 0x02000007 RID: 7
	public abstract class xColorTable
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000041 RID: 65
		public abstract Color TextColor { get; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000042 RID: 66
		public abstract Color Background { get; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000043 RID: 67
		public abstract Color SelectionBorder { get; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000044 RID: 68
		public abstract Color SelectionTopGradient { get; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000045 RID: 69
		public abstract Color SelectionMidGradient { get; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000046 RID: 70
		public abstract Color SelectionBottomGradient { get; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000047 RID: 71
		public abstract Color PressedBackground { get; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000048 RID: 72
		public abstract Color CheckedBackground { get; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000049 RID: 73
		public abstract Color CheckedSelectedBackground { get; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600004A RID: 74
		public abstract Color DropdownBorder { get; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600004B RID: 75
		public abstract Color Arrow { get; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600004C RID: 76
		public abstract Color OverflowBackground { get; }
	}
}
