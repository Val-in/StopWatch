using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string filePath = @"D:\Desktop\Text1.txt";
        string[] lines = File.ReadAllLines(filePath);
        const int repetitions = 10;  // для сглаживания результатов

        CountTickList(lines, repetitions);
        CountTickLinckedList(lines, repetitions);

        Console.ReadKey();
    }
    static void CountTickList(string[] lines,int repetitions)
    {
        long listTime = 0;
        for (int i = 0; i < repetitions; i++)
        {
            List<string> list = new List<string>();
            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var line in lines)
            {
                list.Add(line);
            }
            stopwatch.Stop();
            listTime += stopwatch.ElapsedTicks;
        }
        Console.WriteLine("Среднее время вставки для List<T>: " + (listTime / repetitions) + " тиков");
    }
    static void CountTickLinckedList(string[] lines, int repetitions)
    {
        long linkedListTime = 0;
        for (int i = 0; i < repetitions; i++)
        {
            LinkedList<string> linkedList = new LinkedList<string>();
            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var line in lines)
            {
                linkedList.AddLast(line);
            }
            stopwatch.Stop();
            linkedListTime += stopwatch.ElapsedTicks;
        }
        Console.WriteLine("Среднее время вставки для LinkedList<T>: " + (linkedListTime / repetitions) + " тиков");
    }
}
