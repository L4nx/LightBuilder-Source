using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
	// Token: 0x02000014 RID: 20
	internal class iTalk_HeaderLabel : Label
	{
		// Token: 0x060000D9 RID: 217 RVA: 0x0000AC90 File Offset: 0x00008E90
		public iTalk_HeaderLabel()
		{
			this.Font = new Font("Segoe UI", 25f, FontStyle.Regular);
			this.ForeColor = Color.FromArgb(80, 80, 80);
			this.BackColor = Color.Transparent;
		}
	}
}
