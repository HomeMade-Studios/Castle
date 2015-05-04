using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;

public class ItemList : MonoBehaviour {
	
	public static List<ItemInfo> itemList = new List<ItemInfo>();

	void Start () {
		GetInfoFromFile ();
	}

	public static ItemInfo findItemInListByID(string itemID){
		ItemInfo selectedObject = new ItemInfo();
		for (int i = 0; i < itemList.Count; i++) {
			if(itemList[i].ID == itemID){
				selectedObject = itemList[i];
				break;
			}
		}
		return selectedObject;
	}

	public static List<ItemInfo> findItemsInListByType(string itemsType){
		List<ItemInfo> selectedObjects = new List<ItemInfo>();
		for (int i = 0; i < itemList.Count; i++) {
			if(itemList[i].ID.StartsWith(itemsType)){
				selectedObjects.Add(itemList[i]);
			}
		}
		return selectedObjects;
	}

	void GetInfoFromFile(){
		TextAsset itemInfoFile = Resources.Load("ItemInfo", typeof(TextAsset)) as TextAsset;
		int i = 0;
		string[] stringSeparators = new string[] { "\r\n" };
		foreach (string inputLine in itemInfoFile.text.Split (stringSeparators, StringSplitOptions.RemoveEmptyEntries).Skip(1)) {
			itemList.Add(new ItemInfo());
			SetInfo(inputLine, i);
			i++;
		}

	}

	void SetInfo(string inputLine, int i){
		int info = 0;
		foreach(string value in inputLine.Split('	')){
			switch(info){
			case 0:
				itemList[i].ID = value;
				break;
			
			case 1:
				itemList[i].Name = value;
				break;

			case 2:
				itemList[i].Description = value;
				break;

			case 3:
				itemList[i].Damage = Convert.ToInt32(value);
				break;

			case 4:
				itemList[i].Hp = Convert.ToInt32(value);
				break;

			case 5:
				itemList[i].GoldPrice = Convert.ToInt32(value);
				break;

			case 6:
				itemList[i].WoodPrice = Convert.ToInt32(value);
				break;

			case 7:
				itemList[i].StonePrice = Convert.ToInt32(value);
				break;

			case 8:
				itemList[i].MetalPrice = Convert.ToInt32(value);
				break;

			case 9:
				List<ItemNeeded> temp = new List<ItemNeeded>();
				foreach (string itemIDAndAmount in value.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries)){
					string itemNeededID = itemIDAndAmount.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries)[0];
					int itemNeededAmount = Convert.ToInt32(itemIDAndAmount.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries)[1]);
					temp.Add (new ItemNeeded(itemNeededID, itemNeededAmount));
				}
				itemList[i].ItemsNeeded = temp;
				break;
			}
			info++;
		}
		itemList [i].AmountInInventory = 1;
		itemList [i].GameObject = Resources.Load(itemList[i].ID, typeof(GameObject)) as GameObject;
		if (itemList [i].GameObject != null)
			itemList [i].Sprite = itemList [i].GameObject.GetComponent<SpriteRenderer> ().sprite;
	}
}