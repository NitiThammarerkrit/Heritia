using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLine : MonoBehaviour {

    public GameObject character; 
    public TextAsset succeedText;
    public TextAsset unsucceedText;
    public TextAsset FirstText;

    public int startLine;
    public int FirstTimeendLine;
    public int unsucceedendLine;
    public int succeedendLine;

    public TextBoxmanager theTextBox;

    public bool destroyWhenActivate;
    public bool requireButtonPress;
    private bool waitForPress;
    public Sprite changeto;

    public GameObject canvas;
    public GameObject item;
    public Inventory inventory;
    public GameObject requiment;
    public bool arrive = false;
    bool firsttime = true;
    bool succeed = false;
    bool onetime = true;
    bool FirstTime;
    bool inconver=true;
    float delayfade = 2.5f;
    bool fade = false;
    bool finish = false;
    // Use this for initialization
    void Start () {
        //theTextBox = FindObjectOfType<TextBoxmanager>();
        //succeed = false;
        if (character.gameObject.name == "BUTCHER")
        {
            FirstTime = false;
        }
        else
        {
            FirstTime = true;
        }

    }
	
	// Update is called once per frame
	void Update () {
        if (succeed == true  && theTextBox.currentLine == succeedendLine+1 )
        {
            canvas.GetComponent<Fade>().Fades(true,1.05f);
            fade = true;
            theTextBox.currentLine += 1;
        }
        if(fade == true)
        {
            delayfade -= 1 * Time.deltaTime;
        }
        if (delayfade <= 0)
        {
            if (character.gameObject.name == "BUTCHER")
            {
                character.transform.position = new Vector3(153f, -1.83f, -2.96f);
                character.GetComponent<SpriteRenderer>().sprite = changeto;
                arrive = true;
            }
            else
            if (character.gameObject.name == "DOG")
            {
                character.transform.position = new Vector3(78.1f, -2.527f, -3f);
                character.GetComponent<SpriteRenderer>().sprite = changeto;
                arrive = true;
            }

            canvas.GetComponent<Fade>().Fades(false, 1.25f);
            fade = false;
            delayfade = 2.5f;
        }

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "BUTCHER"|| other.name == "DOG")
        {
            succeed = true;
            arrive = true;
        }
        if (other.name == "Player")
        {
            if (requireButtonPress && inconver)
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    for (int i = 0; i < inventory.inventory.Length; i++)
                    {
                        for (int j = 0; j < inventory.inventory.Length;)
                        {
                            if (requiment != null && (inventory.inventory[j] == requiment))
                            {
                                Debug.Log("kuay5");
                                succeed = true;
                                inventory.RemoveItemfrominventory(inventory.inventory[j]);
                                //inventory.AddItem(item);
                                //Destroy(item);
                                theTextBox.ReloadScript(succeedText);
                                if (theTextBox.currentLine >= succeedendLine || theTextBox.currentLine == 0)
                                {
                                    theTextBox.currentLine = startLine;
                                }
                                theTextBox.endAtLine = succeedendLine;
                                theTextBox.EnableTextBox();
                                if (destroyWhenActivate)
                                {
                                    Destroy(gameObject);
                                }
                                break;
                            }
                            j++;
                            
                        }
                        
                        if ((inventory.inventory[i] == requiment || requiment == null) && FirstTime)
                        {
                            //Debug.Log("succeeddddddddd");
                            Debug.Log("kuay1");
                            if(item!=null)
                            {
                                inventory.AddItem(item);
                                item.SetActive(false);
                            }

                            theTextBox.ReloadScript(FirstText);
                            if (theTextBox.currentLine >= FirstTimeendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = FirstTimeendLine;
                            theTextBox.EnableTextBox();
                            if (destroyWhenActivate)
                            {
                                Destroy(gameObject);
                            }
                            FirstTime = false;
                            finish = true;
                            break;
                        }
                        
                        if (requiment == null && !FirstTime && onetime == true&&!succeed)
                        {
                            Debug.Log("succeeddddddddd");
                            theTextBox.ReloadScript(unsucceedText);
                            if (theTextBox.currentLine >= unsucceedendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = unsucceedendLine;
                            theTextBox.EnableTextBox();
                            if (destroyWhenActivate)
                            {
                                Destroy(gameObject);
                            }
                            onetime = false;
                            break;
                        }

                        if (onetime == true)
                        {
                            //succeed = true;
                            if(succeed == false)
                            {
                                Debug.Log("Hee");
                                theTextBox.ReloadScript(unsucceedText);
                                if (theTextBox.currentLine >= unsucceedendLine || theTextBox.currentLine == 0)
                                {
                                    theTextBox.currentLine = startLine;
                                }
                                theTextBox.endAtLine = unsucceedendLine;
                                theTextBox.EnableTextBox();
                                if (destroyWhenActivate)
                                {
                                    Destroy(gameObject);
                                }
                                onetime = false;
                                break;
                            }
                            
                        }
                        
                        if (succeed == true  && onetime == true && arrive &&!finish)
                        {
                            Debug.Log("sasssss");
                            theTextBox.ReloadScript(FirstText);
                            if (theTextBox.currentLine >= FirstTimeendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = FirstTimeendLine;
                            theTextBox.EnableTextBox();
                            if (destroyWhenActivate)
                            {
                                Destroy(gameObject);
                            }
                            onetime = false;
                            finish = true;
                            break;
                        }
                        if (succeed == true && character.gameObject.name == "BUTCHER" && onetime == true && arrive && finish)
                        {
                            Debug.Log("sasssss");
                            theTextBox.ReloadScript(unsucceedText);
                            if (theTextBox.currentLine >= unsucceedendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = unsucceedendLine;
                            theTextBox.EnableTextBox();
                            if (destroyWhenActivate)
                            {
                                Destroy(gameObject);
                            }
                            onetime = false;
                            break;
                        }
                        if ((character.gameObject.name == "Ama"|| character.gameObject.name == "DEK") && onetime == true && arrive && succeed)
                        {
                            Debug.Log("sasssss");
                            theTextBox.ReloadScript(succeedText);
                            if (theTextBox.currentLine >= succeedendLine || theTextBox.currentLine == 0)
                            {
                                theTextBox.currentLine = startLine;
                            }
                            theTextBox.endAtLine = succeedendLine;
                            theTextBox.EnableTextBox();
                            if (destroyWhenActivate)
                            {
                                Destroy(gameObject);
                            }
                            onetime = false;
                            break;
                        }
                    }
                    inconver = false;
                }
            }
           
        }

    }
    void OnTriggerEnter2D(Collider other)
{
        onetime = true;
        inconver = true;
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

            //character.GetComponent<EnemyController>().enabled = true;
            
        onetime = true;
        inconver = true;
        if (other.name == "Player")
        {
            waitForPress = false;
        }
    }
}
