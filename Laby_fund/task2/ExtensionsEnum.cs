using System.Reflection.Metadata.Ecma335;

namespace Laby_fund.task2;


public static class ExtensionsEnum
{
    public static IEnumerable<IEnumerable<T>> Combination<T>(this IEnumerable<T> obj, int n, int k, IEqualityComparer<T> comparer)
    {
        try
        {
            CopyCheck(obj.ToArray(), comparer);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e);
            throw new ArgumentException(nameof(obj));
        }
        var arr = new int[k];
        var realRes = new T[k];
        var tmp = obj.ToArray();
        FillIn(ref realRes, tmp, null, k);
        yield return realRes;
        var res = nextCombination(ref arr, n, k);
        while (res is not null)
        {
            FillIn(ref realRes, tmp, arr, k);
            yield return realRes;
            res = nextCombination(ref arr, n, k);
        }
    }
    
    public static IEnumerable<IEnumerable<T>> Subsets<T>(this IEnumerable<T> obj,  IEqualityComparer<T> comparer)
    {
        try
        {
            CopyCheck(obj.ToArray(), comparer);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e);
            throw new ArgumentException(nameof(obj));
        }
        var data = obj.ToArray();
        var tmp = Enumerable
            .Range(0, 1 << (data.Length))
            .Select(index => data
                .Where((v, i) => (index & (1 << i)) != 0)
                .ToArray());
        foreach (var VARIABLE in tmp)
        {
            yield return VARIABLE;
        }
    }

    public static IEnumerable<IEnumerable<T>> GetPermutations<T>(this IEnumerable<T> obj, IEqualityComparer<T> comparer)
    {
        try
        {
            CopyCheck(obj.ToArray(), comparer);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e);
            throw new ArgumentException(nameof(obj));
        }

        return Permutation(obj, obj.Count());
    }

    private static IEnumerable<IEnumerable<T>> Permutation<T>(this IEnumerable<T> obj, int n)
    {
        if (n == 1) return obj.Select(t => new T[] { t });

        return Permutation(obj, n - 1).SelectMany(t => obj.Where(e => !t.Contains(e)), 
            (t1, t2) => t1.Concat(new T[] {t2}));
    }

    private static int[]? nextCombination(ref int[] combs, int n, int k)
    {
        int i = k - 1;
        for (; i > -1 && combs[i] >= n - 1; i--)
        {
        }

        if (i == -1)
        {
            return null;
        }

        combs[i] += 1;
        for (int j = i + 1; j < k; j++)
        {
            combs[j] = combs[i];
        }

        return combs;
    }

    private static void FillIn<T>(ref T[] arr, T[] t, int[]? sequence, int k)
    {
        for (int i = 0; i < k; i++)
        {
            arr[i] = t[sequence?[i] ?? 0];
        }
    }

    private static void CopyCheck<T>(T[] arr, IEqualityComparer<T> comparer)
    {
        if (arr.Distinct(comparer).Count() != arr.Length) throw new ArgumentException();
    }
}