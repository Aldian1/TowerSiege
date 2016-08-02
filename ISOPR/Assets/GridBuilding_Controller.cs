using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GridBuilding_Controller : MonoBehaviour {

    public GameObject[] Grid;

    public GameObject[] BlockTypes;

    public GameObject CurrentItem;

    public GameObject GridCanvas;

    private int griditemsdeactivated;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(griditemsdeactivated >= Grid.Length)
        {
            
            GridCanvas.transform.position = new Vector3(GridCanvas.transform.position.x, GridCanvas.transform.position.y + 1, GridCanvas.transform.position.z);
            foreach(Transform gridpiece in GridCanvas.transform)
            {
                gridpiece.gameObject.SetActive(true);
            }
            griditemsdeactivated = 0;
            return;
        }
	}



    public void ItemSelector(Button button)
    {
        if(button.name == "BaseBlock")
        {
            CurrentItem = BlockTypes[0];
        }
    }


    public void DeactivateGridButton(Button button)
    {
        if (CurrentItem != null)
        {
            button.gameObject.SetActive(false);
            griditemsdeactivated++;
        }
    }


    public void BuildBlock(int GridBlock)
    {
        if (CurrentItem != null)
        {

            Vector3 pos = new Vector3(Grid[GridBlock].transform.position.x, Grid[GridBlock].transform.position.y + 10, Grid[GridBlock].transform.position.z);
            GameObject go = Instantiate(BlockTypes[0], pos, Quaternion.identity) as GameObject;
            StartCoroutine(TweenCube( go,Grid[GridBlock]));
            Grid[GridBlock] = go;
        }  
    }

    public IEnumerator TweenCube(GameObject tweener, GameObject GridBlock)
    {
        Vector3 brickpos = new Vector3(GridBlock.transform.position.x, GridBlock.transform.position.y + 1, GridBlock.transform.position.z);

        while (Vector3.Distance(tweener.transform.position, GridBlock.transform.position) > 1)
        {
            tweener.transform.Translate(Vector3.down * Time.deltaTime * 3);
            yield return new WaitForSeconds(.03F);
        }

        StopCoroutine("Tweener");
    }

}
