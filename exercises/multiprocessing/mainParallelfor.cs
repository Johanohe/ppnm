class main
{
    public static int Main(string[] args)
    {
        int nterms = (int)1e7, nthreads = 1;
        foreach (string arg in args)
        {
            var words = arg.Split(':');
            if (words[0] == "-nterms") nterms = (int)double.Parse(words[1]);
            if (words[0] == "-nthreads") nthreads = (int)double.Parse(words[1]);
        }
        System.Console.WriteLine($"Main: nterms={nterms}");
        double sum = 0;
        System.Threading.Tasks.Parallel.For(1, nterms + 1, (int i) => sum += 1.0 / i);
        System.Console.WriteLine($"Main: total sum = {sum}");

        return 0;
    }
}