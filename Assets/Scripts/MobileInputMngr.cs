using UnityEngine;
using System.Collections;
using System;
using Assets.Scripts;

public class MobileInputMngr : MonoBehaviour {

    public float minSwipeDist;
    public float maxSwipeTime;
    private bool couldBeSwipe;
    Vector2 swipeStartPos;

    private float swipeStartTime;

    CameraPanSnap cameraController;

    void Start()
    {
        swipeStartTime = 0;
        cameraController = GameObject.Find("Main Camera").GetComponent<CameraPanSnap>();
        swipeStartPos = Vector2.zero;
    }

	// Update is called once per frame
	void Update () {
        checkHorizontalSwipes();

        if (Input.GetKeyDown("left"))
        {
            HandleSwipe(ESwipeDirection.SCREEN_RIGHT);
        }

        if (Input.GetKeyDown("right"))
        {
            HandleSwipe(ESwipeDirection.SCREEN_LEFT);
        }

	}

    private void checkHorizontalSwipes()
    {
        foreach(Touch touch in Input.touches)
        {

            switch(touch.phase){

                case TouchPhase.Began:
                    couldBeSwipe = true;

                    //Debug.Log("Starting Swipe at: " + touch.position.x + "at time = " + Time.time);

                    swipeStartPos = touch.position;
                    swipeStartTime = Time.time;
                    break;

            }

            float swipeTime = Time.time - swipeStartTime;
            float swipeDist = Vector2.Distance(swipeStartPos, touch.position);

            if(touch.phase == TouchPhase.Ended)
            {
                Debug.Log("Hit a swipe End. Info: " + swipeTime + " , " + swipeDist);
            }

            if(couldBeSwipe && (swipeTime < maxSwipeTime) && (swipeDist > minSwipeDist))
            {

                Debug.Log("Shit should happen");

				//Debug.Log("could be swipe");
                if(Mathf.Sign(touch.position.x - swipeStartPos.x) == 1f){

                    //right
                    if (swipeStartPos.x < (Screen.width * 0.15))
                    {
                        HandleSwipe(ESwipeDirection.SCREEN_LEFT);
                        couldBeSwipe = false;
                    }
					else {//HandleSwipe(ESwipeDirection.RIGHT);   
						Debug.Log("casting");
						RaycastHit2D hit = Physics2D.Raycast(swipeStartPos, touch.position - swipeStartPos, swipeDist);
						if (hit.collider != null)
						{
							Debug.Log("hit");
							if (hit.collider.gameObject.tag == "tree")
							{
								Debug.Log("chopped");
							}
						}
					}
                }
                else
                {
                    //left
                    if (swipeStartPos.x > (Screen.width - Screen.width * 0.15))
                    {
                        HandleSwipe(ESwipeDirection.SCREEN_RIGHT);
                        couldBeSwipe = false;
                    }
					else {//HandleSwipe(ESwipeDirection.LEFT);
						Debug.Log("casting");
						RaycastHit2D hit = Physics2D.Raycast(swipeStartPos, touch.position - swipeStartPos, swipeDist);
						if (hit.collider != null)
						{
							Debug.Log("hit");
							if (hit.collider.gameObject.tag == "tree")
							{
								Debug.Log("chopped");
							}
						}
					}
                }

            }

        }
    }

	private void CheckSwipeCollision()
	{
		//Will fill with swipe hit detection once done
	}

    private void HandleSwipe(ESwipeDirection direction)
    {
        //Debug.Log("Entered Handle Swipe");

        switch (direction)
        {
            case ESwipeDirection.SCREEN_LEFT:
                cameraController.SnapLeft();
                break;

            case ESwipeDirection.SCREEN_RIGHT:
                cameraController.SnapRight();
                break;

			case ESwipeDirection.LEFT:
				
				break;
			case ESwipeDirection.RIGHT:
				
				break;
        }
    }
}
