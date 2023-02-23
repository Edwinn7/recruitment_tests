using System;
using System.Collections.Generic;
using System.Linq;

public class BubbleSortCollectionSorter : ICollectionSorter
{
    public string[] SortAscending(int[] numbers)
    {
        int numSwaps = 0;
        int n = numbers.Length;
        int[] sortedNumbers = (int[])numbers.Clone();

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (sortedNumbers[j] > sortedNumbers[j + 1])
                {
                    int temp = sortedNumbers[j];
                    sortedNumbers[j] = sortedNumbers[j + 1];
                    sortedNumbers[j + 1] = temp;
                    numSwaps++;

                    if (numSwaps == ushort.MaxValue)
                    {
                        throw new InvalidOperationException("Maximum number of trades reached.");
                    }
                }
            }
        }

        return sortedNumbers.Select(ConvertNumberToString).ToArray();
    }

    public string[] SortDescending(int[] numbers)
    {
        int numSwaps = 0;
        int n = numbers.Length;
        int[] sortedNumbers = (int[])numbers.Clone();

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (sortedNumbers[j] < sortedNumbers[j + 1])
                {
                    int temp = sortedNumbers[j];
                    sortedNumbers[j] = sortedNumbers[j + 1];
                    sortedNumbers[j + 1] = temp;
                    numSwaps++;

                    if (numSwaps == ushort.MaxValue)
                    {
                        throw new InvalidOperationException("Maximum number of trades reached.");
                    }
                }
            }
        }

        return sortedNumbers.Select(ConvertNumberToString).ToArray();
    }

    private static string ConvertNumberToString(int number)
    {
        string[] digits = { "ZeRo", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        if (number >= 0 && number <= 9)
        {
            return digits[number].ToUpper();
        }
        else if (number % 2 == 0)
        {
            return number.ToString().ToLower();
        }
        else
        {
            return number.ToString().ToUpper();
        }
    }
}
