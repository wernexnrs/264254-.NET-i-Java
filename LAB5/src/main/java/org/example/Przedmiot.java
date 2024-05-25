package org.example;

public class Przedmiot {
    public int weight;
    public int value;

    public Przedmiot(int weight, int value) {
        this.weight = weight;
        this.value = value;
    }

    @Override
    public String toString() {
        return "Weight: " + weight + ", Value: " + value;
    }
}
