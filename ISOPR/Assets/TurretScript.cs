using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour {

	public float RescanRate;
	public GameObject[] CurrentEnemies;

	public GameObject currenttarget;

	public float ROTspeed;

	public bool firing;

	public float shootrate,BulletSpeed;

	private Transform shootshot;

	private GameObject bullet;



	// Use this for initialization
	void Start () {
		//Load bullet resource
		bullet = Resources.Load("Bullet") as GameObject;
		//repeat the scan
		InvokeRepeating ("ReScan", 0, RescanRate);
		//get the shootshot pos
		shootshot = transform.GetChild(0).FindChild("ShotSpot");
		//if we cant find it put up a warning message
		if (shootshot == null) {
			Debug.Log ("Warning! Cannot find turret child");
		}

	}
	
	// Update is called once per frame
	void Update () {

		//if we have a current target then run
		if (currenttarget != null) {
			//get the direction of the target base on our pos
			Vector3 targetdir = currenttarget.transform.position - transform.position;
			//create a float to incorporate our ROTspeed and smooth it by time.deltatime
			float step = ROTspeed * Time.deltaTime;
			//take the new dir and define it
			Vector3 newdir = Vector3.RotateTowards (transform.forward, targetdir, step, 0.0F);
			//rotate towards the newdir
			transform.rotation = Quaternion.LookRotation (newdir);


			//if we have a target & were not firing then we need to shoot!
			if (!firing) {
				//invoke a repeating rate, also add the new dir to be parsed over
				InvokeRepeating ("Shoot", 0, shootrate);
				//say that firing is true as we are now firing
				firing = true;
			}
		}
	}


	public void ReScan()
	{
		Debug.Log ("Scanning");
		//setting current target as null
		currenttarget = null;
		//refreshing the current enemies list
		CurrentEnemies = GameObject.FindGameObjectsWithTag ("Enemy");

		//searching through the list to find the closest match
		for (int i = 0; i < CurrentEnemies.Length; i++) {
			//checking the distance of object
			if (Vector3.Distance (CurrentEnemies [i].transform.position, this.transform.position) < 5) {
				//setting the current target as the current searched enemie
				currenttarget = CurrentEnemies [i];
			}
		}

	}


	public void Shoot()
	{



		//instantiate the bullet
		GameObject go = Instantiate (bullet, shootshot.position, Quaternion.identity) as GameObject;


		//////REFACTOR//////////

		//get the direction of the target base on our pos
		Vector3 targetdir = currenttarget.transform.position - go.transform.position;
		//create a float to incorporate our ROTspeed and smooth it by time.deltatime
		float step = ROTspeed * Time.deltaTime;
		//take the new dir and define it
		Vector3 newdir = Vector3.RotateTowards (go.transform.forward, targetdir, step, 0.0F);
		//rotate te bullet towards the enemy
		go.transform.rotation = Quaternion.LookRotation (newdir);






		//get the rigidbody of the bullet and add a force behind it
		go.GetComponent<Rigidbody> ().AddForce (transform.forward * BulletSpeed * Time.deltaTime);
	}
}
