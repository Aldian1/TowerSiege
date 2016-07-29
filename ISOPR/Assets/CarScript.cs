using UnityEngine;
using System.Collections;

public class CarScript : MonoBehaviour {
	public Vector3 origpos;
	// Use this for initialization
	void Start () {
	
		//set the original position we start at
		//origpos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (transform.right * Time.deltaTime * 1.5F);
	}


	void OnTriggerEnter(Collider col)
	{
		
		if (col.tag == "End") {
			transform.position = origpos;
		}
	}
}
