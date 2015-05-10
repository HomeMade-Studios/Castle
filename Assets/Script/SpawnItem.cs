using UnityEngine;
using System.Collections;

public class SpawnItem : MonoBehaviour {
	 
	public static void SpawnAnItem(GameObject itemToSpawn){
		Camera cam = FindObjectOfType (typeof(Camera)) as Camera;
		Vector3 spawnPoint = cam.ScreenToWorldPoint (cam.pixelRect.center);
		spawnPoint.z = 0;
		ItemManager.SetManagingItem(Instantiate (itemToSpawn, spawnPoint, Quaternion.Euler(0,0,0)) as GameObject, true);
	}
}