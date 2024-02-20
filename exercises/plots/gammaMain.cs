class main
{
    public static int Main()
    {
        for (double x = -5; x <= 5; x += 1.0 / 256)
        {
            System.Console.WriteLine($"{x} {sfuns.gamma(x)}");
        }
        return 0;
    }
}