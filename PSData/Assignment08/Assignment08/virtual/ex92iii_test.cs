using System;
using System.Collections.Generic;

class GarbageCollectionMeasurement
{
    static void Main(string[] args)
    {
        List<int> list = new List<int>();
        Dictionary<int, string> dictionary = new Dictionary<int, string>();
        string[] array = new string[10000000];

        Console.WriteLine("\nPress anything to continue...");
        Console.In.Read();

        // Initialize data structures with some values
        for (int i = 0; i < 10000000; i++)
        {
            list.Add(i);
            dictionary[i] = $"Item {i}";
            array[i] = $"Value {i}";
        }

        // Loop through the data structures
        Console.WriteLine("Looping through List:");
        foreach (var item in list)
        {
            if (item % 1000000 == 0)
            {
                Console.WriteLine(item);
            }
        }

        Console.WriteLine("\nLooping through Dictionary:");
        foreach (var kvp in dictionary)
        {
            if (kvp.Key % 1000000 == 0)
            {
                Console.WriteLine(kvp.Value);
            }
        }

        Console.WriteLine("\nAccessing Array elements:");
        for (int i = 0; i < 10000000; i++)
        {
            // Do some operations with the array
            var value = array[i];
        }

        // You can add more operations or modify the program as needed for your measurement.
    }
}