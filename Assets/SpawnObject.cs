using UnityEngine;
using System.Collections;

public class SpawnObject : MonoBehaviour {

	public GameObject chair;
	public GameObject table;
	public Camera cam;

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Spawn();
		}
	}

	void Spawn(){
		Vector3 spawn=cam.ScreenToWorldPoint (Input.mousePosition);
		spawn.z=0;
		Instantiate (chair, spawn, Quaternion.Euler (Vector3.zero));
	}
}
