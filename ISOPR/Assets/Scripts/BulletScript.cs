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

    //called by turret script, takes the position of target and the power of the shot
    public void Fire(Transform target, float shotpower)
    {
        transform.LookAt(target);
        GetComponent<Rigidbody>().AddForce(transform.forward * shotpower);
    }
}
