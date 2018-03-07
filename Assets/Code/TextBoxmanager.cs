using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxmanager : MonoBehaviour {

    public GameObject textBox;

    public Text theText;

    public TextAsset textfile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    public bool isActive;
    public Player player;

    public bool StopPlayerMovement;
    private bool isTyping = false;
    private bool cancelTyping = false;

    public float typeSpeed;
    // Use this for initialization
    void Start () {

        if (isActive)
        {
            EnableTextBox();
        }
        else
        {
            DisableTextBox();
        }
        player = FindObjectOfType<Player>();

        if(textfile != null)
        {
            textLines = (textfile.text.Split('\n'));
        }

        if(endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }
	}
	
	// Update is called once per frame
	void Update () {

        if(!isActive)
        {
            return;
        }
        // theText.text = textLines[currentLine];

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!isTyping)
            {
                currentLine += 1;
                if (currentLine > endAtLine)
                {
                    DisableTextBox();
                }
                else
                {
                    StartCoroutine(TextScroll(textLines[currentLine]));
                }
            }
            else
                if(isTyping&&!cancelTyping)
            {
                cancelTyping = true;
            }
        }
	}

    private IEnumerator TextScroll(string lineOfText)
    {
        int letter = 0;
        theText.text = "";
        isTyping = true;
        cancelTyping = false;
        while(isTyping && !cancelTyping && letter < lineOfText.Length - 1)
        {
            theText.text += lineOfText[letter];
            letter += 1;
            yield return new WaitForSeconds(typeSpeed);
        }
        theText.text = lineOfText;
        isTyping = false;
        //cancelTyping = false;
    }

    public void EnableTextBox()
    {
        textBox.SetActive(true);
        isActive = true;
        if(StopPlayerMovement)
        {
            player.canmove = false;
        }

        StartCoroutine(TextScroll(textLines[currentLine]));
    }

    public void DisableTextBox()
    {
        isActive = false;
        textBox.SetActive(false);
        player.canmove = true;
    }

    public void ReloadScript(TextAsset theText)
    {
        if(theText != null)
        {
            textLines = new string[1];
            textLines = (theText.text.Split('\n'));
        }
    }
}
