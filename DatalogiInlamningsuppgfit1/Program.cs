﻿using System;
using DatalogiInlamningsuppgfit1.Utility;
using DatalogiInlamningsuppgfit1;


namespace DatalogiInlamningsuppgfit1
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            Core core = new Core();

        }
    }
}
