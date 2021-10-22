using System;
using System.Drawing;

namespace Client
{
	// Token: 0x02000009 RID: 9
	public class MSColorTable : ColorTable
	{
		// Token: 0x06000057 RID: 87 RVA: 0x0000724B File Offset: 0x0000544B
		public MSColorTable()
		{
			this._CommonColorTable = new DefaultCColorTable();
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000058 RID: 88 RVA: 0x0000725E File Offset: 0x0000545E
		public override xColorTable CommonColorTable
		{
			get
			{
				return this._CommonColorTable;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00007266 File Offset: 0x00005466
		public override Color BackgroundTopGradient
		{
			get
			{
				return Color.FromArgb(246, 246, 246);
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600005A RID: 90 RVA: 0x0000727C File Offset: 0x0000547C
		public override Color BackgroundBottomGradient
		{
			get
			{
				return Color.FromArgb(226, 226, 226);
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600005B RID: 91 RVA: 0x00007292 File Offset: 0x00005492
		public override Color DropdownTopGradient
		{
			get
			{
				return Color.FromArgb(246, 246, 246);
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600005C RID: 92 RVA: 0x000072A8 File Offset: 0x000054A8
		public override Color DropdownBottomGradient
		{
			get
			{
				return Color.FromArgb(246, 246, 246);
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600005D RID: 93 RVA: 0x000072BE File Offset: 0x000054BE
		public override Color DroppedDownItemBackground
		{
			get
			{
				return Color.FromArgb(240, 240, 240);
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600005E RID: 94 RVA: 0x000072D4 File Offset: 0x000054D4
		public override Color Separator
		{
			get
			{
				return Color.FromArgb(190, 195, 203);
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600005F RID: 95 RVA: 0x000072EA File Offset: 0x000054EA
		public override Color ImageMargin
		{
			get
			{
				return Color.FromArgb(240, 240, 240);
			}
		}

		// Token: 0x0400005C RID: 92
		private xColorTable _CommonColorTable;
	}
}
