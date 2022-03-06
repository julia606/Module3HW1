// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace M3HW1
{
    using System;

    /// <summary>
    /// Main class.
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            Random rnd = new Random();

            int[] arr = { 4, 5, 6, 7 };
            int[] arr2 = { 8, 9, 12, 13 };
            var myGen = new MyGeneric<int>(arr);

            Console.Write("Ваша коллекция до изменений : ");
            foreach (var i in myGen)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();

            myGen.Add(5);
            myGen.RemoveAt(rnd.Next(0, arr.Length));
            myGen.AddRange(arr2);
            myGen.Sort();
            myGen.Remove(-6);

            Console.Write("Ваша коллекция после изменений : ");
            foreach (var i in myGen)
            {
                Console.Write($"{i} ");
            }
        }
    }
}
