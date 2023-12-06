using UnityEngine;

public class MovementController : MonoBehaviour
{

    [SerializeField] private float rotDegreeClamp;
    [SerializeField] private float flightSpeed;
    [SerializeField] private float boostGauge;
    [SerializeField] private float jitterBuffer;
    [SerializeField] private float rotAmount;

    private Quaternion gyroAttitude = Quaternion.identity;
    private Quaternion prevFrameRot;

    private void Start()
    {
        Input.gyro.enabled = true;
    }

    public void Update()
    {
        gyroAttitude = Input.gyro.attitude;

        #region RotClamping
        //Quaternion rotChange = Quaternion.Inverse(prevFrameRot) * gyroAttitude;
        //Quaternion clampedRot = Quaternion.Euler(gyroAttitude.eulerAngles.x, gyroAttitude.eulerAngles.y, Mathf.Clamp(adjustedZRot, -rotDegreeClamp, rotDegreeClamp));
        //if (Mathf.Abs(rotChange.eulerAngles.z) > jitterBuffer)
        //{
        //    Quaternion zGyroRot = Quaternion.Euler(0, 0, gyroAttitude.eulerAngles.z - 90);
        //    transform.rotation = Quaternion.Slerp(prevFrameRot, zGyroRot, rotSmoothing * Time.deltaTime);
        //    Debug.Log("jitter: " + rotChange.eulerAngles.z);
        //}
        #endregion

    }

    private void LateUpdate()
    {
        prevFrameRot = transform.rotation;
    }

    public void PlayerRot(float rotDirection)
    {
        Quaternion targetRot = Quaternion.Euler(0f, 0f, Mathf.Clamp(transform.rotation.eulerAngles.z, -rotDegreeClamp, rotDegreeClamp));

        if (rotDirection > 0)
        {
            Debug.Log(targetRot);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotAmount * Time.deltaTime);
        }
        else
        {
            Debug.Log(targetRot);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, -rotAmount * Time.deltaTime);

        }
    }
}
