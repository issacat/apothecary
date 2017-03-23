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

    //player
    public GameObject[] playerInventory;


    //max counts for request dialogueState numbers
    int muu1MaxDS = 6;
    int muu2MaxDS = 6;
    int muu3MaxDS = 7;

    // Use this for initialization
    void Start()
    {
        dialogText = GameObject.Find("DialogText").GetComponent<Text>();
        requestSlot = GameObject.FindGameObjectWithTag("requestSlot");

        charaState = 1;
        request = potionA;

        sprite = GameObject.Find("CustomerSprite");
        playerInventory = GameObject.FindGameObjectsWithTag("playerInventory");
    }

    // Update is called once per frame
    void Update()
    {
        dialogText.text = dialogString;

        if (charaState == 1) // Muuya request 1
        {
            if (dialogState == 0)
            {
                dialogString = "<b>Apothecary:</b> Why hello there. ";
            }
            else if (dialogState == 1)
            {
                dialogString = "<b>Muuya:</b> Hallo....uhm, you're an apothecary right? I heard your many incredible stories, well, from the South. I’m Muuya.";
            }
            else if (dialogState == 2)
            {
                dialogString = "<b>Apothecary:</b> Indeed. I hope to live up to these stories. What brings you in young Muuya?";
            }
            else if (dialogState == 3)
            {
                dialogString = "<b>Muuya:</b> It's my ma and pa. They've been working so hard on this intricately beautiful wood carving. They've really drained themselves, with all that spellweaving involved. I thought I'd get them something rejuvenating.";
            }
            else if (dialogState == 4)
            {
                dialogString = "<b>Muuya:</b> I usually make it something myself, but thought I'd come meet you. Just something basic would be okay. If I remember correctly, something <b>torched</b> and something  <b>ethereal</b> were the ingredients I used.";
            }
            else if (dialogState == 5)
            {
                dialogString = "<b>Apothecary:</b>Sounds like we have an apothecary in the making right here. You know a lot for someone so young. I'll be back with your potion.";
            }
        }
        else if (charaState == 2)
        {
            dialogString = "<b>Muuya:</b> Thank you. I don’t have much as to give but my heartfelt thanks!";
        }
        else if (charaState == 3) // Muuya request 2
        {
            if (dialogState == 0)
            {
                dialogString = "<b>Apothecary:</b> Greetings..";
            }
            else if (dialogState == 1)
            {
                dialogString = "<b>Familiars:</b> To you we say hello. We are the familiars of the witch of the woods, known as Yagi.";
            }
            else if (dialogState == 2)
            {
                dialogString = "<b>Apothecary:</b> I've heard of the witch. She is a controversial figure, to say the least. What do you ask of me?";
            }
            else if (dialogState == 3)
            {
                dialogString = "<b>Familiars:</b> She has been treated poorly by far too many for far too long. She has treated us very well in the past, and we do the same with her now. We have travelled for years to find a place to stay that is welcoming, but we have little hope. ";
            }
            else if (dialogState == 4)
            {
                dialogString = "<b>Familiars:</b> And now, we simply need something to boost our energy and soothe our aching bodies. Something <b>warm</b>, to gives us some <b>serenity</b> during this continued journey.";
            }
            else if (dialogState == 5)
            {
                dialogString = "<b>Apothecary:</b> Well, you're welcome in my apothecary. I will make you just what you need.";
            }
        }
        else if (charaState == 4)
        {
            dialogString = "<b>Familiars:</b> Thank you kindly";
        }
        else if (charaState == 5) //request num 3
        {
            if (dialogState == 0)
            {
                dialogString = "<b>Muuya:</b> Hallo again! Boy, I’ve had quite the day.";
            }
            else if (dialogState == 1)
            {
                dialogString = "<b>Apothecary:</b>Hello Muuya, what’s happened?";
            }
            else if (dialogState == 2)
            {
                dialogString = "<b>Muuya:</b> Well, I was in the Willwood Forest when I saw a few travellers, clearly not from around here. I just had to meet them. Turns out one of them is actually a witch!";
            }
            else if (dialogState == 3)
            {
                dialogString = "<b>Apothecary:</b> A witch, eh. I think I might know of these travelers.";
            }
            else if (dialogState == 4)
            {
                dialogString = "<b>Muuya:</b> Oh? They were really exhausted, nearly falling over. Doesn’t help that there was that big snow storm - strongest one I’ve felt in a while. I had to help them. I ended up massaging the old witch for what felt like *hours*. ";
            }
            else if (dialogState == 5)
            {
                dialogString = "<b>Muuya:</b> Now I'm exhausted. I had to come back - and my parents love the potion you made. Could I have something warm -- it’s so cold out! And sweet too";
            }
            else if (dialogState == 6)
            {
                dialogString = "<b>Apothecary:</b> Well, my potions shouldn’t be confused with candy -- but I’ll see what I can do for ya.";
            }
        }
        else if (charaState == 6)
        {
            dialogString = "<b>Muuya:</b> I'm feeling refreshed! Thanks again!";
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
                //charGiveItems();
            }
        }
    }

   /* public void charGiveItems()
    {
        if (charaState == 2)
        {
            if (requestSlot.transform.childCount != 0)
            {
                Transform panel = requestSlot.transform;
                GameObject a = (GameObject)Instantiate(Resources.Load("Holly"));
                a.name = a.name.Replace("(Clone)", "");
                a.transform.SetParent(panel.transform, false);
            }
        }
        if (charaState == 4)
        {
            if (requestSlot.transform.childCount != 0)
            {
                Transform panel = requestSlot.transform;
                GameObject a = (GameObject)Instantiate(Resources.Load("Banya"));
                a.name = a.name.Replace("(Clone)", "");
                a.transform.SetParent(panel.transform, false);
            }
        }

    }*/

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
            sprite.GetComponent<Image>().sprite = chara1;

        }
        else if (charaState == 3)
        {
            request = potionB;
            
        }
        else if (charaState == 5)
        {
            request = potionA;
            sprite.GetComponent<Image>().sprite = chara1;
        }
    }
}
