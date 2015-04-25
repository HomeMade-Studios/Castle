using UnityEngine;
using System.Collections;

public class ItemManager : MonoBehaviour {

	static GameObject managingItem;

	void Start(){
		SpawnItem.canBuild = false;
	}
	
	public void SaveObject(){
		gameObject.GetComponent<Rigidbody2D> ().gravityScale = 50;
		gameObject.GetComponent<Collider2D> ().isTrigger = false;
		SpawnItem.canBuild = true;
		SpawnItem.SetSpawningObject (null);
	}

	public void Flip(){
		if (transform.rotation.y == 0)
			transform.rotation = Quaternion.Euler (new Vector3 (0, 180, 0));
		else
			transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
		GetComponentInChildren<RectTransform>().rotation = Quaternion.Euler(new Vector3(0,0,0));
	}

	public void Delete(){
		SpawnItem.canBuild = true;
		SpawnItem.SetSpawningObject (null);
		Destroy (this.gameObject);
	}

	public static void SetManagingItem(GameObject selectedItem){
		managingItem = selectedItem;
	}
	
}
