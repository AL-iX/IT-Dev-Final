using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Connect4App
{
    class Game //This is a second controller class handling the game logic
    {
        public int Master(int colorChoice1, int colorChoice2, int gameType, int winReq)
        {
            
            string player2Type = "";
            int columnChoice = 0;
            int count = 0;
            int countx = 0;
            int county = 0;
            int playerWon;
            bool inGame = true;
            bool player1Turn = false;
            bool player2Turn = false;
            bool firstUnfound = true;
            bool columnInvalid = false;
            UI ui = new UI();            
            GameMod mod = new GameMod();
            int[,] boardData = new int[7, 6];            
            int playerFirst;
            Random rand = new Random();

            boardData = mod.GenBoard(); // game board data is generated

            if (gameType == 1)
            {
                player2Type = "AI";
            }
            if (gameType == 2)
            {                               
                player2Type = "human";               
            }

            ui.Who(gameType); // user determines first player
            ConsoleKeyInfo firstKey = Console.ReadKey();            
            playerFirst = Convert.ToInt16(firstKey.Key) - 48;

            do //will take players input, or randomize turn order
            {
                if (playerFirst == 1)
                {
                    player1Turn = true;
                    firstUnfound = false;
                }
                if (playerFirst == 2)
                {
                    player2Turn = true;
                    firstUnfound = false;
                }
                if (firstUnfound)
                {
                    playerFirst = rand.Next(2)+1;                     
                }
            } while (firstUnfound);
            

            ui.GameBoard(); //UI Board generated
            ui.DropPiece(1, 7, colorChoice1, false);
            ui.DropPiece(5, 7, colorChoice2, false);

            while (inGame)
            {
                if (player1Turn)
                {
                    ui.PlayerTurn(player1Turn, player2Turn); // draws arrows indicating turn

                    do // this loop validates players choice so game won't crash
                    {
                        Console.SetCursorPosition(0, 0);
                        columnChoice = mod.HumanTurn(); // humanturn() is called to get player's choice
                        if (columnChoice == -1) // is player presses 0, will forfeit as directed
                        {
                            return 2;
                        }
                        if (columnChoice >=0 && columnChoice <7)
                        {
                            if (boardData[columnChoice, 5] != 0)
                            {
                                columnInvalid = true;
                            }
                            else
                            {
                                columnInvalid = false;
                            }
                        }
                        else { columnInvalid = true; }
                        
                    } while (columnInvalid);                    
                    
                    for (count = 0; count < 6; count++) //once valid column is chosen, if the lowest space is occupied, it will more up until open space is found. boardData will update, and piece is dropped on UI
                    {
                        if (boardData[columnChoice, count] == 0)
                        {
                            Console.Beep(420, 100);
                            boardData[columnChoice, count] = 1;
                            ui.DropPiece(columnChoice, 6 - count, colorChoice1, true);               
                            
                            count = count + 10;
                        }
                    } count = 0;

                    playerWon = mod.WinCheck(boardData,winReq,1); //checks for win
                    if (playerWon == 1)
                    {                        
                        ui.Exit(playerWon);
                        Console.Beep(523, 200);
                        Console.Beep(392, 200);
                        Console.Beep(330, 200);
                        Console.Beep(262, 500);

                        for (county = 0; county < 6; county++)
                        {
                            for (countx = 0; countx < 7; countx++)
                            {
                                if (player2Type == "AI")
                                {                                    
                                    ui.DropPiece(countx, 6 - county, rand.Next(7) + 1, true);
                                }
                                else if (boardData[countx,county] == 2)
                                {
                                    Thread.Sleep(100);
                                    ui.DropPiece(countx, 6 - county, 9, false);
                                }
                                
                            }
                        }                        
                        Console.ReadKey();
                        return 1;                       
                        
                    }
                    else // if win is not achieved, checks for stalemate. else turn order switches.
                    {
                        if (mod.StaleCheck(boardData))
                        {                            
                            for (county = 0; county<5; county++)
                            {
                                Thread.Sleep(150);
                                ui.DropPiece(3, 6 - county, 9, false);
                            }
                            for (countx = 0; countx < 7; countx++)
                            {
                                Thread.Sleep(150);
                                ui.DropPiece(countx, 1, 9, false);
                            }
                            ui.Exit(0);
                            Console.ReadKey();
                            inGame = false;
                        }
                        else
                        {
                            player1Turn = false;
                            player2Turn = true;
                        }
                        
                    }
                }
                if (player2Turn)
                {
                    ui.PlayerTurn(player1Turn, player2Turn);

                    if (player2Type == "human") //if p2 is human, same as above
                    {
                        do
                        {
                            Console.SetCursorPosition(0, 0);
                            columnChoice = mod.HumanTurn();
                            if (columnChoice == -1)
                            {
                                return 1;
                            }
                            if (columnChoice >= 0 && columnChoice < 7)
                            {
                                if (boardData[columnChoice, 5] != 0)
                                {
                                    columnInvalid = true;
                                }
                                else
                                {
                                    columnInvalid = false;
                                }
                            }
                            else { columnInvalid = true; }
                           
                        } while (columnInvalid);
                    }
                    if (player2Type == "AI") // if p2 is AI, calls AImod to determine move
                    {
                        AIMod AI = new AIMod();
                        do
                        {
                            columnChoice = AI.AITurn(boardData, winReq);
                            if (boardData[columnChoice, 5] != 0)
                            {
                                columnInvalid = true;
                            }
                            else
                            {
                                columnInvalid = false;
                            }
                        } while (columnInvalid);
                    }

                    for (count = 0; count < 6; count++)
                    {
                        if (boardData[columnChoice, count] == 0)
                        {
                            Console.Beep(380, 100);
                            boardData[columnChoice, count] = 2;
                            ui.DropPiece(columnChoice, 6 - count, colorChoice2, true);
                            count = count + 10;
                        }
                    }
                    count = 0;
                    playerWon = mod.WinCheck(boardData, winReq, 2);
                    if (playerWon == 2)
                    {
                        ui.Exit(playerWon);
                        if (player2Type == "AI")
                        {
                            Console.Beep(392, 400);
                            Console.Beep(330, 400);
                            Console.Beep(262, 1200);
                        }
                        else
                        {
                            Console.Beep(523, 200);
                            Console.Beep(392, 200);
                            Console.Beep(330, 200);
                            Console.Beep(262, 500);
                        }                        

                        for (county = 0; county < 6; county++)
                        {
                            for (countx = 0; countx < 7; countx++)
                            {
                                if (boardData[countx, county] == 1)
                                {
                                    Thread.Sleep(50);
                                    ui.DropPiece(countx, 6 - county, 9, false);
                                }
                            }
                        }
                        
                        Console.ReadKey();
                        return 2;                        
                    }
                    else
                    {
                        if (mod.StaleCheck(boardData))
                        {
                            for (county = 0; county < 5; county++)
                            {
                                Thread.Sleep(150);
                                ui.DropPiece(3, 6 - county, 9, false);
                            }
                            for (countx = 0; countx < 7; countx++)
                            {
                                Thread.Sleep(150);
                                ui.DropPiece(countx, 1, 9, false);
                            }
                            ui.Exit(0);
                            Console.ReadKey();
                            inGame = false;
                        }
                        else
                        {
                            player2Turn = false;
                            player1Turn = true;
                        }
                        
                    }                    
                }                    
            }return 0;
        }          
    }
}
