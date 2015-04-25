using UnityEngine;
using System.Collections;

public class ItemManager : MonoBehaviour {

	static GameObject managingItem;

	public void Save(){
		managingItem.GetComponent<Rigidbody2D> ().gravityScale = 50;
		managingItem.GetComponent<Collider2D> ().isTrigger = false;
		managingItem = null;
	}

	public void Flip(){
		if (managingItem.transform.rotation.y == 0)
			managingItem.transform.rotation = Quaternion.Euler (new Vector3 (0, 180, 0));
		else
			managingItem.transform.rotation = Quaternion.Euler (new Vector3(0,0,0));
	}

	public void Cancel(){
		Destroy (managingItem);
		managingItem = null;
	}

	public static void SetManagingItem (GameObject selectedItem){
		managingItem = selectedItem;
		managingItem.GetComponent<Rigidbody2D> ().gravityScale = 0;
		managingItem.GetComponent<Collider2D> ().isTrigger = true;
	}
	
}
