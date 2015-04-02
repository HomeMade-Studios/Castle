using UnityEngine;
using System.Collections;

public class GridManager : MonoBehaviour {

	public GameObject Cell;
	float CellSize=32;
	public bool ConstructMode;
	public Sprite Wall;
	public Camera cam;

	void Start () {
		cam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ();
		Create ();
	}

	void Update(){
		if (ConstructMode && Input.GetMouseButtonDown (0)) {
			ChangeWall();
		}
	}

	public void Create(){
		for (int i=0; i<=43; i++) {
			for (int j=0; j<=22; j++) {
				Instantiate(Cell,new Vector3(CellSize*i-687,j*CellSize+15),this.transform.rotation);
			}
		}
	}

	public void ChangeWall(){
		RaycastHit2D tmp= Physics2D.Raycast (cam.ScreenToWorldPoint(Input.mousePosition),Vector2.up);
		if(tmp.transform.gameObject.tag=="Cell"){
			if(tmp.transform.gameObject.GetComponent<SpriteRenderer>().sprite==null){
				tmp.transform.gameObject.GetComponent<SpriteRenderer>().sprite = Wall;
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
