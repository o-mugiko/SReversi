using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Stage : MonoBehaviour
{
    private Vector2 v;

    public void Set(int i, int j)
    {
        v.x = i;
        v.y = j;
    }

    public Vector2 Get()
    {
        return v;
    }
}
