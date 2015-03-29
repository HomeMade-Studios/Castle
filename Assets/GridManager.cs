using UnityEngine;
using System.Collections;

public class GridManager : MonoBehaviour {

	public GameObject Cell;
	float CellSize=16;

	void Start () {
		Create ();
	}

	public void Create(){
		for (int i=0; i<=85; i++) {
			for (int j=0; j<=45; j++) {
				Instantiate(Cell,new Vector3(CellSize*i-660,j*CellSize-105),this.transform.rotation);
			}
		}
	}
}
