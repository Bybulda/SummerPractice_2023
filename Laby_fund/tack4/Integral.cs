using System.Diagnostics;

namespace Laby_fund.tack4;



public class Left : ISolvation
{
    public double Solve(Func<double, double> func, double a, double b, int n)
    {
        Stopwatch watch = Stopwatch.StartNew();
        var h = (b - a) / n;
        double res = 0;
        for(var i = 0; i <= n-1; i++)
        {
            var x = a + i * h;
            res += func(a + i * h);
        }

        Iterations = n;
        var result = h * res;
        watch.Stop();
        Elapsed = watch.Elapsed;
        return result;
    }

    public string GetSolvationType
    {
        get => "Left";
    }
    
    public int Iterations
    {
        get;
        set;
    }
    
    public TimeSpan Elapsed
    {
        get;
        private set;
    }
}

public class Right : ISolvation
{
    public double Solve(Func<double, double> func, double a, double b, int n)
    {
        Stopwatch watch = Stopwatch.StartNew();
        var h = (b - a) / n;
        double res = 0;
        for(var i = 1; i <= n; i++)
        {
            var x = a + i * h;
            res += func(a + i * h);
        }

        Iterations = n;
        var result = h * res;
        watch.Stop();
        Elapsed = watch.Elapsed;
        return result;
    }

    public string GetSolvationType
    {
        get => "Right";
    }
    
    public int Iterations
    {
        get;
        set;
    }
    
    public TimeSpan Elapsed
    {
        get;
        private set;
    }
}

public class Trycep : ISolvation
{
    public double Solve(Func<double, double> func, double a, double b, int n)
    {
        var watch = Stopwatch.StartNew();
        var h = (b - a) / n;
        var fa = func(a);
        var fb = func(b);
        var res = h * ((fa + fb) / 2);
        int i = 0;
        for (double x = a + h; x <= b - h; x += h)
        {
            Iterations = i++;
            res += func(x);
            
        }
        watch.Stop();
        Elapsed = watch.Elapsed;
        return res;
    }

    public string GetSolvationType
    {
        get => "Trycep";
    }
    
    public int Iterations
    {
        get;
        set;
    }
    
    public TimeSpan Elapsed
    {
        get;
        private set;
    }
}

public class Simpson : ISolvation
{
    public double Solve(Func<double, double> func, double a, double b, int n)
    {
        var watch = Stopwatch.StartNew();
        var h = (b - a) / n;
        var fa = func(a);
        var fb = func(b);
        var result0 = fa + fb;
        double result1 = 0;
        double result2 = 0;

        for (double x = a + h, i = 1; Math.Round(x, 6) <= b - h; x += h, i++)
        {
            Iterations = (int) i;
            if (i % 2 == 0)
            {
                result1 += func(x);
            }
            else
            {
                result2 += func(x);
            } 
        }
        watch.Stop();
        Elapsed = watch.Elapsed;
        return (h / 3) * (result0 + result1 * 2 + result2 * 4);
    }

    public string GetSolvationType
    {
        get => "Simpson";
    }
    
    public int Iterations
    {
        get;
        set;
    }
    
    public TimeSpan Elapsed
    {
        get;
        private set;
    }
}