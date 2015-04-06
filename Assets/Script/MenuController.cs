using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public Animator anim;
	public GameObject buildMenu, inventoryMenu, craftMenu;

	void Start (){

	}

	public void OpenInventoryMenu(){
		inventoryMenu.SetActive (true);
		buildMenu.SetActive (false);
		craftMenu.SetActive (false);
		anim.SetBool ("Open", true);
	}

	public void OpenBuildMenu(){
		buildMenu.SetActive (true);
		inventoryMenu.SetActive (false);
		craftMenu.SetActive (false);
		anim.SetBool ("Open", true);
	}

	public void OpenCraftMenu(){
		craftMenu.SetActive (true);
		buildMenu.SetActive (false);
		inventoryMenu.SetActive (false);
		anim.SetBool ("Open", true);
	}

	public void CloseAllMenu(){
		anim.SetBool ("Open", false);
	}



}
