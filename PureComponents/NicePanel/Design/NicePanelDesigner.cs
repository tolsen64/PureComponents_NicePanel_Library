using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace PureComponents.NicePanel.Design
{
	internal class NicePanelDesigner : ScrollableControlDesigner
	{
		private const int WM_LBUTTONDOWN = 513;

		private NicePanel m_NicePanel = null;

		private Pen m_oBorderPen;

		private ISelectionService m_oSelectionService;

		private IDesignerHost m_oDesignerHost;

		private IMenuCommandService m_oMenuService;

		private ActionMenuNative m_ActionMenu;

		private IUIService m_oUIService;

		private MenuCommand m_CmdCopy;

		private MenuCommand m_CmdPaste;

		private MenuCommand m_CmdCut;

		private MenuCommand m_CmdDelete;

		private MenuCommand m_CmdBringFront;

		private MenuCommand m_CmdSendBack;

		private MenuCommand m_CmdAlignGrid;

		private MenuCommand m_CmdLockControls;

		public override ICollection AssociatedComponents => m_NicePanel.Controls;

		public override SelectionRules SelectionRules => SelectionRules.AllSizeable | SelectionRules.Moveable | SelectionRules.Visible;

		internal NicePanel NicePanel => m_NicePanel;

		internal IDesignerHost DesignerHost => m_oDesignerHost;

		public NicePanelDesigner()
		{
			m_oBorderPen = new Pen(SystemBrushes.ControlDarkDark, 1.5f);
			m_oBorderPen.DashStyle = DashStyle.Dash;
		}

		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
			if (component is NicePanel)
			{
				m_NicePanel = component as NicePanel;
				m_NicePanel.SetDesignMode();
				m_NicePanel.Designer = this;
				m_oSelectionService = (ISelectionService)GetService(typeof(ISelectionService));
				m_oDesignerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
				m_oUIService = (IUIService)GetService(typeof(IUIService));
				m_oMenuService = (IMenuCommandService)GetService(typeof(IMenuCommandService));
				m_CmdCopy = m_oMenuService.FindCommand(StandardCommands.Copy);
				m_CmdPaste = m_oMenuService.FindCommand(StandardCommands.Paste);
				m_CmdCut = m_oMenuService.FindCommand(StandardCommands.Cut);
				m_CmdBringFront = m_oMenuService.FindCommand(StandardCommands.BringToFront);
				m_CmdSendBack = m_oMenuService.FindCommand(StandardCommands.SendToBack);
				m_CmdAlignGrid = m_oMenuService.FindCommand(StandardCommands.AlignToGrid);
				m_CmdLockControls = m_oMenuService.FindCommand(StandardCommands.LockControls);
				m_CmdDelete = m_oMenuService.FindCommand(StandardCommands.Delete);
				m_ActionMenu = new ActionMenuNative();
				m_ActionMenu.Width = 170;
				m_ActionMenu.Title = "NicePanel Action Menu";
				ActionMenuGroup oGroup = m_ActionMenu.AddMenuGroup("Layout");
				m_ActionMenu.AddMenuItem(oGroup, "Bring to Front");
				m_ActionMenu.AddMenuItem(oGroup, "Send to Back");
				m_ActionMenu.AddMenuItem(oGroup, "Align to Grid");
				m_ActionMenu.AddMenuItem(oGroup, "Lock Controls");
				oGroup = m_ActionMenu.AddMenuGroup("Editing");
				oGroup.Expanded = true;
				m_ActionMenu.AddMenuItem(oGroup, "Add AutoScroll Panel");
				m_ActionMenu.AddMenuItem(oGroup, "Remove AutoScroll Panel");
				m_ActionMenu.AddMenuItem(oGroup, "-");
				m_ActionMenu.AddMenuItem(oGroup, "Cut");
				m_ActionMenu.AddMenuItem(oGroup, "Copy");
				m_ActionMenu.AddMenuItem(oGroup, "Paste");
				m_ActionMenu.AddMenuItem(oGroup, "Delete");
				m_ActionMenu.AddMenuItem(oGroup, "-");
				m_ActionMenu.AddMenuItem(oGroup, "Style Editor...");
				m_ActionMenu.AddMenuItem(oGroup, "Control Tag Editor...");
				m_ActionMenu.AddMenuItem(oGroup, "Properties");
				m_ActionMenu.AddMenuItem(oGroup, "-");
				m_ActionMenu.AddMenuItem(oGroup, "About NicePanel...");
				oGroup = m_ActionMenu.AddMenuGroup("Color Schemes");
				m_ActionMenu.AddMenuItem(oGroup, "Default");
				m_ActionMenu.AddMenuItem(oGroup, "Forest");
				m_ActionMenu.AddMenuItem(oGroup, "Gold");
				m_ActionMenu.AddMenuItem(oGroup, "Ocean");
				m_ActionMenu.AddMenuItem(oGroup, "Rose");
				m_ActionMenu.AddMenuItem(oGroup, "Silver");
				m_ActionMenu.AddMenuItem(oGroup, "Sky");
				m_ActionMenu.AddMenuItem(oGroup, "Sunset");
				m_ActionMenu.AddMenuItem(oGroup, "Wood");
				m_ActionMenu.ItemClick += OnActionMenuNodeItemClicked;
			}
		}

		public void OnActionMenuNodeItemClicked(ActionMenuItem oItem)
		{
			if (oItem.MenuGroup.Title == "Color Schemes")
			{
				m_ActionMenu.Hide();
				m_ActionMenu.Break = true;
				Shape shape = m_NicePanel.Style.ContainerStyle.Shape;
				BorderStyle borderStyle = m_NicePanel.Style.ContainerStyle.BorderStyle;
				PanelHeaderSize size = m_NicePanel.Style.FooterStyle.Size;
				PanelHeaderSize size2 = m_NicePanel.Style.HeaderStyle.Size;
				PanelStyle panelStyle = null;
				panelStyle = oItem.Text switch
				{
					"Default" => NicePanelStyleFactory.Instance.GetDefaultStyle(), 
					"Forest" => NicePanelStyleFactory.Instance.GetForestStyle(), 
					"Gold" => NicePanelStyleFactory.Instance.GetGoldStyle(), 
					"Ocean" => NicePanelStyleFactory.Instance.GetOceanStyle(), 
					"Rose" => NicePanelStyleFactory.Instance.GetRoseStyle(), 
					"Silver" => NicePanelStyleFactory.Instance.GetSilverStyle(), 
					"Sky" => NicePanelStyleFactory.Instance.GetSkyStyle(), 
					"Sunset" => NicePanelStyleFactory.Instance.GetSunsetStyle(), 
					"Wood" => NicePanelStyleFactory.Instance.GetWoodStyle(), 
					_ => NicePanelStyleFactory.Instance.GetDefaultStyle(), 
				};
				panelStyle.FooterStyle.Size = size;
				panelStyle.HeaderStyle.Size = size2;
				panelStyle.ContainerStyle.Shape = shape;
				panelStyle.ContainerStyle.BorderStyle = borderStyle;
				string description = "Applying style " + oItem.Text;
				using DesignerTransaction designerTransaction = m_oDesignerHost.CreateTransaction(description);
				PanelStyle style = m_NicePanel.Style;
				PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(m_NicePanel);
				PropertyDescriptor propertyDescriptor = properties.Find("Style", ignoreCase: false);
				RaiseComponentChanging(propertyDescriptor);
				propertyDescriptor.SetValue(m_NicePanel, panelStyle);
				RaiseComponentChanged(propertyDescriptor, style, panelStyle);
				designerTransaction.Commit();
			}
			if (oItem.MenuGroup.Title == "Editing")
			{
				switch (oItem.Text)
				{
				case "Properties":
					m_oUIService.ShowToolWindow(StandardToolWindows.PropertyBrowser);
					m_ActionMenu.Hide();
					return;
				case "Copy":
					m_ActionMenu.Hide();
					m_CmdCopy.Invoke();
					break;
				case "Paste":
					m_ActionMenu.Hide();
					m_CmdPaste.Invoke();
					break;
				case "Cut":
					m_ActionMenu.Hide();
					m_CmdCut.Invoke();
					break;
				case "Style Editor...":
					m_ActionMenu.Hide();
					OnStyleEditor(null, EventArgs.Empty);
					break;
				case "Control Tag Editor...":
					m_ActionMenu.Hide();
					OnControlTagEditor(null, EventArgs.Empty);
					break;
				case "Delete":
					m_ActionMenu.Hide();
					m_CmdDelete.Invoke();
					break;
				case "Add AutoScroll Panel":
					m_ActionMenu.Hide();
					Thread.Sleep(300);
					OnAddAutoScrollPanel(null, EventArgs.Empty);
					break;
				case "Remove AutoScroll Panel":
					m_ActionMenu.Hide();
					Thread.Sleep(300);
					OnRemoveAutoScrollPanel(null, EventArgs.Empty);
					break;
				case "About NicePanel...":
					m_ActionMenu.Hide();
					Thread.Sleep(300);
					OnAboutNicePanel(null, EventArgs.Empty);
					break;
				}
			}
			if (oItem.MenuGroup.Title == "Layout")
			{
				switch (oItem.Text)
				{
				case "Bring to Front":
					m_ActionMenu.Hide();
					m_CmdBringFront.Invoke();
					break;
				case "Send to Back":
					m_ActionMenu.Hide();
					m_CmdSendBack.Invoke();
					break;
				case "Align to Grid":
					m_ActionMenu.Hide();
					m_CmdAlignGrid.Invoke();
					break;
				case "Lock Controls":
					m_ActionMenu.Hide();
					m_CmdLockControls.Invoke();
					break;
				}
			}
			m_ActionMenu.Hide();
		}

		private void OnRemoveAutoScrollPanel(object sender, EventArgs e)
		{
			Panel panel = null;
			foreach (Control control3 in m_NicePanel.Controls)
			{
				if (control3 is Panel && control3.Tag is string && (string)control3.Tag == "NicePanelAutoScroll" && control3.Text == "NicePanelAutoScroll")
				{
					panel = control3 as Panel;
					break;
				}
			}
			if (panel == null)
			{
				return;
			}
			while (panel.Controls.Count > 0)
			{
				Control control2 = panel.Controls[0];
				control2.Parent = m_NicePanel;
				if (m_NicePanel.HeaderVisible)
				{
					control2.Top += (int)m_NicePanel.Style.HeaderStyle.Size;
				}
			}
			m_NicePanel.Controls.Remove(panel);
			using DesignerTransaction designerTransaction = m_oDesignerHost.CreateTransaction("Removing AutoScroll Panel");
			m_oDesignerHost.DestroyComponent(panel);
			designerTransaction.Commit();
		}

		private void OnAddAutoScrollPanel(object sender, EventArgs e)
		{
			foreach (Control control3 in m_NicePanel.Controls)
			{
				if (control3 is Panel && control3.Tag is string && (string)control3.Tag == "NicePanelAutoScroll" && control3.Text == "NicePanelAutoScroll")
				{
					return;
				}
			}
			Panel panel = null;
			using (DesignerTransaction designerTransaction = m_oDesignerHost.CreateTransaction("Adding AutoScroll Panel"))
			{
				panel = CreatePanelComponent();
				panel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
				panel.Left = 1;
				panel.Width = m_NicePanel.Width - 2;
				panel.Top = (int)(m_NicePanel.Style.HeaderStyle.Size + 1);
				panel.Height = m_NicePanel.Height - m_NicePanel.Style.HeaderStyle.Size - m_NicePanel.Style.FooterStyle.Size - 2;
				panel.BackColor = Color.Transparent;
				panel.AutoScroll = true;
				panel.Tag = "NicePanelAutoScroll";
				panel.Text = "NicePanelAutoScroll";
				designerTransaction.Commit();
			}
			while (m_NicePanel.Controls.Count > 0)
			{
				Control control2 = m_NicePanel.Controls[0];
				control2.Parent = panel;
				if (m_NicePanel.HeaderVisible)
				{
					control2.Top -= (int)m_NicePanel.Style.HeaderStyle.Size;
				}
			}
			m_NicePanel.Controls.Add(panel);
			panel.SendToBack();
			panel.Invalidate();
			m_NicePanel.ControlCreated();
			m_NicePanel.Invalidate();
		}

		private void OnAboutNicePanel(object sender, EventArgs e)
		{
			AboutForm aboutForm = new AboutForm();
			aboutForm.ShowDialog();
		}

		private void OnStyleEditor(object sender, EventArgs e)
		{
			NicePanelStyleEditorForm nicePanelStyleEditorForm = new NicePanelStyleEditorForm(this);
			nicePanelStyleEditorForm.ShowDialog();
		}

		private void OnControlTagEditor(object sender, EventArgs e)
		{
			ControlTagEditorForm controlTagEditorForm = new ControlTagEditorForm(m_NicePanel, this);
			controlTagEditorForm.ShowDialog();
		}

		protected override void OnContextMenu(int x, int y)
		{
			try
			{
				m_ActionMenu.Hide();
				m_ActionMenu.Break = false;
				m_ActionMenu.Show(x - 21, y);
			}
			catch (Exception ex)
			{
				Console.Out.WriteLine(ex.ToString());
			}
		}

		protected override void OnPaintAdornments(PaintEventArgs pe)
		{
			base.OnPaintAdornments(pe);
		}

		public override void OnSetComponentDefaults()
		{
			base.OnSetComponentDefaults();
			m_NicePanel.HeaderText = m_NicePanel.Name;
		}

		protected Panel CreatePanelComponent()
		{
			return m_oDesignerHost.CreateComponent(typeof(Panel), GenerateNewPanelName()) as Panel;
		}

		protected string GenerateNewPanelName()
		{
			return GenerateNewName("Panel");
		}

		protected string GenerateNewName(string sTmpl)
		{
			int num = 1;
			IReferenceService referenceService = GetService(typeof(IReferenceService)) as IReferenceService;
			string text;
			bool flag;
			do
			{
				text = sTmpl + num;
				ComponentCollection components = m_oDesignerHost.Container.Components;
				flag = false;
				foreach (IComponent item in components)
				{
					string name = referenceService.GetName(item);
					if (name.ToLower() == text.ToLower())
					{
						flag = flag || true;
					}
				}
				num++;
			}
			while (flag);
			return text;
		}

		internal void InvokeComponentChanging(MemberDescriptor member)
		{
			RaiseComponentChanging(member);
		}

		internal void InvokeComponentChanged(MemberDescriptor member, object oldValue, object newValue)
		{
			RaiseComponentChanged(member, oldValue, newValue);
		}

		protected override void WndProc(ref Message m)
		{
			try
			{
				if (m.HWnd != m_NicePanel.Handle)
				{
					base.WndProc(ref m);
					return;
				}
				Point p = new Point(m.LParam.ToInt32());
				if (m.Msg == 513 && m_NicePanel.ProcessMouseDown(p))
				{
					m_oSelectionService.SetSelectedComponents(new Component[1] { m_NicePanel }, SelectionTypes.Click);
					RaiseComponentChanging(TypeDescriptor.GetProperties(m_NicePanel)["IsExpanded"]);
					RaiseComponentChanged(TypeDescriptor.GetProperties(m_NicePanel)["IsExpanded"], null, null);
					RaiseComponentChanging(TypeDescriptor.GetProperties(m_NicePanel)["OriginalHeight"]);
					RaiseComponentChanged(TypeDescriptor.GetProperties(m_NicePanel)["OriginalHeight"], null, null);
					RaiseComponentChanging(TypeDescriptor.GetProperties(m_NicePanel)["OriginalFooterVisible"]);
					RaiseComponentChanged(TypeDescriptor.GetProperties(m_NicePanel)["OriginalFooterVisible"], null, null);
					DefWndProc(ref m);
					return;
				}
			}
			catch
			{
			}
			base.WndProc(ref m);
		}
	}
}
