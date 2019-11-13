using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3D : MonoBehaviour
{

    public GameObject stagePrefab;


    public int[,] stageArray;

    private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");

// Start is called before the first frame update
    public void Initialize(int count)
    {
        stageArray = new int[count,count];
        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                stageArray[i, j] = -1;
                GameObject tmp = Instantiate(stagePrefab, new Vector3(j, -0.5f, -i), Quaternion.identity);
                tmp.GetComponent<Stage>().Set(j,i);
            }
        }
    }

 
}
