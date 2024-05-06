using static System.Math;
public static class ANNTest
{
    public static void Main()
    {
        ANN ann = new ANN(12);
        int n = 1000;
        vector x = new vector(n);
        vector y = new vector(n);
        double tempx = 0;
        for (int i = -n / 2; i < n / 2; i += 1)
        {
            tempx = i * 2.0 / n;
            x[i + n / 2] = tempx;
            y[i + n / 2] = Cos(5 * tempx - 1) * Exp(-tempx * tempx);
        }
        ann.Train(x, y);
        for (double j = -1.2; j <= 1.2; j += 0.05)
        {
            System.Console.WriteLine($"{j} {ann.Response(j)} {Cos(5 * j - 1) * Exp(-j * j)}");
        }
    }
}