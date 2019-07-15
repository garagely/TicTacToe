//===========================================
//Programmer: Michael Sandell
//Date: 11 Jul 2019
//Version: 1.0
//Description: A standard tic tac toe game with computer opponent
//==================================================================
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class GameBoard : Form
    {
        private Button[,] buttonArray;
        GameLogic logic = new GameLogic();
        public GameBoard()
        {
            InitializeComponent();
            buttonArray = new Button[,] { { btn0,btn1,btn2 }, { btn3, btn4, btn5 }, { btn6, btn7, btn8 } };

        }

        private void markBoard(object sender, EventArgs e)
        {
            Button btn = (Button) sender;
            int row = 0;
            int col = 0;

            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    if (btn.Equals(buttonArray[r, c]))
                    {
                        row = r;
                        col = c;
                        break; // break out of the loop when find the index of the clicked button
                    }

                }
            }

            if (btn.Text != "X" && btn.Text != "O")
            {
                btn.Text = "X";
                logic.markSpace("X", row, col);
                int space = logic.cpuMove();

                switch (space)
                {
                    case 1:
                        btn0.Text = "O";
                        break;
                    case 2:
                        btn1.Text = "O";
                        break;
                    case 3:
                        btn2.Text = "O";
                        break;
                    case 4:
                        btn3.Text = "O";
                        break;
                    case 5:
                        btn4.Text = "O";
                        break;
                    case 6:
                        btn5.Text = "O";
                        break;
                    case 7:
                        btn6.Text = "O";
                        break;
                    case 8:
                        btn7.Text = "O";
                        break;
                    case 9:
                        btn8.Text = "O";
                        break;
                }

                if (logic.isGameOverCheck())
                {
                    foreach (Button button in buttonArray)
                    {
                        button.Enabled = false;
                    }
                }
            }
            
        }
    }
}
