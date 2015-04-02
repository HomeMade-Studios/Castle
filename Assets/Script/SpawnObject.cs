using UnityEngine;
using System.Collections;

public class SpawnObject : MonoBehaviour {

	public GameObject spawningObject;
	GameObject spawnedObject;
	public Camera cam;
	public bool BuildMode;

	void Update () {
		if (Input.GetMouseButtonDown (0)&&spawningObject!=null&&BuildMode) {
			Spawn();
		}
	}
	 
	void Spawn(){
		Vector3 spawn=cam.ScreenToWorldPoint (Input.mousePosition);
		spawn.z=0;
		Instantiate (spawningObject, spawn, Quaternion.Euler (Vector3.zero));
	}

	public void SetSpawningObject( GameObject ObjectToSpawn){
		spawningObject = ObjectToSpawn;
	}
}
