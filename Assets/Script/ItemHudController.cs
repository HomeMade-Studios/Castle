using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemHudController : MonoBehaviour {

	public Text objectName, objectDescription, objectHp, objectDamage;
	static ItemInfo selectedItemInfo;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		SetInformation ();
	}

	void SetInformation(){
		objectName.text = selectedItemInfo.Name;
		objectDescription.text = selectedItemInfo.Description;
		objectHp.text = "HP: " + selectedItemInfo.Hp.ToString();
		objectDamage.text = "Damage: " + selectedItemInfo.Damage.ToString();
	}

	public static void SetSelectedItem(string selectedItemID){
		selectedItemInfo = ItemListController.findItemInListByID(selectedItemID);
	}

}
