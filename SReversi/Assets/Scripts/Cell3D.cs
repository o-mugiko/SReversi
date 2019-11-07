using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell3D : MonoBehaviour
{
    public GameObject cellPrefab;
    public int[,] cellArray;

    // Start is called before the first frame update
    public void Initialize(int count)
    {
        cellArray = new int[count,count];
        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                cellArray[i, j] = -1;
            }
        }

        for (int i = count / 2 - 1; i < count / 2; i++)
        {
            for (int j = count/2 - 1; j < count / 2; j++)
            {
                GameObject obj = Instantiate(cellPrefab, new Vector3(j, 0, -i), Quaternion.identity);
                var tmp = obj.GetComponent<Cell>();
                if (i == j)
                {
                    cellArray[i, j] = 0;
                    obj.GetComponent<Renderer>().material.color = Color.black;
                    tmp.SetV2(i,j);tmp.SetBK(true);
                }
                else
                {
                    cellArray[i, j] = 1;
                    obj.GetComponent<Renderer>().material.color = Color.white;
                    tmp.SetV2(i,j);tmp.SetBK(false);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
