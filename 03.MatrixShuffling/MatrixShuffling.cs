using System;
using System.Linq;

class MatrixShuffling
{
    static void Main()
    {
        int higth = int.Parse(Console.ReadLine());
        int length = int.Parse(Console.ReadLine());

        string[,] matrix = new string[higth, length];        //matric inicialization next:
        for (int i = 0; i < higth; i++)
        {
            for (int j = 0; j < length; j++)
            {
                matrix[i, j] = Console.ReadLine();
            }
        }

        string operation = Console.ReadLine();
        while (operation != "END")
        {
            string[] commands = operation.Split(' ').ToArray();

            if (commands[0] == "swap" && commands.Length == 5)
            {
                int x1 = int.Parse(commands[1]);
                int y1 = int.Parse(commands[2]);
                int x2 = int.Parse(commands[3]);
                int y2 = int.Parse(commands[4]);

                if ((x1 >= 0 && x1 < higth) && (y1 >= 0 && y1 < length)
                    && (x2 >= 0 && x2 < higth) && (y2 >= 0 && y2 < length))
                {
                    //swapping
                    string temp = matrix[x1, y1];
                    matrix[x1,y1] = matrix[x2,y2];
                    matrix[x2, y2] = temp;

                //printing
                    Console.WriteLine("(After swapping {0} and {1}): ", matrix[x2, y2], matrix[x1, y1]);
                    for (int row = 0; row < higth; row++)
                    {
                        for (int col = 0; col < length; col++)
                        {
                            Console.Write("{0,2} ", matrix[row, col]);
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
            operation = Console.ReadLine();
        }
    }
}

