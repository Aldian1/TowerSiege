using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		StartCoroutine ("BulletDeath");

	}


	IEnumerator BulletDeath()
	{

		yield return new WaitForSeconds (5);
		Destroy (this.gameObject);

	}
}
