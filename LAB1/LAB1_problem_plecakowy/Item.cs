using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LAB1_problem_plecakowy
{
    internal class item{
        private double weight;
        private double value;
        private double worth;
        private int x = 0;
        public double Weight {
            get{ return weight; }
            set { weight = value; } 
        }
        public double Value {
            get { return value; }
            set { this.value = value; }
        }
        public double Worth{
            get { return worth; }
            set { this.worth = value; }
        }
        public int X {
            get { return x; }
            set { x = value; }
        }
        public item(double value, double weight, int x)
        {
            this.value = value;
            this.weight = weight;
            this.worth = (double)value/weight;
            this.x = x;
        }

        public override string ToString()
        {
            return $"Weight: {Weight}, Value: {Value}, Worth: {Worth}, X: {X}";
        }
    }
}