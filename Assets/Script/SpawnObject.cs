using UnityEngine;
using System.Collections;

public class SpawnObject : MonoBehaviour {

	static GameObject spawningObject;
	GameObject spawnedObject;
	public Camera cam;
	public bool BuildMode;

	void Update () {
		if (Input.GetMouseButtonDown (0)&&spawningObject!=null) {
			Spawn();
		}
	}
	 
	void Spawn(){
		Vector3 spawn=cam.ScreenToWorldPoint (Input.mousePosition);
		spawn.z=0;
		spawnedObject = (GameObject)Instantiate (spawningObject, spawn, Quaternion.Euler (Vector3.zero));
	}

	public void SaveSpawnedObject(){
		spawnedObject.GetComponent<Rigidbody2D> ().gravityScale = 50;
		spawnedObject.GetComponent<Collider2D> ().isTrigger = false;
	}

	public static void SetSpawningObject(GameObject ObjectToSpawn){
		spawningObject = ObjectToSpawn;
	}
}
