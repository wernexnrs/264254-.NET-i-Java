using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB1_problem_plecakowy
{
    internal class Result
    {
        public List<int> numbers_in_backpack { get; set; } = new List<int>();

        public double total_value { get; set; }
        public double total_weight { get; set; }


        public override string ToString()
        {
            return $"Items: {String.Join(", ", numbers_in_backpack.ToArray())} \nTotal value: {total_value} \nTotal Weight: {total_weight} ";
        }
    }
}
