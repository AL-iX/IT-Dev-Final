using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4App
{
    class GameMod
    {       
        public int[,] GenBoard() // generates array of 7 by 6. each element begins at 0, will eventually change to 1 if player 1 'owns' that space, or 2 is player 2 'owns' it.
        {
            int[,] boardData = new int[7, 6];
            int countx = 0;
            int county = 0;
            
            for (countx = 0; countx < 7; countx++)
            {
                for (county = 0; county < 6; county++)
                {
                    boardData[countx,county] = 0;
                }
            }
            return boardData;                 
             
        }

        public int WinCheck(int[,] boardData, int winReq, int player) // checks for victory by looking at each space and determining if all space in a line of given length belong to the same player. returns value corresponding to player.
        {
            int countx = 0;
            int county = 0;

            if (winReq == 3)
            {
                for (countx = 0; countx < 5; countx++) // diagonal up/right
                {
                    for (county = 0; county < 4; county++)
                    {
                        if (boardData[countx, county] == player && boardData[countx + 1, county + 1] == player && boardData[countx + 2, county + 2] == player)
                        {
                            return player;
                        }
                    }
                }
                countx = 0; county = 0;

                for (countx = 0; countx < 5; countx++) // diagonal down/right
                {
                    for (county = 5; county > 1; county--)
                    {
                        if (boardData[countx, county] == player && boardData[countx + 1, county - 1] == player && boardData[countx + 2, county - 2] == player)
                        {
                            return player;
                        }
                    }

                }
                countx = 0; county = 0;

                for (countx = 0; countx < 5; countx++) //horizontal
                {
                    for (county = 0; county < 6; county++)
                    {
                        if (boardData[countx, county] == player && boardData[countx + 1, county] == player && boardData[countx + 2, county] == player)
                        {
                            return player;
                        }
                    }
                }
                countx = 0; county = 0;

                for (countx = 0; countx < 7; countx++) //vertical
                {
                    for (county = 0; county < 4; county++)
                    {
                        if (boardData[countx, county] == player && boardData[countx, county + 1] == player && boardData[countx, county + 2] == player)
                        {
                            return player;
                        }
                    }

                }
                countx = 0; county = 0;

                return 0;
            }        

            if (winReq == 4)
            {
                for (countx = 0; countx < 4; countx++) // diagonal up/right
                {
                    for (county = 0; county < 3; county++)
                    {
                        if (boardData[countx, county] == player && boardData[countx + 1, county + 1] == player && boardData[countx + 2, county + 2] == player && boardData[countx + 3, county + 3] == player)
                        {
                            return player;
                        }
                    }
                }
                countx = 0; county = 0;

                for (countx = 0; countx < 4; countx++) // diagonal down/right
                {
                    for (county = 5; county > 2; county--)
                    {
                        if (boardData[countx, county] == player && boardData[countx + 1, county - 1] == player && boardData[countx + 2, county - 2] == player && boardData[countx + 3, county - 3] == player)
                        {
                            return player;
                        }
                    }

                }
                countx = 0; county = 0;

                for (countx = 0; countx < 4; countx++) // horizontal
                {
                    for (county = 0; county < 6; county++)
                    {
                        if (boardData[countx, county] == player && boardData[countx + 1, county] == player && boardData[countx + 2, county] == player && boardData[countx + 3, county] == player)
                        {
                            return player;
                        }
                    }
                }
                countx = 0; county = 0;

                for (countx = 0; countx < 7; countx++) // vertical
                {
                    for (county = 0; county < 3; county++)
                    {
                        if (boardData[countx, county] == player && boardData[countx, county + 1] == player && boardData[countx, county + 2] == player && boardData[countx, county + 3] == player)
                        {
                            return player;
                        }
                    }

                }
                countx = 0; county = 0;

                return 0;
            }
            if (winReq == 5)
            {
                for (countx = 0; countx < 3; countx++) // diagonal up/right
                {
                    for (county = 0; county < 2; county++)
                    {
                        if (boardData[countx, county] == player && boardData[countx + 1, county + 1] == player && boardData[countx + 2, county + 2] == player && boardData[countx + 3, county + 3] == player && boardData[countx + 4, county + 4] == player)
                        {
                            return player;
                        }
                    }
                }
                countx = 0; county = 0;

                for (countx = 0; countx < 3; countx++) // diagonal down right
                {
                    for (county = 5; county > 3; county--)
                    {
                        if (boardData[countx, county] == player && boardData[countx + 1, county - 1] == player && boardData[countx + 2, county - 2] == player && boardData[countx + 3, county - 3] == player && boardData[countx + 4, county - 4] == player)
                        {
                            return player;
                        }
                    }

                }
                countx = 0; county = 0;

                for (countx = 0; countx < 3; countx++) // horizontal
                {
                    for (county = 0; county < 6; county++)
                    {
                        if (boardData[countx, county] == player && boardData[countx + 1, county] == player && boardData[countx + 2, county] == player && boardData[countx + 3, county] == player && boardData[countx + 4, county] == player)
                        {
                            return player;
                        }
                    }
                }
                countx = 0; county = 0;

                for (countx = 0; countx < 7; countx++) // vertical
                {
                    for (county = 0; county < 2; county++)
                    {
                        if (boardData[countx, county] == player && boardData[countx, county + 1] == player && boardData[countx, county + 2] == player && boardData[countx, county + 3] == player && boardData[countx, county + 4] == player)
                        {
                            return player;
                        }
                    }

                }
                countx = 0; county = 0;

                return 0;
            }
            return 0;
        }            

        public bool StaleCheck(int[,] boardData) // checks for stalemate by determining if board has no 0's
        {
            int countx = 0;
            int county = 0;
            for (countx = 0; countx < 7; countx++)
            {
                for (county = 0; county < 6; county++)
                {
                    if (boardData[countx, county] == 0)
                    {
                        return false;
                    }
                }
            }
            countx = 0; county = 0;
            return true;
        }

        public int HumanTurn() // takes player input of which column they want to place piece in
        {
            ConsoleKeyInfo columnKey;
            int columnChoice;
            columnKey = Console.ReadKey();
            columnChoice = Convert.ToInt16(columnKey.Key);
            return columnChoice - 49;
        }

        
    }
}
