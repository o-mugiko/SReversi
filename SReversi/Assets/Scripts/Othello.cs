using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Othello : MonoBehaviour
{
    private RaycastHit hit;  // 光線に当たったオブジェクトを受け取るクラス 
    private Ray ray;  // 光線クラス
    private Renderer renderer;
    private bool ToF = false;
    
    public Material originalMat;
    
    private int cellCount = 8;

    private bool blackTurn = true;
    private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Stage3D>().Initialize(cellCount);
        this.GetComponent<Cell3D>().Initialize(cellCount);
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
            if (hit.transform.CompareTag("Stage"))
            {
                renderer = hit.transform.GetComponent<Renderer>();
                renderer.material.SetColor(EmissionColor, new Color(0.7f, 0.7f, 0));
                ToF = true;
                if (Input.GetMouseButtonDown(0))
                {
                    var tmp = hit.transform.GetComponent<Stage>();
                    var hoge = tmp.Get();
                    Debug.Log(this.GetComponent<Cell3D>().CanPlaceHere(hoge));
                }
            }
        }
    }
    
    public bool IsInRangeOfBoard(Vector2 v2)
    {
        if (v2.x < 0 || v2.x >= cellCount || v2.y < 0 || v2.y >= cellCount)
        {
            return false;
        }

        return true;
    }
}
