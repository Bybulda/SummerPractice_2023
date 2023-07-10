namespace Laby_fund.task2;


public class Entry
{
    static void hain()
    {
        var arr = new int[] { 1, 2, 3 };
        var cp = ComparerE<int>.Instance;
        foreach (var VARIABLE in arr.GetPermutations(cp))
        {
            foreach (var VARIABLE2 in VARIABLE)
            {
                Console.Write($"{VARIABLE2} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        foreach (var VARIABLE in arr.Subsets(cp))
        {
            var res = VARIABLE;
            foreach (var VAR in res)
            {
                Console.Write($"{VAR} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        foreach (var VARIABLE in arr.Combination(3, 2, cp))
        {
            var res = VARIABLE;
            foreach (var VAR in res)
            {
                Console.Write($"{VAR} ");
            }
            Console.WriteLine();
        }
    }
}