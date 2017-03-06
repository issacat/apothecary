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


    //max counts for request dialogueState numbers
    int muu1MaxDS = 4;
    int muu2MaxDS = 9;
    int muu3MaxDS = 4;

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

        if (charaState == 1) // Muuya request 1
        {
            if (dialogState == 0)
            {
                dialogString = "<b>Muuya:</b> Hallo Mr Apothecary. Would you happen to have anything to soothe my aching muscles? My arms are so tired they’re trembling as I speak.";
            }
            else if (dialogState == 1)
            {
                dialogString = "<b>Apothecary:</b> That must be tough. What was someone as young as you working so hard on?";
            }
            else if (dialogState == 2)
            {
                dialogString = "<b>Muuya:</b> Ah, well… I was helping my... grandmother massage her shoulders, and I was at it long enough for my arms to turn to noodles. Hehe.";
            }
            else if (dialogState == 3)
            {
                dialogString = "<b>Muuya:</b> Actually, if it’s not too much to ask, maybe also something to muster my strength. It seems I may go help her tomorrow as well.";
            }
        }
        else if (charaState == 2)
        {
            dialogString = "<b>Muuya:</b> Thank you. I don’t have much as payment, but I found some beautiful holly berries on my way back, the most beautiful I’ve ever seen!";
        }
        else if (charaState == 3) // Muuya request 2
        {
            if (dialogState == 0)
            {
                dialogString = "<b>Muuya:</b> Hallo Mr Apothecary, I’m back again. What you gave me yesterday did wonders, but I’m still weak and my arms are all shivery again.";
            }
            else if (dialogState == 1)
            {
                dialogString = "<b>Apothecary:</b> At your grandmother’s again? Your steps also seem a bit wobbly. Are you feeling alright?";
            }
            else if (dialogState == 2)
            {
                dialogString = "<b>Muuya:</b> That… was because she had a headache today as well, so I lighted some incense for her. Maybe it’s making me a little dizzy… The woods seemed a little more purple than usual…";
            }
            else if (dialogState == 3)
            {
                dialogString = "<b>Apothecary:</b> Dear child, do you remember what kind of incense it was?";
            }
            else if (dialogState == 4)
            {
                dialogString = "<b>Muuya:</b> Hmmm, it was nothing I had ever smelled before, but it definitely smelled a bit like pine, though a little more smokey…";
            }
            else if (dialogState == 5)
            {
                dialogString = "<b>Muuya:</b> Ah, I still have some sticks in my pocket! I must have forgotten to put it back. I suppose you might like them, Mr Apothecary?";
            }
            else if (dialogState == 6)
            {
                dialogString = "<b>Apothecary:</b> Hmmm, these seem to be Spirit Incense; they're extremely strong for humans. Where exactly did you get them, again?";
            }
            else if (dialogState == 7)
            {
                dialogString = "<b>Muuya:</b> Ahh...... Uhmm...... I'm sorry Mr Apothecary, I lied. I actually went to see the Witch of the Woods... I had a request of sorts....";
            }
            else if (dialogState == 8)
            {
                dialogString = "<b>Apothecary:</b> I see.... Then I can take these as payment. Just wait a moment and I’ll get something for you.";
            }
        }
        else if (charaState == 4)
        {
            dialogString = "<b>Muuya:</b> Thank you again!Ummm, I also picked some banya pine; it's hard to come by around the village, and this was the greenest I could find!";
        }
        else if (charaState == 5) //request num 3
        {
            if (dialogState == 0)
            {
                dialogString = "<b>Familiar:</b> Good afternoon, Apothecary. We are the familiars of our Mistress Yagi, the Witch of the Woods. My kitty friend and I have been touched by little Muuya’s kindness, bringing us treats and warm words when our own Mistress has spoken nothing but insults. Of course, the Mistress hasn’t always been like this, but being far from one’s homeland for too long does strange things.";
            }
            else if (dialogState == 1)
            {
                dialogString = "<b>Apothecary:</b> Mistress Yagi doesn't seem to be well, with aches and headaches all over! And I don't seem to be of much help...";
            }
            else if (dialogState == 2)
            {
                dialogString = "<b>Familiar:</b> You see, we’re from a land of hot springs, but being in this Far North with want of warmth has frozen many things both within and without.";
            }
            else if (dialogState == 3)
            {
                dialogString = "<b>Apothecary:</b> Ah, perhaps something hot and relaxing would help Mistress Yagi? Her aching only seems to be getting worse.";
            }
        }
        else if (charaState == 6)
        {
            dialogString = "Will this do as payment?";
        }
    }
       

    public void checkRequest()
    {
        if (requestSlot.transform.childCount != 0)
        {
            if (requestSlot.transform.GetChild(0).gameObject.name.Contains(request.name))
            {
                Destroy(requestSlot.transform.GetChild(0).gameObject);
                charaState++;
                dialogState = 0; // reset dialogue to start from beginning
            }
        }
    }

    public void moveForward()
    {
        //int dCount = dialogState;
        if (charaState == 1)
        {
            if (dialogState < muu1MaxDS)
            {
                dialogState++;
            }
            if (dialogState >= muu1MaxDS) dialogState = 0;
        }
        if (charaState == 3)
        {
            if (dialogState < muu2MaxDS)
            {
                dialogState++;
            }
            if (dialogState >= muu2MaxDS) dialogState = 0;
        }
        if (charaState == 5)
        {
            if (dialogState < muu3MaxDS)
            {
                dialogState++;
            }
            if (dialogState >= muu3MaxDS) dialogState = 0;
        }
    }

    public void setChara()
    {
        if (charaState == 1)
        {
            request = potionA;
            sprite.GetComponent<SpriteRenderer>().sprite = chara1;

        }
        else if (charaState == 3)
        {
            request = potionB;
            
        }
        else if (charaState == 5)
        {
            request = banyaPotion;
            sprite.GetComponent<SpriteRenderer>().sprite = chara2;
        }
    }
}
