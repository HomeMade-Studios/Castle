using UnityEngine;
using System.Collections;

public class BuildMenuButton : MonoBehaviour {
	
	public string objectName;

	public void setSpawnObject(){
		AllObjects.SelectObjectToSpawnFromList (objectName);
	}
}
