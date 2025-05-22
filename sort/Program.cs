// See https://aka.ms/new-console-template for more information
using sort.src.extensions;

int[] arr1 = IntegerArrayExtension.GenerateRandomArray(100); 
Console.WriteLine("InsertionSort:");
arr1.Print();

int[] arr2 = new int[arr1.Length];

arr1.CopyTo(arr2, 0);

arr1.InsertionSort();

arr1.Print();

Console.WriteLine("Is Sorted? {0}", arr1.IsSorted() ? "True" : "False");

Console.WriteLine("Is Same array? {0}", IntegerArrayExtension.IsEqualsSet(arr1, arr2));

Console.WriteLine("QuickSort");

arr1 = IntegerArrayExtension.GenerateRandomArray(100); 

arr1.Print();

arr2 = new int[arr1.Length];

arr1.CopyTo(arr2, 0);

arr1.QuickSort();

arr1.Print();

Console.WriteLine("Is Sorted? {0}", arr1.IsSorted() ? "True" : "False");

Console.WriteLine("Is Same array? {0}", IntegerArrayExtension.IsEqualsSet(arr1, arr2));


