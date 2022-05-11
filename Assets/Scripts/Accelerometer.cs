using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    #region Instance
    private static Accelerometer _instance;
    public static Accelerometer Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<Accelerometer>();
                if(_instance == null)
                {
                    _instance = new GameObject("Spawned Accelerometer", typeof(Accelerometer)).GetComponent<Accelerometer>();
                }
            }
            return _instance;
        }
        set
        {
            _instance = value;
        }
    }
    #endregion

    public Action OnShake;
    [SerializeField] private float _shakeDetectionThreshold = 2.0f;
    private float _accelerometerUpdateInterval = 1.0f / 60.0f;
    private float _lowPassKernelWithInSeconds = 1.0f;
    private float _lowPassFilterFactor;
    private Vector3 _lowPassValue;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        _lowPassFilterFactor = _accelerometerUpdateInterval / _lowPassKernelWithInSeconds;
        _shakeDetectionThreshold *= _shakeDetectionThreshold;
        _lowPassValue = Input.acceleration;
    }

    private void Update()
    {
        var acceleration = Input.acceleration;
        _lowPassValue = Vector3.Lerp(_lowPassValue, acceleration, _lowPassFilterFactor);
        var deltaAcceleration = acceleration - _lowPassValue;

        if (deltaAcceleration.sqrMagnitude >= _shakeDetectionThreshold)
            OnShake?.Invoke();
    }
}
