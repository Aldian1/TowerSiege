using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    private float sizeofcm;
    void Start()
    {
        sizeofcm = Camera.main.orthographicSize;
    }
    void Update()
    {
        float input = Input.GetAxis("Mouse ScrollWheel");
        Debug.Log(input);
        if(Input.GetKey(KeyCode.Mouse0))
        {
            if(!sizeofcm < 6.76F)
            {

            }
        }
    }
}
