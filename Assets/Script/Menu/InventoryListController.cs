using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InventoryListController : MonoBehaviour {

	public GameObject inventoryListButton , itemScrollContent;
	public InventoryItemInformationPanel itemInformationPanel;
	public Button filter1, filter2, filter3, filter4;
	string currentFilter;

	void OnDisable(){
		selectItem(null);
	}

	void OnEnable(){
		SetFilter ("0001");
	}

	public void SetFilter (string newFilter){
		currentFilter = newFilter;
		switch (currentFilter) {

		case "0001":
			filter1.interactable = false;
			filter2.interactable = true;
			filter3.interactable = true;
			filter4.interactable = true;
			break;

		case "0002":
			filter1.interactable = true;
			filter2.interactable = false;
			filter3.interactable = true;
			filter4.interactable = true;
			break;

		case "0003":
			filter1.interactable = true;
			filter2.interactable = true;
			filter3.interactable = false;
			filter4.interactable = true;
			break;

		case "0004":
			filter1.interactable = true;
			filter2.interactable = true;
			filter3.interactable = true;
			filter4.interactable = false;
			break;
		}
		UpdateInventoryItemList ();
		selectItem(null);
	}

	public void UpdateInventoryItemList(){
		Transform list = itemScrollContent.transform;
		List<ItemInfo> newList = ItemListController.findItemsInListByType (currentFilter);
		GameObject createdButton;
		
		foreach (Transform child in list) {		//delete all list
			GameObject.Destroy(child.gameObject);
		}
		
		foreach (ItemInfo itemInfo in newList){		//recreate the list
			if(itemInfo.AmountInInventory > 0){
				string localItemInfoID = itemInfo.ID;
				createdButton = Instantiate (inventoryListButton, new Vector3(0,0,0), Quaternion.identity) as GameObject;
				createdButton.transform.SetParent(list);
				createdButton.transform.localScale = new Vector3(1,1,1);
				createdButton.transform.FindChild("Item Name").GetComponent<Text>().text = itemInfo.Name;
				createdButton.transform.FindChild("Item Quantity").GetComponent<Text>().text = itemInfo.AmountInInventory.ToString();
				createdButton.GetComponent<Button>().onClick.AddListener(delegate{selectItem(localItemInfoID);}); //imposta la funzione sull'OnClick del bottone e il relativo parametro (referenceItemID)
				createdButton.transform.FindChild("Item Image").GetComponent<Image>().sprite = itemInfo.Sprite;
			}
		}
	}

	public void selectItem(string referenceItemID){
		itemInformationPanel.SetSelectedItem (referenceItemID);
	}
}
