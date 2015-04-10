using UnityEngine;
using System.Collections;

public class ObjectManager : MonoBehaviour {

	GameObject objectHud;
	public GameObject save,flip,delete;


	void Start(){
		SpawnObject.DisableBuildMode ();
		objectHud = SceneElements.GetObjectHud();
	}
	
	public void SaveObject(){
		gameObject.GetComponent<Rigidbody2D> ().gravityScale = 50;
		gameObject.GetComponent<Collider2D> ().isTrigger = false;
		save.SetActive (false);
		flip.SetActive (false);
		delete.SetActive (false);
		SpawnObject.EnableBuildMode ();
	}

	public void Flip(){
		if (transform.rotation.y == 0)
			transform.rotation = Quaternion.Euler (new Vector3 (0, 180, 0));
		else
			transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
		GetComponentInChildren<RectTransform>().rotation = Quaternion.Euler(new Vector3(0,0,0));
	}

	public void Delete(){
		SpawnObject.EnableBuildMode ();
		Destroy (this.gameObject);
	}

	public void ActiveObjectHud(){
		objectHud.SetActive(true);
		ObjectHudController.SetSelectedObject (this.gameObject);
	}
}
