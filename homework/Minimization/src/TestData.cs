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

    public static vector RosenbrockGrad(vector v)
    {
        double x = v[0];
        double y = v[1];
        double dfx = -2 * (1 - x) - 400 * x * (y - x * x);
        double dfy = 200 * (y - x * x);
        vector dfxy = new vector(dfx, dfy);
        return dfxy;
    }
    public static vector HimmelblauGrad(vector v)
    {
        double x = v[0];
        double y = v[1];
        double dfx = 4 * x * (x * x + y - 11) + 2 * (x + y * y - 7);
        double dfy = 2 * (x * x + y - 11) + 4 * y * (x + y * y - 7);
        vector dfxy = new vector(dfx, dfy);
        return dfxy;
    }

    private static double test(vector v)
    {
        double x = v[0];
        double y = v[1];
        return (x - 3) * (x - 3) + 5 * (y + 4) * (y + 4);
    }

    public static void Main()
    {
        Func<vector, double> rosenbrock = Rosenbrock;
        Func<vector, double> himmelblau = Himmelblau;
        vector rosenStart = new vector(1, 2);
        vector himmelStart = new vector(0.5, 0.5);

        (vector rosenAns, int rosenSteps) = Minimize.DownhillSimplex(rosenbrock, rosenStart, 1e-5);
        (vector himmelAns, int himmelSteps) = Minimize.DownhillSimplex(himmelblau, himmelStart, 1e-5);
        Console.WriteLine($"Rosenbrock minima using downhill simplex starting from ({rosenStart[0]},{rosenStart[1]}): x = {rosenAns[0]}, y = {rosenAns[1]}.\nUsing {rosenSteps} steps, function value {Rosenbrock(rosenAns)}\n");
        (rosenAns, rosenSteps) = Minimize.Newton(rosenbrock, rosenStart);
        Console.WriteLine($"Rosenbrock minima using Newton starting from ({rosenStart[0]},{rosenStart[1]}): x = {rosenAns[0]}, y = {rosenAns[1]}.\nUsing {rosenSteps} steps,function value {Rosenbrock(rosenAns)}\n");
        Console.WriteLine($"Himmmelblau minima using downhill simplex starting from ({himmelStart[0]},{himmelStart[1]}): x = {himmelAns[0]}, y = {himmelAns[1]}.\nUsing {himmelSteps} steps, function value {Himmelblau(himmelAns)}\n");
        (himmelAns, himmelSteps) = Minimize.Newton(himmelblau, rosenStart);
        Console.WriteLine($"Himmelblau minima using Newton starting from ({himmelStart[0]},{himmelStart[1]}): x = {himmelAns[0]}, y = {himmelAns[1]}.\nUsing {himmelSteps} steps, function value {Himmelblau(himmelAns)}\n");

    }
}
