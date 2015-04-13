using UnityEngine;
using System.Collections;
using System;

public class Gathering : MonoBehaviour {

	Ping googlePing;
	float time;
	public long alterTime;

	// Use this for initialization
	void Start () {
		time = Time.time;
		InvokeRepeating ("UpdateTime", 0, 60);
	}
	
	// Update is called once per frame
	void UpdateTime () {
		StartCoroutine("getTime");
	}

	void GooglePing(){
		googlePing = new Ping ("8.8.8.8");
	}

	IEnumerator getTime()
	{
		WWW www = new WWW("http://homemadestudios.altervista.org/time/time.php");
		yield return www;
		alterTime= Convert.ToInt64(www.text);
		print("Time on the server is now: " + www.text);
	}

}
