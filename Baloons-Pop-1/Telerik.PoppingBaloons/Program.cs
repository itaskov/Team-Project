using System;

namespace Telerik.PoppingBaloons
{
    class GameExecution
    {
        static void Main()
        {
            Console.WriteLine("Welcome to “Balloons Pops” game. Please try to pop the balloons.");
            Console.WriteLine(" Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
            GameUI game = new GameUI();
            while (true)
            {
                game.executeCommand(Console.ReadLine());
            }
        }
    }
}
