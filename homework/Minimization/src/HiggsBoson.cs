using System.Collections.Generic;
using static System.Math;
using System;

public static class HiggsData
{
    public static List<double> energy;
    public static List<double> signal;
    public static List<double> error;
    public static char[] separators;
}


public static class HiggsBoson
{

    public static void Main()
    {
        HiggsData.energy = new List<double>();
        HiggsData.signal = new List<double>();
        HiggsData.error = new List<double>();
        HiggsData.separators = new char[] { ' ', '\t' };
        var options = StringSplitOptions.RemoveEmptyEntries;
        do
        {
            string line = Console.In.ReadLine();
            if (line == null) break;
            string[] words = line.Split(HiggsData.separators, options);
            HiggsData.energy.Add(double.Parse(words[0]));
            HiggsData.signal.Add(double.Parse(words[1]));
            HiggsData.error.Add(double.Parse(words[2]));
        } while (true);

        vector x = new vector(0.001, 1.0, 1.0);

        (vector weights, int stepCount) = Minimize.DownhillSimplex(DeviationFunction, x);
        for (int i = 0; i < HiggsData.energy.Count; i++)
        {
            System.Console.WriteLine($"{HiggsData.energy[i]} {BreitWigner(HiggsData.energy[i], weights[0], weights[1], weights[2])}");

        }

    }

    public static double DeviationFunction(vector x)
    {
        double sum = 0;
        for (int i = 0; i < HiggsData.energy.Count; i++)
        {
            sum += Pow((((x[0] / (Pow((HiggsData.energy)[i] - x[1], 2) + Pow(x[2], 2) / 4.0)) - (HiggsData.signal)[i]) / (HiggsData.error)[i]), 2);
        }
        return sum;
    }

    public static double BreitWigner(double E, double A, double m, double gamma)
    {
        return A / (Pow(E - m, 2) + Pow(gamma, 2) / 4.0);
    }

}
