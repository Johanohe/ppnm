using static System.Math;
public static class main
{
    public static void Test()
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
        for (double i = 0.5; i <= 16; i += 0.05)
        {
            System.Console.Write($"{i} {Exp(c[0]) * Exp(-c[1] * i)} ");
            System.Console.Write($"{Exp(c[0] - dc[0]) * Exp(-(c[1] - dc[1]) * i)} ");
            System.Console.Write($"{Exp(c[0] + dc[0]) * Exp(-(c[1] + dc[1]) * i)}\n");
        }
    }
    public static void Main()
    {
        Test();
    }
}