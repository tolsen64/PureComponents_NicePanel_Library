using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using PureComponents.NicePanel.Design;

namespace PureComponents.NicePanel
{
	/// <summary><P>NicePanel control represents collapsible panel with advanced item data binding and visual functions.</P></summary>
	[Serializable]
	[ToolboxBitmap(typeof(NicePanel), "PureComponents.NicePanel.bmp")]
	[Designer(typeof(NicePanelDesigner))]
	public class NicePanel : Control
	{
		internal NicePanelDesigner Designer = null;

		private PanelStyle m_Style = null;

		private bool m_HeaderVisible = true;

		private string m_HeaderText = string.Empty;

		private HeaderImage m_HeaderImage = null;

		private HeaderImage m_FooterImage = null;

		private ContainerImage m_ContainerImage = null;

		private MouseMoveTarget m_MouseMoveTarget = MouseMoveTarget.None;

		private bool m_ShowCaptions = true;

		private bool m_ShowDescriptions = true;

		private bool m_ShowChildFocus = true;

		private bool m_FooterVisible = true;

		private string m_FooterText = "PureComponents NicePanel for .NET WinForms V1.0.";

		private int m_CollapsedHeight = 28;

		private int m_OriginalHeight = 0;

		private Hashtable m_mapControlsVisible = new Hashtable();

		private bool m_OriginalFooterVisible = true;

		private bool m_FlashHeader = false;

		private bool m_FlashFooter = false;

		private bool m_Collapsed = false;

		private Rectangle m_CollapseButtonRect;

		private Rectangle m_MenuButtonRect;

		private Rectangle m_CloseButtonRect;

		private Rectangle m_MinimizeButtonRect;

		private Rectangle m_MaximizeButtonRect;

		private bool m_CollapseButtonHighligted = false;

		private bool m_MenuButtonHighligted = false;

		private bool m_CloseButtonHighligted = false;

		private bool m_MinimizeButtonHighligted = false;

		private bool m_MaximizeButtonHighligted = false;

		private int m_RestoreHeight;

		private int m_RestoreWidth;

		private bool m_ContextMenuButtonVisible = true;

		private bool m_CollapseButtonVisible = true;

		private bool m_CloseButtonVisible = false;

		private bool m_MinimizeButtonVisible = false;

		private bool m_MaximizeButtonVisible = false;

		private bool m_Maximized = false;

		private Point m_RestoreLocation = Point.Empty;

		private Point m_LastMousePoint = Point.Empty;

		private ContextMenu m_ContextMenu = null;

		private static bool m_attributesTested = false;

		private static bool m_L = false;

		private static bool m_LCalled = false;

		private string m_copyright = string.Empty;

		private string m_company = string.Empty;

		private string m_product = string.Empty;

		private static string m_LicenseKey = string.Empty;

		private static LF m_LF;

		private static Thread m_LFThread = null;

		private bool m_DesignMode = false;

		private string m_FlashingId = null;

		private Thread m_FlashHeaderThread = null;

		private Thread m_FlashFooterThread = null;

		private Thread m_FlashItemThread = null;

		private string m_OriginalFooter = string.Empty;

		private Hashtable m_MapOriginalBackColor = new Hashtable();

		private ArrayList m_Nulls = new ArrayList();

		private ArrayList m_CtrlTitlePainted = new ArrayList();

		private bool m_Resize = false;

		private bool m_Resizable = false;

		[Browsable(false)]
		public static string LicenseKey
		{
			set
			{
				if (value.ToUpper().IndexOf(Factory.GetInstance().Generate2("B0BE5E434B315D55AAAF425E543BAH3255504C4J51AB5531BA524EA44142BE4GA3BA42424AAGB4AEBBAHB5A4A52JB1422JB2A5A54F413H3H")) == 0)
				{
					m_LicenseKey = value;
				}
			}
		}

		/// <summary><P>Gets or sets whether the header of the <b>NicePanel</b> is visible.</P></summary>
		[DefaultValue(true)]
		[Description("Defines whether the header is visible or not.")]
		[Category("Appearance")]
		public bool HeaderVisible
		{
			get
			{
				return m_HeaderVisible;
			}
			set
			{
				m_HeaderVisible = value;
				Invalidate(invalidateChildren: true);
			}
		}

		/// <summary><P>Gets or sets the header text of the <b>NicePanel</b>.</P></summary>
		[Category("Appearance")]
		[Description("Text being shown in the header area of the panel.")]
		public string HeaderText
		{
			get
			{
				return m_HeaderText;
			}
			set
			{
				m_HeaderText = value;
				Invalidate(invalidateChildren: true);
			}
		}

		/// <summary><P>Gets or sets whether the footer of the <b>NicePanel</b> is visible.</P></summary>
		[Description("Defines whether the footer is visible or not.")]
		[Category("Appearance")]
		[DefaultValue(true)]
		public bool FooterVisible
		{
			get
			{
				return m_FooterVisible;
			}
			set
			{
				m_FooterVisible = value;
				m_OriginalFooterVisible = value;
				Invalidate(invalidateChildren: true);
			}
		}

		/// <summary><P>Gets or sets whether the focus is shown for the inner controls of the <b>NicePanel</b>.</P></summary>
		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("Specifies whether the background of a control is changed when focus is received.")]
		public bool ShowChildFocus
		{
			get
			{
				return m_ShowChildFocus;
			}
			set
			{
				m_ShowChildFocus = value;
				DeepInvalidate();
			}
		}

		/// <summary><P>Gets or sets the move target of the <b>NicePanel</b>.</P></summary>
		[Category("Behavior")]
		[Description("Specifies behavior of the mouse move function when left mouse button is pressed.")]
		[DefaultValue(MouseMoveTarget.None)]
		public MouseMoveTarget MouseMoveTarget
		{
			get
			{
				return m_MouseMoveTarget;
			}
			set
			{
				m_MouseMoveTarget = value;
				DeepInvalidate();
			}
		}

		/// <summary><P>Gets or sets whether the captions are shown on the <b>NicePanel</b>.</P></summary>
		[DefaultValue(true)]
		[Description("Specifies whether the Tag captions are rendered next to the controls.")]
		[Category("Behavior")]
		public bool ShowCaptions
		{
			get
			{
				return m_ShowCaptions;
			}
			set
			{
				m_ShowCaptions = value;
				DeepInvalidate();
			}
		}

		/// <summary><P>Gets or sets whether the description are show in the footer of the <b>NicePanel</b> for container's items.</P></summary>
		[DefaultValue(true)]
		[Description("Specifies whether the descriptions are shown in the footer of the NicePanel when control receives focus.")]
		[Category("Behavior")]
		public bool ShowDescriptions
		{
			get
			{
				return m_ShowDescriptions;
			}
			set
			{
				m_ShowDescriptions = value;
				DeepInvalidate();
			}
		}

		/// <summary><P>Gets or sets the footer text of the <b>NicePanel</b>.</P></summary>
		[Category("Appearance")]
		[Description("Text being shown in the footer area of the panel.")]
		public string FooterText
		{
			get
			{
				return m_FooterText;
			}
			set
			{
				m_FooterText = value;
				Invalidate(invalidateChildren: true);
			}
		}

		/// <summary><P>Gets or sets the current instance of the <b>NicePanel</b> style.</P></summary>
		[Description("Style of the panel, consists of three parts - ContainerStyle, HeaderStyle and FooterStyle.")]
		[Category("Appearance")]
		public PanelStyle Style
		{
			get
			{
				return m_Style;
			}
			set
			{
				m_Style = value;
				m_Style.SetPanel(this);
				OnSetShape();
				Invalidate(invalidateChildren: true);
			}
		}

		/// <summary><P>Gets or sets the conext menu object of the <b>NicePanel</b>.</P></summary>
		[Description("Context menu associated with the panel, menu is shown when the menu button on the header is clicked.")]
		[Category("Behavior")]
		public new ContextMenu ContextMenu
		{
			get
			{
				return m_ContextMenu;
			}
			set
			{
				m_ContextMenu = value;
			}
		}

		/// <summary><P>Gets or sets whether the <b>NicePanel</b> is expanded.</P></summary>
		[Browsable(false)]
		public bool IsExpanded
		{
			get
			{
				return !m_Collapsed;
			}
			set
			{
				if (!value)
				{
					Collapse();
				}
				else
				{
					Expand();
				}
				Invalidate(invalidateChildren: true);
			}
		}

		/// <summary><P>Gets or sets the visibility of the context menu button of the <b>NicePanel</b>.</P></summary>
		[Category("Appearance")]
		[DefaultValue(true)]
		[Description("Specifies whether the context menu button is shown.")]
		public bool ContextMenuButton
		{
			get
			{
				return m_ContextMenuButtonVisible;
			}
			set
			{
				m_ContextMenuButtonVisible = value;
				Invalidate(invalidateChildren: true);
			}
		}

		/// <summary><P>Gets or sets the visibility of the collapse button of the <b>NicePanel</b>.</P></summary>
		[DefaultValue(true)]
		[Category("Appearance")]
		[Description("Specifies whether the collapse button is being shown.")]
		public bool CollapseButton
		{
			get
			{
				return m_CollapseButtonVisible;
			}
			set
			{
				m_CollapseButtonVisible = value;
				Invalidate(invalidateChildren: true);
			}
		}

		/// <summary><P>Gets or sets the visibility of the close button of the <b>NicePanel</b>.</P></summary>
		[Category("Appearance")]
		[Description("Specifies whether the close button is being shown.")]
		[DefaultValue(false)]
		public bool CloseButton
		{
			get
			{
				return m_CloseButtonVisible;
			}
			set
			{
				m_CloseButtonVisible = value;
				Invalidate(invalidateChildren: true);
			}
		}

		/// <summary><P>Gets or sets the visibility of the minimize button of the <b>NicePanel</b>.</P></summary>
		[DefaultValue(false)]
		[Category("Appearance")]
		[Description("Specifies whether the minimize button is being shown.")]
		public bool MinimizeButton
		{
			get
			{
				return m_MinimizeButtonVisible;
			}
			set
			{
				m_MinimizeButtonVisible = value;
				Invalidate(invalidateChildren: true);
			}
		}

		/// <summary><P>Gets or sets the visibility of the maximize button of the <b>NicePanel</b>.</P></summary>
		[Description("Specifies whether the maximize button is being shown.")]
		[DefaultValue(false)]
		[Category("Appearance")]
		public bool MaximizeButton
		{
			get
			{
				return m_MaximizeButtonVisible;
			}
			set
			{
				m_MaximizeButtonVisible = value;
				Invalidate(invalidateChildren: true);
			}
		}

		/// <summary><P>Gets or sets the header image of the <b>NicePanel</b>.</P></summary>
		[Description("Image object at the header area.")]
		[Category("Appearance")]
		public HeaderImage HeaderImage
		{
			get
			{
				return m_HeaderImage;
			}
			set
			{
				m_HeaderImage = value;
				Invalidate(invalidateChildren: true);
			}
		}

		/// <summary><P>Gets or sets the footer image of the <b>NicePanel</b>.</P></summary>
		[Category("Appearance")]
		[Description("Image object at the footer area.")]
		public HeaderImage FooterImage
		{
			get
			{
				return m_FooterImage;
			}
			set
			{
				m_FooterImage = value;
				Invalidate(invalidateChildren: true);
			}
		}

		/// <summary><P>Gets or sets the container image of the <b>NicePanel</b>.</P></summary>
		[Description("Image object at the container area.")]
		[Category("Appearance")]
		public ContainerImage ContainerImage
		{
			get
			{
				return m_ContainerImage;
			}
			set
			{
				m_ContainerImage = value;
				Invalidate(invalidateChildren: true);
			}
		}

		/// <summary><P>Gets or sets the height of the <b>NicePanel</b>.</P></summary>
		[Description("Height of the panel.")]
		public new int Height
		{
			get
			{
				return base.Height;
			}
			set
			{
				if (IsExpanded)
				{
					base.Height = value;
				}
			}
		}

		/// <summary><P>Gets or sets the size of the <b>NicePanel</b>.</P></summary>
		[Description("Size of the panel.")]
		public new Size Size
		{
			get
			{
				return base.Size;
			}
			set
			{
				base.Size = value;
			}
		}

		/// <summary><P>For internal purposes only. Do not use.</P></summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public int OriginalHeight
		{
			get
			{
				return m_OriginalHeight;
			}
			set
			{
				m_OriginalHeight = value;
			}
		}

		/// <summary><P>For internal purposes only. Do not use.</P></summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool OriginalFooterVisible
		{
			get
			{
				return m_OriginalFooterVisible;
			}
			set
			{
				m_OriginalFooterVisible = value;
			}
		}

		public bool Resizable
		{
			get
			{
				return m_Resizable;
			}
			set
			{
				m_Resizable = value;
				Invalidate(invalidateChildren: true);
			}
		}

		/// <summary><P>Inherited. Not used directly.</P></summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new Font Font
		{
			get
			{
				return base.Font;
			}
			set
			{
				base.Font = value;
			}
		}

		/// <summary><P>Gets or sets the background color of the <b>NicePanel</b>.</P></summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
			}
		}

		/// <summary><P>Gets or sets the background image of the <b>NicePanel</b>.</P></summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new Image BackgroundImage
		{
			get
			{
				return base.BackgroundImage;
			}
			set
			{
				base.BackgroundImage = value;
			}
		}

		/// <summary><P>Inherited. Not used directly.</P></summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
			}
		}

		/// <summary><P>Inherited. Not used.</P></summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new RightToLeft RightToLeft
		{
			get
			{
				return base.RightToLeft;
			}
			set
			{
				base.RightToLeft = value;
			}
		}

		/// <summary><P>Inherited. Not used.</P></summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}

		/// <summary><P>Occurs when the <see cref="T:PureComponents.NicePanel.NicePanel" /> is collapsed.</P></summary>
		[Category("NicePanel")]
		public event EventHandler Collapsed;

		[Category("NicePanel")]
		public event CancelEventHandler Collapsing;

		/// <summary><P>Occurs when the <see cref="T:PureComponents.NicePanel.NicePanel" /> is expanded.</P></summary>
		[Category("NicePanel")]
		public event EventHandler Expanded;

		[Category("NicePanel")]
		public event CancelEventHandler Expanding;

		/// <summary><P>Occurs when the <see cref="T:PureComponents.NicePanel.NicePanel" /> is about to be closed.</P></summary>
		[Category("NicePanel")]
		public event CancelEventHandler Closing;

		/// <summary><P>Occurs when the <see cref="T:PureComponents.NicePanel.NicePanel" /> is about to be maximized.</P></summary>
		[Category("NicePanel")]
		public event CancelEventHandler Maximizing;

		/// <summary><P>Occurs when the <see cref="T:PureComponents.NicePanel.NicePanel" /> is about to be minimized.</P></summary>
		[Category("NicePanel")]
		public event CancelEventHandler Minimizing;

		/// <summary><P>Occurs when the <see cref="T:PureComponents.NicePanel.NicePanel" /> is about to be restored.</P></summary>
		[Category("NicePanel")]
		public event CancelEventHandler Restoring;

		/// <summary><P>Default contruction.</P></summary>
		public NicePanel()
		{
			m_Style = new PanelStyle();
			m_HeaderImage = new HeaderImage();
			m_FooterImage = new HeaderImage();
			m_FooterImage.ClipArt = ImageClipArt.None;
			m_ContainerImage = new ContainerImage();
			SetStyle(ControlStyles.DoubleBuffer, value: true);
			SetStyle(ControlStyles.ResizeRedraw, value: true);
			SetStyle(ControlStyles.ContainerControl, value: true);
			SetStyle(ControlStyles.SupportsTransparentBackColor, value: true);
			BackColor = Color.Transparent;
			ForeColor = Color.Black;
			Size = new Size(320, 200);
			m_Style.SetPanel(this);
			m_HeaderImage.SetParent(this);
			m_FooterImage.SetParent(this);
			m_ContainerImage.SetParent(this);
		}

		private void Collapse()
		{
			if (IsExpanded)
			{
				CancelEventArgs cancelEventArgs = new CancelEventArgs(cancel: false);
				if (this.Collapsing != null)
				{
					this.Collapsing(this, cancelEventArgs);
				}
				if (!cancelEventArgs.Cancel)
				{
					m_OriginalHeight = Height;
					m_OriginalFooterVisible = FooterVisible;
					HideControls();
					base.Height = m_CollapsedHeight;
					m_Collapsed = true;
					OnCollapse(this, EventArgs.Empty);
				}
			}
		}

		private void Expand()
		{
			if (IsExpanded)
			{
				return;
			}
			CancelEventArgs cancelEventArgs = new CancelEventArgs(cancel: false);
			if (this.Expanding != null)
			{
				this.Expanding(this, cancelEventArgs);
			}
			if (!cancelEventArgs.Cancel)
			{
				m_Collapsed = false;
				RestoreControls();
				if (m_OriginalHeight == 0)
				{
					m_OriginalHeight = 150;
				}
				base.Height = m_OriginalHeight;
				FooterVisible = m_OriginalFooterVisible;
				OnExpand(this, EventArgs.Empty);
			}
		}

		/// <summary><P>Performs the flash operation on the header object. Using the flash style settings for the header.</P></summary>
		public void FlashHeader()
		{
			try
			{
				if (m_FlashHeaderThread != null)
				{
					m_FlashHeaderThread.Abort();
				}
			}
			catch
			{
			}
			m_FlashHeaderThread = new Thread(OnFlashHeaderImpl);
			m_FlashHeaderThread.IsBackground = true;
			m_FlashHeaderThread.Start();
		}

		/// <summary><P>Performs the flash operation on the footer object. Using the flash style settings for the footer.</P></summary>
		public void FlashFooter()
		{
			try
			{
				if (m_FlashFooterThread != null)
				{
					m_FlashFooterThread.Abort();
				}
			}
			catch
			{
			}
			m_FlashFooterThread = new Thread(OnFlashFooterImpl);
			m_FlashFooterThread.IsBackground = true;
			m_FlashFooterThread.Start();
		}

		/// <summary><P>Performs the flash operation on the specified object. </P></summary>
		/// <param name="id"><P>Id of the inner item to be flashed.</P></param>
		public void FlashItem(string id)
		{
			try
			{
				if (m_FlashItemThread != null)
				{
					m_FlashItemThread.Abort();
				}
			}
			catch
			{
			}
			m_FlashingId = id;
			m_FlashItemThread = new Thread(OnFlashItemImpl);
			m_FlashItemThread.IsBackground = true;
			m_FlashItemThread.Start();
		}

		private void OnFlashItemImpl()
		{
			Control[] items = GetItems(m_FlashingId);
			Hashtable hashtable = new Hashtable();
			Control[] array = items;
			foreach (Control control in array)
			{
				hashtable.Add(control, control.BackColor);
			}
			bool flag = true;
			for (int j = 0; j < 18; j++)
			{
				array = items;
				foreach (Control control2 in array)
				{
					if (flag)
					{
						control2.BackColor = Style.ContainerStyle.FlashItemBackColor;
					}
					else
					{
						control2.BackColor = (Color)hashtable[control2];
					}
				}
				Thread.Sleep(150);
				flag = !flag;
			}
			m_FlashingId = null;
			hashtable.Clear();
			Invalidate();
		}

		private void OnFlashHeaderImpl()
		{
			m_FlashHeader = false;
			for (int i = 0; i < 17; i++)
			{
				Invalidate();
				Thread.Sleep(150);
				m_FlashHeader = !m_FlashHeader;
			}
			m_FlashHeader = false;
			Invalidate();
		}

		private void OnFlashFooterImpl()
		{
			m_FlashFooter = false;
			for (int i = 0; i < 17; i++)
			{
				Invalidate();
				Thread.Sleep(150);
				m_FlashFooter = !m_FlashFooter;
			}
			m_FlashFooter = false;
			Invalidate();
		}

		/// <summary><P>Gets the array of controls under the given Id.</P></summary>
		/// <param name="id"><P>Id of the inner items to be retrieved.</P></param>
		public Control[] GetItems(string id)
		{
			ArrayList arrayList = new ArrayList();
			foreach (Control control in base.Controls)
			{
				if (control.Tag is string && GetControlDataField(control) == id)
				{
					arrayList.Add(control);
				}
				Control[] items = GetItems(control, id);
				arrayList.AddRange(items);
			}
			return (Control[])arrayList.ToArray(typeof(Control));
		}

		private Control[] GetItems(Control ctrl, string id)
		{
			ArrayList arrayList = new ArrayList();
			foreach (Control control in ctrl.Controls)
			{
				if (control.Tag is string && GetControlDataField(control) == id)
				{
					arrayList.Add(control);
				}
				Control[] items = GetItems(control, id);
				arrayList.AddRange(items);
			}
			return (Control[])arrayList.ToArray(typeof(Control));
		}

		/// <summary><P>Sets the visible state of the specified object. </P></summary>
		/// <param name="ID"><P>Id of the object to set its visible state.</P></param>
		/// <param name="Visible"><P>Visible state.</P></param>
		public void SetItemVisible(string ID, bool Visible)
		{
			Control[] items = GetItems(ID);
			Control[] array = items;
			foreach (Control control in array)
			{
				control.Visible = Visible;
			}
		}

		/// <summary><P>Gets the visible state of the specified object. </P></summary>
		/// <param name="ID"><P>Id of the object to get its visible status.</P></param>
		public bool GetItemVisible(string ID)
		{
			Control[] items = GetItems(ID);
			if (items.Length == 0)
			{
				return false;
			}
			return items[0].Visible;
		}

		/// <summary><P>Sets the enabled state of the specified object. </P></summary>
		/// <param name="ID"><P>Id of the object to set its enabled state.</P></param>
		/// <param name="Enabled"><P>Enabled state.</P></param>
		public void SetItemEnabled(string ID, bool Enabled)
		{
			Control[] items = GetItems(ID);
			Control[] array = items;
			foreach (Control control in array)
			{
				control.Enabled = Enabled;
			}
		}

		/// <summary><P>Gets the enable state of the specified object. </P></summary>
		/// <param name="ID"><P>Id of the object to get its enabled status.</P></param>
		public bool GetItemEnabled(string ID)
		{
			Control[] items = GetItems(ID);
			if (items.Length == 0)
			{
				return false;
			}
			return items[0].Enabled;
		}

		/// <summary><P>Gets the text of the specified object. </P></summary>
		/// <param name="ID"><P>Id of the object to get its text.</P></param>
		public string GetItemText(string ID)
		{
			Control[] items = GetItems(ID);
			if (items.Length == 0)
			{
				return null;
			}
			return items[0].Text;
		}

		/// <summary><P>Sets the text of the specified object. </P></summary>
		/// <param name="ID"><P>Id of the object to set its text.</P></param>
		/// <param name="Text"><P>Text to be set.</P></param>
		public void SetItemText(string ID, string Text)
		{
			Control[] items = GetItems(ID);
			Control[] array = items;
			foreach (Control control in array)
			{
				control.Text = Text;
			}
		}

		/// <summary><P>Sets the focus to the specified object. </P></summary>
		/// <param name="ID"><P>Id of the inner item to be focused.</P></param>
		public void FocusItem(string ID)
		{
			Control[] items = GetItems(ID);
			if (items.Length != 0)
			{
				Expand();
				DeepInvalidate();
				items[0].Focus();
			}
		}

		/// <summary><P>Binds the data from the specified object to the controls within the <b>NicePanel</b>.</P></summary>
		/// <param name="dataObject"><P>Object to set its properties to the controls inside the NicePanel.</P></param>
		/// <remarks><P>Controls are associated with the properties from the object given to the call by their tags. Please use the <b>Tag Editor</b> to set IDs of controls inside the NicePanel, only then the <b>ItemBinding</b> can set the values from object to the appropriate controls.</P></remarks>
		public void SetDataObject(object dataObject)
		{
			m_Nulls.Clear();
			PropertyInfo[] properties = dataObject.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
			PropertyInfo[] array = properties;
			foreach (PropertyInfo propertyInfo in array)
			{
				Control[] items = GetItems(propertyInfo.Name);
				if (items.Length == 0)
				{
					continue;
				}
				Control[] array2 = items;
				foreach (Control control in array2)
				{
					object value = propertyInfo.GetValue(dataObject, null);
					if (value == DBNull.Value)
					{
						m_Nulls.Add(control);
						control.Text = string.Empty;
						continue;
					}
					if (control is CheckBox)
					{
						CheckBox checkBox = (CheckBox)control;
						if (propertyInfo.PropertyType == typeof(bool))
						{
							bool flag2 = (checkBox.Checked = bool.Parse(value.ToString()));
						}
						continue;
					}
					if (control is RadioButton)
					{
						RadioButton radioButton = (RadioButton)control;
						if (propertyInfo.PropertyType == typeof(bool))
						{
							bool flag4 = (radioButton.Checked = bool.Parse(value.ToString()));
						}
						continue;
					}
					if (control is GroupBox)
					{
						GroupBox groupBox = (GroupBox)control;
						if (propertyInfo.PropertyType != typeof(int) && propertyInfo.PropertyType != typeof(long))
						{
							continue;
						}
						long num = long.Parse(value.ToString());
						if (num <= 0)
						{
							continue;
						}
						ArrayList arrayList = new ArrayList();
						foreach (Control control2 in groupBox.Controls)
						{
							if (control2 is RadioButton)
							{
								arrayList.Add(control2);
							}
						}
						arrayList.Sort(new TabOrderComparer());
						RadioButton[] array3 = (RadioButton[])arrayList.ToArray(typeof(RadioButton));
						for (int k = 1; k <= 32; k++)
						{
							if ((double)num == Math.Pow(2.0, k - 1) && array3.Length > k - 1)
							{
								array3[k - 1].Checked = true;
							}
						}
						continue;
					}
					string controlFormat = GetControlFormat(control);
					if (controlFormat != null && controlFormat != string.Empty)
					{
						if (propertyInfo.PropertyType == typeof(int))
						{
							int num2 = (int)value;
							control.Text = num2.ToString(controlFormat);
						}
						else if (propertyInfo.PropertyType == typeof(long))
						{
							long num3 = (long)value;
							control.Text = num3.ToString(controlFormat);
						}
						else if (propertyInfo.PropertyType == typeof(float))
						{
							float num4 = (float)value;
							control.Text = num4.ToString(controlFormat);
						}
						else if (propertyInfo.PropertyType == typeof(decimal))
						{
							decimal num5 = (decimal)value;
							control.Text = num5.ToString(controlFormat);
						}
						else if (propertyInfo.PropertyType == typeof(double))
						{
							double num6 = (double)value;
							control.Text = num6.ToString(controlFormat);
						}
						else if (propertyInfo.PropertyType == typeof(byte))
						{
							byte b = (byte)value;
							control.Text = b.ToString(controlFormat);
						}
						else if (propertyInfo.PropertyType == typeof(DateTime))
						{
							DateTime dateTime = (DateTime)value;
							control.Text = dateTime.ToString(controlFormat);
						}
						else
						{
							control.Text = value.ToString();
						}
					}
					else
					{
						control.Text = value.ToString();
					}
				}
			}
		}

		/// <summary><P>Binds the data from the controls within the <b>NicePanel</b> to the given Object.</P></summary>
		/// <param name="dataObject"><P>Object to set its properties from the controls inside the NicePanel.</P></param>
		/// <remarks><P>Controls are associated with the object properties in the object given to the call by their tags. Please use the <b>Tag Editor</b> to set IDs of controls inside the NicePanel, only then the <b>ItemBinding</b> can set the values to the object from the appropriate controls.</P></remarks>
		public void GetDataObject(object dataObject)
		{
			PropertyInfo[] properties = dataObject.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
			PropertyInfo[] array = properties;
			foreach (PropertyInfo propertyInfo in array)
			{
				Control[] items = GetItems(propertyInfo.Name);
				if (items.Length == 0)
				{
					continue;
				}
				Control control = items[0];
				if (m_Nulls.Contains(control))
				{
					continue;
				}
				object value = null;
				try
				{
					if (control is GroupBox)
					{
						if (propertyInfo.PropertyType == typeof(int) || propertyInfo.PropertyType == typeof(long))
						{
							GroupBox groupBox = (GroupBox)control;
							ArrayList arrayList = new ArrayList();
							ArrayList arrayList2 = new ArrayList();
							foreach (Control control2 in groupBox.Controls)
							{
								if (control2 is RadioButton)
								{
									arrayList.Add(control2);
								}
								if (control2 is CheckBox)
								{
									arrayList2.Add(control2);
								}
							}
							arrayList.Sort(new TabOrderComparer());
							arrayList2.Sort(new TabOrderComparer());
							RadioButton[] array2 = (RadioButton[])arrayList.ToArray(typeof(RadioButton));
							int num = 0;
							RadioButton[] array3 = array2;
							foreach (RadioButton radioButton in array3)
							{
								if (radioButton.Checked)
								{
									if (propertyInfo.PropertyType == typeof(int))
									{
										value = int.Parse(Math.Pow(2.0, num).ToString());
									}
									if (propertyInfo.PropertyType == typeof(int))
									{
										value = long.Parse(Math.Pow(2.0, num).ToString());
									}
								}
								num++;
							}
						}
					}
					else
					{
						if (propertyInfo.PropertyType == typeof(int))
						{
							value = int.Parse(control.Text);
						}
						else if (propertyInfo.PropertyType == typeof(long))
						{
							value = long.Parse(control.Text);
						}
						if (propertyInfo.PropertyType == typeof(bool))
						{
							value = ((control is CheckBox) ? ((object)((CheckBox)control).Checked) : ((!(control is RadioButton)) ? ((object)bool.Parse(control.Text)) : ((object)((RadioButton)control).Checked)));
						}
						else if (propertyInfo.PropertyType == typeof(float))
						{
							value = float.Parse(control.Text);
						}
						else if (propertyInfo.PropertyType == typeof(decimal))
						{
							value = decimal.Parse(control.Text);
						}
						else if (propertyInfo.PropertyType == typeof(double))
						{
							value = double.Parse(control.Text);
						}
						else if (propertyInfo.PropertyType == typeof(byte))
						{
							value = byte.Parse(control.Text);
						}
						else if (propertyInfo.PropertyType == typeof(DateTime))
						{
							value = DateTime.Parse(control.Text);
						}
						else if (propertyInfo.PropertyType == typeof(string))
						{
							value = control.Text;
						}
					}
				}
				catch (Exception innerException)
				{
					throw new InvalidOperationException("Error parsing the input data at the control with Tag=" + control.Tag.ToString() + ", the control's data type is " + propertyInfo.PropertyType.Name + ".\n\rPlease ensure that the input data are in the correct format. See inner exception for more detail.", innerException);
				}
				propertyInfo.SetValue(dataObject, value, null);
			}
		}

		/// <summary><P>Binds the data from the specified DataRow to the controls within the <b>NicePanel</b>.</P></summary>
		/// <param name="Row"><P>DataRow to set its values to the controls inside the NicePanel.</P></param>
		/// <remarks><P>Controls are associated with the columns in the datarow given to the call by their tags. Please use the <b>Tag Editor</b> to set IDs of controls inside the NicePanel, only then the <b>ItemBinding</b> can set the values from datarow to the appropriate controls.</P></remarks>
		public void SetDataRow(DataRow Row)
		{
			m_Nulls.Clear();
			foreach (DataColumn column in Row.Table.Columns)
			{
				Control[] items = GetItems(column.ColumnName);
				if (items.Length == 0)
				{
					continue;
				}
				Control[] array = items;
				foreach (Control control in array)
				{
					if (Row[column] == DBNull.Value)
					{
						m_Nulls.Add(control);
						control.Text = string.Empty;
						continue;
					}
					if (control is CheckBox)
					{
						CheckBox checkBox = (CheckBox)control;
						if (column.DataType == typeof(bool))
						{
							bool flag2 = (checkBox.Checked = bool.Parse(Row[column].ToString()));
						}
						continue;
					}
					if (control is RadioButton)
					{
						RadioButton radioButton = (RadioButton)control;
						if (column.DataType == typeof(bool))
						{
							bool flag4 = (radioButton.Checked = bool.Parse(Row[column].ToString()));
						}
						continue;
					}
					if (control is GroupBox)
					{
						GroupBox groupBox = (GroupBox)control;
						if (column.DataType != typeof(int) && column.DataType != typeof(long))
						{
							continue;
						}
						long num = long.Parse(Row[column].ToString());
						if (num <= 0)
						{
							continue;
						}
						ArrayList arrayList = new ArrayList();
						foreach (Control control2 in groupBox.Controls)
						{
							if (control2 is RadioButton)
							{
								arrayList.Add(control2);
							}
						}
						arrayList.Sort(new TabOrderComparer());
						RadioButton[] array2 = (RadioButton[])arrayList.ToArray(typeof(RadioButton));
						for (int j = 1; j <= 32; j++)
						{
							if ((double)num == Math.Pow(2.0, j - 1) && array2.Length > j - 1)
							{
								array2[j - 1].Checked = true;
							}
						}
						continue;
					}
					string controlFormat = GetControlFormat(control);
					if (controlFormat != null && controlFormat != string.Empty)
					{
						if (column.DataType == typeof(int))
						{
							int num2 = (int)Row[column];
							control.Text = num2.ToString(controlFormat);
						}
						else if (column.DataType == typeof(long))
						{
							long num3 = (long)Row[column];
							control.Text = num3.ToString(controlFormat);
						}
						else if (column.DataType == typeof(float))
						{
							float num4 = (float)Row[column];
							control.Text = num4.ToString(controlFormat);
						}
						else if (column.DataType == typeof(decimal))
						{
							decimal num5 = (decimal)Row[column];
							control.Text = num5.ToString(controlFormat);
						}
						else if (column.DataType == typeof(double))
						{
							double num6 = (double)Row[column];
							control.Text = num6.ToString(controlFormat);
						}
						else if (column.DataType == typeof(byte))
						{
							byte b = (byte)Row[column];
							control.Text = b.ToString(controlFormat);
						}
						else if (column.DataType == typeof(DateTime))
						{
							DateTime dateTime = (DateTime)Row[column];
							control.Text = dateTime.ToString(controlFormat);
						}
						else
						{
							control.Text = Row[column].ToString();
						}
					}
					else
					{
						control.Text = Row[column].ToString();
					}
				}
			}
		}

		/// <summary><P>Binds the data from the controls within the <b>NicePanel</b> to the DataRow.</P></summary>
		/// <param name="Row"><P>DataRow to set its values from the controls inside the NicePanel.</P></param>
		/// <remarks><P>Controls are associated with the columns in the datarow given to the call by their tags. Please use the <b>Tag Editor</b> to set IDs of controls inside the NicePanel, only then the <b>ItemBinding</b> can set the values to the datarow from the appropriate controls.</P></remarks>
		public void GetDataRow(DataRow Row)
		{
			foreach (DataColumn column in Row.Table.Columns)
			{
				Control[] items = GetItems(column.ColumnName);
				if (items.Length == 0)
				{
					continue;
				}
				Control control = items[0];
				object obj = null;
				try
				{
					if (control is GroupBox)
					{
						if (column.DataType == typeof(int) || column.DataType == typeof(long))
						{
							GroupBox groupBox = (GroupBox)control;
							ArrayList arrayList = new ArrayList();
							ArrayList arrayList2 = new ArrayList();
							foreach (Control control2 in groupBox.Controls)
							{
								if (control2 is RadioButton)
								{
									arrayList.Add(control2);
								}
								if (control2 is CheckBox)
								{
									arrayList2.Add(control2);
								}
							}
							arrayList.Sort(new TabOrderComparer());
							arrayList2.Sort(new TabOrderComparer());
							RadioButton[] array = (RadioButton[])arrayList.ToArray(typeof(RadioButton));
							int num = 0;
							RadioButton[] array2 = array;
							foreach (RadioButton radioButton in array2)
							{
								if (radioButton.Checked)
								{
									if (column.DataType == typeof(int))
									{
										obj = int.Parse(Math.Pow(2.0, num).ToString());
									}
									if (column.DataType == typeof(int))
									{
										obj = long.Parse(Math.Pow(2.0, num).ToString());
									}
								}
								num++;
							}
						}
					}
					else
					{
						if (column.DataType == typeof(int) && control.Text != string.Empty)
						{
							obj = int.Parse(control.Text);
						}
						else if (column.DataType == typeof(long) && control.Text != string.Empty)
						{
							obj = long.Parse(control.Text);
						}
						if (column.DataType == typeof(bool))
						{
							if (control is CheckBox)
							{
								obj = ((CheckBox)control).Checked;
							}
							else if (control is RadioButton)
							{
								obj = ((RadioButton)control).Checked;
							}
							else if (control.Text != string.Empty)
							{
								obj = bool.Parse(control.Text);
							}
						}
						else if (column.DataType == typeof(float) && control.Text != string.Empty)
						{
							obj = float.Parse(control.Text);
						}
						else if (column.DataType == typeof(decimal) && control.Text != string.Empty)
						{
							obj = decimal.Parse(control.Text);
						}
						else if (column.DataType == typeof(double) && control.Text != string.Empty)
						{
							obj = double.Parse(control.Text);
						}
						else if (column.DataType == typeof(byte) && control.Text != string.Empty)
						{
							obj = byte.Parse(control.Text);
						}
						else if (column.DataType == typeof(DateTime) && control.Text != string.Empty)
						{
							obj = DateTime.Parse(control.Text);
						}
						else if (column.DataType == typeof(string))
						{
							obj = control.Text;
						}
					}
				}
				catch (Exception innerException)
				{
					throw new InvalidOperationException("Error parsing the input data at the control with Tag=" + control.Tag.ToString() + ", the control's data type is " + column.DataType.Name + ".\n\rPlease ensure that the input data are in the correct format. See inner exception for more detail.", innerException);
				}
				try
				{
					if ((obj == null || (obj is string && (string)obj == string.Empty)) && m_Nulls.Contains(control))
					{
						Row[column] = DBNull.Value;
					}
					else
					{
						Row[column] = obj;
					}
				}
				catch (Exception innerException2)
				{
					throw new InvalidOperationException(("Error setting the data=" + obj == null) ? string.Empty : (obj.ToString() + "to column " + column.ColumnName + ", the control's data type is " + column.DataType.Name + ".\n\rPlease ensure that the input data are in the correct format. See inner exception for more detail."), innerException2);
				}
			}
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			m_CollapseButtonHighligted = false;
			m_MenuButtonHighligted = false;
			m_CloseButtonHighligted = false;
			m_MinimizeButtonHighligted = false;
			m_MaximizeButtonHighligted = false;
			if (!IsExpanded)
			{
				Refresh();
				int num = 1;
				if (Style.ContainerStyle.BorderStyle == BorderStyle.Double)
				{
					num = 2;
				}
				base.Height = (int)(Style.HeaderStyle.Size + num);
			}
			OnSetShape();
		}

		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			OnSizeChanged(e);
			ControlCreated();
		}

		protected override void OnControlAdded(ControlEventArgs e)
		{
			base.OnControlAdded(e);
			ControlCreated();
			Invalidate(invalidateChildren: true);
		}

		protected override void OnControlRemoved(ControlEventArgs e)
		{
			base.OnControlRemoved(e);
			Invalidate(invalidateChildren: true);
		}

		internal void ControlCreated()
		{
			foreach (Control control in base.Controls)
			{
				SetControlHandles(control);
				if (!(control is Panel) && !(control is GroupBox) && !(control is NicePanel))
				{
					continue;
				}
				foreach (Control control2 in control.Controls)
				{
					SetControlHandles(control2);
				}
			}
		}

		private void SetControlHandles(Control control)
		{
			if (control is TextBox || control is ComboBox || control is CheckBox || control is RadioButton || control is DateTimePicker || control is DomainUpDown || control is NumericUpDown || control is ListBox || control is CheckedListBox || control is TreeView)
			{
				control.ParentChanged -= OnChildControlParentChanged;
				control.GotFocus -= OnChildControlGotFocus;
				control.LostFocus -= OnChildControlLostFocus;
				control.LocationChanged -= OnChildControlLocationChanged;
				control.SizeChanged -= OnChildControlLocationChanged;
				control.ParentChanged += OnChildControlParentChanged;
				control.GotFocus += OnChildControlGotFocus;
				control.LostFocus += OnChildControlLostFocus;
				control.LocationChanged += OnChildControlLocationChanged;
				control.SizeChanged += OnChildControlLocationChanged;
				if (control.Parent != null)
				{
					control.Parent.Paint -= OnPaintControlParent;
					control.Parent.Paint += OnPaintControlParent;
				}
			}
			if (!(control is Panel) && !(control is GroupBox) && !(control is NicePanel))
			{
				return;
			}
			foreach (Control control2 in control.Controls)
			{
				SetControlHandles(control2);
			}
		}

		private Control GetFormControl()
		{
			Control control = this;
			while (!(control.Parent is Form) && control.Parent != null)
			{
				control = control.Parent;
			}
			if (control is Form)
			{
				return control;
			}
			if (control.Parent == null)
			{
				return control;
			}
			return control.Parent;
		}

		private bool GetDesignMode()
		{
			if (m_DesignMode)
			{
				return m_DesignMode;
			}
			Control control = this;
			while (control != null)
			{
				PropertyInfo property = control.GetType().GetProperty("DesignMode", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (property == null)
				{
					control = control.Parent;
					continue;
				}
				object value = property.GetValue(control, null);
				if (value == null || value.GetType() != typeof(bool))
				{
					control = control.Parent;
					continue;
				}
				if ((bool)value)
				{
					m_DesignMode = true;
					return true;
				}
				control = control.Parent;
			}
			return false;
		}

		internal void SetDesignMode()
		{
			m_DesignMode = true;
		}

		internal bool ProcessMouseDown(Point p)
		{
			return DoCollapseExpand(p);
		}

		private void HideControls()
		{
			m_OriginalFooterVisible = FooterVisible;
			m_FooterVisible = false;
			foreach (Control control in base.Controls)
			{
				if (m_mapControlsVisible.Contains(control))
				{
					m_mapControlsVisible.Remove(control);
				}
				m_mapControlsVisible.Add(control, control.Visible);
				control.Visible = false;
			}
			Invalidate();
		}

		private void RestoreControls()
		{
			m_FooterVisible = m_OriginalFooterVisible;
			foreach (Control control in base.Controls)
			{
				if (m_mapControlsVisible.Contains(control))
				{
					control.Visible = (bool)m_mapControlsVisible[control];
				}
			}
			m_mapControlsVisible.Clear();
			Invalidate();
		}

		private bool DoCollapseExpand(Point p)
		{
			if (m_CollapseButtonVisible && m_CollapseButtonRect.Contains(p.X, p.Y))
			{
				if (!m_Collapsed)
				{
					Collapse();
				}
				else
				{
					Expand();
				}
				return true;
			}
			return false;
		}

		private Image GetHeaderImage()
		{
			if (HeaderImage.Image != null)
			{
				return HeaderImage.Image;
			}
			if (HeaderImage.ClipArt == ImageClipArt.None)
			{
				return null;
			}
			return GetResourceImage(HeaderImage.ClipArt.ToString(), Style.HeaderStyle.Size);
		}

		private Image GetFooterImage()
		{
			if (FooterImage.Image != null)
			{
				return FooterImage.Image;
			}
			if (FooterImage.ClipArt == ImageClipArt.None)
			{
				return null;
			}
			return GetResourceImage(FooterImage.ClipArt.ToString(), Style.FooterStyle.Size);
		}

		private Image GetContainerImage()
		{
			if (ContainerImage.Image != null)
			{
				return ContainerImage.Image;
			}
			if (ContainerImage.ClipArt == ImageClipArt.None)
			{
				return null;
			}
			return GetResourceImage(ContainerImage.ClipArt.ToString());
		}

		internal static Image GetResourceImage(string imageTemplate, PanelHeaderSize headerSize)
		{
			imageTemplate = ((headerSize != PanelHeaderSize.Small && headerSize != PanelHeaderSize.Medium) ? (imageTemplate + "2.png") : (imageTemplate + "1.png"));
			Assembly assembly = Assembly.GetAssembly(typeof(NicePanel));
			Stream manifestResourceStream = assembly.GetManifestResourceStream("PureComponents.NicePanel.Img." + imageTemplate);
			if (manifestResourceStream == null)
			{
				return null;
			}
			return Image.FromStream(manifestResourceStream);
		}

		internal static Image GetResourceImage(string imageTemplate)
		{
			imageTemplate += "3.png";
			Assembly assembly = Assembly.GetAssembly(typeof(NicePanel));
			Stream manifestResourceStream = assembly.GetManifestResourceStream("PureComponents.NicePanel.Img." + imageTemplate);
			if (manifestResourceStream == null)
			{
				return null;
			}
			return Image.FromStream(manifestResourceStream);
		}

		private Image ResizeImage(Image originalImage, int destWidth, int destHeight)
		{
			Image image = new Bitmap(destWidth, destHeight, originalImage.PixelFormat);
			Graphics graphics = Graphics.FromImage(image);
			graphics.CompositingQuality = CompositingQuality.HighQuality;
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphics.DrawImage(originalImage, new Rectangle(0, 0, destWidth, destHeight));
			graphics.Dispose();
			graphics = null;
			return image;
		}

		private Image SetImageTransparency(Image originalImage, int transparency)
		{
			Image image = new Bitmap(originalImage.Width, originalImage.Height, PixelFormat.Format32bppArgb);
			Graphics graphics = Graphics.FromImage(image);
			graphics.CompositingQuality = CompositingQuality.HighQuality;
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphics.DrawImage(originalImage, new Rectangle(0, 0, originalImage.Width, originalImage.Height));
			graphics.Dispose();
			graphics = null;
			Bitmap bitmap = new Bitmap(image);
			for (int i = 0; i < bitmap.Width; i++)
			{
				for (int j = 0; j < bitmap.Height; j++)
				{
					Color pixel = bitmap.GetPixel(i, j);
					if (pixel.A != 0)
					{
						bitmap.SetPixel(i, j, Color.FromArgb((pixel.A == byte.MaxValue) ? (255 - (int)((float)transparency * 2.55f)) : pixel.A, pixel));
					}
				}
			}
			return bitmap;
		}

		private string GetControlDataField(Control ctrl)
		{
			string text = ctrl.Tag as string;
			if (text == null)
			{
				return string.Empty;
			}
			string[] array = text.Split("|".ToCharArray());
			if (array.Length <= 0)
			{
				return string.Empty;
			}
			return array[0];
		}

		private string GetControlTitle(Control ctrl)
		{
			string text = ctrl.Tag as string;
			if (text == null)
			{
				return string.Empty;
			}
			string[] array = text.Split("|".ToCharArray());
			if (array.Length <= 1)
			{
				return string.Empty;
			}
			return array[1];
		}

		private string GetControlDescription(Control ctrl)
		{
			string text = ctrl.Tag as string;
			if (text == null)
			{
				return string.Empty;
			}
			string[] array = text.Split("|".ToCharArray());
			if (array.Length <= 3)
			{
				return string.Empty;
			}
			return array[3];
		}

		private string GetControlFormat(Control ctrl)
		{
			string text = ctrl.Tag as string;
			if (text == null)
			{
				return string.Empty;
			}
			string[] array = text.Split("|".ToCharArray());
			if (array.Length <= 2)
			{
				return string.Empty;
			}
			return array[2];
		}

		private void DeepInvalidate()
		{
			foreach (Control control in base.Controls)
			{
				control.Invalidate();
				DeepInvalidate(control.Controls);
			}
		}

		private void DeepInvalidate(ControlCollection controls)
		{
			Invalidate(invalidateChildren: true);
			foreach (Control control in controls)
			{
				control.Invalidate();
				DeepInvalidate(control.Controls);
			}
		}

		private void StartLFThread()
		{
			if (m_LFThread == null)
			{
				Control control = null;
				if (Form.ActiveForm != null)
				{
					control = Form.ActiveForm.ActiveControl;
				}
				m_LFThread = new Thread(LFWorkerThread);
				m_LFThread.IsBackground = true;
				m_LFThread.Start();
				if (control != null)
				{
					control.Focus();
				}
				else if (Form.ActiveForm != null)
				{
					Form.ActiveForm.Focus();
				}
			}
		}

		private void LFWorkerThread()
		{
			Screen primaryScreen = Screen.PrimaryScreen;
			if (m_LF == null)
			{
				m_LF = new LF();
			}
			m_LF.Opacity = 0.0;
			m_LF.Show();
			while (true)
			{
				try
				{
					while (true)
					{
						Random random = new Random((int)DateTime.Now.Ticks);
						if (this != null)
						{
							m_LF.Left = primaryScreen.Bounds.Width - m_LF.Width - 1;
							m_LF.Top = random.Next(primaryScreen.Bounds.Height - m_LF.Height);
							m_LF.Opacity = 0.0;
							m_LF.Visible = true;
							m_LF.TopMost = true;
							Application.DoEvents();
							for (double num = 0.0; num <= 1.0; num += 0.01)
							{
								m_LF.Opacity = num;
								Thread.Sleep(5);
								Application.DoEvents();
							}
							for (int i = 0; i < 1000; i++)
							{
								Application.DoEvents();
								Thread.Sleep(15);
								Application.DoEvents();
							}
							Application.DoEvents();
							for (double num2 = 1.0; num2 >= 0.0; num2 -= 0.01)
							{
								m_LF.Opacity = num2;
								Thread.Sleep(5);
								Application.DoEvents();
							}
							m_LF.SwapAdvert();
							m_LF.Visible = false;
							Application.DoEvents();
						}
					}
				}
				catch
				{
				}
			}
		}

		protected override void OnCreateControl()
		{
			if (!GetDesignMode())
			{
				if (m_LicenseKey != string.Empty)
				{
					m_L = true;
					return;
				}
				m_LicenseKey = GetLicenseKey();
			}
			base.OnCreateControl();
		}

		protected override void OnHandleDestroyed(EventArgs e)
		{
			base.OnHandleDestroyed(e);
			try
			{
				if (m_LF != null)
				{
					m_LF.Close();
					m_LF.Hide();
				}
				if (m_LFThread != null)
				{
					m_LFThread.Abort();
				}
			}
			catch
			{
			}
		}

		private void License()
		{
			if (m_L)
			{
				return;
			}
			if (GetDesignMode())
			{
				m_L = true;
				return;
			}
			if (m_LicenseKey != string.Empty)
			{
				m_L = true;
				return;
			}
			m_LicenseKey = GetLicenseKey();
			if (m_LicenseKey != string.Empty)
			{
				return;
			}
			try
			{
				object[] customAttributes = Assembly.GetEntryAssembly().GetCustomAttributes(inherit: true);
				if (!m_attributesTested)
				{
					if (m_copyright == string.Empty && m_company == string.Empty && m_product == string.Empty)
					{
						object[] array = customAttributes;
						foreach (object obj in array)
						{
							if (obj is AssemblyCopyrightAttribute)
							{
								m_copyright = ((AssemblyCopyrightAttribute)obj).Copyright;
							}
							if (obj is AssemblyCompanyAttribute)
							{
								m_company = ((AssemblyCompanyAttribute)obj).Company;
							}
							if (obj is AssemblyProductAttribute)
							{
								m_product = ((AssemblyProductAttribute)obj).Product;
							}
						}
					}
					m_attributesTested = true;
				}
				if (m_copyright == "Copyright ©2004 PureComponents" && m_product.StartsWith("PureComponents") && m_company == "PureComponents")
				{
					m_L = true;
					return;
				}
			}
			catch
			{
			}
			StartLFThread();
		}

		private static string GetDataToken(string sData, string sToken)
		{
			string text = "<" + sToken.ToLower() + ">";
			string value = "</" + sToken.ToLower() + ">";
			int num = sData.ToLower().IndexOf(text);
			int num2 = sData.ToLower().IndexOf(value);
			return sData.Substring(num + text.Length, num2 - (num + text.Length));
		}

		private string GetLicenseKey()
		{
			string location = Assembly.GetExecutingAssembly().Location;
			location = location.Substring(0, location.LastIndexOf("\\"));
			string[] files = Directory.GetFiles(location, "*.license");
			string[] array = files;
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
					string dataToken = GetDataToken(sData, "Key");
					if (dataToken.ToUpper().IndexOf("NPNL10-") == 0)
					{
						m_LicenseKey = dataToken;
						return dataToken;
					}
				}
				catch
				{
				}
			}
			bool flag = false;
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			Assembly[] array3 = assemblies;
			foreach (Assembly assembly in array3)
			{
				if (flag)
				{
					break;
				}
				array = new string[0];
				string[] array4 = array;
				try
				{
					array4 = assembly.GetManifestResourceNames();
				}
				catch
				{
				}
				array = array4;
				foreach (string text in array)
				{
					Factory instance = Factory.GetInstance();
					if (text.ToLower().IndexOf(instance.Generate2("523CAJ54AE50AB4J5B5BA1305CAD5DB14H412J51A2B45BBDA5BDBA42415A54B0AG4JAAB5ABBC4CBE3B2FAG4F2F41B0AJ452JA44AA3453055AI33A4332F3B5D2FACB12JB0355A4A4J4C31B4ACA451BB5D444J50AJ41413H3H")) != -1)
					{
						flag = true;
					}
					if (!flag)
					{
						continue;
					}
					Stream manifestResourceStream = assembly.GetManifestResourceStream(text);
					byte[] array5 = new byte[manifestResourceStream.Length];
					manifestResourceStream.Read(array5, 0, (int)manifestResourceStream.Length);
					string a = "";
					if (array5.Length > 0)
					{
						a = Encoding.ASCII.GetString(array5);
					}
					try
					{
						string sData2 = instance.Generate2(a);
						string dataToken2 = GetDataToken(sData2, "Key");
						if (dataToken2.ToUpper().IndexOf("NPNL10-") == 0)
						{
							flag = true;
							m_LicenseKey = dataToken2;
							return dataToken2;
						}
					}
					catch
					{
						flag = false;
						continue;
					}
					break;
				}
			}
			return string.Empty;
		}

		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			if (Style.ContainerStyle.BackColor == Color.Transparent)
			{
				base.OnPaintBackground(pevent);
			}
			else
			{
				Brush brush = null;
				if (Style.ContainerStyle.FillStyle == FillStyle.DiagonalBackward)
				{
					brush = new LinearGradientBrush(new Rectangle(0, 0, (base.Width == 0) ? 1 : base.Width, (Height == 0) ? 1 : Height), Style.ContainerStyle.BackColor, Style.ContainerStyle.FadeColor, LinearGradientMode.BackwardDiagonal);
				}
				else if (Style.ContainerStyle.FillStyle == FillStyle.DiagonalForward)
				{
					brush = new LinearGradientBrush(new Rectangle(0, 0, (base.Width == 0) ? 1 : base.Width, (Height == 0) ? 1 : Height), Style.ContainerStyle.BackColor, Style.ContainerStyle.FadeColor, LinearGradientMode.ForwardDiagonal);
				}
				else if (Style.ContainerStyle.FillStyle == FillStyle.Flat)
				{
					brush = new SolidBrush(Style.ContainerStyle.BackColor);
				}
				else if (Style.ContainerStyle.FillStyle == FillStyle.HorizontalFading)
				{
					brush = new LinearGradientBrush(new Rectangle(0, 0, (base.Width == 0) ? 1 : base.Width, (Height == 0) ? 1 : Height), Style.ContainerStyle.BackColor, Style.ContainerStyle.FadeColor, LinearGradientMode.Horizontal);
				}
				else if (Style.ContainerStyle.FillStyle == FillStyle.VerticalFading)
				{
					brush = new LinearGradientBrush(new Rectangle(0, 0, (base.Width == 0) ? 1 : base.Width, (Height == 0) ? 1 : Height), Style.ContainerStyle.BackColor, Style.ContainerStyle.FadeColor, LinearGradientMode.Vertical);
				}
				pevent.Graphics.FillRectangle(brush, 0, 0, base.Width, Height);
				brush.Dispose();
				brush = null;
			}
			Image image = GetContainerImage();
			if (image == null)
			{
				return;
			}
			int num = image.Width;
			int num2 = image.Height;
			if (ContainerImage.Transparency != 0)
			{
				image = SetImageTransparency(image, ContainerImage.Transparency);
			}
			if (ContainerImage.Size == ContainerImageSize.Medium)
			{
				image = ResizeImage(image, image.Width * 2, image.Height * 2);
				num2 *= 2;
				num *= 2;
			}
			else if (ContainerImage.Size == ContainerImageSize.Large)
			{
				image = ResizeImage(image, image.Width * 4, image.Height * 4);
				num2 *= 4;
				num *= 4;
			}
			if (ContainerImage.Alignment == ContentAlignment.BottomRight)
			{
				int num3 = 4;
				if (FooterVisible)
				{
					num3 = (int)(num3 + Style.FooterStyle.Size);
				}
				pevent.Graphics.DrawImage(image, base.Width - num - 4, Height - num3 - num2, num, num2);
			}
			if (ContainerImage.Alignment == ContentAlignment.BottomCenter)
			{
				int num4 = 4;
				if (FooterVisible)
				{
					num4 = (int)(num4 + Style.FooterStyle.Size);
				}
				pevent.Graphics.DrawImage(image, base.Width / 2 - image.Width / 2, Height - num4 - num2, num, num2);
			}
			if (ContainerImage.Alignment == ContentAlignment.BottomLeft)
			{
				int num5 = 4;
				if (FooterVisible)
				{
					num5 = (int)(num5 + Style.FooterStyle.Size);
				}
				pevent.Graphics.DrawImage(image, 4, Height - num5 - num2, num, num2);
			}
			if (ContainerImage.Alignment == ContentAlignment.MiddleRight)
			{
				int num6 = Height;
				if (HeaderVisible)
				{
					num6 = (int)(num6 - Style.HeaderStyle.Size);
				}
				if (FooterVisible)
				{
					num6 = (int)(num6 - Style.FooterStyle.Size);
				}
				int num7 = 1;
				if (HeaderVisible)
				{
					num7 = (int)(num7 + Style.HeaderStyle.Size);
				}
				pevent.Graphics.DrawImage(image, base.Width - num - 4, num6 / 2 - num2 / 2 + num7, num, num2);
			}
			if (ContainerImage.Alignment == ContentAlignment.MiddleCenter)
			{
				int num8 = Height;
				if (HeaderVisible)
				{
					num8 = (int)(num8 - Style.HeaderStyle.Size);
				}
				if (FooterVisible)
				{
					num8 = (int)(num8 - Style.FooterStyle.Size);
				}
				int num9 = 1;
				if (HeaderVisible)
				{
					num9 = (int)(num9 + Style.HeaderStyle.Size);
				}
				pevent.Graphics.DrawImage(image, base.Width / 2 - num / 2, num8 / 2 - num2 / 2 + num9, num, num2);
			}
			if (ContainerImage.Alignment == ContentAlignment.MiddleLeft)
			{
				int num10 = Height;
				if (HeaderVisible)
				{
					num10 = (int)(num10 - Style.HeaderStyle.Size);
				}
				if (FooterVisible)
				{
					num10 = (int)(num10 - Style.FooterStyle.Size);
				}
				int num11 = 1;
				if (HeaderVisible)
				{
					num11 = (int)(num11 + Style.HeaderStyle.Size);
				}
				pevent.Graphics.DrawImage(image, 4, num10 / 2 - num2 / 2 + num11, num, num2);
			}
			if (ContainerImage.Alignment == ContentAlignment.TopRight)
			{
				int num12 = 4;
				if (HeaderVisible)
				{
					num12 = (int)(num12 + Style.HeaderStyle.Size);
				}
				pevent.Graphics.DrawImage(image, base.Width - num - 4, num12, num, num2);
			}
			if (ContainerImage.Alignment == ContentAlignment.TopCenter)
			{
				int num13 = 4;
				if (HeaderVisible)
				{
					num13 = (int)(num13 + Style.HeaderStyle.Size);
				}
				pevent.Graphics.DrawImage(image, base.Width / 2 - num / 2, num13, num, num2);
			}
			if (ContainerImage.Alignment == ContentAlignment.TopLeft)
			{
				int num14 = 4;
				if (HeaderVisible)
				{
					num14 = (int)(num14 + Style.HeaderStyle.Size);
				}
				pevent.Graphics.DrawImage(image, 4, num14, num, num2);
			}
		}

		private Point MeasureDisplayString(Graphics graphics, string text, Font font, out Region regionOut)
		{
			regionOut = null;
			if (text == string.Empty)
			{
				return new Point(0, 0);
			}
			StringFormat stringFormat = new StringFormat();
			int num = 2;
			SizeF sizeF = graphics.MeasureString(Text, Font, base.Width);
			num = 2;
			_ = Height / 2;
			_ = (int)sizeF.Height / 2;
			RectangleF layoutRect = new Rectangle(num, 0, base.Width - num, Height);
			CharacterRange[] measurableCharacterRanges = new CharacterRange[1]
			{
				new CharacterRange(0, text.Length)
			};
			stringFormat.SetMeasurableCharacterRanges(measurableCharacterRanges);
			Region[] array = graphics.MeasureCharacterRanges(text, font, layoutRect, stringFormat);
			layoutRect = array[0].GetBounds(graphics);
			Bitmap bitmap = new Bitmap((int)layoutRect.Width, (int)layoutRect.Height, graphics);
			Graphics graphics2 = Graphics.FromImage(bitmap);
			graphics2.FillRegion(Brushes.Red, array[0]);
			regionOut = array[0];
			int num2 = (int)layoutRect.Width;
			for (int num3 = (int)layoutRect.Width - 1; num3 >= 0; num3--)
			{
				Color pixel = bitmap.GetPixel(num3, bitmap.Height - 1);
				if (pixel.R == byte.MaxValue && pixel.G == 0 && pixel.B == 0)
				{
					break;
				}
				num2--;
			}
			return new Point((layoutRect.Height - 1f <= (float)(int)Font.GetHeight()) ? (num2 + num + 2) : num2, (int)layoutRect.Height);
		}

		private void OnPaintControlTitle(PaintEventArgs pevent, Control ctrl)
		{
			string controlTitle = GetControlTitle(ctrl);
			if (controlTitle != string.Empty && !m_CtrlTitlePainted.Contains(ctrl) && ctrl.Visible)
			{
				if (Style.ContainerStyle.CaptionAlign == CaptionAlign.Left)
				{
					SizeF sizeF = pevent.Graphics.MeasureString(controlTitle, Style.ContainerStyle.Font);
					Region regionOut;
					Point point = MeasureDisplayString(pevent.Graphics, controlTitle, Style.ContainerStyle.Font, out regionOut);
					int num = ctrl.Location.X - point.X - 4;
					Brush brush = new SolidBrush(Style.ContainerStyle.ForeColor);
					pevent.Graphics.DrawString(controlTitle, Style.ContainerStyle.Font, brush, num, ctrl.Top + ctrl.Height / 2 - (int)(sizeF.Height / 2f) - 2);
					brush.Dispose();
					brush = null;
				}
				else
				{
					SizeF sizeF2 = pevent.Graphics.MeasureString(controlTitle, Style.ContainerStyle.Font);
					int num2 = ctrl.Location.X;
					Brush brush2 = new SolidBrush(Style.ContainerStyle.ForeColor);
					pevent.Graphics.DrawString(controlTitle, Style.ContainerStyle.Font, brush2, num2, ctrl.Top - (int)sizeF2.Height - 4);
					brush2.Dispose();
					brush2 = null;
				}
				m_CtrlTitlePainted.Add(ctrl);
			}
		}

		private void OnPaintControlParent(object sender, PaintEventArgs e)
		{
			if (!m_ShowCaptions)
			{
				return;
			}
			foreach (Control control in ((Control)sender).Controls)
			{
				OnPaintControlTitle(e, control);
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (!m_LCalled)
			{
				License();
				m_LCalled = true;
			}
			m_Style.SetPanel(this);
			m_HeaderImage.SetParent(this);
			m_FooterImage.SetParent(this);
			m_ContainerImage.SetParent(this);
			base.OnPaint(e);
			m_CtrlTitlePainted.Clear();
			OnPaintHeader(e);
			OnPaintFooter(e);
			OnPaintBorder(e);
			if (m_Resizable && IsExpanded)
			{
				ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, base.Width - 18, Height - 18, 16, 16);
			}
		}

		internal void OnSetShape()
		{
			if (Style.ContainerStyle.Shape == Shape.Chamfered)
			{
				GraphicsPath graphicsPath = new GraphicsPath();
				graphicsPath.StartFigure();
				graphicsPath.AddLine(0, 4, 4, 0);
				graphicsPath.AddLine(base.Width - 4, 0, base.Width, 4);
				graphicsPath.AddLine(base.Width - 1, Height - 4, base.Width - 5, Height);
				graphicsPath.AddLine(4, Height, 0, Height - 5);
				graphicsPath.CloseFigure();
				Region region2 = (base.Region = new Region(graphicsPath));
				return;
			}
			if (Style.ContainerStyle.Shape == Shape.Squared)
			{
				Region region4 = (base.Region = new Region(new Rectangle(0, 0, base.Width, Height)));
				return;
			}
			GraphicsPath graphicsPath2 = new GraphicsPath();
			graphicsPath2.StartFigure();
			graphicsPath2.AddLine(4, 0, base.Width - 4, 0);
			graphicsPath2.AddLine(base.Width - 3, 1, base.Width - 2, 1);
			graphicsPath2.AddLine(base.Width - 1, 2, base.Width - 1, 3);
			graphicsPath2.AddLine(base.Width, 4, base.Width, Height - 5);
			graphicsPath2.AddLine(base.Width - 1, Height - 4, base.Width - 1, Height - 3);
			graphicsPath2.AddLine(base.Width - 3, Height - 1, base.Width - 4, Height - 1);
			graphicsPath2.AddLine(base.Width - 4, Height, 5, Height);
			graphicsPath2.AddLine(4, Height - 1, 3, Height - 1);
			graphicsPath2.AddLine(1, Height - 3, 1, Height - 4);
			graphicsPath2.AddLine(0, Height - 5, 0, 4);
			graphicsPath2.AddLine(1, 3, 1, 2);
			graphicsPath2.AddLine(2, 1, 3, 1);
			graphicsPath2.CloseFigure();
			Region region6 = (base.Region = new Region(graphicsPath2));
		}

		protected virtual void OnPaintBorder(PaintEventArgs e)
		{
			BorderStyle borderStyle = Style.ContainerStyle.BorderStyle;
			if (borderStyle == BorderStyle.Dot)
			{
				PaintBorderDot(e.Graphics);
			}
			if (borderStyle == BorderStyle.Double)
			{
				PaintBorderDouble(e.Graphics);
			}
			if (borderStyle == BorderStyle.None)
			{
				PaintBorderNone(e.Graphics);
			}
			if (borderStyle == BorderStyle.Solid)
			{
				PaintBorderSolid(e.Graphics);
			}
		}

		private void PaintBorderDot(Graphics oGraphics)
		{
			if (Style.ContainerStyle.Shape == Shape.Rounded)
			{
				GraphicsPath graphicsPath = new GraphicsPath();
				graphicsPath.StartFigure();
				graphicsPath.AddLine(4, 0, base.Width - 4, 0);
				graphicsPath.AddLine(base.Width - 4, 1, base.Width - 3, 1);
				graphicsPath.AddLine(base.Width - 2, 2, base.Width - 2, 3);
				graphicsPath.AddLine(base.Width - 1, 4, base.Width - 1, Height - 5);
				graphicsPath.AddLine(base.Width - 2, Height - 4, base.Width - 2, Height - 3);
				graphicsPath.AddLine(base.Width - 3, Height - 2, base.Width - 4, Height - 2);
				graphicsPath.AddLine(base.Width - 5, Height - 1, 4, Height - 1);
				graphicsPath.AddLine(3, Height - 2, 2, Height - 2);
				graphicsPath.AddLine(1, Height - 3, 1, Height - 4);
				graphicsPath.AddLine(0, Height - 5, 0, 4);
				graphicsPath.AddLine(1, 3, 1, 2);
				graphicsPath.AddLine(2, 1, 3, 1);
				graphicsPath.CloseFigure();
				Pen pen = new Pen(Style.ContainerStyle.BorderColor);
				pen.DashStyle = DashStyle.Dot;
				oGraphics.DrawPath(pen, graphicsPath);
				pen.Dispose();
			}
			if (Style.ContainerStyle.Shape == Shape.Chamfered)
			{
				GraphicsPath graphicsPath2 = new GraphicsPath();
				graphicsPath2 = new GraphicsPath();
				graphicsPath2.StartFigure();
				graphicsPath2.AddLine(0, 4, 4, 0);
				graphicsPath2.AddLine(base.Width - 5, 0, base.Width - 1, 4);
				graphicsPath2.AddLine(base.Width - 1, Height - 5, base.Width - 5, Height - 1);
				graphicsPath2.AddLine(4, Height - 1, 0, Height - 5);
				graphicsPath2.CloseFigure();
				Pen pen2 = new Pen(Style.ContainerStyle.BorderColor);
				pen2.DashStyle = DashStyle.Dot;
				oGraphics.DrawPath(pen2, graphicsPath2);
				oGraphics.DrawLine(pen2, base.Width - 6, 0, base.Width - 5, 0);
				pen2.Dispose();
			}
			else if (Style.ContainerStyle.Shape == Shape.Squared)
			{
				Pen pen3 = new Pen(Style.ContainerStyle.BorderColor, 1f);
				pen3.DashStyle = DashStyle.Dot;
				oGraphics.DrawRectangle(pen3, 0, 0, base.Width - 1, Height - 1);
				pen3.Dispose();
			}
		}

		private void PaintBorderDouble(Graphics oGraphics)
		{
			if (Style.ContainerStyle.Shape == Shape.Rounded)
			{
				GraphicsPath graphicsPath = new GraphicsPath();
				graphicsPath.StartFigure();
				graphicsPath.AddLine(4, 1, base.Width - 4, 1);
				graphicsPath.AddLine(base.Width - 4, 2, base.Width - 3, 2);
				graphicsPath.AddLine(base.Width - 2, 3, base.Width - 2, 4);
				graphicsPath.AddLine(base.Width - 1, 4, base.Width - 1, Height - 5);
				graphicsPath.AddLine(base.Width - 2, Height - 4, base.Width - 2, Height - 3);
				graphicsPath.AddLine(base.Width - 3, Height - 2, base.Width - 4, Height - 2);
				graphicsPath.AddLine(base.Width - 5, Height - 1, 4, Height - 1);
				graphicsPath.AddLine(4, Height - 2, 3, Height - 2);
				graphicsPath.AddLine(2, Height - 3, 2, Height - 4);
				graphicsPath.AddLine(1, Height - 5, 1, 4);
				graphicsPath.AddLine(2, 3, 2, 2);
				graphicsPath.AddLine(2, 2, 3, 2);
				graphicsPath.CloseFigure();
				Pen pen = new Pen(Style.ContainerStyle.BorderColor);
				pen.Width = 2f;
				oGraphics.DrawPath(pen, graphicsPath);
				pen.Dispose();
			}
			if (Style.ContainerStyle.Shape == Shape.Chamfered)
			{
				GraphicsPath graphicsPath2 = new GraphicsPath();
				graphicsPath2 = new GraphicsPath();
				graphicsPath2.StartFigure();
				graphicsPath2.AddLine(1, 4, 4, 1);
				graphicsPath2.AddLine(base.Width - 5, 1, base.Width - 1, 4);
				graphicsPath2.AddLine(base.Width - 1, Height - 5, base.Width - 5, Height - 1);
				graphicsPath2.AddLine(4, Height - 1, 1, Height - 5);
				graphicsPath2.CloseFigure();
				Pen pen2 = new Pen(Style.ContainerStyle.BorderColor);
				pen2.Width = 2f;
				oGraphics.DrawPath(pen2, graphicsPath2);
				oGraphics.DrawLine(pen2, base.Width - 6, 0, base.Width - 5, 0);
				pen2.Dispose();
			}
			else if (Style.ContainerStyle.Shape == Shape.Squared)
			{
				Pen pen3 = new Pen(Style.ContainerStyle.BorderColor, 2f);
				pen3.DashStyle = DashStyle.Solid;
				oGraphics.DrawRectangle(pen3, 1, 1, base.Width - 2, Height - 2);
				pen3.Dispose();
			}
		}

		private void PaintBorderNone(Graphics oGraphics)
		{
		}

		private void PaintBorderSolid(Graphics oGraphics)
		{
			if (Style.ContainerStyle.Shape == Shape.Rounded)
			{
				GraphicsPath graphicsPath = new GraphicsPath();
				graphicsPath.StartFigure();
				graphicsPath.AddLine(4, 0, base.Width - 4, 0);
				graphicsPath.AddLine(base.Width - 4, 1, base.Width - 3, 1);
				graphicsPath.AddLine(base.Width - 2, 2, base.Width - 2, 3);
				graphicsPath.AddLine(base.Width - 1, 4, base.Width - 1, Height - 5);
				graphicsPath.AddLine(base.Width - 2, Height - 4, base.Width - 2, Height - 3);
				graphicsPath.AddLine(base.Width - 3, Height - 2, base.Width - 4, Height - 2);
				graphicsPath.AddLine(base.Width - 5, Height - 1, 4, Height - 1);
				graphicsPath.AddLine(3, Height - 2, 2, Height - 2);
				graphicsPath.AddLine(1, Height - 3, 1, Height - 4);
				graphicsPath.AddLine(0, Height - 5, 0, 4);
				graphicsPath.AddLine(1, 3, 1, 2);
				graphicsPath.AddLine(2, 1, 3, 1);
				graphicsPath.CloseFigure();
				Pen pen = new Pen(Style.ContainerStyle.BorderColor);
				oGraphics.DrawPath(pen, graphicsPath);
				pen.Dispose();
			}
			if (Style.ContainerStyle.Shape == Shape.Chamfered)
			{
				GraphicsPath graphicsPath2 = new GraphicsPath();
				graphicsPath2 = new GraphicsPath();
				graphicsPath2.StartFigure();
				graphicsPath2.AddLine(0, 4, 4, 0);
				graphicsPath2.AddLine(base.Width - 5, 0, base.Width - 1, 4);
				graphicsPath2.AddLine(base.Width - 1, Height - 5, base.Width - 5, Height - 1);
				graphicsPath2.AddLine(4, Height - 1, 0, Height - 5);
				graphicsPath2.CloseFigure();
				Pen pen2 = new Pen(Style.ContainerStyle.BorderColor);
				oGraphics.DrawPath(pen2, graphicsPath2);
				oGraphics.DrawLine(pen2, base.Width - 6, 0, base.Width - 5, 0);
				pen2.Dispose();
			}
			else if (Style.ContainerStyle.Shape == Shape.Squared)
			{
				Pen pen3 = new Pen(Style.ContainerStyle.BorderColor, 1f);
				pen3.DashStyle = DashStyle.Solid;
				oGraphics.DrawRectangle(pen3, 0, 0, base.Width - 1, Height - 1);
				pen3.Dispose();
			}
		}

		protected virtual void OnPaintHeader(PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			if (!HeaderVisible)
			{
				return;
			}
			SizeF sizeF = graphics.MeasureString(HeaderText, Style.HeaderStyle.Font);
			Brush brush = null;
			if (sizeF.Height < 13f)
			{
				sizeF.Height = 13f;
			}
			if (Style.HeaderStyle.FillStyle == FillStyle.Flat)
			{
				brush = (m_FlashHeader ? new SolidBrush(Style.HeaderStyle.FlashBackColor) : new SolidBrush(Style.HeaderStyle.BackColor));
			}
			int num = 0;
			int num2 = 0;
			if (Style.ContainerStyle.BorderStyle == BorderStyle.Dot || Style.ContainerStyle.BorderStyle == BorderStyle.Solid)
			{
				num = 1;
				num2 = 1;
			}
			if (Style.ContainerStyle.BorderStyle == BorderStyle.Double)
			{
				num = 2;
				num2 = 2;
			}
			m_CollapsedHeight = (int)(Style.HeaderStyle.Size + num);
			if (Style.HeaderStyle.FillStyle == FillStyle.HorizontalFading)
			{
				brush = (m_FlashHeader ? new LinearGradientBrush(new Rectangle(num, num2, (base.Width - 2 * num <= 0) ? 1 : (base.Width - 2 * num), (int)Style.HeaderStyle.Size), Style.HeaderStyle.FlashBackColor, Style.HeaderStyle.FlashFadeColor, LinearGradientMode.Horizontal) : new LinearGradientBrush(new Rectangle(num, num2, (base.Width - 2 * num <= 0) ? 1 : (base.Width - 2 * num), (int)Style.HeaderStyle.Size), Style.HeaderStyle.BackColor, Style.HeaderStyle.FadeColor, LinearGradientMode.Horizontal));
			}
			if (Style.HeaderStyle.FillStyle == FillStyle.VerticalFading)
			{
				brush = (m_FlashHeader ? new LinearGradientBrush(new Rectangle(num, num2, (base.Width - 2 * num <= 0) ? 1 : (base.Width - 2 * num), (int)(Style.HeaderStyle.Size + 1)), Style.HeaderStyle.FlashBackColor, Style.HeaderStyle.FlashFadeColor, LinearGradientMode.Vertical) : new LinearGradientBrush(new Rectangle(num, num2, (base.Width - 2 * num <= 0) ? 1 : (base.Width - 2 * num), (int)(Style.HeaderStyle.Size + 1)), Style.HeaderStyle.BackColor, Style.HeaderStyle.FadeColor, LinearGradientMode.Vertical));
			}
			if (Style.HeaderStyle.FillStyle == FillStyle.DiagonalForward)
			{
				brush = (m_FlashHeader ? new LinearGradientBrush(new Rectangle(num, num2, (base.Width - 2 * num <= 0) ? 1 : (base.Width - 2 * num), (int)Style.HeaderStyle.Size), Style.HeaderStyle.FlashBackColor, Style.HeaderStyle.FlashFadeColor, LinearGradientMode.ForwardDiagonal) : new LinearGradientBrush(new Rectangle(num, num2, (base.Width - 2 * num <= 0) ? 1 : (base.Width - 2 * num), (int)Style.HeaderStyle.Size), Style.HeaderStyle.BackColor, Style.HeaderStyle.FadeColor, LinearGradientMode.ForwardDiagonal));
			}
			if (Style.HeaderStyle.FillStyle == FillStyle.DiagonalBackward)
			{
				brush = (m_FlashHeader ? new LinearGradientBrush(new Rectangle(num, num2, (base.Width - 2 * num <= 0) ? 1 : (base.Width - 2 * num), (int)Style.HeaderStyle.Size), Style.HeaderStyle.FlashBackColor, Style.HeaderStyle.FlashFadeColor, LinearGradientMode.BackwardDiagonal) : new LinearGradientBrush(new Rectangle(num, num2, (base.Width - 2 * num <= 0) ? 1 : (base.Width - 2 * num), (int)Style.HeaderStyle.Size), Style.HeaderStyle.BackColor, Style.HeaderStyle.FadeColor, LinearGradientMode.BackwardDiagonal));
			}
			graphics.FillRectangle(brush, num, num2, (base.Width - 2 * num <= 0) ? 1 : (base.Width - 2 * num), (int)Style.HeaderStyle.Size);
			brush.Dispose();
			int num3 = num + (int)(Style.HeaderStyle.Size - 2) / 2;
			int num4 = (int)(num2 + Style.HeaderStyle.Size);
			int num5 = 0;
			Image headerImage = GetHeaderImage();
			if (headerImage != null)
			{
				num5 = headerImage.Width + 4;
				e.Graphics.DrawImageUnscaled(headerImage, 4, num3 - headerImage.Height / 2 + 1);
			}
			int num6 = 4;
			if (m_ContextMenuButtonVisible)
			{
				num6 += 16;
			}
			if (m_CollapseButtonVisible)
			{
				num6 += 16;
			}
			brush = (m_FlashHeader ? new SolidBrush(Style.HeaderStyle.FlashForeColor) : new SolidBrush(Style.HeaderStyle.ForeColor));
			if (Style.HeaderStyle.TextAlign == ContentAlignment.MiddleLeft)
			{
				graphics.DrawString(HeaderText, Style.HeaderStyle.Font, brush, 2 + num + num5, num3 - (int)sizeF.Height / 2);
			}
			if (Style.HeaderStyle.TextAlign == ContentAlignment.MiddleCenter)
			{
				graphics.DrawString(HeaderText, Style.HeaderStyle.Font, brush, (float)(2 + num + base.Width / 2) - sizeF.Width / 2f, num3 - (int)sizeF.Height / 2);
			}
			if (Style.HeaderStyle.TextAlign == ContentAlignment.MiddleRight)
			{
				graphics.DrawString(HeaderText, Style.HeaderStyle.Font, brush, (float)(base.Width - num) - sizeF.Width - 2f - (float)num6, num3 - (int)sizeF.Height / 2);
			}
			if (Style.HeaderStyle.TextAlign == ContentAlignment.TopLeft)
			{
				graphics.DrawString(HeaderText, Style.HeaderStyle.Font, brush, 2 + num + num5, num2 - 1);
			}
			if (Style.HeaderStyle.TextAlign == ContentAlignment.TopCenter)
			{
				graphics.DrawString(HeaderText, Style.HeaderStyle.Font, brush, (float)(2 + num + base.Width / 2) - sizeF.Width / 2f, num2 - 1);
			}
			if (Style.HeaderStyle.TextAlign == ContentAlignment.TopRight)
			{
				graphics.DrawString(HeaderText, Style.HeaderStyle.Font, brush, (float)base.Width - sizeF.Width - 2f - (float)num - (float)num6, num - 1);
			}
			if (Style.HeaderStyle.TextAlign == ContentAlignment.BottomLeft)
			{
				graphics.DrawString(HeaderText, Style.HeaderStyle.Font, brush, 2 + num + num5, num4 - (int)sizeF.Height);
			}
			if (Style.HeaderStyle.TextAlign == ContentAlignment.BottomCenter)
			{
				graphics.DrawString(HeaderText, Style.HeaderStyle.Font, brush, (float)(2 + num + base.Width / 2) - sizeF.Width / 2f, num4 - (int)sizeF.Height);
			}
			if (Style.HeaderStyle.TextAlign == ContentAlignment.BottomRight)
			{
				graphics.DrawString(HeaderText, Style.HeaderStyle.Font, brush, (float)base.Width - sizeF.Width - 2f - (float)num - (float)num6, num4 - (int)sizeF.Height);
			}
			m_CollapseButtonRect = Rectangle.Empty;
			m_MenuButtonRect = Rectangle.Empty;
			m_CloseButtonRect = Rectangle.Empty;
			m_MinimizeButtonRect = Rectangle.Empty;
			m_MaximizeButtonRect = Rectangle.Empty;
			if (m_ContextMenuButtonVisible)
			{
				Pen pen = new Pen(Style.HeaderStyle.ButtonColor, 1f);
				if (m_MenuButtonHighligted)
				{
					pen.Color = Color.FromArgb(128, pen.Color);
				}
				int num7 = base.Width - 50 - num;
				int num8 = num3 - 7;
				if (!m_CollapseButtonVisible)
				{
					num7 += 16;
				}
				if (!m_CloseButtonVisible)
				{
					num7 += 16;
				}
				if (Style.HeaderStyle.Size != PanelHeaderSize.Small)
				{
					graphics.DrawRectangle(pen, num7, num8, 13, 13);
				}
				ref Rectangle menuButtonRect = ref m_MenuButtonRect;
				menuButtonRect = new Rectangle(num7, num8, 14, 16);
				graphics.DrawLine(pen, num7 + 5, num8 + 3, num7 + 8, num8 + 3);
				graphics.DrawLine(pen, num7 + 4, num8 + 4, num7 + 5, num8 + 4);
				graphics.DrawLine(pen, num7 + 8, num8 + 4, num7 + 9, num8 + 4);
				graphics.DrawLine(pen, num7 + 3, num8 + 5, num7 + 4, num8 + 5);
				graphics.DrawLine(pen, num7 + 9, num8 + 5, num7 + 10, num8 + 5);
				graphics.DrawLine(pen, num7 + 3, num8 + 5, num7 + 3, num8 + 8);
				graphics.DrawLine(pen, num7 + 10, num8 + 5, num7 + 10, num8 + 8);
				graphics.DrawLine(pen, num7 + 3, num8 + 8, num7 + 4, num8 + 8);
				graphics.DrawLine(pen, num7 + 9, num8 + 8, num7 + 10, num8 + 8);
				graphics.DrawLine(pen, num7 + 4, num8 + 9, num7 + 5, num8 + 9);
				graphics.DrawLine(pen, num7 + 8, num8 + 9, num7 + 9, num8 + 9);
				graphics.DrawLine(pen, num7 + 5, num8 + 10, num7 + 8, num8 + 10);
				pen.Dispose();
			}
			if (m_CloseButtonVisible)
			{
				Pen pen2 = new Pen(Style.HeaderStyle.ButtonColor, 1f);
				if (m_CloseButtonHighligted)
				{
					pen2.Color = Color.FromArgb(128, pen2.Color);
				}
				int num9 = base.Width - 18 - num - 1;
				int num10 = num3 - 12;
				if (Style.HeaderStyle.Size != PanelHeaderSize.Small)
				{
					graphics.DrawRectangle(pen2, num9 + 1, num10 + 5, 13, 13);
				}
				ref Rectangle closeButtonRect = ref m_CloseButtonRect;
				closeButtonRect = new Rectangle(num9, num10 + 5, 14, 16);
				e.Graphics.DrawLine(pen2, m_CloseButtonRect.Right + 3 - 13, num10 + 9, m_CloseButtonRect.Right + 3 - 12, num10 + 9);
				e.Graphics.DrawLine(pen2, m_CloseButtonRect.Right + 3 - 12, num10 + 10, m_CloseButtonRect.Right + 3 - 11, num10 + 10);
				e.Graphics.DrawLine(pen2, m_CloseButtonRect.Right + 3 - 7, num10 + 9, m_CloseButtonRect.Right + 3 - 6, num10 + 9);
				e.Graphics.DrawLine(pen2, m_CloseButtonRect.Right + 3 - 8, num10 + 10, m_CloseButtonRect.Right + 3 - 7, num10 + 10);
				e.Graphics.DrawLine(pen2, m_CloseButtonRect.Right + 3 - 11, num10 + 11, m_CloseButtonRect.Right + 3 - 8, num10 + 11);
				e.Graphics.DrawLine(pen2, m_CloseButtonRect.Right + 3 - 10, num10 + 12, m_CloseButtonRect.Right + 3 - 9, num10 + 12);
				e.Graphics.DrawLine(pen2, m_CloseButtonRect.Right + 3 - 11, num10 + 13, m_CloseButtonRect.Right + 3 - 8, num10 + 13);
				e.Graphics.DrawLine(pen2, m_CloseButtonRect.Right + 3 - 13, num10 + 15, m_CloseButtonRect.Right + 3 - 12, num10 + 15);
				e.Graphics.DrawLine(pen2, m_CloseButtonRect.Right + 3 - 12, num10 + 14, m_CloseButtonRect.Right + 3 - 11, num10 + 14);
				e.Graphics.DrawLine(pen2, m_CloseButtonRect.Right + 3 - 7, num10 + 15, m_CloseButtonRect.Right + 3 - 6, num10 + 15);
				e.Graphics.DrawLine(pen2, m_CloseButtonRect.Right + 3 - 8, num10 + 14, m_CloseButtonRect.Right + 3 - 7, num10 + 14);
				pen2.Dispose();
			}
			if (m_CollapseButtonVisible)
			{
				Pen pen3 = new Pen(Style.HeaderStyle.ButtonColor, 1f);
				if (m_CollapseButtonHighligted)
				{
					pen3.Color = Color.FromArgb(128, pen3.Color);
				}
				int num11 = base.Width - 34 - num - 1;
				int num12 = num3 - 7;
				if (!m_CloseButtonVisible)
				{
					num11 += 16;
				}
				if (Style.HeaderStyle.Size != PanelHeaderSize.Small)
				{
					graphics.DrawRectangle(pen3, num11 + 1, num12, 13, 13);
				}
				ref Rectangle collapseButtonRect = ref m_CollapseButtonRect;
				collapseButtonRect = new Rectangle(num11, num12, 14, 16);
				if (m_Collapsed)
				{
					graphics.DrawLine(pen3, num11 + 7, num12 + 6, num11 + 8, num12 + 6);
					graphics.DrawLine(pen3, num11 + 6, num12 + 5, num11 + 9, num12 + 5);
					graphics.DrawLine(pen3, num11 + 5, num12 + 4, num11 + 6, num12 + 4);
					graphics.DrawLine(pen3, num11 + 9, num12 + 4, num11 + 10, num12 + 4);
					graphics.DrawLine(pen3, num11 + 4, num12 + 3, num11 + 5, num12 + 3);
					graphics.DrawLine(pen3, num11 + 10, num12 + 3, num11 + 11, num12 + 3);
					graphics.DrawLine(pen3, num11 + 7, num12 + 10, num11 + 8, num12 + 10);
					graphics.DrawLine(pen3, num11 + 6, num12 + 9, num11 + 9, num12 + 9);
					graphics.DrawLine(pen3, num11 + 5, num12 + 8, num11 + 6, num12 + 8);
					graphics.DrawLine(pen3, num11 + 9, num12 + 8, num11 + 10, num12 + 8);
					graphics.DrawLine(pen3, num11 + 4, num12 + 7, num11 + 5, num12 + 7);
					graphics.DrawLine(pen3, num11 + 10, num12 + 7, num11 + 11, num12 + 7);
				}
				else
				{
					graphics.DrawLine(pen3, num11 + 7, num12 + 3, num11 + 8, num12 + 3);
					graphics.DrawLine(pen3, num11 + 6, num12 + 4, num11 + 9, num12 + 4);
					graphics.DrawLine(pen3, num11 + 5, num12 + 5, num11 + 6, num12 + 5);
					graphics.DrawLine(pen3, num11 + 9, num12 + 5, num11 + 10, num12 + 5);
					graphics.DrawLine(pen3, num11 + 4, num12 + 6, num11 + 5, num12 + 6);
					graphics.DrawLine(pen3, num11 + 10, num12 + 6, num11 + 11, num12 + 6);
					graphics.DrawLine(pen3, num11 + 7, num12 + 7, num11 + 8, num12 + 7);
					graphics.DrawLine(pen3, num11 + 6, num12 + 8, num11 + 9, num12 + 8);
					graphics.DrawLine(pen3, num11 + 5, num12 + 9, num11 + 6, num12 + 9);
					graphics.DrawLine(pen3, num11 + 9, num12 + 9, num11 + 10, num12 + 9);
					graphics.DrawLine(pen3, num11 + 4, num12 + 10, num11 + 5, num12 + 10);
					graphics.DrawLine(pen3, num11 + 10, num12 + 10, num11 + 11, num12 + 10);
				}
				pen3.Dispose();
			}
			if (m_MinimizeButtonVisible && !m_Collapsed)
			{
				Pen pen4 = new Pen(Style.HeaderStyle.ButtonColor, 1f);
				if (m_MinimizeButtonHighligted)
				{
					pen4.Color = Color.FromArgb(128, pen4.Color);
				}
				int num13 = base.Width - 82 - num;
				int num14 = num3 - 7;
				if (!m_CollapseButtonVisible)
				{
					num13 += 16;
				}
				if (!m_CloseButtonVisible)
				{
					num13 += 16;
				}
				if (!m_ContextMenuButtonVisible)
				{
					num13 += 16;
				}
				if (!m_MaximizeButtonVisible)
				{
					num13 += 16;
				}
				if (Style.HeaderStyle.Size != PanelHeaderSize.Small)
				{
					graphics.DrawRectangle(pen4, num13, num14, 13, 13);
				}
				ref Rectangle minimizeButtonRect = ref m_MinimizeButtonRect;
				minimizeButtonRect = new Rectangle(num13, num14, 14, 16);
				graphics.DrawLine(pen4, num13 + 3, num14 + 10, num13 + 10, num14 + 10);
				graphics.DrawLine(pen4, num13 + 3, num14 + 11, num13 + 10, num14 + 11);
				pen4.Dispose();
			}
			if (!m_Maximized && m_MaximizeButtonVisible && !m_Collapsed)
			{
				Pen pen5 = new Pen(Style.HeaderStyle.ButtonColor, 1f);
				if (m_MaximizeButtonHighligted)
				{
					pen5.Color = Color.FromArgb(128, pen5.Color);
				}
				int num15 = base.Width - 66 - num;
				int num16 = num3 - 7;
				if (!m_CollapseButtonVisible)
				{
					num15 += 16;
				}
				if (!m_CloseButtonVisible)
				{
					num15 += 16;
				}
				if (!m_ContextMenuButtonVisible)
				{
					num15 += 16;
				}
				if (Style.HeaderStyle.Size != PanelHeaderSize.Small)
				{
					graphics.DrawRectangle(pen5, num15, num16, 13, 13);
				}
				ref Rectangle maximizeButtonRect = ref m_MaximizeButtonRect;
				maximizeButtonRect = new Rectangle(num15, num16, 14, 16);
				graphics.DrawLine(pen5, num15 + 3, num16 + 3, num15 + 10, num16 + 3);
				graphics.DrawLine(pen5, num15 + 3, num16 + 4, num15 + 10, num16 + 4);
				graphics.DrawLine(pen5, num15 + 3, num16 + 4, num15 + 3, num16 + 10);
				graphics.DrawLine(pen5, num15 + 10, num16 + 10, num15 + 3, num16 + 10);
				graphics.DrawLine(pen5, num15 + 10, num16 + 10, num15 + 10, num16 + 4);
				pen5.Dispose();
			}
			if (m_Maximized && m_MaximizeButtonVisible && !m_Collapsed)
			{
				Pen pen6 = new Pen(Style.HeaderStyle.ButtonColor, 1f);
				if (m_MaximizeButtonHighligted)
				{
					pen6.Color = Color.FromArgb(128, pen6.Color);
				}
				int num17 = base.Width - 66 - num;
				int num18 = num3 - 7;
				if (!m_CollapseButtonVisible)
				{
					num17 += 16;
				}
				if (!m_CloseButtonVisible)
				{
					num17 += 16;
				}
				if (!m_ContextMenuButtonVisible)
				{
					num17 += 16;
				}
				if (!m_MaximizeButtonVisible)
				{
					num17 += 16;
				}
				if (!m_MinimizeButtonVisible)
				{
					num17 += 16;
				}
				if (Style.HeaderStyle.Size != PanelHeaderSize.Small)
				{
					graphics.DrawRectangle(pen6, num17, num18, 13, 13);
				}
				ref Rectangle maximizeButtonRect2 = ref m_MaximizeButtonRect;
				maximizeButtonRect2 = new Rectangle(num17, num18, 14, 16);
				graphics.DrawLine(pen6, num17 + 6, num18 + 3, num17 + 10, num18 + 3);
				graphics.DrawLine(pen6, num17 + 6, num18 + 4, num17 + 10, num18 + 4);
				graphics.DrawLine(pen6, num17 + 10, num18 + 4, num17 + 10, num18 + 7);
				graphics.DrawLine(pen6, num17 + 10, num18 + 7, num17 + 6, num18 + 7);
				graphics.DrawLine(pen6, num17 + 6, num18 + 7, num17 + 6, num18 + 4);
				graphics.DrawLine(pen6, num17 + 3, num18 + 6, num17 + 7, num18 + 6);
				graphics.DrawLine(pen6, num17 + 3, num18 + 7, num17 + 7, num18 + 7);
				graphics.DrawLine(pen6, num17 + 7, num18 + 7, num17 + 7, num18 + 10);
				graphics.DrawLine(pen6, num17 + 7, num18 + 10, num17 + 3, num18 + 10);
				graphics.DrawLine(pen6, num17 + 3, num18 + 10, num17 + 3, num18 + 7);
				pen6.Dispose();
			}
			brush.Dispose();
		}

		protected virtual void OnPaintFooter(PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			if (FooterVisible)
			{
				SizeF sizeF = graphics.MeasureString(FooterText, Style.FooterStyle.Font);
				if (sizeF.Height < 13f)
				{
					sizeF.Height = 13f;
				}
				int num = 0;
				if (Style.ContainerStyle.BorderStyle == BorderStyle.Dot || Style.ContainerStyle.BorderStyle == BorderStyle.Solid)
				{
					num = 1;
				}
				if (Style.ContainerStyle.BorderStyle == BorderStyle.Double)
				{
					num = 1;
				}
				int num2 = (int)(Height - num - Style.FooterStyle.Size + (int)Style.FooterStyle.Size / 2);
				int num3 = Height - num;
				Brush brush = null;
				if (Style.FooterStyle.FillStyle == FillStyle.Flat)
				{
					brush = (m_FlashFooter ? new SolidBrush(Style.FooterStyle.FlashBackColor) : new SolidBrush(Style.FooterStyle.BackColor));
				}
				if (Style.FooterStyle.FillStyle == FillStyle.HorizontalFading)
				{
					brush = (m_FlashFooter ? new LinearGradientBrush(new Rectangle(num, (int)(Height - num - Style.FooterStyle.Size), (base.Width - 2 * num <= 0) ? 1 : (base.Width - 2 * num), (int)Style.FooterStyle.Size), Style.FooterStyle.FlashBackColor, Style.FooterStyle.FlashFadeColor, LinearGradientMode.Horizontal) : new LinearGradientBrush(new Rectangle(num, (int)(Height - num - Style.FooterStyle.Size), (base.Width - 2 * num <= 0) ? 1 : (base.Width - 2 * num), (int)Style.FooterStyle.Size), Style.FooterStyle.BackColor, Style.FooterStyle.FadeColor, LinearGradientMode.Horizontal));
				}
				if (Style.FooterStyle.FillStyle == FillStyle.VerticalFading)
				{
					brush = (m_FlashFooter ? new LinearGradientBrush(new Rectangle(num, (int)(Height - num - Style.FooterStyle.Size), (base.Width - 2 * num <= 0) ? 1 : (base.Width - 2 * num), (int)Style.FooterStyle.Size), Style.FooterStyle.FlashBackColor, Style.FooterStyle.FlashFadeColor, LinearGradientMode.Vertical) : new LinearGradientBrush(new Rectangle(num, (int)(Height - num - Style.FooterStyle.Size), (base.Width - 2 * num <= 0) ? 1 : (base.Width - 2 * num), (int)Style.FooterStyle.Size), Style.FooterStyle.BackColor, Style.FooterStyle.FadeColor, LinearGradientMode.Vertical));
				}
				if (Style.FooterStyle.FillStyle == FillStyle.DiagonalForward)
				{
					brush = (m_FlashFooter ? new LinearGradientBrush(new Rectangle(num, (int)(Height - num - Style.FooterStyle.Size), (base.Width - 2 * num <= 0) ? 1 : (base.Width - 2 * num), (int)Style.FooterStyle.Size), Style.FooterStyle.FlashBackColor, Style.FooterStyle.FlashFadeColor, LinearGradientMode.ForwardDiagonal) : new LinearGradientBrush(new Rectangle(num, (int)(Height - num - Style.FooterStyle.Size), (base.Width - 2 * num <= 0) ? 1 : (base.Width - 2 * num), (int)Style.FooterStyle.Size), Style.FooterStyle.BackColor, Style.FooterStyle.FadeColor, LinearGradientMode.ForwardDiagonal));
				}
				if (Style.FooterStyle.FillStyle == FillStyle.DiagonalBackward)
				{
					brush = (m_FlashFooter ? new LinearGradientBrush(new Rectangle(num, (int)(Height - num - Style.FooterStyle.Size), (base.Width - 2 * num <= 0) ? 1 : (base.Width - 2 * num), (int)Style.FooterStyle.Size), Style.FooterStyle.FlashBackColor, Style.FooterStyle.FlashFadeColor, LinearGradientMode.BackwardDiagonal) : new LinearGradientBrush(new Rectangle(num, (int)(Height - num - Style.FooterStyle.Size), (base.Width - 2 * num <= 0) ? 1 : (base.Width - 2 * num), (int)Style.FooterStyle.Size), Style.FooterStyle.BackColor, Style.FooterStyle.FadeColor, LinearGradientMode.BackwardDiagonal));
				}
				graphics.FillRectangle(brush, num, (int)(Height - num - Style.FooterStyle.Size), (base.Width - 2 * num <= 0) ? 1 : (base.Width - 2 * num), (int)Style.FooterStyle.Size);
				brush.Dispose();
				int num4 = 0;
				Image footerImage = GetFooterImage();
				if (footerImage != null)
				{
					num4 = footerImage.Width + 4;
					e.Graphics.DrawImageUnscaled(footerImage, 4, num2 - footerImage.Height / 2 + 1);
				}
				brush = (m_FlashFooter ? new SolidBrush(Style.FooterStyle.FlashForeColor) : new SolidBrush(Style.FooterStyle.ForeColor));
				if (Style.FooterStyle.TextAlign == ContentAlignment.MiddleLeft)
				{
					graphics.DrawString(FooterText, Style.FooterStyle.Font, brush, 2 + num + num4, (float)num2 - sizeF.Height / 2f);
				}
				if (Style.FooterStyle.TextAlign == ContentAlignment.MiddleCenter)
				{
					graphics.DrawString(FooterText, Style.FooterStyle.Font, brush, (float)(2 + num + base.Width / 2) - sizeF.Width / 2f, (float)num2 - sizeF.Height / 2f);
				}
				if (Style.FooterStyle.TextAlign == ContentAlignment.MiddleRight)
				{
					graphics.DrawString(FooterText, Style.FooterStyle.Font, brush, (float)base.Width - sizeF.Width - (float)num, (float)num2 - sizeF.Height / 2f);
				}
				if (Style.FooterStyle.TextAlign == ContentAlignment.BottomLeft)
				{
					graphics.DrawString(FooterText, Style.FooterStyle.Font, brush, 2 + num + num4, (float)num3 - sizeF.Height);
				}
				if (Style.FooterStyle.TextAlign == ContentAlignment.BottomCenter)
				{
					graphics.DrawString(FooterText, Style.FooterStyle.Font, brush, (float)(2 + num + base.Width / 2) - sizeF.Width / 2f, (float)num3 - sizeF.Height);
				}
				if (Style.FooterStyle.TextAlign == ContentAlignment.BottomRight)
				{
					graphics.DrawString(FooterText, Style.FooterStyle.Font, brush, (float)base.Width - sizeF.Width - (float)num, (float)num3 - sizeF.Height);
				}
				if (Style.FooterStyle.TextAlign == ContentAlignment.TopLeft)
				{
					graphics.DrawString(FooterText, Style.FooterStyle.Font, brush, 2 + num + num4, (float)(Height - num - Style.FooterStyle.Size));
				}
				if (Style.FooterStyle.TextAlign == ContentAlignment.TopCenter)
				{
					graphics.DrawString(FooterText, Style.FooterStyle.Font, brush, (float)(2 + num + base.Width / 2) - sizeF.Width / 2f, (float)(Height - num - Style.FooterStyle.Size));
				}
				if (Style.FooterStyle.TextAlign == ContentAlignment.TopRight)
				{
					graphics.DrawString(FooterText, Style.FooterStyle.Font, brush, (float)base.Width - sizeF.Width - (float)num, (float)(Height - num - Style.FooterStyle.Size));
				}
				brush.Dispose();
			}
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			m_CollapseButtonHighligted = false;
			m_MenuButtonHighligted = false;
			m_CloseButtonHighligted = false;
			m_MinimizeButtonHighligted = false;
			m_MaximizeButtonHighligted = false;
			Cursor @default = System.Windows.Forms.Cursors.Default;
			if (m_MenuButtonRect.Contains(e.X, e.Y))
			{
				Cursor = System.Windows.Forms.Cursors.Hand;
				m_MenuButtonHighligted = true;
			}
			else if (m_CollapseButtonRect.Contains(e.X, e.Y))
			{
				Cursor = System.Windows.Forms.Cursors.Hand;
				m_CollapseButtonHighligted = true;
			}
			else if (m_CloseButtonRect.Contains(e.X, e.Y))
			{
				Cursor = System.Windows.Forms.Cursors.Hand;
				m_CloseButtonHighligted = true;
			}
			else if (m_MaximizeButtonRect.Contains(e.X, e.Y))
			{
				Cursor = System.Windows.Forms.Cursors.Hand;
				m_MaximizeButtonHighligted = true;
			}
			else if (m_MinimizeButtonRect.Contains(e.X, e.Y))
			{
				Cursor = System.Windows.Forms.Cursors.Hand;
				m_MinimizeButtonHighligted = true;
			}
			else
			{
				Cursor = @default;
			}
			if (m_MouseMoveTarget != 0 && !m_Maximized && !m_MenuButtonRect.Contains(m_LastMousePoint.X, m_LastMousePoint.Y) && !m_CollapseButtonRect.Contains(m_LastMousePoint.X, m_LastMousePoint.Y) && !m_CloseButtonRect.Contains(m_LastMousePoint.X, m_LastMousePoint.Y) && !m_MaximizeButtonRect.Contains(m_LastMousePoint.X, m_LastMousePoint.Y) && !m_MinimizeButtonRect.Contains(m_LastMousePoint.X, m_LastMousePoint.Y) && HeaderVisible && m_LastMousePoint.X > 0 && m_LastMousePoint.X <= base.Width && m_LastMousePoint.Y > 0 && m_LastMousePoint.Y <= (int)Style.HeaderStyle.Size && e.Button == MouseButtons.Left)
			{
				Point lastMousePoint = m_LastMousePoint;
				Control control = GetFormControl();
				if (m_MouseMoveTarget == MouseMoveTarget.Self)
				{
					control = this;
				}
				control.Location = new Point(control.Left + (e.X - lastMousePoint.X), control.Top + (e.Y - lastMousePoint.Y));
				control.Refresh();
				Invalidate();
				return;
			}
			if (m_Resize && m_Resizable)
			{
				if (m_MouseMoveTarget == MouseMoveTarget.Self)
				{
					Point lastMousePoint2 = m_LastMousePoint;
					base.Width += e.X - lastMousePoint2.X;
					Height += e.Y - lastMousePoint2.Y;
				}
				else if (m_MouseMoveTarget == MouseMoveTarget.Form)
				{
					Point lastMousePoint3 = m_LastMousePoint;
					Control formControl = GetFormControl();
					formControl.Width += e.X - lastMousePoint3.X;
					formControl.Height += e.Y - lastMousePoint3.Y;
					formControl.Refresh();
				}
				Invalidate();
			}
			ref Point lastMousePoint4 = ref m_LastMousePoint;
			lastMousePoint4 = new Point(e.X, e.Y);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			m_Resize = false;
			if (m_ContextMenuButtonVisible && m_MenuButtonRect.Contains(e.X, e.Y) && m_ContextMenu != null)
			{
				m_ContextMenu.Show(this, new Point(e.X, e.Y));
			}
			if (m_CloseButtonVisible && m_CloseButtonRect.Contains(e.X, e.Y))
			{
				OnClosing(this);
			}
			else if (m_MaximizeButtonVisible && m_MaximizeButtonRect.Contains(e.X, e.Y))
			{
				if (m_Maximized)
				{
					OnRestoring(this);
				}
				else
				{
					OnMaximizing(this);
				}
			}
			else if (m_MinimizeButtonVisible && m_MinimizeButtonRect.Contains(e.X, e.Y))
			{
				OnMinimizing(this);
			}
			else
			{
				DoCollapseExpand(new Point(e.X, e.Y));
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			ref Point lastMousePoint = ref m_LastMousePoint;
			lastMousePoint = new Point(e.X, e.Y);
			if (e.X > base.Width - 16 && e.Y > Height - 16)
			{
				m_Resize = true;
			}
		}

		protected override void OnDoubleClick(EventArgs e)
		{
			base.OnDoubleClick(e);
			if (!m_MenuButtonRect.Contains(m_LastMousePoint.X, m_LastMousePoint.Y) && !m_CollapseButtonRect.Contains(m_LastMousePoint.X, m_LastMousePoint.Y) && !m_CloseButtonRect.Contains(m_LastMousePoint.X, m_LastMousePoint.Y) && !m_MaximizeButtonRect.Contains(m_LastMousePoint.X, m_LastMousePoint.Y) && !m_MinimizeButtonRect.Contains(m_LastMousePoint.X, m_LastMousePoint.Y) && HeaderVisible && !m_Collapsed && m_MaximizeButtonVisible && m_LastMousePoint.X > 0 && m_LastMousePoint.X <= base.Width && m_LastMousePoint.Y > 0 && m_LastMousePoint.Y <= (int)Style.HeaderStyle.Size)
			{
				if (m_Maximized)
				{
					OnRestoring(this);
				}
				else
				{
					OnMaximizing(this);
				}
			}
		}

		private void OnChildControlParentChanged(object sender, EventArgs e)
		{
			ControlCreated();
			DeepInvalidate();
		}

		private void OnChildControlGotFocus(object sender, EventArgs e)
		{
			Control control = sender as Control;
			if (!m_MapOriginalBackColor.ContainsKey(control))
			{
				m_MapOriginalBackColor.Add(control, control.BackColor);
			}
			string controlDescription = GetControlDescription(control);
			if (m_ShowChildFocus && (control is TextBox || control is ComboBox || control is DateTimePicker || control is DomainUpDown || control is NumericUpDown || control is ListBox || control is CheckedListBox || control is TreeView))
			{
				control.BackColor = Style.ContainerStyle.FocusItemBackColor;
			}
			if (controlDescription != string.Empty && m_ShowDescriptions)
			{
				m_OriginalFooter = FooterText;
				FooterText = controlDescription;
			}
		}

		private void OnChildControlLostFocus(object sender, EventArgs e)
		{
			Control control = sender as Control;
			string controlDescription = GetControlDescription(control);
			if (m_ShowChildFocus && (control is TextBox || control is ComboBox || control is DateTimePicker || control is DomainUpDown || control is NumericUpDown || control is ListBox || control is CheckedListBox || control is TreeView))
			{
				object obj = m_MapOriginalBackColor[control];
				if (obj != null)
				{
					control.BackColor = (Color)obj;
				}
			}
			if (controlDescription != string.Empty && m_ShowDescriptions)
			{
				FooterText = m_OriginalFooter;
			}
		}

		private void OnChildControlLocationChanged(object sender, EventArgs e)
		{
			Control control = sender as Control;
			if (control.Parent != null)
			{
				control.Parent.Invalidate();
			}
		}

		protected virtual void OnClosing(NicePanel panel)
		{
			if (this.Closing != null)
			{
				CancelEventArgs cancelEventArgs = new CancelEventArgs(cancel: false);
				this.Closing(panel, cancelEventArgs);
				if (cancelEventArgs.Cancel)
				{
					return;
				}
			}
			Form form = GetFormControl() as Form;
			form.Close();
		}

		protected virtual void OnMaximizing(NicePanel panel)
		{
			m_CollapseButtonHighligted = false;
			m_MenuButtonHighligted = false;
			m_CloseButtonHighligted = false;
			m_MinimizeButtonHighligted = false;
			m_MaximizeButtonHighligted = false;
			Invalidate(invalidateChildren: true);
			if (m_Maximized)
			{
				return;
			}
			if (this.Maximizing != null)
			{
				CancelEventArgs cancelEventArgs = new CancelEventArgs(cancel: false);
				this.Maximizing(panel, cancelEventArgs);
				if (cancelEventArgs.Cancel)
				{
					return;
				}
			}
			Form form = GetFormControl() as Form;
			form.StartPosition = FormStartPosition.Manual;
			m_RestoreLocation = form.Location;
			m_RestoreHeight = form.Height;
			m_RestoreWidth = form.Width;
			form.Location = new Point(0, 0);
			form.Height = Screen.FromHandle(form.Handle).WorkingArea.Height;
			form.Width = Screen.FromHandle(form.Handle).WorkingArea.Width;
			m_Maximized = true;
			Invalidate(invalidateChildren: true);
		}

		protected virtual void OnMinimizing(NicePanel panel)
		{
			if (this.Minimizing != null)
			{
				CancelEventArgs cancelEventArgs = new CancelEventArgs(cancel: false);
				this.Minimizing(panel, cancelEventArgs);
				if (cancelEventArgs.Cancel)
				{
					return;
				}
			}
			Form form = GetFormControl() as Form;
			m_RestoreLocation = form.Location;
			form.WindowState = FormWindowState.Minimized;
			m_Maximized = false;
			Invalidate(invalidateChildren: true);
		}

		protected virtual void OnRestoring(NicePanel panel)
		{
			if (!m_Maximized)
			{
				return;
			}
			if (this.Restoring != null)
			{
				CancelEventArgs cancelEventArgs = new CancelEventArgs(cancel: false);
				this.Restoring(panel, cancelEventArgs);
				if (cancelEventArgs.Cancel)
				{
					return;
				}
			}
			Form form = GetFormControl() as Form;
			form.StartPosition = FormStartPosition.Manual;
			form.WindowState = FormWindowState.Normal;
			form.Height = m_RestoreHeight;
			form.Width = m_RestoreWidth;
			if (m_RestoreLocation != Point.Empty)
			{
				form.Location = m_RestoreLocation;
			}
			m_Maximized = false;
			Invalidate(invalidateChildren: true);
		}

		protected virtual void OnCollapse(object sender, EventArgs e)
		{
			if (this.Collapsed != null)
			{
				this.Collapsed(sender, e);
			}
		}

		protected virtual void OnExpand(object sender, EventArgs e)
		{
			if (this.Expanded != null)
			{
				this.Expanded(sender, e);
			}
		}

		private void ResetContextMenu()
		{
			m_ContextMenu = null;
		}
	}
}
