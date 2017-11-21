﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_11T15H_21H_VoidMethods
{
    public class Program
    {

        static void Main(string[] args)
        {
            int index = 0, element = 5, x = 10, y = 10;

            int[,] twoDimArray = FillingTwoDimentionalArrays(x, y);
            int[] oneDimArray = FillingOneDimentionalArrays(x);
            PrintTwoDimentionalArrays(twoDimArray);
            PrintOneDimentionalArrays(oneDimArray);

            int[] arrayWithMaxValuesInRows = MaxValueInRow(twoDimArray);
            PrintOneDimentionalArrays(arrayWithMaxValuesInRows);

            FindElement(oneDimArray, element, out index);
            Console.WriteLine($"Element {element} found in given array {index} times");

            int[] one = new int[] { 1, 2, 3, 5, 4, 5 };
            int[] two = new int[] { 4, 1, 2, 3, 4 };
            var result = Except(one, two);
            PrintOneDimentionalArrays(result);

            Console.ReadLine();
        }

        static int[,] FillingTwoDimentionalArrays(int x, int y)
        {
            int[,] exampleArray = new int[x, y];
            Random rand = new Random();

            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                    exampleArray[i, j] = rand.Next(-10, 10);
            return exampleArray;
        }

        static int[] FillingOneDimentionalArrays(int x)
        {
            int[] exampleArray = new int[x];
            Random rand = new Random();

            for (int i = 0; i < x; i++)
                exampleArray[i] = rand.Next(-10, 10);
            return exampleArray;
        }

        static void PrintTwoDimentionalArrays(int[,] exampleArray)
        {
            for (int i = 0; i < exampleArray.GetLength(0); i++)
                for (int j = 0; j < exampleArray.GetLength(1); j++)
                    Console.Write(exampleArray[i, j] + (i != exampleArray.GetLength(0) && j != exampleArray.GetLength(1) - 1 ? ", " : "\r\n"));
        }

        static void PrintOneDimentionalArrays(int[] exampleArray)
        {
            for (int i = 0; i < exampleArray.Length; i++)
                Console.Write(exampleArray[i] + (i != exampleArray.Length - 1 ? ", " : ""));
        }

        static int[] MaxValueInRow(int[,] exampleArray)
        {
            int maxValue = int.MinValue;
            int[] arrayWithMaxValuesInRows = new int[exampleArray.GetLength(0)];

            for (int i = 0; i < exampleArray.GetLength(0); i++)
            {
                maxValue = int.MinValue;
                for (int j = 0; j < exampleArray.GetLength(1); j++)
                    maxValue = maxValue < exampleArray[i, j] ? exampleArray[i, j] : maxValue;
                arrayWithMaxValuesInRows[i] = maxValue;
            }
            return arrayWithMaxValuesInRows;
        }

        static bool FindElement(int[] exampleArray, int element, out int index)
        {
            int number = 0;
            for (int i = 0; i < exampleArray.Length; i++)
            {
                if (exampleArray[i] == element)
                {
                    number++;
                }
            }
            index = number;
            return number > 0;
        }

        public static int[] JoinArraysDistinct(int[] firstExampleArray, int[] secondExampleArray)
        {
            int[] resultArray = new int[firstExampleArray.Length + secondExampleArray.Length];
            for (int i = 0; i < resultArray.Length; i++)
                resultArray[i] = int.MinValue;

            int count = 0;
            for (int i = 0; i < firstExampleArray.Length; i++)
            {
                bool exist = false;
                for (int j = 0; j < resultArray.Length; j++)
                {
                    if (resultArray[j] == int.MinValue)
                        break;
                    if (firstExampleArray[i] == resultArray[j])
                    {
                        exist = true;
                        break;
                    }
                }
                if (!exist)
                {
                    resultArray[count] = firstExampleArray[i];
                    count++;
                }
            }
            for (int i = 0; i < secondExampleArray.Length; i++)
            {
                bool exist = false;
                for (int j = 0; j < resultArray.Length; j++)
                {
                    if (resultArray[j] == int.MinValue)
                        break;
                    if (secondExampleArray[i] == resultArray[j])
                    {
                        exist = true;
                        break;
                    }
                }
                if (!exist)
                {
                    resultArray[count] = secondExampleArray[i];
                    count++;
                }
            }
            int[] finalArray = new int[count];
            for (int i = 0; i < finalArray.Length; i++)
                finalArray[i] = resultArray[i];
            return finalArray;
        }
    }

}
