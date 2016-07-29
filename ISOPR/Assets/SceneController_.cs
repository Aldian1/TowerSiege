using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController_ : MonoBehaviour {
	float deltaTime = 0.0f;
	public float gold;
	public GameObject[] Enemies;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
	}

    void OnGUI()
    {





		//GUILayout.
		GUILayout.Label ("Debug Menu/Stats");
		GUILayout.Label ("Current Gold: " + gold);

        if(GUILayout.Button("Reload Scene"))
        {
			
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }





		//fps calculations
		int w = Screen.width, h = Screen.height;

		GUIStyle style = new GUIStyle();

		Rect rect = new Rect(w/4, 0, w, h * 2 / 100);
		style.alignment = TextAnchor.UpperLeft;
		style.fontSize = h * 2 / 100;
		style.normal.textColor = Color.yellow;
		float msec = deltaTime * 1000.0f;
		float fps = 1.0f / deltaTime;
		string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
		GUI.Label(rect, text, style);

    }

}
