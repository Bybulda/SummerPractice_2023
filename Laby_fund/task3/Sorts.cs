namespace Laby_fund.task3;

public enum Rule
{
    Ascending,
    Descending
}

public enum Sorts
{
    Insertion,
    Choice,
    Heap,
    Fast,
    Merge
}

public static class Sortings
{
    public static T[]? Sort<T>(this T[] obj, Rule r, Sorts type, IComparer<T> comp)
    {
        Func<T, T, bool> func = r == Rule.Ascending ? (t1, t2) => comp.Compare(t1, t2) <= 0 : (t1, t2) => comp.Compare(t1, t2) >= 0;
        return Handle(obj, type, func);
    }
    
    public static T[]? Sort<T>(this T[] obj, Rule r, Sorts type, Comparer<T> comp)
    {
        Func<T, T, bool> func = r == Rule.Ascending ? (t1, t2) => comp.Compare(t1, t2) <= 0 : (t1, t2) => comp.Compare(t1, t2) >= 0;
        return Handle(obj, type, func);
    }
    
    public static T[]? Sort<T>(this T[] obj, Rule r, Sorts type, Comparison<T> comp)
    {
        Func<T, T, bool> func = r == Rule.Ascending ? (t1, t2) => comp(t1, t2) <= 0 : (t1, t2) => comp(t1, t2) >= 0;
        return Handle(obj, type, func);
    }

    private static T[]? Handle<T>(T[] obj, Sorts type, Func<T, T, bool> func)
    {
        switch (type)
        { 
            case Sorts.Insertion: return Insertion(obj, func);
                
            case Sorts.Choice: return Choice(obj, func);
                
            case Sorts.Heap: return Pyromidal(obj, func);
                
            case Sorts.Fast: return Fast(obj, func);
                
            case Sorts.Merge: return Merge(obj, func);
                
        }

        return null;
    }

    private static T[] Insertion<T>(T[] obj, Func<T, T, bool> func)
    {
        for(int i=1; i < obj.Length; i++)
        {
            var k = obj[i];
            int j = i - 1;

            while(j>=0 && !func(obj[j], k))
            {
                obj[j + 1] = obj[j];
                j--;
            }
            obj[j + 1] = k;
        }
        return obj;
    }
    /*Region Choice*/
    private static T[] Choice<T>(T[] obj, Func<T, T, bool> func)
    {
        for (int i = obj.Length - 1; i >= 0; i--)
        {
            T max = obj[0];
            int pos = 0;
            for (int j = 0; j <= i; j++)
            {
                if (func(max, obj[j]))
                {
                    max = obj[j];
                    pos = j;
                }
            }
            
            Swap(ref obj[i], ref obj[pos]);
        }

        return obj;
    }
    /*Choice end*/
    
    /*Ptromidal region*/
    private static T[] Pyromidal<T>(T[] obj, Func<T, T, bool> func)
    {
        return HeapSort(obj, obj.Length, func);
    }
    private static void Heapify<T>(T[] arr, int n, int i, Func<T, T, bool> func)
    {
        int largest = i;
        int l = 2*i + 1; 
        int r = 2*i + 2; 
        
        if (l < n && func(arr[largest], arr[l]))
            largest = l;
        
        if (r < n && func(arr[largest], arr[r]))
            largest = r;
        
        if (largest != i)
        {
            Swap(ref arr[i], ref arr[largest]);
            Heapify(arr, n, largest, func);
        }
    }
    
    private static T[] HeapSort<T>(T[] arr, int n, Func<T, T, bool> func)
    {
        for (int i = n / 2 - 1; i >= 0; i--)
            Heapify(arr, n, i, func);
        for (int i=n-1; i>=0; i--)
        {
            Swap(ref arr[0], ref arr[i]);
            Heapify(arr, i, 0, func);
        }

        return arr;
    }
    
    /*Pyromidal end*/
    
    /*Region fast*/
    private static void Swap<T>(ref T x, ref T y)
    {
        (x, y) = (y, x);
    }
    
    private static T[] Fast<T>(T[] obj, Func<T, T, bool> func)
    {
        return QuickSort(obj, 0, obj.Length - 1, func);
    }
    
    private static int Partition<T>(T[] array, int minIndex, int maxIndex, Func<T, T, bool> func)
    {
        var pivot = minIndex - 1;
        for (var i = minIndex; i < maxIndex; i++)
        {
            if (func(array[i], array[maxIndex]))
            {
                pivot++;
                Swap(ref array[pivot], ref array[i]);
            }
        }

        pivot++;
        Swap(ref array[pivot], ref array[maxIndex]);
        return pivot;
    }
    
    private static T[] QuickSort<T>(T[] array, int minIndex, int maxIndex, Func<T, T, bool> func)
    {
        if (minIndex >= maxIndex)
        {
            return array;
        }

        var pivotIndex = Partition(array, minIndex, maxIndex, func);
        QuickSort(array, minIndex, pivotIndex - 1, func);
        QuickSort(array, pivotIndex + 1, maxIndex, func);

        return array;
    }
    /*Region fast end*/
    
    /*Region Merge*/
    private static T[] Merge<T>(T[] obj, Func<T, T, bool> func)
    {
        return MergeSort(obj, 0, obj.Length - 1, func);
    }
    
    private static void MergeIt<T>(T[] array, int lowIndex, int middleIndex, int highIndex, Func< T, T, bool> func)
    {
        var left = lowIndex;
        var right = middleIndex + 1;
        var tempArray = new T[highIndex - lowIndex + 1];
        var index = 0;

        while ((left <= middleIndex) && (right <= highIndex))
        {
            if (func(array[left], array[right]))
            {
                tempArray[index] = array[left];
                left++;
            }
            else
            {
                tempArray[index] = array[right];
                right++;
            }

            index++;
        }

        for (var i = left; i <= middleIndex; i++)
        {
            tempArray[index] = array[i];
            index++;
        }

        for (var i = right; i <= highIndex; i++)
        {
            tempArray[index] = array[i];
            index++;
        }

        for (var i = 0; i < tempArray.Length; i++)
        {
            array[lowIndex + i] = tempArray[i];
        }
    }
    
    private static T[] MergeSort< T >(T[] array, int lowIndex, int highIndex, Func< T, T, bool> func)
    {
        if (lowIndex < highIndex)
        {
            var middleIndex = (lowIndex + highIndex) / 2;
            MergeSort(array, lowIndex, middleIndex, func);
            MergeSort(array, middleIndex + 1, highIndex, func);
            MergeIt(array, lowIndex, middleIndex, highIndex, func);
        }

        return array;
    }
    /*Merge region end*/
}