class main
{
    public static int Main()
    {
        for (double x = 1.0 / 256; x <= 500; x += 1.0 / 256)
        {
            System.Console.WriteLine($"{x} {sfuns.lngamma(x)}");
        }
        return 0;
    }
}