using System;

namespace StringCalculator
{
    /*  Try not to read ahead.
        Do one task at a time. The trick is to learn to work incrementally.
        Make sure you only test for correct inputs. there is no need to test for invalid inputs for this kata */

    //Create a simple String calculator with a method int Add(string numbers)
    //The method can take 0, 1 or 2 numbers, and will return their sum(for an empty string it will return 0) for example “” or “1” or “1,2”
    //Start with the simplest test case of an empty string and move to 1 and two numbers
    //Remember to solve things as simply as possible so that you force yourself to write tests you did not think about
    //Remember to refactor after each passing test

    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (numbers == string.Empty)
                return 0;

            int singleNumber;
            if (int.TryParse(numbers, out singleNumber))
                return singleNumber;

            int sumOfNumbers = 0;
            string[] delimitedNumbers = numbers.Split(',');
            for (int i = 0; i < delimitedNumbers.Length; i++)
            {
                sumOfNumbers += Convert.ToInt32(delimitedNumbers[i]);
                if (i == delimitedNumbers.Length - 1)
                    return sumOfNumbers;
            }

            return -1;
        }
    }
}
