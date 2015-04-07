using UnityEngine;
using System.Collections;

public class ObjectManager : MonoBehaviour {

	void Start(){
		SpawnObject.DisableBuildMode ();
	}
	
	public void SaveObject(){
		gameObject.GetComponent<Rigidbody2D> ().gravityScale = 50;
		gameObject.GetComponent<Collider2D> ().isTrigger = false;
		SpawnObject.EnableBuildMode ();
	}

	public void Flip(){
		transform.rotation.Set (
			transform.rotation.x, 
			180f, 
			transform.rotation.z,
			transform.rotation.w);
	}

	public void Delete(){
		SpawnObject.EnableBuildMode ();
		Destroy (this.gameObject);
	}
}
