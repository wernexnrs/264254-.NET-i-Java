using System.Windows.Markup;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Windows Forms App"), InternalsVisibleTo("GUI")]
[assembly: InternalsVisibleTo("MSTest Project")]
namespace LAB1_problem_plecakowy
{
    internal class problem
    {
        private int n { get; set; }
        public List<item> items { get; set; }
        public problem(int n, int seed = 1)
        {
            this.n = n;
            Random random = new Random(seed);

            items = new List<item>();

            for (int i = 0; i < n; i++)
            {
                item newItem = new item(random.Next(1, 11), random.Next(1, 11),0);
                items.Add(newItem);
            }
        }

        public Result Solve(double capacity)
        {
            items = items.OrderByDescending(item => item.Worth).ToList();
            Result result = new Result();
            foreach (item element in items)
            {
                if (element.Weight <= capacity)
                {
                    element.X = 1;
                    capacity -= element.Weight;
                    result.total_value += element.Value;
                    result.total_weight += element.Weight;
                    result.numbers_in_backpack.Add(items.IndexOf(element));
                }
                if (capacity < items.Min(item => item.Weight)) break;
            }
            return result;
        }
        public override string ToString()
        {
            string result = $"Liczba przedmiotów: {n}\n";
            result += "Lista przedmiotów:\n";

            for (int i = 0; i<n; i++)
            {
                result += $"No. {i}, Wartość: {items[i].Value}, Waga: {items[i].Weight},  Moc: {items[i].Worth}, X: {items[i].X}\n";
            }
            return result;
        }
        static void Main()
        {
            problem mc = new problem(10, 2);
            Result result = mc.Solve(10);
            Console.WriteLine(mc.ToString());
            Console.WriteLine(result.ToString());
        }

    }
}
