using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingredientScript : MonoBehaviour {
    //mixture
    public GameObject[] mixingInventory;
    //mixing arrays
    public GameObject[] m_slots;
    //mixture
    public GameObject[] mixingInventory2;
    //mixing arrays
    public GameObject[] m_slots2;
    public ArrayList m_ingredients;

    //player
    public GameObject[] playerInventory;
    //player array
    public ArrayList p_ingredients;
    public playerScript player;

    public GameObject recipePages;

    //new system
    public GameObject defaultIngredient;
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
    public Dictionary<string, potionAttribute> potions;

    public potionAttribute spot1;
    public potionAttribute spot2;
    public potionAttribute spot3;
    public potionAttribute spot4;
    public potionAttribute spot5;
    public potionAttribute spot6;
    public potionAttribute spot7;
    public potionAttribute spot8;
    public Dictionary<string, potionAttribute> specialPotions;

    // Use this for initialization
    void Start () {
         defaultIngredient = (GameObject)Instantiate(Resources.Load("Ingredient"));
        recipePages = GameObject.FindGameObjectWithTag("recipePage");
        addPage();

         mixingInventory = GameObject.FindGameObjectsWithTag("mixingInventory");
         mixingInventory2 = GameObject.FindGameObjectsWithTag("mixingInventory");
         playerInventory = GameObject.FindGameObjectsWithTag("playerInventory");
         m_slots = new GameObject[mixingInventory.Length];
         m_slots2 = new GameObject[mixingInventory.Length];
         m_ingredients = new ArrayList();
         p_ingredients = new ArrayList();
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
        for (int i = 0; i < mixingInventory2.Length; i++)
        {
            if (mixingInventory2[i].gameObject.transform.childCount != 0)
            {
                m_slots2[i] = mixingInventory2[i].gameObject.transform.GetChild(0).gameObject;
            }
            else m_slots2[i] = null;
        }
    }

    public void setupDictionary()
    {
        /*
        INGREDIENTS
        */
        ing1 = new ingredientAttribute("Midnight Fern", "Solitude", "Midnight Fern, with it's dark blue leaves, is used in potion-making for is introspective effects, often inspiring consumers to seek solitude.", Resources.Load<Sprite>("fern_midnight"));
        ing2 = new ingredientAttribute("Blooming Fern", "Luck", "Blooming Ferns are rare, and when found they are prized as good luck charms.", Resources.Load<Sprite>("fern_blooming"));
        ing3 = new ingredientAttribute("Tormented Fern", "Opposition", "The Tormented Fern is an pungent variety reverses many effects in potion recipes. Known for producing powerful opposition energy, and for it’s scent which can bring people instantly out of sleep.", Resources.Load<Sprite>("fern_tormented"));
        ing4 = new ingredientAttribute("Ethereal Billberry", "Serenity", "Ethereal Bilberries are flavourless, but they commonly imbue a feeling of serenity in the consumer.", Resources.Load<Sprite>("billberry_ethereal"));
        ing5 = new ingredientAttribute("Bog Billberry", "Poison", "Bog Billberries are the opposite: bitter and highly poisonous. They are also commonly used in perfumes when mixed with something pleasant smelling or tasting.", Resources.Load<Sprite>("billberry_bog"));
        ing6 = new ingredientAttribute("Dwarf Billberry", "Sweet", "Dwarf Billberries are very sweet, in taste and in personality. They have been known to increase clarity when mixed in potions.", Resources.Load<Sprite>("billberry_dwarf"));
        ing7 = new ingredientAttribute("Violet Perunika", "Love", "The blessed violet Perunika a beautiful, deeply hued variety, often gifted to express love, affection and caring. They smell musky, however.", Resources.Load<Sprite>("perunika_violet"));
        ing8 = new ingredientAttribute("Divine Perunika", "Sanctity", "Divine Perunika has been decalared a holy plant, as it grows in only the most sacred regions. Their potent scent is mysteriously undefinable.", Resources.Load<Sprite>("perunika_divine"));
        ing9 = new ingredientAttribute("Torched Perunika", "Warmth", "Torched Perunika is the name for a variety of the flower that grows in the highest mountains, often getting struck by lightning. These perunika are perpetually warm to the touch and smell like lavender.", Resources.Load<Sprite>("perunika_torched"));

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
        pot1 = new potionAttribute("Brew of Blessing", "Blessing", "A brew made of the fortitious flowering fern, it entices the lady of fortune to smile kindly on whoever drinks it", Resources.Load<Sprite>("brew_of_blessing"));
        pot2 = new potionAttribute("Potion of Healing", "Rejuvenation", "For the wounds that can be healed with the warmth of the hearth and heart. Can help calm a restless mind, and a little love makes a more soothing concoction.", Resources.Load<Sprite>("potion_of_healing"));
        pot3 = new potionAttribute("Animalcule", "Companionship", "Microscopic creatures enter the bloodstream for a short time, often administered in a liquid solution. First discovered in the Caves of Porewit decades ago, these creatures have been increasingly used for medicinal purposes.", Resources.Load<Sprite>("animalcule"));
        pot4 = new potionAttribute("Elixir of Dreams", "Dreams", "Once taken, the fire of the heart will be ignited and the lock undone on the wellspring of desires. The effects may vary person to person.", Resources.Load<Sprite>("elixir_of_dreams"));
        pot5 = new potionAttribute("Perfume of Allure", "Seduction", "A fresh smelling spritzer that is known to make the wearer more intriguing.", Resources.Load<Sprite>("perfume_of_allure"));
        pot6 = new potionAttribute("Potion of Protection", "Immunity", "A bitter, fizzy potion often used by military and those seeking the protection of the Gods.", Resources.Load<Sprite>("potion_of_protection"));
        pot7 = new potionAttribute("Silver Water", "Awakening", "This freezing cold liquid seems to sparkle like moonlight even where no light shines, and is said to connect to the hidden landscapes of the unconscious.", Resources.Load<Sprite>("silver_water"));
        pot8 = new potionAttribute("Decoction of Clarity", "Peace", "A harsh shot used to stir the mind. This decoction is created by extracting the essences of the ingredients to create a dense brew.", Resources.Load<Sprite>("decoction_of_clarity"));

        potions = new Dictionary<string, potionAttribute>()
        {
            {"Brew of Blessing", pot1},
            {"Potion of Healing", pot2},
            {"Animalcule", pot3},
            {"Elixir of Dreams", pot4},
            {"Perfume of Allure", pot5},
            {"Potion of Protection", pot6},
            {"Silver Water", pot7},
            {"Decoction of Clarity", pot8}
        };

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
        spot8 = new potionAttribute("Steaming Elixir", "Awakening", "A viscous concoction that is primarily used by insomniacs to maintain a steady sleep pattern. Can be incorporated into a sleep schedule to maintain regular dreaming.",
            Resources.Load<Sprite>("steaming_elixir"));

        specialPotions = new Dictionary<string, potionAttribute>()
        {
            {"Balm of Realization", spot1},
            {"Nightmare Crystal", spot2},
            {"Midnight Moonlight", spot3},
            {"Goddess' Protection", spot4},
            {"Brownie Butler", spot5},
            {"Eternal Love", spot6},
            {"Homunculus", spot7},
            {"Dream Catcher", spot8}
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

                else if (m_slots[i].gameObject.name.Equals(ingredients["Decoction of Clarity"].ingredientName)) dclarity = true;
                else if (m_slots[i].gameObject.name.Equals(ingredients["Animalcule"].ingredientName)) anima = true;
                else if (m_slots[i].gameObject.name.Equals(ingredients["Elixir of Dreams"].ingredientName)) edreams = true;
                else if (m_slots[i].gameObject.name.Equals(ingredients["Potion of Allure"].ingredientName)) pallure = true;
                else if (m_slots[i].gameObject.name.Equals(ingredients["Potion of Protection"].ingredientName)) pprotect = true;
                else if (m_slots[i].gameObject.name.Equals(ingredients["Silver Water"].ingredientName)) swater = true;
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

                GameObject a = Instantiate(defaultIngredient);
                potionAttribute test = a.AddComponent<potionAttribute>();
                test = potions[s];
                a.GetComponent<UnityEngine.UI.Image>().sprite = test.img;
                a.name = test.ingredientName;
                test.setAttribute(att);
                a.transform.SetParent(panel.transform, false);
                player.modalPopUp(a.name, a.GetComponent<UnityEngine.UI.Image>().sprite);
                for (int h = 0; h < m_slots.Length; h++)
                {
                    if (m_slots[h] != null)
                    {
                        Destroy(m_slots[h]);
                    }
                }
                break;
            }    
        }
    }

    public void addIngredients(int i)
    {
        for (int j = 0; j < playerInventory.Length-1; j++)
        {
            if (playerInventory[j].gameObject.transform.childCount == 0 && i == 1)
            {
                Transform panel = playerInventory[j].transform;

                GameObject a = Instantiate(defaultIngredient);
                ingredientAttribute test = a.AddComponent<ingredientAttribute>();
                test = ingredients["Torched Perunika"];
                a.GetComponent<UnityEngine.UI.Image>().sprite = test.img;
                a.name = test.ingredientName;
                a.transform.SetParent(panel.transform, false);

                Transform panel2 = playerInventory[j + 1].transform;
                
                GameObject b = Instantiate(defaultIngredient);
                ingredientAttribute test2 = b.AddComponent<ingredientAttribute>();
                test2 = ingredients["Ethereal Billberry"];
                b.GetComponent<UnityEngine.UI.Image>().sprite = test2.img;
                b.name = test2.ingredientName;
                b.transform.SetParent(panel2.transform, false);
                break;
            }
        }
        for (int j = 0; j < playerInventory.Length; j++)
        {
            if (playerInventory[j].gameObject.transform.childCount == 0 && i == 2)
            {
                Transform panel = playerInventory[j].transform;

                GameObject a = Instantiate(defaultIngredient);
                ingredientAttribute test = a.AddComponent<ingredientAttribute>();
                test = ingredients["Midnight Fern"];
                a.GetComponent<UnityEngine.UI.Image>().sprite = test.img;
                a.name = test.ingredientName;
                a.transform.SetParent(panel.transform, false);

                Transform panel2 = playerInventory[j + 1].transform;

                GameObject b = Instantiate(defaultIngredient);
                ingredientAttribute test2 = b.AddComponent<ingredientAttribute>();
                test2 = ingredients["Violet Perunika"];
                b.GetComponent<UnityEngine.UI.Image>().sprite = test2.img;
                b.name = test2.ingredientName;
                b.transform.SetParent(panel2.transform, false);
                break;
            }
        }
    }

    public void addPage()
    {
        Transform panel = recipePages.transform;

        GameObject a = (GameObject)Instantiate(Resources.Load("recipe - left"));
        a.transform.SetParent(panel.transform, false);

        GameObject b = (GameObject)Instantiate(Resources.Load("recipe - right"));
        b.transform.SetParent(panel.transform, false);
    }

}
