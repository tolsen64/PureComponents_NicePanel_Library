using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace PureComponents.NicePanel.Design
{
	internal class AboutForm : Form
	{
		private Label label1;

		private Label label2;

		private Label lblVersion;

		private Label lblName;

		private Button button1;

		private Button button2;

		private Label lblEmail;

		private Container components = null;

		public AboutForm()
		{
			InitializeComponent();
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			string fullName = executingAssembly.FullName;
			int num = fullName.IndexOf("Version=");
			int num2 = fullName.IndexOf(",", num);
			lblVersion.Text = fullName.Substring(num + 8, num2 - num - 8);
			ReadLicense();
		}

		private static string GetDataToken(string sData, string sToken)
		{
			string text = "<" + sToken.ToLower() + ">";
			string value = "</" + sToken.ToLower() + ">";
			int num = sData.ToLower().IndexOf(text);
			int num2 = sData.ToLower().IndexOf(value);
			return sData.Substring(num + text.Length, num2 - (num + text.Length));
		}

		private void ReadLicense()
		{
			try
			{
				string[] array;
				try
				{
					RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\PureComponents\\Components\\NicePanel");
					if (registryKey != null)
					{
						string text = registryKey.GetValue("InstallDir") as string;
						if (text != null)
						{
							string text2 = text;
							if (text2.ToCharArray()[text2.Length - 1] == '\\')
							{
								text2 = text2.Substring(0, text2.LastIndexOf("\\"));
							}
							string[] files = Directory.GetFiles(text2, "*.license");
							array = files;
							foreach (string path in array)
							{
								try
								{
									FileStream fileStream = File.Open(path, FileMode.Open);
									byte[] array2 = new byte[fileStream.Length];
									fileStream.Read(array2, 0, (int)fileStream.Length);
									fileStream.Close();
									string @string = Encoding.ASCII.GetString(array2);
									string sData = Factory.GetInstance().Generate2(@string);
									string dataToken = GetDataToken(sData, "Name");
									string dataToken2 = GetDataToken(sData, "Email");
									if (dataToken != null)
									{
										lblName.Text = dataToken;
										lblEmail.Text = dataToken2;
										button2.Visible = false;
										return;
									}
								}
								catch
								{
								}
							}
						}
					}
				}
				catch
				{
				}
				string location = Assembly.GetExecutingAssembly().Location;
				location = location.Substring(0, location.LastIndexOf("\\"));
				string[] files2 = Directory.GetFiles(location, "*.license");
				array = files2;
				foreach (string path2 in array)
				{
					try
					{
						FileStream fileStream2 = File.Open(path2, FileMode.Open);
						byte[] array3 = new byte[fileStream2.Length];
						fileStream2.Read(array3, 0, (int)fileStream2.Length);
						fileStream2.Close();
						string string2 = Encoding.ASCII.GetString(array3);
						string sData2 = Factory.GetInstance().Generate2(string2);
						string dataToken3 = GetDataToken(sData2, "Name");
						string dataToken4 = GetDataToken(sData2, "Email");
						if (dataToken3 != null)
						{
							lblName.Text = dataToken3;
							lblEmail.Text = dataToken4;
							button2.Visible = false;
							return;
						}
					}
					catch
					{
					}
				}
				files2 = Directory.GetFiles("C:\\Program Files\\PureComponents\\NicePanel", "*.license");
				array = files2;
				foreach (string path3 in array)
				{
					try
					{
						FileStream fileStream3 = File.Open(path3, FileMode.Open);
						byte[] array4 = new byte[fileStream3.Length];
						fileStream3.Read(array4, 0, (int)fileStream3.Length);
						fileStream3.Close();
						string string3 = Encoding.ASCII.GetString(array4);
						string sData3 = Factory.GetInstance().Generate2(string3);
						string dataToken5 = GetDataToken(sData3, "Name");
						string dataToken6 = GetDataToken(sData3, "Email");
						if (dataToken5 != null)
						{
							lblName.Text = dataToken5;
							lblEmail.Text = dataToken6;
							button2.Visible = false;
							return;
						}
					}
					catch
					{
					}
				}
				files2 = Directory.GetFiles("C:\\Program Files\\PureComponents\\NicePanel\\Bin", "*.license");
				array = files2;
				foreach (string path4 in array)
				{
					try
					{
						FileStream fileStream4 = File.Open(path4, FileMode.Open);
						byte[] array5 = new byte[fileStream4.Length];
						fileStream4.Read(array5, 0, (int)fileStream4.Length);
						fileStream4.Close();
						string string4 = Encoding.ASCII.GetString(array5);
						string sData4 = Factory.GetInstance().Generate2(string4);
						string dataToken7 = GetDataToken(sData4, "Name");
						string dataToken8 = GetDataToken(sData4, "Email");
						if (dataToken7 != null)
						{
							lblName.Text = dataToken7;
							lblEmail.Text = dataToken8;
							button2.Visible = false;
							return;
						}
					}
					catch
					{
					}
				}
			}
			catch
			{
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager(typeof(PureComponents.NicePanel.Design.AboutForm));
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			lblVersion = new System.Windows.Forms.Label();
			lblName = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			lblEmail = new System.Windows.Forms.Label();
			SuspendLayout();
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.Cursor = System.Windows.Forms.Cursors.Hand;
			label1.Location = new System.Drawing.Point(183, 307);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(120, 14);
			label1.TabIndex = 0;
			label1.Click += new System.EventHandler(label1_Click);
			label2.BackColor = System.Drawing.Color.Transparent;
			label2.Cursor = System.Windows.Forms.Cursors.Hand;
			label2.Location = new System.Drawing.Point(183, 436);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(120, 14);
			label2.TabIndex = 1;
			label2.Click += new System.EventHandler(label2_Click);
			lblVersion.BackColor = System.Drawing.Color.Transparent;
			lblVersion.Location = new System.Drawing.Point(413, 206);
			lblVersion.Name = "lblVersion";
			lblVersion.Size = new System.Drawing.Size(122, 14);
			lblVersion.TabIndex = 2;
			lblName.BackColor = System.Drawing.Color.Transparent;
			lblName.Location = new System.Drawing.Point(380, 245);
			lblName.Name = "lblName";
			lblName.Size = new System.Drawing.Size(154, 14);
			lblName.TabIndex = 3;
			lblName.Text = "Unlicensed";
			button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Location = new System.Drawing.Point(488, 478);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(58, 23);
			button1.TabIndex = 4;
			button1.Text = "OK";
			button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button2.Location = new System.Drawing.Point(4, 478);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(110, 23);
			button2.TabIndex = 5;
			button2.Text = "Get FREE license";
			button2.Click += new System.EventHandler(button2_Click);
			lblEmail.BackColor = System.Drawing.Color.Transparent;
			lblEmail.Location = new System.Drawing.Point(380, 263);
			lblEmail.Name = "lblEmail";
			lblEmail.Size = new System.Drawing.Size(154, 14);
			lblEmail.TabIndex = 6;
			base.AcceptButton = button1;
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("$this.BackgroundImage");
			base.ClientSize = new System.Drawing.Size(549, 506);
			base.Controls.Add(lblEmail);
			base.Controls.Add(button2);
			base.Controls.Add(button1);
			base.Controls.Add(lblName);
			base.Controls.Add(lblVersion);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "AboutForm";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "About PureComponents NicePanel";
			ResumeLayout(false);
		}

		private void label1_Click(object sender, EventArgs e)
		{
			Process.Start("iexplore.exe", "http://www.purecomponents.com/products/Navigator/features.aspx");
		}

		private void label2_Click(object sender, EventArgs e)
		{
			Process.Start("iexplore.exe", "http://www.purecomponents.com/products/TreeView/features.aspx");
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Process.Start("iexplore.exe", "http://www.purecomponents.com/products/NicePanel/IssueLicense.aspx");
		}
	}
}
