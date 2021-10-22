using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Client
{
	// Token: 0x02000021 RID: 33
	internal class iTalk_Listview : ListView
	{
		// Token: 0x0600015D RID: 349
		[DllImport("uxtheme", CharSet = CharSet.Unicode)]
		public static extern int SetWindowTheme(IntPtr hWnd, string textSubAppName, string textSubIdList);

		// Token: 0x0600015E RID: 350 RVA: 0x0000D421 File Offset: 0x0000B621
		public iTalk_Listview()
		{
			base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			base.HeaderStyle = ColumnHeaderStyle.Nonclickable;
			base.BorderStyle = BorderStyle.None;
		}

		// Token: 0x0600015F RID: 351 RVA: 0x0000D44A File Offset: 0x0000B64A
		protected override void OnHandleCreated(EventArgs e)
		{
			iTalk_Listview.SetWindowTheme(base.Handle, "explorer", null);
			base.OnHandleCreated(e);
		}
	}
}
