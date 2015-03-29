using UnityEngine;
using System.Collections;

public class GridManager : MonoBehaviour {

	public GameObject Cell;
	float CellSize=32;

	void Start () {
		Create ();
	}

	public void Create(){
		for (int i=0; i<=43; i++) {
			for (int j=0; j<=22; j++) {
				Instantiate(Cell,new Vector3(CellSize*i-687,j*CellSize-113),this.transform.rotation);
			}
		}
	}
}
