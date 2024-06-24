class HessenbergTest
{
    public static void Main()
    {
        System.Console.WriteLine("------ Hessenberg Factorization of random matrix -------");
        matrix A = matrix.RandomMatrix(5, 5, -100, 100);
        A.print("Random matrix A:");
        (matrix H, matrix V) = Hessenberg.HessenbergFactorization(A);
        H.print("Lower Hessenberg matrix H:");
        V.print("Transformation matrix V:");
        matrix ShouldBeA = (V * H) * V.T;
        ShouldBeA.print("V*H*V^T: (should be A)");

        System.Console.WriteLine();
        System.Console.WriteLine("------ Hessenberg Factorization of random symmetric matrix -------");
        matrix B = matrix.RandomSymMatrix(5, -100, 100);
        B.print("Random symmetric matrix B:");
        (matrix W, matrix C) = Hessenberg.HessenbergFactorization(B);
        W.print("Lower Hessenberg matrix W:");
        C.print("Transformation matrix V:");
        matrix ShouldBeB = (C * W) * C.T;
        ShouldBeB.print("V*W*V^T: (should be B)");


        System.Console.WriteLine("------ Hessenberg Factorization of random 10x10 matrix -------");
        matrix D = matrix.RandomMatrix(10, 10, -100, 100);
        D.print("Random matrix D:");
        (matrix HD, matrix VD) = Hessenberg.HessenbergFactorization(D);
        HD.print("Lower Hessenberg matrix H:");
        VD.print("Transformation matrix V:");
        matrix ShouldBeD = (VD * HD) * VD.T;
        ShouldBeD.print("V*H*V^T: (should be D)");

    }

}