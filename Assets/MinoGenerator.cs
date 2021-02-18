using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinoGenerator : MonoBehaviour
{
    public GameObject mino1Prefab;

    public GameObject mino2Prefab;

    public GameObject mino3Prefab;

    public GameObject mino;

    private GameObject nextMino;

    private int item;
    void Start()
    {
        item = Random.Range(1, 4);
        Debug.Log(item);
        switch(item)
        {
            case 1:
                mino = Instantiate(mino1Prefab);
                mino.transform.position = new Vector3(5, 19, 0);
                break;
            case 2:
                mino = Instantiate(mino2Prefab);
                mino.transform.position = new Vector3(5, 19, 0);
                break;
            case 3:
                mino = Instantiate(mino3Prefab);
                mino.transform.position = new Vector3(5, 19, 0);
                break;
        }
        item = Random.Range(1, 4);
        Debug.Log(item);
        switch (item)
        {
            case 1:
                nextMino = Instantiate(mino1Prefab);
                nextMino.transform.position = new Vector3(15, 12, 0);
                break;
            case 2:
                nextMino = Instantiate(mino2Prefab);
                nextMino.transform.position = new Vector3(15, 12, 0);
                break;
            case 3:
                nextMino = Instantiate(mino3Prefab);
                nextMino.transform.position = new Vector3(15, 12, 0);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void minoGenerator()
    {
        this.mino = nextMino;
        mino.transform.position = new Vector3(5, 20, 0);

        item = Random.Range(1, 4);
        switch (item)
        {
            case 1:
                nextMino = Instantiate(mino1Prefab);
                nextMino.transform.position = new Vector3(15, 12, 0);
                break;
            case 2:
                nextMino = Instantiate(mino2Prefab);
                nextMino.transform.position = new Vector3(15, 12, 0);
                break;
            case 3:
                nextMino = Instantiate(mino3Prefab);
                nextMino.transform.position = new Vector3(15, 12, 0);
                break;
        }
    }
}
