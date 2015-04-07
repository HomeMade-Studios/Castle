using UnityEngine;
using System.Collections;

public class AllObjects : MonoBehaviour {

	public GameObject chair, table;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void SelectObjectToSpawnFromList(string objectName){
		SpawnObject.SetSpawningObject(GameObject.FindGameObjectWithTag("GameController").GetComponent<AllObjects>().ReturnObjectFromList(objectName));
	}

	GameObject ReturnObjectFromList(string objectName){
		switch (objectName) {
			case "chair":
				return chair;
			case "table":
				return table;
		}
		return null;
	}
}
