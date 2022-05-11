using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class UXController : MonoBehaviour
{
    private ARPlaneManager _manager;
    public GameObject prefab;

    private void Awake()
    {
        _manager = GetComponent<ARPlaneManager>();
    }

    private void Start()
    {
        _manager.planesChanged += OnPlanesChanged;
    }

    private void OnPlanesChanged(ARPlanesChangedEventArgs obj)
    {
        foreach(var item in obj.added)
        {
            prefab.SetActive(false);
            Debug.LogError("UI guides are removed");
            break;
        }
    }
}
