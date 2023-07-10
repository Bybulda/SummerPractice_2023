namespace Laby_fund.task2;

public class ComparerE<T>: IEqualityComparer<T>
{
    private static ComparerE<T>? _instance;
    
    private ComparerE() {}

    public static ComparerE<T> Instance => _instance ??= new ComparerE<T>();

    public bool Equals(T? x, T? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (ReferenceEquals(x, null)) return false;
        if (ReferenceEquals(y, null)) return false;
        if (x.GetType() != y.GetType()) return false; 
        return x.Equals(y);
    }

    public int GetHashCode(T obj)
    {
        return obj.GetHashCode();
    }
}