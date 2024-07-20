using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class EXT 
{
    public static Vector2 Position(this Transform transform) => transform.position;
    public static T Find<T>(this    T[] Group,Func<T,bool>  Predicate)
    {
        foreach (T item in Group)
        {
            if (Predicate(item))
            {
                return item;
            }
        }
        return default(T);
    }
}
