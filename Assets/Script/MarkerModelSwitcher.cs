using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerModelSwitcher : MonoBehaviour
    {
        [SerializeField]
        private ARObjectManager _arObjManager;

        private int _pageNum = 0;

        public GameObject ArObj{get; set;}


        public void SwitchingObject(int pageNum, Vector3 pos, Quaternion rot)
        {
            if (ArObj != null) ArObj.SetActive(false);
            this._pageNum = pageNum;
            ArObj = _arObjManager.GetArObjByNum(_pageNum);
            ArObj.SetActive(true);
            ArObj.transform.position = pos;
            ArObj.transform.rotation = rot;
        }
    }
