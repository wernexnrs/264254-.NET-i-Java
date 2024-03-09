using System.Diagnostics;
using System.Runtime.CompilerServices;
using LAB1_problem_plecakowy;
namespace MSTest_Project
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void one_good_one_out()
        {
            /*Sprawdzenie, czy jeœli co najmniej jeden 
             przedmiot spe³nia ograniczenia, 
             to zwrócono co najmniej jeden element.*/

            problem problem = new problem(15,2);

            int capacity = 10;
            Result result = problem.Solve(capacity);

            Debug.Assert(problem.items.Any(item => item.Weight <= capacity) && result.numbers_in_backpack.Count >= 1);

        }
        [TestMethod]
        public void zero_good_zero_out()
        {
            /*Sprawdzenie, czy jeœli 
             ¿aden przedmiot nie spe³nia ograniczeñ, 
             to zwrócono puste rozwi¹zanie.*/

            problem problem = new problem(15, 2);

            double capacity = 0.0001;
            Result result = problem.Solve(capacity);

            Debug.Assert(problem.items.All(item => item.Weight > capacity) && result.numbers_in_backpack.Count == 0);

        }
        [TestMethod]
        public void items_order()
        {
            /*Sprawdzenie, czy kolejnoœæ przedmiotów 
             ma wp³ywa na znalezione rozwi¹zanie..*/
            double capacity = 10;

            problem problem = new problem(15, 2);
            Result result = problem.Solve(capacity);


            problem problem_reversed = problem;
            problem_reversed.items.OrderBy(item => item.Weight);
            Result result_reversed = problem_reversed.Solve(capacity);


            Debug.Assert(result_reversed != result);

        }

        [TestMethod]
        public void is_result_ok()
        {
            /*Sprawdzenie poprawnoœci wyniku 
             dla konkretnej instancji.*/

            double capacity = 10;

            List<item> items = new List<item>{
            new item(1, 1, 0),
            new item(1, 1, 0),
            new item(1, 1, 0),
            new item(1, 1, 0),
            new item(1, 1, 0),
            new item(1, 1, 0),
            new item(1, 1, 0),
            new item(1, 1, 0)};

            problem problem_test = new problem(8,0);
            problem_test.items = items;

            Result result = problem_test.Solve(capacity);

            List<int> good_result = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 };

            CollectionAssert.AreEqual(good_result, result.numbers_in_backpack);
            Assert.AreEqual(8, result.total_value);
            Assert.AreEqual(8, result.total_weight);

        }
        [TestMethod]
        public void no_space_in_backpack()
        {
            /*Sprawdzenie, czy je¿eli plecak nie ma miejsca to nie bêdzie w nim przedmiotów.*/

            problem problem = new problem(15, 2);

            double capacity = 0;
            Result result = problem.Solve(capacity);

            Debug.Assert(result.numbers_in_backpack.Count == 0);

        }

        [TestMethod]
        public void a_lot_of_space_in_backpack()
        {
            /*Sprawdzenie, czy je¿eli plecak ma bardzo du¿o miejsca to wszystkie przedmioty do niego trafi³y.*/

            problem problem = new problem(1000, 2);

            double capacity = int.MaxValue;
            Result result = problem.Solve(capacity);

            Debug.Assert(result.numbers_in_backpack.Count == 1000);

        }

        [TestMethod]
        public void no_items()
        {
            /*Sprawdzenie, czy algorytm dzia³a gdy nie ma ¿adnych przedmiotów.*/

            problem problem = new problem(0, 2);

            double capacity = 20;
            Result result = problem.Solve(capacity);

            Debug.Assert(result.numbers_in_backpack.Count == 0 && result.total_weight == 0  && result.total_value ==0);

        }

        [TestMethod]
        public void is_size_of_items_ok()
        {
            /*Sprawdzenie, czy iloœæ wylosowanych przedmiotów zgadza siê z iloœci¹ obiektów w liœcie.*/

            problem problem = new problem(15, 2);

            Debug.Assert(problem.items.Count == 15);

        }
        
    }
}