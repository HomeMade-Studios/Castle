using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ItemInfo {

	private string itemID;
	private string itemName;
	private string itemDescription;
	private int itemDamage;
	private int itemHp;
	private int goldPrice;
	private int woodPrice;
	private int stonePrice;
	private int metalPrice;
	private List<ItemNeeded> itemsNeeded;
	private int itemAmountInInventory;
	private GameObject gameObject;
	private Sprite sprite;
	
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

	public List<ItemNeeded> ItemsNeeded {
		
		get { return itemsNeeded; }
		
		set { itemsNeeded = value; }
		
	}

	public int AmountInInventory {
		
		get { return itemAmountInInventory; }
		
		set { itemAmountInInventory = value; }
		
	}

	public GameObject GameObject {
		
		get { return gameObject; }
		
		set { gameObject = value; }
		
	}

	public Sprite Sprite {
		
		get { return sprite; }
		
		set { sprite = value; }
		
	}
}

public struct ItemNeeded{
	private string itemID;
	private int amount;

	public ItemNeeded(string newItemID, int newAmount){
		itemID = newItemID;
		amount = newAmount;
	}

	public string ItemID {
		
		get { return itemID; }
		
		set { itemID = value; }
		
	}

	public int Amount {
		
		get { return amount; }
		
		set { amount = value; }
		
	}
}