namespace LAB0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj górny zakres liczb:");

            int Up_Limit = Convert.ToInt32(Console.ReadLine());

            FizzBuzz fizzBuzz = new FizzBuzz(Up_Limit);
            fizzBuzz.PrintFizzBuzz();
        }
    }

    class FizzBuzz
    {
        private int Up_Limit;
        public FizzBuzz(int Up_Limit) => this.Up_Limit = Up_Limit;

        public void PrintFizzBuzz()
        {
            for (int i = 1; i <= Up_Limit; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }

    }
}
