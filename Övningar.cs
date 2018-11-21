
using System.Collections.Generic;

public interface Övningar {
    int Summa(List<int> heltal);
    string FizzBuzz(int heltal);

    int FibonacciRec(int n); // Lös rekursivt

    int Fibonacci(int n); // Lös O(n)

    // Returns the position of `elementToFind` in array
    // Assume that array is ordered/sorted ascending and 
    // that an element can only appear once in the array
    // Make 2 implementations, one that solves the problem in
    // O(n) and one that solves the problem in O(log n)
    int Find(int[] array, int elementToFind);
}
