using UnityEngine;
using System.Collections;

public class EnemyTestScript : MonoBehaviour {

    public float speed;

    public bool attack;

    public Transform Tower;

    public GameObject ChildObj;


	// Use this for initialization
	void Start () {
        Tower = GameObject.FindGameObjectWithTag("Tower").transform;
        ChildObj = transform.GetChild(0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {

        if (attack)
        {
           
            transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        }
        if(!attack)
        {
            if (transform.rotation.x != 90)
            {
                
            }
            transform.RotateAround(Vector3.zero, Vector3.up, speed * Time.deltaTime);
        }
	}


}
