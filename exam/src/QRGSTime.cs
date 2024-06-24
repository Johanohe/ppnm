public static class QRGSTime
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
        // QRGS factorization of random matrix
        (matrix Q, matrix R) = QRGS.Decomp(RandomMatrix);
    }
}