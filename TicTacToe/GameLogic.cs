//===========================================
//Programmer: Michael Sandell
//Date: 11 Jul 2019
//Version: 1.0
//Description: A standard tic tac toe game with computer opponent
//This is the business logic for the game. It handles checking the rows and columns for wins and changing spaces on the board
//==================================================================

using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace TicTacToe
{
    class GameLogic
    {
        private static String[,] boardArray = new string[,]
        {
            {"1", "2", "3"},
            {"4", "5", "6"},
            {"7", "8", "9"}
        };

        public bool isPlayerTurn = true;


        /// <summary>
        /// Method is called when a spaces is changed.
        /// Calls the method to check all rows, columns, and diagonals and changes the turn.
        /// </summary>
        /// <param name="strMark"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public void markSpace(string strMark, int row, int col)
        {
            boardArray[row, col] = strMark;
            //isGameOverCheck();
            
            isPlayerTurn = false;
            
        }


        /// <summary>
        /// Loops through the rows, columns, and diagonals. Passes the three spaces to the winCheck method.
        /// </summary>
        public bool isGameOverCheck()
        {
            bool isGameOver = false;
            //check the rows
            for (int r = 0; r < 3; r++)
            {
                if (winCheck(boardArray[r, 0], boardArray[r, 1], boardArray[r, 2]))
                {
                    isGameOver = true;
                }
            }

            //check the columns
            for (int c = 0; c < 3; c++)
            {
                if (winCheck(boardArray[0, c], boardArray[1, c], boardArray[2, c]))
                {
                    isGameOver = true;
                }
            }
            //check diagonals

            if (winCheck(boardArray[0, 0], boardArray[1, 1], boardArray[2, 2]))
            {
                isGameOver = true;
            }

            if (winCheck(boardArray[2, 0], boardArray[1, 1], boardArray[0, 2]))
            {
                isGameOver = true;
            }

            if (isGameOver)
            {
                string winningPlayer = "Player";
                if (!isPlayerTurn)
                {
                    winningPlayer = "CPU";
                }

                MessageBox.Show(winningPlayer + " Wins!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.None);
            }

            return isGameOver;
        }


        /// <summary>
        /// Takes the three spaces from the space check method and sees if they are all the same.
        /// If they are, it's a win and return true.
        /// </summary>
        /// <param name="space1"></param>
        /// <param name="space2"></param>
        /// <param name="space3"></param>
        /// <returns></returns>
        private bool winCheck(string space1, string space2, string space3)
        {
            return space1.Equals(space2) && space2.Equals(space3);
        }


        public int cpuMove()
        {
            int space = cpuCheckRows("O");
            //Check if it can win and move there
            if (space != 0)
            {
                return space;
            }

            space = cpuCheckColumns("O");
            if (space != 0)
            {
                return space;
            }

            space = cpuCheckDiagonals("O");
            if (space != 0)
            {
                return space;
            }





            //block if it finds two x in a row
            space = cpuCheckRows("X");
            if (space != 0)
            {
                return space;
            }

            space = cpuCheckColumns("X");
            if (space != 0)
            {
                return space;
            }

            space = cpuCheckDiagonals("X");
            if (space != 0)
            {
                return space;
            }

            //If it can't win take the center if not empty

            if (!boardArray[1, 1].Equals("X") && !boardArray[1, 1].Equals("O"))
            {
                boardArray[1, 1] = "O";
                space = 5;
            }
            //If center is tke take a corner
            else if (!boardArray[0, 0].Equals("X") && boardArray[0, 0] != "O")
            {
                boardArray[0, 0] = "O";
                space = 1;
            }
            else if (boardArray[0, 2] != "X" && boardArray[0, 2] != "O")
            {
                boardArray[0, 2] = "O";
                space = 3;
            }
            else if (boardArray[2, 0] != "X" && boardArray[2, 0] != "O")
            {
                boardArray[2, 0] = "O";
                space = 7;
            }
            else if (boardArray[2, 2] != "X" && boardArray[2, 2] != "O")
            {
                boardArray[2, 2] = "O";
                space = 9;
            }
            isPlayerTurn = true;

            return space;
        }

        private int cpuCheckRows(string condition)
        {
            int space = 0;
            for (int r = 0; r < 3; r++)
            {
                if (cpuSpaceCheck(condition, boardArray[r, 0], boardArray[r, 1], boardArray[r, 2]))
                {
                    for (int s = 0; s < 3; s++)
                    {
                        if (!boardArray[r, s].Equals("O") && !boardArray[r, s].Equals("X"))
                        {
                            space = int.Parse(boardArray[r, s]);
                            boardArray[r, s] = "O";
                            //isGameOverCheck();
                            
                        }
                    }
                }
            }


            return space;
        }

        private int cpuCheckColumns(string condition)
        {
            int space = 0;
            for (int c = 0; c < 3; c++)
            {
                if (cpuSpaceCheck(condition, boardArray[0, c], boardArray[1, c], boardArray[2, c]))
                {
                    for (int s = 0; s < 3; s++)
                    {
                        if (!boardArray[s, c].Equals("O") && !boardArray[s, c].Equals("X"))
                        {
                            space = int.Parse(boardArray[s, c]);
                            boardArray[s, c] = "O";
                            //isGameOverCheck();
                            
                        }
                    }
                }
            }

            return space;
        }

        private int cpuCheckDiagonals(string condition)
        {
            int space = 0;
            if (cpuSpaceCheck(condition, boardArray[0, 0], boardArray[1, 1], boardArray[2, 2]))
            {
                for (int s = 0; s < 3; s++)
                {
                    if(!boardArray[s,s].Equals("O") && !boardArray[s, s].Equals("X"))
                    {
                        space = int.Parse(boardArray[s, s]);
                        boardArray[s, s] = "O";
                        //isGameOverCheck();
                        
                    }
                }
            }else if (cpuSpaceCheck(condition, boardArray[2, 0], boardArray[1, 1], boardArray[0, 2]))
            {
                int r = 2;
                int c = 0;
                for (int x = 0; x < 3; x++)
                {
                    if (!boardArray[r, c].Equals("O") && !boardArray[r, c].Equals("X"))
                    {
                        space = int.Parse(boardArray[r, c]);
                        boardArray[r, c] = "O";
                        //isGameOverCheck();
                        
                    }

                    r--;
                    c++;
                }
            }

            return space;
        }

        private bool cpuSpaceCheck(string condition, string space1, string space2, string space3)
        {
            int playerSpaces = 0;
            if (space1.Equals(condition))
            {
                playerSpaces++;
            }

            if (space2.Equals(condition))
            {
                playerSpaces++;
            }

            if (space3.Equals(condition))
            {
                playerSpaces++;
            }

            return playerSpaces == 2;
        }


    }
}