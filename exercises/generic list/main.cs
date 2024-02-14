using static System.Console;
using System;

static class main
{
    public static int Main()
    {
        var list = new genlist<double[]>();
        char[] delimiters = { ' ', '\t' };
        var options = StringSplitOptions.RemoveEmptyEntries;
        for (string line = ReadLine(); line != null; line = ReadLine())
        {
            var words = line.Split(delimiters, options);
            int n = words.Length;
            var numbers = new double[n];
            for (int i = 0; i < n; i++) numbers[i] = double.Parse(words[i]);
            list.add(numbers);
        }
        for (int i = 0; i < list.size; i++)
        {
            var numbers = list[i];
            foreach (var number in numbers) Write($"{number: 0.00e+00;-0.00e+00} ");
            WriteLine();
        }
        WriteLine();
        WriteLine("Testing the remove function");
        var newlist = new genlist<double>();
        newlist.add(5.6);
        newlist.add(5.7);
        WriteLine("Array before removal");
        for (int i = 0; i < newlist.size; i++) WriteLine(newlist[i]);
        int c = 1;
        newlist.remove(c);
        WriteLine($"Array after removal of [{c}]");
        for (int i = 0; i < newlist.size; i++) WriteLine(newlist[i]);
        return 0;
    }
}