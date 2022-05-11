using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeConsoleInvokation : MonoBehaviour
{
    [SerializeField] private GameObject _runtimeConsoles;

    private void Start()
    {
        _runtimeConsoles.SetActive(false);
        Accelerometer.Instance.OnShake += OnShakeChange;
    }

    private void OnDestroy()
    {
        Accelerometer.Instance.OnShake -= OnShakeChange;
    }

    private void OnShakeChange()
    {
        if (_runtimeConsoles.activeInHierarchy)
            _runtimeConsoles.SetActive(false);
        else
            _runtimeConsoles.SetActive(true);
    }
}
