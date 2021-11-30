using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PureComponents.NicePanel.Design
{
	internal class ControlTagEditorForm : Form
	{
		private NicePanel m_NicePanel = null;

		private NicePanelDesigner m_Designer = null;

		private Hashtable m_MapControl2Value = new Hashtable();

		private TreeView treeView1;

		private Label label1;

		private Label label2;

		private Label label4;

		private GroupBox groupBox1;

		private Label label5;

		private Label label6;

		private Label label7;

		private Button button1;

		private Button button2;

		private Label lblControlName;

		private TextBox txtDescription;

		private TextBox txtFormat;

		private TextBox txtDataField;

		private TextBox txtTitle;

		private Container components = null;

		public ControlTagEditorForm(NicePanel nicePanel, NicePanelDesigner designer)
		{
			InitializeComponent();
			m_NicePanel = nicePanel;
			m_Designer = designer;
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
			treeView1 = new System.Windows.Forms.TreeView();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			lblControlName = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			groupBox1 = new System.Windows.Forms.GroupBox();
			txtDescription = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			txtFormat = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			txtTitle = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			txtDataField = new System.Windows.Forms.TextBox();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			groupBox1.SuspendLayout();
			SuspendLayout();
			treeView1.FullRowSelect = true;
			treeView1.HideSelection = false;
			treeView1.ImageIndex = -1;
			treeView1.Location = new System.Drawing.Point(8, 20);
			treeView1.Name = "treeView1";
			treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[4]
			{
				new System.Windows.Forms.TreeNode("GroupBox1", new System.Windows.Forms.TreeNode[3]
				{
					new System.Windows.Forms.TreeNode("TextBox3"),
					new System.Windows.Forms.TreeNode("TextBox4"),
					new System.Windows.Forms.TreeNode("TextBox5")
				}),
				new System.Windows.Forms.TreeNode("GroupBox2", new System.Windows.Forms.TreeNode[3]
				{
					new System.Windows.Forms.TreeNode("RadioButton1"),
					new System.Windows.Forms.TreeNode("RadioButton2"),
					new System.Windows.Forms.TreeNode("RadioButton3")
				}),
				new System.Windows.Forms.TreeNode("TextBox1"),
				new System.Windows.Forms.TreeNode("TextBox2")
			});
			treeView1.SelectedImageIndex = -1;
			treeView1.Size = new System.Drawing.Size(188, 264);
			treeView1.Sorted = true;
			treeView1.TabIndex = 0;
			treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(treeView1_AfterSelect);
			treeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(treeView1_BeforeSelect);
			label1.Location = new System.Drawing.Point(8, 4);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(108, 16);
			label1.TabIndex = 1;
			label1.Text = "Child controls:";
			label2.Location = new System.Drawing.Point(204, 16);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(108, 16);
			label2.TabIndex = 2;
			label2.Text = "Selected control:";
			lblControlName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 238);
			lblControlName.Location = new System.Drawing.Point(204, 32);
			lblControlName.Name = "lblControlName";
			lblControlName.Size = new System.Drawing.Size(208, 16);
			lblControlName.TabIndex = 3;
			label4.Location = new System.Drawing.Point(8, 20);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(108, 16);
			label4.TabIndex = 4;
			label4.Text = "ID:";
			groupBox1.Controls.Add(txtDescription);
			groupBox1.Controls.Add(label7);
			groupBox1.Controls.Add(txtFormat);
			groupBox1.Controls.Add(label6);
			groupBox1.Controls.Add(txtTitle);
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(txtDataField);
			groupBox1.Controls.Add(label4);
			groupBox1.Location = new System.Drawing.Point(208, 52);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(204, 232);
			groupBox1.TabIndex = 5;
			groupBox1.TabStop = false;
			groupBox1.Text = "Tag property";
			txtDescription.Location = new System.Drawing.Point(12, 168);
			txtDescription.Multiline = true;
			txtDescription.Name = "txtDescription";
			txtDescription.Size = new System.Drawing.Size(180, 48);
			txtDescription.TabIndex = 11;
			txtDescription.Text = "";
			label7.Location = new System.Drawing.Point(8, 152);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(108, 16);
			label7.TabIndex = 10;
			label7.Text = "Description:";
			txtFormat.Location = new System.Drawing.Point(12, 124);
			txtFormat.Name = "txtFormat";
			txtFormat.Size = new System.Drawing.Size(180, 20);
			txtFormat.TabIndex = 9;
			txtFormat.Text = "";
			label6.Location = new System.Drawing.Point(8, 108);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(108, 16);
			label6.TabIndex = 8;
			label6.Text = "Format:";
			txtTitle.Location = new System.Drawing.Point(12, 80);
			txtTitle.Name = "txtTitle";
			txtTitle.Size = new System.Drawing.Size(180, 20);
			txtTitle.TabIndex = 7;
			txtTitle.Text = "";
			label5.Location = new System.Drawing.Point(8, 64);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(108, 16);
			label5.TabIndex = 6;
			label5.Text = "Caption:";
			txtDataField.Location = new System.Drawing.Point(12, 36);
			txtDataField.Name = "txtDataField";
			txtDataField.Size = new System.Drawing.Size(180, 20);
			txtDataField.TabIndex = 5;
			txtDataField.Text = "";
			button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			button1.Location = new System.Drawing.Point(348, 296);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(64, 24);
			button1.TabIndex = 6;
			button1.Text = "Cancel";
			button1.Click += new System.EventHandler(button1_Click);
			button2.Location = new System.Drawing.Point(276, 296);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(64, 24);
			button2.TabIndex = 7;
			button2.Text = "OK";
			button2.Click += new System.EventHandler(button2_Click);
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			base.CancelButton = button1;
			base.ClientSize = new System.Drawing.Size(420, 325);
			base.Controls.Add(button2);
			base.Controls.Add(button1);
			base.Controls.Add(groupBox1);
			base.Controls.Add(lblControlName);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.Controls.Add(treeView1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ControlTagEditorForm";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "PureComponents NicePanel Tag Editor";
			groupBox1.ResumeLayout(false);
			ResumeLayout(false);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			treeView1.Nodes.Clear();
			m_MapControl2Value.Clear();
			foreach (Control control in m_NicePanel.Controls)
			{
				AddControlNode(control, null);
			}
		}

		private void AddControlNode(Control control, TreeNode parentNode)
		{
			if (!(control is NicePanel))
			{
				TreeNode treeNode = new TreeNode(control.Name);
				treeNode.Tag = control;
				m_MapControl2Value.Add(control, control.Tag);
				if (parentNode == null)
				{
					treeView1.Nodes.Add(treeNode);
				}
				else
				{
					parentNode.Nodes.Add(treeNode);
				}
			}
			if (!(control is Panel) && !(control is GroupBox) && !(control is NicePanel) && !(control is ContainerControl))
			{
				return;
			}
			if (control is Panel && control.Tag is string && (string)control.Tag == "NicePanelAutoScroll" && control.Text == "NicePanelAutoScroll")
			{
				foreach (Control control4 in control.Controls)
				{
					AddControlNode(control4, null);
				}
				return;
			}
			TreeNode treeNode2 = new TreeNode(control.Name);
			treeNode2.Tag = control;
			m_MapControl2Value.Add(control, control.Tag);
			if (parentNode == null)
			{
				treeView1.Nodes.Add(treeNode2);
			}
			else
			{
				parentNode.Nodes.Add(treeNode2);
			}
			foreach (Control control5 in control.Controls)
			{
				AddControlNode(control5, treeNode2);
			}
		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			lblControlName.Text = (e.Node.Tag as Control).Name;
			txtDataField.Text = string.Empty;
			txtDescription.Text = string.Empty;
			txtFormat.Text = string.Empty;
			txtTitle.Text = string.Empty;
			string text = (e.Node.Tag as Control).Tag as string;
			if (text != null)
			{
				string[] array = text.Split("|".ToCharArray());
				txtDataField.Text = ((array.Length > 0) ? array[0] : string.Empty);
				txtTitle.Text = ((array.Length > 1) ? array[1] : string.Empty);
				txtFormat.Text = ((array.Length > 2) ? array[2] : string.Empty);
				txtDescription.Text = ((array.Length > 3) ? array[3] : string.Empty);
			}
		}

		private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
		{
			if (treeView1.SelectedNode != null)
			{
				Control control = treeView1.SelectedNode.Tag as Control;
				PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(control);
				PropertyDescriptor member = properties.Find("Tag", ignoreCase: false);
				string newValue = (string)(control.Tag = txtDataField.Text + "|" + txtTitle.Text + "|" + txtFormat.Text + "|" + txtDescription.Text);
				m_Designer.InvokeComponentChanging(member);
				m_Designer.InvokeComponentChanged(member, null, newValue);
			}
			m_NicePanel.Invalidate();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (treeView1.SelectedNode != null)
			{
				Control control = treeView1.SelectedNode.Tag as Control;
				PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(control);
				PropertyDescriptor member = properties.Find("Tag", ignoreCase: false);
				string newValue = (string)(control.Tag = txtDataField.Text + "|" + txtTitle.Text + "|" + txtFormat.Text + "|" + txtDescription.Text);
				m_Designer.InvokeComponentChanging(member);
				m_Designer.InvokeComponentChanged(member, null, newValue);
			}
			m_NicePanel.Invalidate();
			base.DialogResult = DialogResult.OK;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			foreach (Control key in m_MapControl2Value.Keys)
			{
				key.Tag = m_MapControl2Value[key] as string;
			}
			m_NicePanel.Invalidate();
			base.DialogResult = DialogResult.Cancel;
		}
	}
}
