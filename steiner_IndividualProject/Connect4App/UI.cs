using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Connect4App
{
    class UI
    {   //  ___________
        // |   _____   |    
        // |  /@@@@@\  |
        // | /@@@@@@@\ |
        // | |@@@@@@@| |
        // | \@@@@@@@/ |
        // |  \@@@@@/  |
        // |___________|
        public void GameBoard()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("        ___________ ___________ ___________ ___________ ___________ ___________ ___________ ");
            Console.WriteLine("       |1          |2          |3          |4          |5          |6          |7          | ");
            Console.WriteLine("       |           |           |           |           |           |           |           | ");
            Console.WriteLine("       |           |           |           |           |           |           |           | ");
            Console.WriteLine("       |           |           |           |           |           |           |           | ");
            Console.WriteLine("       |           |           |           |           |           |           |           | ");
            Console.WriteLine("       |           |           |           |           |           |           |           | ");
            Console.WriteLine("       |___________|___________|___________|___________|___________|___________|___________| ");
            Console.WriteLine("       |           |           |           |           |           |           |           | ");
            Console.WriteLine("       |           |           |           |           |           |           |           | ");
            Console.WriteLine("       |           |           |           |           |           |           |           | ");
            Console.WriteLine("       |           |           |           |           |           |           |           | ");
            Console.WriteLine("       |           |           |           |           |           |           |           | ");
            Console.WriteLine("       |           |           |           |           |           |           |           | ");
            Console.WriteLine("       |___________|___________|___________|___________|___________|___________|___________| ");
            Console.WriteLine("       |           |           |           |           |           |           |           | ");
            Console.WriteLine("       |           |           |           |           |           |           |           | ");
            Console.WriteLine("       |           |           |           |           |           |           |           | ");
            Console.WriteLine("       |           |           |           |           |           |           |           | ");
            Console.WriteLine("       |           |           |           |           |           |           |           | ");
            Console.WriteLine("       |           |           |           |           |           |           |           | ");
            Console.WriteLine("       |___________|___________|___________|___________|___________|___________|___________| ");
            Console.WriteLine("       |           |           |           |           |           |           |           | ");
            Console.WriteLine("       |           |           |           |           |           |           |           | ");
            Console.WriteLine("       |           |           |           |           |           |           |           | ");
            Console.WriteLine("       |           |           |           |           |           |           |           | ");
            Console.WriteLine("       |           |           |           |           |           |           |           | ");
            Console.WriteLine("       |           |           |           |           |           |           |           | ");
            Console.WriteLine("       |___________|___________|___________|___________|___________|___________|___________| ");
            Console.WriteLine("       |           |           |           |           |           |           |           | ");
            Console.WriteLine("       |           |           |           |           |           |           |           | ");
            Console.WriteLine("       |           |           |           |           |           |           |           | ");
            Console.WriteLine("       |           |           |           |           |           |           |           | ");
            Console.WriteLine("       |           |           |           |           |           |           |           | ");
            Console.WriteLine("       |           |           |           |           |           |           |           | ");
            Console.WriteLine("       |___________|___________|___________|___________|___________|___________|___________| ");
            Console.WriteLine("       |           |           |           |           |           |           |           | ");
            Console.WriteLine("       |           |           |           |           |           |           |           | ");
            Console.WriteLine("       |           |           |           |           |           |           |           | ");
            Console.WriteLine("       |           |           |           |           |           |           |           | ");
            Console.WriteLine("       |           |           |           |           |           |           |           | ");
            Console.WriteLine("       |           |           |           |           |           |           |           | ");
            Console.WriteLine("       |___________|___________|___________|___________|___________|___________|___________| ");
            Console.WriteLine("\n                                    Press the key corresponding");
            Console.WriteLine("                                     to the column you want to");
            Console.WriteLine("                                        drop your piece in.");
            Console.WriteLine("                                    (Press '0' key to forfeit)");
        }

        public void DropPiece(int x, int y, int color, bool drop) // This will drop a piece in a certain grid position. bool determines whether or not to use drop animation
        {
            int county = 0;
            if (color == 1) { Console.ForegroundColor = ConsoleColor.Blue; }
            if (color == 2) { Console.ForegroundColor = ConsoleColor.Red; }
            if (color == 3) { Console.ForegroundColor = ConsoleColor.Green; }
            if (color == 4) { Console.ForegroundColor = ConsoleColor.Yellow; }
            if (color == 5) { Console.ForegroundColor = ConsoleColor.Magenta; }
            if (color == 6) { Console.ForegroundColor = ConsoleColor.Cyan; }
            if (color == 7) { Console.ForegroundColor = ConsoleColor.DarkMagenta; }
            if (color == 8) { Console.ForegroundColor = ConsoleColor.Gray; }
            if (color == 9) { Console.ForegroundColor = ConsoleColor.White; }

            if (drop)
            {
                for (county = 1; county <= y; county++) // loop writes the token to the highest board position, the erases it and rewrites it to the space below, until it reaches its intended position.
                {
                    if (county > 1)
                    {
                        Console.SetCursorPosition(12 * x + 11, (7 * (county - 2)) + 1);
                        Console.Write("       ");
                        Console.SetCursorPosition(12 * x + 9, (7 * (county - 2)) + 2);
                        Console.Write("         ");
                        Console.SetCursorPosition(12 * x + 9, (7 * (county - 2)) + 3);
                        Console.Write("         ");
                        Console.SetCursorPosition(12 * x + 9, (7 * (county - 2)) + 4);
                        Console.Write("         ");
                        Console.SetCursorPosition(12 * x + 9, (7 * (county - 2)) + 5);
                        Console.Write("          ");
                        Console.SetCursorPosition(12 * x + 9, (7 * (county - 2)) + 6);
                        Console.Write("          ");
                        Console.SetCursorPosition(0, 0);
                    }
                    Console.SetCursorPosition(12 * x + 11, (7 * (county - 1)) + 1);
                    Console.Write("_____ ");
                    Console.SetCursorPosition(12 * x + 9, (7 * (county - 1)) + 2);
                    Console.Write(" /@@@@@\\");
                    Console.SetCursorPosition(12 * x + 9, (7 * (county - 1)) + 3);
                    Console.Write("/@@@@@@@\\");
                    Console.SetCursorPosition(12 * x + 9, (7 * (county - 1)) + 4);
                    Console.Write("|@@@@@@@|");
                    Console.SetCursorPosition(12 * x + 9, (7 * (county - 1)) + 5);
                    Console.Write("\\@@@@@@@/");
                    Console.SetCursorPosition(12 * x + 9, (7 * (county - 1)) + 6);
                    Console.Write(" \\@@@@@/");
                    Console.SetCursorPosition(0, 0);
                    Thread.Sleep(50);
                }
                
            }
            else // if animations is unwanted, token is place directly on spot
            {
                Console.SetCursorPosition(12 * x + 11, (7 * (y - 1)) + 1);
                Console.Write("_____ ");
                Console.SetCursorPosition(12 * x + 9, (7 * (y - 1)) + 2);
                Console.Write(" /@@@@@\\");
                Console.SetCursorPosition(12 * x + 9, (7 * (y - 1)) + 3);
                Console.Write("/@@@@@@@\\");
                Console.SetCursorPosition(12 * x + 9, (7 * (y - 1)) + 4);
                Console.Write("|@@@@@@@|");
                Console.SetCursorPosition(12 * x + 9, (7 * (y - 1)) + 5);
                Console.Write("\\@@@@@@@/");
                Console.SetCursorPosition(12 * x + 9, (7 * (y - 1)) + 6);
                Console.Write(" \\@@@@@/");
                Console.SetCursorPosition(0, 0);
            }                                
            
        }
        public void Who(int gameType)
        {
            if (gameType == 2)
            {
                Console.SetCursorPosition(0, 0);
                Console.Clear();
                Console.WriteLine("\n Who's going first?\n");
                Console.WriteLine(" 1: Player 1");
                Console.WriteLine(" 2: Player 2");
                Console.WriteLine(" R: Random");
            }
            if (gameType == 1)
            {
                Console.SetCursorPosition(0, 0);
                Console.Clear();
                Console.WriteLine("\n Who's going first?\n");
                Console.WriteLine(" 1: Player 1 (Human)");
                Console.WriteLine(" 2: Player 2 (AI)");
                Console.WriteLine(" R: Random");
            }
        }
        public void PlayerWin(int player)
        {
            Console.Clear();
            Console.WriteLine(player);
            Console.ReadKey();
        }
        
        public void PlayerTurn(bool player1Turn, bool player2Turn) // writes the arrow indicating player turn
        {
            Console.ForegroundColor = ConsoleColor.White;
            if (player1Turn)
            {                
                Console.SetCursorPosition(10, 44);
                Console.Write("> >");
                Console.SetCursorPosition(10, 45);
                Console.Write("  > >");
                Console.SetCursorPosition(10, 46);
                Console.Write("    > >");
                Console.SetCursorPosition(10, 47);
                Console.Write("  > >");
                Console.SetCursorPosition(10, 48);
                Console.Write("> >");
                Console.SetCursorPosition(82, 44);
                Console.Write("       ");
                Console.SetCursorPosition(82, 45);
                Console.Write("       ");
                Console.SetCursorPosition(82, 46);
                Console.Write("       ");
                Console.SetCursorPosition(82, 47);
                Console.Write("       ");
                Console.SetCursorPosition(82, 48);
                Console.Write("       ");
                Console.SetCursorPosition(0, 0);
            }
            if (player2Turn)
            {
                Console.SetCursorPosition(82, 44);
                Console.Write("    < <");
                Console.SetCursorPosition(82, 45);
                Console.Write("  < <");
                Console.SetCursorPosition(82, 46);
                Console.Write("< <");
                Console.SetCursorPosition(82, 47);
                Console.Write("  < <");
                Console.SetCursorPosition(82, 48);
                Console.Write("    < <");
                Console.SetCursorPosition(10, 44);
                Console.Write("       ");
                Console.SetCursorPosition(10, 45);
                Console.Write("       ");
                Console.SetCursorPosition(10, 46);
                Console.Write("       ");
                Console.SetCursorPosition(10, 47);
                Console.Write("       ");
                Console.SetCursorPosition(10, 48);
                Console.Write("       ");
                Console.SetCursorPosition(0, 0);
            }
        }
        public void Exit(int playerWon)
        {
            Console.SetCursorPosition(36, 44);
            Console.Write("                                ");
            Console.SetCursorPosition(36, 45);
            if (playerWon == 0)
            {
                Console.Write("        It's a tie!             ");
            }
            else
            {
                Console.Write("      Player {0} Wins!          ", playerWon);
            }            
            Console.SetCursorPosition(36, 46);
            Console.Write("                                ");
            Console.SetCursorPosition(36, 47);
            Console.Write("  (Press any key to return)     ");
            Console.SetCursorPosition(36, 48);
            Console.Write("                                ");
        }
    }
}
