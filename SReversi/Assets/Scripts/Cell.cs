using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    private bool isBlack;
    private Vector2 v;

    public void SetV2(int i, int j)
    {
        v.x = i;
        v.y = j;
    }

    public void SetBK(bool isBlack)
    {
        this.isBlack = isBlack;
    }

    public Vector2 GetV2()
    {
        return v;
    }

    public bool GetBK()
    {
        return isBlack;
    }
}
