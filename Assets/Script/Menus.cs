using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menus : MonoBehaviour {
	
	public GameObject menu, inventoryPanel, craftPanel;	
	public Button inventoryButton, craftButton;

	public void OpenInventoryPanel(){
		inventoryPanel.SetActive (true);
		craftPanel.SetActive (false);
		inventoryButton.interactable = false;
		craftButton.interactable = true;
	}

	public void OpenCraftPanel(){
		craftPanel.SetActive (true);
		inventoryPanel.SetActive (false);
		inventoryButton.interactable = true;
		craftButton.interactable = false;
	}

	public void OpenCloseMenu(){
		if (!menu.activeSelf) {
			menu.SetActive (true);
			OpenInventoryPanel();
		} else {
			craftPanel.SetActive (false);
			inventoryPanel.SetActive (false);
			menu.SetActive (false);
		}

	}

	public void OpenMap(){
		Application.LoadLevel ("Map");
	}
}
