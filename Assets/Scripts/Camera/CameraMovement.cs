using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private float smoothVal;
    [SerializeField] private float distOffset;
    [SerializeField] private float heightOffset;
    [SerializeField] private Transform transformTarget;

    void Start()
    {

    }

    void LateUpdate()
    {
        Vector3 cameraDest = transformTarget.position + transformTarget.up * heightOffset;
        cameraDest -= transformTarget.forward * distOffset;

        transform.position = Vector3.Lerp(transform.position, cameraDest, smoothVal * Time.deltaTime);

        Quaternion cameraRot = Quaternion.LookRotation(transformTarget.forward, transformTarget.up);        
        transform.rotation = Quaternion.Slerp(transform.rotation, cameraRot, smoothVal * Time.deltaTime);
    }
}