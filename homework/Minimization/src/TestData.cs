using System;
public static class TestData
{
    private static double Rosenbrock(vector v)
    {
        double x = v[0];
        double y = v[1];
        return (1 - x) * (1 - x) + 100 * (y - x * x) * (y - x * x);
    }
    private static double Himmelblau(vector v)
    {
        double x = v[0];
        double y = v[1];
        return (x * x + y - 11) * (x * x + y - 11) + (x + y * y - 7) * (x + y * y - 7);
    }
    public static void Main()
    {
        Func<vector, double> rosenbrock = Rosenbrock;
        Func<vector, double> himmelblau = Himmelblau;
        vector rosenStart = new vector(1, 2);
        vector himmelStart = new vector(0.5, 0.5);
        (vector rosenAns, int rosenSteps) = Minimize.Newton(rosenbrock, rosenStart);
        (vector himmelAns, int himmelSteps) = Minimize.Newton(himmelblau, himmelStart);
        Console.WriteLine($"Rosenbrock minima starting from ({rosenStart[0]},{rosenStart[1]}): x = {rosenAns[0]}, y = {rosenAns[1]} , using {rosenSteps} steps");
        Console.WriteLine($"Himmelblau minima starting from ({himmelStart[0]},{himmelStart[1]}): x = {himmelAns[0]}, y = {himmelAns[1]}, using {himmelSteps} steps");
    }
}