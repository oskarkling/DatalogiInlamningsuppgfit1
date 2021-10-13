using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
        public static bool IsPrimeNumber(long nr)
        {
            if (nr == 1) return false;
            if (nr == 2) return true;
            var max = Math.Ceiling(Math.Sqrt(nr));
            for(long i = 2; i <= max; i++)
            {
                if(nr % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        // Checks if user menu input is valid
        public static bool IsMenuInputValid(string input, out long validNumber, out string errormsg, long nrOfMenuChoices)
        {
            errormsg = "no error";
            validNumber = 0;

            if (IsInputValid(input, out validNumber, out errormsg, true))
            {
                if(validNumber < nrOfMenuChoices)
                {
                    return true;
                }
                else
                {
                    errormsg = $"Menu choice is out for range for menu choices. Use 0 - {nrOfMenuChoices - 1}\n";
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        // Checks if user input is valid
        // if its empty, anumber or if the input is zero
        // if not successful it sends an errormsg also.
        public static bool IsInputValid(string input, out long validNumber, out string errormsg, bool canBeZero)
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
                        if(canBeZero)
                        {
                            return true;
                        }
                        else
                        {
                            if(validNumber != 0)
                            {
                                return true;
                            }
                            else
                            {
                                errormsg = "You can not input 0.\nIs 0 a Natural Number? No, 0 is NOT a natural number because natural numbers are counting numbers. For counting any number of objects, we start counting from 1 and not from 0.\n";
                                return false;
                            }
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
                    errormsg = "Input was not a valid number\n";
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
        public static long GetNextPrimeNr(long number)
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
        private static bool IsInputANumber(string input, out long number)
        {
            return long.TryParse(input, out number);
        }

        // Checks if string is empty
        private static bool IsInputEmpty(string input)
        {
            return input == string.Empty;
        }

        // Checks if the number is negative
        private static bool IsNumberNegative(long number)
        {
            return number < 0;
        }
    }
}
