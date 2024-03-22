using static System.Math;
public static class WavefunctionData
{
    public static void Main(string[] args)
    {
        int rmax = 10;
        double dr = 0.3;
        foreach (var arg in args)
        {
            var words = arg.Split(':');
            if (words[0] == "-rmax") { rmax = int.Parse(words[1]); }
            if (words[0] == "-dr") { dr = double.Parse(words[1]); }
        }
        var (w, V) = Hydrogen.Hamiltonian(rmax, dr);
        for (int j = 0; j < V.size2; j++)
        {
            System.Console.Write("0 ");
        }
        System.Console.WriteLine();
        for (int i = 0; i < V.size1; i++)
        {
            System.Console.Write((i + 1) * dr);
            for (int j = 0; j < V.size2; j++)
            {
                System.Console.Write(" ");
                System.Console.Write((1 / Sqrt(dr)) * V[i, j]);
            }
            System.Console.WriteLine();
        }
        System.Console.Write($"{rmax} ");
        for (int j = 0; j < V.size2; j++)
        {
            System.Console.Write("0 ");
        }
        System.Console.WriteLine();
    }

}