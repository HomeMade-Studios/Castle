using UnityEngine;
using System.Collections;

public class SceneElements : MonoBehaviour {

	public GameObject menu, objectHud;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static GameObject GetMenu(){
		return GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneElements>().menu;
	}

	public static GameObject GetObjectHud(){
		return GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneElements>().objectHud;
	}
	                        
}
