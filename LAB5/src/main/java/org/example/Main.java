package org.example;
//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {
        Problem problem = new Problem(10, 1);
        Result solved = problem.solve(15);

        System.out.println(problem);
        System.out.println(solved);
    }
}