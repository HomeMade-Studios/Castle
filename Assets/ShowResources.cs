using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowResources : MonoBehaviour {

	public string Res;
	public Text txt;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("UpdateResource", 0.01f, 1);
	}
	void UpdateResource () {
		txt.text=PlayerPrefs.GetInt(Res)+" "+Res;
	}
}
