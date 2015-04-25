using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SwitchMode : MonoBehaviour {


	static GameObject playObjectsReference, buildObjectsReference;
	static string gameMode = "Play";
	public GameObject playObjects, buildObjects;


	void Start(){
		playObjectsReference = playObjects;
		buildObjectsReference = buildObjects;
		playObjectsReference.SetActive (true);
		buildObjectsReference.SetActive (false);
	}

	public static string GetGameMode(){
		return gameMode;
	}
	
	public static void SwitchToBuildMode(){
		playObjectsReference.SetActive (false);
		buildObjectsReference.SetActive (true);
		gameMode = "Build";
	}

	public static void SwitchToPlayMode(){
		playObjectsReference.SetActive (true);
		buildObjectsReference.SetActive (false);
		gameMode = "Play";
	}
}
