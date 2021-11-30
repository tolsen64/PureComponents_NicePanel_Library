namespace PureComponents.NicePanel.Design
{
	internal enum SetWindowPosFlags : uint
	{
		SWP_NOSIZE = 1u,
		SWP_NOMOVE = 2u,
		SWP_NOZORDER = 4u,
		SWP_NOREDRAW = 8u,
		SWP_NOACTIVATE = 0x10u,
		SWP_FRAMECHANGED = 0x20u,
		SWP_SHOWWINDOW = 0x40u,
		SWP_HIDEWINDOW = 0x80u,
		SWP_NOCOPYBITS = 0x100u,
		SWP_NOOWNERZORDER = 0x200u,
		SWP_NOSENDCHANGING = 0x400u,
		SWP_DRAWFRAME = 0x20u,
		SWP_NOREPOSITION = 0x200u,
		SWP_DEFERERASE = 0x2000u,
		SWP_ASYNCWINDOWPOS = 0x4000u
	}
}