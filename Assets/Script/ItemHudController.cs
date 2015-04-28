using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemHudController : MonoBehaviour {

	public Text itemName, itemDescription, itemHp, itemDamage;
	static ItemInfo selectedItemInfo;

	void Update(){
		SetInformation ();
	}

	void SetInformation(){
		itemName.text = selectedItemInfo.Name;
		itemDescription.text = selectedItemInfo.Description;
		itemHp.text = "HP: " + selectedItemInfo.Hp.ToString();
		itemDamage.text = "Damage: " + selectedItemInfo.Damage.ToString();
	}

	public static void SetSelectedItem(string selectedItemID){
		selectedItemInfo = ItemListController.findItemInListByID(selectedItemID);
	}

}
