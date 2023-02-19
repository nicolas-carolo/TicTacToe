using System;

using AppKit;
using Darwin;
using Foundation;
using XamarinBusinessLayer.Entities;

namespace MacDesktop
{
	public partial class ViewController : NSViewController
	{
        private Controller Controller { get; set; }
        private BotPlayer BotPlayer { get; set; }

    public ViewController (IntPtr handle) : base (handle)
		{
            this.Controller = new Controller(1);
            this.BotPlayer = new BotPlayer(1);
        }

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

            Button1.Enabled = false;
            Button2.Enabled = false;
            Button3.Enabled = false;
            Button4.Enabled = false;
            Button5.Enabled = false;
            Button6.Enabled = false;
            Button7.Enabled = false;
            Button8.Enabled = false;
            Button9.Enabled = false;
        }

		public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }

        partial void Button1Click(Foundation.NSObject sender)
        {
            Cell cell = this.Controller.CellPressed(1);
            Button1.Title = IntToCrossCyrcle(cell.PressedBy);
            Button1.Enabled = false;
            PrintMessage(cell);
            if (cell.Winner == 0)
            {
                CallBot();
            }
        }

        partial void Button2Click(Foundation.NSObject sender)
        {
            Cell cell = this.Controller.CellPressed(2);
            Button2.Title = IntToCrossCyrcle(cell.PressedBy);
            Button2.Enabled = false;
            PrintMessage(cell);
            if (cell.Winner == 0)
            {
                CallBot();
            }
        }

        partial void Button3Click(Foundation.NSObject sender)
        {
            Cell cell = this.Controller.CellPressed(3);
            Button3.Title = IntToCrossCyrcle(cell.PressedBy);
            Button3.Enabled = false;
            PrintMessage(cell);
            if (cell.Winner == 0)
            {
                CallBot();
            }
        }

        partial void Button4Click(Foundation.NSObject sender)
        {
            Cell cell = this.Controller.CellPressed(4);
            Button4.Title = IntToCrossCyrcle(cell.PressedBy);
            Button4.Enabled = false;
            PrintMessage(cell);
            if (cell.Winner == 0)
            {
                CallBot();
            }
        }

        partial void Button5Click(Foundation.NSObject sender)
        {
            Cell cell = this.Controller.CellPressed(5);
            Button5.Title = IntToCrossCyrcle(cell.PressedBy);
            Button5.Enabled = false;
            PrintMessage(cell);
            if (cell.Winner == 0)
            {
                CallBot();
            }
        }

        partial void Button6Click(Foundation.NSObject sender)
        {
            Cell cell = this.Controller.CellPressed(6);
            Button6.Title = IntToCrossCyrcle(cell.PressedBy);
            Button6.Enabled = false;
            PrintMessage(cell);
            if (cell.Winner == 0)
            {
                CallBot();
            }
        }

        partial void Button7Click(Foundation.NSObject sender)
        {
            Cell cell = this.Controller.CellPressed(7);
            Button7.Title = IntToCrossCyrcle(cell.PressedBy);
            Button7.Enabled = false;
            PrintMessage(cell);
            if (cell.Winner == 0)
            {
                CallBot();
            }
        }

        partial void Button8Click(Foundation.NSObject sender)
        {
            Cell cell = this.Controller.CellPressed(8);
            Button8.Title = IntToCrossCyrcle(cell.PressedBy);
            Button8.Enabled = false;
            PrintMessage(cell);
            if (cell.Winner == 0)
            {
                CallBot();
            }
        }

        partial void Button9Click(Foundation.NSObject sender)
        {
            Cell cell = this.Controller.CellPressed(9);
            Button9.Title = IntToCrossCyrcle(cell.PressedBy);
            Button9.Enabled = false;
            PrintMessage(cell);
            if (cell.Winner == 0)
            {
                CallBot();
            }
        }

        partial void ResetButtonClick(Foundation.NSObject sender)
        {
            if (this.Controller.NumberOfPlayers == 1)
            {
                ResetSinglePlayerGame();
            }
            else
            {
                ResetTwoPlayersGame();
            }
        }

        private void ResetSinglePlayerGame()
        {
            ResetGame();
            this.Controller = new Controller(1);
            this.BotPlayer = new BotPlayer(this.Controller.LastPlayer);
            this.BotPlayer.Update(this.Controller.WinningCombinations, this.Controller.NumberOfCellsPressed);
            if (this.BotPlayer.StartingPlayer == 2)
            {
                int pressedCell = this.BotPlayer.PressCell();
                if (pressedCell > 0)
                {
                    RenderBotAction(pressedCell);
                }
            }
        }


        private void ResetTwoPlayersGame()
        {
            ResetGame();
            this.Controller = new Controller(2);
        }

        private void ResetGame()
        {
            ResetButton.Enabled = true;

            Button1.Enabled = true;
            Button2.Enabled = true;
            Button3.Enabled = true;
            Button4.Enabled = true;
            Button5.Enabled = true;
            Button6.Enabled = true;
            Button7.Enabled = true;
            Button8.Enabled = true;
            Button9.Enabled = true;

            Button1.Title = "";
            Button2.Title = "";
            Button3.Title = "";
            Button4.Title = "";
            Button5.Title = "";
            Button6.Title = "";
            Button7.Title = "";
            Button8.Title = "";
            Button9.Title = "";
        }

        private string IntToCrossCyrcle(int player)
        {
            string playerChar = player == 1 ? "X" : "O";
            return playerChar;
        }

        private void PrintMessage(Cell cell)
        {
            if (cell.Winner > 0)
            {
                string winnerStr = cell.Winner.ToString();
                var alert = new NSAlert();
                alert.MessageText = "TicTacToe";
                alert.InformativeText = $"The winner is Player {winnerStr} ({IntToCrossCyrcle(cell.Winner)})!";
                alert.RunModal();
                Button1.Enabled = false;
                Button2.Enabled = false;
                Button3.Enabled = false;
                Button4.Enabled = false;
                Button5.Enabled = false;
                Button6.Enabled = false;
                Button7.Enabled = false;
                Button8.Enabled = false;
                Button9.Enabled = false;
            }

            if (cell.IsMatchEnded && cell.Winner == 0)
            {
                var alert = new NSAlert();
                alert.MessageText = "TicTacToe";
                alert.InformativeText = "Tie!";
                alert.RunModal();
            }
        }

        private void CallBot()
        {
            if (this.Controller.NumberOfPlayers == 1)
            {
                this.BotPlayer.Update(this.Controller.WinningCombinations, this.Controller.NumberOfCellsPressed);
                int pressedCell = this.BotPlayer.PressCell();
                if (pressedCell > 0)
                {
                    RenderBotAction(pressedCell);
                }
            }
        }

        private void RenderBotAction(int pressedCell)
        {
            Cell cell = this.Controller.CellPressed(pressedCell);
            switch (pressedCell)
            {
                case 1:
                    Button1.Title = IntToCrossCyrcle(cell.PressedBy);
                    Button1.Enabled = false;
                    break;
                case 2:
                    Button2.Title = IntToCrossCyrcle(cell.PressedBy);
                    Button2.Enabled = false;
                    break;
                case 3:
                    Button3.Title = IntToCrossCyrcle(cell.PressedBy);
                    Button3.Enabled = false;
                    break;
                case 4:
                    Button4.Title = IntToCrossCyrcle(cell.PressedBy);
                    Button4.Enabled = false;
                    break;
                case 5:
                    Button5.Title = IntToCrossCyrcle(cell.PressedBy);
                    Button5.Enabled = false;
                    break;
                case 6:
                    Button6.Title = IntToCrossCyrcle(cell.PressedBy);
                    Button6.Enabled = false;
                    break;
                case 7:
                    Button7.Title = IntToCrossCyrcle(cell.PressedBy);
                    Button7.Enabled = false;
                    break;
                case 8:
                    Button8.Title = IntToCrossCyrcle(cell.PressedBy);
                    Button8.Enabled = false;
                    break;
                case 9:
                    Button9.Title = IntToCrossCyrcle(cell.PressedBy);
                    Button9.Enabled = false;
                    break;
                default:
                    break;
            }
            PrintMessage(cell);
            //this.Controller.LastPlayer = 2;
        }
    }
}
