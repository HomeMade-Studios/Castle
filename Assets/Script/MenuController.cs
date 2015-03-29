using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public Animator anim;

	public void OpenInventory(){
		bool temp = anim.GetBool ("Open");
		if (!temp) {
			anim.SetBool ("Open", true);
		}
		else {
			anim.SetBool("Open",false);
		}
	}

}
