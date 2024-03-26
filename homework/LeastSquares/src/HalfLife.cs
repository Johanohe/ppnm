using static System.Math;
public static class HalfLife
{
    public static void Main()
    {
        vector t = new vector("1,2,3,4,6,9,10,13,15");
        vector y = new vector("117,100,88,72,53,29.5,25.2,15.2,11.1");
        vector dy = new vector("6,5,4,4,4,3,3,2,2");
        for (int i = 0; i < dy.size; i++)
        {
            dy[i] /= y[i];
            y[i] = Log(y[i]);
        }
        var fs = new System.Func<double, double>[] { x => 1.0, x => -x };
        (vector c, matrix sig) = LeastSquares.LsFit(fs, t, y, dy);
        double[] dc = new double[2] { Sqrt(sig[0, 0]), Sqrt(sig[1, 1]) };
        System.Console.WriteLine($"Half-life: {Log(2) / c[1]} ± {(Log(2) / c[1]) - (Log(2) / (c[1] + dc[1]))} days");
        System.Console.WriteLine("Litterature value: 3.6 days");
    }
}