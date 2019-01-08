using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4App
{
    class AIMod // AI class
    {
        public int AITurn(int[,] boardData, int winReq) // handles AI logic. AI work by assigning weights to possible moves and picks the move with highest weight. parameters are the board state and win condition
        {
            int countx = 0;
            int county = 0;
            int[] moveWeight = { 1, 3, 9, 18, 9, 3, 1 }; // Each column has 1 move associated. playing toward the center is good, so default weights are increased for middle columns            
            int[,] hypBoard = new int[7, 6]; // this array will parallel boardData, and is used to store theoretical board states.
            bool[,] possibleMove = new bool[7, 6]; // this array is also parallel, and will store which moves are possible.
            GameMod gameMod = new GameMod();


            for (countx = 0; countx < 7; countx++) // fills hypBoard with element from boardDate
            {
                for (county = 0; county < 6; county++)
                {
                    hypBoard[countx, county] = boardData[countx, county];
                }
            }
            countx = 0; county = 0;

            for (countx = 0; countx < 7; countx++) // This algorithm looks at boardData and determines which moves are possible based on the lowest unoccupied space in each column.
            {
                for (county = 0; county < 6; county++)
                {
                    if (boardData[countx, county] == 0)
                    {
                        possibleMove[countx, county] = true;
                        county = county + 10;
                    }
                }
            }
            countx = 0; county = 0;

            for (countx = 0; countx < 7; countx++) //AI uses the WinCheck() method to find a win. Takes each possible move and it leads to a win, it immediately takes it.
            {
                for (county = 0; county < 6; county++)
                {
                    if (possibleMove[countx, county])
                    {                        
                        hypBoard[countx, county] = 2;                    
                        
                        if (gameMod.WinCheck(hypBoard, winReq, 2) == 2)
                        {
                            return countx;
                        }
                        else
                        {
                            hypBoard[countx, county] = 0;
                        }
                    }
                }
            }
            countx = 0; county = 0;

            for (countx = 0; countx < 7; countx++) //AI uses the WinCheck() method block a win.
            {
                for (county = 0; county < 6; county++)
                {
                    if (possibleMove[countx, county])
                    {
                        
                        hypBoard[countx, county] = 1;

                        if (gameMod.WinCheck(hypBoard, winReq, 1) == 1)
                        {
                            return countx;
                        }
                        else
                        {
                            hypBoard[countx, county] = 0;
                        }
                    }
                }
            }
            countx = 0; county = 0;

            for (countx = 0; countx < 7; countx++) // makes sure move does not set up opponent win. Move weight tanks to -1000000, so it will only be picked if there is not other choice
            {
                for (county = 0; county < 5; county++)
                {
                    if (possibleMove[countx,county])
                    {
                        hypBoard[countx, county] = 2;
                        hypBoard[countx, county + 1] = 1;
                        if (gameMod.WinCheck(hypBoard, winReq, 1) == 1)
                        {
                            moveWeight[countx] = moveWeight[countx] - 1000000;
                        }
                        hypBoard[countx, county] = 0;
                        hypBoard[countx, county + 1] = 0;
                    }
                }
            }
            countx = 0; county = 0;
            
            for (countx = 0; countx < 5; countx++) // +200 move weight for blocking humans horizontal 
            {
                for (county = 0; county < 6; county++)
                {
                    if (possibleMove[countx, county] && boardData[countx + 1, county] == 1 && boardData[countx + 2,county] == 1)
                    {
                        moveWeight[countx] = moveWeight[countx] + 200;
                    }
                    
                }
            } countx = 0; county = 0;           

            for (countx = 6; countx > 1; countx--) // reciporacal
            {
                for (county = 0; county < 6; county++)
                {
                    if (possibleMove[countx, county] && boardData[countx - 1, county] == 1 && boardData[countx - 2, county] == 1)
                    {
                        moveWeight[countx] = moveWeight[countx] + 200;
                    }

                }
            }
            countx = 0; county = 0;

            for (countx = 0; countx < 5; countx++) // +150 move weight for blocking humans diagonal 
            {
                for (county = 0; county < 4; county++)
                {
                    if (possibleMove[countx, county] && boardData[countx + 1, county + 1] == 1 && boardData[countx + 2, county + 2] == 1)
                    {
                        moveWeight[countx] = moveWeight[countx] + 150;
                    }

                }
            }
            countx = 0; county = 0;

            for (countx = 6; countx > 1; countx--) // reciporacal
            {
                for (county = 5; county > 1; county--)
                {
                    if (possibleMove[countx, county] && boardData[countx - 1, county-1] == 1 && boardData[countx - 2, county-2] == 1)
                    {
                        moveWeight[countx] = moveWeight[countx] + 150;
                    }

                }
            }
            countx = 0; county = 0;

            for (countx = 0; countx < 5; countx++) // +150 move weight for blocking humans diagonal 
            {
                for (county = 2; county < 6; county++)
                {
                    if (possibleMove[countx, county] && boardData[countx + 1, county - 1] == 1 && boardData[countx + 2, county - 2] == 1)
                    {
                        moveWeight[countx] = moveWeight[countx] + 150;
                    }

                }
            }
            countx = 0; county = 0;

            for (countx = 6; countx > 1; countx--) // +150 move weight for blocking humans diagonal 
            {
                for (county = 0; county < 4; county++)
                {
                    if (possibleMove[countx, county] && boardData[countx - 1, county +1] == 1 && boardData[countx - 2, county + 2] == 1)
                    {
                        moveWeight[countx] = moveWeight[countx] + 150;
                    }

                }
            }
            countx = 0; county = 0;

            for (countx = 0; countx < 5; countx++) // develop diag
            {
                for (county = 0; county < 4; county++)
                {
                    if (possibleMove[countx, county] && boardData[countx + 1, county + 1] == 2 && boardData[countx + 2, county + 2] == 2)
                    {
                        moveWeight[countx] = moveWeight[countx] + 100;
                    }

                }
            }
            countx = 0; county = 0;

            for (countx = 6; countx > 1; countx--) // develop diag
            {
                for (county = 5; county > 1; county--)
                {
                    if (possibleMove[countx, county] && boardData[countx - 1, county - 1] == 2 && boardData[countx - 2, county - 2] == 2)
                    {
                        moveWeight[countx] = moveWeight[countx] + 100;
                    }

                }
            }
            countx = 0; county = 0;

            for (countx = 0; countx < 5; countx++) // develop diag 
            {
                for (county = 2; county < 6; county++)
                {
                    if (possibleMove[countx, county] && boardData[countx + 1, county - 1] == 2 && boardData[countx + 2, county - 2] == 2)
                    {
                        moveWeight[countx] = moveWeight[countx] + 100;
                    }

                }
            }
            countx = 0; county = 0;

            for (countx = 6; countx > 1; countx--) // develop diag 
            {
                for (county = 0; county < 4; county++)
                {
                    if (possibleMove[countx, county] && boardData[countx - 1, county + 1] == 2 && boardData[countx - 2, county + 2] == 2)
                    {
                        moveWeight[countx] = moveWeight[countx] + 100;
                    }

                }
            }
            countx = 0; county = 0;



            for (countx = 0; countx < 5; countx++) // +100 to develop it own 3 horizontal
            {
                for (county = 0; county < 6; county++)
                {
                    if (possibleMove[countx, county] && boardData[countx + 1, county] == 2 && boardData[countx + 2, county] == 2)
                    {
                        moveWeight[countx] = moveWeight[countx] + 100;
                        
                        if( countx < 4 )
                        {
                            if (boardData[countx + 3, county] == 0)
                            {
                                moveWeight[countx] = moveWeight[countx] + 100;
                            }
                        }
                    }

                }
            }
            countx = 0; county = 0;

            for (countx = 6; countx > 1; countx--) // recip
            {
                for (county = 0; county < 6; county++)
                {
                    if (possibleMove[countx, county] && boardData[countx - 1, county] == 2 && boardData[countx - 2, county] == 2)
                    {
                        moveWeight[countx] = moveWeight[countx] + 100;

                        if (countx > 2)
                        {
                            if (boardData[countx - 3, county] == 0)
                            {
                                moveWeight[countx] = moveWeight[countx] + 100;
                            }
                        }
                    }

                }
            }
            countx = 0; county = 0;               

            for (countx = 6; countx > 2; countx--) // diagonal down/left develop
            {
                for (county = 5; county < 1; county--)
                {
                    if (possibleMove[countx, county] && boardData[countx - 1, county - 1] == 2 && boardData[countx -2, county - 2] == 0 && boardData[countx - 3, county - 3] == 2)
                    {
                        moveWeight[countx] = moveWeight[countx] + 100;
                    }
                    if (possibleMove[countx, county] && boardData[countx - 1, county - 1] == 0 && boardData[countx - 2, county - 2] == 2 && boardData[countx - 3, county - 3] == 2)
                    {
                        moveWeight[countx] = moveWeight[countx] + 100;
                    }
                    if (possibleMove[countx, county] && boardData[countx - 1, county - 1] == 2 && boardData[countx - 2, county - 2] == 2 && boardData[countx - 3, county - 3] == 0)
                    {
                        moveWeight[countx] = moveWeight[countx] + 100;
                    }

                }
            }
            countx = 0; county = 0;

            for (countx = 0; countx < 4; countx++) // diagonal down/right develop
            {
                for (county = 5; county < 1; county--)
                {
                    if (possibleMove[countx, county] && boardData[countx + 1, county - 1] == 2 && boardData[countx + 2, county - 2] == 0 && boardData[countx + 3, county - 3] == 2)
                    {
                        moveWeight[countx] = moveWeight[countx] + 100;
                    }
                    if (possibleMove[countx, county] && boardData[countx + 1, county - 1] == 0 && boardData[countx + 2, county - 2] == 2 && boardData[countx + 3, county - 3] == 2)
                    {
                        moveWeight[countx] = moveWeight[countx] + 100;
                    }
                    if (possibleMove[countx, county] && boardData[countx + 1, county - 1] == 2 && boardData[countx + 2, county - 2] == 2 && boardData[countx + 3, county - 3] == 0)
                    {
                        moveWeight[countx] = moveWeight[countx] + 100;
                    }

                }
            }
            countx = 0; county = 0;

            for (countx = 0; countx < 7; countx++) // ai will prefer middle rows.
            {
                for (county = 2; county < 4; county++)
                {
                    if (possibleMove[countx, county])
                    {
                        moveWeight[countx] = moveWeight[countx] + 25;
                    }

                }
            }
            countx = 0; county = 0;

            Random rand = new Random();

            for (countx = 0; countx < 7; countx++) // add random element to possible moves. Impossible moves get -1000000000
            {
                for (county = 0; county < 6; county++)
                {
                    if (possibleMove[countx, county])
                    {
                        moveWeight[countx] = moveWeight[countx] + rand.Next(20);
                    }
                    else
                    {
                        moveWeight[countx] = moveWeight[countx] - 1000000000;
                    }
                }
            }
            
            for (countx = 0; countx < 7; countx++) // this selects move with highest weight.
            {
                if (moveWeight[countx] == moveWeight.Max())
                {
                    return countx;
                }
            }
            return 3;
        }
    }
}
