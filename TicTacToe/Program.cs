using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "TicTacToe";
            introduction();
            string [,] grid = new string[3,3] {{"■","■","■"},{"■","■","■"},{"■","■","■"}};
            int [] input = new int[2] {0,0};
            bool turnOfPlayerX = true;
            Console.Write("Enter your name Player 1: ");
            string player1Name = Console.ReadLine();
            Console.WriteLine();
            string player1Char;
            int plays = 0;
            
                while(true){
                    Console.Write("{0} choose the character you want to play with: ", player1Name);
                    player1Char = Console.ReadLine();
                    if(player1Char.Length > 1){
                        Console.WriteLine("Please choose one character only");
                    }else{
                        break;
                    }
                }
                Console.WriteLine();

                Console.Write("Enter your name Player 2: ");
                string player2Name = Console.ReadLine();
                Console.WriteLine();
                string player2Char;
                while(true){
                    Console.Write("{0} choose the character you want to play with: ", player2Name);
                    player2Char = Console.ReadLine();
                    if(player2Char.Length > 1){
                        Console.WriteLine("Please choose one character only \n");
                    }else{
                        break;
                    }
                }
                Console.WriteLine();

            Console.WriteLine("{0} its your turn \n", player1Name);

            while(true){
                draw(grid);
                input = processInput();
                if(input == null){
                    Console.WriteLine("Please enter a valid space \n");
                }else{
                    if(turnOfPlayerX == true){
                        if(grid[input[1] - 1, input[0] - 1] == player2Char){
                            Console.WriteLine("Invalid move please try a new one \n");
                        }else{
                            grid[input[1] - 1, input[0] - 1] = player1Char;
                            turnOfPlayerX = false;
                            plays += 1;
                        }
                    }else if(turnOfPlayerX == false){
                        if(grid[input[1] - 1, input[0] - 1] == player1Char){
                            Console.WriteLine("Invalid move please try a new one \n");
                        }else{
                            grid[input[1] - 1, input[0] - 1] = player2Char;
                            turnOfPlayerX = true;
                            plays += 1;
                        }
                    }

                    if(checkWin(grid, turnOfPlayerX, player1Char, player2Char) && checkDraw(plays) == false){
                        if(turnOfPlayerX == true){
                            Console.WriteLine("{0} won the game \n", player2Name );
                        }else{
                            Console.WriteLine("{0} won the game \n", player1Name);
                        }
                        grid = new string [3,3] {{"■","■","■"},{"■","■","■"},{"■","■","■"}};
                    }
                    if(checkDraw(plays) == true && checkWin(grid, turnOfPlayerX, player1Char, player2Char) == false){
                        plays = 0;
                        Console.WriteLine("Its a draw");
                        grid = new string [3,3] {{"■","■","■"},{"■","■","■"},{"■","■","■"}};
                    }

                    if(turnOfPlayerX == true && checkWin(grid, turnOfPlayerX, player1Char, player2Char) == false && checkDraw(plays) == false){
                        Console.WriteLine("{0} its your turn \n", player1Name);
                    }else if(turnOfPlayerX == false && checkWin(grid, turnOfPlayerX, player1Char, player2Char) == false && checkDraw(plays) == false){
                        Console.WriteLine("{0} its your turn \n", player2Name);
                    }
                }
            }
        }


        static void draw(string [,] grid){
            for (int i = 0; i < grid.GetLength(0); i++){
                Console.WriteLine();
                for(int u = 0; u < grid.GetLength(1); u++){
                    Console.Write(grid[i,u] + " ");
                }
            }
            Console.WriteLine();
        }

        static int[] processInput(){
            int [] processedInput = new int[2];
            string rawInput = Console.ReadLine();
            Console.WriteLine();
            string temp_;

            if(rawInput.Length == 3){
                temp_ = rawInput.Remove(1);
                if(!(temp_.Contains("1") ||
                temp_.Contains("2") ||
                temp_.Contains("3") ||
                temp_.Contains("4") ||
                temp_.Contains("5") ||
                temp_.Contains("6") ||
                temp_.Contains("7") ||
                temp_.Contains("8") ||
                temp_.Contains("9") ||
                temp_.Contains("0"))){
                    return null;
                }
                rawInput = rawInput.Substring(2);
                if(!(rawInput.Contains("1") ||
                rawInput.Contains("2") ||
                rawInput.Contains("3") ||
                rawInput.Contains("4") ||
                rawInput.Contains("5") ||
                rawInput.Contains("6") ||
                rawInput.Contains("7") ||
                rawInput.Contains("8") ||
                rawInput.Contains("9") ||
                rawInput.Contains("0"))){
                    return null;
                }
                processedInput = new int [] {Convert.ToInt32(temp_),Convert.ToInt32(rawInput)};
                return processedInput;
            }else{
                return null;
            }
        }

        static bool checkWin(string [,] grid, bool turnOfPlayerX, string player1Char, string player2Char){
            if(grid[0,0] == player1Char && grid[0,1] == player1Char && grid[0,2] == player1Char || 
            grid[1,0] == player1Char && grid[1,1] == player1Char && grid[1,2] == player1Char ||
            grid[2,0] == player1Char && grid[2,1] == player1Char && grid[2,2] == player1Char ||
            grid[0,0] == player1Char && grid[1,1] == player1Char && grid[2,2] == player1Char ||
            grid[2,0] == player1Char && grid[1,1] == player1Char && grid[0,2] == player1Char ||
            grid[0,0] == player1Char && grid[1,0] == player1Char && grid[2,0] == player1Char ||
            grid[0,1] == player1Char && grid[1,1] == player1Char && grid[2,1] == player1Char ||
            grid[0,2] == player1Char && grid[1,2] == player1Char && grid[2,2] == player1Char){
                return true;
            }else if(grid[0,0] == player2Char && grid[0,1] == player2Char && grid[0,2] == player2Char || 
            grid[1,0] == player2Char && grid[1,1] == player2Char && grid[1,2] == player2Char ||
            grid[2,0] == player2Char && grid[2,1] == player2Char && grid[2,2] == player2Char ||
            grid[0,0] == player2Char && grid[1,1] == player2Char && grid[2,2] == player2Char ||
            grid[2,0] == player2Char && grid[1,1] == player2Char && grid[0,2] == player2Char ||
            grid[0,0] == player2Char && grid[1,0] == player2Char && grid[2,0] == player2Char ||
            grid[0,1] == player2Char && grid[1,1] == player2Char && grid[2,1] == player2Char ||
            grid[0,2] == player2Char && grid[1,2] == player2Char && grid[2,2] == player2Char){
                return true;
            }else{
                return false;
            }
        }
        static void introduction(){
            Console.WriteLine("Welcome to TicTacToe!");
            Console.WriteLine("This is a game made by Rui Pedro with C#. (Press Enter to continue) \n");
            Console.ReadKey();
            Console.WriteLine("Its a 2 player offline game.");
            Console.WriteLine("To play the game you just need to input the coordinates (x,y) of the square you want to play on.");
            Console.WriteLine("Keep in mind that the origin of the grid is on the top left corner");
            Console.WriteLine("For example this is the board: \n");
            Console.WriteLine("■ ■ ■");
            Console.WriteLine("■ ■ ■");
            Console.WriteLine("■ ■ ■  \n");
            Console.WriteLine("If you want to play on the middle just write: 2,2");
            Console.WriteLine("If you want to play on the top middle just write: 1,2");
            Console.WriteLine("Got it? Press Enter to continue \n");
        }
        static bool checkDraw(int plays){
            if(plays >= 9){
                return true;
            }else{
                return false;
            }
        }
    }
}