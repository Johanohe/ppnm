using static System.Math;

public static class Hessenberg
{
    public static (matrix, matrix) HessenbergFactorization(matrix M)
    {
        matrix A = M.copy();
        int n = M.size1;
        matrix V = matrix.id(n);
        for (int p = 1; p < n - 1; p++)
        {
            for (int q = p + 1; q < n; q++)
            {
                double apq = A[p - 1, q], app = A[p - 1, p];
                double theta = Atan2(-apq, app);
                Jacobi.TimesJ(A, p, q, theta); // A←A*J 
                Jacobi.JTimes(A, p, q, -theta); // A←JT*A 
                Jacobi.TimesJ(V, p, q, theta); // V←V*J
            }
        }
        return (A, V);
    }
}