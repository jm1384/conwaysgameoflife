using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace lifeGame
{
    class Board
    {
        private int size;
        private Cell[,] grid;

        public Board(int dimensions)
        {
            size = dimensions;
            grid = new Cell[size, size];
            for(int i = 0; i<size; i++)
            {
                for(int j = 0; j<size; j++)
                {
                    grid[i,j] = new Cell(false);
                }
            }
        }
        public void InvertCell(int x, int y)
        {
            grid[x,y].ChangeState();
        }   
        public void PrintBoard()
        {
            for(int i = 0; i<size; i++)
            {
                for(int j = 0; j<size; j++)
                {
                    grid[i,j].PrintCell();
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
        
        public void UpdateBoard()
        {
            //get neighbors of each cell
            for(int i = 0; i<size; i++)
            {
                for(int j = 0; j<size; j++)
                {
                    Cell currentCell = grid[i,j];
                    int neighborCount = GetNeighborsCount(i, j);
                    currentCell.SetNeighborCount(neighborCount);
                }
            }
            //evaluate state of each cell
            for(int i = 0; i<size; i++)
            {
                for(int j = 0; j<size; j++)
                {
                    Cell currentCell = grid[i,j];
                    currentCell.EvaluateState();
                    currentCell.SetNeighborCount(0);
                }
            }
        }
        
        private int GetNeighborsCount(int x, int y)
        {
            int[,] locations = {
                {x-1,y-1},
                {x+1,y+1},
                {x-1,y+1},
                {x+1,y-1},
                {x-1,y},
                {x+1,y},
                {x, y+1},
                {x,y-1}
            }; 
            int xcoord;
            int ycoord;
            int neighborCount = 0;
            for(int i = 0; i<=7; i++)
            {
                xcoord = locations[i,0];
                ycoord = locations[i,1];
                if(xcoord >= 0 && ycoord >= 0 && xcoord < size && ycoord < size) //eliminate edges
                {
                    neighborCount += grid[xcoord,ycoord].GetValue();
                }
            }
            return neighborCount;
        }  
    }
}
