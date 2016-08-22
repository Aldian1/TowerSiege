using UnityEngine;
using System.Collections;

public class GridDetector : MonoBehaviour {

    public Material normal, highlighted;

    public bool mousein,locked;

    private GameObject BasicBlock;
	// Use this for initialization
	void Start () {
        BasicBlock = Resources.Load("BaseBlock") as GameObject;
        normal = Resources.Load("GridBlock") as Material;
        highlighted = Resources.Load("GridHighlight") as Material;
    }
	
	// Update is called once per frame
	void Update () {
	if(Input.GetKeyDown(KeyCode.Mouse0) && mousein == true && locked == false)
        {
            
            Vector3 pos = new Vector3(this.transform.position.x, this.transform.position.y + 10, this.transform.position.z);
            GameObject go = Instantiate(BasicBlock, pos, Quaternion.identity) as GameObject;
            StartCoroutine("TweenCube", go);
            locked = true;
        }
	}


    void OnMouseEnter()
    {
        if (!locked)
        {
            this.GetComponent<Renderer>().material = highlighted;
            mousein = true;
        }
    }

    void OnMouseExit()
    {
        this.GetComponent<Renderer>().material = normal;
        mousein = false;
    }


    //tweener = the gameobject 

    public IEnumerator TweenCube(GameObject tweener)
    {


        Vector3 brickpos = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);

        while (Vector3.Distance(tweener.transform.position, this.transform.position) > 1)
        {
            tweener.transform.Translate(Vector3.down * Time.deltaTime * 3);
            yield return new WaitForSeconds(.03F);

        }
        this.enabled = false;

    }
}
