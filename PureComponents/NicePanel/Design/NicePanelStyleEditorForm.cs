using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace PureComponents.NicePanel.Design
{
	internal class NicePanelStyleEditorForm : Form
	{
		private NicePanelDesigner m_Designer = null;

		private PanelStyle m_Style = null;

		private bool m_HeaderVisible;

		private bool m_FooterVisible;

		private GroupBox groupBox1;

		private GroupBox groupBox2;

		private GroupBox groupBox3;

		private Label label1;

		private Label label2;

		private Label label3;

		private TabControl tabControl1;

		private TabPage tabPage1;

		private TabPage tabPage2;

		private TabPage tabPage3;

		private Label label4;

		private Label label5;

		private Label label6;

		private Label label7;

		private Label label8;

		private Label label9;

		private GroupBox groupBox4;

		private Label label10;

		private GroupBox groupBox5;

		private GroupBox groupBox6;

		private GroupBox groupBox7;

		private GroupBox groupBox8;

		private GroupBox groupBox9;

		private Label label12;

		private Label label13;

		private Label label14;

		private Label label15;

		private Label label16;

		private Label label17;

		private ToolTip toolTip1;

		private RadioButton ContainerBorderStyle4;

		private RadioButton ContainerBorderStyle3;

		private RadioButton ContainerBorderStyle2;

		private RadioButton ContainerBorderStyle1;

		private RadioButton ContainerShape3;

		private RadioButton ContainerShape2;

		private RadioButton ContainerShape1;

		private RadioButton ContainerFillStyle5;

		private RadioButton ContainerFillStyle4;

		private RadioButton ContainerFillStyle3;

		private RadioButton ContainerFillStyle2;

		private RadioButton ContainerFillStyle1;

		private Button ContainerBorderColor;

		private Button HeaderFont;

		private RadioButton HeaderSize3;

		private RadioButton HeaderSize2;

		private RadioButton HeaderSize1;

		private RadioButton HeaderTextAlign9;

		private RadioButton HeaderTextAlign8;

		private RadioButton HeaderTextAlign7;

		private RadioButton HeaderTextAlign6;

		private RadioButton HeaderTextAlign5;

		private RadioButton HeaderTextAlign4;

		private RadioButton HeaderTextAlign3;

		private RadioButton HeaderTextAlign2;

		private RadioButton HeaderTextAlign1;

		private Button HeaderButtonColor;

		private RadioButton HeaderFillStyle5;

		private RadioButton HeaderFillStyle4;

		private RadioButton HeaderFillStyle3;

		private RadioButton HeaderFillStyle2;

		private RadioButton HeaderFillStyle1;

		private Button HeaderFlashFadeColor;

		private Button HeaderFlashForeColor;

		private Button HeaderFlashBackColor;

		private Button HeaderFadeColor;

		private Button HeaderForeColor;

		private Button HeaderBackColor;

		private CheckBox HeaderVisible;

		private Button ContainerFadeColor;

		private Button ContainerBackColor;

		private RadioButton FooterFillStyle3;

		private RadioButton FooterFillStyle2;

		private RadioButton FooterFillStyle1;

		private Button FooterFont;

		private RadioButton FooterSize3;

		private RadioButton FooterSize2;

		private RadioButton FooterSize1;

		private RadioButton FooterTextAlign9;

		private RadioButton FooterTextAlign8;

		private RadioButton FooterTextAlign7;

		private RadioButton FooterTextAlign6;

		private RadioButton FooterTextAlign5;

		private RadioButton FooterTextAlign4;

		private RadioButton FooterTextAlign3;

		private RadioButton FooterTextAlign2;

		private RadioButton FooterTextAlign1;

		private RadioButton FooterFillStyle5;

		private RadioButton FooterFillStyle4;

		private Button FooterFlashFadeColor;

		private Button FooterFlashForeColor;

		private Button FooterFlashBackColor;

		private Button FooterFadeColor;

		private Button FooterForeColor;

		private Button FooterBackColor;

		private CheckBox FooterVisible;

		private Button OK;

		private Button Cancel;

		private Button Apply;

		private Label label11;

		private Button ContainerBaseColor;

		private Label label18;

		private Button ContainerForeColor;

		private Label label19;

		private Button ContainerFlashItemBackColor;

		private Label label20;

		private Button ContainerFocusItemBackColor;

		private GroupBox groupBox10;

		private RadioButton ContainerCaptionAlign1;

		private RadioButton ContainerCaptionAlign2;

		private IContainer components;

		public NicePanelStyleEditorForm(NicePanelDesigner designer, int selectedIndex)
		{
			InitializeComponent();
			m_Designer = designer;
			m_Style = new PanelStyle();
			m_HeaderVisible = m_Designer.NicePanel.HeaderVisible;
			m_FooterVisible = m_Designer.NicePanel.FooterVisible;
			m_Designer.NicePanel.Style.SetPanel(m_Designer.NicePanel);
			m_Style.SetPanel(m_Designer.NicePanel);
			m_Style.HeaderStyle.BackColor = m_Designer.NicePanel.Style.HeaderStyle.BackColor;
			m_Style.HeaderStyle.ButtonColor = m_Designer.NicePanel.Style.HeaderStyle.ButtonColor;
			m_Style.HeaderStyle.FadeColor = m_Designer.NicePanel.Style.HeaderStyle.FadeColor;
			m_Style.HeaderStyle.FillStyle = m_Designer.NicePanel.Style.HeaderStyle.FillStyle;
			m_Style.HeaderStyle.FlashBackColor = m_Designer.NicePanel.Style.HeaderStyle.FlashBackColor;
			m_Style.HeaderStyle.FlashFadeColor = m_Designer.NicePanel.Style.HeaderStyle.FlashFadeColor;
			m_Style.HeaderStyle.FlashForeColor = m_Designer.NicePanel.Style.HeaderStyle.FlashForeColor;
			m_Style.HeaderStyle.Font = m_Designer.NicePanel.Style.HeaderStyle.Font;
			m_Style.HeaderStyle.ForeColor = m_Designer.NicePanel.Style.HeaderStyle.ForeColor;
			m_Style.HeaderStyle.Size = m_Designer.NicePanel.Style.HeaderStyle.Size;
			m_Style.HeaderStyle.TextAlign = m_Designer.NicePanel.Style.HeaderStyle.TextAlign;
			m_Style.ContainerStyle.BackColor = m_Designer.NicePanel.Style.ContainerStyle.BackColor;
			m_Style.ContainerStyle.BaseColor = m_Designer.NicePanel.BackColor;
			m_Style.ContainerStyle.ForeColor = m_Designer.NicePanel.ForeColor;
			m_Style.ContainerStyle.BorderColor = m_Designer.NicePanel.Style.ContainerStyle.BorderColor;
			m_Style.ContainerStyle.BorderStyle = m_Designer.NicePanel.Style.ContainerStyle.BorderStyle;
			m_Style.ContainerStyle.FadeColor = m_Designer.NicePanel.Style.ContainerStyle.FadeColor;
			m_Style.ContainerStyle.FillStyle = m_Designer.NicePanel.Style.ContainerStyle.FillStyle;
			m_Style.ContainerStyle.Shape = m_Designer.NicePanel.Style.ContainerStyle.Shape;
			m_Style.ContainerStyle.FlashItemBackColor = m_Designer.NicePanel.Style.ContainerStyle.FlashItemBackColor;
			m_Style.ContainerStyle.FocusItemBackColor = m_Designer.NicePanel.Style.ContainerStyle.FocusItemBackColor;
			m_Style.FooterStyle.BackColor = m_Designer.NicePanel.Style.FooterStyle.BackColor;
			m_Style.FooterStyle.ButtonColor = m_Designer.NicePanel.Style.FooterStyle.ButtonColor;
			m_Style.FooterStyle.FadeColor = m_Designer.NicePanel.Style.FooterStyle.FadeColor;
			m_Style.FooterStyle.FillStyle = m_Designer.NicePanel.Style.FooterStyle.FillStyle;
			m_Style.FooterStyle.FlashBackColor = m_Designer.NicePanel.Style.FooterStyle.FlashBackColor;
			m_Style.FooterStyle.FlashFadeColor = m_Designer.NicePanel.Style.FooterStyle.FlashFadeColor;
			m_Style.FooterStyle.FlashForeColor = m_Designer.NicePanel.Style.FooterStyle.FlashForeColor;
			m_Style.FooterStyle.Font = m_Designer.NicePanel.Style.FooterStyle.Font;
			m_Style.FooterStyle.ForeColor = m_Designer.NicePanel.Style.FooterStyle.ForeColor;
			m_Style.FooterStyle.Size = m_Designer.NicePanel.Style.FooterStyle.Size;
			m_Style.FooterStyle.TextAlign = m_Designer.NicePanel.Style.FooterStyle.TextAlign;
			HeaderBackColor.BackColor = m_Style.HeaderStyle.BackColor;
			HeaderFadeColor.BackColor = m_Style.HeaderStyle.FadeColor;
			HeaderButtonColor.BackColor = m_Style.HeaderStyle.ButtonColor;
			HeaderForeColor.BackColor = m_Style.HeaderStyle.FadeColor;
			HeaderFlashBackColor.BackColor = m_Style.HeaderStyle.FlashBackColor;
			HeaderFlashFadeColor.BackColor = m_Style.HeaderStyle.FlashFadeColor;
			HeaderFlashForeColor.BackColor = m_Style.HeaderStyle.FlashForeColor;
			HeaderForeColor.BackColor = m_Style.HeaderStyle.ForeColor;
			switch (m_Style.HeaderStyle.FillStyle)
			{
			case FillStyle.Flat:
				HeaderFillStyle1.Checked = true;
				break;
			case FillStyle.HorizontalFading:
				HeaderFillStyle2.Checked = true;
				break;
			case FillStyle.VerticalFading:
				HeaderFillStyle3.Checked = true;
				break;
			case FillStyle.DiagonalForward:
				HeaderFillStyle4.Checked = true;
				break;
			case FillStyle.DiagonalBackward:
				HeaderFillStyle5.Checked = true;
				break;
			}
			switch (m_Style.HeaderStyle.Size)
			{
			case PanelHeaderSize.Small:
				HeaderSize1.Checked = true;
				break;
			case PanelHeaderSize.Medium:
				HeaderSize2.Checked = true;
				break;
			case PanelHeaderSize.Large:
				HeaderSize3.Checked = true;
				break;
			}
			switch (m_Style.HeaderStyle.TextAlign)
			{
			case ContentAlignment.TopLeft:
				HeaderTextAlign1.Checked = true;
				break;
			case ContentAlignment.TopCenter:
				HeaderTextAlign2.Checked = true;
				break;
			case ContentAlignment.TopRight:
				HeaderTextAlign3.Checked = true;
				break;
			case ContentAlignment.MiddleLeft:
				HeaderTextAlign4.Checked = true;
				break;
			case ContentAlignment.MiddleCenter:
				HeaderTextAlign5.Checked = true;
				break;
			case ContentAlignment.MiddleRight:
				HeaderTextAlign6.Checked = true;
				break;
			case ContentAlignment.BottomLeft:
				HeaderTextAlign7.Checked = true;
				break;
			case ContentAlignment.BottomCenter:
				HeaderTextAlign8.Checked = true;
				break;
			case ContentAlignment.BottomRight:
				HeaderTextAlign9.Checked = true;
				break;
			}
			HeaderVisible.Checked = m_Designer.NicePanel.HeaderVisible;
			FooterBackColor.BackColor = m_Style.FooterStyle.BackColor;
			FooterFadeColor.BackColor = m_Style.FooterStyle.FadeColor;
			FooterForeColor.BackColor = m_Style.FooterStyle.FadeColor;
			FooterFlashBackColor.BackColor = m_Style.FooterStyle.FlashBackColor;
			FooterFlashFadeColor.BackColor = m_Style.FooterStyle.FlashFadeColor;
			FooterFlashForeColor.BackColor = m_Style.FooterStyle.FlashForeColor;
			FooterForeColor.BackColor = m_Style.FooterStyle.ForeColor;
			switch (m_Style.FooterStyle.FillStyle)
			{
			case FillStyle.Flat:
				FooterFillStyle1.Checked = true;
				break;
			case FillStyle.HorizontalFading:
				FooterFillStyle2.Checked = true;
				break;
			case FillStyle.VerticalFading:
				FooterFillStyle3.Checked = true;
				break;
			case FillStyle.DiagonalForward:
				FooterFillStyle4.Checked = true;
				break;
			case FillStyle.DiagonalBackward:
				FooterFillStyle5.Checked = true;
				break;
			}
			switch (m_Style.FooterStyle.Size)
			{
			case PanelHeaderSize.Small:
				FooterSize1.Checked = true;
				break;
			case PanelHeaderSize.Medium:
				FooterSize2.Checked = true;
				break;
			case PanelHeaderSize.Large:
				FooterSize3.Checked = true;
				break;
			}
			switch (m_Style.FooterStyle.TextAlign)
			{
			case ContentAlignment.TopLeft:
				FooterTextAlign1.Checked = true;
				break;
			case ContentAlignment.TopCenter:
				FooterTextAlign2.Checked = true;
				break;
			case ContentAlignment.TopRight:
				FooterTextAlign3.Checked = true;
				break;
			case ContentAlignment.MiddleLeft:
				FooterTextAlign4.Checked = true;
				break;
			case ContentAlignment.MiddleCenter:
				FooterTextAlign5.Checked = true;
				break;
			case ContentAlignment.MiddleRight:
				FooterTextAlign6.Checked = true;
				break;
			case ContentAlignment.BottomLeft:
				FooterTextAlign7.Checked = true;
				break;
			case ContentAlignment.BottomCenter:
				FooterTextAlign8.Checked = true;
				break;
			case ContentAlignment.BottomRight:
				FooterTextAlign9.Checked = true;
				break;
			}
			FooterVisible.Checked = m_Designer.NicePanel.FooterVisible;
			ContainerBackColor.BackColor = m_Style.ContainerStyle.BackColor;
			ContainerBaseColor.BackColor = m_Style.ContainerStyle.BaseColor;
			ContainerForeColor.BackColor = m_Style.ContainerStyle.ForeColor;
			ContainerBorderColor.BackColor = m_Style.ContainerStyle.BorderColor;
			ContainerFadeColor.BackColor = m_Style.ContainerStyle.FadeColor;
			ContainerFlashItemBackColor.BackColor = m_Style.ContainerStyle.FlashItemBackColor;
			ContainerFocusItemBackColor.BackColor = m_Style.ContainerStyle.FocusItemBackColor;
			switch (m_Style.ContainerStyle.CaptionAlign)
			{
			case CaptionAlign.Left:
				ContainerCaptionAlign1.Checked = true;
				break;
			case CaptionAlign.Top:
				ContainerCaptionAlign2.Checked = true;
				break;
			}
			switch (m_Style.ContainerStyle.BorderStyle)
			{
			case BorderStyle.None:
				ContainerBorderStyle1.Checked = true;
				break;
			case BorderStyle.Dot:
				ContainerBorderStyle2.Checked = true;
				break;
			case BorderStyle.Solid:
				ContainerBorderStyle3.Checked = true;
				break;
			case BorderStyle.Double:
				ContainerBorderStyle4.Checked = true;
				break;
			}
			switch (m_Style.ContainerStyle.Shape)
			{
			case Shape.Squared:
				ContainerShape1.Checked = true;
				break;
			case Shape.Rounded:
				ContainerShape2.Checked = true;
				break;
			case Shape.Chamfered:
				ContainerShape3.Checked = true;
				break;
			}
			switch (m_Style.ContainerStyle.FillStyle)
			{
			case FillStyle.Flat:
				ContainerFillStyle1.Checked = true;
				break;
			case FillStyle.HorizontalFading:
				ContainerFillStyle2.Checked = true;
				break;
			case FillStyle.VerticalFading:
				ContainerFillStyle3.Checked = true;
				break;
			case FillStyle.DiagonalForward:
				ContainerFillStyle4.Checked = true;
				break;
			case FillStyle.DiagonalBackward:
				ContainerFillStyle5.Checked = true;
				break;
			}
			tabControl1.SelectedIndex = selectedIndex;
		}

		public NicePanelStyleEditorForm(NicePanelDesigner designer)
			: this(designer, 0)
		{
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
			components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager(typeof(PureComponents.NicePanel.Design.NicePanelStyleEditorForm));
			groupBox1 = new System.Windows.Forms.GroupBox();
			ContainerBorderStyle4 = new System.Windows.Forms.RadioButton();
			ContainerBorderStyle3 = new System.Windows.Forms.RadioButton();
			ContainerBorderStyle2 = new System.Windows.Forms.RadioButton();
			ContainerBorderStyle1 = new System.Windows.Forms.RadioButton();
			groupBox2 = new System.Windows.Forms.GroupBox();
			ContainerShape3 = new System.Windows.Forms.RadioButton();
			ContainerShape2 = new System.Windows.Forms.RadioButton();
			ContainerShape1 = new System.Windows.Forms.RadioButton();
			groupBox3 = new System.Windows.Forms.GroupBox();
			ContainerFillStyle5 = new System.Windows.Forms.RadioButton();
			ContainerFillStyle4 = new System.Windows.Forms.RadioButton();
			ContainerFillStyle3 = new System.Windows.Forms.RadioButton();
			ContainerFillStyle2 = new System.Windows.Forms.RadioButton();
			ContainerFillStyle1 = new System.Windows.Forms.RadioButton();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			ContainerBorderColor = new System.Windows.Forms.Button();
			tabControl1 = new System.Windows.Forms.TabControl();
			tabPage2 = new System.Windows.Forms.TabPage();
			label20 = new System.Windows.Forms.Label();
			ContainerFocusItemBackColor = new System.Windows.Forms.Button();
			label19 = new System.Windows.Forms.Label();
			ContainerFlashItemBackColor = new System.Windows.Forms.Button();
			label18 = new System.Windows.Forms.Label();
			ContainerForeColor = new System.Windows.Forms.Button();
			label11 = new System.Windows.Forms.Label();
			ContainerBaseColor = new System.Windows.Forms.Button();
			ContainerFadeColor = new System.Windows.Forms.Button();
			ContainerBackColor = new System.Windows.Forms.Button();
			groupBox10 = new System.Windows.Forms.GroupBox();
			ContainerCaptionAlign1 = new System.Windows.Forms.RadioButton();
			ContainerCaptionAlign2 = new System.Windows.Forms.RadioButton();
			tabPage1 = new System.Windows.Forms.TabPage();
			HeaderFont = new System.Windows.Forms.Button();
			groupBox6 = new System.Windows.Forms.GroupBox();
			HeaderSize3 = new System.Windows.Forms.RadioButton();
			HeaderSize2 = new System.Windows.Forms.RadioButton();
			HeaderSize1 = new System.Windows.Forms.RadioButton();
			groupBox5 = new System.Windows.Forms.GroupBox();
			HeaderTextAlign9 = new System.Windows.Forms.RadioButton();
			HeaderTextAlign8 = new System.Windows.Forms.RadioButton();
			HeaderTextAlign7 = new System.Windows.Forms.RadioButton();
			HeaderTextAlign6 = new System.Windows.Forms.RadioButton();
			HeaderTextAlign5 = new System.Windows.Forms.RadioButton();
			HeaderTextAlign4 = new System.Windows.Forms.RadioButton();
			HeaderTextAlign3 = new System.Windows.Forms.RadioButton();
			HeaderTextAlign2 = new System.Windows.Forms.RadioButton();
			HeaderTextAlign1 = new System.Windows.Forms.RadioButton();
			label10 = new System.Windows.Forms.Label();
			HeaderButtonColor = new System.Windows.Forms.Button();
			groupBox4 = new System.Windows.Forms.GroupBox();
			HeaderFillStyle5 = new System.Windows.Forms.RadioButton();
			HeaderFillStyle4 = new System.Windows.Forms.RadioButton();
			HeaderFillStyle3 = new System.Windows.Forms.RadioButton();
			HeaderFillStyle2 = new System.Windows.Forms.RadioButton();
			HeaderFillStyle1 = new System.Windows.Forms.RadioButton();
			label7 = new System.Windows.Forms.Label();
			HeaderFlashFadeColor = new System.Windows.Forms.Button();
			HeaderFlashForeColor = new System.Windows.Forms.Button();
			label8 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			HeaderFlashBackColor = new System.Windows.Forms.Button();
			label4 = new System.Windows.Forms.Label();
			HeaderFadeColor = new System.Windows.Forms.Button();
			HeaderForeColor = new System.Windows.Forms.Button();
			label5 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			HeaderBackColor = new System.Windows.Forms.Button();
			HeaderVisible = new System.Windows.Forms.CheckBox();
			tabPage3 = new System.Windows.Forms.TabPage();
			FooterFont = new System.Windows.Forms.Button();
			groupBox7 = new System.Windows.Forms.GroupBox();
			FooterSize3 = new System.Windows.Forms.RadioButton();
			FooterSize2 = new System.Windows.Forms.RadioButton();
			FooterSize1 = new System.Windows.Forms.RadioButton();
			groupBox8 = new System.Windows.Forms.GroupBox();
			FooterTextAlign9 = new System.Windows.Forms.RadioButton();
			FooterTextAlign8 = new System.Windows.Forms.RadioButton();
			FooterTextAlign7 = new System.Windows.Forms.RadioButton();
			FooterTextAlign6 = new System.Windows.Forms.RadioButton();
			FooterTextAlign5 = new System.Windows.Forms.RadioButton();
			FooterTextAlign4 = new System.Windows.Forms.RadioButton();
			FooterTextAlign3 = new System.Windows.Forms.RadioButton();
			FooterTextAlign2 = new System.Windows.Forms.RadioButton();
			FooterTextAlign1 = new System.Windows.Forms.RadioButton();
			groupBox9 = new System.Windows.Forms.GroupBox();
			FooterFillStyle5 = new System.Windows.Forms.RadioButton();
			FooterFillStyle4 = new System.Windows.Forms.RadioButton();
			FooterFillStyle3 = new System.Windows.Forms.RadioButton();
			FooterFillStyle2 = new System.Windows.Forms.RadioButton();
			FooterFillStyle1 = new System.Windows.Forms.RadioButton();
			label12 = new System.Windows.Forms.Label();
			FooterFlashFadeColor = new System.Windows.Forms.Button();
			FooterFlashForeColor = new System.Windows.Forms.Button();
			label13 = new System.Windows.Forms.Label();
			label14 = new System.Windows.Forms.Label();
			FooterFlashBackColor = new System.Windows.Forms.Button();
			label15 = new System.Windows.Forms.Label();
			FooterFadeColor = new System.Windows.Forms.Button();
			FooterForeColor = new System.Windows.Forms.Button();
			label16 = new System.Windows.Forms.Label();
			label17 = new System.Windows.Forms.Label();
			FooterBackColor = new System.Windows.Forms.Button();
			FooterVisible = new System.Windows.Forms.CheckBox();
			toolTip1 = new System.Windows.Forms.ToolTip(components);
			OK = new System.Windows.Forms.Button();
			Cancel = new System.Windows.Forms.Button();
			Apply = new System.Windows.Forms.Button();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox3.SuspendLayout();
			tabControl1.SuspendLayout();
			tabPage2.SuspendLayout();
			groupBox10.SuspendLayout();
			tabPage1.SuspendLayout();
			groupBox6.SuspendLayout();
			groupBox5.SuspendLayout();
			groupBox4.SuspendLayout();
			tabPage3.SuspendLayout();
			groupBox7.SuspendLayout();
			groupBox8.SuspendLayout();
			groupBox9.SuspendLayout();
			SuspendLayout();
			groupBox1.BackColor = System.Drawing.Color.Transparent;
			groupBox1.Controls.Add(ContainerBorderStyle4);
			groupBox1.Controls.Add(ContainerBorderStyle3);
			groupBox1.Controls.Add(ContainerBorderStyle2);
			groupBox1.Controls.Add(ContainerBorderStyle1);
			groupBox1.Location = new System.Drawing.Point(8, 125);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(136, 55);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "BorderStyle";
			ContainerBorderStyle4.Appearance = System.Windows.Forms.Appearance.Button;
			ContainerBorderStyle4.Image = (System.Drawing.Image)resourceManager.GetObject("ContainerBorderStyle4.Image");
			ContainerBorderStyle4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			ContainerBorderStyle4.Location = new System.Drawing.Point(96, 20);
			ContainerBorderStyle4.Name = "ContainerBorderStyle4";
			ContainerBorderStyle4.Size = new System.Drawing.Size(28, 28);
			ContainerBorderStyle4.TabIndex = 4;
			ContainerBorderStyle4.Tag = "Double";
			toolTip1.SetToolTip(ContainerBorderStyle4, "Double");
			ContainerBorderStyle4.CheckedChanged += new System.EventHandler(OnContainerBorderStyleCheckedChanged);
			ContainerBorderStyle3.Appearance = System.Windows.Forms.Appearance.Button;
			ContainerBorderStyle3.Checked = true;
			ContainerBorderStyle3.Image = (System.Drawing.Image)resourceManager.GetObject("ContainerBorderStyle3.Image");
			ContainerBorderStyle3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			ContainerBorderStyle3.Location = new System.Drawing.Point(68, 20);
			ContainerBorderStyle3.Name = "ContainerBorderStyle3";
			ContainerBorderStyle3.Size = new System.Drawing.Size(28, 28);
			ContainerBorderStyle3.TabIndex = 3;
			ContainerBorderStyle3.TabStop = true;
			ContainerBorderStyle3.Tag = "Solid";
			toolTip1.SetToolTip(ContainerBorderStyle3, "Solid");
			ContainerBorderStyle3.CheckedChanged += new System.EventHandler(OnContainerBorderStyleCheckedChanged);
			ContainerBorderStyle2.Appearance = System.Windows.Forms.Appearance.Button;
			ContainerBorderStyle2.Image = (System.Drawing.Image)resourceManager.GetObject("ContainerBorderStyle2.Image");
			ContainerBorderStyle2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			ContainerBorderStyle2.Location = new System.Drawing.Point(40, 20);
			ContainerBorderStyle2.Name = "ContainerBorderStyle2";
			ContainerBorderStyle2.Size = new System.Drawing.Size(28, 28);
			ContainerBorderStyle2.TabIndex = 2;
			ContainerBorderStyle2.Tag = "Dot";
			toolTip1.SetToolTip(ContainerBorderStyle2, "Dot");
			ContainerBorderStyle2.CheckedChanged += new System.EventHandler(OnContainerBorderStyleCheckedChanged);
			ContainerBorderStyle1.Appearance = System.Windows.Forms.Appearance.Button;
			ContainerBorderStyle1.Image = (System.Drawing.Image)resourceManager.GetObject("ContainerBorderStyle1.Image");
			ContainerBorderStyle1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			ContainerBorderStyle1.Location = new System.Drawing.Point(12, 20);
			ContainerBorderStyle1.Name = "ContainerBorderStyle1";
			ContainerBorderStyle1.Size = new System.Drawing.Size(28, 28);
			ContainerBorderStyle1.TabIndex = 1;
			ContainerBorderStyle1.Tag = "None";
			toolTip1.SetToolTip(ContainerBorderStyle1, "None");
			ContainerBorderStyle1.CheckedChanged += new System.EventHandler(OnContainerBorderStyleCheckedChanged);
			groupBox2.BackColor = System.Drawing.Color.Transparent;
			groupBox2.Controls.Add(ContainerShape3);
			groupBox2.Controls.Add(ContainerShape2);
			groupBox2.Controls.Add(ContainerShape1);
			groupBox2.Location = new System.Drawing.Point(8, 65);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(108, 55);
			groupBox2.TabIndex = 1;
			groupBox2.TabStop = false;
			groupBox2.Text = "Shape";
			ContainerShape3.Appearance = System.Windows.Forms.Appearance.Button;
			ContainerShape3.Image = (System.Drawing.Image)resourceManager.GetObject("ContainerShape3.Image");
			ContainerShape3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			ContainerShape3.Location = new System.Drawing.Point(68, 20);
			ContainerShape3.Name = "ContainerShape3";
			ContainerShape3.Size = new System.Drawing.Size(28, 28);
			ContainerShape3.TabIndex = 6;
			ContainerShape3.Tag = "Chamfered";
			toolTip1.SetToolTip(ContainerShape3, "Chamfered");
			ContainerShape3.CheckedChanged += new System.EventHandler(OnContainerShapeCheckedChanged);
			ContainerShape2.Appearance = System.Windows.Forms.Appearance.Button;
			ContainerShape2.Image = (System.Drawing.Image)resourceManager.GetObject("ContainerShape2.Image");
			ContainerShape2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			ContainerShape2.Location = new System.Drawing.Point(40, 20);
			ContainerShape2.Name = "ContainerShape2";
			ContainerShape2.Size = new System.Drawing.Size(28, 28);
			ContainerShape2.TabIndex = 5;
			ContainerShape2.Tag = "Rounded";
			toolTip1.SetToolTip(ContainerShape2, "Rounded");
			ContainerShape2.CheckedChanged += new System.EventHandler(OnContainerShapeCheckedChanged);
			ContainerShape1.Appearance = System.Windows.Forms.Appearance.Button;
			ContainerShape1.Checked = true;
			ContainerShape1.Image = (System.Drawing.Image)resourceManager.GetObject("ContainerShape1.Image");
			ContainerShape1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			ContainerShape1.Location = new System.Drawing.Point(12, 20);
			ContainerShape1.Name = "ContainerShape1";
			ContainerShape1.Size = new System.Drawing.Size(28, 28);
			ContainerShape1.TabIndex = 4;
			ContainerShape1.TabStop = true;
			ContainerShape1.Tag = "Squared";
			toolTip1.SetToolTip(ContainerShape1, "Squared");
			ContainerShape1.CheckedChanged += new System.EventHandler(OnContainerShapeCheckedChanged);
			groupBox3.BackColor = System.Drawing.Color.Transparent;
			groupBox3.Controls.Add(ContainerFillStyle5);
			groupBox3.Controls.Add(ContainerFillStyle4);
			groupBox3.Controls.Add(ContainerFillStyle3);
			groupBox3.Controls.Add(ContainerFillStyle2);
			groupBox3.Controls.Add(ContainerFillStyle1);
			groupBox3.Location = new System.Drawing.Point(8, 8);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(164, 57);
			groupBox3.TabIndex = 2;
			groupBox3.TabStop = false;
			groupBox3.Text = "FillStyle";
			ContainerFillStyle5.Appearance = System.Windows.Forms.Appearance.Button;
			ContainerFillStyle5.Image = (System.Drawing.Image)resourceManager.GetObject("ContainerFillStyle5.Image");
			ContainerFillStyle5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			ContainerFillStyle5.Location = new System.Drawing.Point(124, 20);
			ContainerFillStyle5.Name = "ContainerFillStyle5";
			ContainerFillStyle5.Size = new System.Drawing.Size(28, 28);
			ContainerFillStyle5.TabIndex = 17;
			ContainerFillStyle5.Tag = "DiagonalBackward";
			toolTip1.SetToolTip(ContainerFillStyle5, "DiagonalBackward");
			ContainerFillStyle5.CheckedChanged += new System.EventHandler(OnContainerFillStyleCheckedChanged);
			ContainerFillStyle4.Appearance = System.Windows.Forms.Appearance.Button;
			ContainerFillStyle4.Image = (System.Drawing.Image)resourceManager.GetObject("ContainerFillStyle4.Image");
			ContainerFillStyle4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			ContainerFillStyle4.Location = new System.Drawing.Point(96, 20);
			ContainerFillStyle4.Name = "ContainerFillStyle4";
			ContainerFillStyle4.Size = new System.Drawing.Size(28, 28);
			ContainerFillStyle4.TabIndex = 16;
			ContainerFillStyle4.Tag = "DiagonalForward";
			toolTip1.SetToolTip(ContainerFillStyle4, "DiagonalForward");
			ContainerFillStyle4.CheckedChanged += new System.EventHandler(OnContainerFillStyleCheckedChanged);
			ContainerFillStyle3.Appearance = System.Windows.Forms.Appearance.Button;
			ContainerFillStyle3.Image = (System.Drawing.Image)resourceManager.GetObject("ContainerFillStyle3.Image");
			ContainerFillStyle3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			ContainerFillStyle3.Location = new System.Drawing.Point(68, 20);
			ContainerFillStyle3.Name = "ContainerFillStyle3";
			ContainerFillStyle3.Size = new System.Drawing.Size(28, 28);
			ContainerFillStyle3.TabIndex = 15;
			ContainerFillStyle3.Tag = "VerticalFading";
			toolTip1.SetToolTip(ContainerFillStyle3, "VerticalFading");
			ContainerFillStyle3.CheckedChanged += new System.EventHandler(OnContainerFillStyleCheckedChanged);
			ContainerFillStyle2.Appearance = System.Windows.Forms.Appearance.Button;
			ContainerFillStyle2.Image = (System.Drawing.Image)resourceManager.GetObject("ContainerFillStyle2.Image");
			ContainerFillStyle2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			ContainerFillStyle2.Location = new System.Drawing.Point(40, 20);
			ContainerFillStyle2.Name = "ContainerFillStyle2";
			ContainerFillStyle2.Size = new System.Drawing.Size(28, 28);
			ContainerFillStyle2.TabIndex = 14;
			ContainerFillStyle2.Tag = "HorizontalFading";
			toolTip1.SetToolTip(ContainerFillStyle2, "HorizontalFading");
			ContainerFillStyle2.CheckedChanged += new System.EventHandler(OnContainerFillStyleCheckedChanged);
			ContainerFillStyle1.Appearance = System.Windows.Forms.Appearance.Button;
			ContainerFillStyle1.Checked = true;
			ContainerFillStyle1.Image = (System.Drawing.Image)resourceManager.GetObject("ContainerFillStyle1.Image");
			ContainerFillStyle1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			ContainerFillStyle1.Location = new System.Drawing.Point(12, 20);
			ContainerFillStyle1.Name = "ContainerFillStyle1";
			ContainerFillStyle1.Size = new System.Drawing.Size(28, 28);
			ContainerFillStyle1.TabIndex = 13;
			ContainerFillStyle1.TabStop = true;
			ContainerFillStyle1.Tag = "Flat";
			toolTip1.SetToolTip(ContainerFillStyle1, "Flat");
			ContainerFillStyle1.CheckedChanged += new System.EventHandler(OnContainerFillStyleCheckedChanged);
			label1.AutoSize = true;
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.Location = new System.Drawing.Point(205, 65);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(65, 16);
			label1.TabIndex = 4;
			label1.Text = "BorderColor";
			label2.AutoSize = true;
			label2.BackColor = System.Drawing.Color.Transparent;
			label2.Location = new System.Drawing.Point(205, 15);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(56, 16);
			label2.TabIndex = 6;
			label2.Text = "BackColor";
			label3.AutoSize = true;
			label3.BackColor = System.Drawing.Color.Transparent;
			label3.Location = new System.Drawing.Point(205, 40);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(57, 16);
			label3.TabIndex = 8;
			label3.Text = "FadeColor";
			ContainerBorderColor.BackColor = System.Drawing.Color.FromArgb(1, 45, 150);
			ContainerBorderColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			ContainerBorderColor.Location = new System.Drawing.Point(180, 60);
			ContainerBorderColor.Name = "ContainerBorderColor";
			ContainerBorderColor.Size = new System.Drawing.Size(20, 20);
			ContainerBorderColor.TabIndex = 7;
			ContainerBorderColor.Click += new System.EventHandler(OnContainerColorPick);
			tabControl1.Controls.Add(tabPage2);
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage3);
			tabControl1.Location = new System.Drawing.Point(4, 4);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new System.Drawing.Size(323, 280);
			tabControl1.TabIndex = 9;
			tabPage2.Controls.Add(label20);
			tabPage2.Controls.Add(ContainerFocusItemBackColor);
			tabPage2.Controls.Add(label19);
			tabPage2.Controls.Add(ContainerFlashItemBackColor);
			tabPage2.Controls.Add(label18);
			tabPage2.Controls.Add(ContainerForeColor);
			tabPage2.Controls.Add(label11);
			tabPage2.Controls.Add(ContainerBaseColor);
			tabPage2.Controls.Add(ContainerFadeColor);
			tabPage2.Controls.Add(ContainerBackColor);
			tabPage2.Controls.Add(groupBox2);
			tabPage2.Controls.Add(groupBox3);
			tabPage2.Controls.Add(groupBox1);
			tabPage2.Controls.Add(label1);
			tabPage2.Controls.Add(ContainerBorderColor);
			tabPage2.Controls.Add(label3);
			tabPage2.Controls.Add(label2);
			tabPage2.Controls.Add(groupBox10);
			tabPage2.Location = new System.Drawing.Point(4, 22);
			tabPage2.Name = "tabPage2";
			tabPage2.Size = new System.Drawing.Size(315, 254);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "ContainerStyle";
			label20.AutoSize = true;
			label20.BackColor = System.Drawing.Color.Transparent;
			label20.Location = new System.Drawing.Point(205, 165);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(109, 16);
			label20.TabIndex = 17;
			label20.Text = "FocusItemBackColor";
			ContainerFocusItemBackColor.BackColor = System.Drawing.Color.FromArgb(1, 45, 150);
			ContainerFocusItemBackColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			ContainerFocusItemBackColor.Location = new System.Drawing.Point(180, 160);
			ContainerFocusItemBackColor.Name = "ContainerFocusItemBackColor";
			ContainerFocusItemBackColor.Size = new System.Drawing.Size(20, 20);
			ContainerFocusItemBackColor.TabIndex = 18;
			ContainerFocusItemBackColor.Click += new System.EventHandler(OnContainerColorPick);
			label19.AutoSize = true;
			label19.BackColor = System.Drawing.Color.Transparent;
			label19.Location = new System.Drawing.Point(205, 140);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(106, 16);
			label19.TabIndex = 15;
			label19.Text = "FlashItemBackColor";
			ContainerFlashItemBackColor.BackColor = System.Drawing.Color.FromArgb(1, 45, 150);
			ContainerFlashItemBackColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			ContainerFlashItemBackColor.Location = new System.Drawing.Point(180, 135);
			ContainerFlashItemBackColor.Name = "ContainerFlashItemBackColor";
			ContainerFlashItemBackColor.Size = new System.Drawing.Size(20, 20);
			ContainerFlashItemBackColor.TabIndex = 16;
			ContainerFlashItemBackColor.Click += new System.EventHandler(OnContainerColorPick);
			label18.AutoSize = true;
			label18.BackColor = System.Drawing.Color.Transparent;
			label18.Location = new System.Drawing.Point(205, 115);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(55, 16);
			label18.TabIndex = 13;
			label18.Text = "ForeColor";
			ContainerForeColor.BackColor = System.Drawing.Color.FromArgb(1, 45, 150);
			ContainerForeColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			ContainerForeColor.Location = new System.Drawing.Point(180, 110);
			ContainerForeColor.Name = "ContainerForeColor";
			ContainerForeColor.Size = new System.Drawing.Size(20, 20);
			ContainerForeColor.TabIndex = 14;
			ContainerForeColor.Click += new System.EventHandler(OnContainerColorPick);
			label11.AutoSize = true;
			label11.BackColor = System.Drawing.Color.Transparent;
			label11.Location = new System.Drawing.Point(205, 90);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(57, 16);
			label11.TabIndex = 11;
			label11.Text = "BaseColor";
			ContainerBaseColor.BackColor = System.Drawing.Color.FromArgb(1, 45, 150);
			ContainerBaseColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			ContainerBaseColor.Location = new System.Drawing.Point(180, 85);
			ContainerBaseColor.Name = "ContainerBaseColor";
			ContainerBaseColor.Size = new System.Drawing.Size(20, 20);
			ContainerBaseColor.TabIndex = 12;
			ContainerBaseColor.Click += new System.EventHandler(OnContainerColorPick);
			ContainerFadeColor.BackColor = System.Drawing.Color.FromArgb(217, 232, 252);
			ContainerFadeColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			ContainerFadeColor.Location = new System.Drawing.Point(180, 35);
			ContainerFadeColor.Name = "ContainerFadeColor";
			ContainerFadeColor.Size = new System.Drawing.Size(20, 20);
			ContainerFadeColor.TabIndex = 10;
			ContainerFadeColor.Click += new System.EventHandler(OnContainerColorPick);
			ContainerBackColor.BackColor = System.Drawing.Color.FromArgb(142, 179, 231);
			ContainerBackColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			ContainerBackColor.Location = new System.Drawing.Point(180, 10);
			ContainerBackColor.Name = "ContainerBackColor";
			ContainerBackColor.Size = new System.Drawing.Size(20, 20);
			ContainerBackColor.TabIndex = 9;
			ContainerBackColor.Click += new System.EventHandler(OnContainerColorPick);
			groupBox10.BackColor = System.Drawing.Color.Transparent;
			groupBox10.Controls.Add(ContainerCaptionAlign1);
			groupBox10.Controls.Add(ContainerCaptionAlign2);
			groupBox10.Location = new System.Drawing.Point(8, 185);
			groupBox10.Name = "groupBox10";
			groupBox10.Size = new System.Drawing.Size(90, 55);
			groupBox10.TabIndex = 5;
			groupBox10.TabStop = false;
			groupBox10.Text = "CaptionAlign";
			ContainerCaptionAlign1.Appearance = System.Windows.Forms.Appearance.Button;
			ContainerCaptionAlign1.Checked = true;
			ContainerCaptionAlign1.Image = (System.Drawing.Image)resourceManager.GetObject("ContainerCaptionAlign1.Image");
			ContainerCaptionAlign1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			ContainerCaptionAlign1.Location = new System.Drawing.Point(12, 20);
			ContainerCaptionAlign1.Name = "ContainerCaptionAlign1";
			ContainerCaptionAlign1.Size = new System.Drawing.Size(28, 28);
			ContainerCaptionAlign1.TabIndex = 1;
			ContainerCaptionAlign1.TabStop = true;
			ContainerCaptionAlign1.Tag = "Left";
			toolTip1.SetToolTip(ContainerCaptionAlign1, "Left");
			ContainerCaptionAlign1.CheckedChanged += new System.EventHandler(OnContainerCaptionAlignCheckedChanged);
			ContainerCaptionAlign2.Appearance = System.Windows.Forms.Appearance.Button;
			ContainerCaptionAlign2.Image = (System.Drawing.Image)resourceManager.GetObject("ContainerCaptionAlign2.Image");
			ContainerCaptionAlign2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			ContainerCaptionAlign2.Location = new System.Drawing.Point(40, 20);
			ContainerCaptionAlign2.Name = "ContainerCaptionAlign2";
			ContainerCaptionAlign2.Size = new System.Drawing.Size(28, 28);
			ContainerCaptionAlign2.TabIndex = 2;
			ContainerCaptionAlign2.Tag = "Top";
			toolTip1.SetToolTip(ContainerCaptionAlign2, "Top");
			ContainerCaptionAlign2.CheckedChanged += new System.EventHandler(OnContainerCaptionAlignCheckedChanged);
			tabPage1.Controls.Add(HeaderFont);
			tabPage1.Controls.Add(groupBox6);
			tabPage1.Controls.Add(groupBox5);
			tabPage1.Controls.Add(label10);
			tabPage1.Controls.Add(HeaderButtonColor);
			tabPage1.Controls.Add(groupBox4);
			tabPage1.Controls.Add(label7);
			tabPage1.Controls.Add(HeaderFlashFadeColor);
			tabPage1.Controls.Add(HeaderFlashForeColor);
			tabPage1.Controls.Add(label8);
			tabPage1.Controls.Add(label9);
			tabPage1.Controls.Add(HeaderFlashBackColor);
			tabPage1.Controls.Add(label4);
			tabPage1.Controls.Add(HeaderFadeColor);
			tabPage1.Controls.Add(HeaderForeColor);
			tabPage1.Controls.Add(label5);
			tabPage1.Controls.Add(label6);
			tabPage1.Controls.Add(HeaderBackColor);
			tabPage1.Controls.Add(HeaderVisible);
			tabPage1.Location = new System.Drawing.Point(4, 22);
			tabPage1.Name = "tabPage1";
			tabPage1.Size = new System.Drawing.Size(315, 254);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "HeaderStyle";
			HeaderFont.Location = new System.Drawing.Point(184, 184);
			HeaderFont.Name = "HeaderFont";
			HeaderFont.Size = new System.Drawing.Size(68, 20);
			HeaderFont.TabIndex = 26;
			HeaderFont.Text = "Font";
			HeaderFont.Click += new System.EventHandler(OnHeaderFontPick);
			groupBox6.BackColor = System.Drawing.Color.Transparent;
			groupBox6.Controls.Add(HeaderSize3);
			groupBox6.Controls.Add(HeaderSize2);
			groupBox6.Controls.Add(HeaderSize1);
			groupBox6.Location = new System.Drawing.Point(8, 72);
			groupBox6.Name = "groupBox6";
			groupBox6.Size = new System.Drawing.Size(160, 52);
			groupBox6.TabIndex = 25;
			groupBox6.TabStop = false;
			groupBox6.Text = "Size";
			HeaderSize3.Appearance = System.Windows.Forms.Appearance.Button;
			HeaderSize3.Location = new System.Drawing.Point(108, 20);
			HeaderSize3.Name = "HeaderSize3";
			HeaderSize3.Size = new System.Drawing.Size(44, 20);
			HeaderSize3.TabIndex = 2;
			HeaderSize3.Tag = "Large";
			HeaderSize3.Text = "Large";
			HeaderSize3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			HeaderSize3.CheckedChanged += new System.EventHandler(OnHeaderSizeCheckedChanged);
			HeaderSize2.Appearance = System.Windows.Forms.Appearance.Button;
			HeaderSize2.Checked = true;
			HeaderSize2.Location = new System.Drawing.Point(52, 20);
			HeaderSize2.Name = "HeaderSize2";
			HeaderSize2.Size = new System.Drawing.Size(56, 20);
			HeaderSize2.TabIndex = 1;
			HeaderSize2.TabStop = true;
			HeaderSize2.Tag = "Medium";
			HeaderSize2.Text = "Medium";
			HeaderSize2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			HeaderSize2.CheckedChanged += new System.EventHandler(OnHeaderSizeCheckedChanged);
			HeaderSize1.Appearance = System.Windows.Forms.Appearance.Button;
			HeaderSize1.Location = new System.Drawing.Point(8, 20);
			HeaderSize1.Name = "HeaderSize1";
			HeaderSize1.Size = new System.Drawing.Size(44, 20);
			HeaderSize1.TabIndex = 0;
			HeaderSize1.Tag = "Small";
			HeaderSize1.Text = "Small";
			HeaderSize1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			HeaderSize1.CheckedChanged += new System.EventHandler(OnHeaderSizeCheckedChanged);
			groupBox5.BackColor = System.Drawing.Color.Transparent;
			groupBox5.Controls.Add(HeaderTextAlign9);
			groupBox5.Controls.Add(HeaderTextAlign8);
			groupBox5.Controls.Add(HeaderTextAlign7);
			groupBox5.Controls.Add(HeaderTextAlign6);
			groupBox5.Controls.Add(HeaderTextAlign5);
			groupBox5.Controls.Add(HeaderTextAlign4);
			groupBox5.Controls.Add(HeaderTextAlign3);
			groupBox5.Controls.Add(HeaderTextAlign2);
			groupBox5.Controls.Add(HeaderTextAlign1);
			groupBox5.Location = new System.Drawing.Point(8, 128);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new System.Drawing.Size(108, 116);
			groupBox5.TabIndex = 24;
			groupBox5.TabStop = false;
			groupBox5.Text = "TextAlign";
			HeaderTextAlign9.Appearance = System.Windows.Forms.Appearance.Button;
			HeaderTextAlign9.Image = (System.Drawing.Image)resourceManager.GetObject("HeaderTextAlign9.Image");
			HeaderTextAlign9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			HeaderTextAlign9.Location = new System.Drawing.Point(68, 76);
			HeaderTextAlign9.Name = "HeaderTextAlign9";
			HeaderTextAlign9.Size = new System.Drawing.Size(28, 28);
			HeaderTextAlign9.TabIndex = 11;
			HeaderTextAlign9.Tag = "BottomRight";
			toolTip1.SetToolTip(HeaderTextAlign9, "BottomRight");
			HeaderTextAlign9.CheckedChanged += new System.EventHandler(OnHeaderTextAlignCheckedChanged);
			HeaderTextAlign8.Appearance = System.Windows.Forms.Appearance.Button;
			HeaderTextAlign8.Image = (System.Drawing.Image)resourceManager.GetObject("HeaderTextAlign8.Image");
			HeaderTextAlign8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			HeaderTextAlign8.Location = new System.Drawing.Point(40, 76);
			HeaderTextAlign8.Name = "HeaderTextAlign8";
			HeaderTextAlign8.Size = new System.Drawing.Size(28, 28);
			HeaderTextAlign8.TabIndex = 10;
			HeaderTextAlign8.Tag = "BottomCenter";
			toolTip1.SetToolTip(HeaderTextAlign8, "BottomCenter");
			HeaderTextAlign8.CheckedChanged += new System.EventHandler(OnHeaderTextAlignCheckedChanged);
			HeaderTextAlign7.Appearance = System.Windows.Forms.Appearance.Button;
			HeaderTextAlign7.Image = (System.Drawing.Image)resourceManager.GetObject("HeaderTextAlign7.Image");
			HeaderTextAlign7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			HeaderTextAlign7.Location = new System.Drawing.Point(12, 76);
			HeaderTextAlign7.Name = "HeaderTextAlign7";
			HeaderTextAlign7.Size = new System.Drawing.Size(28, 28);
			HeaderTextAlign7.TabIndex = 9;
			HeaderTextAlign7.Tag = "BottomLeft";
			toolTip1.SetToolTip(HeaderTextAlign7, "BottomLeft");
			HeaderTextAlign7.CheckedChanged += new System.EventHandler(OnHeaderTextAlignCheckedChanged);
			HeaderTextAlign6.Appearance = System.Windows.Forms.Appearance.Button;
			HeaderTextAlign6.Image = (System.Drawing.Image)resourceManager.GetObject("HeaderTextAlign6.Image");
			HeaderTextAlign6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			HeaderTextAlign6.Location = new System.Drawing.Point(68, 48);
			HeaderTextAlign6.Name = "HeaderTextAlign6";
			HeaderTextAlign6.Size = new System.Drawing.Size(28, 28);
			HeaderTextAlign6.TabIndex = 8;
			HeaderTextAlign6.Tag = "MiddleRight";
			toolTip1.SetToolTip(HeaderTextAlign6, "MiddleRight");
			HeaderTextAlign6.CheckedChanged += new System.EventHandler(OnHeaderTextAlignCheckedChanged);
			HeaderTextAlign5.Appearance = System.Windows.Forms.Appearance.Button;
			HeaderTextAlign5.Image = (System.Drawing.Image)resourceManager.GetObject("HeaderTextAlign5.Image");
			HeaderTextAlign5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			HeaderTextAlign5.Location = new System.Drawing.Point(40, 48);
			HeaderTextAlign5.Name = "HeaderTextAlign5";
			HeaderTextAlign5.Size = new System.Drawing.Size(28, 28);
			HeaderTextAlign5.TabIndex = 7;
			HeaderTextAlign5.Tag = "MiddleCenter";
			toolTip1.SetToolTip(HeaderTextAlign5, "MiddleCenter");
			HeaderTextAlign5.CheckedChanged += new System.EventHandler(OnHeaderTextAlignCheckedChanged);
			HeaderTextAlign4.Appearance = System.Windows.Forms.Appearance.Button;
			HeaderTextAlign4.Checked = true;
			HeaderTextAlign4.Image = (System.Drawing.Image)resourceManager.GetObject("HeaderTextAlign4.Image");
			HeaderTextAlign4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			HeaderTextAlign4.Location = new System.Drawing.Point(12, 48);
			HeaderTextAlign4.Name = "HeaderTextAlign4";
			HeaderTextAlign4.Size = new System.Drawing.Size(28, 28);
			HeaderTextAlign4.TabIndex = 6;
			HeaderTextAlign4.TabStop = true;
			HeaderTextAlign4.Tag = "MiddleLeft";
			toolTip1.SetToolTip(HeaderTextAlign4, "MiddleLeft");
			HeaderTextAlign4.CheckedChanged += new System.EventHandler(OnHeaderTextAlignCheckedChanged);
			HeaderTextAlign3.Appearance = System.Windows.Forms.Appearance.Button;
			HeaderTextAlign3.Image = (System.Drawing.Image)resourceManager.GetObject("HeaderTextAlign3.Image");
			HeaderTextAlign3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			HeaderTextAlign3.Location = new System.Drawing.Point(68, 20);
			HeaderTextAlign3.Name = "HeaderTextAlign3";
			HeaderTextAlign3.Size = new System.Drawing.Size(28, 28);
			HeaderTextAlign3.TabIndex = 5;
			HeaderTextAlign3.Tag = "TopRight";
			toolTip1.SetToolTip(HeaderTextAlign3, "TopRight");
			HeaderTextAlign3.CheckedChanged += new System.EventHandler(OnHeaderTextAlignCheckedChanged);
			HeaderTextAlign2.Appearance = System.Windows.Forms.Appearance.Button;
			HeaderTextAlign2.Image = (System.Drawing.Image)resourceManager.GetObject("HeaderTextAlign2.Image");
			HeaderTextAlign2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			HeaderTextAlign2.Location = new System.Drawing.Point(40, 20);
			HeaderTextAlign2.Name = "HeaderTextAlign2";
			HeaderTextAlign2.Size = new System.Drawing.Size(28, 28);
			HeaderTextAlign2.TabIndex = 4;
			HeaderTextAlign2.Tag = "TopCenter";
			toolTip1.SetToolTip(HeaderTextAlign2, "TopCenter");
			HeaderTextAlign2.CheckedChanged += new System.EventHandler(OnHeaderTextAlignCheckedChanged);
			HeaderTextAlign1.Appearance = System.Windows.Forms.Appearance.Button;
			HeaderTextAlign1.Image = (System.Drawing.Image)resourceManager.GetObject("HeaderTextAlign1.Image");
			HeaderTextAlign1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			HeaderTextAlign1.Location = new System.Drawing.Point(12, 20);
			HeaderTextAlign1.Name = "HeaderTextAlign1";
			HeaderTextAlign1.Size = new System.Drawing.Size(28, 28);
			HeaderTextAlign1.TabIndex = 3;
			HeaderTextAlign1.Tag = "TopLeft";
			toolTip1.SetToolTip(HeaderTextAlign1, "TopLeft");
			HeaderTextAlign1.CheckedChanged += new System.EventHandler(OnHeaderTextAlignCheckedChanged);
			label10.AutoSize = true;
			label10.BackColor = System.Drawing.Color.Transparent;
			label10.Location = new System.Drawing.Point(208, 160);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(64, 16);
			label10.TabIndex = 23;
			label10.Text = "ButtonColor";
			HeaderButtonColor.BackColor = System.Drawing.Color.FromArgb(172, 191, 227);
			HeaderButtonColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			HeaderButtonColor.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			HeaderButtonColor.Location = new System.Drawing.Point(184, 156);
			HeaderButtonColor.Name = "HeaderButtonColor";
			HeaderButtonColor.Size = new System.Drawing.Size(20, 20);
			HeaderButtonColor.TabIndex = 22;
			HeaderButtonColor.Click += new System.EventHandler(OnHeaderColorPick);
			groupBox4.BackColor = System.Drawing.Color.Transparent;
			groupBox4.Controls.Add(HeaderFillStyle5);
			groupBox4.Controls.Add(HeaderFillStyle4);
			groupBox4.Controls.Add(HeaderFillStyle3);
			groupBox4.Controls.Add(HeaderFillStyle2);
			groupBox4.Controls.Add(HeaderFillStyle1);
			groupBox4.Location = new System.Drawing.Point(8, 8);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new System.Drawing.Size(164, 60);
			groupBox4.TabIndex = 21;
			groupBox4.TabStop = false;
			groupBox4.Text = "FillStyle";
			HeaderFillStyle5.Appearance = System.Windows.Forms.Appearance.Button;
			HeaderFillStyle5.Image = (System.Drawing.Image)resourceManager.GetObject("HeaderFillStyle5.Image");
			HeaderFillStyle5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			HeaderFillStyle5.Location = new System.Drawing.Point(124, 20);
			HeaderFillStyle5.Name = "HeaderFillStyle5";
			HeaderFillStyle5.Size = new System.Drawing.Size(28, 28);
			HeaderFillStyle5.TabIndex = 7;
			HeaderFillStyle5.Tag = "DiagonalBackward";
			toolTip1.SetToolTip(HeaderFillStyle5, "DiagonalBackward");
			HeaderFillStyle5.CheckedChanged += new System.EventHandler(OnHeaderFillStyleCheckedChanged);
			HeaderFillStyle4.Appearance = System.Windows.Forms.Appearance.Button;
			HeaderFillStyle4.Image = (System.Drawing.Image)resourceManager.GetObject("HeaderFillStyle4.Image");
			HeaderFillStyle4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			HeaderFillStyle4.Location = new System.Drawing.Point(96, 20);
			HeaderFillStyle4.Name = "HeaderFillStyle4";
			HeaderFillStyle4.Size = new System.Drawing.Size(28, 28);
			HeaderFillStyle4.TabIndex = 6;
			HeaderFillStyle4.Tag = "DiagonalForward";
			toolTip1.SetToolTip(HeaderFillStyle4, "DiagonalForward");
			HeaderFillStyle4.CheckedChanged += new System.EventHandler(OnHeaderFillStyleCheckedChanged);
			HeaderFillStyle3.Appearance = System.Windows.Forms.Appearance.Button;
			HeaderFillStyle3.Checked = true;
			HeaderFillStyle3.Image = (System.Drawing.Image)resourceManager.GetObject("HeaderFillStyle3.Image");
			HeaderFillStyle3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			HeaderFillStyle3.Location = new System.Drawing.Point(68, 20);
			HeaderFillStyle3.Name = "HeaderFillStyle3";
			HeaderFillStyle3.Size = new System.Drawing.Size(28, 28);
			HeaderFillStyle3.TabIndex = 5;
			HeaderFillStyle3.TabStop = true;
			HeaderFillStyle3.Tag = "VerticalFading";
			toolTip1.SetToolTip(HeaderFillStyle3, "VerticalFading");
			HeaderFillStyle3.CheckedChanged += new System.EventHandler(OnHeaderFillStyleCheckedChanged);
			HeaderFillStyle2.Appearance = System.Windows.Forms.Appearance.Button;
			HeaderFillStyle2.Image = (System.Drawing.Image)resourceManager.GetObject("HeaderFillStyle2.Image");
			HeaderFillStyle2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			HeaderFillStyle2.Location = new System.Drawing.Point(40, 20);
			HeaderFillStyle2.Name = "HeaderFillStyle2";
			HeaderFillStyle2.Size = new System.Drawing.Size(28, 28);
			HeaderFillStyle2.TabIndex = 4;
			HeaderFillStyle2.Tag = "HorizontalFading";
			toolTip1.SetToolTip(HeaderFillStyle2, "HorizontalFading");
			HeaderFillStyle2.CheckedChanged += new System.EventHandler(OnHeaderFillStyleCheckedChanged);
			HeaderFillStyle1.Appearance = System.Windows.Forms.Appearance.Button;
			HeaderFillStyle1.Image = (System.Drawing.Image)resourceManager.GetObject("HeaderFillStyle1.Image");
			HeaderFillStyle1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			HeaderFillStyle1.Location = new System.Drawing.Point(12, 20);
			HeaderFillStyle1.Name = "HeaderFillStyle1";
			HeaderFillStyle1.Size = new System.Drawing.Size(28, 28);
			HeaderFillStyle1.TabIndex = 3;
			HeaderFillStyle1.Tag = "Flat";
			toolTip1.SetToolTip(HeaderFillStyle1, "Flat");
			HeaderFillStyle1.CheckedChanged += new System.EventHandler(OnHeaderFillStyleCheckedChanged);
			label7.AutoSize = true;
			label7.BackColor = System.Drawing.Color.Transparent;
			label7.Location = new System.Drawing.Point(208, 136);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(82, 16);
			label7.TabIndex = 16;
			label7.Text = "FlashForeColor";
			HeaderFlashFadeColor.BackColor = System.Drawing.Color.FromArgb(255, 215, 159);
			HeaderFlashFadeColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			HeaderFlashFadeColor.Location = new System.Drawing.Point(184, 108);
			HeaderFlashFadeColor.Name = "HeaderFlashFadeColor";
			HeaderFlashFadeColor.Size = new System.Drawing.Size(20, 20);
			HeaderFlashFadeColor.TabIndex = 19;
			HeaderFlashFadeColor.Click += new System.EventHandler(OnHeaderColorPick);
			HeaderFlashForeColor.BackColor = System.Drawing.Color.White;
			HeaderFlashForeColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			HeaderFlashForeColor.Location = new System.Drawing.Point(184, 132);
			HeaderFlashForeColor.Name = "HeaderFlashForeColor";
			HeaderFlashForeColor.Size = new System.Drawing.Size(20, 20);
			HeaderFlashForeColor.TabIndex = 17;
			HeaderFlashForeColor.Click += new System.EventHandler(OnHeaderColorPick);
			label8.AutoSize = true;
			label8.BackColor = System.Drawing.Color.Transparent;
			label8.Location = new System.Drawing.Point(208, 112);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(85, 16);
			label8.TabIndex = 20;
			label8.Text = "FlashFadeColor";
			label9.AutoSize = true;
			label9.BackColor = System.Drawing.Color.Transparent;
			label9.Location = new System.Drawing.Point(208, 88);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(84, 16);
			label9.TabIndex = 18;
			label9.Text = "FlashBackColor";
			HeaderFlashBackColor.BackColor = System.Drawing.Color.FromArgb(243, 122, 1);
			HeaderFlashBackColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			HeaderFlashBackColor.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			HeaderFlashBackColor.Location = new System.Drawing.Point(184, 84);
			HeaderFlashBackColor.Name = "HeaderFlashBackColor";
			HeaderFlashBackColor.Size = new System.Drawing.Size(20, 20);
			HeaderFlashBackColor.TabIndex = 15;
			HeaderFlashBackColor.Click += new System.EventHandler(OnHeaderColorPick);
			label4.AutoSize = true;
			label4.BackColor = System.Drawing.Color.Transparent;
			label4.Location = new System.Drawing.Point(208, 64);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(55, 16);
			label4.TabIndex = 10;
			label4.Text = "ForeColor";
			HeaderFadeColor.BackColor = System.Drawing.Color.FromArgb(102, 145, 215);
			HeaderFadeColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			HeaderFadeColor.Location = new System.Drawing.Point(184, 36);
			HeaderFadeColor.Name = "HeaderFadeColor";
			HeaderFadeColor.Size = new System.Drawing.Size(20, 20);
			HeaderFadeColor.TabIndex = 13;
			HeaderFadeColor.Click += new System.EventHandler(OnHeaderColorPick);
			HeaderForeColor.BackColor = System.Drawing.Color.FromArgb(215, 230, 251);
			HeaderForeColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			HeaderForeColor.Location = new System.Drawing.Point(184, 60);
			HeaderForeColor.Name = "HeaderForeColor";
			HeaderForeColor.Size = new System.Drawing.Size(20, 20);
			HeaderForeColor.TabIndex = 11;
			HeaderForeColor.Click += new System.EventHandler(OnHeaderColorPick);
			label5.AutoSize = true;
			label5.BackColor = System.Drawing.Color.Transparent;
			label5.Location = new System.Drawing.Point(208, 40);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(57, 16);
			label5.TabIndex = 14;
			label5.Text = "FadeColor";
			label6.AutoSize = true;
			label6.BackColor = System.Drawing.Color.Transparent;
			label6.Location = new System.Drawing.Point(208, 16);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(56, 16);
			label6.TabIndex = 12;
			label6.Text = "BackColor";
			HeaderBackColor.BackColor = System.Drawing.Color.FromArgb(9, 42, 127);
			HeaderBackColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			HeaderBackColor.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			HeaderBackColor.Location = new System.Drawing.Point(184, 12);
			HeaderBackColor.Name = "HeaderBackColor";
			HeaderBackColor.Size = new System.Drawing.Size(20, 20);
			HeaderBackColor.TabIndex = 9;
			HeaderBackColor.Click += new System.EventHandler(OnHeaderColorPick);
			HeaderVisible.BackColor = System.Drawing.Color.Transparent;
			HeaderVisible.Checked = true;
			HeaderVisible.CheckState = System.Windows.Forms.CheckState.Checked;
			HeaderVisible.Location = new System.Drawing.Point(184, 212);
			HeaderVisible.Name = "HeaderVisible";
			HeaderVisible.Size = new System.Drawing.Size(96, 20);
			HeaderVisible.TabIndex = 0;
			HeaderVisible.Text = "HeaderVisible";
			HeaderVisible.CheckedChanged += new System.EventHandler(OnHeaderVisibleCheckedChanged);
			tabPage3.Controls.Add(FooterFont);
			tabPage3.Controls.Add(groupBox7);
			tabPage3.Controls.Add(groupBox8);
			tabPage3.Controls.Add(groupBox9);
			tabPage3.Controls.Add(label12);
			tabPage3.Controls.Add(FooterFlashFadeColor);
			tabPage3.Controls.Add(FooterFlashForeColor);
			tabPage3.Controls.Add(label13);
			tabPage3.Controls.Add(label14);
			tabPage3.Controls.Add(FooterFlashBackColor);
			tabPage3.Controls.Add(label15);
			tabPage3.Controls.Add(FooterFadeColor);
			tabPage3.Controls.Add(FooterForeColor);
			tabPage3.Controls.Add(label16);
			tabPage3.Controls.Add(label17);
			tabPage3.Controls.Add(FooterBackColor);
			tabPage3.Controls.Add(FooterVisible);
			tabPage3.Location = new System.Drawing.Point(4, 22);
			tabPage3.Name = "tabPage3";
			tabPage3.Size = new System.Drawing.Size(315, 254);
			tabPage3.TabIndex = 2;
			tabPage3.Text = "FooterStyle";
			FooterFont.Location = new System.Drawing.Point(184, 160);
			FooterFont.Name = "FooterFont";
			FooterFont.Size = new System.Drawing.Size(68, 20);
			FooterFont.TabIndex = 45;
			FooterFont.Text = "Font";
			FooterFont.Click += new System.EventHandler(OnFooterFontPick);
			groupBox7.BackColor = System.Drawing.Color.Transparent;
			groupBox7.Controls.Add(FooterSize3);
			groupBox7.Controls.Add(FooterSize2);
			groupBox7.Controls.Add(FooterSize1);
			groupBox7.Location = new System.Drawing.Point(8, 72);
			groupBox7.Name = "groupBox7";
			groupBox7.Size = new System.Drawing.Size(160, 52);
			groupBox7.TabIndex = 44;
			groupBox7.TabStop = false;
			groupBox7.Text = "Size";
			FooterSize3.Appearance = System.Windows.Forms.Appearance.Button;
			FooterSize3.Location = new System.Drawing.Point(108, 20);
			FooterSize3.Name = "FooterSize3";
			FooterSize3.Size = new System.Drawing.Size(44, 20);
			FooterSize3.TabIndex = 2;
			FooterSize3.Tag = "Large";
			FooterSize3.Text = "Large";
			FooterSize3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			toolTip1.SetToolTip(FooterSize3, "Large");
			FooterSize3.CheckedChanged += new System.EventHandler(OnFooterSizeCheckedChanged);
			FooterSize2.Appearance = System.Windows.Forms.Appearance.Button;
			FooterSize2.Location = new System.Drawing.Point(52, 20);
			FooterSize2.Name = "FooterSize2";
			FooterSize2.Size = new System.Drawing.Size(56, 20);
			FooterSize2.TabIndex = 1;
			FooterSize2.Tag = "Medium";
			FooterSize2.Text = "Medium";
			FooterSize2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			toolTip1.SetToolTip(FooterSize2, "Medium");
			FooterSize2.CheckedChanged += new System.EventHandler(OnFooterSizeCheckedChanged);
			FooterSize1.Appearance = System.Windows.Forms.Appearance.Button;
			FooterSize1.Checked = true;
			FooterSize1.Location = new System.Drawing.Point(8, 20);
			FooterSize1.Name = "FooterSize1";
			FooterSize1.Size = new System.Drawing.Size(44, 20);
			FooterSize1.TabIndex = 0;
			FooterSize1.TabStop = true;
			FooterSize1.Tag = "Small";
			FooterSize1.Text = "Small";
			FooterSize1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			toolTip1.SetToolTip(FooterSize1, "Small");
			FooterSize1.CheckedChanged += new System.EventHandler(OnFooterSizeCheckedChanged);
			groupBox8.BackColor = System.Drawing.Color.Transparent;
			groupBox8.Controls.Add(FooterTextAlign9);
			groupBox8.Controls.Add(FooterTextAlign8);
			groupBox8.Controls.Add(FooterTextAlign7);
			groupBox8.Controls.Add(FooterTextAlign6);
			groupBox8.Controls.Add(FooterTextAlign5);
			groupBox8.Controls.Add(FooterTextAlign4);
			groupBox8.Controls.Add(FooterTextAlign3);
			groupBox8.Controls.Add(FooterTextAlign2);
			groupBox8.Controls.Add(FooterTextAlign1);
			groupBox8.Location = new System.Drawing.Point(8, 128);
			groupBox8.Name = "groupBox8";
			groupBox8.Size = new System.Drawing.Size(108, 116);
			groupBox8.TabIndex = 43;
			groupBox8.TabStop = false;
			groupBox8.Text = "TextAlign";
			FooterTextAlign9.Appearance = System.Windows.Forms.Appearance.Button;
			FooterTextAlign9.Image = (System.Drawing.Image)resourceManager.GetObject("FooterTextAlign9.Image");
			FooterTextAlign9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			FooterTextAlign9.Location = new System.Drawing.Point(68, 76);
			FooterTextAlign9.Name = "FooterTextAlign9";
			FooterTextAlign9.Size = new System.Drawing.Size(28, 28);
			FooterTextAlign9.TabIndex = 20;
			FooterTextAlign9.Tag = "BottomRight";
			toolTip1.SetToolTip(FooterTextAlign9, "BottomRight");
			FooterTextAlign9.CheckedChanged += new System.EventHandler(OnFooterTextAlignCheckedChanged);
			FooterTextAlign8.Appearance = System.Windows.Forms.Appearance.Button;
			FooterTextAlign8.Image = (System.Drawing.Image)resourceManager.GetObject("FooterTextAlign8.Image");
			FooterTextAlign8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			FooterTextAlign8.Location = new System.Drawing.Point(40, 76);
			FooterTextAlign8.Name = "FooterTextAlign8";
			FooterTextAlign8.Size = new System.Drawing.Size(28, 28);
			FooterTextAlign8.TabIndex = 19;
			FooterTextAlign8.Tag = "BottomCenter";
			toolTip1.SetToolTip(FooterTextAlign8, "BottomCenter");
			FooterTextAlign8.CheckedChanged += new System.EventHandler(OnFooterTextAlignCheckedChanged);
			FooterTextAlign7.Appearance = System.Windows.Forms.Appearance.Button;
			FooterTextAlign7.Image = (System.Drawing.Image)resourceManager.GetObject("FooterTextAlign7.Image");
			FooterTextAlign7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			FooterTextAlign7.Location = new System.Drawing.Point(12, 76);
			FooterTextAlign7.Name = "FooterTextAlign7";
			FooterTextAlign7.Size = new System.Drawing.Size(28, 28);
			FooterTextAlign7.TabIndex = 18;
			FooterTextAlign7.Tag = "BottomLeft";
			toolTip1.SetToolTip(FooterTextAlign7, "BottomLeft");
			FooterTextAlign7.CheckedChanged += new System.EventHandler(OnFooterTextAlignCheckedChanged);
			FooterTextAlign6.Appearance = System.Windows.Forms.Appearance.Button;
			FooterTextAlign6.Image = (System.Drawing.Image)resourceManager.GetObject("FooterTextAlign6.Image");
			FooterTextAlign6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			FooterTextAlign6.Location = new System.Drawing.Point(68, 48);
			FooterTextAlign6.Name = "FooterTextAlign6";
			FooterTextAlign6.Size = new System.Drawing.Size(28, 28);
			FooterTextAlign6.TabIndex = 17;
			FooterTextAlign6.Tag = "MiddleRight";
			toolTip1.SetToolTip(FooterTextAlign6, "MiddleRight");
			FooterTextAlign6.CheckedChanged += new System.EventHandler(OnFooterTextAlignCheckedChanged);
			FooterTextAlign5.Appearance = System.Windows.Forms.Appearance.Button;
			FooterTextAlign5.Image = (System.Drawing.Image)resourceManager.GetObject("FooterTextAlign5.Image");
			FooterTextAlign5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			FooterTextAlign5.Location = new System.Drawing.Point(40, 48);
			FooterTextAlign5.Name = "FooterTextAlign5";
			FooterTextAlign5.Size = new System.Drawing.Size(28, 28);
			FooterTextAlign5.TabIndex = 16;
			FooterTextAlign5.Tag = "MiddleCenter";
			toolTip1.SetToolTip(FooterTextAlign5, "MiddleCenter");
			FooterTextAlign5.CheckedChanged += new System.EventHandler(OnFooterTextAlignCheckedChanged);
			FooterTextAlign4.Appearance = System.Windows.Forms.Appearance.Button;
			FooterTextAlign4.Checked = true;
			FooterTextAlign4.Image = (System.Drawing.Image)resourceManager.GetObject("FooterTextAlign4.Image");
			FooterTextAlign4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			FooterTextAlign4.Location = new System.Drawing.Point(12, 48);
			FooterTextAlign4.Name = "FooterTextAlign4";
			FooterTextAlign4.Size = new System.Drawing.Size(28, 28);
			FooterTextAlign4.TabIndex = 15;
			FooterTextAlign4.TabStop = true;
			FooterTextAlign4.Tag = "MiddleLeft";
			toolTip1.SetToolTip(FooterTextAlign4, "MiddleLeft");
			FooterTextAlign4.CheckedChanged += new System.EventHandler(OnFooterTextAlignCheckedChanged);
			FooterTextAlign3.Appearance = System.Windows.Forms.Appearance.Button;
			FooterTextAlign3.Image = (System.Drawing.Image)resourceManager.GetObject("FooterTextAlign3.Image");
			FooterTextAlign3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			FooterTextAlign3.Location = new System.Drawing.Point(68, 20);
			FooterTextAlign3.Name = "FooterTextAlign3";
			FooterTextAlign3.Size = new System.Drawing.Size(28, 28);
			FooterTextAlign3.TabIndex = 14;
			FooterTextAlign3.Tag = "TopRight";
			toolTip1.SetToolTip(FooterTextAlign3, "TopRight");
			FooterTextAlign3.CheckedChanged += new System.EventHandler(OnFooterTextAlignCheckedChanged);
			FooterTextAlign2.Appearance = System.Windows.Forms.Appearance.Button;
			FooterTextAlign2.Image = (System.Drawing.Image)resourceManager.GetObject("FooterTextAlign2.Image");
			FooterTextAlign2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			FooterTextAlign2.Location = new System.Drawing.Point(40, 20);
			FooterTextAlign2.Name = "FooterTextAlign2";
			FooterTextAlign2.Size = new System.Drawing.Size(28, 28);
			FooterTextAlign2.TabIndex = 13;
			FooterTextAlign2.Tag = "TopCenter";
			toolTip1.SetToolTip(FooterTextAlign2, "TopCenter");
			FooterTextAlign2.CheckedChanged += new System.EventHandler(OnFooterTextAlignCheckedChanged);
			FooterTextAlign1.Appearance = System.Windows.Forms.Appearance.Button;
			FooterTextAlign1.Image = (System.Drawing.Image)resourceManager.GetObject("FooterTextAlign1.Image");
			FooterTextAlign1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			FooterTextAlign1.Location = new System.Drawing.Point(12, 20);
			FooterTextAlign1.Name = "FooterTextAlign1";
			FooterTextAlign1.Size = new System.Drawing.Size(28, 28);
			FooterTextAlign1.TabIndex = 12;
			FooterTextAlign1.Tag = "TopLeft";
			toolTip1.SetToolTip(FooterTextAlign1, "TopLeft");
			FooterTextAlign1.CheckedChanged += new System.EventHandler(OnFooterTextAlignCheckedChanged);
			groupBox9.BackColor = System.Drawing.Color.Transparent;
			groupBox9.Controls.Add(FooterFillStyle5);
			groupBox9.Controls.Add(FooterFillStyle4);
			groupBox9.Controls.Add(FooterFillStyle3);
			groupBox9.Controls.Add(FooterFillStyle2);
			groupBox9.Controls.Add(FooterFillStyle1);
			groupBox9.Location = new System.Drawing.Point(8, 8);
			groupBox9.Name = "groupBox9";
			groupBox9.Size = new System.Drawing.Size(164, 60);
			groupBox9.TabIndex = 40;
			groupBox9.TabStop = false;
			groupBox9.Text = "FillStyle";
			FooterFillStyle5.Appearance = System.Windows.Forms.Appearance.Button;
			FooterFillStyle5.Image = (System.Drawing.Image)resourceManager.GetObject("FooterFillStyle5.Image");
			FooterFillStyle5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			FooterFillStyle5.Location = new System.Drawing.Point(124, 20);
			FooterFillStyle5.Name = "FooterFillStyle5";
			FooterFillStyle5.Size = new System.Drawing.Size(28, 28);
			FooterFillStyle5.TabIndex = 12;
			FooterFillStyle5.Tag = "DiagonalBackward";
			toolTip1.SetToolTip(FooterFillStyle5, "DiagonalBackward");
			FooterFillStyle5.CheckedChanged += new System.EventHandler(OnFooterFillStyleCheckedChanged);
			FooterFillStyle4.Appearance = System.Windows.Forms.Appearance.Button;
			FooterFillStyle4.Image = (System.Drawing.Image)resourceManager.GetObject("FooterFillStyle4.Image");
			FooterFillStyle4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			FooterFillStyle4.Location = new System.Drawing.Point(96, 20);
			FooterFillStyle4.Name = "FooterFillStyle4";
			FooterFillStyle4.Size = new System.Drawing.Size(28, 28);
			FooterFillStyle4.TabIndex = 11;
			FooterFillStyle4.Tag = "DiagonalForward";
			toolTip1.SetToolTip(FooterFillStyle4, "DiagonalForward");
			FooterFillStyle4.CheckedChanged += new System.EventHandler(OnFooterFillStyleCheckedChanged);
			FooterFillStyle3.Appearance = System.Windows.Forms.Appearance.Button;
			FooterFillStyle3.Image = (System.Drawing.Image)resourceManager.GetObject("FooterFillStyle3.Image");
			FooterFillStyle3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			FooterFillStyle3.Location = new System.Drawing.Point(68, 20);
			FooterFillStyle3.Name = "FooterFillStyle3";
			FooterFillStyle3.Size = new System.Drawing.Size(28, 28);
			FooterFillStyle3.TabIndex = 10;
			FooterFillStyle3.Tag = "VerticalFading";
			toolTip1.SetToolTip(FooterFillStyle3, "VerticalFading");
			FooterFillStyle3.CheckedChanged += new System.EventHandler(OnFooterFillStyleCheckedChanged);
			FooterFillStyle2.Appearance = System.Windows.Forms.Appearance.Button;
			FooterFillStyle2.Checked = true;
			FooterFillStyle2.Image = (System.Drawing.Image)resourceManager.GetObject("FooterFillStyle2.Image");
			FooterFillStyle2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			FooterFillStyle2.Location = new System.Drawing.Point(40, 20);
			FooterFillStyle2.Name = "FooterFillStyle2";
			FooterFillStyle2.Size = new System.Drawing.Size(28, 28);
			FooterFillStyle2.TabIndex = 9;
			FooterFillStyle2.TabStop = true;
			FooterFillStyle2.Tag = "HorizontalFading";
			toolTip1.SetToolTip(FooterFillStyle2, "HorizontalFading");
			FooterFillStyle2.CheckedChanged += new System.EventHandler(OnFooterFillStyleCheckedChanged);
			FooterFillStyle1.Appearance = System.Windows.Forms.Appearance.Button;
			FooterFillStyle1.Image = (System.Drawing.Image)resourceManager.GetObject("FooterFillStyle1.Image");
			FooterFillStyle1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			FooterFillStyle1.Location = new System.Drawing.Point(12, 20);
			FooterFillStyle1.Name = "FooterFillStyle1";
			FooterFillStyle1.Size = new System.Drawing.Size(28, 28);
			FooterFillStyle1.TabIndex = 8;
			FooterFillStyle1.Tag = "Flat";
			toolTip1.SetToolTip(FooterFillStyle1, "Flat");
			FooterFillStyle1.CheckedChanged += new System.EventHandler(OnFooterFillStyleCheckedChanged);
			label12.AutoSize = true;
			label12.BackColor = System.Drawing.Color.Transparent;
			label12.Location = new System.Drawing.Point(208, 136);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(82, 16);
			label12.TabIndex = 35;
			label12.Text = "FlashForeColor";
			FooterFlashFadeColor.BackColor = System.Drawing.Color.FromArgb(255, 215, 159);
			FooterFlashFadeColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			FooterFlashFadeColor.Location = new System.Drawing.Point(184, 108);
			FooterFlashFadeColor.Name = "FooterFlashFadeColor";
			FooterFlashFadeColor.Size = new System.Drawing.Size(20, 20);
			FooterFlashFadeColor.TabIndex = 38;
			FooterFlashFadeColor.Click += new System.EventHandler(OnFooterColorPick);
			FooterFlashForeColor.BackColor = System.Drawing.Color.White;
			FooterFlashForeColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			FooterFlashForeColor.Location = new System.Drawing.Point(184, 132);
			FooterFlashForeColor.Name = "FooterFlashForeColor";
			FooterFlashForeColor.Size = new System.Drawing.Size(20, 20);
			FooterFlashForeColor.TabIndex = 36;
			FooterFlashForeColor.Click += new System.EventHandler(OnFooterColorPick);
			label13.AutoSize = true;
			label13.BackColor = System.Drawing.Color.Transparent;
			label13.Location = new System.Drawing.Point(208, 112);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(85, 16);
			label13.TabIndex = 39;
			label13.Text = "FlashFadeColor";
			label14.AutoSize = true;
			label14.BackColor = System.Drawing.Color.Transparent;
			label14.Location = new System.Drawing.Point(208, 88);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(84, 16);
			label14.TabIndex = 37;
			label14.Text = "FlashBackColor";
			FooterFlashBackColor.BackColor = System.Drawing.Color.FromArgb(243, 122, 1);
			FooterFlashBackColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			FooterFlashBackColor.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			FooterFlashBackColor.Location = new System.Drawing.Point(184, 84);
			FooterFlashBackColor.Name = "FooterFlashBackColor";
			FooterFlashBackColor.Size = new System.Drawing.Size(20, 20);
			FooterFlashBackColor.TabIndex = 34;
			FooterFlashBackColor.Click += new System.EventHandler(OnFooterColorPick);
			label15.AutoSize = true;
			label15.BackColor = System.Drawing.Color.Transparent;
			label15.Location = new System.Drawing.Point(208, 64);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(55, 16);
			label15.TabIndex = 29;
			label15.Text = "ForeColor";
			FooterFadeColor.BackColor = System.Drawing.Color.FromArgb(9, 42, 127);
			FooterFadeColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			FooterFadeColor.Location = new System.Drawing.Point(184, 36);
			FooterFadeColor.Name = "FooterFadeColor";
			FooterFadeColor.Size = new System.Drawing.Size(20, 20);
			FooterFadeColor.TabIndex = 32;
			FooterFadeColor.Click += new System.EventHandler(OnFooterColorPick);
			FooterForeColor.BackColor = System.Drawing.Color.FromArgb(169, 198, 237);
			FooterForeColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			FooterForeColor.Location = new System.Drawing.Point(184, 60);
			FooterForeColor.Name = "FooterForeColor";
			FooterForeColor.Size = new System.Drawing.Size(20, 20);
			FooterForeColor.TabIndex = 30;
			FooterForeColor.Click += new System.EventHandler(OnFooterColorPick);
			label16.AutoSize = true;
			label16.BackColor = System.Drawing.Color.Transparent;
			label16.Location = new System.Drawing.Point(208, 40);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(57, 16);
			label16.TabIndex = 33;
			label16.Text = "FadeColor";
			label17.AutoSize = true;
			label17.BackColor = System.Drawing.Color.Transparent;
			label17.Location = new System.Drawing.Point(208, 16);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(56, 16);
			label17.TabIndex = 31;
			label17.Text = "BackColor";
			FooterBackColor.BackColor = System.Drawing.Color.FromArgb(102, 145, 215);
			FooterBackColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			FooterBackColor.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			FooterBackColor.Location = new System.Drawing.Point(184, 12);
			FooterBackColor.Name = "FooterBackColor";
			FooterBackColor.Size = new System.Drawing.Size(20, 20);
			FooterBackColor.TabIndex = 28;
			FooterBackColor.Click += new System.EventHandler(OnFooterColorPick);
			FooterVisible.BackColor = System.Drawing.Color.Transparent;
			FooterVisible.Checked = true;
			FooterVisible.CheckState = System.Windows.Forms.CheckState.Checked;
			FooterVisible.Location = new System.Drawing.Point(184, 188);
			FooterVisible.Name = "FooterVisible";
			FooterVisible.Size = new System.Drawing.Size(96, 20);
			FooterVisible.TabIndex = 27;
			FooterVisible.Text = "FooterVisible";
			FooterVisible.CheckedChanged += new System.EventHandler(OnFooterVisibleCheckedChanged);
			OK.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			OK.DialogResult = System.Windows.Forms.DialogResult.OK;
			OK.Location = new System.Drawing.Point(122, 289);
			OK.Name = "OK";
			OK.Size = new System.Drawing.Size(64, 24);
			OK.TabIndex = 10;
			OK.Text = "OK";
			OK.Click += new System.EventHandler(OK_Click);
			Cancel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			Cancel.DialogResult = System.Windows.Forms.DialogResult.OK;
			Cancel.Location = new System.Drawing.Point(192, 289);
			Cancel.Name = "Cancel";
			Cancel.Size = new System.Drawing.Size(64, 24);
			Cancel.TabIndex = 11;
			Cancel.Text = "Cancel";
			Cancel.Click += new System.EventHandler(Cancel_Click);
			Apply.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			Apply.Location = new System.Drawing.Point(262, 289);
			Apply.Name = "Apply";
			Apply.Size = new System.Drawing.Size(64, 24);
			Apply.TabIndex = 12;
			Apply.Text = "Apply";
			Apply.Click += new System.EventHandler(Apply_Click);
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			base.ClientSize = new System.Drawing.Size(331, 317);
			base.Controls.Add(Apply);
			base.Controls.Add(Cancel);
			base.Controls.Add(OK);
			base.Controls.Add(tabControl1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "NicePanelStyleEditorForm";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "PureComponents NicePanel Style Editor";
			groupBox1.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			groupBox3.ResumeLayout(false);
			tabControl1.ResumeLayout(false);
			tabPage2.ResumeLayout(false);
			groupBox10.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			groupBox6.ResumeLayout(false);
			groupBox5.ResumeLayout(false);
			groupBox4.ResumeLayout(false);
			tabPage3.ResumeLayout(false);
			groupBox7.ResumeLayout(false);
			groupBox8.ResumeLayout(false);
			groupBox9.ResumeLayout(false);
			ResumeLayout(false);
		}

		private void OnHeaderFillStyleCheckedChanged(object sender, EventArgs e)
		{
			Control control = (Control)sender;
			string value = (string)control.Tag;
			m_Designer.NicePanel.Style.HeaderStyle.FillStyle = (FillStyle)Enum.Parse(typeof(FillStyle), value);
		}

		private void OnHeaderSizeCheckedChanged(object sender, EventArgs e)
		{
			Control control = (Control)sender;
			string value = (string)control.Tag;
			m_Designer.NicePanel.Style.HeaderStyle.Size = (PanelHeaderSize)Enum.Parse(typeof(PanelHeaderSize), value);
		}

		private void OnHeaderTextAlignCheckedChanged(object sender, EventArgs e)
		{
			Control control = (Control)sender;
			string value = (string)control.Tag;
			m_Designer.NicePanel.Style.HeaderStyle.TextAlign = (ContentAlignment)Enum.Parse(typeof(ContentAlignment), value);
		}

		private void OnHeaderColorPick(object sender, EventArgs e)
		{
			Control control = (Control)sender;
			Point point = control.Parent.PointToScreen(control.Location);
			ColorPickForm colorPickForm = new ColorPickForm(control.BackColor);
			colorPickForm.Location = new Point(point.X + control.Width + 2, point.Y);
			Screen screen = Screen.FromControl(this);
			if (colorPickForm.Location.X + colorPickForm.Width > screen.WorkingArea.Width - 1)
			{
				colorPickForm.Left = screen.WorkingArea.Width - 1 - colorPickForm.Width;
			}
			if (colorPickForm.Location.Y + colorPickForm.Width > screen.WorkingArea.Height - 1)
			{
				colorPickForm.Top = screen.WorkingArea.Height - 1 - colorPickForm.Height;
			}
			if (colorPickForm.ShowDialog() == DialogResult.OK)
			{
				Color color2 = (control.BackColor = colorPickForm.Color);
				if (HeaderBackColor == sender)
				{
					m_Designer.NicePanel.Style.HeaderStyle.BackColor = color2;
				}
				else if (HeaderButtonColor == sender)
				{
					m_Designer.NicePanel.Style.HeaderStyle.ButtonColor = color2;
				}
				else if (HeaderFadeColor == sender)
				{
					m_Designer.NicePanel.Style.HeaderStyle.FadeColor = color2;
				}
				else if (HeaderFlashBackColor == sender)
				{
					m_Designer.NicePanel.Style.HeaderStyle.FlashBackColor = color2;
				}
				else if (HeaderFlashFadeColor == sender)
				{
					m_Designer.NicePanel.Style.HeaderStyle.FlashFadeColor = color2;
				}
				else if (HeaderFlashForeColor == sender)
				{
					m_Designer.NicePanel.Style.HeaderStyle.FlashForeColor = color2;
				}
				else if (HeaderForeColor == sender)
				{
					m_Designer.NicePanel.Style.HeaderStyle.ForeColor = color2;
				}
			}
		}

		private void OnHeaderFontPick(object sender, EventArgs e)
		{
			FontDialog fontDialog = new FontDialog();
			fontDialog.Font = m_Designer.NicePanel.Style.HeaderStyle.Font;
			if (fontDialog.ShowDialog() == DialogResult.OK)
			{
				m_Designer.NicePanel.Style.HeaderStyle.Font = fontDialog.Font;
			}
		}

		private void OnHeaderVisibleCheckedChanged(object sender, EventArgs e)
		{
			m_Designer.NicePanel.HeaderVisible = HeaderVisible.Checked;
		}

		private void OnFooterFillStyleCheckedChanged(object sender, EventArgs e)
		{
			Control control = (Control)sender;
			string value = (string)control.Tag;
			m_Designer.NicePanel.Style.FooterStyle.FillStyle = (FillStyle)Enum.Parse(typeof(FillStyle), value);
		}

		private void OnFooterSizeCheckedChanged(object sender, EventArgs e)
		{
			Control control = (Control)sender;
			string value = (string)control.Tag;
			m_Designer.NicePanel.Style.FooterStyle.Size = (PanelHeaderSize)Enum.Parse(typeof(PanelHeaderSize), value);
		}

		private void OnFooterTextAlignCheckedChanged(object sender, EventArgs e)
		{
			Control control = (Control)sender;
			string value = (string)control.Tag;
			m_Designer.NicePanel.Style.FooterStyle.TextAlign = (ContentAlignment)Enum.Parse(typeof(ContentAlignment), value);
		}

		private void OnFooterColorPick(object sender, EventArgs e)
		{
			Control control = (Control)sender;
			Point point = control.Parent.PointToScreen(control.Location);
			ColorPickForm colorPickForm = new ColorPickForm(control.BackColor);
			colorPickForm.Location = new Point(point.X + control.Width + 2, point.Y);
			Screen screen = Screen.FromControl(this);
			if (colorPickForm.Location.X + colorPickForm.Width > screen.WorkingArea.Width - 1)
			{
				colorPickForm.Left = screen.WorkingArea.Width - 1 - colorPickForm.Width;
			}
			if (colorPickForm.Location.Y + colorPickForm.Width > screen.WorkingArea.Height - 1)
			{
				colorPickForm.Top = screen.WorkingArea.Height - 1 - colorPickForm.Height;
			}
			if (colorPickForm.ShowDialog() == DialogResult.OK)
			{
				Color color2 = (control.BackColor = colorPickForm.Color);
				if (FooterBackColor == sender)
				{
					m_Designer.NicePanel.Style.FooterStyle.BackColor = color2;
				}
				else if (FooterFadeColor == sender)
				{
					m_Designer.NicePanel.Style.FooterStyle.FadeColor = color2;
				}
				else if (FooterFlashBackColor == sender)
				{
					m_Designer.NicePanel.Style.FooterStyle.FlashBackColor = color2;
				}
				else if (FooterFlashFadeColor == sender)
				{
					m_Designer.NicePanel.Style.FooterStyle.FlashFadeColor = color2;
				}
				else if (FooterFlashForeColor == sender)
				{
					m_Designer.NicePanel.Style.FooterStyle.FlashForeColor = color2;
				}
				else if (FooterForeColor == sender)
				{
					m_Designer.NicePanel.Style.FooterStyle.ForeColor = color2;
				}
			}
		}

		private void OnFooterFontPick(object sender, EventArgs e)
		{
			FontDialog fontDialog = new FontDialog();
			fontDialog.Font = m_Designer.NicePanel.Style.FooterStyle.Font;
			if (fontDialog.ShowDialog() == DialogResult.OK)
			{
				m_Designer.NicePanel.Style.FooterStyle.Font = fontDialog.Font;
			}
		}

		private void OnFooterVisibleCheckedChanged(object sender, EventArgs e)
		{
			m_Designer.NicePanel.FooterVisible = FooterVisible.Checked;
		}

		private void OnContainerColorPick(object sender, EventArgs e)
		{
			Control control = (Control)sender;
			Point point = control.Parent.PointToScreen(control.Location);
			ColorPickForm colorPickForm = new ColorPickForm(control.BackColor);
			colorPickForm.Location = new Point(point.X + control.Width + 2, point.Y);
			Screen screen = Screen.FromControl(this);
			if (colorPickForm.Location.X + colorPickForm.Width > screen.WorkingArea.Width - 1)
			{
				colorPickForm.Left = screen.WorkingArea.Width - 1 - colorPickForm.Width;
			}
			if (colorPickForm.Location.Y + colorPickForm.Width > screen.WorkingArea.Height - 1)
			{
				colorPickForm.Top = screen.WorkingArea.Height - 1 - colorPickForm.Height;
			}
			if (colorPickForm.ShowDialog() == DialogResult.OK)
			{
				Color color2 = (control.BackColor = colorPickForm.Color);
				if (ContainerBackColor == sender)
				{
					m_Designer.NicePanel.Style.ContainerStyle.BackColor = color2;
				}
				if (ContainerForeColor == sender)
				{
					m_Designer.NicePanel.Style.ContainerStyle.ForeColor = color2;
				}
				if (ContainerBaseColor == sender)
				{
					m_Designer.NicePanel.Style.ContainerStyle.BaseColor = color2;
				}
				else if (ContainerBorderColor == sender)
				{
					m_Designer.NicePanel.Style.ContainerStyle.BorderColor = color2;
				}
				else if (ContainerFadeColor == sender)
				{
					m_Designer.NicePanel.Style.ContainerStyle.FadeColor = color2;
				}
				else if (ContainerFocusItemBackColor == sender)
				{
					m_Designer.NicePanel.Style.ContainerStyle.FocusItemBackColor = color2;
				}
				else if (ContainerFlashItemBackColor == sender)
				{
					m_Designer.NicePanel.Style.ContainerStyle.FlashItemBackColor = color2;
				}
			}
		}

		private void OnContainerFillStyleCheckedChanged(object sender, EventArgs e)
		{
			Control control = (Control)sender;
			string value = (string)control.Tag;
			m_Designer.NicePanel.Style.ContainerStyle.FillStyle = (FillStyle)Enum.Parse(typeof(FillStyle), value);
		}

		private void OnContainerShapeCheckedChanged(object sender, EventArgs e)
		{
			Control control = (Control)sender;
			string value = (string)control.Tag;
			m_Designer.NicePanel.Style.ContainerStyle.Shape = (Shape)Enum.Parse(typeof(Shape), value);
		}

		private void OnContainerBorderStyleCheckedChanged(object sender, EventArgs e)
		{
			Control control = (Control)sender;
			string value = (string)control.Tag;
			m_Designer.NicePanel.Style.ContainerStyle.BorderStyle = (BorderStyle)Enum.Parse(typeof(BorderStyle), value);
		}

		private void OnContainerCaptionAlignCheckedChanged(object sender, EventArgs e)
		{
			Control control = (Control)sender;
			string value = (string)control.Tag;
			m_Designer.NicePanel.Style.ContainerStyle.CaptionAlign = (CaptionAlign)Enum.Parse(typeof(CaptionAlign), value);
		}

		private void Cancel_Click(object sender, EventArgs e)
		{
			m_Designer.NicePanel.Style = m_Style;
			base.DialogResult = DialogResult.Cancel;
		}

		private void OK_Click(object sender, EventArgs e)
		{
			Apply_Click(sender, e);
			base.DialogResult = DialogResult.OK;
		}

		private void Apply_Click(object sender, EventArgs e)
		{
			PanelStyle style = m_Designer.NicePanel.Style;
			bool headerVisible = m_Designer.NicePanel.HeaderVisible;
			bool footerVisible = m_Designer.NicePanel.FooterVisible;
			m_Designer.NicePanel.Style = m_Style;
			m_Designer.NicePanel.HeaderVisible = m_HeaderVisible;
			m_Designer.NicePanel.FooterVisible = m_FooterVisible;
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(m_Designer.NicePanel);
			PropertyDescriptor propertyDescriptor = properties.Find("Style", ignoreCase: false);
			PropertyDescriptor propertyDescriptor2 = properties.Find("HeaderVisible", ignoreCase: false);
			PropertyDescriptor propertyDescriptor3 = properties.Find("FooterVisible", ignoreCase: false);
			using DesignerTransaction designerTransaction = m_Designer.DesignerHost.CreateTransaction("Applying NicePanel style");
			m_Designer.InvokeComponentChanging(propertyDescriptor);
			propertyDescriptor.SetValue(m_Designer.NicePanel, style);
			m_Designer.InvokeComponentChanged(propertyDescriptor, m_Style, style);
			m_Designer.InvokeComponentChanging(propertyDescriptor2);
			propertyDescriptor2.SetValue(m_Designer.NicePanel, headerVisible);
			m_Designer.InvokeComponentChanged(propertyDescriptor2, m_HeaderVisible, headerVisible);
			m_Designer.InvokeComponentChanging(propertyDescriptor3);
			propertyDescriptor3.SetValue(m_Designer.NicePanel, footerVisible);
			m_Designer.InvokeComponentChanged(propertyDescriptor3, m_FooterVisible, footerVisible);
			designerTransaction.Commit();
		}
	}
}
