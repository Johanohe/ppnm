
public static class HydrogenData
{
    public static void Main(string[] args)
    {
        int rmax = 10;
        double dr = 0.3;
        bool Dodr = false;
        bool Dorm = false;
        foreach (var arg in args)
        {
            var words = arg.Split(':');
            if (words[0] == "-rmax") { rmax = int.Parse(words[1]); if (rmax == 0) Dorm = true; }
            if (words[0] == "-dr") { dr = double.Parse(words[1]); if (dr == 0) Dodr = true; }
        }
        if (Dorm && Dodr)
        {
            System.Console.WriteLine($"{rmax} {dr} {Hydrogen.MinEnergy(rmax, dr)}");
        }
        else if (Dodr)
        {
            for (double i = 0.02; i < 1; i += 0.02)
            {
                System.Console.WriteLine($"{i} {Hydrogen.MinEnergy(rmax, i)}");
            }
        }
        else if (Dorm)
        {
            for (int i = 1; i < 25; i += 1)
            {
                System.Console.WriteLine($"{i} {Hydrogen.MinEnergy(i, dr)}");
            }
        }

    }
}