using UnityEngine;
using System.Collections;

public class SceneElements : MonoBehaviour {

	public GameObject menu, objectHud;

	public static GameObject GetMenu(){
		return GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneElements>().menu;
	}

	public static GameObject GetObjectHud(){
		return GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneElements>().objectHud;
	}
	                        
}
