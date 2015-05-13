//02.Write a program that reads a rectangular integer matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements. 
//On the first line, you will receive the rows N and columns M. On the next N lines you will receive each row with its columns.
//Print the elements of the 3 x 3 square as a matrix, along with their sum.

using System;
using System.Linq;


class MaximalSum
{
    static void Main()
    {
        string[] matrixDimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int higth = int.Parse(matrixDimensions[0]);
        int length = int.Parse(matrixDimensions[1]);

        int[,] matrix = new int[higth, length];        //matric inicialization
        for (int i = 0; i < higth; i++)
        {
            string input = Console.ReadLine();
            string[] strArr = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < strArr.Length; j++)
            {
                matrix[i, j] = int.Parse(strArr[j]);
            }
        }

        int bestSum = int.MinValue;
        int startPointRows = 0;
        int startPointCols = 0;

        for (int row = 0; row < matrix.GetLength(0) - 2; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 2; col++)
            {
                int currentSum =
                    matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                    matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                    matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                if (currentSum > bestSum)
                {
                    bestSum = currentSum;
                    startPointRows = row;
                    startPointCols = col;
                }
            }
        }

        Console.WriteLine("Sum = {0}", bestSum); //printing
        for (int row = startPointRows; row < startPointRows + 3; row++)
        {
            for (int col = startPointCols; col < startPointCols + 3; col++)
            {
                Console.Write("{0,3}",matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}

