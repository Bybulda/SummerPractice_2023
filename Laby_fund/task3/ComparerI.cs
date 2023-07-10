﻿using System.Collections;

namespace Laby_fund.task3;

public class ComparerI<T>: Comparer<T>
{
    public override int Compare(T? x, T? y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (ReferenceEquals(null, y)) return 1;
        if (ReferenceEquals(null, x)) return -1;
        return Comparer<T>.Default.Compare(x, y);
    }
}