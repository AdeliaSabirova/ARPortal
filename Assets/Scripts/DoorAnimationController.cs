using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;

public class DoorAnimationController : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        GetComponent<Animator>().SetTrigger("Open");

        var planeManager = FindObjectOfType<ARPlaneManager>();
        var pointCloudManager = FindObjectOfType<ARPointCloudManager>();

        foreach (var point in pointCloudManager.trackables)
        {
            point.gameObject.SetActive(false);
        }

        foreach (var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }

        planeManager.enabled = false;
        pointCloudManager.enabled = false;
    }
}
