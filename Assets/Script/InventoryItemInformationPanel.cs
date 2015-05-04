using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryItemInformationPanel : MonoBehaviour {

	public Text itemName, itemDescription, itemHp, itemDamage;
	public Button buildButton;
	static string selectedItemID;
	static ItemInfo selectedItemInformation;

	void Update () {
		UpdateInformation ();
	}

	void UpdateInformation(){
		if (selectedItemID != null) {
			itemName.text = selectedItemInformation.Name;
			itemDescription.text = selectedItemInformation.Description;
			itemHp.text = "Hp: " + selectedItemInformation.Hp.ToString ();
			itemDamage.text = "Damage: " + selectedItemInformation.Damage.ToString ();
			buildButton.interactable = true;
		} else {
			NullSelectedItem();
		}
	}

	public void Build(){
		SpawnItem.SpawnAnItem(ItemList.findItemInListByID (selectedItemID).GameObject);
		SwitchMode.SwitchToBuildMode();
	}

	public void SetSelectedItem(string itemID){
		selectedItemID = itemID;
		if (selectedItemID != null)
			selectedItemInformation = ItemList.findItemInListByID (selectedItemID);
		else
			NullSelectedItem ();
	}

	void NullSelectedItem(){
		itemName.text = null;
		itemDescription.text = null;
		itemHp.text = null;
		itemDamage.text = null;
		buildButton.interactable = false;
	}
}
