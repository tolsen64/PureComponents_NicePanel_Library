using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace PureComponents.NicePanel.Design
{
	internal class ActionMenuNative : NativeWindow
	{
		private enum PaintItem
		{
			BT,
			BL,
			BB,
			BR,
			IGT,
			IGL,
			IGB,
			IGR,
			TGL,
			TGR,
			SMGL,
			SMW,
			SBGR,
			SPH,
			SPW,
			SG,
			SW,
			SH,
			EWG,
			EHG,
			ERG,
			ER
		}

		internal delegate void ItemClickEventHandler(ActionMenuItem oItem);

		internal bool Break = false;

		private bool m_bLayered;

		private Color m_oBackColor;

		private Color m_oControlLL;

		private Size m_oCurrentSize;

		private Point m_oScreenPos;

		private Point m_oCurrentPoint;

		private SolidBrush m_oLBrush;

		private SolidBrush m_oLLBrush;

		private Point m_oLastMousePos;

		protected bool m_bMouseOver = false;

		private static int m_nImageWidth = 16;

		private static int m_nShadowLength = 4;

		private static Bitmap m_oShadowCache = null;

		private static int m_nShadowCacheWidth = 0;

		private static int m_nShadowCacheHeight = 0;

		private bool m_bSupportsLayered = false;

		private Color m_oBorderColor = Color.FromArgb(30, 38, 145);

		private Color m_oSelectColor = Color.Azure;

		private string m_sTitle = "Context Menu";

		private int m_nWidth = 150;

		private Point m_oLastMouseDown;

		private ArrayList m_aGroups = new ArrayList();

		private Hashtable m_mapGroupBox2Rect = new Hashtable();

		private Hashtable m_mapRect2GroupBox = new Hashtable();

		private Hashtable m_mapItem2Rect = new Hashtable();

		private Hashtable m_mapRect2Item = new Hashtable();

		private ActionMenuItem m_oSelectedItem = null;

		private ActionMenuGroup m_oHighlightedGroup = null;

		private bool m_bExpandCollapseStrafeSelect = false;

		private bool m_bDrag = false;

		private static readonly int[,] m_aPosition = new int[2, 22]
		{
			{
				2, 1, 0, 1, 2, 3, 3, 5, 4, 4,
				2, 6, 5, 5, 1, 10, 4, 4, 2, 2,
				0, 0
			},
			{
				1, 0, 1, 2, 2, 1, 3, 4, 3, 3,
				2, 8, 5, 5, 5, 10, 0, 0, 2, 2,
				2, 5
			}
		};

		[Description("Font of the context menu")]
		[Category("ActionMenu")]
		public int Width
		{
			set
			{
				m_nWidth = value;
			}
		}

		[Category("ActionMenu")]
		[Description("Font of the context menu")]
		public Font Font => new Font("Microsoft Sans Serif", 8.25f);

		[Description("Title of the context menu")]
		[Category("ActionMenu")]
		public string Title
		{
			get
			{
				return m_sTitle;
			}
			set
			{
				m_sTitle = value;
			}
		}

		[Category("ActionMenu")]
		[Description("The color of the border")]
		public Color BorderColor
		{
			get
			{
				return m_oBorderColor;
			}
			set
			{
				m_oBorderColor = value;
			}
		}

		[Category("ActionMenu")]
		[Description("The color of the selected item")]
		public Color SelectColor
		{
			get
			{
				return m_oSelectColor;
			}
			set
			{
				m_oSelectColor = value;
			}
		}

		internal event ItemClickEventHandler ItemClick;

		public ActionMenuNative()
		{
			m_bSupportsLayered = OSFeature.Feature.GetVersionPresent(OSFeature.LayeredWindows) != null;
			m_oBackColor = Color.White;
			m_oControlLL = CalculateColor(SystemColors.Window, m_oBackColor, 220);
			m_oLBrush = new SolidBrush(CalculateColor(m_oBackColor, Color.White, 200));
			m_oLLBrush = new SolidBrush(m_oControlLL);
		}

		public ActionMenuGroup AddMenuGroup(string sGroup)
		{
			ActionMenuGroup actionMenuGroup = new ActionMenuGroup();
			actionMenuGroup.Title = sGroup;
			m_aGroups.Add(actionMenuGroup);
			RecalcLayout();
			Invalidate();
			return actionMenuGroup;
		}

		public void RemoveMenuGroup(ActionMenuGroup oGroup)
		{
			m_aGroups.Remove(oGroup);
			RecalcLayout();
			Invalidate();
		}

		public void ClearMenuGroups()
		{
			m_aGroups.Clear();
		}

		public ActionMenuItem AddMenuItem(ActionMenuGroup oGroup, string sItem)
		{
			ActionMenuItem actionMenuItem = new ActionMenuItem();
			actionMenuItem.Text = sItem;
			actionMenuItem.MenuGroup = oGroup;
			oGroup.Items.Add(actionMenuItem);
			return actionMenuItem;
		}

		internal bool AllGroupsExpanded()
		{
			foreach (ActionMenuGroup aGroup in m_aGroups)
			{
				if (!aGroup.Expanded)
				{
					return false;
				}
			}
			return true;
		}

		protected virtual void OnItemClick(ActionMenuItem oItem)
		{
			if (this.ItemClick != null)
			{
				this.ItemClick(oItem);
			}
		}

		public void Show(int nX, int nY)
		{
			m_bLayered = m_bSupportsLayered;
			CreateParams createParams = new CreateParams();
			createParams.Caption = "PureComponents.ActionMenu";
			RecalcLayout();
			Screen screen = Screen.FromHandle(base.Handle);
			if (nX + m_oCurrentSize.Width > screen.Bounds.Width)
			{
				nX = screen.Bounds.Width - m_oCurrentSize.Width;
			}
			if (nY + m_oCurrentSize.Height > screen.Bounds.Height)
			{
				nY = screen.Bounds.Height - m_oCurrentSize.Height;
			}
			ref Point oScreenPos = ref m_oScreenPos;
			oScreenPos = new Point(nX, nY);
			Size oCurrentSize = m_oCurrentSize;
			Point oScreenPos2 = m_oScreenPos;
			createParams.X = nX;
			createParams.Y = nY;
			createParams.Height = oCurrentSize.Height;
			createParams.Width = oCurrentSize.Width;
			createParams.Parent = IntPtr.Zero;
			createParams.Style = int.MinValue;
			createParams.ExStyle = 136;
			if (m_bLayered)
			{
				createParams.ExStyle += 524288;
			}
			if (base.Handle == IntPtr.Zero)
			{
				CreateHandle(createParams);
			}
			m_oCurrentSize = oCurrentSize;
			m_oCurrentPoint = oScreenPos2;
			if (m_bLayered)
			{
				UpdateLayeredWindow();
			}
			User32.ShowWindow(base.Handle, 4);
			MSG msg = default(MSG);
			bool flag = false;
			while (!flag && !Break)
			{
				if (!User32.WaitMessage())
				{
					continue;
				}
				while (!flag && User32.PeekMessage(ref msg, 0, 0u, 0u, 0u))
				{
					int num = m_oCurrentSize.Width - m_aPosition[0, 16];
					int num2 = m_oCurrentSize.Height - m_aPosition[0, 17];
					bool flag2 = false;
					if (msg.message == 512)
					{
						POINT pOINT = MousePositionToScreen(msg);
						if (pOINT.x >= m_oCurrentPoint.X && pOINT.x <= m_oCurrentPoint.X + num && pOINT.y >= m_oCurrentPoint.Y && pOINT.y <= m_oCurrentPoint.Y + num2)
						{
							flag2 = true;
							OnWM_MOUSEMOVE(pOINT.x, pOINT.y);
							if (m_oHighlightedGroup != null)
							{
								User32.SetCursor(User32.LoadCursor(IntPtr.Zero, 32649u));
							}
							else
							{
								User32.SetCursor(User32.LoadCursor(IntPtr.Zero, 32512u));
							}
						}
						else if (m_bDrag)
						{
							OnWM_MOUSEMOVE(pOINT.x, pOINT.y);
						}
						else
						{
							if (m_oSelectedItem != null)
							{
								m_oSelectedItem.Selected = false;
								m_oSelectedItem = null;
								RecalcLayout();
								Invalidate();
							}
							if (m_oHighlightedGroup != null)
							{
								m_oHighlightedGroup = null;
								RecalcLayout();
								Invalidate();
							}
							if (m_bExpandCollapseStrafeSelect)
							{
								m_bExpandCollapseStrafeSelect = false;
								RecalcLayout();
								Invalidate();
							}
							if (User32.GetMessage(ref msg, 0, 0u, 0u))
							{
								User32.TranslateMessage(ref msg);
								User32.DispatchMessage(ref msg);
							}
						}
					}
					if (msg.message == 514)
					{
						POINT point = MousePositionToScreen(msg);
						m_bDrag = false;
						if (point.x >= m_oCurrentPoint.X && point.x <= m_oCurrentPoint.X + num && point.y >= m_oCurrentPoint.Y && point.y <= m_oCurrentPoint.Y + num2)
						{
							flag2 = true;
							POINT pOINT2 = MousePositionToClient(point);
							if (OnWM_LBUTTONUP(pOINT2.x, pOINT2.y))
							{
								MSG msg2 = default(MSG);
								User32.GetMessage(ref msg2, 0, 0u, 0u);
								return;
							}
						}
						else
						{
							Hide();
							flag = true;
							if (User32.GetMessage(ref msg, 0, 0u, 0u))
							{
								User32.TranslateMessage(ref msg);
								User32.DispatchMessage(ref msg);
							}
						}
					}
					if (msg.message == 519 || msg.message == 516 || msg.message == 523 || msg.message == 161 || msg.message == 167 || msg.message == 164 || msg.message == 171)
					{
						POINT pOINT3 = MousePositionToScreen(msg);
						if (pOINT3.x >= m_oCurrentPoint.X && pOINT3.x <= m_oCurrentPoint.X + num && pOINT3.y >= m_oCurrentPoint.Y && pOINT3.y <= m_oCurrentPoint.Y + num2)
						{
							flag2 = true;
							if (msg.message != 516 && msg.message != 519)
							{
								if (pOINT3.x >= m_oCurrentPoint.X && pOINT3.x <= m_oCurrentPoint.X + num && pOINT3.y >= m_oCurrentPoint.Y && pOINT3.y <= m_oCurrentPoint.Y + 10)
								{
									m_bDrag = true;
								}
								else
								{
									m_bDrag = false;
								}
							}
						}
						else
						{
							m_bDrag = false;
							Hide();
							flag = true;
							if (User32.GetMessage(ref msg, 0, 0u, 0u))
							{
								User32.TranslateMessage(ref msg);
								User32.DispatchMessage(ref msg);
							}
						}
					}
					if (msg.message == 256)
					{
						int num3 = (int)msg.wParam;
						if (num3 == 27)
						{
							Hide();
							return;
						}
					}
					if (flag2)
					{
						MSG msg3 = default(MSG);
						User32.GetMessage(ref msg3, 0, 0u, 0u);
						flag2 = false;
					}
					else if (User32.GetMessage(ref msg, 0, 0u, 0u))
					{
						User32.TranslateMessage(ref msg);
						User32.DispatchMessage(ref msg);
					}
				}
			}
		}

		protected void UpdateLayeredWindow()
		{
			m_mapGroupBox2Rect.Clear();
			m_mapItem2Rect.Clear();
			m_mapRect2GroupBox.Clear();
			m_mapRect2Item.Clear();
			UpdateLayeredWindow(m_oCurrentPoint, m_oCurrentSize, byte.MaxValue);
		}

		protected void UpdateLayeredWindow(byte alpha)
		{
			UpdateLayeredWindow(m_oCurrentPoint, m_oCurrentSize, alpha);
		}

		protected void UpdateLayeredWindow(Point point, Size size, byte alpha)
		{
			Bitmap bitmap = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);
			using Graphics graphics = Graphics.FromImage(bitmap);
			Rectangle rectWin = new Rectangle(0, 0, size.Width, size.Height);
			DrawBackground(graphics, rectWin);
			DrawAllCommands(graphics);
			IntPtr dC = User32.GetDC(IntPtr.Zero);
			IntPtr intPtr = Gdi32.CreateCompatibleDC(dC);
			IntPtr hbitmap = bitmap.GetHbitmap(Color.FromArgb(0));
			IntPtr hObject = Gdi32.SelectObject(intPtr, hbitmap);
			SIZE psize;
			psize.cx = size.Width;
			psize.cy = size.Height;
			POINT pptDst;
			pptDst.x = point.X;
			pptDst.y = point.Y;
			POINT pprSrc;
			pprSrc.x = 0;
			pprSrc.y = 0;
			BLENDFUNCTION pblend = default(BLENDFUNCTION);
			pblend.BlendOp = 0;
			pblend.BlendFlags = 0;
			pblend.SourceConstantAlpha = alpha;
			pblend.AlphaFormat = 1;
			User32.UpdateLayeredWindow(base.Handle, dC, ref pptDst, ref psize, intPtr, ref pprSrc, 0, ref pblend, 2);
			Gdi32.SelectObject(intPtr, hObject);
			User32.ReleaseDC(IntPtr.Zero, dC);
			Gdi32.DeleteObject(hbitmap);
			Gdi32.DeleteDC(intPtr);
		}

		protected void RecalcLayout()
		{
			int num = 25;
			foreach (ActionMenuGroup aGroup in m_aGroups)
			{
				num += CalcGroupHeight(aGroup);
			}
			ref Size oCurrentSize = ref m_oCurrentSize;
			oCurrentSize = new Size(m_nWidth, num);
		}

		protected int CalcGroupHeight(ActionMenuGroup oGroup)
		{
			if (!oGroup.Expanded)
			{
				return 23;
			}
			int num = 28;
			foreach (ActionMenuItem item in oGroup.Items)
			{
				num = ((!(item.Text == "-")) ? (num + 20) : (num + 3));
			}
			return num;
		}

		protected void Invalidate()
		{
			UpdateLayeredWindow();
		}

		protected void DrawAllCommands(Graphics oGraphics)
		{
			int y = 0;
			Rectangle rectangle = new Rectangle(0, 0, m_oCurrentSize.Width - 1 - m_aPosition[0, 16], m_oCurrentSize.Height - 1 - m_aPosition[0, 17]);
			Brush brush = new LinearGradientBrush(new Rectangle(2, y, rectangle.Width - 3, 19), Color.FromArgb(104, 113, 221), Color.FromArgb(30, 38, 145), LinearGradientMode.Vertical);
			Font font = new Font(Font.FontFamily.Name, Font.Size, FontStyle.Bold);
			oGraphics.FillRectangle(brush, 1, 1, rectangle.Width - 1, 19);
			Pen pen = new Pen(m_oSelectColor, 1f);
			oGraphics.DrawRectangle(pen, rectangle.Width - 15, 4, 11, 10);
			oGraphics.DrawLine(pen, rectangle.Width - 13, 6, rectangle.Width - 12, 6);
			oGraphics.DrawLine(pen, rectangle.Width - 12, 7, rectangle.Width - 11, 7);
			oGraphics.DrawLine(pen, rectangle.Width - 7, 6, rectangle.Width - 6, 6);
			oGraphics.DrawLine(pen, rectangle.Width - 8, 7, rectangle.Width - 7, 7);
			oGraphics.DrawLine(pen, rectangle.Width - 11, 8, rectangle.Width - 8, 8);
			oGraphics.DrawLine(pen, rectangle.Width - 10, 9, rectangle.Width - 9, 9);
			oGraphics.DrawLine(pen, rectangle.Width - 11, 10, rectangle.Width - 8, 10);
			oGraphics.DrawLine(pen, rectangle.Width - 13, 12, rectangle.Width - 12, 12);
			oGraphics.DrawLine(pen, rectangle.Width - 12, 11, rectangle.Width - 11, 11);
			oGraphics.DrawLine(pen, rectangle.Width - 7, 12, rectangle.Width - 6, 12);
			oGraphics.DrawLine(pen, rectangle.Width - 8, 11, rectangle.Width - 7, 11);
			brush = new SolidBrush(m_oSelectColor);
			oGraphics.DrawString(m_sTitle, font, brush, 3f, 3f);
			brush.Dispose();
			y = 24;
			foreach (ActionMenuGroup aGroup in m_aGroups)
			{
				if (aGroup.Expanded)
				{
					PaintGroupExpanded(aGroup, oGraphics, ref y);
				}
				else
				{
					PaintGroupClosed(aGroup, oGraphics, ref y);
				}
			}
		}

		private void PaintGroupClosed(ActionMenuGroup oGroup, Graphics oGraphics, ref int nY)
		{
			Rectangle rectangle = new Rectangle(0, 0, m_oCurrentSize.Width - 1 - m_aPosition[0, 16], m_oCurrentSize.Height - 1 - m_aPosition[0, 17]);
			Brush brush = ((m_oHighlightedGroup != oGroup) ? new LinearGradientBrush(new Rectangle(2, nY, rectangle.Width - 3, 18), Color.FromArgb(104, 113, 221), Color.FromArgb(30, 38, 145), LinearGradientMode.Horizontal) : new LinearGradientBrush(new Rectangle(2, nY, rectangle.Width - 3, 18), Color.FromArgb(104, 113, 221), Color.FromArgb(30, 38, 145), LinearGradientMode.Horizontal));
			oGraphics.FillRectangle(brush, 2, nY, rectangle.Width - 3, 18);
			oGraphics.DrawString(oGroup.Title, Font, Brushes.White, 5f, nY + 2);
			brush.Dispose();
			Pen pen = new Pen(m_oSelectColor, 1f);
			oGraphics.DrawLine(pen, rectangle.Width - 15, nY + 5, rectangle.Width - 14, nY + 5);
			oGraphics.DrawLine(pen, rectangle.Width - 14, nY + 6, rectangle.Width - 13, nY + 6);
			oGraphics.DrawLine(pen, rectangle.Width - 13, nY + 7, rectangle.Width - 12, nY + 7);
			oGraphics.DrawLine(pen, rectangle.Width - 12, nY + 8, rectangle.Width - 11, nY + 8);
			oGraphics.DrawLine(pen, rectangle.Width - 11, nY + 7, rectangle.Width - 10, nY + 7);
			oGraphics.DrawLine(pen, rectangle.Width - 10, nY + 6, rectangle.Width - 9, nY + 6);
			oGraphics.DrawLine(pen, rectangle.Width - 9, nY + 5, rectangle.Width - 8, nY + 5);
			oGraphics.DrawLine(pen, rectangle.Width - 15, nY + 8, rectangle.Width - 14, nY + 8);
			oGraphics.DrawLine(pen, rectangle.Width - 14, nY + 9, rectangle.Width - 13, nY + 9);
			oGraphics.DrawLine(pen, rectangle.Width - 13, nY + 10, rectangle.Width - 12, nY + 10);
			oGraphics.DrawLine(pen, rectangle.Width - 12, nY + 11, rectangle.Width - 11, nY + 11);
			oGraphics.DrawLine(pen, rectangle.Width - 11, nY + 10, rectangle.Width - 10, nY + 10);
			oGraphics.DrawLine(pen, rectangle.Width - 10, nY + 9, rectangle.Width - 9, nY + 9);
			oGraphics.DrawLine(pen, rectangle.Width - 9, nY + 8, rectangle.Width - 8, nY + 8);
			pen.Dispose();
			Rectangle rectangle2 = new Rectangle(1, nY, rectangle.Width - 2, 18);
			m_mapGroupBox2Rect.Add(oGroup, rectangle2);
			m_mapRect2GroupBox.Add(rectangle2, oGroup);
			nY += 23;
		}

		private void PaintGroupExpanded(ActionMenuGroup oGroup, Graphics oGraphics, ref int nY)
		{
			Rectangle rectangle = new Rectangle(0, 0, m_oCurrentSize.Width - 1 - m_aPosition[0, 16], m_oCurrentSize.Height - 1 - m_aPosition[0, 17]);
			Brush brush = ((m_oHighlightedGroup != oGroup) ? new LinearGradientBrush(new Rectangle(2, nY, rectangle.Width - 3, 18), Color.FromArgb(104, 113, 221), Color.FromArgb(30, 38, 145), LinearGradientMode.Horizontal) : new LinearGradientBrush(new Rectangle(2, nY, rectangle.Width - 3, 18), Color.FromArgb(104, 113, 221), Color.FromArgb(30, 38, 145), LinearGradientMode.Horizontal));
			oGraphics.FillRectangle(brush, 2, nY, rectangle.Width - 3, 18);
			oGraphics.DrawString(oGroup.Title, Font, Brushes.White, 5f, nY + 2);
			brush.Dispose();
			Pen pen = new Pen(m_oSelectColor, 1f);
			oGraphics.DrawLine(pen, rectangle.Width - 12, nY + 5, rectangle.Width - 11, nY + 5);
			oGraphics.DrawLine(pen, rectangle.Width - 13, nY + 6, rectangle.Width - 12, nY + 6);
			oGraphics.DrawLine(pen, rectangle.Width - 11, nY + 6, rectangle.Width - 10, nY + 6);
			oGraphics.DrawLine(pen, rectangle.Width - 14, nY + 7, rectangle.Width - 13, nY + 7);
			oGraphics.DrawLine(pen, rectangle.Width - 10, nY + 7, rectangle.Width - 9, nY + 7);
			oGraphics.DrawLine(pen, rectangle.Width - 15, nY + 8, rectangle.Width - 14, nY + 8);
			oGraphics.DrawLine(pen, rectangle.Width - 9, nY + 8, rectangle.Width - 8, nY + 8);
			oGraphics.DrawLine(pen, rectangle.Width - 12, nY + 8, rectangle.Width - 11, nY + 8);
			oGraphics.DrawLine(pen, rectangle.Width - 13, nY + 9, rectangle.Width - 12, nY + 9);
			oGraphics.DrawLine(pen, rectangle.Width - 11, nY + 9, rectangle.Width - 10, nY + 9);
			oGraphics.DrawLine(pen, rectangle.Width - 14, nY + 10, rectangle.Width - 13, nY + 10);
			oGraphics.DrawLine(pen, rectangle.Width - 10, nY + 10, rectangle.Width - 9, nY + 10);
			oGraphics.DrawLine(pen, rectangle.Width - 15, nY + 11, rectangle.Width - 14, nY + 11);
			oGraphics.DrawLine(pen, rectangle.Width - 9, nY + 11, rectangle.Width - 8, nY + 11);
			pen.Dispose();
			Rectangle rectangle2 = new Rectangle(3, nY, rectangle.Width - 6, 18);
			m_mapGroupBox2Rect.Add(oGroup, rectangle2);
			m_mapRect2GroupBox.Add(rectangle2, oGroup);
			nY += 5;
			foreach (ActionMenuItem item in oGroup.Items)
			{
				if (item.Selected)
				{
					Brush brush2 = new SolidBrush(Color.FromArgb(234, 158, 0));
					oGraphics.FillRectangle(brush2, 2, nY + 17, rectangle.Width - 3, 20);
					brush2 = new LinearGradientBrush(new Rectangle(3, nY + 17, rectangle.Width - 5, 19), Color.FromArgb(255, 233, 185), Color.FromArgb(255, 192, 60), LinearGradientMode.Vertical);
					oGraphics.FillRectangle(brush2, 3, nY + 18, rectangle.Width - 5, 18);
					brush2.Dispose();
				}
				if (item.Text == "-")
				{
					pen = new Pen(m_oBorderColor);
					pen.DashStyle = DashStyle.Dot;
					oGraphics.DrawLine(pen, 5, nY + 18, rectangle.Width - 5, nY + 18);
					pen.Dispose();
					nY += 3;
				}
				else
				{
					oGraphics.DrawString(item.Text, Font, Brushes.Black, 5f, nY + 20);
					rectangle2 = new Rectangle(10, nY + 17, rectangle.Width - 20, 20);
					m_mapItem2Rect.Add(item, rectangle2);
					m_mapRect2Item.Add(rectangle2, item);
					nY += 20;
				}
			}
			nY += 23;
		}

		protected void DrawBackground(Graphics g, Rectangle rectWin)
		{
			Rectangle rect = new Rectangle(0, 0, rectWin.Width - 1 - m_aPosition[0, 16], rectWin.Height - 1 - m_aPosition[0, 17]);
			_ = m_aPosition[0, 5];
			_ = m_nImageWidth;
			_ = m_aPosition[0, 7];
			_ = m_aPosition[0, 1];
			int num = m_aPosition[0, 0];
			_ = rect.Height;
			_ = m_aPosition[0, 2];
			using (Brush brush = new LinearGradientBrush(new Rectangle(0, 0, rect.Width, rect.Height), Color.FromArgb(232, 250, 255), Color.FromArgb(168, 234, 255), LinearGradientMode.Horizontal))
			{
				g.FillRectangle(brush, rect);
			}
			using (Pen pen = new Pen(m_oBorderColor))
			{
				g.DrawRectangle(pen, rect);
			}
			int num2 = rect.Right + 1;
			int num3 = rect.Top + m_aPosition[0, 17];
			int num4 = rect.Bottom + 1;
			int left = rect.Left + m_aPosition[0, 16];
			DrawShadowHorizontal(g, left, num4, num2, m_aPosition[0, 17]);
			DrawShadowVertical(g, num2, num3, m_aPosition[0, 16], num4 - num3 - 1);
		}

		protected void DrawShadowVertical(Graphics g, int left, int top, int width, int height)
		{
			if (m_bLayered)
			{
				Color color = Color.FromArgb(64, 0, 0, 0);
				Color color2 = Color.FromArgb(48, 0, 0, 0);
				Color color3 = Color.FromArgb(0, 0, 0, 0);
				if (height >= m_nShadowLength)
				{
					using LinearGradientBrush brush = new LinearGradientBrush(new Point(left - m_nShadowLength, top + m_nShadowLength), new Point(left + m_nShadowLength, top), color, color3);
					g.FillRectangle(brush, left, top, m_nShadowLength, m_nShadowLength);
					top += m_nShadowLength;
					height -= m_nShadowLength;
				}
				using LinearGradientBrush brush2 = new LinearGradientBrush(new Point(left, 0), new Point(left + width, 0), color2, color3);
				g.FillRectangle(brush2, left, top, width, height + 1);
			}
			else
			{
				using SolidBrush brush3 = new SolidBrush(ControlPaint.Dark(m_oBackColor));
				g.FillRectangle(brush3, left, top, width, height + 1);
			}
		}

		protected void DrawShadowHorizontal(Graphics g, int left, int top, int width, int height)
		{
			if (m_bLayered)
			{
				Color color = Color.FromArgb(48, 0, 0, 0);
				Color color2 = Color.FromArgb(0, 0, 0, 0);
				if (width >= m_nShadowLength)
				{
					try
					{
						g.DrawImageUnscaled(GetShadowCache(m_nShadowLength, height), left + width - m_nShadowLength, top);
					}
					catch
					{
					}
					width -= m_nShadowLength;
				}
				using LinearGradientBrush brush = new LinearGradientBrush(new Point(9999, top), new Point(9999, top + height), color, color2);
				g.FillRectangle(brush, left, top, width, height);
			}
			else
			{
				using SolidBrush brush2 = new SolidBrush(ControlPaint.Dark(m_oBackColor));
				g.FillRectangle(brush2, left, top, width, height);
			}
		}

		public void Hide()
		{
			User32.ShowWindow(base.Handle, 0);
		}

		protected POINT MousePositionToClient(POINT point)
		{
			POINT pt;
			pt.x = point.x;
			pt.y = point.y;
			User32.ScreenToClient(base.Handle, ref pt);
			return pt;
		}

		protected POINT MousePositionToScreen(POINT point)
		{
			POINT pt;
			pt.x = point.x;
			pt.y = point.y;
			User32.ClientToScreen(base.Handle, ref pt);
			return pt;
		}

		protected POINT MousePositionToScreen(MSG msg)
		{
			POINT pt;
			pt.x = (short)((int)msg.lParam & 0xFFFF);
			pt.y = (short)((uint)((int)msg.lParam & -65536) >> 16);
			if (msg.message != 162 && msg.message != 168 && msg.message != 165 && msg.message != 172 && msg.message != 161 && msg.message != 167 && msg.message != 164 && msg.message != 171)
			{
				User32.ClientToScreen(msg.hwnd, ref pt);
			}
			return pt;
		}

		protected POINT MousePositionToScreen(Message msg)
		{
			POINT pt;
			pt.x = (short)((int)msg.LParam & 0xFFFF);
			pt.y = (short)((uint)((int)msg.LParam & -65536) >> 16);
			if (msg.Msg != 162 && msg.Msg != 168 && msg.Msg != 165 && msg.Msg != 172 && msg.Msg != 161 && msg.Msg != 167 && msg.Msg != 164 && msg.Msg != 171)
			{
				User32.ClientToScreen(msg.HWnd, ref pt);
			}
			return pt;
		}

		protected unsafe static Bitmap GetShadowCache(int width, int height)
		{
			if (m_nShadowCacheWidth == width && m_nShadowCacheHeight == height && m_oShadowCache != null)
			{
				return m_oShadowCache;
			}
			if (m_oShadowCache != null)
			{
				m_oShadowCache.Dispose();
			}
			Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
			BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
			uint* ptr = (uint*)(void*)bitmapData.Scan0;
			for (int i = 0; i < height; i++)
			{
				int num = bitmapData.Stride * i / 4;
				int num2 = 64 * (height - i) / (height + 1);
				for (int j = 0; j < width; j++)
				{
					int num3 = num2 * (width - j) / (width + 1);
					ptr[num + j] = (uint)(num3 << 24);
				}
			}
			bitmap.UnlockBits(bitmapData);
			m_oShadowCache = bitmap;
			m_nShadowCacheWidth = width;
			m_nShadowCacheHeight = height;
			return m_oShadowCache;
		}

		protected Color CalculateColor(Color front, Color back, int alpha)
		{
			Color color = Color.FromArgb(255, front);
			Color color2 = Color.FromArgb(255, back);
			float num = (int)color.R;
			float num2 = (int)color.G;
			float num3 = (int)color.B;
			float num4 = (int)color2.R;
			float num5 = (int)color2.G;
			float num6 = (int)color2.B;
			float num7 = num * (float)alpha / 255f + num4 * ((float)(255 - alpha) / 255f);
			float num8 = num2 * (float)alpha / 255f + num5 * ((float)(255 - alpha) / 255f);
			float num9 = num3 * (float)alpha / 255f + num6 * ((float)(255 - alpha) / 255f);
			byte red = (byte)num7;
			byte green = (byte)num8;
			byte blue = (byte)num9;
			return Color.FromArgb(255, red, green, blue);
		}

		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
			case 513:
			{
				ref Point oLastMouseDown = ref m_oLastMouseDown;
				oLastMouseDown = new Point(m.LParam.ToInt32());
				POINT point = default(POINT);
				point.x = m_oLastMouseDown.X;
				point.y = m_oLastMouseDown.Y;
				point = MousePositionToScreen(point);
				if (point.x >= m_oCurrentPoint.X && point.x <= m_oCurrentPoint.X + m_nWidth && point.y >= m_oCurrentPoint.Y && point.y <= m_oCurrentPoint.Y + 20)
				{
					m_bDrag = true;
				}
				break;
			}
			case 514:
				OnWM_LBUTTONUP();
				break;
			case 33:
				OnWM_MOUSEACTIVATE(ref m);
				break;
			case 15:
				OnWM_PAINT(ref m);
				break;
			case 32:
				OnWM_SETCURSOR();
				break;
			case 132:
				if (!OnWM_NCHITTEST(ref m))
				{
					base.WndProc(ref m);
				}
				break;
			case 28:
				Hide();
				base.WndProc(ref m);
				break;
			default:
				base.WndProc(ref m);
				break;
			}
		}

		protected bool OnWM_LBUTTONUP(int nX, int nY)
		{
			ref Point oLastMouseDown = ref m_oLastMouseDown;
			oLastMouseDown = new Point(nX, nY);
			return OnWM_LBUTTONUP();
		}

		protected bool OnWM_LBUTTONUP()
		{
			try
			{
				int num = m_oCurrentSize.Width - m_aPosition[0, 16];
				if (new Rectangle(num - 20, 1, 15, 19).Contains(m_oLastMouseDown))
				{
					Cursor.Current = System.Windows.Forms.Cursors.Arrow;
					Hide();
					return true;
				}
				foreach (object key in m_mapRect2GroupBox.Keys)
				{
					Rectangle rectangle = (Rectangle)key;
					if (rectangle.Contains(m_oLastMouseDown))
					{
						ActionMenuGroup actionMenuGroup = m_mapRect2GroupBox[rectangle] as ActionMenuGroup;
						actionMenuGroup.Expanded = !actionMenuGroup.Expanded;
						if (m_oSelectedItem != null)
						{
							m_oSelectedItem.Selected = false;
							m_oSelectedItem = null;
						}
						RecalcLayout();
						Screen screen = Screen.FromHandle(base.Handle);
						if (m_oCurrentPoint.X + m_oCurrentSize.Width > screen.Bounds.Width)
						{
							m_oCurrentPoint.X = screen.Bounds.Width - m_oCurrentSize.Width;
						}
						if (m_oCurrentPoint.Y + m_oCurrentSize.Height > screen.Bounds.Height)
						{
							m_oCurrentPoint.Y = screen.Bounds.Height - m_oCurrentSize.Height;
						}
						Invalidate();
						Cursor.Current = System.Windows.Forms.Cursors.Hand;
						return false;
					}
				}
				if (m_oSelectedItem != null)
				{
					Rectangle rectangle2 = (Rectangle)m_mapItem2Rect[m_oSelectedItem];
					if (rectangle2.Contains(m_oLastMouseDown))
					{
						OnItemClick(m_oSelectedItem);
						return true;
					}
				}
			}
			catch (Exception ex)
			{
				Exception ex2 = ex;
			}
			return false;
		}

		protected void OnWM_MOUSEMOVE(int xPos, int yPos)
		{
			xPos -= m_oCurrentPoint.X;
			yPos -= m_oCurrentPoint.Y;
			Point point = new Point(xPos, yPos);
			m_bMouseOver = true;
			if (m_bDrag)
			{
				ref Point oCurrentPoint = ref m_oCurrentPoint;
				oCurrentPoint = new Point(m_oCurrentPoint.X - (m_oLastMousePos.X - xPos), m_oCurrentPoint.Y - (m_oLastMousePos.Y - yPos));
				Screen screen = Screen.FromHandle(base.Handle);
				if (m_oCurrentPoint.X + m_oCurrentSize.Width > screen.Bounds.Width)
				{
					m_oCurrentPoint.X = screen.Bounds.Width - m_oCurrentSize.Width;
				}
				if (m_oCurrentPoint.Y + m_oCurrentSize.Height > screen.Bounds.Height)
				{
					m_oCurrentPoint.Y = screen.Bounds.Height - m_oCurrentSize.Height;
				}
				RecalcLayout();
				Invalidate();
				return;
			}
			int num = m_oCurrentSize.Width - m_aPosition[0, 16];
			if (m_oLastMousePos != point)
			{
				foreach (object key in m_mapRect2GroupBox.Keys)
				{
					Rectangle rectangle = (Rectangle)key;
					if (!rectangle.Contains(point))
					{
						continue;
					}
					ActionMenuGroup actionMenuGroup = m_mapRect2GroupBox[rectangle] as ActionMenuGroup;
					if (m_oHighlightedGroup != actionMenuGroup)
					{
						m_oHighlightedGroup = actionMenuGroup;
						RecalcLayout();
						Invalidate();
						if (Cursor.Current != System.Windows.Forms.Cursors.Hand)
						{
							Cursor.Current = System.Windows.Forms.Cursors.Hand;
						}
					}
					return;
				}
				foreach (object key2 in m_mapRect2Item.Keys)
				{
					Rectangle rectangle2 = (Rectangle)key2;
					if (!rectangle2.Contains(point))
					{
						continue;
					}
					ActionMenuItem actionMenuItem = m_mapRect2Item[rectangle2] as ActionMenuItem;
					if (!actionMenuItem.Selected)
					{
						if (m_oSelectedItem != null)
						{
							m_oSelectedItem.Selected = false;
						}
						actionMenuItem.Selected = true;
						m_oSelectedItem = actionMenuItem;
						m_oHighlightedGroup = null;
						RecalcLayout();
						Invalidate();
					}
					return;
				}
				if (new Rectangle(num - 15, 3, 11, 10).Contains(point))
				{
					Cursor.Current = System.Windows.Forms.Cursors.Hand;
					return;
				}
				if (m_oSelectedItem != null)
				{
					m_oSelectedItem.Selected = false;
					m_oSelectedItem = null;
					RecalcLayout();
					Invalidate();
				}
				if (m_oHighlightedGroup != null)
				{
					m_oHighlightedGroup = null;
					RecalcLayout();
					Invalidate();
				}
				if (m_bExpandCollapseStrafeSelect)
				{
					m_bExpandCollapseStrafeSelect = false;
					RecalcLayout();
					Invalidate();
				}
			}
			m_oLastMousePos = point;
		}

		protected void OnWM_MOUSELEAVE()
		{
			m_bMouseOver = false;
			ref Point oLastMousePos = ref m_oLastMousePos;
			oLastMousePos = new Point(-1, -1);
		}

		protected void OnWM_MOUSEACTIVATE(ref Message m)
		{
			m.Result = (IntPtr)3L;
		}

		protected void OnWM_SETCURSOR()
		{
		}

		protected void OnWM_PAINT(ref Message m)
		{
			PAINTSTRUCT ps = default(PAINTSTRUCT);
			IntPtr hdc = User32.BeginPaint(m.HWnd, ref ps);
			RECT rect = default(RECT);
			User32.GetWindowRect(base.Handle, ref rect);
			Rectangle rectWin = new Rectangle(0, 0, rect.right - rect.left, rect.bottom - rect.top);
			using (Graphics graphics2 = Graphics.FromHdc(hdc))
			{
				Bitmap image = new Bitmap(rectWin.Width, rectWin.Height);
				using (Graphics graphics = Graphics.FromImage(image))
				{
					DrawBackground(graphics, rectWin);
					DrawAllCommands(graphics);
				}
				graphics2.DrawImageUnscaled(image, 0, 0);
			}
			User32.EndPaint(m.HWnd, ref ps);
		}

		protected bool OnWM_NCHITTEST(ref Message m)
		{
			POINT pOINT;
			pOINT.x = (short)((int)m.LParam & 0xFFFF);
			pOINT.y = (short)((uint)((int)m.LParam & -65536) >> 16);
			POINT pt;
			pt.x = m_oCurrentSize.Width - m_aPosition[0, 16];
			pt.y = m_oCurrentSize.Height - m_aPosition[0, 17];
			User32.ClientToScreen(base.Handle, ref pt);
			if (pOINT.x > pt.x || pOINT.y > pt.y)
			{
				m.Result = (IntPtr)(-1L);
				return true;
			}
			return false;
		}
	}
}
