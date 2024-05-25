package org.example;

import java.util.ArrayList;

public class Result {
    private ArrayList<Przedmiot> items;
    private int totalValue;
    private int totalWeight;

    public Result(ArrayList<Przedmiot> items, int totalValue, int totalWeight) {
        this.items = items;
        this.totalValue = totalValue;
        this.totalWeight = totalWeight;
    }

    public ArrayList<Przedmiot> getItems() {
        return items;
    }

    public int getTotalValue() {
        return totalValue;
    }

    public int getTotalWeight() {
        return totalWeight;
    }

    @Override
    public String toString() {
        StringBuilder builder = new StringBuilder();
        builder.append("Weight: ").append(totalWeight).append("\n");
        builder.append("Value: ").append(totalValue).append("\n");
        for (Przedmiot item : items) {
            builder.append("No: ").append(items.indexOf(item))
                    .append(" v: ").append(item.value)
                    .append(" w: ").append(item.weight).append("\n");
        }
        return builder.toString();
    }
}
