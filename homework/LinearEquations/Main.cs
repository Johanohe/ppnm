using static System.Console;
public class Test
{
    public static void DecompTest(int n = 6, int m = 4)
    {
        WriteLine("\n----------------------------");
        WriteLine("Testing the decomp function");
        WriteLine("----------------------------\n");
        matrix A = matrix.RandomMatrix(n, m);
        WriteLine("Random matrix A:");
        A.print();
        WriteLine();
        var tuple = QRGS.Decomp(A);
        matrix R = tuple.Item2;
        matrix Q = tuple.Item1;
        WriteLine("R from random matrix:");
        R.print();
        WriteLine();
        WriteLine($"Determinant of R and A = {QRGS.Det(R)}");
        matrix QQ = Q.transpose() * Q;
        matrix id = matrix.id(m);
        WriteLine();
        WriteLine("Identity:");
        id.print();
        WriteLine();
        WriteLine("QT times Q:");
        QQ.print();
        WriteLine();
        if (QQ.approx(id)) { WriteLine("TEST: QT*Q is approx equal to I"); }
        else { WriteLine("TEST: QT*Q is not equal to I"); }
        WriteLine();
        matrix QR = Q * R;
        WriteLine("Q * R");
        QR.print();
        WriteLine();
        if (QR.approx(A)) { WriteLine("TEST: QR is approx equal to A"); }
        else { WriteLine("TEST: QR is not apprix equal to A"); }
    }
    public static void SolveTest(int n = 6, int m = 6)
    {
        WriteLine("\n----------------------------");
        WriteLine("Testing the solve function");
        WriteLine("----------------------------\n");
        matrix A = matrix.RandomMatrix(n, m);
        WriteLine("Random matrix A");
        A.print();
        WriteLine();
        var tuple = QRGS.Decomp(A);
        matrix R = tuple.Item2;
        matrix Q = tuple.Item1;
        vector B = matrix.RandomMatrix(n)[0];
        WriteLine("B:");
        B.print();
        WriteLine();
        vector X = QRGS.Solve(Q, R, B);
        WriteLine("X:");
        X.print();
        WriteLine();
        vector AX = A * X;
        WriteLine("A * X:");
        AX.print();
        WriteLine();
        if (AX.approx(B)) { WriteLine("A * X is approx equal to B"); }
        else { WriteLine("A * X is not approx equal B"); }

    }
    public static void InvTest()
    {
        WriteLine("\n----------------------------");
        WriteLine("Testing the inverse function");
        WriteLine("----------------------------\n");
        matrix a = matrix.RandomMatrix(6, 6);
        matrix invA = QRGS.Inverse(QRGS.Decomp(a));
        WriteLine("Random matrix A:");
        a.print();
        WriteLine();
        WriteLine("The inverse of A:");
        invA.print();
        WriteLine();
        WriteLine("A * A^(-1):");
        matrix ainvA = a * invA;
        ainvA.print();


    }
}

public class main
{
    public static int Main()
    {
        Test.DecompTest();
        Test.SolveTest();
        Test.InvTest();
        return 0;

    }
}