using UnityEngine;
using System.Collections;
using System;
using Assets.Scripts;

public class MobileInputMngr : MonoBehaviour {

    public float minSwipeDist;
    public float maxSwipeTime;
    private bool couldBeSwipe;

    private float swipeStartTime;

    CameraPanSnap cameraController;

    void Start()
    {
        swipeStartTime = 0;
        cameraController = GameObject.Find("Main Camera").GetComponent<CameraPanSnap>();
    }

	// Update is called once per frame
	void Update () {
        checkHorizontalSwipes();
	}

    private void checkHorizontalSwipes()
    {
        Vector2 swipeStartPos = Vector2.zero;

        foreach(Touch touch in Input.touches)
        {

            switch(touch.phase){

                case TouchPhase.Began:
                    couldBeSwipe = true;
                    swipeStartPos = touch.position;
                    swipeStartTime = Time.time;
                    break;

                case TouchPhase.Stationary:
                    couldBeSwipe = false;
                    break;

            }

            float swipeTime = Time.time - swipeStartTime;
            float swipeDist = Vector2.Distance(swipeStartPos, touch.position);

            //Debug.Log(Time.time);
            //Debug.Log(swipeStartTime);

            if(touch.phase == TouchPhase.Ended)
            {
                
            }

            if(couldBeSwipe && swipeTime < maxSwipeTime && swipeDist > minSwipeDist)
            {
				Debug.Log("could be swipe");
                if(Mathf.Sign(touch.position.x - swipeStartPos.x) == 1f){

                    //right
                    if (swipeStartPos.x < (Screen.width * 0.1))
                    {
                        HandleSwipe(ESwipeDirection.SCREEN_RIGHT);
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
                    if (swipeStartPos.x > (Screen.width - Screen.width * 0.1))
                    {
                        HandleSwipe(ESwipeDirection.SCREEN_LEFT);
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
        Debug.Log("Entered Handle Swipe");

        switch (direction)
        {
            case ESwipeDirection.SCREEN_LEFT:
                cameraController.SnapRight();
                break;

            case ESwipeDirection.SCREEN_RIGHT:
                cameraController.SnapLeft();
                break;

			case ESwipeDirection.LEFT:
				cameraController.SnapRight();
				break;
			case ESwipeDirection.RIGHT:
				cameraController.SnapRight();
				break;
        }
    }
}
