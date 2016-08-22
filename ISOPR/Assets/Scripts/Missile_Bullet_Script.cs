using UnityEngine;
using System.Collections;

public class Missile_Bullet_Script : MonoBehaviour {

    public Transform tower;
    public float smoothingspeed;

	// Use this for initialization
	void Start () {
        tower = GameObject.FindGameObjectWithTag("Tower").transform;
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.forward * 4 * Time.deltaTime);
        transform.Rotate(0,0,10);

        Vector3 targetDir = tower.position - transform.position;
        float step = smoothingspeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        Debug.DrawRay(transform.position, newDir, Color.red);
        transform.rotation = Quaternion.LookRotation(newDir);
    }


}

