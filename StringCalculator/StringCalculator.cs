﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    // http://osherove.com/tdd-kata-1/
    /*  Try not to read ahead.
        Do one task at a time. The trick is to learn to work incrementally.
        Make sure you only test for correct inputs. there is no need to test for invalid inputs for this kata */

    // Create a simple String calculator with a method int Add(string numbers)
    // [X] The method can take 0, 1 or 2 numbers, and will return their sum(for an empty string it will return 0) for example “” or “1” or “1,2”
    // Start with the simplest test case of an empty string and move to 1 and two numbers
    // Remember to solve things as simply as possible so that you force yourself to write tests you did not think about
    // Remember to refactor after each passing test

    // [X] Allow the Add method to handle an unknown amount of numbers

    // [ ] Allow the Add method to handle new lines between numbers (instead of commas).
    // the following input is ok:  “1\n2,3”  (will equal 6)
    // the following input is NOT ok:  “1,\n” (not need to prove it - just clarifying)

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
            List<string> delimitedNumbers = numbers.Split(',').ToList();
            var itemContainingNewLines = delimitedNumbers.SingleOrDefault(dn => dn.Contains("\n"));
            if (itemContainingNewLines != null)
            {
                delimitedNumbers.Remove(itemContainingNewLines);
                var items = itemContainingNewLines.Split('\n');
                delimitedNumbers.AddRange(items);
            }

            for (int i = 0; i < delimitedNumbers.Count(); i++)
            {
                sumOfNumbers += Convert.ToInt32(delimitedNumbers[i]);
                if (i == delimitedNumbers.Count() - 1)
                    return sumOfNumbers;
            }

            return -1;
        }
    }
}
