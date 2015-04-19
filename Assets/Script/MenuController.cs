using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MenuController : MonoBehaviour {
	
	public GameObject menu, inventoryPanel, craftPanel, inventoryItemList;
	public GameObject inventoryListButton;

	void Start (){
		UpdateInventoryItemList (inventoryItemList.transform);
	}

	public void OpenInventoryPanel(){
		inventoryPanel.SetActive (true);
		craftPanel.SetActive (false);
		UpdateInventoryItemList (inventoryItemList.transform);
	}

	public void OpenCraftPanel(){
		craftPanel.SetActive (true);
		inventoryPanel.SetActive (false);
	}

	public void OpenCloseMenu(){
		menu.SetActive (!menu.activeSelf);
	}

	void UpdateInventoryItemList(Transform list){
		List<ItemInfo> newList = ItemListController.findItemsInListByType ("0001");
		GameObject createdButton;

		foreach (Transform child in list) {		//delete all list
			GameObject.Destroy(child.gameObject);
		}

		foreach (ItemInfo itemInfo in newList){			//recreate the list
			createdButton = Instantiate (inventoryListButton, new Vector3(0,0,0), Quaternion.identity) as GameObject;
			createdButton.transform.SetParent(list);
			createdButton.transform.localScale = new Vector3(1,1,1);
			createdButton.transform.FindChild("ItemName").GetComponent<Text>().text = itemInfo.Name;
			createdButton.transform.FindChild("ItemQuantity").GetComponent<Text>().text = itemInfo.AmountInInventory.ToString();
			createdButton.GetComponent<InventoryListButton>().referenceItemID = itemInfo.ID;
		}
	}



}
