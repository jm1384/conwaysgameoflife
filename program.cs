using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
namespace lifeGame
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Chaotic Board");

            Board game = randomPattern();
            string runLoop = "";
            while(runLoop == "")
            {
                game.PrintBoard();
                game.UpdateBoard();
                runLoop = Console.ReadLine();
                Console.Clear();
            }

        }
        static Board randomPattern()
        {
            int size = 15;
            Board board = new Board(size);
            Random rnd = new Random();
            for(int i = 0; i< size; i++)
            {
                for(int j = 0; j<size; j++)
                {
                    if(!(rnd.Next(2) < 1))
                    {
                        board.InvertCell(i,j);
                    }   
                }
            }
            return board;
        }
    }
}
