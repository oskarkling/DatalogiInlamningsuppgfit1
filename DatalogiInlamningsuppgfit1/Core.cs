using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatalogiInlamningsuppgfit1.Utility;
using DatalogiInlamningsuppgfit1;
using System.Threading;

namespace DatalogiInlamningsuppgfit1
{
    internal class Core
    {
        private int menuChoice;
        private int nrOfMenuChoices;
        private string errormsg;
        private List<int> listOfPrimes;

        // Constructor initalizes the variables and list
        internal Core()
        {
            listOfPrimes = new List<int>();
            nrOfMenuChoices = 4;
            Visuals.Welcome();
            Thread.Sleep(1000);
            Menu();
        }

        // Method of running the menu
        private void Menu()
        {
            bool runMenu = true;
            while(runMenu)
            {
                Console.WriteLine("1. Add prime nr\n2. Show datastructure of added prime numbers (List)\n3. Add next prime number of the highest number in the data structure\n0. Exit\n");
                var input = Console.ReadLine();
                if (Utils.IsMenuInputValid(input, out menuChoice, out errormsg, nrOfMenuChoices))
                {
                    switch(menuChoice)
                    {
                        case 1:
                            EnterAPrimeNr();
                            break;
                        case 2:
                            ShowDatastructure();
                            break;
                        case 3:
                            AddNextPrimeToDatastructure();
                            break;
                        case 0:
                            runMenu = false;
                            Console.Clear();
                            Console.WriteLine("bye bye");
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(errormsg);
                }
                
            }
        }

        // Adds the next prime number of the highest prime number in the data structure to the data strucutre.
        // Also checks if the data structure is empty first. Then loops through the data structure of the highest number of value.
        private void AddNextPrimeToDatastructure()
        {
            if(!Utils.IsListEmpty(listOfPrimes))
            {
                int highest = 0;
                for(int i = 0; i < listOfPrimes.Count; i++)
                {
                    if(listOfPrimes[i] > highest)
                    {
                        highest = listOfPrimes[i];
                    }
                }

                int nextPrime = Utils.GetNextPrimeNr(highest);
                listOfPrimes.Add(nextPrime);
                Console.Clear();
                Console.WriteLine($"{nextPrime} has now been added to the data stucture");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Sorry but the data structure is empty\nAdd some numbers.\n");
            }
        }

        // Prints the datastructure to the console.
        private void ShowDatastructure()
        {
            Console.Clear();
            for(int i = 0; i < listOfPrimes.Count; i++)
            {
                if(i == listOfPrimes.Count - 1)
                {
                    Console.Write($"{listOfPrimes[i]}");
                }
                else
                {
                    Console.Write($"{listOfPrimes[i]}, ");
                }
            }
            Console.WriteLine("\n");
        }

        // Enables user to enter a input.
        // Then checks if this input is valid and if its a prime
        // If input is a prime, it gets added to the list of primes
        private void EnterAPrimeNr()
        {
            Console.Clear();
            Console.WriteLine("Enter a prime number");
            int validNumber;
            var input = Console.ReadLine();
            if(Utils.IsInputValid(input, out validNumber, out errormsg))
            {
                if (Utils.IsPrimeNumber(validNumber))
                {
                    Console.Clear();
                    Console.WriteLine($"{validNumber} is a prime number!\nAnd is now added to a generic data structure, also called a List :)\n");
                    listOfPrimes.Add(validNumber);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Im sorry but {validNumber} is not a prime number");
                }
            }
            else
            {
                Console.WriteLine(errormsg);
            }
        }
    }
}
