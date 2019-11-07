using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3D : MonoBehaviour
{
    private RaycastHit hit;  // 光線に当たったオブジェクトを受け取るクラス 
    private Ray ray;  // 光線クラス
    private Renderer renderer;
    private bool ToF = false;
    public GameObject stagePrefab;
    public Material originalMat;


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
                tmp.GetComponent<Stage>().Set(i,j);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // スクリーン座標に対してマウスの位置の光線を取得
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (ToF)
        {
            renderer.material = originalMat;
        }

        // マウスの光線の先にオブジェクトが存在していたら hit に入る 
        if (Physics.Raycast(ray, out hit, 15f))
        {
            renderer = hit.transform.GetComponent<Renderer>();
            renderer.material.SetColor(EmissionColor, new Color(0.7f, 0.7f, 0));
            ToF = true;
        }
    }
}
