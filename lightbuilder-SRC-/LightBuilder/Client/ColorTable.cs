using System;
using System.Drawing;

namespace Client
{
	// Token: 0x02000008 RID: 8
	public abstract class ColorTable
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600004E RID: 78
		public abstract xColorTable CommonColorTable { get; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600004F RID: 79
		public abstract Color BackgroundTopGradient { get; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000050 RID: 80
		public abstract Color BackgroundBottomGradient { get; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000051 RID: 81
		public abstract Color DroppedDownItemBackground { get; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000052 RID: 82
		public abstract Color DropdownTopGradient { get; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000053 RID: 83
		public abstract Color DropdownBottomGradient { get; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000054 RID: 84
		public abstract Color Separator { get; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000055 RID: 85
		public abstract Color ImageMargin { get; }
	}
}
