using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SaddlePoints
{
    public static class SaddlePoints
    {
        public static IEnumerable<(int, int)> Calculate(int[,] matrix)
        {
            var goodTree = new List<(int rows, int columns)>();

            if (matrix.Length == 0)
            {
                return goodTree;
            }
                        
            for (int rows = 0; rows <= matrix.GetLength(0) - 1; rows++)
            {
                for (int columns = 0; columns < matrix.GetLength(1); columns++)
                {
                    var highestValueInRow = Enumerable.Range(0, matrix.GetLength(1))
                    .Select(x => matrix[rows, x]).OrderByDescending(x => x).First();
                    var highestValueInColumn = Enumerable.Range(0, matrix.GetLength(0))
                    .Select(x => matrix[x, columns]).OrderBy(x => x).First();
                    //check if matrix[rows, columns] has the highest value in the row
                    if (matrix[rows, columns] == highestValueInRow && matrix[rows, columns] == highestValueInColumn)
                    {
                        //Add 1 because the counting of rows and columns in the exercise starts from 1
                        goodTree.Add((rows + 1, columns + 1));
                    }

                }

            }

            goodTree = goodTree.Distinct().ToList();
            //matrix.Cast<int[,]>().ToList();
            return goodTree;


        }

        static void Main()
        {
            var matrix = new[,]
        {
            {
                6,
                7,
                8
            },
            {
                5,
                5,
                5
            },
            {
                7,
                5,
                6
            }
        };

            Calculate(matrix);
        }


    }
}
