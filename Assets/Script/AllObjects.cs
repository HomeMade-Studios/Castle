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

	public GameObject GetObjectFromList(string objectName){
		print ("chair");
		switch (objectName) {
		case "chair":

			return chair;
		case "table":
			return table;
		}

		return null;
	}
}
