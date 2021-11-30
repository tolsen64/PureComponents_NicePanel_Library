using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace PureComponents.NicePanel.Design
{
	[ToolboxItem(false)]
	internal class ColorUIEditorCtrl : UserControl
	{
		private ColorUIEditorHexagonCtrl m_HexagonCtrl;

		private ColorUIEditorCustomCtrl m_CustomCtrl;

		private ColorUIEditorPaletteLightCtrl m_PaletteLightCtrl;

		private ColorUIEditorPaletteCtrl m_PaletteCtrl;

		private bool m_InternalValueChange = false;

		private Color m_OriginalColor;

		private IWindowsFormsEditorService m_EditorService = null;

		private TabControl tabControl1;

		private TabPage tabPage1;

		private TabPage tabPage2;

		private ListBox lstSystemColors;

		private ListBox lstColors;

		private Panel previewColorPanel;

		private Label label1;

		private Button btnUse;

		private TabPage tabPage4;

		private Button button1;

		private Panel originalColorPanel;

		private Label label5;

		private Label label6;

		private TextBox txtValue;

		private Label label7;

		private RadioButton radioButton1;

		private RadioButton radioButton2;

		private Label lblSaturation;

		private Label lblLight;

		private Label lblHue;

		private Label lblBlue;

		private Label lblGreen;

		private Label lblRed;

		private NumericUpDown txtBlue;

		private NumericUpDown txtGreen;

		private NumericUpDown txtRed;

		private NumericUpDown txtS;

		private NumericUpDown txtL;

		private NumericUpDown txtH;

		private TabPage tabPage3;

		private Container components = null;

		public Color OriginalValue
		{
			set
			{
				m_OriginalColor = value;
				originalColorPanel.BackColor = value;
			}
		}

		public Color Value
		{
			get
			{
				return previewColorPanel.BackColor;
			}
			set
			{
				previewColorPanel.BackColor = value;
				originalColorPanel.BackColor = m_OriginalColor;
				ColorManager.HLS hLS = ColorManager.RGB_to_HLS(value);
				txtH.Value = (int)(hLS.H * 100.0);
				txtL.Value = (int)(hLS.L * 100.0);
				txtS.Value = (int)(hLS.S * 100.0);
				txtRed.Value = value.R;
				txtGreen.Value = value.G;
				txtBlue.Value = value.B;
				txtValue.Text = "#" + previewColorPanel.BackColor.R.ToString("X2") + previewColorPanel.BackColor.G.ToString("X2") + previewColorPanel.BackColor.B.ToString("X2");
			}
		}

		public event EventHandler OKClick;

		public event EventHandler CancelClick;

		internal ColorUIEditorCtrl()
		{
			InitializeComponent();
			new ResourceManager(typeof(ColorUIEditorCtrl));
			AddColoursToList(lstSystemColors, typeof(SystemColors), Color.Black);
			AddNamedColors();
			m_PaletteCtrl = new ColorUIEditorPaletteCtrl();
			m_PaletteCtrl.Width = 175;
			m_PaletteCtrl.Height = 137;
			m_PaletteCtrl.Top = 4;
			m_PaletteCtrl.Left = 4;
			m_PaletteCtrl.ColorPick += PaletteColorPick;
			m_CustomCtrl = new ColorUIEditorCustomCtrl();
			m_CustomCtrl.Top = 4;
			m_CustomCtrl.Left = 0;
			m_CustomCtrl.ColorPick += CustomColorPick;
			m_HexagonCtrl = new ColorUIEditorHexagonCtrl();
			m_HexagonCtrl.Top = 8;
			m_HexagonCtrl.Left = 2 + m_CustomCtrl.Width;
			m_HexagonCtrl.ColorPick += CustomColorPick;
			m_PaletteLightCtrl = new ColorUIEditorPaletteLightCtrl();
			m_PaletteLightCtrl.Width = 15;
			m_PaletteLightCtrl.Height = 137;
			m_PaletteLightCtrl.Left = 187;
			m_PaletteLightCtrl.Top = 4;
			m_PaletteLightCtrl.ColorPick += PaletteColorPick;
			tabPage3.Controls.Add(m_PaletteCtrl);
			tabPage3.Controls.Add(m_PaletteLightCtrl);
			tabPage4.Controls.Add(m_CustomCtrl);
			tabPage4.Controls.Add(m_HexagonCtrl);
		}

		public ColorUIEditorCtrl(Color originalColor, IWindowsFormsEditorService editorService)
			: this()
		{
			m_EditorService = editorService;
			m_OriginalColor = originalColor;
			BackColor = tabPage1.BackColor;
			button1.BackColor = tabPage1.BackColor;
			btnUse.BackColor = tabPage1.BackColor;
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
			tabControl1 = new System.Windows.Forms.TabControl();
			tabPage4 = new System.Windows.Forms.TabPage();
			tabPage2 = new System.Windows.Forms.TabPage();
			lstColors = new System.Windows.Forms.ListBox();
			tabPage1 = new System.Windows.Forms.TabPage();
			lstSystemColors = new System.Windows.Forms.ListBox();
			tabPage3 = new System.Windows.Forms.TabPage();
			label7 = new System.Windows.Forms.Label();
			radioButton1 = new System.Windows.Forms.RadioButton();
			radioButton2 = new System.Windows.Forms.RadioButton();
			lblBlue = new System.Windows.Forms.Label();
			lblGreen = new System.Windows.Forms.Label();
			lblRed = new System.Windows.Forms.Label();
			txtBlue = new System.Windows.Forms.NumericUpDown();
			txtGreen = new System.Windows.Forms.NumericUpDown();
			txtRed = new System.Windows.Forms.NumericUpDown();
			txtS = new System.Windows.Forms.NumericUpDown();
			txtL = new System.Windows.Forms.NumericUpDown();
			txtH = new System.Windows.Forms.NumericUpDown();
			lblSaturation = new System.Windows.Forms.Label();
			lblLight = new System.Windows.Forms.Label();
			lblHue = new System.Windows.Forms.Label();
			previewColorPanel = new System.Windows.Forms.Panel();
			label1 = new System.Windows.Forms.Label();
			btnUse = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			originalColorPanel = new System.Windows.Forms.Panel();
			label5 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			txtValue = new System.Windows.Forms.TextBox();
			tabControl1.SuspendLayout();
			tabPage2.SuspendLayout();
			tabPage1.SuspendLayout();
			tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)txtBlue).BeginInit();
			((System.ComponentModel.ISupportInitialize)txtGreen).BeginInit();
			((System.ComponentModel.ISupportInitialize)txtRed).BeginInit();
			((System.ComponentModel.ISupportInitialize)txtS).BeginInit();
			((System.ComponentModel.ISupportInitialize)txtL).BeginInit();
			((System.ComponentModel.ISupportInitialize)txtH).BeginInit();
			SuspendLayout();
			tabControl1.Controls.Add(tabPage4);
			tabControl1.Controls.Add(tabPage2);
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage3);
			tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
			tabControl1.Location = new System.Drawing.Point(1, 0);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new System.Drawing.Size(336, 181);
			tabControl1.TabIndex = 0;
			tabPage4.BackColor = System.Drawing.SystemColors.Control;
			tabPage4.Location = new System.Drawing.Point(4, 22);
			tabPage4.Name = "tabPage4";
			tabPage4.Size = new System.Drawing.Size(328, 155);
			tabPage4.TabIndex = 3;
			tabPage4.Text = "Custom";
			tabPage2.Controls.Add(lstColors);
			tabPage2.Location = new System.Drawing.Point(4, 22);
			tabPage2.Name = "tabPage2";
			tabPage2.Size = new System.Drawing.Size(328, 155);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "Web";
			lstColors.BackColor = System.Drawing.Color.White;
			lstColors.Dock = System.Windows.Forms.DockStyle.Fill;
			lstColors.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			lstColors.Location = new System.Drawing.Point(0, 0);
			lstColors.Name = "lstColors";
			lstColors.Size = new System.Drawing.Size(328, 155);
			lstColors.TabIndex = 1;
			lstColors.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(lstSystemColors_MeasureItem);
			lstColors.DrawItem += new System.Windows.Forms.DrawItemEventHandler(lstColors_DrawItem);
			lstColors.SelectedIndexChanged += new System.EventHandler(lstColors_SelectedIndexChanged);
			tabPage1.Controls.Add(lstSystemColors);
			tabPage1.Location = new System.Drawing.Point(4, 22);
			tabPage1.Name = "tabPage1";
			tabPage1.Size = new System.Drawing.Size(328, 155);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "System";
			lstSystemColors.BackColor = System.Drawing.Color.White;
			lstSystemColors.Dock = System.Windows.Forms.DockStyle.Fill;
			lstSystemColors.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			lstSystemColors.Location = new System.Drawing.Point(0, 0);
			lstSystemColors.Name = "lstSystemColors";
			lstSystemColors.Size = new System.Drawing.Size(328, 155);
			lstSystemColors.TabIndex = 0;
			lstSystemColors.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(lstSystemColors_MeasureItem);
			lstSystemColors.DrawItem += new System.Windows.Forms.DrawItemEventHandler(lstColors_DrawItem);
			lstSystemColors.SelectedIndexChanged += new System.EventHandler(lstSystemColors_SelectedIndexChanged);
			tabPage3.Controls.Add(label7);
			tabPage3.Controls.Add(radioButton1);
			tabPage3.Controls.Add(radioButton2);
			tabPage3.Controls.Add(lblBlue);
			tabPage3.Controls.Add(lblGreen);
			tabPage3.Controls.Add(lblRed);
			tabPage3.Controls.Add(txtBlue);
			tabPage3.Controls.Add(txtGreen);
			tabPage3.Controls.Add(txtRed);
			tabPage3.Controls.Add(txtS);
			tabPage3.Controls.Add(txtL);
			tabPage3.Controls.Add(txtH);
			tabPage3.Controls.Add(lblSaturation);
			tabPage3.Controls.Add(lblLight);
			tabPage3.Controls.Add(lblHue);
			tabPage3.Location = new System.Drawing.Point(4, 22);
			tabPage3.Name = "tabPage3";
			tabPage3.Size = new System.Drawing.Size(328, 155);
			tabPage3.TabIndex = 4;
			tabPage3.Text = "Advanced";
			label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
			label7.Location = new System.Drawing.Point(217, 6);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(70, 13);
			label7.TabIndex = 8;
			label7.Text = "Color model:";
			radioButton1.Checked = true;
			radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
			radioButton1.Location = new System.Drawing.Point(221, 26);
			radioButton1.Name = "radioButton1";
			radioButton1.Size = new System.Drawing.Size(48, 24);
			radioButton1.TabIndex = 9;
			radioButton1.TabStop = true;
			radioButton1.Text = "RGB";
			radioButton1.Click += new System.EventHandler(radioButton1_Click);
			radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
			radioButton2.Location = new System.Drawing.Point(269, 26);
			radioButton2.Name = "radioButton2";
			radioButton2.Size = new System.Drawing.Size(48, 24);
			radioButton2.TabIndex = 10;
			radioButton2.Text = "HSL";
			radioButton2.Click += new System.EventHandler(radioButton2_Click);
			lblBlue.AutoSize = true;
			lblBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
			lblBlue.Location = new System.Drawing.Point(221, 108);
			lblBlue.Name = "lblBlue";
			lblBlue.Size = new System.Drawing.Size(30, 16);
			lblBlue.TabIndex = 37;
			lblBlue.Text = "Blue:";
			lblGreen.AutoSize = true;
			lblGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
			lblGreen.Location = new System.Drawing.Point(221, 84);
			lblGreen.Name = "lblGreen";
			lblGreen.Size = new System.Drawing.Size(39, 16);
			lblGreen.TabIndex = 36;
			lblGreen.Text = "Green:";
			lblRed.AutoSize = true;
			lblRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
			lblRed.Location = new System.Drawing.Point(221, 60);
			lblRed.Name = "lblRed";
			lblRed.Size = new System.Drawing.Size(28, 16);
			lblRed.TabIndex = 35;
			lblRed.Text = "Red:";
			txtBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
			txtBlue.Location = new System.Drawing.Point(268, 108);
			txtBlue.Maximum = new decimal(new int[4] { 255, 0, 0, 0 });
			txtBlue.Name = "txtBlue";
			txtBlue.Size = new System.Drawing.Size(48, 20);
			txtBlue.TabIndex = 34;
			txtBlue.Value = new decimal(new int[4] { 255, 0, 0, 0 });
			txtBlue.TextChanged += new System.EventHandler(txtBlue_ValueChanged);
			txtBlue.ValueChanged += new System.EventHandler(txtBlue_ValueChanged);
			txtBlue.Leave += new System.EventHandler(txtBlue_ValueChanged);
			txtGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
			txtGreen.Location = new System.Drawing.Point(268, 84);
			txtGreen.Maximum = new decimal(new int[4] { 255, 0, 0, 0 });
			txtGreen.Name = "txtGreen";
			txtGreen.Size = new System.Drawing.Size(48, 20);
			txtGreen.TabIndex = 33;
			txtGreen.Value = new decimal(new int[4] { 255, 0, 0, 0 });
			txtGreen.TextChanged += new System.EventHandler(txtBlue_ValueChanged);
			txtGreen.ValueChanged += new System.EventHandler(txtBlue_ValueChanged);
			txtGreen.Leave += new System.EventHandler(txtBlue_ValueChanged);
			txtRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
			txtRed.Location = new System.Drawing.Point(268, 60);
			txtRed.Maximum = new decimal(new int[4] { 255, 0, 0, 0 });
			txtRed.Name = "txtRed";
			txtRed.Size = new System.Drawing.Size(48, 20);
			txtRed.TabIndex = 32;
			txtRed.Value = new decimal(new int[4] { 255, 0, 0, 0 });
			txtRed.TextChanged += new System.EventHandler(txtBlue_ValueChanged);
			txtRed.ValueChanged += new System.EventHandler(txtBlue_ValueChanged);
			txtRed.Leave += new System.EventHandler(txtBlue_ValueChanged);
			txtS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
			txtS.Location = new System.Drawing.Point(268, 84);
			txtS.Name = "txtS";
			txtS.Size = new System.Drawing.Size(48, 20);
			txtS.TabIndex = 39;
			txtS.Visible = false;
			txtS.ValueChanged += new System.EventHandler(txtHSL_ValueChanged);
			txtL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
			txtL.Location = new System.Drawing.Point(268, 108);
			txtL.Name = "txtL";
			txtL.Size = new System.Drawing.Size(48, 20);
			txtL.TabIndex = 40;
			txtL.Visible = false;
			txtL.ValueChanged += new System.EventHandler(txtHSL_ValueChanged);
			txtH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
			txtH.Location = new System.Drawing.Point(268, 60);
			txtH.Name = "txtH";
			txtH.Size = new System.Drawing.Size(48, 20);
			txtH.TabIndex = 38;
			txtH.Visible = false;
			txtH.ValueChanged += new System.EventHandler(txtHSL_ValueChanged);
			lblSaturation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			lblSaturation.Location = new System.Drawing.Point(221, 84);
			lblSaturation.Name = "lblSaturation";
			lblSaturation.Size = new System.Drawing.Size(56, 13);
			lblSaturation.TabIndex = 7;
			lblSaturation.Text = "S:";
			lblSaturation.Visible = false;
			lblLight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			lblLight.Location = new System.Drawing.Point(221, 108);
			lblLight.Name = "lblLight";
			lblLight.Size = new System.Drawing.Size(30, 13);
			lblLight.TabIndex = 5;
			lblLight.Text = "L:";
			lblLight.Visible = false;
			lblHue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			lblHue.Location = new System.Drawing.Point(221, 60);
			lblHue.Name = "lblHue";
			lblHue.Size = new System.Drawing.Size(25, 13);
			lblHue.TabIndex = 3;
			lblHue.Text = "H:";
			lblHue.Visible = false;
			previewColorPanel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			previewColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			previewColorPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
			previewColorPanel.Location = new System.Drawing.Point(108, 202);
			previewColorPanel.Name = "previewColorPanel";
			previewColorPanel.Size = new System.Drawing.Size(39, 20);
			previewColorPanel.TabIndex = 1;
			previewColorPanel.BackColorChanged += new System.EventHandler(previewColorPanel_BackColorChanged);
			label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
			label1.Location = new System.Drawing.Point(106, 186);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(29, 12);
			label1.TabIndex = 0;
			label1.Text = "New";
			btnUse.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			btnUse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
			btnUse.Location = new System.Drawing.Point(276, 202);
			btnUse.Name = "btnUse";
			btnUse.Size = new System.Drawing.Size(50, 20);
			btnUse.TabIndex = 2;
			btnUse.Text = "Apply";
			btnUse.Click += new System.EventHandler(button1_Click);
			button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
			button1.Location = new System.Drawing.Point(221, 202);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(50, 20);
			button1.TabIndex = 3;
			button1.Text = "Cancel";
			button1.Click += new System.EventHandler(button1_Click_1);
			originalColorPanel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			originalColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			originalColorPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
			originalColorPanel.Location = new System.Drawing.Point(146, 202);
			originalColorPanel.Name = "originalColorPanel";
			originalColorPanel.Size = new System.Drawing.Size(39, 20);
			originalColorPanel.TabIndex = 4;
			label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
			label5.Location = new System.Drawing.Point(145, 186);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(44, 12);
			label5.TabIndex = 5;
			label5.Text = "Current";
			label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
			label6.Location = new System.Drawing.Point(5, 186);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(38, 12);
			label6.TabIndex = 6;
			label6.Text = "Value:";
			txtValue.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			txtValue.BackColor = System.Drawing.Color.White;
			txtValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			txtValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238);
			txtValue.Location = new System.Drawing.Point(7, 203);
			txtValue.Name = "txtValue";
			txtValue.ReadOnly = true;
			txtValue.Size = new System.Drawing.Size(88, 20);
			txtValue.TabIndex = 7;
			txtValue.Text = "";
			base.Controls.Add(tabControl1);
			base.Controls.Add(label6);
			base.Controls.Add(label5);
			base.Controls.Add(originalColorPanel);
			base.Controls.Add(label1);
			base.Controls.Add(txtValue);
			base.Controls.Add(previewColorPanel);
			base.Controls.Add(button1);
			base.Controls.Add(btnUse);
			base.Name = "ColorUIEditorCtrl";
			base.Size = new System.Drawing.Size(337, 228);
			tabControl1.ResumeLayout(false);
			tabPage2.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)txtBlue).EndInit();
			((System.ComponentModel.ISupportInitialize)txtGreen).EndInit();
			((System.ComponentModel.ISupportInitialize)txtRed).EndInit();
			((System.ComponentModel.ISupportInitialize)txtS).EndInit();
			((System.ComponentModel.ISupportInitialize)txtL).EndInit();
			((System.ComponentModel.ISupportInitialize)txtH).EndInit();
			ResumeLayout(false);
		}

		private void AddColoursToList(ListBox in_listBox, Type in_colourSource, Color in_selectMe)
		{
			PropertyInfo[] properties = in_colourSource.GetProperties();
			PropertyInfo[] array = properties;
			foreach (PropertyInfo propertyInfo in array)
			{
				if (propertyInfo.PropertyType == typeof(Color))
				{
					ColourAndNameListItem colourAndNameListItem = new ColourAndNameListItem();
					colourAndNameListItem.Colour = (Color)propertyInfo.GetValue(null, null);
					colourAndNameListItem.Name = propertyInfo.Name;
					int selectedIndex = in_listBox.Items.Add(colourAndNameListItem);
					if (in_selectMe.Equals(colourAndNameListItem.Colour))
					{
						in_listBox.SelectedIndex = selectedIndex;
					}
				}
			}
		}

		private void AddNamedColors()
		{
			AddColourToList(lstColors, Color.Transparent);
			AddColourToList(lstColors, Color.Black);
			AddColourToList(lstColors, Color.DimGray);
			AddColourToList(lstColors, Color.Gray);
			AddColourToList(lstColors, Color.DarkGray);
			AddColourToList(lstColors, Color.Silver);
			AddColourToList(lstColors, Color.LightGray);
			AddColourToList(lstColors, Color.Gainsboro);
			AddColourToList(lstColors, Color.WhiteSmoke);
			AddColourToList(lstColors, Color.White);
			AddColourToList(lstColors, Color.RosyBrown);
			AddColourToList(lstColors, Color.IndianRed);
			AddColourToList(lstColors, Color.Brown);
			AddColourToList(lstColors, Color.Firebrick);
			AddColourToList(lstColors, Color.LightCoral);
			AddColourToList(lstColors, Color.Maroon);
			AddColourToList(lstColors, Color.DarkRed);
			AddColourToList(lstColors, Color.Red);
			AddColourToList(lstColors, Color.Snow);
			AddColourToList(lstColors, Color.MistyRose);
			AddColourToList(lstColors, Color.Salmon);
			AddColourToList(lstColors, Color.Tomato);
			AddColourToList(lstColors, Color.DarkSalmon);
			AddColourToList(lstColors, Color.Coral);
			AddColourToList(lstColors, Color.OrangeRed);
			AddColourToList(lstColors, Color.LightSalmon);
			AddColourToList(lstColors, Color.Sienna);
			AddColourToList(lstColors, Color.SeaShell);
			AddColourToList(lstColors, Color.Chocolate);
			AddColourToList(lstColors, Color.SaddleBrown);
			AddColourToList(lstColors, Color.SandyBrown);
			AddColourToList(lstColors, Color.PeachPuff);
			AddColourToList(lstColors, Color.Peru);
			AddColourToList(lstColors, Color.Linen);
			AddColourToList(lstColors, Color.Bisque);
			AddColourToList(lstColors, Color.DarkOrange);
			AddColourToList(lstColors, Color.BurlyWood);
			AddColourToList(lstColors, Color.Tan);
			AddColourToList(lstColors, Color.AntiqueWhite);
			AddColourToList(lstColors, Color.NavajoWhite);
			AddColourToList(lstColors, Color.BlanchedAlmond);
			AddColourToList(lstColors, Color.PapayaWhip);
			AddColourToList(lstColors, Color.Moccasin);
			AddColourToList(lstColors, Color.Orange);
			AddColourToList(lstColors, Color.Wheat);
			AddColourToList(lstColors, Color.OldLace);
			AddColourToList(lstColors, Color.FloralWhite);
			AddColourToList(lstColors, Color.DarkGoldenrod);
			AddColourToList(lstColors, Color.Goldenrod);
			AddColourToList(lstColors, Color.Cornsilk);
			AddColourToList(lstColors, Color.Gold);
			AddColourToList(lstColors, Color.Khaki);
			AddColourToList(lstColors, Color.LemonChiffon);
			AddColourToList(lstColors, Color.PaleGoldenrod);
			AddColourToList(lstColors, Color.DarkKhaki);
			AddColourToList(lstColors, Color.LightGray);
			AddColourToList(lstColors, Color.Beige);
			AddColourToList(lstColors, Color.LightGoldenrodYellow);
			AddColourToList(lstColors, Color.Olive);
			AddColourToList(lstColors, Color.Yellow);
			AddColourToList(lstColors, Color.LightYellow);
			AddColourToList(lstColors, Color.Ivory);
			AddColourToList(lstColors, Color.OliveDrab);
			AddColourToList(lstColors, Color.YellowGreen);
			AddColourToList(lstColors, Color.DarkOliveGreen);
			AddColourToList(lstColors, Color.GreenYellow);
			AddColourToList(lstColors, Color.Chartreuse);
			AddColourToList(lstColors, Color.LawnGreen);
			AddColourToList(lstColors, Color.DarkSeaGreen);
			AddColourToList(lstColors, Color.ForestGreen);
			AddColourToList(lstColors, Color.LimeGreen);
			AddColourToList(lstColors, Color.LightGreen);
			AddColourToList(lstColors, Color.PaleGreen);
			AddColourToList(lstColors, Color.DarkGreen);
			AddColourToList(lstColors, Color.Green);
			AddColourToList(lstColors, Color.Lime);
			AddColourToList(lstColors, Color.Honeydew);
			AddColourToList(lstColors, Color.SeaGreen);
			AddColourToList(lstColors, Color.MediumSeaGreen);
			AddColourToList(lstColors, Color.SpringGreen);
			AddColourToList(lstColors, Color.MintCream);
			AddColourToList(lstColors, Color.MediumSpringGreen);
			AddColourToList(lstColors, Color.MediumAquamarine);
			AddColourToList(lstColors, Color.Aquamarine);
			AddColourToList(lstColors, Color.Turquoise);
			AddColourToList(lstColors, Color.LightSeaGreen);
			AddColourToList(lstColors, Color.MediumTurquoise);
			AddColourToList(lstColors, Color.DarkSlateBlue);
			AddColourToList(lstColors, Color.PaleTurquoise);
			AddColourToList(lstColors, Color.Teal);
			AddColourToList(lstColors, Color.DarkCyan);
			AddColourToList(lstColors, Color.Aqua);
			AddColourToList(lstColors, Color.Cyan);
			AddColourToList(lstColors, Color.LightCyan);
			AddColourToList(lstColors, Color.Azure);
			AddColourToList(lstColors, Color.DarkTurquoise);
			AddColourToList(lstColors, Color.CadetBlue);
			AddColourToList(lstColors, Color.PowderBlue);
			AddColourToList(lstColors, Color.LightBlue);
			AddColourToList(lstColors, Color.DeepSkyBlue);
			AddColourToList(lstColors, Color.SkyBlue);
			AddColourToList(lstColors, Color.LightSkyBlue);
			AddColourToList(lstColors, Color.SteelBlue);
			AddColourToList(lstColors, Color.AliceBlue);
			AddColourToList(lstColors, Color.DodgerBlue);
			AddColourToList(lstColors, Color.SlateGray);
			AddColourToList(lstColors, Color.LightSlateGray);
			AddColourToList(lstColors, Color.LightSteelBlue);
			AddColourToList(lstColors, Color.CornflowerBlue);
			AddColourToList(lstColors, Color.RoyalBlue);
			AddColourToList(lstColors, Color.MidnightBlue);
			AddColourToList(lstColors, Color.Lavender);
			AddColourToList(lstColors, Color.Navy);
			AddColourToList(lstColors, Color.DarkBlue);
			AddColourToList(lstColors, Color.MediumBlue);
			AddColourToList(lstColors, Color.Blue);
			AddColourToList(lstColors, Color.GhostWhite);
			AddColourToList(lstColors, Color.SlateBlue);
			AddColourToList(lstColors, Color.DarkSlateBlue);
			AddColourToList(lstColors, Color.MediumSlateBlue);
			AddColourToList(lstColors, Color.MediumPurple);
			AddColourToList(lstColors, Color.BlueViolet);
			AddColourToList(lstColors, Color.Indigo);
			AddColourToList(lstColors, Color.DarkOrchid);
			AddColourToList(lstColors, Color.DarkViolet);
			AddColourToList(lstColors, Color.MediumOrchid);
			AddColourToList(lstColors, Color.Thistle);
			AddColourToList(lstColors, Color.Plum);
			AddColourToList(lstColors, Color.Violet);
			AddColourToList(lstColors, Color.Purple);
			AddColourToList(lstColors, Color.DarkMagenta);
			AddColourToList(lstColors, Color.Magenta);
			AddColourToList(lstColors, Color.Fuchsia);
			AddColourToList(lstColors, Color.Orchid);
			AddColourToList(lstColors, Color.MediumVioletRed);
			AddColourToList(lstColors, Color.DeepPink);
			AddColourToList(lstColors, Color.HotPink);
			AddColourToList(lstColors, Color.LavenderBlush);
			AddColourToList(lstColors, Color.PaleVioletRed);
			AddColourToList(lstColors, Color.Crimson);
			AddColourToList(lstColors, Color.Pink);
			AddColourToList(lstColors, Color.LightPink);
		}

		private void AddColourToList(ListBox in_listBox, Color color)
		{
			ColourAndNameListItem colourAndNameListItem = new ColourAndNameListItem();
			colourAndNameListItem.Colour = color;
			colourAndNameListItem.Name = color.Name;
			in_listBox.Items.Add(colourAndNameListItem);
		}

		private void PaletteColorPick(object sender, EventArgs e)
		{
			Value = ((ColorUIEditorPaletteCtrl.ColorPickEventArgs)e).Color;
			m_PaletteLightCtrl.Color = Value;
		}

		private void lstColors_DrawItem(object sender, DrawItemEventArgs e)
		{
			DrawItemForListBox(sender as ListBox, e);
		}

		private void CustomColorPick(object sender, EventArgs e)
		{
			Value = ((ColorUIEditorPaletteCtrl.ColorPickEventArgs)e).Color;
			m_PaletteLightCtrl.Color = Value;
		}

		private void DrawItemForListBox(ListBox in_listBox, DrawItemEventArgs in_args)
		{
			SolidBrush solidBrush = null;
			Pen pen = null;
			in_args.DrawBackground();
			Graphics graphics = in_args.Graphics;
			Rectangle bounds = in_args.Bounds;
			ColourAndNameListItem colourAndNameListItem = in_listBox.Items[in_args.Index] as ColourAndNameListItem;
			try
			{
				solidBrush = new SolidBrush(colourAndNameListItem.Colour);
				pen = new Pen(Color.Black);
				graphics.FillRectangle(solidBrush, bounds.Left + 2, bounds.Top + 2, 22, in_listBox.ItemHeight - 4);
				graphics.DrawRectangle(pen, bounds.Left + 2, bounds.Top + 2, 22, in_listBox.ItemHeight - 4);
			}
			finally
			{
				solidBrush?.Dispose();
				pen?.Dispose();
			}
			try
			{
				solidBrush = ((in_args.State != DrawItemState.Selected) ? new SolidBrush(SystemColors.ControlText) : new SolidBrush(in_listBox.BackColor));
				graphics.DrawString(colourAndNameListItem.Name, in_listBox.Font, solidBrush, bounds.Left + 26, in_args.Bounds.Top);
			}
			finally
			{
				solidBrush?.Dispose();
			}
		}

		private void lstSystemColors_MeasureItem(object sender, MeasureItemEventArgs e)
		{
			e.ItemHeight = 14;
		}

		private void lstSystemColors_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!m_InternalValueChange)
			{
				m_InternalValueChange = true;
				ColourAndNameListItem colourAndNameListItem = lstSystemColors.SelectedItem as ColourAndNameListItem;
				ColorManager.HLS hLS = ColorManager.RGB_to_HLS(colourAndNameListItem.Colour);
				txtH.Value = (int)(hLS.H * 100.0);
				txtL.Value = (int)(hLS.L * 100.0);
				txtS.Value = (int)(hLS.S * 100.0);
				previewColorPanel.BackColor = colourAndNameListItem.Colour;
				txtRed.Value = previewColorPanel.BackColor.R;
				txtGreen.Value = previewColorPanel.BackColor.G;
				txtBlue.Value = previewColorPanel.BackColor.B;
				txtValue.Text = "#" + previewColorPanel.BackColor.R.ToString("X2") + previewColorPanel.BackColor.G.ToString("X2") + previewColorPanel.BackColor.B.ToString("X2");
				m_InternalValueChange = false;
			}
		}

		private void lstColors_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!m_InternalValueChange)
			{
				m_InternalValueChange = true;
				ColourAndNameListItem colourAndNameListItem = lstColors.SelectedItem as ColourAndNameListItem;
				ColorManager.HLS hLS = ColorManager.RGB_to_HLS(colourAndNameListItem.Colour);
				txtH.Value = (int)(hLS.H * 100.0);
				txtL.Value = (int)(hLS.L * 100.0);
				txtS.Value = (int)(hLS.S * 100.0);
				previewColorPanel.BackColor = colourAndNameListItem.Colour;
				txtRed.Value = previewColorPanel.BackColor.R;
				txtGreen.Value = previewColorPanel.BackColor.G;
				txtBlue.Value = previewColorPanel.BackColor.B;
				txtValue.Text = "#" + previewColorPanel.BackColor.R.ToString("X2") + previewColorPanel.BackColor.G.ToString("X2") + previewColorPanel.BackColor.B.ToString("X2");
				m_InternalValueChange = false;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (m_EditorService != null)
			{
				m_EditorService.CloseDropDown();
			}
			if (this.OKClick != null)
			{
				this.OKClick(this, EventArgs.Empty);
			}
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			previewColorPanel.BackColor = m_OriginalColor;
			if (m_EditorService != null)
			{
				m_EditorService.CloseDropDown();
			}
			if (this.CancelClick != null)
			{
				this.CancelClick(this, EventArgs.Empty);
			}
		}

		private void radioButton2_Click(object sender, EventArgs e)
		{
			txtH.Visible = true;
			txtL.Visible = true;
			txtS.Visible = true;
			lblHue.Visible = true;
			lblLight.Visible = true;
			lblSaturation.Visible = true;
			txtRed.Visible = false;
			txtGreen.Visible = false;
			txtBlue.Visible = false;
			lblRed.Visible = false;
			lblGreen.Visible = false;
			lblBlue.Visible = false;
		}

		private void radioButton1_Click(object sender, EventArgs e)
		{
			txtH.Visible = false;
			txtL.Visible = false;
			txtS.Visible = false;
			lblHue.Visible = false;
			lblLight.Visible = false;
			lblSaturation.Visible = false;
			txtRed.Visible = true;
			txtGreen.Visible = true;
			txtBlue.Visible = true;
			lblRed.Visible = true;
			lblGreen.Visible = true;
			lblBlue.Visible = true;
		}

		private void txtBlue_ValueChanged(object sender, EventArgs e)
		{
			if (!m_InternalValueChange)
			{
				m_InternalValueChange = true;
				Color color = Color.FromArgb((int)txtRed.Value, (int)txtGreen.Value, (int)txtBlue.Value);
				ColorManager.HLS hLS = ColorManager.RGB_to_HLS(color);
				txtH.Value = (int)(hLS.H * 100.0);
				txtL.Value = (int)(hLS.L * 100.0);
				txtS.Value = (int)(hLS.S * 100.0);
				previewColorPanel.BackColor = color;
				txtValue.Text = "#" + previewColorPanel.BackColor.R.ToString("X2") + previewColorPanel.BackColor.G.ToString("X2") + previewColorPanel.BackColor.B.ToString("X2");
				m_InternalValueChange = false;
			}
		}

		private void previewColorPanel_BackColorChanged(object sender, EventArgs e)
		{
			if (m_PaletteLightCtrl != null)
			{
				m_PaletteLightCtrl.Color = Value;
			}
		}

		private void txtHSL_ValueChanged(object sender, EventArgs e)
		{
			if (!m_InternalValueChange)
			{
				m_InternalValueChange = true;
				ColorManager.HLS hLS = new ColorManager.HLS();
				hLS.H = (double)txtH.Value / 100.0;
				hLS.L = (double)txtL.Value / 100.0;
				hLS.S = (double)txtS.Value / 100.0;
				Color backColor = ColorManager.HLS_to_RGB(hLS);
				previewColorPanel.BackColor = backColor;
				txtRed.Value = previewColorPanel.BackColor.R;
				txtGreen.Value = previewColorPanel.BackColor.G;
				txtBlue.Value = previewColorPanel.BackColor.B;
				txtValue.Text = "#" + previewColorPanel.BackColor.R.ToString("X2") + previewColorPanel.BackColor.G.ToString("X2") + previewColorPanel.BackColor.B.ToString("X2");
				m_InternalValueChange = false;
			}
		}
	}
}
