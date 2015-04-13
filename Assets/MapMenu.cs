﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MapMenu : MonoBehaviour {

	public Animator Character;
	public Text Pos,resPerMin,ResMax,ResAcc,AtWork;
	public int Position;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		switch (Position) {
		case 0:
			SetDefault();
			break;
		case 1:
			SetCave();
			break;
		case 2:
			SetForest();
			break;
		}
	}

	void SetDefault(){
		Pos.text="Your Castle";
		resPerMin.text="Chi dorme non piglia pesci(ma banane in culo)";
		ResMax.text="";
		ResAcc.text = "";
	}

	void SetCave(){
		Pos.text="Cave";
		resPerMin.text="0.5 Rock/min";
		ResMax.text="La cariola può contenere 480 rocce";
		ResAcc.text = "Non va ancora un cazzo";
	}

	void SetForest(){
		Pos.text="Forest";
		resPerMin.text="10 Wood/min";
		ResMax.text="La cariola può contenere 2400 legno";
		ResAcc.text = "Non va ancora un cazzo";
	}

	public void StartAnim(){
		switch (Position) {
		case 0:
			Character.SetBool("Forest",false);
			Character.SetBool("Cave",false);
			break;
		case 1:
			Character.SetBool("Forest",false);
			Character.SetBool("Cave",true);
			break;
		case 2:
			Character.SetBool("Forest",true);
			Character.SetBool("Cave",false);
			break;
		}
	}

	public void SetPosition(int pos){
		Position = pos;
	}
}
