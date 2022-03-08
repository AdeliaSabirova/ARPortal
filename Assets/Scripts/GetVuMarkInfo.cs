using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class GetVuMarkInfo : MonoBehaviour
{
    private string _vumark;
    private VuMarkManager _manager;

    private void Start()
    {
        _manager = TrackerManager.Instance.GetStateManager().GetVuMarkManager();
    }

    public void ShowVuMarkInfor()
    {
        foreach(var behavior in _manager.GetActiveBehaviours())
        {
            _vumark = behavior.VuMarkUserData;
        }
        Debug.Log($"VuMark info is {_vumark}");
    }
}
