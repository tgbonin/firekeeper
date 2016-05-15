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
                    swipeStartPos = touch.position;
                    swipeStartTime = Time.time;
                    break;

            }

            float swipeTime = Time.time - swipeStartTime;
            float swipeDist = Vector2.Distance(swipeStartPos, touch.position);

            if(couldBeSwipe && (swipeTime < maxSwipeTime) && (swipeDist > minSwipeDist))
            {

                if(Mathf.Sign(touch.position.x - swipeStartPos.x) == 1f){

                    //right
                    if (swipeStartPos.y < (Screen.height * .08))
                    {
                        HandleSwipe(ESwipeDirection.SCREEN_LEFT);
                        couldBeSwipe = false;
                    }
					else {//HandleSwipe(ESwipeDirection.RIGHT);
                        Vector2 startPosWorld = Camera.main.ScreenToWorldPoint(swipeStartPos);
                        Vector2 endPosWorld = Camera.main.ScreenToWorldPoint(touch.position);
                        
                        RaycastHit2D hit = Physics2D.Raycast(startPosWorld, endPosWorld - startPosWorld, Vector2.Distance(startPosWorld, endPosWorld));
						if (hit.collider != null)
						{
							couldBeSwipe = false;
							if (hit.collider.gameObject.tag == "tree")
							{
								GameObject.Find("Wood Pile").GetComponent<WoodPile>().AddToWoodPileSize(1);
							}
						}
					}
                }
                else
                {
                    //left
                    if (swipeStartPos.y < (Screen.height * .08))
                    {
                        HandleSwipe(ESwipeDirection.SCREEN_RIGHT);
                        couldBeSwipe = false;
                    }
					else {//HandleSwipe(ESwipeDirection.LEFT);
                        Vector2 startPosWorld = Camera.main.ScreenToWorldPoint(swipeStartPos);
                        Vector2 endPosWorld = Camera.main.ScreenToWorldPoint(touch.position);

                        RaycastHit2D hit = Physics2D.Raycast(startPosWorld, endPosWorld - startPosWorld, Vector2.Distance(startPosWorld, endPosWorld));
                        if (hit.collider != null)
						{
                            couldBeSwipe = false;
                            if (hit.collider.gameObject.tag == "tree")
							{
                                GameObject.Find("Wood Pile").GetComponent<WoodPile>().AddToWoodPileSize(1);
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
