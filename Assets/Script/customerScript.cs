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
    public int place;

    public Text charaName;
    public string charaString;

    //contain different customer states
    public int charaState;

    //the request 
    public potionAttribute request;
    public string requestAtt;
    public potionAttribute requestSpecial;

    //where the requested item goes
    public GameObject requestSlot;

    //the sprite for the chara
    public GameObject sprite;
    public Sprite chara1;
    public Sprite chara2;

    //player
    public GameObject[] playerInventory;
    public playerScript player;

    public List<string> dia;

    public ingredientScript list;

    // Use this for initialization
    void Start()
    {
        dialogText = GameObject.Find("DialogText").GetComponent<Text>();
        charaName = GameObject.Find("CharaName").GetComponent<Text>();
        requestSlot = GameObject.FindGameObjectWithTag("requestSlot");

        player = GameObject.Find("player sprite").GetComponent<playerScript>();

        list = GameObject.FindGameObjectWithTag("prepArea").GetComponent<ingredientScript>();
        list.setupDictionary();
        request = list.potions["Potion of Healing"];
        charaState = 1;

        place = 0;
        dia = new List<string>();
        dia.Add("Muuya: Hello! I see your head is still a reindeer. I’m starting to like it.");
        dia.Add("Apothecary: Ah Muuya. Yes, soon I’ll be rid of this cursed head. Spirits come in and laugh at me. What brings you in?");
        dia.Add("Muuya: I heard murmurs today that a powerful witch has moved into the area. Might be the cause of that big snowstorm.");
        dia.Add("Apothecary: So knowing you, you were overcome with curiosity and sought her out?");
        dia.Add("Muuya: Of course! I met her, she was with her travelling companions. They were so worn out they couldn’t muster energy to talk.");
        dia.Add("Muuya: I’m thinking I need a <b>potion of healing</b> to give them. It’s made with something <b>torched</b> and something <b>ethereal</b>. Unless you know a more <b>rejuvenating recipe</b>.");
        dia.Add("Apothecary: A potion of healing, that’s not a problem. Give me a minute.");

        sprite = GameObject.Find("CustomerSprite");
        playerInventory = GameObject.FindGameObjectsWithTag("playerInventory");
    }

    // Update is called once per frame
    void Update()
    {
        dialogText.text = dialogString;
        charaName.text = charaString;

        charaString = dia[place].Substring(0, dia[place].LastIndexOf(':')+1);
        dialogString = dia[place].Substring(dia[place].LastIndexOf(':') + 1);
    }
       

    public void checkRequest()
    {
        if (requestSlot.transform.childCount != 0)
        {
            if (requestSlot.transform.GetChild(0).gameObject.name.Contains(request.ingredientName))
            {
                Destroy(requestSlot.transform.GetChild(0).gameObject);
                charaState++;
                setChara();
                player.gratitude++;
                if (requestAtt.Contains(request.attribute)) player.gratitude += 4;
            }
        }
    }


    public void moveForward()
    {
        //int dCount = dialogState;
        if (place < dia.Count-1)
        {
            place++;
        }
    }

    public void moveBackwards()
    {
        //int dCount = dialogState;
        if (place > 0)
        {
            place--;
        }
    }

    public void setChara()
    {
        dia.Clear(); // reset dialogue to start from beginning
        if (charaState == 1)
        {
            request = list.potions["Potion of Healing"];
            sprite.GetComponent<Image>().sprite = chara1;

        }else if(charaState == 2)
        {
            dia.Add("Muuya: Thank you!");
        }
        else if (charaState == 3) //second request start
        {
            dia.Add("Muuya: Hello again! I’ve returned, with friends! This is Raspu and Itsa, familiars of Yagi, the witch.");
            dia.Add("Familiars: Greetings friend of Muuya. We have been told you are able to give aid to those who need it.");
            dia.Add("Muuya: These two help Miss Yagi out with everything. But right now she is extremely restless, I think she needs some special help.");
            dia.Add("Familiars: We have been moving Mistress Yagi too often because of false persecution. It has taken a toll on her.");
            dia.Add("Apothecary: That’s unfortunate to hear. What can I do?");
            dia.Add("Familiars: We come for the <b>sweet</b> medicine that will grant our witch the <b>peace of mind</b> that she needs in order to rest.");
            request = list.potions["Decoction of Clarity"];
            sprite.GetComponent<Image>().sprite = chara2;
        }
        else if (charaState == 4)
        {
            dia.Add("Familiars: Thank you!");
        }
        else if (charaState == 5) //third request start
        {
            dia.Add("Hot Springs Spirit: Hullo. I've heard of you, the reindeer alchemist. I'm hoping you can help.");
            dia.Add("Apothecary: Apothecary, not alchemist. And only my head is a reindeer, and it’s temporary… I hope. What do you need?");
            dia.Add("Hot Springs Spirit: I was caught in that recent snowstorm. My luck charms got blown away in the wind. I'm lost.");
            dia.Add("Hot Springs Spirit: I need to refresh our <b>good fortune</b> in order to find my way. Perhaps you can speak with the Gods and give me something to <b>bless our journey</b>?");
            dia.Add("Apothecary: I think my reindeer brain knows just the thing.");
            request = list.potions["Brew of Blessing"];
            sprite.GetComponent<Image>().sprite = chara1;
        }
        else if (charaState == 6)
        {
            dia.Add("Hot Springs Spirit: Thank you!");
        }
        else if (charaState == 7) //fourth request start
        {
            dia.Add("Duggy: Hi. I’m Duggy, loyal house spirit. You’re the apothecary cursed with the deer face.");
            dia.Add("Apothecary: Yes, thank you for pointing that out, spirit. What brings you in?");
            dia.Add("Duggy: I was caught in that recent storm. In between moments of blinding wind and snow, I saw a glimpse of the most beautiful woman.");
            dia.Add("Duggy: Muuya knew her, so I visited her at her home. Her name is Miss Yagi. I’m hoping she’ll hire me as her housekeeper,");
            dia.Add("Apothecary: Wait, you’re talking about Yagi the witch. I wouldn’t have expected her to be beautiful.");
            dia.Add("Duggy: Yes, well, Muuya says what I saw was a vestige of Miss Yagi’s former self. Right now, she looks like a witch, and I can’t even get her to break a smile.");
            dia.Add("Duggy: Any suggestions? There was rumor of a potion that would imbibe the drinker with <b>endless affection</b>. But maybe I just need to <b>freshen up</b>.");
            request = list.potions["Perfume of Allure"];
            requestSpecial = list.potions["Eternal Love"];
            sprite.GetComponent<Image>().sprite = chara1;
        }
        else if (charaState == 8)
        {
            dia.Add("Duggy: Thank you!");
        }
        else if (charaState == 9) //fifth request start
        {
            dia.Add("Duggy: Hello again! Muuya and I are hoping you can help us cheer up Miss Yagi.");
            dia.Add("Muuya: She seems lonely, often gazes into the distance absentmindedly. We try to cheer her up, but we think she needs some sort of funny companion.");
            dia.Add("Duggy: We have this carving Muuya’s parents made. We’re hoping you can animate it.");
            dia.Add("Muuya: We need a <b>Brownie Butler</b> to inhabit this carving and bring it life. Do you know the recipe? I remember that this spirit is derived from an <b>animalcule potion</b>. Just <b>add warmth</b>.");
            dia.Add("Muuya: You can think of the animalcule as the opposite of loneliness. A <b>companion</b>.");
            dia.Add("Apothecary: I believe I can work something out. Duggy, did the perfume help?");
            dia.Add("Duggy: *blushes*");
            dia.Add("Muuya: Miss Yagi found it… awkwardly amusing.");
            request = list.potions["Brownie Butler"];
            sprite.GetComponent<Image>().sprite = chara1;
        }
        else if (charaState == 10)
        {
            dia.Add("Duggy: Thank you!");
        }
        else if (charaState == 11) // 6 SIXTH request start 
        {
            dia.Add("Yagi: Hello. I am Yagi, Witch of the Woods. I’d like to thank you. I heard the stories that Muuya, Raspu, Itsa and that cute Duggy.");
            dia.Add("Apothecary: I’ve heard much about you. I have done nothing but what my profession asks.");
            dia.Add("Yagi: Maybe that’s true. I’m hoping for some advice. I’ve gotten good rest, but have noticed that I haven’t been dreaming.");
            dia.Add("Yagi: Yet I feel a nagging pull at something I’ve forgotten, <b>locked in my dreams</b>. Any suggestiongs? I feel that only the <b>holy affection of Perun</b> could help me now.");
            dia.Add("Apothecary: I will try to help you regain what you’ve forgotten.");
            request = list.potions["Elixir of Dreams"];
            requestSpecial = list.potions["Dream Catcher"];
            //sprite.GetComponent<Image>().sprite ...
        }
        else if (charaState == 12)
        {
            dia.Add("Yagi: Thank you!");
        }
        else if (charaState == 13) // 7 SEVENTH request start 
        {
            dia.Add("Hot Springs Spirit: Oh, Mr. Apothecary! Help, my friend is hurt! ");
            dia.Add("Apothecary: What’s the matter. It looks like your friend is unconcious. What happened?");
            dia.Add("Hot Springs Spirit: She was out in the cold too long, during that blasted snowstorm. I cannot <b>wake her</b>!");
            dia.Add("Hot Springs Spirit: Please, we need something to bring her about. Something <b>warm</b>, to get her blood flowing. I sense the cold has gone to the core of her spirit.");
            dia.Add("Hot Springs Spirit: I fear we don’t have much time.");
            request = list.potions["Steaming Elixir"];
            //sprite.GetComponent<Image>().sprite ...
        }
        else if (charaState == 14) // 7 dialogue after seventh request is complete
        {
            dia.Add("Now-awake Spirit: Ugh….where am I?");
            dia.Add("Hot Springs Spirit: You are with the reindeer apothecary. He has helped saved you, you were passed out from the cold storm.");
            dia.Add("Now-awake Spirit: Oh...wow. I had the most intense dreams. A beautiful woman, controlling the storm. She was a companion of the hot springs spirits. ");
            dia.Add("Hot Springs Spirit: How awful. Please, apothecary, keep what has happened here secret, we hot springs spirits don’t like to make ourselves known.");
            dia.Add("Hot Springs Spirit: We owe you greatly.");
            // dia.Add("");
        }
        else if (charaState == 15) // 8 EIGHTH request start 
        {
            dia.Add("Familiars: Hello. We and the domovoi Duggy require assistance. We have a journey ahead of us.");
            dia.Add("Duggy: We’re going to meet the hot springs spirits! We found out they were living close in secret, and think they could help Miss Yagi.");
            dia.Add("Familiars: Yes. The hot springs and Mistress Yagi share close connection. However, she was chased away from her home in the hot springs, which is why we are here.");
            dia.Add("Familiars: Mistress Yagi used to return from patrols dirty and heavy, and soak in the hot springs to cleanse herself. Something she cannot do now.");
            dia.Add("Apothecary: If you seek to find these hot springs spirits, you will need one for <b>protection</b>.");
            dia.Add("Apothecary: When you meet the hot springs spirits, tell them my name. They will help.");
            request = list.potions["Potion of Protection"];
            //sprite.GetComponent<Image>().sprite ...
        }
        else if (charaState == 16)
        {
            dia.Add("Duggy: Thank you!");
        }
        else if (charaState == 17) // 9 NINTH request start 
        {
            dia.Add("Hot Springs Spirit: : Hello apothecary. We have heard of Yagi the Witch and seek to help her, upon your request. We have a hot spring prepared for her.");
            dia.Add("Apothecary: Thank you, hot springs spirits. I do request that this be done.");
            dia.Add("Familars: We need to enchant the waters to give them more powerful healing properties.");
            dia.Add("Hot Springs Spirit: Ideally, the poisonous <b>nightmare crystal</b> would be the most cleansing additive. However, many potions would work, <b>anything to rejuvenate her</b>.");
            dia.Add("Apothecary: I will see what can be done.");
            request = list.potions["Potion of Healing"];
            requestSpecial = list.potions["Nightmare Crystal"];
            //sprite.GetComponent<Image>().sprite ...
        }
        else if (charaState == 18)
        {
            dia.Add("Familiars: Thank you!");
        }
        else if (charaState == 19) // 10 TENTH request start 
        {
            dia.Add("Muuya: Hello! It worked! The witch is regaining her old form. You’ve made us incredibly happy.");
            dia.Add("Muuya: But I’ve felt nothing from the townspeople, who remain afraid of her due to the storm she caused. She’s bringing them misfortune, they think.");
            dia.Add("Muuya: I’d like to give them something to <b>make them all come around</b>. Something minor or major to give them a <b>fresh perspective</b> on Miss Yagi. ");
            // dia.Add("");
            // dia.Add("");
            request = list.potions["Decoction of Clarity"];
            request.setAttribute("Awakening");
            requestSpecial = list.potions["Balm of Realization"];
            //sprite.GetComponent<Image>().sprite ...
        }
        else if (charaState == 20)
        {
            dia.Add("Muuya: Thank you!");
        }
    }
}
