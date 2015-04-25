using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ObjectHudController : MonoBehaviour {

	public Text objectName, objectDescription, objectHp, objectDamage;
	static ObjectInformation selectedObject;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		SetInformation ();
	}

	public static void SetSelectedObject(GameObject sendedObject){
		selectedObject = sendedObject.GetComponent<ObjectInformation>();
	}

	void SetInformation(){
		objectName.text = selectedObject.GetId ().ToString ();
		objectDescription.text = selectedObject.GetDescription ().ToString();
		objectHp.text = "HP: " + selectedObject.GetHp ().ToString();
		objectDamage.text = "Damage: " + selectedObject.GetDamage ().ToString();
	}


}
