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
		transform.rotation.Set (
			transform.rotation.x, 
			180f, 
			transform.rotation.z,
			transform.rotation.w);
	}

	public void Delete(){
		Destroy (this.gameObject);
	}
}
