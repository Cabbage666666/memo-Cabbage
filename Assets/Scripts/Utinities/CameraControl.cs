using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private CinemachineConfiner2D consiner2D;
    public CinemachineImpulseSource impulseSource;
    public VoidEventSO CameraShakeEvent;
    
    private void Awake()
    {
        consiner2D = GetComponent<CinemachineConfiner2D>(); 
    }

    private void OnEnable()
    {
        CameraShakeEvent.OnEventRaised += OnCameraShakeEvent;
    }

    private void OnDisable()
    {
        CameraShakeEvent.OnEventRaised -= OnCameraShakeEvent;
    }

    private void OnCameraShakeEvent()
    {
        impulseSource.GenerateImpulse();
    }
}
