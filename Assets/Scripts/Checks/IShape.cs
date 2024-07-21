using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IShape : MonoBehaviour
{
    public abstract Collider2D[] GetCols();
    public abstract bool Check();
}
