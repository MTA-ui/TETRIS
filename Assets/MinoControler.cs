using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinoControler : MonoBehaviour
{
    public MinoGenerator CtrlMino;

    private GameObject PlacedMino;

    private GameObject[,] haichi_mino = new GameObject[21, 10];

    float waitTime = 0; //ミノの落下間隔を計る変数

    int[,] MinoPos = new int[21, 10];

    int[,] haichi = new int[21, 10]; 

    void Start()
    {
        for(int y = 0; y<MinoPos.GetLength(0); y++)
        {
            for(int x = 0; x < MinoPos.GetLength(1); x++)
            {
                MinoPos[y, x] = 0;
                haichi[y, x] = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        waitTime += Time.deltaTime;
        if (waitTime <= 1.5)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && CtrlMino.mino.transform.position.x > 0)
            {
                if(MinoPos[(int)CtrlMino.mino.transform.position.y, (int)CtrlMino.mino.transform.position.x] == 1 
                    && MinoPos[(int)CtrlMino.mino.transform.position.y, (int)CtrlMino.mino.transform.position.x] != haichi[(int)CtrlMino.mino.transform.position.y, (int)CtrlMino.mino.transform.position.x -1])
                {
                    CtrlMino.mino.transform.position += new Vector3(-1, 0, 0);
                    MinoPos = CtrlMinoPos();
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && CtrlMino.mino.transform.position.x < 9)
            {
                if (MinoPos[(int)CtrlMino.mino.transform.position.y, (int)CtrlMino.mino.transform.position.x] == 1
                    && MinoPos[(int)CtrlMino.mino.transform.position.y, (int)CtrlMino.mino.transform.position.x] != haichi[(int)CtrlMino.mino.transform.position.y, (int)CtrlMino.mino.transform.position.x + 1])
                {
                    CtrlMino.mino.transform.position += new Vector3(1, 0, 0);
                    MinoPos = CtrlMinoPos();
                }
            }
            //下キー押したときかつミノのy座標が0より高いとき
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                //下が地面の時、または下にミノがあったら切り替える。そうでなければ1マス落下。
                if (CtrlMino.mino.transform.position.y <= 0
                    || MinoPos[(int)CtrlMino.mino.transform.position.y, (int)CtrlMino.mino.transform.position.x] == 1
                     && MinoPos[(int)CtrlMino.mino.transform.position.y, (int)CtrlMino.mino.transform.position.x] == haichi[(int)CtrlMino.mino.transform.position.y - 1, (int)CtrlMino.mino.transform.position.x])
                {
                    haichi[(int)CtrlMino.mino.transform.position.y, (int)CtrlMino.mino.transform.position.x] = 1;
                    haichi_mino[(int)CtrlMino.mino.transform.position.y, (int)CtrlMino.mino.transform.position.x] = CtrlMino.mino;
                    waitTime = 0;
                    if (haichi_mino[(int)CtrlMino.mino.transform.position.y, (int)CtrlMino.mino.transform.position.x] == null)
                    {
                        Debug.Log("null");
                    }
                    Debug.Log("minoPosY:" + (int)CtrlMino.mino.transform.position.y + "minoPosX:" + (int)CtrlMino.mino.transform.position.x);
                    hantei();
                    CtrlMino.minoGenerator();
                    MinoPos = CtrlMinoPos();
                }
                else
                {
                    CtrlMino.mino.transform.position += new Vector3(0, -1, 0);
                    MinoPos = CtrlMinoPos();
                }
            }

        }
        else
        {
            MinoPos = CtrlMinoPos();
            //操作中のミノが地面についたとき
            if (CtrlMino.mino.transform.position.y < 1)
            {
                haichi[(int)CtrlMino.mino.transform.position.y, (int)CtrlMino.mino.transform.position.x] = 1;
                haichi_mino[(int)CtrlMino.mino.transform.position.y, (int)CtrlMino.mino.transform.position.x] = CtrlMino.mino;
                waitTime = 0;
                if (haichi_mino[(int)CtrlMino.mino.transform.position.y, (int)CtrlMino.mino.transform.position.x] == null)
                {
                    Debug.Log("null");
                }
                Debug.Log("minoPosY:" + (int)CtrlMino.mino.transform.position.y + " minoPosX:" + (int)CtrlMino.mino.transform.position.x);
                hantei();
                CtrlMino.minoGenerator();
                MinoPos = CtrlMinoPos();
            }
            //下にすでにミノが置いてあったとき
            else if (MinoPos[(int)CtrlMino.mino.transform.position.y, (int)CtrlMino.mino.transform.position.x] == 1
                     && MinoPos[(int)CtrlMino.mino.transform.position.y, (int)CtrlMino.mino.transform.position.x] == haichi[(int)CtrlMino.mino.transform.position.y -1, (int)CtrlMino.mino.transform.position.x])
            {
                haichi[(int)CtrlMino.mino.transform.position.y, (int)CtrlMino.mino.transform.position.x] = 1;
                haichi_mino[(int)CtrlMino.mino.transform.position.y, (int)CtrlMino.mino.transform.position.x] = CtrlMino.mino;
                waitTime = 0;
                if (haichi_mino[(int)CtrlMino.mino.transform.position.y, (int)CtrlMino.mino.transform.position.x] == null)
                {
                    Debug.Log("null");
                }
                Debug.Log("minoPosY:" + (int)CtrlMino.mino.transform.position.y + "minoPosX:" + (int)CtrlMino.mino.transform.position.x);
                hantei();
                CtrlMino.minoGenerator();
                MinoPos = CtrlMinoPos();
            }
            else
            {
                waitTime = 0;
                CtrlMino.mino.transform.position += new Vector3(0, -1, 0);
                MinoPos = CtrlMinoPos();
            }
        }
    }
    int[,] CtrlMinoPos()
    {
        int[,] pos = new int[21, 10];
        for(int y = 0; y < pos.GetLength(0); y++)
        {
            for(int x = 0; x < pos.GetLength(1); x++)
            {
                if(CtrlMino.mino.transform.position.y == y && CtrlMino.mino.transform.position.x == x)
                {
                    pos[y, x] = 1;
                }
                else
                {
                    pos[y, x] = 0;
                }
            }
        }
        return pos;
    }
    
    void hantei()
    {
        int count = 0;
        for (int y = 0; y < haichi.GetLength(0); y++)
        {
            count = 0;
            for (int x = 0; x < haichi.GetLength(1); x++)
            {
                if (haichi[y, x] == 1)
                {
                    count++;
                }
            }
            if (count == 10)
            {
                for (int x = 0; x < haichi.GetLength(1); x++)
                {
                    Destroy(haichi_mino[y, x]);
                    haichi[y, x] = 0;
                }
            }
        }
        for (int y = haichi.GetLength(0) - 1; y >= 0; y--)
        {
            for(int x = 0; x < haichi.GetLength(1); x++)
            {
                if (haichi[y, x] == 1)
                {
                    count = 0;
                    for (int posY = y; y < haichi.GetLength(0); y++)
                    {
                        if(haichi[posY,x] == 0)
                        {
                            count++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (haichi_mino[y, x] == null)
                    {
                        Debug.Log("null");
                    }
                    Debug.Log("y:"+y+"x:" + x + "y.length:" + haichi_mino.GetLength(0)+"x.length:" + haichi_mino.GetLength(1));
                    haichi_mino[y, x].transform.position = new Vector3(x, y + count, 0);
                    haichi_mino[y + count, x] = haichi_mino[y, x];
                    haichi_mino[y, x] = null;
                    haichi[y, x] = 0;
                    haichi[y + count, x] = 1;
                }
            }
        }
    }
}
