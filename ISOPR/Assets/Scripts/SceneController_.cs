﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController_ : MonoBehaviour {
	float deltaTime = 0.0f;
	public float gold;
	public GameObject[] Enemies;

    //the current object to be built
    public GameObject CurrentlySelected;

    //reference to all the buildable objects
    public GameObject[] Buildables;

    //the main parent of all the island objects
    public GameObject IslandParent;

    //tells us whether we should be rotating the island or not
    private bool rotateisland;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		deltaTime += (Time.deltaTime - deltaTime) * 0.1f;

        //rotates the island if we have pressed the button and we are at 0 rotation
        if(rotateisland == true && IslandParent.transform.rotation.eulerAngles.y <= 180)
        { IslandParent.transform.Rotate(0, 1, 0);  }


        //NEW WAY TO DO CAMERA ROTATIONS LOOK INTO THIS

     // transform.LookAt(IslandParent.transform);
      // transform.Translate(Vector3.right * Time.deltaTime * 100);
        

        
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

    //selects the item based on what number the button sends. 
    public void SelectItem(int IndexNumber)
    {
        CurrentlySelected = Buildables[IndexNumber];
    }
    //cancel out of building so if we click on something we wont build anything
    public void Cancel()
    {
        CurrentlySelected = null;
    }
    //rotates the island so we can see the other side
    public void RotateIsland()
    {
        //simple if statement to determine if we have already rotated the island or not
        if (rotateisland == false)
        {
            rotateisland = true;
        }
        else
        {
            rotateisland = false;
        }
    }
}
