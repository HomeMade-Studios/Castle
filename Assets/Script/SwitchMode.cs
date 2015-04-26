using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SwitchMode : MonoBehaviour {


	static GameObject playObjectsReference, buildObjectsReference;
	static bool buildMode = false;
	public GameObject playObjects, buildObjects;


	void Start(){
		playObjectsReference = playObjects;
		buildObjectsReference = buildObjects;
		playObjectsReference.SetActive (true);
		buildObjectsReference.SetActive (false);
	}

	public static bool BuildMode {
		
		get { return buildMode; }
		
	}

	public static void SwitchToBuildMode(){
		playObjectsReference.SetActive (false);
		buildObjectsReference.SetActive (true);
		buildMode = true;
	}

	public static void SwitchToPlayMode(){
		playObjectsReference.SetActive (true);
		buildObjectsReference.SetActive (false);
		buildMode = false;
	}
}
