//01.Write two programs that fill and print a matrix of size N x N. Filling a matrix in the regular pattern (top to bottom and left to right) is boring. Fill the matrix as described in both patterns below:

using System;

class FillTheMatrix
{
    static void Main()
    {
        int matrixLength = int.Parse(Console.ReadLine());

        FillAndPrintMatrixPatternA(matrixLength);
        Console.WriteLine();
        FillAndPrintMatrixPatternB(matrixLength);
        Console.WriteLine();
    }

    static void FillAndPrintMatrixPatternA(int n)
    {
        int[,] matrixA = new int[n, n];
        int filler = 1;
        for (int col = 0; col < matrixA.GetLength(1); col++)
        {
            for (int row = 0; row < matrixA.GetLength(0); row++)
            {
                matrixA[row, col] = filler;
                filler++;
            }
        }
        PrintMatrix(matrixA);// printing
    }

    static void FillAndPrintMatrixPatternB(int n)
    {
        int[,] matrixB = new int[n, n];
        int filler = 1;
        int reverser = 0;
        for (int col = 0; col < matrixB.GetLength(1); col++)
        {
            if (reverser % 2 != 0) //odd (nechetno) NOT reversed
            {
                filler = ReversedFill(matrixB, filler, col); //invoking Reversed Fill
            }
            else //even (chetno) reversed
            {
                filler = RegularFill(matrixB, filler, col); //invoking RegularFill
            }
            reverser++;
        }
        PrintMatrix(matrixB); //Printing
    }


    static int RegularFill(int[,] myMatrix, int filler, int col)
    {
        for (int row = 0; row < myMatrix.GetLength(0); row++)
        {
            myMatrix[row, col] = filler;
            filler++;
        }
        return filler;
    }

    static int ReversedFill(int[,] myMatrix, int filler, int col)
    {
        for (int row = myMatrix.GetLength(0) - 1; row >= 0; row--)
        {
            myMatrix[row, col] = filler;
            filler++;
        }
        return filler;
    }


    static void PrintMatrix(int[,] myMatrix)
    {
        for (int row = 0; row < myMatrix.GetLength(0); row++)
        {
            for (int col = 0; col < myMatrix.GetLength(1); col++)
            {
                Console.Write("{0,3}", myMatrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}


