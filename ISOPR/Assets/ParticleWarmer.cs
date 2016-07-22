using UnityEngine;
using System.Collections;

public class ParticleWarmer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<ParticleSystem>().Emit(800);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
