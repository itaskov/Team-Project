using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telerik.PoppingBaloons
{
    public class BaloonsGame
    {
        public const int GAME_FIELD_ROWS_COUNT = 6;

        public const int GAME_FIELD_COLS_COUNT = 10;

        public const int GAME_FIELD_MIN_NUMBER = 1;

        public const int GAME_FIELD_MAX_NUMBER = 4;

        private int[,] gameField;

        private int popCount;
       
        public BaloonsGame()
        {
            this.CreateGameField();
            this.PrintGameToConsole();
        }

        
        private void CreateGameField()
        {
            this.gameField = new int[GAME_FIELD_ROWS_COUNT, GAME_FIELD_COLS_COUNT];
            Random random = new Random();

            for (int row = 0; row < GAME_FIELD_ROWS_COUNT; row++)
            {
                for (int col = 0; col < GAME_FIELD_COLS_COUNT; col++)
                {
                    gameField[row, col] = random.Next(GAME_FIELD_MIN_NUMBER, GAME_FIELD_MAX_NUMBER + 1);
                }
            }
        }

        public int[,] GameField
        {
            get { return this.gameField; }
        }

        public int PopCount
        {
            get { return this.popCount; }
        }
      
        private char GetGameFieldPointValue(int gameFieldPoint)
        {
            switch (gameFieldPoint)
            {
                case 1:
                    return '1';

                case 2:
                    return '2';

                case 3:
                    return '3';

                case 4:
                    return '4';

                default:
                    return '-';
            }
        }

        public bool PopBaloon(int row, int col)
        {
            //changes the game state and returns boolean,indicating wheater the game is over
            if (gameField[row - 1, col - 1] == 0)
            {
                Console.WriteLine("Invalid Move! Can not pop a baloon at that place!!");
                return false;
            }
            else
            {
                popCount++;
                int state = gameField[row - 1, col - 1];
                int top = row - 1;
                int bottom = row - 1;
                int left = col - 1;
                int right = col - 1;
                while (top > 0 && (gameField[top - 1, col - 1] == state))
                {
                    top--;
                }

                while (bottom < 5 && gameField[bottom + 1, col - 1] == state)
                {
                    bottom++;
                }
                while (left > 0 && gameField[row - 1, left - 1] == state)
                {
                    left--;
                }
                while (right < 9 && gameField[row - 1, right + 1] == state)
                {
                    right++;
                }

                for (int i = left; i <= right; i++)
                {

                    //first remove the elements on the same row and float the elemnts above down
                    if (row == 1)
                        gameField[row - 1, i] = 0;

                    else
                    {
                        for (int j = row - 1; j > 0; j--)
                        {
                            gameField[j, i] = gameField[j - 1, i];
                            gameField[j - 1, i] = 0;
                        }
                    }
                }

                //if that's enough,just stop
                if (top == bottom)
                {
                    Console.WriteLine();
                    this.PrintGameToConsole();
                    Console.WriteLine();
                    return kraj();
                }
                else
                {   //otherwise fix the problematic column as well
                    for (int i = top; i > 0; --i)
                    {//first float the elements above down and replace them
                        gameField[i + bottom - top, col - 1] = gameField[i, col - 1];
                        gameField[i, col - 1] = 0;
                    }
                    if (bottom - top > top - 1)
                    {   //is there are more baloons to pop in the column than elements above them, need to pop them as well
                        for (int i = top; i <= bottom; i++)
                        {
                            if (gameField[i, col - 1] == state)
                                gameField[i, col - 1] = 0;
                        }
                    }
                }
                Console.WriteLine();
                this.PrintGameToConsole();
                Console.WriteLine();
                return kraj();
            }
        }


        bool kraj()
        {
            foreach (var s in gameField)
            {
                if (s != 0)
                    return false;
            }
            return true;
        }
        public void PrintGameToConsole()
        {
            Console.WriteLine("    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("    --------------------");
            
            for (int row = 0; row < GAME_FIELD_ROWS_COUNT; row++)
            {
                Console.Write(row.ToString() + " | ");
                for (int col = 0; col < GAME_FIELD_COLS_COUNT; col++)
                {
                    Console.Write(GetGameFieldPointValue(gameField[row, col]) + " ");
                }
                Console.WriteLine("| ");
            }

            Console.WriteLine("    --------------------");
            Console.WriteLine("Insert row and column or other command");
        }
    }


}

