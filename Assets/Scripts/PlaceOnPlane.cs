using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceOnPlane : MonoBehaviour
{
    private ARRaycastManager _manager;
    private Vector2 _touchPosition;
    public GameObject prefab;
    private static List<ARRaycastHit> _hits = new List<ARRaycastHit>();

    private void Awake()
    {
        _manager = GetComponent<ARRaycastManager>();
        prefab.SetActive(false);
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            _touchPosition = Input.GetTouch(0).position;
            if(_manager.Raycast(_touchPosition, _hits, TrackableType.PlaneWithinPolygon))
            {
                var hitPose = _hits[0].pose;
                prefab.SetActive(true);
                prefab.transform.position = hitPose.position;
                LookAtPlayer(prefab.transform);
            }
        }
    }

    private void LookAtPlayer(Transform transform)
    {
        var lookDirection = Camera.main.transform.position - transform.position;
        lookDirection.y = 0;
        transform.rotation = Quaternion.LookRotation(lookDirection);
    }
}
