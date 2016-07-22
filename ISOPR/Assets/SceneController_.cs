using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController_ : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if(GUILayout.Button("Reload Scene"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

    }

}
