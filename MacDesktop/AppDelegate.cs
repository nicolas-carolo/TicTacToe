using AppKit;
using Foundation;
using MacDesktop;

namespace MacDesktop
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : NSApplicationDelegate
    {
        private ViewController Controller;
        public AppDelegate ()
        {
        }

		public override void DidFinishLaunching (NSNotification notification)
		{
            // Insert code here to initialize your application
        }

		public override void WillTerminate(NSNotification notification)
		{
			// Insert code here to tear down your application
		}

        partial void SinglePlayerMenuClick(Foundation.NSObject sender)
        {
            var alert = new NSAlert();
            alert.MessageText = "TicTacToe";
            alert.InformativeText = "Ok!";
            alert.RunModal();

        }

    }
}

