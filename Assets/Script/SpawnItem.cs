using UnityEngine;
using System.Collections;

public class SpawnItem : MonoBehaviour {

	static GameObject spawningItem;
	public Camera cam;
	public static bool canBuild = true;

	void Update () {
		if (SwitchMode.GetGameMode() == "Build") {
			if(spawningItem != null && canBuild){
				if ((Input.GetMouseButtonDown (0)) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)) {
					Spawn ();
				}
			}
		}
	}
	 
	void Spawn(){
		Vector3 spawn = cam.ScreenToWorldPoint (Input.mousePosition);
		spawn.z = 0;
		Instantiate (spawningItem, spawn, Quaternion.Euler (Vector3.zero));
	}

	public static void SetSpawningObject( GameObject itemToSpawn){
		spawningItem = itemToSpawn;
	}

}
