using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4App
{
    class MenUI
    {
        public void Banner()
        {
            /*------------------------------------------------------------------------------------------------
             *   ______   ______    ___    __   ___    __   ________    ______  _________            _    _
             *  / ____/  / ____ \  |   \  |  | |   \  |  | |  ______|  / ____/ |___   ___|          | |  | |
             * | |      | |    | | |  \ \ |  | |  \ \ |  | | |____    | |          | |      _____   | |__| |
             * | |      | |    | | |  |\ \|  | |  |\ \|  | |  ____|   | |          | |     |_____|  |____  |
             * | |____  | |____| | |  | \ |  | |  | \ |  | | |______  | |____      | |                   | |
             *  \_____\  \______/  |__|  \___| |__|  \___| |________|  \_____\     |_|                   |_|
             *   
             *------------------------------------------------------------------------------------------------ 
             */

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n+-------------------------------------------------------------------------------------------------+");            
            Console.WriteLine("|    ______   ______    ___    __   ___    __   ________    ______  _________            _    _   |");
            Console.WriteLine("|   / ____/  / ____ \\  |   \\  |  | |   \\  |  | |  ______|  / ____/ |___   ___|          | |  | |  |");
            Console.WriteLine("|  | |      | |    | | |  \\ \\ |  | |  \\ \\ |  | | |____    | |          | |      _____   | |__| |  |");
            Console.WriteLine("|  | |      | |    | | |  |\\ \\|  | |  |\\ \\|  | |  ____|   | |          | |     |_____|  |____  |  |");
            Console.WriteLine("|  | |____  | |____| | |  | \\ |  | |  | \\ |  | | |______  | |____      | |                   | |  |");
            Console.WriteLine("|   \\_____\\  \\______/  |__|  \\___| |__|  \\___| |________|  \\_____\\     |_|                   |_|  |");
            Console.WriteLine("|                                                                                                 |");
            Console.WriteLine("+-------------------------------------------------------------------------------------------------+");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n\t\t\t\t     By Alex Steiner, Dec 2017");
            Console.ForegroundColor = ConsoleColor.White;            
        }

        public void MainMenu(int p1Wins1, int p1Wins2, int aiWins, int p2Wins, int games)
        {
            Console.WriteLine("\n\n\tMain Menu:                                                    Stats:\n");
            Console.WriteLine("\t1: New Game vs AI");
            Console.WriteLine("\t2: New Game vs Human");
            Console.WriteLine("\t3: Settings");
            Console.WriteLine("\t4: Rules");
            Console.WriteLine("\tQ: Quit");
            Console.WriteLine("\n\n\t(To navigate, press the key that corresponds to the menu option you want to select.)");
            Console.SetCursorPosition(43, 16);
            Console.Write("_    _   ___");
            Console.SetCursorPosition(43, 17);
            Console.Write("\\    /  /");
            Console.SetCursorPosition(43, 18);
            Console.Write(" \\  /   `--.");
            Console.SetCursorPosition(43, 19);
            Console.Write("  \\/    ___/");
            Console.SetCursorPosition(70, 16);
            Console.Write("Games Played: "+games);
            Console.SetCursorPosition(70, 17);
            Console.Write("Player 1 Wins (vs AI): " +p1Wins1);
            Console.SetCursorPosition(70, 18);
            Console.Write("Player 1 Wins (vs Human): " +p1Wins2);
            Console.SetCursorPosition(70, 19);
            Console.Write("Player 2 Wins (AI): " +aiWins);
            Console.SetCursorPosition(70, 20);
            Console.Write("Player 2 Wins (Human): " +p2Wins);
            Console.SetCursorPosition(0, 0);

            /* __        __   ______
             * \ \      / /  /  ____|
             *  \ \    / /   | |____
             *   \ \  / /    \____  \
             *    \ \/ /      ____| |
             *     \__/      |______/
             *     
             *    _    _   ___
             *    \    /  /
             *     \  /   `--.
             *      \/    ___/
             */
        }

        public void SettingsMenu()
        {            
            Console.WriteLine("\n\n\tSettings:");
            Console.WriteLine("\n\tChoose the setting you want to change.\n");           
            Console.WriteLine("\t1: Player 1 color");
            Console.WriteLine("\t2: Player 2 color");
            Console.WriteLine("\t3: Win Condition");
            Console.WriteLine("\t4: Reset Stats");
            Console.WriteLine("\tB: Back");
            Console.SetCursorPosition(0, 0);
        }

        public void Rules()
        {            
            Console.WriteLine("\n\n\tRules:\n");
            Console.WriteLine("\tThis is the Traditional 2 player game Connect-4!");
            Console.WriteLine("\tThe game board consists of a 7 x 6 grid.");
            Console.WriteLine("\tEach player will take turns dropping a piece onto the board.");
            Console.WriteLine("\tWhen a column is selected, the player's piece will drop to the lowest row available.");
            Console.WriteLine("\tWhen 6 pieces occupy a column, pieces can no longer be played in that column.");
            Console.WriteLine("\tA player achieves victory after placing 4 pieces in an unbroken line.");
            Console.WriteLine("\tA winning line can be vertical, horizontal, or diagonal.");
            Console.WriteLine("\tOther game modes will allow for victories after 3 in a line, or 5 in a line.");
            Console.WriteLine("\n\t(Press any key to exit)");
            Console.SetCursorPosition(0, 0);

        }

        public void ColorMenu(int player)
        {
            Console.WriteLine("\n\n\tChoose a color for player {0}:\n", player);            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t1: Blue");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t2: Red");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t3: Green");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t4: Yellow");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t5: Magenta");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t6: Cyan");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\t7: Purple");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\t8: Gray");            
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 0);
        }

        public void WinReqMenu()
        {
            Console.WriteLine("\n\n\t Choose a win condition.\n");
            Console.WriteLine("\t3: 3 in a row");
            Console.WriteLine("\t4: 4 in a row");
            Console.WriteLine("\t5: 5 in a row");
            Console.SetCursorPosition(0, 0);
        }
    }
}
