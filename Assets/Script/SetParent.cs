using UnityEngine;
using System.Collections;

public class SetParent : MonoBehaviour {

	Transform Parent;

	void Start () {
		Parent=GameObject.FindGameObjectWithTag ("Grid").GetComponent<Transform>();
		transform.parent = Parent;
	}
}
