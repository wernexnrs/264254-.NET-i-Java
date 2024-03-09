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
            Random random = new(seed);

            items = [];

            for (int i = 0; i < n; i++)
            {
                item newItem = new(random.Next(1, 11), random.Next(1, 11), 0);
                items.Add(newItem);
            }
        }

        public Result Solve(double capacity)
        {
            items = [.. items.OrderByDescending(item => item.Worth)];
            Result result = new();
            foreach (item element in items)
            {
                if (element.Weight <= capacity)
                {
                    element.X = 1;
                    capacity -= element.Weight;
                    result.Total_value += element.Value;
                    result.Total_weight += element.Weight;
                    result.Numbers_in_backpack.Add(items.IndexOf(element));
                }
                if (capacity < items.Min(item => item.Weight)) break;
            }
            return result;
        }
        public override string ToString()
        {
            string result = $"Liczba przedmiotów: {n + Environment.NewLine}";
            result += $"Lista przedmiotów:{Environment.NewLine}";

            for (int i = 0; i<n; i++)
            {
                result += $"No. {i}, Wartość: {items[i].Value}, Waga: {items[i].Weight},  Moc: {items[i].Worth}, X: {items[i].X+Environment.NewLine}";
            }
            return result;
        }
        static void Main()
        {
            problem mc = new(10, 2);
            Result result = mc.Solve(10);
            Console.WriteLine(mc.ToString());
            Console.WriteLine(result.ToString());
        }

    }
}
