using System;
using ObjCRuntime;

namespace KBCustomNavigationMenu
{
	public enum KBDropdownViewState : uint
	{
		WillOpen,
		DidOpen,
		WillClose,
		DidClose
	}

	public enum KBDropdownViewDirection : uint
	{
		Top,
		Bottom
	}
}
