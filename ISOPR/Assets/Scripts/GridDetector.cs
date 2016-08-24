using UnityEngine;
using System.Collections;

public class GridDetector : MonoBehaviour
{
    public int identifier;
    public Material normal, highlighted;

    public bool mousein, locked;

    private SceneController_ SceneController;

 
    // Use this for initialization
    void Start()
    {
        SceneController = Camera.main.GetComponent<SceneController_>();

        normal = GetComponent<Renderer>().material;
        highlighted = Resources.Load("GridHighlight") as Material;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && mousein == true && locked == false && SceneController.CurrentlySelected != null)
        {
            BuildObject();

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



    //tweens the object from its spawned position to +1 above the object
    public IEnumerator TweenCube(GameObject tweener)
    {


        Vector3 brickpos = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);

        while (Vector3.Distance(tweener.transform.position, this.transform.position) > 1)
        {
            tweener.transform.Translate(Vector3.down * Time.deltaTime * 4);
            yield return new WaitForSeconds(.03F);

        }
        this.enabled = false;

    }


    void BuildObject()
    {

        Vector3 pos = new Vector3(this.transform.position.x, this.transform.position.y + 10, this.transform.position.z);
        GameObject go = Instantiate(SceneController.CurrentlySelected, pos, Quaternion.identity) as GameObject;
        StartCoroutine("TweenCube", go);
        go.transform.parent = this.gameObject.transform;

        //determine the rotation of the object 
        //set by designer when importing models

        switch(identifier)
        {
            case 0:
                go.transform.Rotate(0, 0, 0);

                break;

            case 1:
                go.transform.Rotate(0, 90, 0);
                break;

            case 2:
                go.transform.Rotate(0, 180, 0);
                break;

            case 3:
                go.transform.Rotate(0, 270, 0);
                break;
        }


        locked = true;

    }
}
