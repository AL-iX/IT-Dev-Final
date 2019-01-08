using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Connect4App
{
    class Menu // This is a controller class
    {
        public void MainMenu()
        {   //declarations. All statistics, preferences, menu keyinfros stored here in the main controller. When this controller ends, app quits
            bool stay = true;
            bool inSettings = false;
            ConsoleKeyInfo menuKey;
            ConsoleKeyInfo settingsKey;
            char menuChoice;
            char settingsChoice;
            ConsoleKeyInfo colorKey;
            ConsoleKeyInfo winReqKey;
            char colorChoice;
            int color1 = 1;
            int color2 = 2;
            int winReq = 4;
            int pWin = 0;
            int p1Wins1 = 0;
            int p1Wins2 = 0;
            int p2Wins = 0;
            int aiWins = 0;
            int games = 0;

            MenUI menUI = new MenUI();
            UI ui = new UI();
            

            while (stay)
            {
                Console.Clear();  
                ui.DropPiece(2, 3, color1, true);
                ui.DropPiece(4, 3, color2, true);
                menUI.Banner();
                
                menUI.MainMenu(p1Wins1,p1Wins2,aiWins,p2Wins,games);
                menuKey = Console.ReadKey();
                menuChoice = Convert.ToChar(menuKey.Key);
                

                switch (menuChoice)
                {
                    default:
                        break;

                    case '1': //begins game vs ai. return value will increment the appropriate stat
                        Game NG1 = new Game();
                        pWin = NG1.Master(color1, color2, 1, winReq);
                        if (pWin == 1) { p1Wins1++; }
                        if (pWin == 2) { aiWins++; }
                        games++;
                        break;

                    case '2':
                        Game NG2 = new Game(); //game vs human
                        pWin = NG2.Master(color1, color2, 2, winReq);
                        if (pWin == 1) { p1Wins2++; }
                        if (pWin == 2) { p2Wins++; }
                        games++;
                        break;

                    case '3':
                        inSettings = true;                                               
                        break;

                    case '4':
                        Console.Clear();
                        menUI.Banner();
                        menUI.Rules();
                        Console.ReadKey();
                        break;

                    case 'q':
                        stay = false;
                        inSettings = false;
                        break;

                    case 'Q':
                        stay = false;
                        inSettings = false;
                        break;
                }

                while (inSettings)
                {
                    Console.Clear();
                    menUI.Banner();
                    menUI.SettingsMenu();
                    settingsKey = Console.ReadKey();
                    settingsChoice = Convert.ToChar(settingsKey.Key);

                    switch (settingsChoice)
                    {
                        default:                            
                            break;

                        case '1':
                            Console.Clear();
                            menUI.Banner();
                            menUI.ColorMenu(1);
                            colorKey = Console.ReadKey();
                            colorChoice = Convert.ToChar(colorKey.Key);
                            switch (colorChoice)
                            {
                                default:
                                    break;

                                case '1':
                                    color1 = 1;
                                    break;

                                case '2':
                                    color1 = 2;
                                    break;

                                case '3':
                                    color1 = 3;
                                    break;

                                case '4':
                                    color1 = 4;
                                    break;

                                case '5':
                                    color1 = 5;
                                    break;

                                case '6':
                                    color1 = 6;
                                    break;

                                case '7':
                                    color1 = 7;
                                    break;

                                case '8':
                                    color1 = 8;
                                    break;                                
                            }
                            break;

                        case '2':
                            Console.Clear();
                            menUI.Banner();
                            menUI.ColorMenu(2);
                            colorKey = Console.ReadKey();
                            colorChoice = Convert.ToChar(colorKey.Key);
                            switch (colorChoice)
                            {
                                default:
                                    break;

                                case '1':
                                    color2 = 1;
                                    break;

                                case '2':
                                    color2 = 2;
                                    break;

                                case '3':
                                    color2 = 3;
                                    break;

                                case '4':
                                    color2 = 4;
                                    break;

                                case '5':
                                    color2 = 5;
                                    break;

                                case '6':
                                    color2 = 6;
                                    break;

                                case '7':
                                    color2 = 7;
                                    break;

                                case '8':
                                    color2 = 8;
                                    break;

                                case '9':
                                    color2 = 9;
                                    break;
                            }
                            break;

                        case '3':
                            Console.Clear();
                            menUI.Banner();
                            menUI.WinReqMenu();
                            winReqKey = Console.ReadKey();
                            if (winReqKey.Key == ConsoleKey.D3|| winReqKey.Key == ConsoleKey.D4|| winReqKey.Key == ConsoleKey.D5)
                            {
                                winReq = Convert.ToInt16(winReqKey.Key) - 48;
                            }                            
                            break;

                        case '4':
                            Console.Beep(420, 200);
                            games = 0;
                            p1Wins1 = 0;
                            p1Wins2 = 0;
                            aiWins = 0;
                            p2Wins = 0;
                            break;

                        case 'b':
                            inSettings = false;
                            break;

                        case 'B':
                            inSettings = false;
                            break;

                    }

                }
                                         
            }            
        }
    }
}
