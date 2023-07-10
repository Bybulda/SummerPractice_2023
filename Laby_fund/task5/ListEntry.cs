namespace Laby_fund.task5;

public class ListEntry
{
    public static void Main()
    {
        var lst = new LinkedList<int>();
        lst.PushBack(1);
        lst.PushBack(2);
        lst.PushBack(3);
        lst.PushBack(4);
        lst.PushBack(5);
        lst.PushBack(6);
        lst.PushBack(7);
        var lst2 = new LinkedList<int>();
        lst2.PushBack(1);
        lst2.PushBack(2);
        var res = lst.Sort((x, y) => x.CompareTo(y));
        Console.WriteLine(res);
    }
}