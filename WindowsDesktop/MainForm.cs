using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer.Entities;

namespace TicTacToe
{
    public partial class MainForm : Form
    {

        public Controller Controller { get; set; }
        public BotPlayer BotPlayer { get; set; }

        public MainForm()
        {
            InitializeComponent();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Cell cell = this.Controller.CellPressed(1);
            button1.Text = IntToCrossCyrcle(cell.PressedBy);
            button1.Enabled = false;
            PrintMessage(cell);
            if (cell.Winner == 0)
            {
                CallBot();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cell cell = this.Controller.CellPressed(2);
            button2.Text = IntToCrossCyrcle(cell.PressedBy);
            button2.Enabled = false;
            PrintMessage(cell);
            if (cell.Winner == 0)
            {
                CallBot();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cell cell = this.Controller.CellPressed(3);
            button3.Text = IntToCrossCyrcle(cell.PressedBy);
            button3.Enabled = false;
            PrintMessage(cell);
            if (cell.Winner == 0)
            {
                CallBot();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Cell cell = this.Controller.CellPressed(6);
            button6.Text = IntToCrossCyrcle(cell.PressedBy);
            button6.Enabled = false;
            PrintMessage(cell);
            if (cell.Winner == 0)
            {
                CallBot();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Cell cell = this.Controller.CellPressed(5);
            button5.Text = IntToCrossCyrcle(cell.PressedBy);
            button5.Enabled = false;
            PrintMessage(cell);
            if (cell.Winner == 0)
            {
                CallBot();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cell cell = this.Controller.CellPressed(4);
            button4.Text = IntToCrossCyrcle(cell.PressedBy);
            button4.Enabled = false;
            PrintMessage(cell);
            if (cell.Winner == 0)
            {
                CallBot();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Cell cell = this.Controller.CellPressed(9);
            button9.Text = IntToCrossCyrcle(cell.PressedBy);
            button9.Enabled = false;
            PrintMessage(cell);
            if (cell.Winner == 0)
            {
                CallBot();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Cell cell = this.Controller.CellPressed(8);
            button8.Text = IntToCrossCyrcle(cell.PressedBy);
            button8.Enabled = false;
            PrintMessage(cell);
            if (cell.Winner == 0)
            {
                CallBot();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Cell cell = this.Controller.CellPressed(7);
            button7.Text = IntToCrossCyrcle(cell.PressedBy);
            button7.Enabled = false;
            PrintMessage(cell);
            if (cell.Winner == 0)
            {
                CallBot();
            }
        }

        private void PrintMessage(Cell cell)
        {
            if (cell.Winner > 0)
            {
                string winnerStr = cell.Winner.ToString();
                MessageBox.Show($"The winner is Player {winnerStr} ({IntToCrossCyrcle(cell.Winner)})!");
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
            }

            if (cell.IsMatchEnded && cell.Winner == 0)
            {
                MessageBox.Show("Tie!");
            }
        }

        private string IntToCrossCyrcle(int player)
        {
            if (player == 1)
            {
                return "X";
            } else
            {
                return "O";
            }
        }

        private void ResetGame()
        {
            restartBtn.Enabled = true;

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;

            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";
        }

        private void RenderBotAction(int pressedCell)
        {
            Cell cell = this.Controller.CellPressed(pressedCell);
            switch (pressedCell)
            {
                case 1:
                    button1.Text = IntToCrossCyrcle(cell.PressedBy);
                    button1.Enabled = false;
                    break;
                case 2:
                    button2.Text = IntToCrossCyrcle(cell.PressedBy);
                    button2.Enabled = false;
                    break;
                case 3:
                    button3.Text = IntToCrossCyrcle(cell.PressedBy);
                    button3.Enabled = false;
                    break;
                case 4:
                    button4.Text = IntToCrossCyrcle(cell.PressedBy);
                    button4.Enabled = false;
                    break;
                case 5:
                    button5.Text = IntToCrossCyrcle(cell.PressedBy);
                    button5.Enabled = false;
                    break;
                case 6:
                    button6.Text = IntToCrossCyrcle(cell.PressedBy);
                    button6.Enabled = false;
                    break;
                case 7:
                    button7.Text = IntToCrossCyrcle(cell.PressedBy);
                    button7.Enabled = false;
                    break;
                case 8:
                    button8.Text = IntToCrossCyrcle(cell.PressedBy);
                    button8.Enabled = false;
                    break;
                case 9:
                    button9.Text = IntToCrossCyrcle(cell.PressedBy);
                    button9.Enabled = false;
                    break;
                default:
                    break;
            }
            PrintMessage(cell);
            //this.Controller.LastPlayer = 2;
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

        private void singlePlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetSinglePlayerGame();
        }

        private void twoPlayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetTwoPlayersGame();
        }


        private void restartBtn_Click(object sender, EventArgs e)
        {
            if (this.Controller.NumberOfPlayers == 1)
            {
                ResetSinglePlayerGame();
            } else
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form AboutForm = new AboutForm(this);
            AboutForm.ShowDialog();
        }
    }
}
