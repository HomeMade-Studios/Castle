using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class ItemManager : MonoBehaviour {

    public Button saveButton;
	static Transform managingItem;
    static GridMovement itemGridMovement;
	static Vector2 oldItemCoord, newItemCoord, touchCoord;
	static bool isItemNew;
	float touchTime;


	public void Update(){
        if (managingItem != null)
        {
            checkOverlap();
            moveItem();
        }
            
	}

	public void Save(){
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
		oldItemCoord = newItemCoord = managingItem.position;
        itemGridMovement = managingItem.gameObject.GetComponent<GridMovement>();
		isItemNew = isNew;
	}
	
    void moveItem(){
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        newItemCoord = managingItem.position;
                        touchCoord = Camera.main.ScreenToWorldPoint(touch.position);
                        break;

                    case TouchPhase.Moved:
                        newItemCoord.Set(newItemCoord.x + Camera.main.ScreenToWorldPoint(touch.position).x - touchCoord.x, newItemCoord.y + Camera.main.ScreenToWorldPoint(touch.position).y - touchCoord.y);
                        touchCoord = Camera.main.ScreenToWorldPoint(touch.position);
                        break;

                    case TouchPhase.Ended:
                     
                        break;
                }
            }
            managingItem.position = newItemCoord;
        }
		
    }

    void checkOverlap()
    {
        if (itemGridMovement.OverlapAnotherObject())
        {
            saveButton.interactable = false;
        }
        else
        {
            saveButton.interactable = true;
        }

    }
}
