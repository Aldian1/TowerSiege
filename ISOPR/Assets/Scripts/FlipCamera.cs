using UnityEngine;
using System.Collections;

public class FlipCamera : MonoBehaviour {

    public bool memory;
    private Transform camerapar;

    void Start()
    {
        camerapar = Camera.main.transform.parent.transform;
    }

    public void FlipCamera_()
    {
        if (!memory)
        {
            StartCoroutine("TweenTooNinety");
            memory = true;
        }
        else
        {
            memory = false;
        }
    }

    IEnumerator TweenTooNinety()
    {

        while(camerapar.transform.rotation.y < 180)
        {
            camerapar.transform.Rotate(0, 5, 0);
        }

        yield return null;
    }
}
