using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class customerScript : MonoBehaviour
{
    //dialog elements
    public int dialogState = 0; //state determines what the merchant is saying
    public Text dialogText;
    string dialogString;

    //contain different customer states
    public int charaState;

    //the request 
    public GameObject request;

    //where the requested item goes
    public GameObject requestSlot;

    //the sprite for the chara
    public GameObject sprite;
    public Sprite chara1;
    public Sprite chara2;


    public GameObject potionA;
    public GameObject potionB;
    public GameObject potionC;
    public GameObject banyaPotion;

    // Use this for initialization
    void Start()
    {
        dialogText = GameObject.Find("DialogText").GetComponent<Text>();
        requestSlot = GameObject.FindGameObjectWithTag("requestSlot");

        charaState = 1;
        request = potionA;

        sprite = GameObject.Find("CustomerSprite");
      
    }

    // Update is called once per frame
    void Update()
    {
        dialogText.text = dialogString;

        if (charaState == 1)
        {
            if (dialogState == 0)
            {
                dialogString = " Hallo Mr Apothecary. Would you happen to have anything to soothe my aching muscles? My arms are so tired they’re trembling as I speak.";
            }
            else if (dialogState == 1)
            {
                dialogString = "Ah, well… I was helping my... grandmother massage her shoulders, and I was at it long enough for my arms to turn to noodles. Hehe.";
            }

            
        }else if (charaState == 2)
        {
            if (dialogState == 0)
            {
                dialogString = "Hallo Mr Apothecary, I’m back again. What you gave me yesterday did wonders, but I’m still weak and my arms are all shivery again.";
            }
            else if (dialogState == 1)
            {
                dialogString = "That… was because she had a headache today as well, so I lighted some incense for her. Maybe it’s making me a little dizzy… The woods seemed a little more purple than usual…";
            }
        }
    }

    public void checkRequest()
    {
        if (requestSlot.transform.childCount != 0)
        {
            Debug.Log(requestSlot.transform.GetChild(0).gameObject.name);
            Debug.Log(request.name);
            if (requestSlot.transform.GetChild(0).gameObject.name.Contains(request.name))
            {
                Destroy(requestSlot.transform.GetChild(0).gameObject);
                charaState++;
                setChara(charaState);
            }
        }
    }

    public void moveForward()
    {
        if (dialogState == 0)
        {
            dialogState = 1;
        }

        else if (dialogState == 1)
        {
            dialogState = 0;
        }
    }

    public void setChara(int s)
    {
        if (s == 1)
        {
            request = potionA;
            sprite.GetComponent<SpriteRenderer>().sprite = chara1;

        }
        else if (s == 2)
        {
            request = potionB;
            sprite.GetComponent<SpriteRenderer>().sprite = chara2;
        }
    }
}
