using System;
using System.Linq;

namespace sudoku
{
    class Program
    {
        static void Main(string[] args)
        {

            int[,] board = new int[9, 9] { { 5,3,4,6,7,8,9,1,2 },
                                            {6,7,2,1,9,5,3,4,8 },
                                            {1,9,8,3,4,2,5,6,7 },
                                            {8,5,9,7,6,1,4,2,3 },
                                            {4,2,6,8,5,3,7,9,1 },
                                            {7,1,3,9,2,4,8,5,6 },
                                            {9,6,1,5,3,7,2,8,4 },
                                            {2,8,7,4,1,9,6,3,5 },
                                            {3,4,5,2,8,6,1,7,9 } };


            // check for duplicate values in a row by passing it the board and a single row
            bool rowCheck(int[,] play, int row)
            {
                String keepTrack = "";

                for (int j = 0; j < 9; j++)
                   keepTrack += play[row, j];
                               
                return (keepTrack.Length - keepTrack.ToCharArray().Distinct().Count() >= 1);
            }


            // checking board row by row
            // if one row has duplicate values, then the board is invalid
            bool checkBoardByRow(int[,] play)
            {
                bool validBoard = true;
               
                for (int row = 0; row < 9; row++)
                {                    
                    if (rowCheck(play, row))                   
                        validBoard = false;
                }
                return validBoard;
            }


            // check for duplicate values in a column by passing it the board and a single column
            bool colCheck(int[,] play, int col)
            {
                String keepTrack = "";

                for (int i = 0; i < 9; i++)
                   keepTrack += play[i, col];

                return (keepTrack.Length - keepTrack.ToCharArray().Distinct().Count() >= 1);
            }


            // checking board row by row
            // if one row has duplicate values, then the board is invalid
            bool checkBoardByCol(int[,] play)
            {
                bool validBoard = true;
                
                for (int col = 0; col < 9; col++)
                {
                    if (colCheck(play, col))                 
                         validBoard = false;                                                 
                }
                return validBoard;
            }


            bool squareCheck(int[,] play, int row, int col)
            {
                String keepTrack = "";

                for (int i = row; i < (row + 3); i++)
                {
                    for (int j = col; j < (col + 3); j++)                    
                        keepTrack += play[i, j];
                }
                return (keepTrack.Length - keepTrack.ToCharArray().Distinct().Count() >= 1);
            }


            bool checkBoardBySquare(int[,] play)
            {
                bool validBoard = true;
                
                for (int i = 0; i < 9; i += 3)
                {                   
                    //check to see if square is valid or not
                    for (int j = 0; j < 9; j += 3)
                    {                        
                        // if a duplicate number on the 3x3 square exists, then board is false
                       if (squareCheck(play, i, j))
                            validBoard = false;
                    }
                }
                return validBoard;
            }


            if (!checkBoardByCol(board) || (!checkBoardByRow(board)) || (!checkBoardBySquare(board)))            
                Console.WriteLine("Board is invalid");            

            else            
                Console.WriteLine("Board is valid");            
        }
    }
}
