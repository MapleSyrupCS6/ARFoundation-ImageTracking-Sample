using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;  

public class ImageRecognition : MonoBehaviour
{
    [SerializeField] private MarkerModelSwitcher _markerModelSwitcher;
    [SerializeField] private ARTrackedImageManager _arTrackedImageManager;

    private int _presentMarkerNum = -1;

    private void Awake()
    {
        _arTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    public void OnImageChanged (ARTrackedImagesChangedEventArgs args)
    {
        string _name;
        int _nameNum;

        foreach (var a in args.updated)
        {
            _name = a.referenceImage.name;
            _nameNum = int.Parse (_name);
            Vector3 markerPos = a.transform.position;
            Quaternion qua = a.transform.rotation;

            if(_markerModelSwitcher.ArObj != null) 
            {
                _markerModelSwitcher.ArObj.transform.position = markerPos;
                _markerModelSwitcher.ArObj.transform.rotation = qua;
            }

            if (a.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Tracking)
            {
                if (_nameNum == _presentMarkerNum) return;
                // Debug.Log ("MarkerName:::::::::::::::::::::::::::::::::" + _name);
                _markerModelSwitcher.SwitchingObject(_nameNum, markerPos, qua);
                _presentMarkerNum = _nameNum;
            }
        }
    }
}
