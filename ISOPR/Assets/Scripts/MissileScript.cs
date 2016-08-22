using UnityEngine;
using System.Collections;

public class MissileScript : MonoBehaviour {

    public GameObject missile;

	// Use this for initialization
	void Start () {
        //int u = Random.Range
        InvokeRepeating("Shoot", 0, Random.Range(10, 20));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Shoot()
    {
        
        Instantiate(missile, transform.position, Quaternion.identity);
    }
}
