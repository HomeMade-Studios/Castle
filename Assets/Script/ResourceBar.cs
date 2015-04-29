using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResourceBar : MonoBehaviour {

	public Text wood, stone, metal, gold, premium;

	void Start () {
		InvokeRepeating ("UpdateResources", 0.01f, 0.5f);
	}

	void UpdateResources () {
		wood.text=PlayerPrefs.GetInt("wood")+" "+"wood";
		stone.text=PlayerPrefs.GetInt("stone")+" "+"stone";
		metal.text=PlayerPrefs.GetInt("metal")+" "+"metal";
		gold.text=PlayerPrefs.GetInt("gold")+" "+"gold";
		premium.text=PlayerPrefs.GetInt("premium")+" "+"premium";
	}
}
