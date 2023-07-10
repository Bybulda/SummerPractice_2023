using System.Collections;
using System.Data;
using System.Drawing;
using System.Text;
using Laby_fund.task3;
using Rule = Laby_fund.task3.Rule;

namespace Laby_fund.task5;

public class LinkedList<T>: IEquatable<LinkedList<T>>, ICloneable, IEnumerable<T>
{
    #region nested

    private class LinkedListNode<T>
    {
        public LinkedListNode()
        {
            
        }
        private LinkedListNode<T>? _next;
        private T? _data;
        public T? DataField
        {
            get => _data;
            set => _data = value;
        }

        public LinkedListNode<T>? NextNode
        {
            get => _next;
            set => _next = value;
        }
        
    }

    #endregion

    private LinkedListNode<T>? root;


    public int Lenght
    {
        get;
        private set;
    }
    
    public LinkedList()
    {
        root = new LinkedListNode<T>();
        Lenght = 0;
    }
    
    public LinkedList(IEnumerable<T> obj)
    {
        root = new LinkedListNode<T>();
        Lenght = 0;
        foreach (var variable in obj)
        {
            PushBack(variable);
        }
    }

    public LinkedList(LinkedList<T> obj)
    {
        root = new LinkedListNode<T>();
        Lenght = 0;
        foreach (var variable in obj)
        {
            PushBack(variable);
        }
    }

    public void PushBack(T data)
    {
        Insert(data, Lenght); 
    }

    public void PushFront(T data)
    {
        Insert(data, 0);
    }
    

    private LinkedListNode<T>? At(int index)
    {
        if (index < 0 || index > Lenght - 1)
        {
            throw new IndexOutOfRangeException();
        }

        if (root is null)
        {
            throw new IndexOutOfRangeException();
        }

        LinkedListNode<T>? current = root;
        for (int i = 0; i < index; i++)
        {
            current = current.NextNode;
        }

        return current;
    }

    public T? this[int index]
    {
        get => At(index).DataField;
        set => At(index).DataField = value;
    }

    public void Insert(T data, int index)
    {
        if (index < 0 || index > Lenght) throw new IndexOutOfRangeException();
        

        else if (Lenght == 0)
        {
            root.DataField = data;
            root.NextNode = null;
        }

        
        
        else
        {
            var newRoot = new LinkedListNode<T>();
            newRoot.DataField = data;
            if (index == 0 && Lenght != 0)
            {
                newRoot.NextNode = root;
                root = newRoot;
            }
            else if (index == Lenght) At(Lenght - 1).NextNode = newRoot;
            else
            {
                var pred = At(index - 1);
                var next = At(index + 1);
                pred.NextNode = newRoot;
                newRoot.NextNode = next; 
            }
            
        }

        Lenght++;
    }

    public T? PopBack()
    {
        return Delete(Lenght - 1);
    }

    public T? PopFront()
    {
        return Delete(0);
    }

    public T? Delete(int index)
    {
        if (index < 0 || index >= Lenght) throw new IndexOutOfRangeException();
        var result = default(T);
        if (index == 0)
        {
            result = root.DataField;
            root = root.NextNode;
        }

        else if (index == Lenght - 1)
        {
            var node = At(index - 1);
            result = node.DataField;
            node.NextNode = null;
        }

        else
        {
            var pred = At(index - 1);
            var curr = pred.NextNode;
            var next = curr.NextNode;
            
            pred.NextNode = next;
            result = curr.DataField;
        }
        Lenght--;
        return result;
    }
    

    public LinkedList<T> Reverse()
    {
        LinkedList<T>? reversed = new LinkedList<T>();
        foreach (var variable in this)
        {
            reversed.PushFront(variable);
        }

        return reversed;

    }

    public static LinkedList<T> operator !(LinkedList<T> obj)
    {
        return obj.Reverse();
    }

    public static LinkedList<T> Concat(LinkedList<T> obj, LinkedList<T> obj2)
    {

        var list1 = obj.Clone() as LinkedList<T>;
        var list2 = obj2.Clone() as LinkedList<T>;
        list1.At(list1.Lenght - 1).NextNode = list2.root;
        list1.Lenght += list2.Lenght;
        return list1;
    }

    public static LinkedList<T> operator +(LinkedList<T> obj, LinkedList<T> obj2)
    {
        return Concat(obj, obj2);
    }

    public static LinkedList<T> Intersection(LinkedList<T> obj, LinkedList<T> obj2, IEqualityComparer<T> comparer)
    {
        return new LinkedList<T>(obj.Intersect(obj2, comparer));
    }
    
    public static LinkedList<T> operator &(LinkedList<T> obj, LinkedList<T> obj2)
    {
        return Intersection(obj, obj2, EqualityComparer<T>.Default);
    }
    
    public static LinkedList<T> CombineWithoutReps(LinkedList<T> obj, LinkedList<T> obj2, IEqualityComparer<T> comp)
    {
        return new LinkedList<T>(obj.Union(obj2, comp));
    }
    
    public static LinkedList<T> operator |(LinkedList<T> obj, LinkedList<T> obj2)
    {
        return CombineWithoutReps(obj, obj2, EqualityComparer<T>.Default);
    }

    public static LinkedList<T> DeleteReps(LinkedList<T> obj, LinkedList<T> obj2, IEqualityComparer<T> comp)
    {
        return new LinkedList<T>(obj.Except(obj2, comp));
    }
    
    public static LinkedList<T> operator -(LinkedList<T> obj, LinkedList<T> obj2)
    {
        return DeleteReps(obj, obj2, EqualityComparer<T>.Default);
    }

    public void ApplyTo(Action<T> act)
    {
        if (root == null)
        {
            throw new EvaluateException();
        }

        LinkedListNode<T>? current = root;
        do
        {
            act(current.DataField);
            current = current.NextNode;
        } while (current != null);
    }

    public static LinkedList<T> operator *(LinkedList<T> lst1, LinkedList<T> lst2)
    {
        if (lst1 is null || lst2 is null) throw new ArgumentException();
        var size = lst1.Lenght < lst2.Lenght ? lst1.Lenght : lst2.Lenght;
        var res = new LinkedList<T>();
        for (int i = 0; i < size; i++)
        {
            res.PushBack((dynamic?)lst1[i] * lst2[i]);
        }

        return res;
    }

    public static bool operator ==(LinkedList<T> obj, LinkedList<T> obj2)
    {
        return obj.Equals(obj2);
    }

    public static bool operator !=(LinkedList<T> obj, LinkedList<T> obj2)
    {
        return !(obj == obj2);
    }

    public LinkedList<T>? Sort(IComparer<T> comparer)
    {
        var c = this.ToArray();
        c.Sort(Rule.Ascending, Sorts.Choice, comparer);
        
        return new LinkedList<T>(c);
    }
    
    public LinkedList<T>? Sort(Comparer<T> comparer)
    {
        var c = this.ToArray();
        c.Sort(Rule.Ascending, Sorts.Choice, comparer);
        return new LinkedList<T>(c);
    }
    
    public LinkedList<T>? Sort(Comparison<T> comparer)
    {
        var c = this.ToArray();
        c.Sort(Rule.Ascending, Sorts.Choice, comparer);
        return new LinkedList<T>(c);
    }
    

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj is LinkedList<T> lst) return Equals(lst);
        return false;
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();
        foreach (var variable in this)
        {
            hash.Add(variable);
        }

        return hash.ToHashCode();
    }

    public bool Equals(LinkedList<T>? other)
    {
        if (ReferenceEquals(this, other)) return true;
        if (other is null) return false;
        if (other.Lenght != Lenght) return false;
        var curr = root;
        var otherCurr = other.root;
        for(int i = 0; i < Lenght; i++)
        {
            if (!curr.DataField.Equals(otherCurr.DataField))
            {
                return false;
            }

            curr = curr.NextNode;
            otherCurr = otherCurr.NextNode;
        }

        return true;
    }

    public override string ToString()
    {
        var builder = new StringBuilder("List has such elements in it: [ ");
        foreach (var variable in this)
        {
            builder.Append($"{variable} ");
        }

        builder.Append(']');
        return builder.ToString();
    }

    public object Clone()
    {
        return new LinkedList<T>(this);
    }

    public IEnumerator<T> GetEnumerator()
    {
        if (root == null)
        {
            throw new ArgumentNullException();
        }

        var current = root;
        do
        {
            yield return current.DataField;
            current = current.NextNode;
        } while (current is not null);
        
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}