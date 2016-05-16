using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WoodPile : MonoBehaviour {

	[SerializeField]
	GameObject logPrefab;

    public Sprite[] logStateImages;
    int woodAmount;

    SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        woodAmount = 10;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        if(woodAmount >= 9)
        {
            spriteRenderer.sprite = logStateImages[3];
        }
        else if(woodAmount >= 6)
        {
            spriteRenderer.sprite = logStateImages[2];
        }
        else if(woodAmount >= 3)
        {
            spriteRenderer.sprite = logStateImages[1];
        }
        else if(woodAmount > 0)
        {
            spriteRenderer.sprite = logStateImages[0];
        }
        else
        {
            spriteRenderer.sprite = new Sprite();
        }

        GameObject.Find("LogAmtText").GetComponent<Text>().text = "X " + woodAmount;

	}

	void OnMouseDown() {
        if (woodAmount > 0) {
            Vector3 tempVec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tempVec.z = 0;
            Instantiate(logPrefab, tempVec, Quaternion.identity);

            woodAmount--;
        }
	}

    public void SetWoodPileSize(int newSize)
    {
        woodAmount = newSize;
    }

    public void AddToWoodPileSize(int addSize)
    {
        woodAmount += addSize;
        if(woodAmount > 10)
        {
            woodAmount = 10;
        }
        else if (woodAmount < 0)
        {
            woodAmount = 0;
        }
    }

    public int GetAmtWoodLeft()
    {
        return woodAmount;
    }
}
