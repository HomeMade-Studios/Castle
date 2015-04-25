using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

public class ItemListController : MonoBehaviour {
	
	public static ItemInfo[] itemList = new ItemInfo[2];

	void Start () {
		GetInfoFromFile ();
	}

	public static ItemInfo findItemInListByID(string itemID){
		ItemInfo selectedObject = new ItemInfo();
		for (int i = 0; i < itemList.Length; i++) {
			if(itemList[i].ID == itemID){
				selectedObject = itemList[i];
				break;
			}
		}
		return selectedObject;
	}

	public static List<ItemInfo> findItemsInListByType(string itemsType){
		List<ItemInfo> selectedObjects = new List<ItemInfo>();
		for (int i = 0; i < itemList.Length; i++) {
			if(itemList[i].ID.StartsWith(itemsType)){
				selectedObjects.Add(itemList[i]);
			}
		}
		return selectedObjects;
	}

	void GetInfoFromFile(){
		TextAsset itemInfoFile = Resources.Load("ItemInfo", typeof(TextAsset)) as TextAsset;
		string[] inputLine = itemInfoFile.text.Split("\n"[0]);
		for (int i = 0; i < itemList.Length; i++) {
			SetInfo(inputLine[i], i);
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
				itemList[i].Price = Convert.ToInt32(value);
				break;

				case 4:
				itemList[i].Damage = Convert.ToInt32(value);
				break;

				case 5:
				itemList[i].Hp = Convert.ToInt32(value);
				break;
			}
			info++;
		}
		itemList[i].AmountInInventory = 1;
		itemList[i].GameObject = Resources.Load(itemList[i].ID, typeof(GameObject)) as GameObject;
	}
}




