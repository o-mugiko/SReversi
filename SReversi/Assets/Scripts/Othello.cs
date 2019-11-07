using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Othello : MonoBehaviour
{
    private int CellCount = 8;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Stage3D>().Initialize(CellCount);
        this.GetComponent<Cell3D>().Initialize(CellCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
