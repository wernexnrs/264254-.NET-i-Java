package org.example;

import java.util.ArrayList;
import java.util.Random;
import java.util.Collections;

public class Problem {
    public int n;
    public int seed;
    public int lowerBound;
    public int upperBound;
    public int weight;
    public int value;
    public ArrayList<Przedmiot> lista_obiektow;

    public Problem(int n, int seed){
        this.n = n;
        this.seed = seed;
        this.lowerBound = 1;
        this.upperBound = 10;
        this.lista_obiektow = new ArrayList<>();

        Random random = new Random(seed);
        for (int i = 0; i < n; i++) {
            this.value = random.nextInt(upperBound - lowerBound+1) + lowerBound;
            this.weight = random.nextInt(upperBound - lowerBound+1) + lowerBound;
            lista_obiektow.add(new Przedmiot(weight, value));
        }
    }
    public Result solve(int capacity) {
        Collections.sort(lista_obiektow, (a, b) -> Double.compare((double)b.value/b.weight, (double)a.value/a.weight));

        int totalWeight = 0;
        int totalValue = 0;
        ArrayList<Przedmiot> selectedItems = new ArrayList<>();

        for (Przedmiot item : lista_obiektow) {
            while (totalWeight + item.weight <= capacity) {
                selectedItems.add(item);
                totalWeight += item.weight;
                totalValue += item.value;
            }
        }

        return new Result(selectedItems, totalValue, totalWeight);
    }

    @Override
    public String toString() {
        StringBuilder builder = new StringBuilder();
        for (Przedmiot item : lista_obiektow) {
            builder.append("No: ").append(lista_obiektow.indexOf(item))
                    .append(" v: ").append(item.value)
                    .append(" w: ").append(item.weight).append("\n");
        }
        return builder.toString();
    }

}
