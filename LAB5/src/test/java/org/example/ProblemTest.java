package org.example;

import org.junit.Assert;
import org.junit.Test;


public class ProblemTest {
    @Test
    public void testAtLeastOneItemReturnedWhenConditionMet() {
        // Sprawdzenie, czy jeśli co najmniej jeden przedmiot spełnia ograniczenia, to zwrócono co najmniej jeden element
        int capacity = 3;
        Problem problem = new Problem(10, 1);
        Result result = problem.solve(capacity);

        boolean isAnyItemInProblemEligible = problem.lista_obiektow.stream().anyMatch(item -> item.weight <= capacity);
        boolean isAnyItemInResultEligible = result.getItems().stream().anyMatch(item -> item.weight <= capacity);

        Assert.assertFalse(!isAnyItemInProblemEligible && !isAnyItemInResultEligible);
    }

    @Test
    public void testEmptyResultWhenNoItemMeetsConditions() {
        //Sprawdzenie, czy jeśli żaden przedmiot nie spełnia ograniczeń, to zwrócono puste rozwiązanie
        int capacity = 0;

        Problem problem = new Problem(10, 100);
        Result result = problem.solve(capacity);

        boolean isAllItemInProblem = problem.lista_obiektow.stream().allMatch(item -> item.weight > capacity);
        boolean isAllItemInResult = result.getItems().isEmpty();

        Assert.assertTrue(isAllItemInProblem && isAllItemInResult);
    }

    @Test
    public void testAllItemsWithinSpecifiedRange() {
        //Sprawdzenie, czy waga i wartość wszystkich przedmiotów z listy mieści się w założonym przedziale
        Problem problem = new Problem(10, 1); // Zakładając, że wszystkie przedmioty spełniają te kryteria

        var upperBound = problem.upperBound;
        var lowerBound = problem.lowerBound;

        Assert.assertTrue("All items should meet the weight and value requirements",
                problem.lista_obiektow.stream().allMatch(
                        item -> item.weight <= upperBound &&
                                item.weight >= lowerBound &&
                                item.value <= upperBound &&
                                item.value >= lowerBound
                ));
    }

    @Test
    public void testCorrectSumOfWeightAndValue() {
        //Sprawdzenie poprawności wyniku (sumy wag i wartości w plecaku) dla konkretnej instancji
        Problem problem = new Problem(10, 1); // Ustawienia, które pozwolą na dodanie przedmiotów do wyniku
        Result result = problem.solve(15);

        var proper_weight = 15;
        var proper_total_value = 33;

        Assert.assertTrue("Total weight should match expected", result.getTotalWeight() == proper_weight && result.getTotalValue() == proper_total_value);
    }
}