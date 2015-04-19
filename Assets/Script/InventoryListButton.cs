using UnityEngine;
using System.Collections;

public class InventoryListButton : MonoBehaviour {

	public string referenceItemID;

	public void selectItem(){
		if(referenceItemID != null)
			InventoryItemInformationPanel.SetSelectedItem (referenceItemID);
	}



}
