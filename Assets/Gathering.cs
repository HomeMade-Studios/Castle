using UnityEngine;
using System.Collections;
using System;

public class Gathering : MonoBehaviour {

	public int alterTime;
	public int WhatGathered;
	public double gathered;
	bool changeGather;
	public bool reset;
	WWW www;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("UpdateTime", 0.01f, 10);
		WhatGathered = PlayerPrefs.GetInt ("GatherPos");
		print ("Time:" + alterTime);
		switch (WhatGathered) {
		case 0:
			gathered = 0;
			break;
		case 1:
			gathered =PlayerPrefs.GetInt("TmpRock");
			break;
		case 2:
			gathered =PlayerPrefs.GetInt("TmpWood");
			break;
		}
	}
	
	// Update is called once per frame
	void UpdateTime () {
		int tmpGatherPos = PlayerPrefs.GetInt ("GatherPos");
		if (WhatGathered != tmpGatherPos) {
			WhatGathered = tmpGatherPos;
			changeGather=true;
		}
		StartCoroutine("getTime");

	}

	IEnumerator getTime()
	{
		www = new WWW("http://homemadestudios.altervista.org/time/time.php");
		yield return www;
		alterTime= Convert.ToInt32(www.text);
		CalcGathered ();

	}

	void CalcGathered(){
		double pastedTime = alterTime - PlayerPrefs.GetInt ("LastTime");
		print ("Pasted time:"+(int)pastedTime+"="+alterTime+"-"+PlayerPrefs.GetInt ("LastTime"));
		if (alterTime > 0) {
			if (changeGather) {
				gathered = 0;
				ResetTmpRes();
			}
			if(alterTime!=(int)pastedTime){
				switch (WhatGathered) {
				case 0:
					gathered += 0;
					break;
				case 1:
					gathered += (pastedTime/60);
					if(gathered>=480)
						gathered=480;
					PlayerPrefs.SetInt("TmpRock",(int)(gathered));
					break;
				case 2:
						gathered += (pastedTime/6);
					if(gathered>=2400)
						gathered=2400;
					PlayerPrefs.SetInt("TmpWood",(int)(gathered));
					break;
				}
			}
			PlayerPrefs.SetInt ("LastTime", alterTime);
		}
	}

	public void ResetTmpRes(){
		PlayerPrefs.SetInt("TmpWood",0);
		PlayerPrefs.SetInt("TmpRock",0);
	}

	public void Gather(){
		switch (WhatGathered) {
		case 0:
			break;
		case 1:
			PlayerPrefs.SetInt("Rock",PlayerPrefs.GetInt("Rock")+(int)(gathered));
			break;
		case 2:
			PlayerPrefs.SetInt("Wood",PlayerPrefs.GetInt("Wood")+(int)(gathered));
			break;
		}
		gathered = 0;
	}

	public int GetGathered(){
		return (int) gathered;
	}

}
