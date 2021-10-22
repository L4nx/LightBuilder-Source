using System;
using System.Windows.Forms;

namespace L33TBuilder
{
	// Token: 0x02000005 RID: 5
	internal static class Program
	{
		// Token: 0x0600003E RID: 62 RVA: 0x00006FFE File Offset: 0x000051FE
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}
