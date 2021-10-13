using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatalogiInlamningsuppgfit1.Utility;
using DatalogiInlamningsuppgfit1;
using System.Threading;
using DatalogiInlamningsuppgfit1.DataStructures;

namespace DatalogiInlamningsuppgfit1
{
    internal class Core
    {
        private int menuChoice;
        private int nrOfMenuChoices;
        private string errormsg;
        private BinaryTree binTree;

        // Constructor initalizes the variables and list
        internal Core()
        {
            binTree = new BinaryTree();
            Visuals.Welcome();
            Thread.Sleep(1000);
            Menu();
        }

        // Method of running the menu
        private void Menu()
        {
            bool runMenu = true;
            nrOfMenuChoices = 4;
            while (runMenu)
            {
                Console.WriteLine("1. Add prime nr\n2. Show binary tree of added primes\n3. Add next prime number of the highest number in the data structure\n0. Exit\n");
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

        // Adds the next prime number of the highest prime number in the binary tree.
        // Also checks if the data structure is empty first.
        private void AddNextPrimeToDatastructure()
        {
            if(binTree.Root != null)
            {
                int highest = binTree.MaxVal();
                int nextPrime = Utils.GetNextPrimeNr(highest);
                binTree.Add(nextPrime);
                Console.Clear();
                Console.WriteLine($"{nextPrime} has now been added to the binary tree\n");
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
            if(binTree.Root != null)
            {
                Console.WriteLine(binTree.TraversePreOrder() + "\n");
                ShowBinTreeInOrder();
            }
            else
            {
                Console.WriteLine("Binary tree is empty\n");
            }
        }

        private void ShowBinTreeInOrder()
        {
            bool runMenu = true;
            nrOfMenuChoices = 2;
            while (runMenu)
            {
                Console.WriteLine("1. Show tree in Order\n0. Exit\n");
                var input = Console.ReadLine();
                if (Utils.IsMenuInputValid(input, out menuChoice, out errormsg, nrOfMenuChoices))
                {
                    switch (menuChoice)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine(binTree.TraverseInOrder() + "\n");
                            break;
                        case 0:
                            runMenu = false;
                            Console.Clear();
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

        // Enables user to enter a input.
        // Then checks if this input is valid and if its a prime
        // If input is a prime, it gets added to the binary tree of primes
        private void EnterAPrimeNr()
        {
            Console.Clear();
            Console.WriteLine("Enter a prime number");
            int validNumber;
            var input = Console.ReadLine();
            if(Utils.IsInputValid(input, out validNumber, out errormsg, false))
            {
                if (Utils.IsPrimeNumber(validNumber))
                {
                    Console.Clear();
                    
                    if(binTree.Add(validNumber))
                    { 
                        Console.WriteLine($"{validNumber} is a prime number!\nAnd is now added to the binary tree :)\n");
                    }
                    else
                    {
                        Console.WriteLine("Value already exists in the binary tree\nChoose another one\n");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Im sorry but {validNumber} is not a prime number\n");
                }
            }
            else
            {
                Console.WriteLine(errormsg);
            }
        }
    }
}
