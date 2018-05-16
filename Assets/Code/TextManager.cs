using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{

    public GameObject character;
    public TextAsset succeedText;
    public TextAsset unsucceedText;
    public TextAsset FirstText;
    public TextAsset OnetimeText;
    public TextAsset CAT1;
    public TextAsset CAT1After;
    public TextAsset CAT2;
    public TextAsset CAT2After;
    public TextAsset CAT3;
    public TextAsset CAT3After;
    public TextAsset CAT4;
    public TextAsset CAT4After;

    public int startLine;
    public int FirstTimeendLine;
    public int unsucceedendLine;
    public int succeedendLine;
    public int OnetimeendLine;
    public int CAT1End;
    public int CAT1AfterEnd;
    public int CAT2End;
    public int CAT2AfterEnd;
    public int CAT3End;
    public int CAT3AfterEnd;
    public int CAT4End;
    public int CAT4AfterEnd;

    public TextBoxmanager theTextBox;

    public bool destroyWhenActivate;
    public bool requireButtonPress;
    private bool waitForPress;
    public static bool Hunter = false;
    public static bool DEKonetime = true;
    public Sprite changeto;

    public GameObject canvas;
    public GameObject item;
    public GameObject gem;
    public Inventory inventory;
    public GameObject requiment;
    public GameObject Coinrequiment;
    bool onetime = true;
    bool inconver = false;
    float delayfade = 2.5f;
    bool fade = false;
    bool FirstTime = true;
    bool isgive;
    static bool FarmerFirstTime = true;

    public GameObject fadeout;

    // Use this for initialization
    void Start()
    {
        isgive = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (succeed == true && theTextBox.currentLine == succeedendLine + 1)
        {
            canvas.GetComponent<Fade>().Fades(true, 1.05f);
            fade = true;
            theTextBox.currentLine += 1;
        }
        if (fade == true)
        {
            delayfade -= 1 * Time.deltaTime;
        }
        canvas.GetComponent<Fade>().Fades(false, 1.25f);
        fade = false;
        delayfade = 2.5f;*/
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (requireButtonPress && !inconver)
            {
                Debug.Log("Getin2!!");
                if (Input.GetKeyDown(KeyCode.Z) && !inconver)
                {
                    Debug.Log("Getin3!!");
                    if (this.GetComponentInParent<Rigidbody2D>().name == "BUTCHER")
                    {
                        Debug.Log("BUTCHER!!");
                        if (GameData.events_complete[0] == true && FirstTime)
                        {
                            inconver = true;
                            FirstTime = false;
                            theTextBox.ReloadScript(FirstText);
                            if (theTextBox.currentLine >= FirstTimeendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = FirstTimeendLine;
                            theTextBox.EnableTextBox();
                        }
                        else
                        if (GameData.events_complete[0] == true && !FirstTime)
                        {
                            inconver = true;
                            theTextBox.ReloadScript(succeedText);
                            if (theTextBox.currentLine >= succeedendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = succeedendLine;
                            theTextBox.EnableTextBox();
                        }
                        for (int i = 0; i < inventory.inventory.Length; i++)
                        {
                            if ((inventory.inventory[i] != requiment && GameData.events_complete[0] == false))
                            {
                                inconver = true;
                                theTextBox.ReloadScript(unsucceedText);
                                if (theTextBox.currentLine >= unsucceedendLine || theTextBox.currentLine == 0)
                                {
                                    theTextBox.currentLine = startLine;
                                }
                                theTextBox.endAtLine = unsucceedendLine;
                                theTextBox.EnableTextBox();
                                break;
                            }
                        }
                        for (int i = 0; i < inventory.inventory.Length; i++)
                        {
                            if (inventory.inventory[i] == requiment && GameData.events_complete[0] == false)
                            {
                                inconver = true;
                                theTextBox.issucceed = true;
                                theTextBox.number = 0;
                                inventory.RemoveItemfrominventory(inventory.inventory[i]);
                                theTextBox.ReloadScript(OnetimeText);
                                if (theTextBox.currentLine >= OnetimeendLine || theTextBox.currentLine == 0)
                                {
                                    theTextBox.currentLine = startLine;
                                }
                                theTextBox.endAtLine = OnetimeendLine;
                                theTextBox.EnableTextBox();
                                break;
                            }
                        }
                    }
                    else
                    if (this.GetComponentInParent<Rigidbody2D>().name == "Ama")
                    {
                        Debug.Log("Ama!!");
                        if (FirstTime && GameData.events_complete[0] == false)
                        {
                            inconver = true;
                            for (int i = 0; i < inventory.inventory.Length; i++)
                            {
                                if (inventory.inventory[i] == item)
                                {
                                    isgive = true;
                                    FirstTime = false;
                                    break;
                                }
                            }
                            if (!isgive)
                            {
                                inconver = true;
                                FirstTime = false;
                                theTextBox.ReloadScript(FirstText);
                                if (theTextBox.currentLine >= FirstTimeendLine || theTextBox.currentLine == 0)
                                {
                                    theTextBox.currentLine = startLine;
                                }
                                theTextBox.endAtLine = FirstTimeendLine;
                                theTextBox.EnableTextBox();
                                inventory.AddItem(item);
                                item.SetActive(false);
                            }
                        }
                        else
                        if (!FirstTime && GameData.events_complete[0] == false)
                        {
                            inconver = true;
                            theTextBox.ReloadScript(unsucceedText);
                            if (theTextBox.currentLine >= unsucceedendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = unsucceedendLine;
                            theTextBox.EnableTextBox();
                        }
                        else
                        if (!FirstTime && GameData.events_complete[0] == true)
                        {
                            inconver = true;
                            theTextBox.ReloadScript(succeedText);
                            if (theTextBox.currentLine >= succeedendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = succeedendLine;
                            theTextBox.EnableTextBox();
                        }
                    }
                    else
                    if (this.GetComponentInParent<Rigidbody2D>().name == "DOG")
                    {
                        Debug.Log("Dog!!");
                        if (GameData.events_complete[1] == true)
                        {
                            inconver = true;
                            theTextBox.ReloadScript(FirstText);
                            if (theTextBox.currentLine >= FirstTimeendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = FirstTimeendLine;
                            theTextBox.EnableTextBox();
                        }
                        for (int i = 0; i < inventory.inventory.Length; i++)
                        {
                            if ((inventory.inventory[i] != requiment && GameData.events_complete[1] == false))
                            {
                                inconver = true;
                                theTextBox.ReloadScript(unsucceedText);
                                if (theTextBox.currentLine >= unsucceedendLine || theTextBox.currentLine == 0)
                                {
                                    theTextBox.currentLine = startLine;
                                }
                                theTextBox.endAtLine = unsucceedendLine;
                                theTextBox.EnableTextBox();
                                break;
                            }
                        }
                        for (int i = 0; i < inventory.inventory.Length; i++)
                        {
                            if (inventory.inventory[i] == requiment && GameData.events_complete[1] == false)
                            {
                                inconver = true;
                                inventory.RemoveItemfrominventory(inventory.inventory[i]);
                                theTextBox.issucceed = true;
                                theTextBox.number = 1;
                                theTextBox.ReloadScript(succeedText);
                                if (theTextBox.currentLine >= succeedendLine || theTextBox.currentLine == 0)
                                {
                                    theTextBox.currentLine = startLine;
                                }
                                theTextBox.endAtLine = succeedendLine;
                                theTextBox.EnableTextBox();
                                break;
                            }
                        }
                    }
                    else
                    if (this.GetComponentInParent<Rigidbody2D>().name == "DEK")
                    {
                        Debug.Log("DEK!!");
                        if (FirstTime && GameData.events_complete[1] == false)
                        {
                            if (isgive == false)
                            {
                                for (int i = 0; i < inventory.inventory.Length; i++)
                                {
                                    inconver = true;
                                    if (inventory.inventory[i] == item)
                                    {
                                        isgive = true;
                                        FirstTime = false;
                                        break;
                                    }
                                }
                            }
                            if (isgive == false)
                            {
                                inconver = true;
                                FirstTime = false;
                                isgive = true;
                                theTextBox.ReloadScript(FirstText);
                                if (theTextBox.currentLine >= FirstTimeendLine || theTextBox.currentLine == 0)
                                {
                                    theTextBox.currentLine = startLine;
                                }
                                theTextBox.endAtLine = FirstTimeendLine;
                                theTextBox.EnableTextBox();
                                inventory.AddItem(item);
                                item.SetActive(false);

                            }
                        }
                        else
                        if (!FirstTime && GameData.events_complete[1] == false)
                        {
                            inconver = true;
                            theTextBox.ReloadScript(unsucceedText);
                            if (theTextBox.currentLine >= unsucceedendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = unsucceedendLine;
                            theTextBox.EnableTextBox();
                        }
                        else
                        if (GameData.events_complete[1] == true && DEKonetime)
                        {
                            inconver = true;
                            DEKonetime = false;
                            theTextBox.ReloadScript(OnetimeText);
                            if (theTextBox.currentLine >= OnetimeendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = OnetimeendLine;
                            theTextBox.EnableTextBox();
                            inventory.AddItem(gem);
                            gem.SetActive(false);
                            
                        }
                        else
                        if (GameData.events_complete[1] == true && !DEKonetime)
                        {
                            inconver = true;
                            theTextBox.ReloadScript(succeedText);
                            if (theTextBox.currentLine >= succeedendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = succeedendLine;
                            theTextBox.EnableTextBox();
                        }
                    }
                    else
                    if (this.GetComponentInParent<Rigidbody2D>().name == "COWBOII")
                    {
                        Debug.Log("COWBOII!!");
                        {
                            theTextBox.ReloadScript(unsucceedText);
                            if (theTextBox.currentLine >= unsucceedendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = unsucceedendLine;
                            theTextBox.EnableTextBox();
                        }
                    }
                    else
                    if (this.GetComponentInParent<Rigidbody2D>().name == "HUNTER")
                    {
                        for (int i = 0; i < inventory.inventory.Length; i++)
                        {
                            if (inventory.inventory[i] != requiment && GameData.events_complete[2] == false)
                            {
                                inconver = true;
                                theTextBox.ReloadScript(unsucceedText);
                                if (theTextBox.currentLine >= unsucceedendLine || theTextBox.currentLine == 0)
                                {
                                    theTextBox.currentLine = startLine;
                                }
                                theTextBox.endAtLine = unsucceedendLine;
                                theTextBox.EnableTextBox();
                                break;
                            }
                        }
                        for (int i = 0; i < inventory.inventory.Length; i++)
                        {
                            for (int j = 0; j < inventory.inventory.Length; j++)
                            {
                                if (inventory.inventory[i] == requiment && inventory.inventory[j] == Coinrequiment && GameData.events_complete[2] == false)
                                {
                                    inconver = true;
                                    theTextBox.issucceed = true;
                                    theTextBox.number = 2;
                                    theTextBox.ReloadScript(succeedText);
                                    if (theTextBox.currentLine >= succeedendLine || theTextBox.currentLine == 0)
                                    {
                                        theTextBox.currentLine = startLine;
                                    }
                                    theTextBox.endAtLine = succeedendLine;
                                    inventory.RemoveItemfrominventory(inventory.inventory[i]);
                                    inventory.AddItem(gem);
                                    gem.SetActive(false);
                                    theTextBox.EnableTextBox();
                                    break;
                                }
                                else
                                if (inventory.inventory[i] == Coinrequiment && inventory.inventory[j] == requiment && GameData.events_complete[2] == false)
                                {
                                    inconver = true;
                                    theTextBox.issucceed = true;
                                    theTextBox.number = 2;
                                    theTextBox.ReloadScript(succeedText);
                                    if (theTextBox.currentLine >= succeedendLine || theTextBox.currentLine == 0)
                                    {
                                        theTextBox.currentLine = startLine;
                                    }
                                    theTextBox.endAtLine = succeedendLine;
                                    inventory.RemoveItemfrominventory(inventory.inventory[j]);
                                    inventory.AddItem(gem);
                                    gem.SetActive(false);
                                    theTextBox.EnableTextBox();
                                    break;
                                }
                                else
                                if (inventory.inventory[i] == requiment && GameData.events_complete[2] == false)
                                {
                                    inconver = true;
                                    theTextBox.issucceed = true;
                                    theTextBox.number = 2;
                                    theTextBox.ReloadScript(succeedText);
                                    if (theTextBox.currentLine >= succeedendLine || theTextBox.currentLine == 0)
                                    {
                                        theTextBox.currentLine = startLine;
                                    }
                                    theTextBox.endAtLine = succeedendLine;
                                    inventory.RemoveItemfrominventory(inventory.inventory[i]);
                                    inventory.AddItem(gem);
                                    gem.SetActive(false);
                                    theTextBox.EnableTextBox();
                                    break;
                                }
                                else
                                if (inventory.inventory[i] == Coinrequiment)
                                {
                                    Hunter = true;
                                    inconver = true;
                                    theTextBox.ReloadScript(FirstText);
                                    if (theTextBox.currentLine >= FirstTimeendLine || theTextBox.currentLine == 0)
                                    {
                                        theTextBox.currentLine = startLine;
                                    }
                                    theTextBox.endAtLine = FirstTimeendLine;
                                    theTextBox.EnableTextBox();
                                    break;
                                }
                            }

                        }
                    }
                    else
                    if (this.GetComponentInParent<Rigidbody2D>().name == "Christine")
                    {
                        if (GameData.events_complete[2] == false)
                        {
                            inconver = true;
                            for (int i = 0; i < inventory.inventory.Length; i++)
                            {
                                if (inventory.inventory[i] == item)
                                {
                                    isgive = true;
                                    break;
                                }
                            }
                            if (!isgive)
                            {
                                inconver = true;
                                theTextBox.ReloadScript(FirstText);
                                if (theTextBox.currentLine >= FirstTimeendLine || theTextBox.currentLine == 0)
                                {
                                    theTextBox.currentLine = startLine;
                                }
                                theTextBox.endAtLine = FirstTimeendLine;
                                theTextBox.EnableTextBox();
                                inventory.AddItem(item);
                                item.SetActive(false);
                            }
                            else
                            if (isgive)
                            {
                                inconver = true;
                                theTextBox.ReloadScript(unsucceedText);
                                if (theTextBox.currentLine >= unsucceedendLine || theTextBox.currentLine == 0)
                                {
                                    theTextBox.currentLine = startLine;
                                }
                                theTextBox.endAtLine = unsucceedendLine;
                                theTextBox.EnableTextBox();
                            }
                        }
                    }
                    else
                    if (this.GetComponentInParent<Rigidbody2D>().name == "Chief")
                    {
                        if (GameData.events_complete[3] == false)
                        {
                            inconver = true;
                            theTextBox.issucceed = true;
                            theTextBox.number = 3;
                            theTextBox.ReloadScript(unsucceedText);
                            if (theTextBox.currentLine >= unsucceedendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = unsucceedendLine;
                            theTextBox.EnableTextBox();
                        }
                        else
                        if (GameData.events_complete[3] == true)
                        {
                            inconver = true;
                            theTextBox.ReloadScript(succeedText);
                            if (theTextBox.currentLine >= succeedendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = succeedendLine;
                            theTextBox.EnableTextBox();
                        }
                    }
                    else
                    if (this.GetComponentInParent<Rigidbody2D>().name == "Farmer")
                    {
                        if (FarmerFirstTime && GameData.events_complete[5] == false)
                        {
                            inconver = true;
                            FarmerFirstTime = false;
                            theTextBox.ReloadScript(FirstText);
                            if (theTextBox.currentLine >= FirstTimeendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = FirstTimeendLine;
                            theTextBox.EnableTextBox();
                            inventory.AddItem(item);
                            item.SetActive(false);
                            GameData.events_complete[5] = true;
                            SaveLoad.Save();
                        }
                        else
                        //if (!FarmerFirstTime)
                        {
                            inconver = true;
                            theTextBox.ReloadScript(succeedText);
                            if (theTextBox.currentLine >= succeedendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = succeedendLine;
                            theTextBox.EnableTextBox();
                        }
                    }
                    else
                    if (this.GetComponentInParent<Rigidbody2D>().name == "Woman")
                    {
                        inconver = true;
                        theTextBox.ReloadScript(unsucceedText);
                        if (theTextBox.currentLine >= unsucceedendLine || theTextBox.currentLine == 0)
                        {
                            theTextBox.currentLine = startLine;
                        }
                        theTextBox.endAtLine = unsucceedendLine;
                        theTextBox.EnableTextBox();
                    }
                    else
                    if (this.GetComponentInParent<Rigidbody2D>().name == "Lumberjack")
                    {
                        inconver = true;
                        theTextBox.ReloadScript(unsucceedText);
                        if (theTextBox.currentLine >= unsucceedendLine || theTextBox.currentLine == 0)
                        {
                            theTextBox.currentLine = startLine;
                        }
                        theTextBox.endAtLine = unsucceedendLine;
                        theTextBox.EnableTextBox();
                    }
                    else
                    if (this.GetComponentInParent<Rigidbody2D>().name == "Merchant")
                    {
                        for (int i = 0; i < inventory.inventory.Length; i++)
                        {
                            if (inventory.inventory[i] != requiment && GameData.events_complete[4] == false)
                            {
                                inconver = true;
                                theTextBox.ReloadScript(unsucceedText);
                                if (theTextBox.currentLine >= unsucceedendLine || theTextBox.currentLine == 0)
                                {
                                    theTextBox.currentLine = startLine;
                                }
                                theTextBox.endAtLine = unsucceedendLine;
                                theTextBox.EnableTextBox();
                                break;
                            }
                        }
                        for (int i = 0; i < inventory.inventory.Length; i++)
                        {
                            if (inventory.inventory[i] == requiment && GameData.events_complete[4] == false && FirstTime)
                            {
                                for (int j = 0; j < inventory.inventory.Length; j++)
                                {
                                    if (inventory.inventory[j] == item)
                                    {
                                        isgive = true;
                                        break;
                                    }
                                }
                                if (!isgive && Hunter)
                                {
                                    FirstTime = false;
                                    inconver = true;
                                    theTextBox.ReloadScript(succeedText);
                                    if (theTextBox.currentLine >= succeedendLine || theTextBox.currentLine == 0)
                                    {
                                        theTextBox.currentLine = startLine;
                                    }
                                    theTextBox.endAtLine = succeedendLine;
                                    theTextBox.EnableTextBox();
                                    inventory.AddItem(item);
                                    item.SetActive(false);
                                    break;
                                }

                            }
                        }
                    }
                    else
                    if (this.GetComponentInParent<Rigidbody2D>().name == "Miner")
                    {
                        for (int i = 0; i < inventory.inventory.Length; i++)
                        {
                            if (inventory.inventory[i] != requiment && GameData.events_complete[4] == false && FirstTime)
                            {
                                for (int j = 0; j < inventory.inventory.Length; j++)
                                {
                                    inconver = true;
                                    if (inventory.inventory[j] == item)
                                    {
                                        isgive = true;
                                        FirstTime = false;
                                        break;
                                    }
                                }
                                if (!isgive)
                                {
                                    inconver = true;
                                    FirstTime = false;
                                    theTextBox.ReloadScript(FirstText);
                                    if (theTextBox.currentLine >= FirstTimeendLine || theTextBox.currentLine == 0)
                                    {
                                        theTextBox.currentLine = startLine;
                                    }
                                    theTextBox.endAtLine = FirstTimeendLine;
                                    theTextBox.EnableTextBox();
                                    inventory.AddItem(item);
                                    item.SetActive(false);
                                    break;
                                }
                            }
                            else
                            if (inventory.inventory[i] != requiment && GameData.events_complete[4] == false && !FirstTime)
                            {
                                inconver = true;
                                FirstTime = false;
                                theTextBox.ReloadScript(unsucceedText);
                                if (theTextBox.currentLine >= unsucceedendLine || theTextBox.currentLine == 0)
                                {
                                    theTextBox.currentLine = startLine;
                                }
                                theTextBox.endAtLine = unsucceedendLine;
                                theTextBox.EnableTextBox();
                                break;
                            }
                        }
                        for (int i = 0; i < inventory.inventory.Length; i++)
                        {
                            if (inventory.inventory[i] == requiment && GameData.events_complete[4] == false)
                            {
                                inconver = true;
                                inventory.RemoveItemfrominventory(inventory.inventory[i]);
                                for (int j = 0; j < inventory.inventory.Length; j++)
                                {
                                    if (inventory.inventory[j] == item)
                                    {
                                        inventory.RemoveItemfrominventory(inventory.inventory[j]);
                                    }
                                }
                                theTextBox.issucceed = true;
                                theTextBox.number = 4;
                                theTextBox.ReloadScript(succeedText);
                                if (theTextBox.currentLine >= succeedendLine || theTextBox.currentLine == 0)
                                {
                                    theTextBox.currentLine = startLine;
                                }
                                theTextBox.endAtLine = succeedendLine;
                                theTextBox.EnableTextBox();
                                inventory.AddItem(gem);
                                gem.SetActive(false);
                                break;
                            }
                        }
                        if (GameData.events_complete[4] == true)
                        {
                            inconver = true;
                            theTextBox.ReloadScript(OnetimeText);
                            if (theTextBox.currentLine >= OnetimeendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = OnetimeendLine;
                            theTextBox.EnableTextBox();
                        }
                    }
                    else
                    if (this.GetComponentInParent<Rigidbody2D>().name == "CAT")
                    {
                        GameData.pass_tutorial = true;
                        for (int i = 0; i < inventory.inventory.Length; i++)
                        {
                            if (inventory.inventory[i] == GameObject.Find("gem") || inventory.inventory[i] == GameObject.Find("gem1") || inventory.inventory[i] == GameObject.Find("gem2") || inventory.inventory[i] == GameObject.Find("gem3"))
                            {
                                GameData.gems_receive += 1;
                                inventory.RemoveItemfrominventory(inventory.inventory[i]);
                                FirstTime = true;
                                if (GameData.gems_receive == 1 && FirstTime)
                                {
                                    FirstTime = false;
                                    inconver = true;
                                    theTextBox.ReloadScript(CAT1);
                                    if (theTextBox.currentLine >= CAT1End || theTextBox.currentLine == 0)
                                    {
                                        theTextBox.currentLine = startLine;
                                    }
                                    theTextBox.endAtLine = CAT1End;
                                    theTextBox.EnableTextBox();
                                }
                                else
                                if (GameData.gems_receive == 2 && FirstTime)
                                {
                                    inconver = true;
                                    FirstTime = false;
                                    theTextBox.ReloadScript(CAT2);
                                    if (theTextBox.currentLine >= CAT2End || theTextBox.currentLine == 0)
                                    {
                                        theTextBox.currentLine = startLine;
                                    }
                                    theTextBox.endAtLine = CAT2End;
                                    theTextBox.EnableTextBox();
                                }
                                else
                                if (GameData.gems_receive == 3 && FirstTime)
                                {
                                    inconver = true;
                                    FirstTime = false;
                                    theTextBox.ReloadScript(CAT3);
                                    if (theTextBox.currentLine >= CAT3End || theTextBox.currentLine == 0)
                                    {
                                        theTextBox.currentLine = startLine;
                                    }
                                    theTextBox.endAtLine = CAT3End;
                                    theTextBox.EnableTextBox();
                                }
                                else
                                if (GameData.gems_receive == 4 && FirstTime)
                                {
                                    inconver = true;
                                    FirstTime = false;
                                    /*theTextBox.ReloadScript(CAT4);
                                    if (theTextBox.currentLine >= CAT4End || theTextBox.currentLine == 0)
                                    {
                                        theTextBox.currentLine = startLine;
                                    }
                                    theTextBox.endAtLine = CAT4End;
                                    theTextBox.EnableTextBox();*/
                                    if (fadeout != null) fadeout.SetActive(true);

                                    StartCoroutine(gameend());

                                }
                                SaveLoad.Save();
                            }
                        }
                        if (GameData.gems_receive == 0)
                        {
                            inconver = true;
                            theTextBox.ReloadScript(FirstText);
                            if (theTextBox.currentLine >= FirstTimeendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = FirstTimeendLine;
                            theTextBox.EnableTextBox();
                        }
                        else
                        if (GameData.gems_receive == 1 && !FirstTime)
                        {
                            inconver = true;
                            theTextBox.ReloadScript(CAT1After);
                            if (theTextBox.currentLine >= CAT1AfterEnd || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = CAT1AfterEnd;
                            theTextBox.EnableTextBox();
                        }
                        else
                        if (GameData.gems_receive == 2 && !FirstTime)
                        {
                            inconver = true;
                            theTextBox.ReloadScript(CAT2After);
                            if (theTextBox.currentLine >= CAT2AfterEnd || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = CAT2AfterEnd;
                            theTextBox.EnableTextBox();
                        }
                        else
                        if (GameData.gems_receive == 3 && !FirstTime)
                        {
                            inconver = true;
                            theTextBox.ReloadScript(CAT3After);
                            if (theTextBox.currentLine >= CAT3AfterEnd || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = CAT3AfterEnd;
                            theTextBox.EnableTextBox();
                        }
                        SaveLoad.Save();
                    }
                    inconver = true;
                }
            }
        }
    }
    
    void OnTriggerEnter2D(Collider other)
    {
        inconver = false;
        if (other.name == "Player")
        { 
            if (!requireButtonPress)
            {
                {
                    theTextBox.ReloadScript(unsucceedText);
                    theTextBox.currentLine = startLine;
                    theTextBox.endAtLine = unsucceedendLine;
                    theTextBox.EnableTextBox();
                    if (destroyWhenActivate)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        inconver = false;
        if (other.name == "Player")
        {
            waitForPress = false;
        }
    }

    IEnumerator gameend ()
    {
        yield return new WaitForSeconds(1.0f);
        Application.LoadLevel("Cutscene");
    }
}
