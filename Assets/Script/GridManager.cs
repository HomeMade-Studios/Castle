using UnityEngine;
using System.Collections;

public class GridManager : MonoBehaviour {

	public Transform grid;
	public GameObject cell;
	public int cellSize, col, row;
	public Sprite wall;
	public Camera cam;

	void Start () {
		cam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ();
		CreateGrid ();
	}

	void Update(){
		if (SwitchMode.BuildMode && Input.GetMouseButtonDown (0)) {
			//ChangeWall();
		}
	}

	public void CreateGrid(){
		Vector3 coord = new Vector3 (0,0,0);
		for (int i=0; i<row; i++) {
			for (int j=0; j<col; j++) {
				coord = new Vector3(-cellSize * (col / 2) + cellSize * j, cellSize*i, 0);
				GameObject temp = Instantiate(cell, coord, Quaternion.Euler(0,0,0)) as GameObject;
				temp.transform.SetParent(grid);
			}
		}
	}

	public void ChangeWall(){
		RaycastHit2D tmp= Physics2D.Raycast (cam.ScreenToWorldPoint(Input.mousePosition),Vector2.up);
		if(tmp.transform.gameObject.tag=="Cell"){
			if(tmp.transform.gameObject.GetComponent<SpriteRenderer>().sprite==null){
				tmp.transform.gameObject.GetComponent<SpriteRenderer>().sprite = wall;
				print("Lecose");
			}
			else{
				if(tmp.transform.FindChild("Delete").gameObject.activeInHierarchy){
					tmp.transform.gameObject.GetComponent<SpriteRenderer>().sprite = null;
					tmp.transform.FindChild("Delete").gameObject.SetActive(false);
				}
				else{
					tmp.transform.FindChild("Delete").gameObject.SetActive(true);
				}
			}
		}
	}
}
