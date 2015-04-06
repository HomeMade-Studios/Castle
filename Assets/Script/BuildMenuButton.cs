using UnityEngine;
using System.Collections;

public class BuildMenuButton : MonoBehaviour {
	
	public string objectName;
	GameObject gameController;
	// Use this for initialization
	void Start () {
		gameController = GameObject.FindGameObjectWithTag ("GameController");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setSpawnObject(){
		SpawnObject.SetSpawningObject(gameController.GetComponent<AllObjects>().GetObjectFromList (objectName));
	}
}
