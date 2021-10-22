using System;
using System.Drawing;

namespace Client
{
	// Token: 0x0200000A RID: 10
	public class DefaultCColorTable : xColorTable
	{
		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000060 RID: 96 RVA: 0x00007300 File Offset: 0x00005500
		public override Color CheckedBackground
		{
			get
			{
				return Color.FromArgb(230, 230, 230);
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000061 RID: 97 RVA: 0x00007316 File Offset: 0x00005516
		public override Color CheckedSelectedBackground
		{
			get
			{
				return Color.FromArgb(230, 230, 230);
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000062 RID: 98 RVA: 0x0000732C File Offset: 0x0000552C
		public override Color SelectionBorder
		{
			get
			{
				return Color.FromArgb(180, 180, 180);
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000063 RID: 99 RVA: 0x00007342 File Offset: 0x00005542
		public override Color SelectionTopGradient
		{
			get
			{
				return Color.FromArgb(240, 240, 240);
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000064 RID: 100 RVA: 0x00007358 File Offset: 0x00005558
		public override Color SelectionMidGradient
		{
			get
			{
				return Color.FromArgb(235, 235, 235);
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000065 RID: 101 RVA: 0x0000736E File Offset: 0x0000556E
		public override Color SelectionBottomGradient
		{
			get
			{
				return Color.FromArgb(230, 230, 230);
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000066 RID: 102 RVA: 0x00007384 File Offset: 0x00005584
		public override Color PressedBackground
		{
			get
			{
				return Color.FromArgb(232, 232, 232);
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000067 RID: 103 RVA: 0x0000739A File Offset: 0x0000559A
		public override Color TextColor
		{
			get
			{
				return Color.FromArgb(80, 80, 80);
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000068 RID: 104 RVA: 0x000073A7 File Offset: 0x000055A7
		public override Color Background
		{
			get
			{
				return Color.FromArgb(188, 199, 216);
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000069 RID: 105 RVA: 0x000073BD File Offset: 0x000055BD
		public override Color DropdownBorder
		{
			get
			{
				return Color.LightGray;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600006A RID: 106 RVA: 0x000073C4 File Offset: 0x000055C4
		public override Color Arrow
		{
			get
			{
				return Color.Black;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600006B RID: 107 RVA: 0x000073CB File Offset: 0x000055CB
		public override Color OverflowBackground
		{
			get
			{
				return Color.FromArgb(213, 220, 232);
			}
		}
	}
}
