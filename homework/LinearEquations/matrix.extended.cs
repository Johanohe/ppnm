
public partial class matrix
{
    public static matrix RandomMatrix(int n = 3, int m = 3)
    {
        var rnd = new System.Random();
        matrix mat = new matrix(n, m);
        for (int i = 0; i < m; i++)
        {
            for (int x = 0; x < n; x++)
            {
                mat[i][x] = rnd.NextDouble();
            }

        }
        return mat;
    }
}