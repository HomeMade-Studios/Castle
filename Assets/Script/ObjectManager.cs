using UnityEngine;
using System.Collections;

public class ObjectManager : MonoBehaviour {

	void Start(){
		SpawnObject.DisableBuildMode ();
	}
	
	public void SaveObject(){
		this.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 50;
		this.gameObject.GetComponent<Collider2D> ().isTrigger = false;
		SpawnObject.EnableBuildMode ();
		print ("Pene");
	}

	public void Flip(){
		transform.rotation.eulerAngles.Set (
			transform.rotation.eulerAngles.x, 
			transform.rotation.eulerAngles.y * -1, 
			transform.rotation.eulerAngles.z);
	}

	public void Delete(){
		Destroy (this.gameObject);
	}
}
