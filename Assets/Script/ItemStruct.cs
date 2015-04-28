using UnityEngine;
using System.Collections;
using System;

public struct ItemInfo {

	private string itemID;
	private string itemName;
	private string itemDescription;
	private int itemDamage;
	private int itemHp;
	private int goldPrice;
	private int woodPrice;
	private int stonePrice;
	private int metalPrice;
	private int itemAmountInInventory;
	private GameObject gameObject;
	
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

	public int Damage {
		
		get { return itemDamage; }
		
		set { itemDamage = value; }
		
	}

	public int Hp {
		
		get { return itemHp; }
		
		set { itemHp = value; }
		
	}

	public int GoldPrice {
		
		get { return goldPrice; }
		
		set { goldPrice = value; }
		
	}

	public int WoodPrice {
		
		get { return woodPrice; }
		
		set { woodPrice = value; }
		
	}

	public int StonePrice {
		
		get { return stonePrice; }
		
		set { stonePrice = value; }
		
	}

	public int MetalPrice {
		
		get { return metalPrice; }
		
		set { metalPrice = value; }
		
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