using UnityEngine;
using System.Collections;
using System;

public class ItemInfo {

	private string itemID;
	private string itemName;
	private string itemDescription;
	private int itemPrice;
	private int itemDamage;
	private int itemHp;
	private int itemAmountInInventory;
	private GameObject gameObject;

	public ItemInfo(){
		itemID = "UNDEFINED";
		itemName = "UNDEFINED";
		itemDescription = "UNDEFINED";
		itemPrice = 0;
		itemDamage = 0;
		itemHp = 0;
		itemAmountInInventory = 0;
		gameObject = null;
	}
	
	public string ID {
		
		get { return itemID; }
		
		set { itemID = value; }

	}

	public string Name {
		
		get { return itemName; }
		
		set { itemName = value; }
		
	}

	public string Description {
		
		get { return itemDescription; }
		
		set { itemDescription = value; }
		
	}

	public int Price {
		
		get { return itemPrice; }
		
		set { itemPrice = value; }
		
	}

	public int Damage {
		
		get { return itemDamage; }
		
		set { itemDamage = value; }
		
	}

	public int Hp {
		
		get { return itemHp; }
		
		set { itemHp = value; }
		
	}

	public int AmountInInventory {
		
		get { return itemAmountInInventory; }
		
		set { itemAmountInInventory = value; }
		
	}

	public GameObject GameObject {
		
		get { return gameObject; }
		
		set { gameObject = value; }
		
	}
	
}