using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.IO;

public class ItemList : MonoBehaviour {

	static int numberOfItems = 2;
	static ItemInfo[] itemList = new ItemInfo[numberOfItems];

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

	public static ArrayList findItemsInListByType(string itemsType){
		ArrayList selectedObjects = new ArrayList();
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
			SetInfo(inputLine[i], itemList[i]);
		}

	}

	void SetInfo(string inputLine, ItemInfo item){
		{ int info = 0;
			foreach(string value in inputLine.Split('	'))
			{
				switch(info){
					case 0:
					item.ID = value;
					GameObject.FindGameObjectWithTag("Finish").GetComponent<Text>().text = value;
					break;

					case 1:
					item.Name = value;
					break;

					case 2:
					item.Description = value;
					break;

					case 3:
					item.Price = Convert.ToInt32(value);
					break;

					case 4:
					item.Damage = Convert.ToInt32(value);
					break;

					case 5:
					item.Hp = Convert.ToInt32(value);
					break;
				}
				info++;
			}
			item.AmountInInventory = 2;
			item.GameObject = Resources.Load(item.ID, typeof(GameObject)) as GameObject;
		}
	}
}




