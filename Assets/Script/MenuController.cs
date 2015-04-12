using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {
	
	public GameObject inventoryMenu, craftMenu;

	void Start (){

	}

	public void OpenInventoryMenu(){
		inventoryMenu.SetActive (true);
		craftMenu.SetActive (false);
	}

	public void OpenBuildMenu(){
		inventoryMenu.SetActive (false);
		craftMenu.SetActive (false);
	}

	public void OpenCraftMenu(){
		craftMenu.SetActive (true);
		inventoryMenu.SetActive (false);
	}

	public void CloseAllMenu(){

	}



}
