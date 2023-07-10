using Laby_fund.task2;

namespace Laby_fund.task3;

public class EntryPointSorts
{

    public static void jain()
    {
        int[] a = new int[] { 2, 1, 3, 7, 4, 9, 5, 6, 10, 0, 8};
        var cp = new Comparison<int>((t1, t2) => t1.CompareTo(t2));
        foreach (var VARIABLE in a.Sort(Rule.Descending, Sorts.Choice, cp))
        {
            Console.WriteLine(VARIABLE);
        }
        
    }
}