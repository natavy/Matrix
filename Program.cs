

using System;
using System.Collections.Generic;


class FindPathsInMatrix
{
    static int[,] matrix =
    {
        {1, 1, 1, 1},
        {1, 0, 1, 1},
        {1, 1, 1, 1},
        {1, 1, 0, 'e'}
    };

    static List<char> path = new List<char>();
   
    static bool InRange(int row, int col)
    {
        bool rowInRange = row >= 0 && row < matrix.GetLength(0);
        bool colInRange = col >= 0 && col < matrix.GetLength(1);
        return rowInRange && colInRange;
    }

    static void FindPathToExit(int row, int col, char direction)
    {
        
        if (!InRange(row, col))
        {
            // can't find a path
            return;
        }

        // Append the current direction to the path
        path.Add(direction);
        
        
        

        // Check if we have found the exit
        if (matrix[row, col] == 'e')
        {
            PrintPath(path);
           
        }
       
        if (matrix[row, col] == 1)
        {
            // Mark the current cell as visited
            matrix[row, col] = 's';

            //Explore all possible directions
            FindPathToExit(row, col - 1, 'L'); // left
            FindPathToExit(row - 1, col, 'U'); // up
            FindPathToExit(row, col + 1, 'R'); // right
            FindPathToExit(row + 1, col, 'D'); // down

            // Mark back the current cell as free
            matrix[row, col] = 1;
            
        }

        // Remove the last direction from the path
        path.RemoveAt(path.Count - 1);
        
       
    }

    static void PrintPath(List<char> path)
    {
        
        Console.Write("Found path to the exit: ");
        foreach (var dir in path)
        {
            Console.Write(dir);
            
            
        }

        Console.WriteLine();
    }

    
    static void Main()
    {
        
        char starCell = 'S';//top left
        FindPathToExit(0, 0, starCell);
       
    }
}
