public static class HessenbergTime
{
    public static void Main(string[] args)
    {
        int matrixSize = 5;
        foreach (string arg in args)
        {
            var words = arg.Split(':');
            if (words[0] == "-matrixSize") matrixSize = (int)double.Parse(words[1]);
        }
        // Generating a random matrix
        matrix RandomMatrix = matrix.RandomMatrix(matrixSize, matrixSize, -100, 100);
        // Hessenberg factorization of random matrix
        (matrix H, matrix V) = Hessenberg.HessenbergFactorization(RandomMatrix);
    }
}