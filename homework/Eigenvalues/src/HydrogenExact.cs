using static System.Math;

public static class HydrogenExact
{
    public static double SE10(double x) { return x * 2 * (Exp(-x)); }
    public static double SE20(double x) { return x * (1 / Pow(2, 3 / 2)) * (2 - x) * (Exp(-x / 2)); }
    public static void Main(string[] args)
    {
        int rmax = 10;
        double dr = 0.05;
        int size = (int)(rmax / dr);
        foreach (var arg in args)
        {
            var words = arg.Split(':');
            if (words[0] == "-rmax") { rmax = int.Parse(words[1]); }
            if (words[0] == "-dr") { dr = double.Parse(words[1]); }
        }
        for (int i = 0; i <= size; i++)
        {
            System.Console.Write($"{i * dr} ");
            System.Console.Write($"{SE10(i * dr)} ");
            System.Console.Write($"{SE20(i * dr)}");
            System.Console.WriteLine();
        }

    }
}