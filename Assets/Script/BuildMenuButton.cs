using UnityEngine;
using System.Collections;

public class BuildMenuButton : MonoBehaviour {
	
	public string objectName;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setSpawnObject(){
		AllObjects.SelectObjectToSpawnFromList (objectName);
	}
}
