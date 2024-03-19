using static System.Console;

public class main
{
    public static void Test()
    {

        matrix A = matrix.RandomSymMatrix(5);
        A.print("Random symmetric matrix A:");
        (vector w, matrix V) = Jacobi.Cyclic(A);
        matrix D = matrix.id(5);
        for (int i = 0; i < w.size; i++)
        {
            D[i, i] = w[i];
        }
        Write("Eigenvalues: ");
        for (int i = 0; i < w.size; i++)
        {
            Write($"{w[i]} ");
        }
        WriteLine();
        WriteLine();
        D.print("Matrix D:");
        matrix VAV = (V.T * A) * V;
        VAV.PrettyPrint("Matrix V^T*A*V:");
        matrix VDV = (V * D) * V.T;
        VDV.PrettyPrint("Matrix V*D*V^T:");
        matrix VTV = V.T * V;
        VTV.PrettyPrint("Matrix V^T*V:");
        matrix VVT = V * V.T;
        VVT.PrettyPrint("Matrix V*V^T:");

    }
    public static void Main()
    {
        Test();
    }
}