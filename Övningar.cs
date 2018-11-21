
using System.Collections.Generic;

public interface Övningar {
    // Summera alla tal i listan. Använd inte .Sum() ;)
    int Summa(List<int> heltal);
    
    // Om heltal är jämnt delbart med 3, returnera "Fizz"
    // Om heltal är jämnt delbart med 5, returnera "Buzz"
    // Om heltal är jämnt delbart med 3 och 5, returnera "FizzBuzz"
    string FizzBuzz(int heltal);

    // Lös fibonacci rekursivt
    int FibonacciRec(int n); // Lös rekursivt

    // Lös fibonacci utan rekursion (O(n))
    int Fibonacci(int n);

    // Lös fibonacci utan rekursion O(n) och med konstant minnesanvändning
    int Fibonacci2(int n);
    
    // Returns the position of `elementToFind` in array
    // Assume that array is ordered/sorted ascending and 
    // that an element can only appear once in the array
    // Make 2 implementations, one that solves the problem in
    // O(n) and one that solves the problem in O(log n)
    int Find(int[] array, int elementToFind);
}
