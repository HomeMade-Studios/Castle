using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuController : MonoBehaviour {
	
	public GameObject menu, inventoryPanel, craftPanel;	

	public void OpenInventoryPanel(){
		inventoryPanel.SetActive (true);
		craftPanel.SetActive (false);
	}

	public void OpenCraftPanel(){
		craftPanel.SetActive (true);
		inventoryPanel.SetActive (false);
	}

	public void OpenCloseMenu(){
		menu.SetActive (true);
		craftPanel.SetActive (false);
		inventoryPanel.SetActive (true);
	}

	public void CloseMenu(){
		craftPanel.SetActive (false);
		inventoryPanel.SetActive (false);
		menu.SetActive (false);
	}





}
