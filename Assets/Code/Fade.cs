using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour {

    public static Fade Instance { set; get; }

    public Image fadeImage;
    private bool isInTransition;
    private float transition;
    private bool isShowing;
    private float duration;


    private void Awake()
    {
        Instance = this;
    }

    public void Fades(bool showing, float duration)
    {
        isShowing = showing;
        isInTransition = true;
        this.duration = duration;
        transition = (isShowing) ? 0 : 1;
    }


    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (!isInTransition)
            return;

        transition += (isShowing) ? Time.deltaTime * (1 / duration) : - Time.deltaTime * (1 / duration);
        fadeImage.color = Color.Lerp(new Color(1, 1, 1, 0), Color.white, transition);

        if (transition > 1 || transition <0 )
        {
            isInTransition = false;
        }
	}

}
