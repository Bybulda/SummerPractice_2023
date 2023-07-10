using System.Diagnostics;

namespace Laby_fund.tack4;

public class EntrySolvation
{
    private static void pprint(int iterations, TimeSpan ts, string methodName, double solvation)
    {
        Console.WriteLine($"Method {methodName} solved the equation with {iterations} and time elapsed {ts.Nanoseconds}" +
                          $" with result {solvation}");
    }
    
    public static void lain()
    {
        Stopwatch stopwatch = new Stopwatch();
        var left = new Left();
        var right = new Right();
        var simpson = new Simpson();
        var tryc = new Trycep();
        double solvation;
        var func = new Func<double, double>(x => x*x + x*3);
        solvation = left.Solve(func, 1, 1000, 5000);
        pprint(left.Iterations, left.Elapsed, left.GetSolvationType, solvation);
        solvation = right.Solve(func, 1, 1000, 5000);
        pprint(right.Iterations, right.Elapsed, right.GetSolvationType, solvation);
        solvation = simpson.Solve(func, 1, 1000, 5000);
        pprint(simpson.Iterations, simpson.Elapsed, simpson.GetSolvationType, solvation);
        solvation = tryc.Solve(func, 1, 1000, 5000);
        pprint(tryc.Iterations, tryc.Elapsed, tryc.GetSolvationType, solvation);

    }
}