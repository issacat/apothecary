using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class customerScript : MonoBehaviour
{
    //dialog elements
    public int dialogState = 0; //state determines what the merchant is saying
    public Text dialogText;
    string dialogString;
    public int place;
    public GameObject bubbleRight;
    public GameObject bubbleLeft;

    public Text charaName;
    public string charaString;

    //contain different customer states
    public int charaState;

    //keeps a track of how many characters have been introduced; used in book pages
    public int charaNum;

    public bookScript book;

    //the request 
    public potionAttribute request;
    public string requestAtt;
    public potionAttribute requestSpecial;

    //where the requested item goes
    public GameObject requestSlot;

    //the sprite for the chara
    public GameObject chara1;
    public GameObject chara2;
    public GameObject chara3;
    public GameObject chara4;
    public GameObject chara5;
    public GameObject chara6;
    public GameObject chara7;

    //player
    public GameObject[] playerInventory;
    public playerScript player;

    public List<string> dia;

    public ingredientScript list;

    //buttons
    public GameObject nextChara;
    public GameObject back;
    public GameObject forward;
    public GameObject endButton;

    //gratitude
    public GameObject[] stars;
    public int requestReward;

    public AudioSource enter;
    public AudioSource success;

    // Use this for initialization
    void Start()
    {
        book = GameObject.Find("Book").GetComponent<bookScript>();

        bubbleLeft = GameObject.Find("bubbleLeft");
        bubbleRight = GameObject.Find("bubbleRight");

        dialogText = GameObject.Find("DialogText").GetComponent<Text>();
        charaName = GameObject.Find("CharaName").GetComponent<Text>();
        requestSlot = GameObject.FindGameObjectWithTag("requestSlot");

        player = GameObject.Find("player sprite").GetComponent<playerScript>();

        list = GameObject.FindGameObjectWithTag("prepArea").GetComponent<ingredientScript>();
        list.setupDictionary();
        request = list.potions["Potion of Healing"];
        requestAtt = "Soothing";
        requestSpecial = null;
        charaState = 1;

        stars = GameObject.FindGameObjectsWithTag("stars").OrderBy(go => go.name).ToArray();
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].SetActive(false);
        }

        playerInventory = GameObject.FindGameObjectsWithTag("playerInventory");

        back = GameObject.Find("textBack");
        forward = GameObject.Find("textForward");
        nextChara = GameObject.Find("nextCustomer");
        endButton = GameObject.Find("endGame");

        nextChara.SetActive(false);
        endButton.SetActive(false);

        dia = new List<string>();
        //list.test();

        charaNum = 0;
        place = 0;

        enter = GameObject.Find("enterSound").GetComponent<AudioSource>();
        success = GameObject.Find("successSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dia.Count > 0)
        {
            dialogText.text = dialogString;
            charaName.text = charaString;

            charaString = dia[place].Substring(0, dia[place].LastIndexOf(':') + 1);
            if (charaString.Contains("Sarvvis"))
            {
                bubbleRight.SetActive(true);
                bubbleLeft.SetActive(false);
            }
            else
            {
                bubbleRight.SetActive(false);
                bubbleLeft.SetActive(true);
            }
            dialogString = dia[place].Substring(dia[place].LastIndexOf(':') + 1);

            if (place == dia.Count() - 1)
            {
                forward.SetActive(false);
                back.SetActive(true);
                if (charaState % 2 == 0)
                {
                    nextChara.SetActive(true);
                }
            }
            else if (place == 0)
            {
                back.SetActive(false);
                forward.SetActive(true);
            }
            else
            {
                nextChara.SetActive(false);
                forward.SetActive(true);
                back.SetActive(true);
            }
        }
    }
       
    public void setUpChara()
    {
        chara1 = GameObject.Find("chara_muuya");
        chara2 = GameObject.Find("chara_raspu");
        chara3 = GameObject.Find("chara_itsa");
        chara4 = GameObject.Find("chara_uuryn");
        chara5 = GameObject.Find("chara_topka");
        chara6 = GameObject.Find("chara_witch_old");
        chara7 = GameObject.Find("chara_witch_young");

        chara1.SetActive(false);
        chara2.SetActive(false);
        chara3.SetActive(false);
        chara4.SetActive(false);
        chara5.SetActive(false);
        chara6.SetActive(false);
        chara7.SetActive(false);
    }

    public void checkRequest()
    {
        if (requestSlot.transform.childCount != 0)
        {
            GameObject itemCheck = requestSlot.transform.GetChild(0).gameObject;
            if (itemCheck.name.Contains(request.ingredientName))
            {
                Destroy(requestSlot.transform.GetChild(0).gameObject);
                requestReward = 1;
                if (requestAtt.Contains(itemCheck.GetComponent<potionAttribute>().attribute))
                {
                    requestReward = 3;
                }
                if (charaState <= 3)
                {
                    stars[charaState - 1].SetActive(true);
                    stars[charaState - 1].GetComponent<Animator>().SetInteger("gratitude", requestReward+2);
                }
                else
                {
                    stars[charaState - 1].SetActive(true);
                    stars[charaState - 1].GetComponent<Animator>().SetInteger("gratitude", requestReward);
                }
                charaState++;
                setChara();
                player.gratitude+= requestReward;
                success.Play();

            }
            else if (requestSpecial != null)
            {
                if (itemCheck.name.Contains(requestSpecial.ingredientName))
                {
                    Destroy(requestSlot.transform.GetChild(0).gameObject);
                    requestReward = 5;
                    stars[charaState - 1].SetActive(true);
                    stars[charaState - 1].GetComponent<Animator>().SetInteger("gratitude", requestReward);
                    charaState++;
                    setChara();
                    player.gratitude+=requestReward;
                    success.Play();
                }
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

    public void nextRequest()
    {
        enter.Play();
        charaState++;
        setChara();
        nextChara.SetActive(false);
    }

    public void setChara()
    {
        dia.Clear(); // reset dialogue to start from beginning
        place = 0;
        if (charaState == 1)
        {
            setUpChara();
            dia.Add("Muuya: Hullo Mister Sarvvis! You're still a reindeer, I see. I'm starting to like it.");
            dia.Add("Sarvvis: Hello Muuya. The whole look is growing on me, too. Makes a great conversational topic.");
            dia.Add("Sarvvis: Anyways, what trouble did you get in to today? The snow storm finally calmed so I'm sure you were out and about.");
            dia.Add("Muuya: Not trouble - adventures! The crossbills were twittering about foreigners arriving with the storm, so I asked them to show me the way.");
            dia.Add("Muuya: <b>Weary travellers</b>, they were. Their clothes shimmered like rain so beautifully...");
            dia.Add("Sarvvis: It's useless for me to tell you to be more careful, isn't it.");
            dia.Add("Muuya: Hehe, I think I'll be fine. But, right, I wanted to give them a welcoming gift to <b>refresh them</b>. Like that delicious drink you gave me last time I was <b>completely wiped</b>.");
            dia.Add("Muuya: You know, that one made with a <b>fiery flower</b> and a <b>berry</b>, was it?");
            dia.Add("Sarvvis: Hm, yes, I remember. Very well.");
            request = list.potions["Potion of Healing"];
            requestAtt = "Soothing";
            chara1.SetActive(true);
            StartCoroutine(FadeImage(true));
            StartCoroutine(FadeImage(false));

        }
        else if(charaState == 2)
        {
            dia.Add("Muuya: Lovely!I hope they'll like this, and this place, and that we can be great friends.");
            dia.Add("Sarvvis: And who and where were these people?");
            dia.Add("Muuya: They were in the <b>Rangifer boreal forests</b> to the south. And you don't have to worry, Mister Sarvvis.");
            dia.Add("Muuya: See, it was a lovely witch with her animal friends, and anyone who gets along with animals must be a wonderful person.");
            dia.Add("Sarvvis: Hm, yes, I remember. Very well. Ah, but it seems I am a little low in stock. Let me go out and collect some ingredients first.");
            dia.Add("Muuya: Alright, see you later!");
        }
        else if (charaState == 3) //second request start
        {
            dia.Add("Muuya: I've returned with friends, Mister Sarvvis. As you wished, Raspu and Itsa, the companions of the witch.");
            dia.Add("Raspu: Greetings. So you are the fabled reindeer apothecary. It's a becoming appearance.");
            dia.Add("Sarvvis: Thank you. And welcome. I hope your travels have treated you well.");
            dia.Add("Raspu: Well, I'd like to say it has. We've heard you give aid any peoples and creatures, and we have a little request.");
            dia.Add("Raspu: We didn't come from a friendly place, and our Mistress has been <b>restless as of late</b>, and her powers strangely unstable.");
            dia.Add("Raspu: And for that, we sincerely apologize for the snow storm we brought with us.");
            dia.Add("Muuya: That's alright, we always expect a snow storm or two at this time of year.");
            dia.Add("Raspu: Those are kind words, little Muuya. Apothecary, do you know of anything to give her a <b>bit of peace</b>?");
            dia.Add("Muuya: I personally recommend the one that was <b>wonderfully sweet yet calming</b>. Remember, Mister Sarvvis?");
            dia.Add("Sarvvis: Yes, I do. You're becoming quite bold, aren't you, Muuya. Wait right there, companions of the witch.");
            request = list.potions["Decoction of Clarity"];
            requestAtt = "peace";
            charaNum+=2;
            chara2.SetActive(true);
            chara3.SetActive(true);
            StartCoroutine(FadeImage(true));
            StartCoroutine(FadeImage(false));

            book.maxPlaces++;
        }
        else if (charaState == 4)
        {
            dia.Add("Sarvvis: Pour four tablespoons in some hot tea, once a day, after supper. Let me know how it fares.");
            dia.Add("Raspu: Thank you kindly, Apothecary. We will repay you.");
            dia.Add("Sarvvis: I can always be found if the need arises. Be well.");
        }
        else if (charaState == 5) //third request start
        {
            dia.Add("Sarvvis: Well, this is a rare visitor. What brings you here, spirit of fire and water?");
            dia.Add("Spirit: I am Uuryn, and at the moment, but a lost soul. I have been sent by Topka the domovoi to seek your aid, reindeer healer.");
            dia.Add("Sarvvis: Topka, is it, that little fellow from Muuya's home? Well, I am found by those who seek me. Tell me what it is you need.");
            dia.Add("Uuryn: I was playing far from home with my family, when the recent snow storm swept me away to a <i>place of purple peat and murky waters</i>,");
            dia.Add("...a heavy domain of earth and water.");
            dia.Add("Uuryn: I wandered back a ways, weary and tired, when Topka took me in until I had regained my strength... and has sent me here now.");
            dia.Add("Uuryn: My home is a land of fire and flowing waters, but it seems the <b>heavy cold peat has lingered its curses on me<b>. I miss my home so dearly...");
            dia.Add("Sarvvis: Hmmm, I see, the <i>Siyohrang Pleregenmoore</i>, a bog that <b>drains all fortune</b> from the unprepared.");
            dia.Add("Sarvvis: Perhaps you are in need of but a little replenishment of luck.");
            request = list.potions["Brew of Blessing"];
            requestAtt = "blessing";
            charaNum++;
            chara4.SetActive(true);
            StartCoroutine(FadeImage(true));
            StartCoroutine(FadeImage(false));
            chara1.SetActive(false);
            chara2.SetActive(false);
            chara3.SetActive(false);
        }
        else if (charaState == 6)
        {
            dia.Add("Sarvvis: This will reverse the effects of the bog's poison. Wait a few days for your body to adjust, and you should be able to find your home easily.");
            dia.Add("Uuryn: Thank you kindly, reindeer healer. Surely, your help will not go unrewarded.");
        }
        else if (charaState == 7) //fourth request start
        {
            dia.Add("Topka: Oh Mister Sarvvis, what am I to do?!");
            dia.Add("Sarvvis: Hello Topka. I hope your guest the other day found her way home.");
            dia.Add("Topka: Oh, yes... I should be happy, yet why does my chest ache so much??? I think of Uuryn all day and all night, and I just want to see her again!");
            dia.Add("Sarvvis: Hmmm, sounds like love sickness. There is no cure for that, little house helper. ");
            dia.Add("Topka: Then what am I to do?... Aha, perhaps I shall visit her, and bring her a gift. Oh, but I am terribly unattractive...");
            dia.Add("Topka: But maybe if I can please Uuryn? A <b>charm to make me seem terribly attrative</b>?");
            dia.Add("Is there such a thing? Oh... I must see her... please Mister Sarvvis.");
            dia.Add("Sarvvis: Oh little Topka, are you sure you will leave your hearth? It is not a light sacrifice.");
            dia.Add("Topka: I am sure. I must go to Uuryn.");
            dia.Add("Sarvvis: Hmm... Alright, seeing you are so resolved. I will give you something that will <b>enchant you briefly in the sweetest of charms</b>.");
            request = list.potions["Perfume of Allure"];
            requestAtt = "seduction";
            requestSpecial = list.potions["Eternal Love"];
            charaNum++;
            chara5.SetActive(true);
            StartCoroutine(FadeImage(true));
            StartCoroutine(FadeImage(false));
            chara4.SetActive(false);

            book.maxPlaces++;
        }
        else if (charaState == 8)
        {
            dia.Add("Topka: Thank you reindeer healer! I must go to my lovely!");
            dia.Add("Sarvvis: I don't think you really need it, Topka. I am sure you are charming as you already are.");
            dia.Add("Topka: You are too kind, Mister Sarvvis. And for now, tata!");
        }
        else if (charaState == 9) //fifth request start
        {
            dia.Add("Muuya: Hullo Mister Sarvvis. Topka is gone. To chase his love to the hot springs of the <i>Yellow Ranges</i>. I am happy for him... but now of all times...");
            dia.Add("Sarvvis: Hello Muuya. Hot springs in the <i>Yellow Ranges</i>? That is new.");
            dia.Add("Muuya: Yes, he told us as he left. But my parents' woodcarving is getting busy, and Topka was always a great help. ");
            dia.Add("Muuya: And I've been visiting Miss Yagi so much lately... she's been telling me lots of stories lately, of her homeland to the east.");
            dia.Add("Muuya: But anyways, I've brought my own little carving in hopes you could enchant it. Isn't there a spell to <b>bring this to life</b> for a bit?");
            dia.Add("Muuya: A little creature filled with the <b>lovely warmth</b> and <b>care</b> of the home. At least, until Topka returns.");
            dia.Add("Sarvvis: Well, isn't that a wonderful carving of a domovoi. Perhaps it could be Topka's spiritual little brother. Hmm... I feel I do have a spell somewhere.");
            request = list.potions["Animalcule"];
            requestAtt = "Companionship";
            requestSpecial = list.potions["Brownie Butler"];
            chara1.SetActive(true);
            StartCoroutine(FadeImage(true));
            StartCoroutine(FadeImage(false));
            chara5.SetActive(false);
        }
        else if (charaState == 10)
        {
            dia.Add("Sarvvis: Here we go... And, there! He should last for a time. Don't forget to feed him cookies and milk every night.");
            dia.Add("Muuya: Oh, he's lovely! Mister Sarvvis, how are you so knowledgable about so many things? I'm sure my mum and dad will be happy.");
            dia.Add("Sarvvis: Off you go then, little one. Give my regards to your parents for me.");

        }
        else if (charaState == 11) // 6 SIXTH request start 
        {
            dia.Add("Sarvvis: Why, greetings, friends. Raspu and, the Witch of the Woods. It is the first we have met.");
            dia.Add("Yagi: Hello reindeer apothecary. I'm here to thank you for the help you and Muuya have given us. I haven't felt my head so clear and my body so refreshed in a long time.");
            dia.Add("Raspu: Yes, you have our sincerect gratitude.");
            dia.Add("Sarvvis: No need to be so formal. I am sure you haven't come just for thanks. What is troubling you?");
            dia.Add("Yagi: You are perceptive. I am <b>plagued by nightmares</b>, yet wake in cold sweat without rememberence, left with only a nagging hole inside.");
            dia.Add("Yagi: <b>Comfort eludes me</b>, and this strange forgetfulness...");
            dia.Add("Raspu: You do not need to force yourself to remember, Mistress.");
            dia.Add("Yagi: But there must be <b>something important hidden within my dreams</b>, for the self in the subconscious to smother so dutifully. Reindeer Sarvvis, can you help?");
            dia.Add("Sarvvis: Dreams are always a tricky topic that upset the balance.");
            request = list.potions["Elixir of Dreams"];
            requestAtt = "Dreams";
            requestSpecial = list.potions["Nightmare Crystal"];
            charaNum++;
            chara2.SetActive(true);
            chara6.SetActive(true);
            StartCoroutine(FadeImage(true));
            StartCoroutine(FadeImage(false));
            chara1.SetActive(false);

            book.maxPlaces++;
        }
        else if (charaState == 12)
        {
            dia.Add("Sarvvis: This will help your nightmares. Set it by your bed while you sleep, every night, until its colour becomes black. ");
            dia.Add("Sarvvis: But by then, you should have found your dreams and waking already changed.");
            dia.Add("Sarvvis: And if you so wish, this is the season for the most beautiful of the northern lights at <i>Tenger Gardinur</i>, where many go to seek peace.");
            dia.Add("Yagi: The rumors were true, you are wonderful, reindeer healer. Thank you.");

            charaNum++;
        }
        else if (charaState == 13) // 7 SEVENTH request start 
        {
            dia.Add("Muuya: Mister Sarvvis! I think I have a revelation. About how to help Miss Yagi.");
            dia.Add("Sarvvis: That is definitely something. Pray tell.");
            dia.Add("Muuya: After the medicine you gave Miss Yagi, bits and pieces of her past are returning.");
            dia.Add("She came from an eastern land of hot springs, you know? and her stories are so wonderfully warm and lovely.");
            dia.Add("Muuya: But she's still strangely aching in her heart... And it occured to me she must be missing the hot springs dreadfully. Surely, soaking in them would cheer her up.");
            dia.Add("Sarvvis: And that's where Topka has secretly run off to. I see where you're going.");
            dia.Add("Muuya: Yes. I will go with Raspu to ask the hot spring spirits in the <i>Yellow Ranges</i> if they are willing, because it can be touchy between beings of power.");
            dia.Add("Sarvvis: You are set to go? Do you take after Topka, or is it that Topka takes after the family?");
            dia.Add("Sarvvis: Ha... At least let me give you a <b>charm of protection</b>. Please tell me you've also told your parents.");
            dia.Add("Muuya: They don't mind so much. They say youth should experience the world, like they did. Hopefully, I can find Topka and Uuryn to ask for their help too.");
            request = list.potions["Potion of Protection"];
            requestAtt = "blessing";
            requestSpecial = list.potions["Goddess' Protection"];
            chara1.SetActive(true);
            StartCoroutine(FadeImage(true));
            StartCoroutine(FadeImage(false));
            chara2.SetActive(false);
            chara6.SetActive(false);

            book.maxPlaces++;
        }
        else if (charaState == 14) // 7 dialogue after seventh request is complete
        {
            dia.Add("Sarvvis: Be safe out there, little one.");
            dia.Add("Muuya: Thank you Mister Sarvvis! I will be back soon!");
        }
        else if (charaState == 15) // 8 EIGHTH request start 
        {
            dia.Add("Uuryn: It is good we meet again, reindeer healer.");
            dia.Add("Sarvvis: Hello, Uuryn. Muuya and Raspu must have found you then? And Topka?");
            dia.Add("Uuryn: Ah, yes. Topka is lovely...*blush* and I have a debt to repay to you. We are also a clan of healers, and I am sure we can be of help.");
            dia.Add("Uuryn: From what we hear of the Witch's past, even our special waters will not be quite enough. Her past is deeply <b>frozen</b> inside her <b>innermost depths</b>.");
            dia.Add("Uuryn: We only need but a charm to our healing waters to flow deeper into her inner being.");
            dia.Add("Sarvvis: \"</b>That which is sleeping must be awoken...\"</b>");
            dia.Add("Sarvvis: Hmmm, I see. ");
            request = list.potions["Silver Water"];
            requestAtt = "awakening";
            requestSpecial = list.potions["Steaming Elixir"];
            chara4.SetActive(true);
            StartCoroutine(FadeImage(true));
            StartCoroutine(FadeImage(false));
            chara1.SetActive(false);
        }
        else if (charaState == 16)
        {
            dia.Add("Uuryn: Wonderful. Now this is a debt repaid, Sarvvis the reindeer healer.");
            dia.Add("Uuryn: I had thought the storm was terrible, but it was surely a force of fortune. You are welcome at the Yellow Ranges anytime.");
            dia.Add("Sarvvis: Thank you, Uuryn, and your peoples.");
        }
        else if (charaState == 17) 
        {
            dia.Add("Muuya: I'm finally back, Mister Sarvvis. It is wonderful. See how Miss Yagi has become!");
            dia.Add("Yagi: Hello reindeer healer. It must have been fate that brought me to this peoples here. My former self has been restored.");
            dia.Add("Sarvvis: Well now. Who would have known. I am glad that I could be of help.");
            dia.Add("Yagi: I remember, now, what duties I have as a Witch of the Winds and Woods. I will stay here to protect from the evil and dirt of the world, as I had done in my homelands.");
            dia.Add("Yagi: And the kindly hot springs peoples will let me bathe when ever I so wish, so I will not clog with ice again.");
            dia.Add("Yagi: These lovely people that have welcomed and helped me will be cherished.");
            dia.Add("Muuya: I'm so happy you'll stay, Miss Yagi. You must tell me more stories, too. I was right that we would be good friends.");
            dia.Add("Sarvvis: That is a wonderful end to another beginning. I will always be here when need calls.");
            endButton.SetActive(true);
            chara7.SetActive(true);
            StartCoroutine(FadeImage(true));
            StartCoroutine(FadeImage(false));
            chara4.SetActive(false);
        }
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                chara1.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, i);
                chara2.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, i);
                chara3.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, i);
                chara4.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, i);
                chara5.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, i);
                chara6.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, i);
                chara7.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                chara1.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, i);
                chara2.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, i);
                chara3.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, i);
                chara4.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, i);
                chara5.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, i);
                chara6.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, i);
                chara7.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}
