namespace Laby_fund.tack4;

public interface ISolvation
{
        public double Solve(Func<double, double> func, double a, double b, int n);
        
        public string GetSolvationType { get; }

        protected int Iterations
        {
            get;
            set;
        }

        public TimeSpan Elapsed
        {
            get;
        }
}