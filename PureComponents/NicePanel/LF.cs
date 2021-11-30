using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace PureComponents.NicePanel
{
	internal class LF : Form
	{
		private Panel panelTreeView;

		private Panel panelNavigator;

		private Panel panel1;

		private Label label1;

		private Label label2;

		private Label label3;

		private Container components = null;

		public LF()
		{
			InitializeComponent();
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
			System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager(typeof(PureComponents.NicePanel.LF));
			panelTreeView = new System.Windows.Forms.Panel();
			label2 = new System.Windows.Forms.Label();
			panelNavigator = new System.Windows.Forms.Panel();
			label3 = new System.Windows.Forms.Label();
			panel1 = new System.Windows.Forms.Panel();
			label1 = new System.Windows.Forms.Label();
			panelTreeView.SuspendLayout();
			panelNavigator.SuspendLayout();
			panel1.SuspendLayout();
			SuspendLayout();
			panelTreeView.AutoScroll = true;
			panelTreeView.BackColor = System.Drawing.Color.WhiteSmoke;
			panelTreeView.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("panelTreeView.BackgroundImage");
			panelTreeView.Controls.Add(label2);
			panelTreeView.DockPadding.All = 3;
			panelTreeView.Location = new System.Drawing.Point(6, 76);
			panelTreeView.Name = "panelTreeView";
			panelTreeView.Size = new System.Drawing.Size(356, 138);
			panelTreeView.TabIndex = 1;
			label2.BackColor = System.Drawing.Color.Transparent;
			label2.Cursor = System.Windows.Forms.Cursors.Hand;
			label2.Location = new System.Drawing.Point(184, 111);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(120, 12);
			label2.TabIndex = 2;
			label2.Click += new System.EventHandler(linkLabel2_LinkClicked);
			panelNavigator.BackColor = System.Drawing.Color.WhiteSmoke;
			panelNavigator.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("panelNavigator.BackgroundImage");
			panelNavigator.Controls.Add(label3);
			panelNavigator.DockPadding.All = 3;
			panelNavigator.Location = new System.Drawing.Point(6, 76);
			panelNavigator.Name = "panelNavigator";
			panelNavigator.Size = new System.Drawing.Size(356, 138);
			panelNavigator.TabIndex = 3;
			label3.BackColor = System.Drawing.Color.Transparent;
			label3.Cursor = System.Windows.Forms.Cursors.Hand;
			label3.Location = new System.Drawing.Point(184, 113);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(119, 13);
			label3.TabIndex = 14;
			label3.Click += new System.EventHandler(linkLabel3_LinkClicked);
			panel1.BackColor = System.Drawing.Color.WhiteSmoke;
			panel1.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("panel1.BackgroundImage");
			panel1.Controls.Add(label1);
			panel1.Controls.Add(panelNavigator);
			panel1.Controls.Add(panelTreeView);
			panel1.DockPadding.All = 5;
			panel1.Location = new System.Drawing.Point(-5, -5);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(363, 215);
			panel1.TabIndex = 0;
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.Cursor = System.Windows.Forms.Cursors.Hand;
			label1.Location = new System.Drawing.Point(308, 43);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(48, 11);
			label1.TabIndex = 1;
			label1.Click += new System.EventHandler(linkLabel1_LinkClicked);
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			base.ClientSize = new System.Drawing.Size(358, 210);
			base.Controls.Add(panel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "LF";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "LF";
			base.TopMost = true;
			panelTreeView.ResumeLayout(false);
			panelNavigator.ResumeLayout(false);
			panel1.ResumeLayout(false);
			ResumeLayout(false);
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			e.Cancel = true;
		}

		private void linkLabel1_LinkClicked(object sender, EventArgs e)
		{
			Process.Start("iexplore.exe", "http://www.purecomponents.com/products/NicePanel/IssueLicense.aspx");
		}

		private void linkLabel2_LinkClicked(object sender, EventArgs e)
		{
			Process.Start("iexplore.exe", "http://www.purecomponents.com/products/TreeView/features.aspx");
		}

		private void linkLabel3_LinkClicked(object sender, EventArgs e)
		{
			Process.Start("iexplore.exe", "http://www.purecomponents.com/products/Navigator/features.aspx");
		}

		internal void SwapAdvert()
		{
			if (!panelNavigator.Visible)
			{
				panelNavigator.Visible = true;
			}
			else
			{
				panelNavigator.Visible = false;
			}
			panelTreeView.Visible = !panelNavigator.Visible;
		}
	}
}
