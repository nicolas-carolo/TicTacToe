// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using AppKit;
using Foundation;
using System.CodeDom.Compiler;

namespace MacDesktop
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSButton Button1 { get; set; }

		[Outlet]
		AppKit.NSButton Button2 { get; set; }

		[Outlet]
		AppKit.NSButton Button3 { get; set; }

		[Outlet]
		AppKit.NSButton Button4 { get; set; }

		[Outlet]
		AppKit.NSButton Button5 { get; set; }

		[Outlet]
		AppKit.NSButton Button6 { get; set; }

		[Outlet]
		AppKit.NSButton Button7 { get; set; }

		[Outlet]
		AppKit.NSButton Button8 { get; set; }

		[Outlet]
		AppKit.NSButtonCell Button9 { get; set; }

		[Outlet]
		AppKit.NSButton ResetButton { get; set; }

        [Action ("Button1Click:")]
		partial void Button1Click (Foundation.NSObject sender);

		[Action ("Button2Click:")]
		partial void Button2Click (Foundation.NSObject sender);

		[Action ("Button3Click:")]
		partial void Button3Click (Foundation.NSObject sender);

		[Action ("Button4Click:")]
		partial void Button4Click (Foundation.NSObject sender);

		[Action ("Button5Click:")]
		partial void Button5Click (Foundation.NSObject sender);

		[Action ("Button6Click:")]
		partial void Button6Click (Foundation.NSObject sender);

		[Action ("Button7Click:")]
		partial void Button7Click (Foundation.NSObject sender);

		[Action ("Button8Click:")]
		partial void Button8Click (Foundation.NSObject sender);

		[Action ("Button9Click:")]
		partial void Button9Click (Foundation.NSObject sender);

		[Action ("ButtonClick:")]
		partial void ButtonClick (Foundation.NSObject sender);

		[Action ("Label1Click:")]
		partial void Label1Click (Foundation.NSObject sender);

		[Action ("ResetButtonClick:")]
		partial void ResetButtonClick (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (Button1 != null) {
				Button1.Dispose ();
				Button1 = null;
			}

			if (Button2 != null) {
				Button2.Dispose ();
				Button2 = null;
			}

			if (Button3 != null) {
				Button3.Dispose ();
				Button3 = null;
			}

			if (Button4 != null) {
				Button4.Dispose ();
				Button4 = null;
			}

			if (Button5 != null) {
				Button5.Dispose ();
				Button5 = null;
			}

			if (Button6 != null) {
				Button6.Dispose ();
				Button6 = null;
			}

			if (Button7 != null) {
				Button7.Dispose ();
				Button7 = null;
			}

			if (Button8 != null) {
				Button8.Dispose ();
				Button8 = null;
			}

			if (Button9 != null) {
				Button9.Dispose ();
				Button9 = null;
			}

			if (ResetButton != null) {
				ResetButton.Dispose ();
				ResetButton = null;
			}
		}
	}
}
