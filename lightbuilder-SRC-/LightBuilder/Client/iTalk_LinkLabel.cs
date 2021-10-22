using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
	// Token: 0x02000013 RID: 19
	internal class iTalk_LinkLabel : LinkLabel
	{
		// Token: 0x060000D8 RID: 216 RVA: 0x0000AC18 File Offset: 0x00008E18
		public iTalk_LinkLabel()
		{
			this.Font = new Font("Segoe UI", 8f, FontStyle.Regular);
			this.BackColor = Color.Transparent;
			base.LinkColor = Color.FromArgb(51, 153, 225);
			base.ActiveLinkColor = Color.FromArgb(0, 101, 202);
			base.VisitedLinkColor = Color.FromArgb(0, 101, 202);
			base.LinkBehavior = LinkBehavior.NeverUnderline;
		}
	}
}
