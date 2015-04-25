using UnityEngine;
using System.Collections;

public class SpawnObject : MonoBehaviour {

	public static GameObject spawningObject;
	public GameObject spawnedObject;
	public Camera cam;
	public static bool canBuild = true;

	void Update () {
		if (SwitchMode.gameMode == "Build") {
			if(spawningObject != null && canBuild){
				if ((Input.GetMouseButtonDown (0)) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)) {
					Spawn ();
				}
			}
		}
	}
	 
	void Spawn(){
		Vector3 spawn = cam.ScreenToWorldPoint (Input.mousePosition);
		spawn.z = 0;
		Instantiate (spawningObject, spawn, Quaternion.Euler (Vector3.zero));
	}

	public static void SetSpawningObject( GameObject ObjectToSpawn){
		spawningObject = ObjectToSpawn;
	}

}
