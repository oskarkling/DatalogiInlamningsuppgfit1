﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatalogiInlamningsuppgfit1.Utility
{
    public static class Utils
    {

        // Checks if the number input is a prime number.
        // First it sends false if nr = 1 or true if nr = 2
        // Then gets max possible checks with square root of nr
        // Then uses modulus. If there is a rest from modulus- it is a prime number.
        public static bool IsPrimeNumber(int nr)
        {
            if (nr == 1) return false;
            if (nr == 2) return true;
            var max = Math.Ceiling(Math.Sqrt(nr));
            for(int i = 2; i <= max; i++)
            {
                if(nr % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        // Checks if user input is valid
        // if its empty, a number, if its within the menu range.
        // also sends an errormsg if input is not valid
        public static bool IsMenuInputValid(string input, out int validNumber, out string errormsg, int nrOfMenuChoices)
        {
            errormsg = "no error";
            validNumber = 0;

            if (IsInputEmpty(input))
            {
                errormsg = "Input was empty\n";
                return false;
            }
            else
            {
                if (IsInputANumber(input, out validNumber))
                {
                    if(!IsNumberNegative(validNumber))
                    {
                        if(validNumber < nrOfMenuChoices)
                        {
                            return true;
                        }
                        else
                        {
                            errormsg = "Not valid menu choice\n";
                            return false;
                        }
                    }
                    else
                    {
                        errormsg = "No negative numbers here!\n";
                        return false;
                    }
                }
                else
                {
                    errormsg = "Input was not a number\n";
                    return false;
                }
            }

        }

        // Checks if user input is valid
        // if its empty, anumber or if the input is zero
        // if not successful it sends an errormsg also.
        public static bool IsInputValid(string input, out int validNumber, out string errormsg)
        {
            errormsg = "no error";
            validNumber = 0;
            if(IsInputEmpty(input)) 
            {
                errormsg = "Input was empty\n";
                return false;
            }
            else
            {
                if (IsInputANumber(input, out validNumber))
                {
                    if(!IsNumberNegative(validNumber))
                    {
                        if(validNumber != 0)
                        {
                            return true;
                        }
                        else
                        {
                            errormsg = "You can not input 0.\nIs 0 a Natural Number? No, 0 is NOT a natural number because natural numbers are counting numbers. For counting any number of objects, we start counting from 1 and not from 0.";
                            return false;
                        }
                    }
                    else
                    {
                        errormsg = "No negative numbers here!\n";
                        return false;
                    }
                }
                else
                {
                    errormsg = "Input was not a number\n";
                    return false;
                }
            }
        }

        // Checks if the lsit is null or just has no elements
        public static bool IsListEmpty<T>(List<T> list)
        {
            if(list == null)
            {
                return true;
            }

            return !list.Any();
        }

        // Returns the next Prime number
        public static int GetNextPrimeNr(int number)
        {
            bool found = false;
            while(!found)
            {
                number++;
                if(IsPrimeNumber(number))
                {
                    found = true;
                }
            }
            return number;
        }

        // Checks if string input is a number
        // Then sends an int with that number
        private static bool IsInputANumber(string input, out int number)
        {
            return Int32.TryParse(input, out number);
        }

        // Checks if string is empty
        private static bool IsInputEmpty(string input)
        {
            return input == string.Empty;
        }

        // Checks if the number is negative
        private static bool IsNumberNegative(int number)
        {
            return number < 0;
        }

    }
}