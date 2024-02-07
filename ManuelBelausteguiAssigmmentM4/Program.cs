using System;

namespace ManuelBelausteguiAssignmentM4
{
    internal class Program
    {
        enum state : int { U, O, X };
        static void Main(string[] args)
        {
            bool player = true;
            bool gamewon = false;
            bool fullboard = false;
            
            state[,] board = new state[3, 3]
        {
            { state.U, state.U, state.U },
            { state.U, state.U, state.U },
            { state.U, state.U, state.U }
        };
            //Display board 
            PrintBoard(board);
            
            while (!gamewon)
            {
                
                if (player)
                {
                    Console.Write("Player 1: Enter a number ");
                }
                else
                {
                    Console.Write("Player 2: Enter a number ");
                }
                string userinput = Console.ReadLine();
                int intinput;
                bool isNum = int.TryParse(userinput, out intinput);
                if (isNum)
                {

                    int row = ((intinput - 1) / 3);
                    int column = ((intinput - 1) % 3);
                    if (board[row, column]!=state.U)
                    {
                        Console.Write("That space is already taken\nTry a new space ");
                        continue;
                    }
                    if (player)
                    {
                        board[row, column] = state.O;
                        gamewon = WinCheck(board, player);
                        if (gamewon)
                        {
                            Console.WriteLine("Player 1 wins!\n");
                            break;
                        }
                        fullboard = IsBoardFull(board);
                        if (fullboard)
                        {
                            Console.WriteLine("Its a Tie!");
                            break;
                        }
                        player = false;
                    }
                    else
                    {
                        board[row, column] = state.X;
                        gamewon = WinCheck(board, player);
                        if (gamewon)
                        {
                            Console.WriteLine("Player 2 wins!\n");
                            break;
                        }
                        fullboard = IsBoardFull(board);
                        if (fullboard)
                        {
                            Console.WriteLine("Its a Tie!");
                            break;
                        }
                        player = true;
                    }
                    PrintBoard(board);
                    
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
            
        }
        static void PrintBoard(state[,] board)
        {
            int number = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == state.U)
                    {
                        Console.Write(number+" ");
                    }
                    else
                    {
                        Console.Write(board[i, j] + " ");
                    }
                    number++;
                }
                Console.WriteLine();
            }

        }
        static bool WinCheck(state[,] board,bool player)
        {
            state value; 
            if (player)
            {
                value = state.O;
            }
            else
            {
                value=state.X;
            }
            for (int i = 0; i < 3; i++)
            {
                if (board[i,0] == value && board[i,1] == value && board[i, 2] == value)
                {
                    return true;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] == value && board[1, i] == value && board[2, i] == value)
                {
                    return true;
                }
            }
            if (board[0, 0] == value && board[1, 1] == value && board[2, 2] == value)
            {
                return true;
            }
            if (board[2, 0] == value && board[1, 1] == value && board[0, 2] == value)
            {
                return true;
            }
            return false;
        }
        static bool IsBoardFull(state[,] board)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == state.U)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}