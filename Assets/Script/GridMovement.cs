using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class GridMovement : MonoBehaviour {

    public bool needFloor = false, needCeiling = false, needWall = false, overlapAnotherObject = false;
	public float cell_size = 8f; // larghezza/altezza delle celle
    SpriteRenderer spriteRenderer;
	private float x, y, z;
	
	void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
		x = 0f;
		y = 0f;
		z = 0f;	
	}
	
	void Update () {
		x = Mathf.Round(transform.position.x / cell_size) * cell_size;
		y = Mathf.Round(transform.position.y / cell_size) * cell_size;
		z = transform.position.z;
		transform.position = new Vector3(x, y, z);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            overlapAnotherObject = true;   
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            overlapAnotherObject = false;
        }
    }

    public bool OverlapAnotherObject()
    {
        return overlapAnotherObject;
    }
}
