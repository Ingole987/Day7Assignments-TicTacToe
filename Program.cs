// See https://aka.ms/new-console-template for more information
using TicTacToe2;



namespace TicTacToe2
{
    class Program
    {
        static void Main(string[] args)
        {
            int gameStatus = 0;
            int currentPlayer = -1;
            char[] gameMarkers = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            do 
            {
                Console.Clear();
                currentPlayer = getNextPlayer(currentPlayer);
                HeadsUpDisplay(currentPlayer);
                DrawGameBoard(gameMarkers);
                gameEngine(gameMarkers, currentPlayer);
                gameStatus = CheckWinner(gameMarkers);

            } while (gameStatus.Equals(0));

            if (gameStatus.Equals(1))
            {
                Console.Clear();
                HeadsUpDisplay(currentPlayer);
                DrawGameBoard(gameMarkers);
                Console.WriteLine($"Player {currentPlayer} is the WINNER");
            }

            if (gameStatus.Equals(2))
            {
                Console.Clear();
                HeadsUpDisplay(currentPlayer);
                DrawGameBoard(gameMarkers);
                Console.WriteLine($"The game is DRAW!");
            }


        }
       
        static void HeadsUpDisplay(int PlayerNumber)
        {
            Console.WriteLine("Welcome to TicTacToe");
            Console.WriteLine("Player 1 : X");
            Console.WriteLine("Player 2 : O");
            Console.WriteLine();
            Console.WriteLine($"Player {PlayerNumber} to move,select from 1 through 9 game board");
            Console.WriteLine();
        }
        static void DrawGameBoard(char[] gameMarkers)
        {
            Console.WriteLine($" {gameMarkers[0]} | {gameMarkers[1]} | {gameMarkers[2]} ");
            Console.WriteLine(" ---+---+--- ");
            Console.WriteLine($" {gameMarkers[3]} | {gameMarkers[4]} | {gameMarkers[5]} ");
            Console.WriteLine(" ---+---+--- "); 
            Console.WriteLine($" {gameMarkers[6]} | {gameMarkers[7]} | {gameMarkers[8]} ");
        }
        static int getNextPlayer(int Player)
        {
            if(Player.Equals(1))
            {
                return 2;
            } 
            else 
            {
                return 1;
            }
        }
        
        private static char getPlayerMarker(int Player)
        {
            if( Player % 2 == 0 )
            {
                return 'O';
            }
            return 'X';
        }
        private static void gameEngine(char[] gameMarkers, int currentPlayer)
        {
            bool notValidMove = true;
            do
            {
                string userInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(userInput) &&
                    (userInput.Equals("1") ||
                    userInput.Equals("2") ||
                    userInput.Equals("3") ||
                    userInput.Equals("4") ||
                    userInput.Equals("5") ||
                    userInput.Equals("6") ||
                    userInput.Equals("7") ||
                    userInput.Equals("8") ||
                    userInput.Equals("9")))
                {
                    Console.Clear();
                    int.TryParse(userInput, out var gamePlacementMarker);
                    char currentMarker = gameMarkers[gamePlacementMarker - 1];
                    if (currentMarker.Equals('X') || currentMarker.Equals('O'))
                    {
                        Console.WriteLine("Placement has already a marker please select another one");
                    }
                    else
                    {
                        gameMarkers[gamePlacementMarker -1] = getPlayerMarker(currentPlayer);
                        notValidMove = false;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Placement please select another one");
                }
            } while (notValidMove);
        }
        private static bool isGameMarkersTheSame(char[] testGameMarkers, int pos1, int pos2, int pos3)
        {
            return testGameMarkers[pos1].Equals(testGameMarkers[pos2]) && testGameMarkers[pos2].Equals(testGameMarkers[pos3]);
        }
        private static int CheckWinner(char[] gameMarkers)
        {
            if(isGameDraw(gameMarkers))
            {
                return 2;
            }
            if(isGameWinner(gameMarkers))
            {
                return 1;
            }
            return 0;
        }

        private static bool isGameWinner(char[] gameMarkers)
        {
            if (isGameMarkersTheSame(gameMarkers, 0, 1, 2))
            {
                return true;
            }

            if (isGameMarkersTheSame(gameMarkers, 3, 4, 5))
            {
                return true;
            }

            if (isGameMarkersTheSame(gameMarkers, 6, 7, 8))
            {
                return true;
            }

            if (isGameMarkersTheSame(gameMarkers, 0, 3, 6))
            {
                return true;
            }

            if (isGameMarkersTheSame(gameMarkers, 1, 4, 7))
            {
                return true;
            }

            if (isGameMarkersTheSame(gameMarkers, 2, 5, 8))
            {
                return true;
            }

            if (isGameMarkersTheSame(gameMarkers, 0, 4, 8))
            {
                return true;
            }

            if (isGameMarkersTheSame(gameMarkers, 2, 4, 6))
            {
                return true;
            }

            return false;
        }
        private static bool isGameDraw(char[] gameMarkers)
        {
            return gameMarkers[0] != '1' &&
                   gameMarkers[1] != '2' &&
                   gameMarkers[2] != '3' &&
                   gameMarkers[3] != '4' &&
                   gameMarkers[4] != '5' &&
                   gameMarkers[5] != '6' &&
                   gameMarkers[6] != '7' &&
                   gameMarkers[7] != '8' &&
                   gameMarkers[8] != '9';
        }

    }
}
 