using UnityEngine;
using System.Collections;
using System;

public class Gathering : MonoBehaviour {

	public int alterTime;
	public int WhatGathered;
	public double gathered;
	bool changeGather;
	public bool reset;
	WWW timeSite;

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
			gathered =PlayerPrefs.GetInt("TmpStone");
			break;
		case 2:
			gathered =PlayerPrefs.GetInt("TmpWood");
			break;
		}
	}

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
		timeSite = new WWW("http://homemadestudios.altervista.org/time/time.php");
		yield return timeSite;
		alterTime = Convert.ToInt32(timeSite.text);
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
					PlayerPrefs.SetInt("TmpStone",(int)(gathered));
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
		PlayerPrefs.SetInt("TmpStone",0);
	}

	public void Gather(){
		switch (WhatGathered) {
		case 0:
			break;
		case 1:
			PlayerPrefs.SetInt("Stone",PlayerPrefs.GetInt("Stone")+(int)(gathered));
			break;
		case 2:
			PlayerPrefs.SetInt("Wood",PlayerPrefs.GetInt("Wood")+(int)(gathered));
			break;
		}
		/*PlayerPrefs.SetInt("Stone",PlayerPrefs.GetInt("Stone")+(int)(gathered));
		PlayerPrefs.SetInt("Wood",PlayerPrefs.GetInt("Wood")+(int)(gathered));*/
		ResetTmpRes ();
		gathered = 0;
	}

	public int GetGathered(){
		return (int) gathered;
	}

	public int GetPosition(){
		return WhatGathered;
	}

}
