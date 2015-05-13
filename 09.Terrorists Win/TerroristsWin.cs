﻿using System;

class TerroristsWin
{
    static void Main()
    {
        int start = 0;
        int explosionRight = 0;
        int explosionLeft = 0;
        bool bombFound = false;
        string sentence = Console.ReadLine();

        for (int i = 0; i < sentence.Length; i++)   //finding the start of a bomb
        {
            if (sentence[i] == '|')
            {
                bombFound = !bombFound;

                if (bombFound)       //begining of a bomb
                {
                    start = i;
                }
                else        //ending of a bomb
                {
                    int end = i;

                    CalculatingBombPower(start, end, sentence, ref explosionRight, ref explosionLeft);
                    CheckExplosionRadius(start, sentence, ref explosionRight, ref explosionLeft);
                    ExplodingTheString(start, explosionRight, explosionLeft, ref sentence);
                }
            }
        }
        Console.WriteLine(sentence);
    }

    static void CheckExplosionRadius(int start, string sentence, ref int explosionRight, ref int explosionLeft)
    {
        //checking if the radius is bigger than the string
        if (start + explosionRight > sentence.Length)
        {
            explosionRight = sentence.Length - start;
        }
        if (explosionLeft > start)
        {
            explosionLeft = start;
        }
    }

    static void CalculatingBombPower(int start, int end, string sentence, ref int explosionRight, ref int explosionLeft)
    {
        int bombPower = 0;
        int innerLength = (end - start) - 1;

        //parse input of the bomb
        for (int l = start + 1; l < end; l++)
        {
            bombPower += sentence[l];
        }
        bombPower = bombPower % 10;
        explosionRight = (innerLength + 2) + bombPower;
        explosionLeft = bombPower;
    }

    static void ExplodingTheString(int start, int explosionRight, int explosionLeft, ref string sentence)
    {
        //exploding the string
        int explosion = explosionLeft + explosionRight;
        string boom = new string('.', explosion);
        sentence = sentence.Remove(start - explosionLeft, explosion).Insert(start - explosionLeft, boom);
    }
}