using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    [SerializeField] private float rotDegreeClamp;
    [SerializeField] private float flightSpeed;
    [SerializeField] private float boostGauge;
    [SerializeField] private float jitterBuffer;
    [SerializeField] private float rotSmoothing;

    private Quaternion gyroAttitude = Quaternion.identity;
    private Quaternion prevFrameRot;

    private void Start()
    {
        Input.gyro.enabled = true;
    }

    void Update()
    {
        gyroAttitude = Input.gyro.attitude;

        Quaternion rotChange = Quaternion.Inverse(prevFrameRot) * gyroAttitude;
        //Quaternion clampedRot = Quaternion.Euler(gyroAttitude.eulerAngles.x, gyroAttitude.eulerAngles.y, Mathf.Clamp(adjustedZRot, -rotDegreeClamp, rotDegreeClamp));

        if (Mathf.Abs(rotChange.eulerAngles.z) > jitterBuffer)
        {
            Quaternion zGyroRot = Quaternion.Euler(0, 0, gyroAttitude.eulerAngles.z - 90);
            transform.rotation = Quaternion.Slerp(prevFrameRot, zGyroRot, rotSmoothing * Time.deltaTime);
            Debug.Log("jitter: " + rotChange.eulerAngles.z);
        }
    }

    private void LateUpdate()
    {
        prevFrameRot = transform.rotation;
    }
}
