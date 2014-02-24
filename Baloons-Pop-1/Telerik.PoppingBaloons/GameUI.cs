using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telerik.PoppingBaloons
{
    public class GameUI
    {
        private BaloonsGame baloonsGame;
        
        private List<Tuple<string, int>> scoreBoard;

        public GameUI()
        {
            Console.WriteLine("Welcome to “Balloons Pops” game. Please try to pop the balloons.");
            Console.WriteLine(" Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");

            baloonsGame = new BaloonsGame();
            scoreBoard = new List<Tuple<string, int>>();
        }

        public Tuple<string, int> this [int index]
        {
            get
            {
                if (index < 0 || index >= this.scoreBoard.Count)
                {
                    throw new ArgumentException("Invalud scoreboard index!");
                }

                return this.scoreBoard[index];
            }
        }

        public List<Tuple<string, int>> ScoreBoard
        {
            get { return scoreBoard; }
        }

        private void DisplayScoreboard()
        {
            if (this.scoreBoard.Count == 0)
            {
                Console.WriteLine("The scoreboard is empty.");
            }
            else
            {
                Console.WriteLine("Top performers:");
                Action<Tuple<string, int>> playesScore;
                playesScore = ps =>
                    {
                        Console.WriteLine("{0} {1} turns", ps.Item1, ps.Item2);
                    };
                scoreBoard.ForEach(playesScore);
            }
        }
        public string ExecuteCommand(string command)
        {
            string result = string.Empty;

            if (command == "exit")
            {
                Console.WriteLine("Thanks for playing!");
                result = "Exit executed.";
                return result;
            }
            else if (command == "restart")
            {
                this.Restart();
                result = "Restart executed.";
                return result;
            }
            else if (command == "top")
            {
                this.DisplayScoreboard();
                result = "Top executed.";
                return result;
            }
            else
            {
                this.ValidateInput(command);
                result = "ValidateInput executed.";
                return result;
            }
        }

        private void ValidateInput(string command)
        {
            if (command.Length == 3)
            {
                int row = int.Parse(command.Substring(0, 1));
                int col  = int.Parse(command.Substring(2, 1));

                SendCommand(row, col);
            }
            else
            {
                Console.WriteLine("Unknown Command");
            }
        }

        private void SendCommand(int row, int col)
        {
            bool isGameEnded = false;

            if (!this.IsValidCoordinates(row, col))
            {
                Console.WriteLine("Invalid row or column!");
            }
            else
            {
                // If this turn ends the game, try to update the scoreboard
                isGameEnded = baloonsGame.PopBaloon(row + 1, col + 1);
            }

            if (isGameEnded)
            {
                Console.WriteLine("Congratulations! You popped all the baloons in" + baloonsGame.PopCount + "moves!");
                this.UpdateScoreboard();
                this.Restart();
            }
        }

        private bool IsValidCoordinates(int row, int col)
        {
            bool isValidRow = 0 <= row && row < BaloonsGame.GAME_FIELD_ROWS_COUNT;
            bool isValidCol = 0 <= row && row < BaloonsGame.GAME_FIELD_COLS_COUNT;
            return isValidRow && isValidCol;
        }

        private void UpdateScoreboard()
        {
            Action<int> add = count =>//function to get the player name and add a tuple to the scoreboard
            {
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();
                Tuple<string, int> player = Tuple.Create<string, int>(name, count);
                this.scoreBoard.Add(player);
            };

            if (scoreBoard.Count < 5)
            {
                add(baloonsGame.PopCount);
                return;
            }
            else
            {
                if (scoreBoard.ElementAt<Tuple<string, int>>(4).Item2 >= baloonsGame.PopCount)
                {
                    add(baloonsGame.PopCount);
                    scoreBoard.RemoveRange(4, 1);//if the new name replaces one of the old ones, remove the old one
                }
            }
            scoreBoard.Sort(delegate(Tuple<string, int> p1, Tuple<string, int> p2)//re-sort the list
                      {
                          return p1.Item2.CompareTo(p2.Item2);
                      });
            baloonsGame = new BaloonsGame();
        }

        private void Restart()
        {
            baloonsGame = new BaloonsGame();
        }

        public void Start()
        {
            while (true)
            {
                if (this.ExecuteCommand(Console.ReadLine()) == "Exit executed.")
                {
                    break;
                }
            }
        }

    }
}

