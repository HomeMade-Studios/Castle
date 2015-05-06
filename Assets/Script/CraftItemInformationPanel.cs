using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CraftItemInformationPanel : MonoBehaviour {
	
	public Text itemName, itemDescription, itemHp, itemDamage;
	public Button craftButton;
	public Transform prices;
	public GameObject priceText;
	GameObject instantiatedText;
	static string selectedItemID;
	static ItemInfo selectedItemInformation;
	public CraftList craftList;
	
	void Update () {
		//UpdateInformation ();
		PlayerPrefs.SetInt ("Wood", 10);
	}
	
	void UpdateInformation(){
		if (selectedItemID != null) {
			itemName.text = selectedItemInformation.Name;
			itemDescription.text = selectedItemInformation.Description;
			itemHp.text = "Hp: " + selectedItemInformation.Hp.ToString ();
			itemDamage.text = "Damage: " + selectedItemInformation.Damage.ToString ();
			foreach (Transform child in prices) {		//delete all list
				GameObject.Destroy(child.gameObject);
			}
			if(selectedItemInformation.GoldPrice > 0){
				instantiatedText = Instantiate (priceText, new Vector3(0,0,0), Quaternion.identity) as GameObject;
				instantiatedText.GetComponent<Transform>().SetParent(prices);
				instantiatedText.GetComponent<Text>().text = "Gold: " + selectedItemInformation.GoldPrice.ToString();
				if(PlayerPrefs.GetInt("Gold") < selectedItemInformation.GoldPrice){
					instantiatedText.GetComponent<Text>().color = Color.red;
					craftButton.interactable = false;
				}
				else{
					instantiatedText.GetComponent<Text>().color = Color.black;
					craftButton.interactable = true;
				}
			}

			if(selectedItemInformation.WoodPrice > 0){
				instantiatedText = Instantiate (priceText, new Vector3(0,0,0), Quaternion.identity) as GameObject;
				instantiatedText.GetComponent<Transform>().SetParent(prices);
				instantiatedText.GetComponent<Text>().text = "Wood: " + selectedItemInformation.WoodPrice.ToString();
				if(PlayerPrefs.GetInt("Wood") < selectedItemInformation.WoodPrice){
					instantiatedText.GetComponent<Text>().color = Color.red;
					craftButton.interactable = false;
				}
				else{
					instantiatedText.GetComponent<Text>().color = Color.black;
					craftButton.interactable = true;
				}
			}

			if(selectedItemInformation.StonePrice > 0){
				instantiatedText = Instantiate (priceText, new Vector3(0,0,0), Quaternion.identity) as GameObject;
				instantiatedText.GetComponent<Transform>().SetParent(prices);
				instantiatedText.GetComponent<Text>().text = "Stone: " + selectedItemInformation.StonePrice.ToString();
				if(PlayerPrefs.GetInt("Stone") < selectedItemInformation.StonePrice){
					instantiatedText.GetComponent<Text>().color = Color.red;
					craftButton.interactable = false;
				}
				else{
					instantiatedText.GetComponent<Text>().color = Color.black;
					craftButton.interactable = true;
				}
			}

			if(selectedItemInformation.MetalPrice > 0){
				instantiatedText = Instantiate (priceText, new Vector3(0,0,0), Quaternion.identity) as GameObject;
				instantiatedText.GetComponent<Transform>().SetParent(prices);
				instantiatedText.GetComponent<Text>().text = "Metal: " + selectedItemInformation.MetalPrice.ToString();
				if(PlayerPrefs.GetInt("Metal") < selectedItemInformation.MetalPrice){
					instantiatedText.GetComponent<Text>().color = Color.red;
					craftButton.interactable = false;
				}
				else{
					instantiatedText.GetComponent<Text>().color = Color.black;
					craftButton.interactable = true;
				}
			}

			if(selectedItemInformation.PremiumPrice > 0){
				instantiatedText = Instantiate (priceText, new Vector3(0,0,0), Quaternion.identity) as GameObject;
				instantiatedText.GetComponent<Transform>().SetParent(prices);
				instantiatedText.GetComponent<Text>().text = "Premium: " + selectedItemInformation.PremiumPrice.ToString();
				if(PlayerPrefs.GetInt("Premium") < selectedItemInformation.PremiumPrice){
					instantiatedText.GetComponent<Text>().color = Color.red;
					craftButton.interactable = false;
				}
				else{
					instantiatedText.GetComponent<Text>().color = Color.black;
					craftButton.interactable = true;
				}
			}

			foreach (ItemNeeded itemNeeded in selectedItemInformation.ItemsNeeded){
				instantiatedText = Instantiate (priceText, new Vector3(0,0,0), Quaternion.identity) as GameObject;
				instantiatedText.GetComponent<Transform>().SetParent(prices);
				instantiatedText.GetComponent<Text>().text = ItemList.findItemInListByID(itemNeeded.ItemID).Name + ": " + itemNeeded.Amount.ToString();
				if(PlayerPrefs.GetInt("item" + itemNeeded.ItemID + "AmountInInventory") < itemNeeded.Amount){
					instantiatedText.GetComponent<Text>().color = Color.red;
					craftButton.interactable = false;
				}
				else{
					instantiatedText.GetComponent<Text>().color = Color.black;
					craftButton.interactable = true;
				}
			}
		} else {
			NullSelectedItem();
		}
	}
	
	public void Craft(){
		PlayerPrefs.SetInt ("item" + selectedItemInformation.ID + "AmountInInventory", PlayerPrefs.GetInt("item" + selectedItemInformation.ID + "AmountInInventory") + 1);
		PlayerPrefs.SetInt ("Gold", PlayerPrefs.GetInt ("Gold") - selectedItemInformation.GoldPrice);
		PlayerPrefs.SetInt ("Wood", PlayerPrefs.GetInt ("Wood") - selectedItemInformation.WoodPrice);
		PlayerPrefs.SetInt ("Stone", PlayerPrefs.GetInt ("Stone") - selectedItemInformation.StonePrice);
		PlayerPrefs.SetInt ("Metal", PlayerPrefs.GetInt ("Metal") - selectedItemInformation.MetalPrice);
		PlayerPrefs.SetInt ("Premium", PlayerPrefs.GetInt ("Premium") - selectedItemInformation.PremiumPrice);
		foreach (ItemNeeded itemNeeded in selectedItemInformation.ItemsNeeded) {
			PlayerPrefs.SetInt ("item" + itemNeeded.ItemID + "AmountInInventory", PlayerPrefs.GetInt("item" + itemNeeded.ItemID + "AmountInInventory") - itemNeeded.Amount);
		}
		UpdateInformation ();
		craftList.UpdateItemList();
	}
	
	public void SetSelectedItem(string itemID){
		selectedItemID = itemID;
		if (selectedItemID != null)
			selectedItemInformation = ItemList.findItemInListByID (selectedItemID);
		else
			NullSelectedItem ();
		UpdateInformation ();
	}

	void NullSelectedItem(){
		itemName.text = null;
		itemDescription.text = null;
		itemHp.text = null;
		itemDamage.text = null;
		craftButton.interactable = false;
		foreach (Transform price in prices) {
			price.gameObject.GetComponent<Text>().text = null;
		}
	}
}
