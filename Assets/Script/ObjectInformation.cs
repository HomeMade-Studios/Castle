using UnityEngine;
using System.Collections;

public class ObjectInformation : MonoBehaviour {

	public int price, hp, damage;
	public string id, description;

	public int GetPrice(){
		return price;
	}

	public int GetHp(){
		return hp;
	}

	public int GetDamage(){
		return damage;
	}
	
	public string GetId(){
		return id;
	}

	public string GetDescription(){
		return description;
	}

}
