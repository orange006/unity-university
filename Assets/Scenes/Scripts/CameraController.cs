using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public float cameraDistance = 30.0f;

    private void Awake()
    {
        GetComponent<Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance);
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }
}
