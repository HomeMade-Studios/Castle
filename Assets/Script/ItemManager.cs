using UnityEngine;
using System.Collections;

public class ItemManager : MonoBehaviour {

	static Transform managingItem;
	static Vector2 newItemCoord, oldItemCoord, touchCoord;
	static bool isItemNew;
	float touchTime;


	public void Update(){
		if (managingItem != null) {
			if (Input.touchCount > 0) {
				Touch touch = Input.GetTouch (0);
				switch (touch.phase) {
				case TouchPhase.Began:
					newItemCoord = managingItem.position;
					touchCoord = Camera.main.ScreenToWorldPoint (touch.position);
					touchTime = Time.time;
					break;

				case TouchPhase.Moved:
					newItemCoord.Set (newItemCoord.x + Camera.main.ScreenToWorldPoint (touch.position).x - touchCoord.x, newItemCoord.y + Camera.main.ScreenToWorldPoint (touch.position).y - touchCoord.y);
					;
					touchCoord = Camera.main.ScreenToWorldPoint (touch.position);
					break;

				case TouchPhase.Ended:
					if (Time.time - touchTime < 0.25)
						newItemCoord = touchCoord;
					break;
				}
			}
			managingItem.position = newItemCoord;
		}
	}

	public void Save(){
		managingItem.position = newItemCoord;
		managingItem = null;
		SwitchMode.SwitchToPlayMode();
	}

	public void Flip(){
		if (managingItem.rotation.y == 0)
			managingItem.rotation = Quaternion.Euler (new Vector3 (0, 180, 0));
		else
			managingItem.rotation = Quaternion.Euler (new Vector3(0,0,0));
	}

	public void Cancel(){
		if (isItemNew) {
			Destroy (managingItem.gameObject);
		} 
		else {
			managingItem.position = oldItemCoord;
		}
		managingItem = null;
		SwitchMode.SwitchToPlayMode();
	}

	public static void SetManagingItem (GameObject selectedItem, bool isNew){
		managingItem = selectedItem.transform ;
		oldItemCoord = managingItem.position;
		isItemNew = isNew;
	}
	
}
