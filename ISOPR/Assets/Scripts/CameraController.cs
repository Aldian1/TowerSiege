using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    Camera cam;
    public float MaxZoom, MinZoom;

    public void Start()
    {
        //get the camera
        cam = this.gameObject.GetComponent<Camera>();
    }

    public void Update()
    {
        float i = Input.GetAxis("Mouse ScrollWheel");

        if (i > 0 && cam.orthographicSize > MinZoom)
        {
            cam.orthographicSize -= .5F;
        }

        if (i < 0 && cam.orthographicSize < MaxZoom)
        {
            cam.orthographicSize += .5F;
        }
    }
}
