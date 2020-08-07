using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARObjectManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _arObjs;

    private int _ObjNum = 0;

    private void Awake()
    {
        foreach (GameObject g in _arObjs)
        {
            g.SetActive(false);
        }
    }

    public GameObject GetArObjByNum(int _pageNum)
    {
        return _arObjs[_pageNum];
    }
}
