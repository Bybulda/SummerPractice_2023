using System.Collections;
using Laby_fund.task3;

namespace Laby_fund.task5;

public class LinkedList<T>: IEquatable<LinkedList<T>>, ICloneable, IEnumerable<T>
{
    #region nested

    private class LinkedListNode<T>
    {
        private T? data;
        private LinkedListNode<T>? next;
    }

    #endregion

    private LinkedListNode<T>? root;
    public LinkedList()
    {
        root = new LinkedListNode<T>();
    }

    public void PushBack(T data)
    {
        
    }

    public void PushFront(T data)
    {
        
    }

    public void Insert(T data, int index)
    {
        
    }

    public T? PopBack()
    {
        throw new NotImplementedException();
    }

    public T? PopFront()
    {
        throw new NotImplementedException();
    }

    public T? Delete(int index)
    {
        throw new NotImplementedException();
    }

    public LinkedList<T> Reverse()
    {
        throw new NotImplementedException();
    }

    public static LinkedList<T> operator !(LinkedList<T> obj)
    {
        return obj.Reverse();
    }

    public static LinkedList<T> Concat(LinkedList<T> obj, LinkedList<T> obj2)
    {
        throw new NotImplementedException();
    }

    public static LinkedList<T> operator +(LinkedList<T> obj, LinkedList<T> obj2)
    {
        return Concat(obj, obj2);
    }

    public static LinkedList<T> Intersection(LinkedList<T> obj, LinkedList<T> obj2, IEqualityComparer<T> comparer)
    {
        throw new NotImplementedException();
    }
    
    public static LinkedList<T> operator &(LinkedList<T> obj, LinkedList<T> obj2)
    {
        return Intersection(obj, obj2, EqualityComparer<T>.Default);
    }
    
    public static LinkedList<T> CombineWithoutReps(LinkedList<T> obj, LinkedList<T> obj2, IEqualityComparer<T> comp)
    {
        throw new NotImplementedException();
    }
    
    public static LinkedList<T> operator |(LinkedList<T> obj, LinkedList<T> obj2)
    {
        return CombineWithoutReps(obj, obj2, EqualityComparer<T>.Default);
    }

    public static LinkedList<T> DeleteReps(LinkedList<T> obj, LinkedList<T> obj2, IEqualityComparer<T> comp)
    {
        throw new NotImplementedException();
    }
    
    public static LinkedList<T> operator -(LinkedList<T> obj, LinkedList<T> obj2)
    {
        return DeleteReps(obj, obj2, EqualityComparer<T>.Default);
    }

    public void ApplyTo(Action<T> act)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(LinkedList<T> obj, LinkedList<T> obj2)
    {
        return false;
    }

    public static bool operator !=(LinkedList<T> obj, LinkedList<T> obj2)
    {
        return true;
    }

    public LinkedList<T>? Sort(IComparer<T> comparer)
    {
        var c = this.ToArray();
        c.Sort(Rule.Ascending, Sorts.Choice, comparer);
        return c as LinkedList<T>;
    }
    
    public LinkedList<T>? Sort(Comparer<T> comparer)
    {
        var c = this.ToArray();
        c.Sort(Rule.Ascending, Sorts.Choice, comparer);
        return c as LinkedList<T>;
    }
    
    public LinkedList<T>? Sort(Comparison<T> comparer)
    {
        var c = this.ToArray();
        c.Sort(Rule.Ascending, Sorts.Choice, comparer);
        return c as LinkedList<T>;
    }

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public bool Equals(LinkedList<T>? other)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return base.ToString();
    }

    public object Clone()
    {
        throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}