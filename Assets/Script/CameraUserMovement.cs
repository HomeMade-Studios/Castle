using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CameraUserMovement : MonoBehaviour {

    public float movementSpeed;
    bool firstTime = true;
    private Vector3 touchCoord, deltaTouchPosition;
    static bool canMove;

	// Use this for initialization
	void Start () {
        canMove = true;
	}
	
	// Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    switch (touch.phase)
                    {
                        case TouchPhase.Began:

                            break;

                        case TouchPhase.Moved:
                            if (Input.touchCount == 2)
                            {
                                if (!firstTime)
                                {
                                    deltaTouchPosition = Camera.main.ScreenToWorldPoint(touch.position) - touchCoord;
                                    transform.position = Vector3.Lerp(transform.position, transform.position - deltaTouchPosition, movementSpeed * Time.deltaTime);
                                }
                                else
                                    firstTime = false;

                                touchCoord = Camera.main.ScreenToWorldPoint(touch.position);
                            }
                            break;

                        case TouchPhase.Ended:
                            firstTime = true;
                            break;
                    }
                }

            }
        }
    }
    public static void setCanMove(bool value) {
        canMove = value;
    }
}
