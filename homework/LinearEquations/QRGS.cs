using static matrix;
using static vector;

public static class QRGS
{
    public static (matrix, matrix) Decomp(matrix A)
    {
        matrix Q = A.copy();
        int m = Q.size2;
        var R = new matrix(m, m);
        for (int i = 0; i < m; i++)
        {
            R[i, i] = Q[i].norm();
            Q[i] /= R[i, i];
            for (int j = i + 1; j < m; j++)
            {
                R[i, j] = Q[i].dot(Q[j]);
                Q[j] -= Q[i] * R[i, j];
            }
        }
        return (Q, R);

    }
    public static vector Solve(matrix Q, matrix R, vector B)
    {
        int n = R.size1 - 1;
        double sum = 0;
        vector X = new vector(n + 1);
        vector QTB = Q.transpose() * B;
        X[n] = QTB[n] / R[n, n];
        for (int i = n - 1; i >= 0; i--)
        {
            sum = 0;
            for (int j = i + 1; j <= n; j++)
            {
                sum += R[i, j] * X[j];
            }
            X[i] = (QTB[i] - sum) / R[i, i];
        }
        return X;
    }
    public static double Det(matrix R)
    {
        double det = R[0, 0];
        for (int i = 1; i < R.size1; i++)
        {
            det *= R[i, i];
        }
        return det;
    }
    public static matrix Inverse(matrix Q, matrix R)
    {
        int n = R.size1 - 1;
        double sum = 0;
        matrix invR = new matrix(n + 1, n + 1);
        matrix id = matrix.id(n + 1);
        vector X = new vector(n + 1);
        for (int k = 0; k <= n; k++)
        {
            vector B = id[k];
            X[n] = B[n] / R[n, n];
            for (int i = n - 1; i >= 0; i--)
            {
                sum = 0;
                for (int j = i + 1; j <= n; j++)
                {
                    sum += R[i, j] * X[j];
                }
                X[i] = (B[i] - sum) / R[i, i];
            }
            invR[k] = X.copy();
        }
        matrix invA = invR * Q.transpose();
        return invA;
    }
    public static matrix Inverse((matrix, matrix) tup)
    {
        var (Q, R) = tup;
        return Inverse(Q, R);
    }
}
