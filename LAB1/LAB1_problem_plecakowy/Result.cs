using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB1_problem_plecakowy
{
    internal class Result
    {
        public List<int> Numbers_in_backpack { get; set; } = [];

        public double Total_value { get; set; }
        public double Total_weight { get; set; }


        public override string ToString()
        {
            return $"Items: {String.Join(", ", Numbers_in_backpack.ToArray())+Environment.NewLine}Total value: {Total_value + Environment.NewLine}Total Weight: {Total_weight+ Environment.NewLine}";
        }
    }
}
