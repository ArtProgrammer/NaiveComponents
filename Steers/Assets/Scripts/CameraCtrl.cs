using UnityEngine;
using System.Collections;

public class CameraCtrl : MonoBehaviour {

    public float Dis = 10;

    public float Distance
    {
        set
        {
            CameraPropertiesChanged = Mathf.Approximately(Dis, value);
            Dis = value;
        }
        get
        {
            return Dis;
        }
    }

    public Vector3 TargetPosition;

    public Vector3 Position;

    public float pitch = 45.0f;

    private bool CameraPropertiesChanged = false;

    public float Pitch
    {
        set
        {
            CameraPropertiesChanged = Mathf.Approximately(pitch, value);
            pitch = value;
        }
        get
        {
            return pitch;
        }
    }

    public float yaw = .0f;

    public float Yaw
    {
        set
        {
            CameraPropertiesChanged = Mathf.Approximately(yaw, value);
            yaw = value;
        }
        get
        {
            return yaw;
        }
    }

	// Use this for initialization
	void Start () {
        updateCamera();
    }
	
	// Update is called once per frame
	void Update () {
        //if (CameraPropertiesChanged)
        {
            updateCamera();
        }
    }

    void updateCamera()
    {
        float pitchRad = Pitch * Mathf.Deg2Rad;
        float yawRad = Yaw * Mathf.Deg2Rad;

        Position =
            new Vector3(Distance * Mathf.Cos(pitchRad) * Mathf.Sin(yawRad),
                 Distance * Mathf.Sin(pitchRad),
                 -Distance * Mathf.Cos(pitchRad) * Mathf.Cos(yawRad));

        Position += TargetPosition;

        transform.position = Position;

        transform.LookAt(TargetPosition);
    }
}
