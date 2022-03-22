using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomTrackableEventHandler : DefaultTrackableEventHandler
{
    [SerializeField] private Image _vumark;
    [SerializeField] private Text _text;
    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        GetComponent<GetVuMarkInfo>().ShowVuMarkInfor();
        _vumark.enabled = false;
        _text.enabled = false;
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        _vumark.enabled = true;
        _text.enabled = true;
    }
}
