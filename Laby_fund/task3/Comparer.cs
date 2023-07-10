namespace Laby_fund.task3;

public class ComparerT<T>: IComparer<T>
{
    private static ComparerT<T>? _comparer;

    public static ComparerT<T> ComparerInstance => 
        _comparer ??= new ComparerT<T>();

    public int Compare(T? x, T? y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (ReferenceEquals(null, y)) return 1;
        if (ReferenceEquals(null, x)) return -1;
        return Comparer<T>.Default.Compare(x, y);

        
    }
}