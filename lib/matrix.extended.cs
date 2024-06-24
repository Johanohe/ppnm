
using static System.Math;
public partial class matrix
{
    public static matrix RandomMatrix(int n = 3, int m = 3, double min = -1, double max = 1)
    {
        var rnd = new System.Random();
        matrix mat = new matrix(n, m);
        for (int i = 0; i < m; i++)
        {
            for (int x = 0; x < n; x++)
            {
                mat[i][x] = rnd.NextDouble() * (max - min) + min;
            }

        }
        return mat;
    }
    public static matrix RandomSymMatrix(int n = 3, double min = -1, double max = 1)
    {
        matrix mat = RandomMatrix(n, n, min, max);
        return mat + mat.T;
    }
    public void PrettyPrint(string s = "", string format = "{0,10:g3} ", double acc = 1e-6)
    {
        System.Console.WriteLine();
        System.Console.WriteLine(s);
        System.Console.WriteLine($"(0 when Abs(element) < {acc})");
        for (int ir = 0; ir < this.size1; ir++)
        {
            for (int ic = 0; ic < this.size2; ic++)
            {
                if (Abs(this[ir, ic]) < acc) { System.Console.Write(format, 0); }
                else { System.Console.Write(format, this[ir, ic]); }
            }
            System.Console.WriteLine();
        }
        System.Console.WriteLine();
    }
}
