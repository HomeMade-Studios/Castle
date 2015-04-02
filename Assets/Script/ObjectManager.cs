using UnityEngine;
using System.Collections;

public class ObjectManager : MonoBehaviour {
	
	public void SaveObject(){
		gameObject.GetComponent<Rigidbody2D> ().gravityScale = 50;
		gameObject.GetComponent<Collider2D> ().isTrigger = false;
	}

	public void Flip(){
		transform.rotation.eulerAngles.Set (
			transform.rotation.eulerAngles.x, 
			transform.rotation.eulerAngles.y * -1, 
			transform.rotation.eulerAngles.x);
	}

	public void Delete(){
		Destroy (this.gameObject);
	}
}
