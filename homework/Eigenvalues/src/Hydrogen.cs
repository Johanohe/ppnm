public static class Hydrogen
{
    public static (vector w, matrix V) Hamiltonian(int rmax, double dr)
    {
        int npoints = (int)(rmax / dr) - 1;
        vector r = new vector(npoints);
        for (int i = 0; i < npoints; i++) r[i] = dr * (i + 1);
        matrix H = new matrix(npoints, npoints);
        for (int i = 0; i < npoints - 1; i++)
        {
            H[i, i] = -2 * (-0.5 / dr / dr);
            H[i, i + 1] = 1 * (-0.5 / dr / dr);
            H[i + 1, i] = 1 * (-0.5 / dr / dr);
        }
        H[npoints - 1, npoints - 1] = -2 * (-0.5 / dr / dr);
        for (int i = 0; i < npoints; i++) H[i, i] += -1 / r[i];
        (vector w, matrix V) = Jacobi.Cyclic(H);
        return (w, V);
    }

    public static double MinEnergy(int rmax, double dr)
    {
        (vector w, matrix V) = Hamiltonian(rmax, dr);
        double min = w[0];
        for (int i = 1; i < w.size; i++)
        {
            if (w[i] < min)
            {
                min = w[i];
            }
        }
        return min;
    }
}