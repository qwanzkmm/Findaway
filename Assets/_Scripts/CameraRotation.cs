using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CameraRotation : MonoBehaviour
{
    public float SensitivityX;
    public float SensitivityY;

    [SerializeField] private GameObject rootObject;
    
    private float yaw;
    private float pitch;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        yaw += SensitivityY * Input.GetAxis(AXIS_CONSTS.MOUSEX);
        pitch -= SensitivityX * Input.GetAxis(AXIS_CONSTS.MOUSEY);

        pitch = Mathf.Clamp(pitch, -75f, 75f);
        
        transform.eulerAngles = new Vector3(pitch, transform.eulerAngles.y, 0f);
        rootObject.transform.eulerAngles = new Vector3(rootObject.transform.eulerAngles.x, yaw, rootObject.transform.eulerAngles.z);

    }
}
