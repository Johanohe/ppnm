public static class LeastSquares
{
    public static (vector, matrix) LsFit(System.Func<double, double>[] fs, vector x, vector y, vector dy)
    {
        int n = x.size, m = fs.Length;
        var A = new matrix(n, m);
        var b = new vector(n);
        for (int i = 0; i < n; i++)
        {
            b[i] = y[i] / dy[i];
            for (int k = 0; k < m; k++) A[i, k] = fs[k](x[i]) / dy[i];
        }
        vector c = QRGS.Solve(A, b); // solves | |A∗c−b||−>min
        matrix AI = QRGS.Inverse(QRGS.Decomp(A)); // calculates pseudoinverse
        matrix sig = AI * AI.T;
        return (c, sig);
    }
}