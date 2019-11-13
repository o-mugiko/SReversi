using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell3D : MonoBehaviour
{
    public List<Vector2> DirectionList; // Vector2(-1,1)は左上, Vector2(0,1)は上、Vector(1,0)は右上… Scene内で定義している

    public GameObject cellPrefab;
    public int[,] cellArray;
    private Othello _othello;

    // Start is called before the first frame update
    private void Start()
    {
        _othello = this.GetComponent<Othello>();
    }

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

        for (int i = count / 2 - 1; i <= count / 2; i++)
        {
            for (int j = count/2 - 1; j <= count / 2; j++)
            {
                GameObject obj = Instantiate(cellPrefab, new Vector3(j, 0, -i), Quaternion.identity);
                var tmp = obj.GetComponent<Cell>();
                if (i == j)
                {
                    cellArray[i, j] = 0;
                    obj.GetComponent<Renderer>().material.color = Color.black;
                    tmp.SetV2(j,i);tmp.SetBK(true);
                }
                else
                {
                    cellArray[i, j] = 1;
                    obj.GetComponent<Renderer>().material.color = Color.white;
                    tmp.SetV2(j,i);tmp.SetBK(false);
                }
            }
        }
    }

    //中略

    //押下された位置が反転可能かの判定
    internal bool CanPlaceHere(Vector2 location)
    {
        //押下された位置は、そもそも空いているか
        if (cellArray[(int)location.x, (int)location.y] != -1)
            return false;
        //全方向に対して、挟めるか方角があるかを判定
        for (int direction = 0; direction < DirectionList.Count; direction++)
        {
            Vector2 directionVector = DirectionList[direction];
            //指定された方角に対して、挟む自分のコマが存在しているか？
            if (FindAllyChipOnOtherSide(directionVector, location, false) != -1)
            {
                //一つの方向でも見つかればそれで終わり
                return true;
            }
        }
        return false;
    }
    
    //指定された方角に対して、挟む事ができるかを判定する再帰メソッド
    private int FindAllyChipOnOtherSide(Vector2 directionVector, Vector2 fromV, bool EnemyFound)
    {
        Vector2 to = fromV + directionVector;
        //ボードの外に出ていないか、空マスでないか
        if (IsInRangeOfBoard(to) && cellArray[(int)to.x, (int)to.y] != -1)
        {
            //見つかったマスのオセロは自分のオセロか
            if (cellArray[(int)to.x, (int)to.y] == 0)
            {
                //既に間に一回敵オセロを見つけているか(つまり挟んだか)
                if (EnemyFound)
                    return cellArray[(int)to.x, (int)to.y];
                return -1;
            }
            else
                //見つかったのは敵オセロなので、EnemyFoundを真にし、自分のオセロを見つけるまで再帰的に同メソッドを呼ぶ
                return FindAllyChipOnOtherSide(directionVector, to, true);
        }
        //ここまでにreturnされない場合nullを返す
        return -1;
    }

    bool IsInRangeOfBoard(Vector2 v2)
    {
        return _othello.IsInRangeOfBoard(v2);
    }
}
