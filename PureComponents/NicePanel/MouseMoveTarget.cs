namespace PureComponents.NicePanel
{
	/// <summary><P>Specifies the move target of the dragdrop operation on the <see cref="T:PureComponents.NicePanel.NicePanel" /> control. </P></summary>
	/// <remarks><P>When user clicks and holds the mouse button over the NicePanel's header and then moves the control, it is possible to specify the move target to the parent form and then the form will be moved when moving the panel. This system allows you to create fully visualy enhanced forms with customized borders, possibility to collapse then and much more.</P></remarks>
	public enum MouseMoveTarget
	{
		/// <summary><P>Specifies the move target of the dragdrop opeation on the<see cref="T:PureComponents.NicePanel.NicePanel" /> control to be none object, meaning that moving is not allowed.</P></summary>
		None,
		/// <summary><P>Specifies the move target of the dragdrop opeation on the<see cref="T:PureComponents.NicePanel.NicePanel" /> control to be the <B>NicePanel</B> itself.</P></summary>
		Self,
		/// <summary><P>Specifies the move target of the dragdrop opeation on the<see cref="T:PureComponents.NicePanel.NicePanel" /> control to be the parent Form object.</P></summary>
		Form
	}
}
