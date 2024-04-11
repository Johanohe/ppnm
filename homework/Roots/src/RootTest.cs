using System;
public static class RootTest
{
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
    public static void Main()
    {
        Func<vector, vector> rosenbrock = RosenbrockGrad;
        Func<vector, vector> himmelblau = HimmelblauGrad;
        vector rosenStart = new vector(1, 2);
        vector himmelStart = new vector(0.5, 0.5);
        vector rosenAns = Root.Newton(rosenbrock, rosenStart);
        vector himmelAns = Root.Newton(himmelblau, himmelStart);
        Console.WriteLine($"Rosenbrock minima starting from ({rosenStart[0]},{rosenStart[1]}): x = {rosenAns[0]}, y = {rosenAns[1]}");
        Console.WriteLine($"Himmelblau minima starting from ({himmelStart[0]},{himmelStart[1]}): x = {himmelAns[0]}, y = {himmelAns[1]}");

    }
}