using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ingredientScript : MonoBehaviour {
    //mixture
    public GameObject[] mixingInventory;
    //mixing arrays
    public GameObject[] m_slots;
    public ArrayList m_ingredients;

    //mixing area
    public GameObject mixButton;
    public GameObject mixArea;
    public bool mixState;

    //player
    public GameObject[] playerInventory;
    //player array
    public ArrayList p_ingredients;
    public playerScript player;

    public GameObject recipePages;
    public GameObject ingredientPages;

    //new system
    public GameObject defaultIngredient;
    public GameObject defaultPotion;

    //scavenge
    public scavengeScript scavenging;
    public GameObject modal;

    public bookScript book;

    public AudioSource bubbles;
    public AudioSource stir;
    public AudioSource trashSound;

    public ingredientAttribute ing1;
    public ingredientAttribute ing2;
    public ingredientAttribute ing3;
    public ingredientAttribute ing4;
    public ingredientAttribute ing5;
    public ingredientAttribute ing6;
    public ingredientAttribute ing7;
    public ingredientAttribute ing8;
    public ingredientAttribute ing9;

    public Dictionary<string, ingredientAttribute> ingredients;

    public potionAttribute pot1;
    public potionAttribute pot2;
    public potionAttribute pot3;
    public potionAttribute pot4;
    public potionAttribute pot5;
    public potionAttribute pot6;
    public potionAttribute pot7;
    public potionAttribute pot8;

    public potionAttribute spot1;
    public potionAttribute spot2;
    public potionAttribute spot3;
    public potionAttribute spot4;
    public potionAttribute spot5;
    public potionAttribute spot6;
    public potionAttribute spot7;
    public potionAttribute spot8;
    public potionAttribute spot9;
    public Dictionary<string, potionAttribute> potions;

    // Use this for initialization
    void Start () {
        defaultIngredient = (GameObject)(Resources.Load("Ingredient"));
        defaultPotion = (GameObject)(Resources.Load("Potion"));

        recipePages = GameObject.FindGameObjectWithTag("recipePage");
        ingredientPages = GameObject.FindGameObjectWithTag("ingredientPage");

         mixingInventory = GameObject.FindGameObjectsWithTag("mixingInventory");
         playerInventory = GameObject.FindGameObjectsWithTag("playerInventory").OrderBy(go => go.name).ToArray();
         m_slots = new GameObject[mixingInventory.Length];
         m_ingredients = new ArrayList();
         p_ingredients = new ArrayList();

        mixButton = GameObject.Find("mixButton");
        mixArea = GameObject.Find("mixInventory");

        mixArea.SetActive(false);
        mixButton.SetActive(false);
        mixState = false;

        modal = GameObject.Find("pickUpModal");
        modal.SetActive(false);

        book = GameObject.Find("Book").GetComponent<bookScript>();

        scavenging = GameObject.Find("Scavenger Hunt").GetComponent<scavengeScript>();

        player.toggleItem();

        bubbles = GameObject.Find("cauldronSound").GetComponent<AudioSource>();
        stir = GameObject.Find("mixAreaSound").GetComponent<AudioSource>();
    }

    void Update()
    {
        for (int i = 0; i < mixingInventory.Length; i++)
        {
            if (mixingInventory[i].gameObject.transform.childCount != 0)
            {
                m_slots[i] = mixingInventory[i].gameObject.transform.GetChild(0).gameObject;
            }
            else m_slots[i] = null;
        }
    }

    public void test()
    {
        for (int j = 0; j < playerInventory.Length; j++)
        {
            if (playerInventory[j].gameObject.transform.childCount == 0)
            {
                Transform panel = playerInventory[j].transform;

                GameObject a = Instantiate(defaultPotion);
                potionAttribute test = a.AddComponent<potionAttribute>();
                a.GetComponent<UnityEngine.UI.Image>().sprite = potions["Potion of Healing"].img;
                a.name = potions["Potion of Healing"].ingredientName;
                test.setAttribute("Rejuvenate");
                a.transform.SetParent(panel.transform, false);

                Transform panel2 = playerInventory[j + 1].transform;

                GameObject b = Instantiate(defaultIngredient);
                ingredientAttribute test2 = b.AddComponent<ingredientAttribute>();
                test2 = ingredients["Torched Perunika"];
                b.GetComponent<UnityEngine.UI.Image>().sprite = test2.img;
                b.name = test2.ingredientName;
                b.transform.SetParent(panel2.transform, false);

                Transform panel3 = playerInventory[j + 2].transform;

                GameObject c = Instantiate(defaultIngredient);
                ingredientAttribute test3 = c.AddComponent<ingredientAttribute>();
                test3 = ingredients["Ethereal Billberry"];
                c.GetComponent<UnityEngine.UI.Image>().sprite = test3.img;
                c.name = test3.ingredientName;
                c.transform.SetParent(panel3.transform, false);

                break;
            }
        }
    }

    public void setupDictionary()
    {
        /*
        INGREDIENTS
        */
        ing1 = new ingredientAttribute("Midnight Fern", "Solitude", "They grow in the <b>isolated</b> shadowed cliffs of the <i>Yellow Ranges</i>, and draw in the holder to <b>introspection</b> and the desire for <b>solitude</b>.", Resources.Load<Sprite>("fern_midnight"));
        ing2 = new ingredientAttribute("Blooming Fern", "Luck", "An undying symbol of <b>good fortune</b> and <b>luck</b>, yet it should be plucked with care. Who knows what too much fortune can bring?", Resources.Load<Sprite>("fern_blooming"));
        ing3 = new ingredientAttribute("Tormented Fern", "Opposition", "Stunted in growth and never known to unfurl, its nature <b>reverses</b> properties like the clenched fist of <b>opposition</b>.", Resources.Load<Sprite>("fern_tormented"));
        ing4 = new ingredientAttribute("Ethereal Billberry", "Serenity", "Those who eat of this berry are overcome by a state of <b>serenity</b> and otherworldly one-ness with the world. They are found growing next to torched perunika in seeming <b>calm</b> and disregard.", Resources.Load<Sprite>("billberry_ethereal"));
        ing5 = new ingredientAttribute("Bog Billberry", "Poison", "Found only in the <i>Siyohrang Planregenmoore</i>, it has been dyed purple with <b>poison</b>. Yet, a good measure has <b>balancing effects</b> with other ingredients.", Resources.Load<Sprite>("billberry_bog"));
        ing6 = new ingredientAttribute("Dwarf Billberry", "Sweet", "Little <b>juicy sweet</b> berries of all things good and wonderful. They have <b>lovely scent</b> that entices all residents of the <i>boreal</i>.", Resources.Load<Sprite>("billberry_dwarf"));
        ing7 = new ingredientAttribute("Violet Perunika", "Love", "A strain with small petals of deep purple in the <i>Siyohrang Planregenmoore</i>. Their unlikely beauty amidst poison have driven people to relate it with <b>love</b> that wins over all obstacles.", Resources.Load<Sprite>("perunika_violet"));
        ing8 = new ingredientAttribute("Divine Perunika", "Sanctity", "It glows with a <b>saintly blue</b> like the lights of the Tenger Gardinur, and is the flower of the goddess of <b>virtue</b>. Their potent scent is mysteriously undefinable.", Resources.Load<Sprite>("perunika_divine"));
        ing9 = new ingredientAttribute("Torched Perunika", "Warmth", "They are said to be born from lightning in the storm-ridden <i>Tarandus Highland Taiga</i>. Their petals <b>promote warmth</b>, and is often used in internal healing.", Resources.Load<Sprite>("perunika_torched"));

        ingredients = new Dictionary<string, ingredientAttribute>()
        {
            {"Midnight Fern", ing1},
            {"Blooming Fern", ing2},
            {"Tormented Fern", ing3},
            {"Ethereal Billberry", ing4},
            {"Bog Billberry", ing5},
            {"Dwarf Billberry", ing6},
            {"Violet Perunika", ing7},
            {"Divine Perunika", ing8},
            {"Torched Perunika", ing9}
        };

        /*
        POTIONS
        ING + ING
        */
        pot1 = new potionAttribute("Brew of Blessing", "Blessing, Fortune, Rejuvenation", "A brew made of the <b>fortitious flowering fern</b>, it entices the lady of fortune to smile kindly on whoever drinks it", Resources.Load<Sprite>("brew_of_blessing"));
        pot2 = new potionAttribute("Potion of Healing", "Soothing, Rejuvenation", "For the wounds that can be healed with the <b>warmth</b> of the hearth and heart. Can help calm a restless mind, and a little <b>love</b> makes a more soothing concoction.", Resources.Load<Sprite>("potion_of_healing"));
        pot3 = new potionAttribute("Animalcule", "Companionship, Soothing", "Microscopic creatures enter the bloodstream for a short time, often administered in a liquid solution. First discovered in the Caves of Porewit decades ago, these creatures have been increasingly used for medicinal purposes.", Resources.Load<Sprite>("animalcule"));
        pot4 = new potionAttribute("Elixir of Dreams", "Dreams, Passion", "Once taken, the <b>fire of the heart</b> will be ignited and the lock undone on the wellspring of <b>desires</b>. The effects may vary person to person.", Resources.Load<Sprite>("elixir_of_dreams"));
        pot5 = new potionAttribute("Perfume of Allure", "Seduction, Dreams, Passion", "A fresh smelling spritzer that is known to make the wearer more <b>intriguing</b>.", Resources.Load<Sprite>("perfume_of_allure"));
        pot6 = new potionAttribute("Potion of Protection", "Immunity, Blessing", "A bitter, fizzy potion often used by military and those <b>seeking the protection</b> of the Gods.", Resources.Load<Sprite>("potion_of_protection"));
        pot7 = new potionAttribute("Silver Water", "Awakening, Reflection, Sleep", "It seems to sparkle like moonlight even where no light shines, and is said to connect to the hidden landscapes of the <b>unconscious</b>.", Resources.Load<Sprite>("silver_water"));
        pot8 = new potionAttribute("Decoction of Clarity", "Peace, Wisdom", "A harsh shot used to <b>stir the mind</b>. This decoction is created by extracting the essences of the ingredients to create a dense brew.", Resources.Load<Sprite>("decoction_of_clarity"));
        /* 
        SPECIAL POTIONS 
        POT + ING
        */
        spot1 = new potionAttribute("Balm of Realization", "Awakening", "A salve that, when rubbed on the eyelid, will allow the user to see that which was hidden. It is said to reveal the true intentions of others and at times lead to the invention of mythical objects. It is used by powerful witches to capture spirits.",
            Resources.Load<Sprite>("balm_realization"));
        spot2 = new potionAttribute("Nightmare Crystal", "Nightmare", "The crystal, when placed in the north west corner of the bed, will capture bad spirits and prevent nightmares. Some say that Marowit dwells within the crystal and feasts upon the nightmares.",
            Resources.Load<Sprite>("nightmare_crystal"));
        spot3 = new potionAttribute("Midnight Moonlight", "Night", "A spirit that has been soaked in moonlight for 30 moons, purified in the 1000 year old well water, and sprinkled with aged berries. It is said to be blessed by the fairies of the night.",
            Resources.Load<Sprite>("midnight_moonlight"));
        spot4 = new potionAttribute("Goddess' Protection", "Protection", "This potion calls upon the ranger goddess Dziewona to protect the imbiber. Often consumed by hunters before a dangerous expedition into the Black Forest.",
            Resources.Load<Sprite>("goddess_protection"));
        spot5 = new potionAttribute("Brownie Butler", "Helper", "A loyal household fairy that takes care of the chores during the early hours of the morning. They often have tails and small horns, resembling the animal that is closest to the house's soul. ",
            Resources.Load<Sprite>("brownie_butler"));
        spot6 = new potionAttribute("Eternal Love", "Love", "The quintessential love potion, used to create pure obsession (not actual love) in whoever ingests it. Well known to cause a lot of problems once it's effects wear off.",
            Resources.Load<Sprite>("eternal_love"));
        spot7 = new potionAttribute("Homunculus", "Soul", "A protective spirit that replicates the creator's soul and will sacrifice itself when the creator is in mortal danger.",
            Resources.Load<Sprite>("homunculus"));
        spot8 = new potionAttribute("Dream Catcher", "Dreams", "A viscous concoction that is primarily used by insomniacs to maintain a steady sleep pattern. Can be incorporated into a sleep schedule to maintain regular dreaming.",
            Resources.Load<Sprite>("dream_catcher"));
        spot9 = new potionAttribute("Steaming Elixir", "Awakening", "A powerful, hot brew. It's contents will shock the tongue of the consumer, waking them from even the deepest of sleeps.",
            Resources.Load<Sprite>("steaming_elixir"));
        potions = new Dictionary<string, potionAttribute>()
        {
            {"Brew of Blessing", pot1},
            {"Potion of Healing", pot2},
            {"Animalcule", pot3},
            {"Elixir of Dreams", pot4},
            {"Perfume of Allure", pot5},
            {"Potion of Protection", pot6},
            {"Silver Water", pot7},
            {"Decoction of Clarity", pot8},
            {"Balm of Realization", spot1},
            {"Nightmare Crystal", spot2},
            {"Midnight Moonlight", spot3},
            {"Goddess' Protection", spot4},
            {"Brownie Butler", spot5},
            {"Eternal Love", spot6},
            {"Homunculus", spot7},
            {"Dream Catcher", spot8},
            {"Steaming Elixir", spot9}
        };
    }

    public void mix()
    {
        bool mfern = false;
        bool bfern = false;
        bool tfern = false;
        bool ebill = false;
        bool bbill = false;
        bool dbill = false;
        bool vper = false;
        bool dper = false;
        bool tper = false;

        bool dclarity = false;
        bool anima = false;
        bool edreams = false;
        bool pallure = false;
        bool pprotect = false;
        bool swater = false;

        for (int i = 0; i < m_slots.Length; i++)
        {
            if (m_slots[i] != null)
            {
                if (m_slots[i].gameObject.name.Equals(ingredients["Midnight Fern"].ingredientName))  mfern = true;
                else if (m_slots[i].gameObject.name.Equals(ingredients["Blooming Fern"].ingredientName)) bfern = true;
                else if (m_slots[i].gameObject.name.Equals(ingredients["Tormented Fern"].ingredientName)) tfern = true;
                else if (m_slots[i].gameObject.name.Equals(ingredients["Ethereal Billberry"].ingredientName)) ebill = true;
                else if (m_slots[i].gameObject.name.Equals(ingredients["Bog Billberry"].ingredientName)) bbill = true;
                else if (m_slots[i].gameObject.name.Equals(ingredients["Dwarf Billberry"].ingredientName)) dbill = true;
                else if (m_slots[i].gameObject.name.Equals(ingredients["Divine Perunika"].ingredientName)) dper = true;
                else if (m_slots[i].gameObject.name.Equals(ingredients["Torched Perunika"].ingredientName)) tper = true;
                else if (m_slots[i].gameObject.name.Equals(ingredients["Violet Perunika"].ingredientName)) vper = true;

                else if (m_slots[i].gameObject.name.Equals(potions["Decoction of Clarity"].ingredientName)) dclarity = true;
                else if (m_slots[i].gameObject.name.Equals(potions["Animalcule"].ingredientName)) anima = true;
                else if (m_slots[i].gameObject.name.Equals(potions["Elixir of Dreams"].ingredientName)) edreams = true;
                else if (m_slots[i].gameObject.name.Equals(potions["Potion of Allure"].ingredientName)) pallure = true;
                else if (m_slots[i].gameObject.name.Equals(potions["Potion of Protection"].ingredientName)) pprotect = true;
                else if (m_slots[i].gameObject.name.Equals(potions["Silver Water"].ingredientName)) swater = true;
            }
        }

        if (mfern && ebill)
        {
            addPotion("Decoction of Clarity", "Awakening");
        }
        else if ((mfern && dbill) || (dbill && ebill))
        {
            addPotion("Decoction of Clarity", "Peace");
        }
        else if (mfern && dper)
        {
            addPotion("Decoction of Clarity", "Wisdom");
        }
        else if (mfern && bbill)
        {
            addPotion("Silver Water", "Reflection");
        }
        else if (tfern && tper)
        {
            addPotion("Silver Water", "Awakening");
        }
        else if (bbill && ebill) {
            addPotion("Silver Water", "Sleep");
        }
        else if ((mfern && tper) || (vper && dper))
        {
            addPotion("Elixir of Dreams", "Dreams");
        }
        else if ((mfern && vper) || (tper && vper))
        {
            addPotion("Elixir of Dreams", "Passion");
        }
        else if ((mfern && tfern) || (vper && dbill))
        {
            addPotion("Animalcule", "Companionship");
        }
        else if (dper && dbill)
        {
            addPotion("Animalcule", "Soothing");
        }
        else if (mfern && bfern)
        {
            addPotion("Brew of Blessing", "Fortune");
        }
        else if (bfern && dbill)
        {
            addPotion("Brew of Blessing", "Rejuvanation");
        }
        else if (bfern && tper)
        {
            addPotion("Brew of Blessing", "Blessing");
        }
        else if (bfern && vper)
        {
            addPotion("Brew of Blessing", "Blessing");
        }
        else if (bfern && dper)
        {
            addPotion("Potion of Protection", "Blessing");
        }
        else if (tfern && ebill)
        {
            addPotion("Potion of Protection", "Blessing");
        }
        else if (dper && bbill) {
            addPotion("Potion of Protection", "Immunity");
        }
        else if (tfern && dbill)
        {
            addPotion("Perfume of Allure", "Dreams");
        }
        else if (vper && bbill) {
            addPotion("Perfume of Allure", "Passion");
        }
        else if ((tper && bbill) || (dbill && bbill)) {
            addPotion("Perfume of Allure", "Seduction");
        }
        else if (vper && ebill)
        {
            addPotion("Potion of Healing", "Soothing");
        }
        else if (tper && ebill)
        {
            addPotion("Potion of Healing", "Soothing");
        }
        else if (tper && dbill) {
            addPotion("Potion of Healing", "Rejuvenation");
        }

        // HERE BEGINS SPECIAL POTIONS CHECKING
        else if (dclarity && ebill) {
            addPotion("Balm of Realization", "Awakening");
        }
        else if (anima && tper) {
            addPotion("Brownie Butler", "Helper");
        }
        else if (anima && mfern) {
            addPotion("Homunculus", "Soul");
        }
        else if (edreams && bbill) {
            addPotion("Nightmare Crystal", "Nightmare");
        }
        else if (pallure && vper) {
            addPotion("Eternal Love", "Love");
        }
        else if (pprotect && dper) {
            addPotion("Goddess' Protection", "Protection");
        }
        else if (swater && dbill) {
            addPotion("Midnight Moonlight", "Night");
        }
        else if (swater && tper) {
            addPotion("Steaming Elixir", "Awakening");
        }
        else if (swater && mfern) {
            addPotion("Dream Catcher", "Dreams");
        }

    }

    void addPotion(string s, string att)
    {
        for (int j = 0; j < playerInventory.Length; j++)
        {
            if (playerInventory[j].gameObject.transform.childCount == 0)
            {
                Transform panel = playerInventory[j].transform;

                GameObject a = Instantiate(defaultPotion);
                potionAttribute test = a.AddComponent<potionAttribute>();
                a.GetComponent<UnityEngine.UI.Image>().sprite = potions[s].img;
                a.name = potions[s].ingredientName;
                test.setAttribute(att);
                a.transform.SetParent(panel.transform, false);
                player.modalPopUp(a.name, test.attribute, a.GetComponent<UnityEngine.UI.Image>().sprite);
                for (int h = 0; h < m_slots.Length; h++)
                {
                    if (m_slots[h] != null)
                    {
                        Destroy(m_slots[h]);
                    }
                }
                bool added = false;
                for (int k = 0; k < recipePages.transform.childCount; k++)
                {
                    if (recipePages.transform.GetChild(k).transform.FindChild("title").GetComponent<Text>().text != s)
                    {
                        added = false;
                    }
                    else
                    {
                        added = true;
                        k = recipePages.transform.childCount - 1;
                    }
                }
                if (!added) addRecipePage(s);

                bubbles.Play();
                break;
            }    
        }
    }

    public void addIngredients(int i)
    {
        for (int j = 0; j <= playerInventory.Length - 2; j++)
        {
            if (playerInventory[j].gameObject.transform.childCount == 0 && i == 1)
            {
                Transform panel = playerInventory[j].transform;

                GameObject a = Instantiate(defaultIngredient);
                ingredientAttribute test = a.AddComponent<ingredientAttribute>();
                if (Random.Range(0, 100) > 50)
                {
                    test = ingredients["Torched Perunika"];
                }
                else test = ingredients["Ethereal Billberry"];
                a.GetComponent<UnityEngine.UI.Image>().sprite = test.img;
                a.name = test.ingredientName;
                a.transform.SetParent(panel.transform, false);

                modal.SetActive(true);
                modal.GetComponentInChildren<SpriteRenderer>().sprite = test.img;
                scavenging.Fade();

                bool added1 = false;
                for (int k = 0; k < ingredientPages.transform.childCount; k++)
                {
                    if (ingredientPages.transform.GetChild(k).transform.FindChild("title").GetComponent<Text>().text != (test.ingredientName))
                    {
                        added1 = false;
                    }
                    else
                    {
                        added1 = true;
                        k = ingredientPages.transform.childCount - 1;
                    }
                }
                if (!added1) addIngredientPage(test.ingredientName);
                break;
            }
            else if (playerInventory[j].gameObject.transform.childCount == 0 && i == 2)
            {
                Transform panel = playerInventory[j].transform;

                GameObject a = Instantiate(defaultIngredient);
                ingredientAttribute test = a.AddComponent<ingredientAttribute>();
                if (Random.Range(0, 100) > 50)
                {
                    test = ingredients["Dwarf Billberry"];
                }
                else test = ingredients["Blooming Fern"];
                a.GetComponent<UnityEngine.UI.Image>().sprite = test.img;
                a.name = test.ingredientName;
                a.transform.SetParent(panel.transform, false);

                modal.SetActive(true);
                 modal.GetComponentInChildren<SpriteRenderer>().sprite = test.img;
                scavenging.Fade();

                bool added1 = false;
                for (int k = 0; k < ingredientPages.transform.childCount; k++)
                {
                    if (ingredientPages.transform.GetChild(k).transform.FindChild("title").GetComponent<Text>().text != (test.ingredientName))
                    {
                        added1 = false;
                    }
                    else
                    {
                        added1 = true;
                        k = ingredientPages.transform.childCount - 1;
                    }
                }
                if (!added1) addIngredientPage(test.ingredientName);
                break;
            }
            else if (playerInventory[j].gameObject.transform.childCount == 0 && i == 3)
            {
                Transform panel = playerInventory[j].transform;

                GameObject a = Instantiate(defaultIngredient);
                ingredientAttribute test = a.AddComponent<ingredientAttribute>();
                if (Random.Range(0, 100) > 50) {
                    test = ingredients["Bog Billberry"];
                }else test = ingredients["Violet Perunika"];
                a.GetComponent<UnityEngine.UI.Image>().sprite = test.img;
                a.name = test.ingredientName;
                a.transform.SetParent(panel.transform, false);

                modal.SetActive(true);
                 modal.GetComponentInChildren<SpriteRenderer>().sprite = test.img;
                scavenging.Fade();

                bool added1 = false;
                for (int k = 0; k < ingredientPages.transform.childCount; k++)
                {
                    if (ingredientPages.transform.GetChild(k).transform.FindChild("title").GetComponent<Text>().text != (test.ingredientName))
                    {
                        added1 = false;
                    }
                    else
                    {
                        added1 = true;
                        k = ingredientPages.transform.childCount - 1;
                    }
                }
                if (!added1) addIngredientPage(test.ingredientName);

                break;
            }
            else if (playerInventory[j].gameObject.transform.childCount == 0 && i == 4)
            {
                Transform panel = playerInventory[j].transform;

                GameObject a = Instantiate(defaultIngredient);
                ingredientAttribute test = a.AddComponent<ingredientAttribute>();
                if (Random.Range(0, 100) > 50)
                {
                    test = ingredients["Divine Perunika"];
                }
                else test = ingredients["Midnight Fern"];
                a.GetComponent<UnityEngine.UI.Image>().sprite = test.img;
                a.name = test.ingredientName;
                a.transform.SetParent(panel.transform, false);

                modal.SetActive(true);
                 modal.GetComponentInChildren<SpriteRenderer>().sprite = test.img;
                scavenging.Fade();

                bool added1 = false;
                for (int k = 0; k < ingredientPages.transform.childCount; k++)
                {
                    if (ingredientPages.transform.GetChild(k).transform.FindChild("title").GetComponent<Text>().text != (test.ingredientName))
                    {
                        added1 = false;
                    }
                    else
                    {
                        added1 = true;
                        k = ingredientPages.transform.childCount - 1;
                    }
                }
                if (!added1) addIngredientPage(test.ingredientName);
                break;
            }
            else if (playerInventory[j].gameObject.transform.childCount == 0 && i == 5)
            {
                Transform panel = playerInventory[j].transform;

                GameObject a = Instantiate(defaultIngredient);
                ingredientAttribute test = a.AddComponent<ingredientAttribute>();
                if (Random.Range(0, 100) > 50)
                {
                    test = ingredients["Tormented Fern"];
                }
                else test = ingredients["Midnight Fern"];
                a.GetComponent<UnityEngine.UI.Image>().sprite = test.img;
                a.name = test.ingredientName;
                a.transform.SetParent(panel.transform, false);

                modal.SetActive(true);
                 modal.GetComponentInChildren<SpriteRenderer>().sprite = test.img;
                scavenging.Fade();

                bool added1 = false;
                for (int k = 0; k < ingredientPages.transform.childCount; k++)
                {
                    if (ingredientPages.transform.GetChild(k).transform.FindChild("title").GetComponent<Text>().text != (test.ingredientName))
                    {
                        added1 = false;
                    }
                    else
                    {
                        added1 = true;
                        k = ingredientPages.transform.childCount - 1;
                    }
                }
                if (!added1) addIngredientPage(test.ingredientName);
                break;
            }
        }
    }

    public void addRecipePage(string s)
    {
        if (recipePages.transform.childCount % 2 == 0)
        {
            Transform panel = recipePages.transform;

            GameObject a = (GameObject)Instantiate(Resources.Load("recipe - left"));
            a.transform.Find("ingredient picture").GetComponent<Image>().sprite = potions[s].img;
            a.transform.Find("title").GetComponent<Text>().text = potions[s].ingredientName;
            a.transform.Find("description").GetComponent<Text>().text = potions[s].description;
            a.transform.Find("attributes").GetComponent<Text>().text = potions[s].attribute;
            a.SetActive(false);
            a.transform.SetParent(panel, false);
        }
        else
        {
            Transform panel = recipePages.transform;

            GameObject a = (GameObject)Instantiate(Resources.Load("recipe - right"));
            a.transform.Find("ingredient picture").GetComponent<Image>().sprite = potions[s].img;
            a.transform.Find("title").GetComponent<Text>().text = potions[s].ingredientName;
            a.transform.Find("description").GetComponent<Text>().text = potions[s].description;
            a.transform.Find("attributes").GetComponent<Text>().text = potions[s].attribute;
            a.SetActive(false);
            a.transform.SetParent(panel.transform, false);
        }

        if(book._currentPage == book._recipePage)
        {
            book.recipeSwitch();
        }
    }

    public void addIngredientPage(string s)
    {
        if (ingredientPages.transform.childCount % 2 == 0)
        {
            Transform panel = ingredientPages.transform;

            GameObject a = (GameObject)Instantiate(Resources.Load("recipe - left"));
            a.transform.Find("ingredient picture").GetComponent<Image>().sprite = ingredients[s].img;
            a.transform.Find("title").GetComponent<Text>().text = ingredients[s].ingredientName;
            a.transform.Find("description").GetComponent<Text>().text = ingredients[s].description;
            a.transform.Find("attributes").GetComponent<Text>().text = ingredients[s].attribute;
            a.SetActive(false);
            a.transform.SetParent(panel.transform, false);
        }else
        {
            Transform panel = ingredientPages.transform;

            GameObject a = (GameObject)Instantiate(Resources.Load("recipe - right"));
            a.transform.Find("ingredient picture").GetComponent<Image>().sprite = ingredients[s].img;
            a.transform.Find("title").GetComponent<Text>().text = ingredients[s].ingredientName;
            a.transform.Find("description").GetComponent<Text>().text = ingredients[s].description;
            a.transform.Find("attributes").GetComponent<Text>().text = ingredients[s].attribute;
            a.SetActive(false);
            a.transform.SetParent(panel.transform, false);
        }
    }

    public void mixSwitch()
    {
        if (mixState)
        {
            StartCoroutine(mixFadeIn(false));
            mixButton.SetActive(false);
            mixState = false;
        }else
        {
            stir.Play();
            mixArea.SetActive(true);
            StartCoroutine(mixFadeIn(true));
            mixButton.SetActive(true);
            mixState = true;
        }
    }

    private IEnumerator mixFadeIn(bool fade)
    {
        if (fade)
        {
            for (float i = 0; i <= 1; i += Time.deltaTime * 3)
            {
                // set color with i as alpha
                mixArea.GetComponentInChildren<Image>().color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        else
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime * 3)
            {
                // set color with i as alpha
                mixArea.GetComponentInChildren<Image>().color = new Color(1, 1, 1, i);
                yield return null;  
            }
            mixArea.SetActive(false);
        }
    }
}
