using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Script utilisé pour la gestion de l'écran de transition.
public class Fading : MonoBehaviour {

    bool fadeOut = true;
    bool fadeIn = false;

    public float tpsIn = 1.0f;
    public float tpsOut = 2.0f;

    AdditionalControls player;

	void Awake() {
        fadeOut = true;
        fadeIn = false;

        Color temp = GetComponent<Image>().color;
        temp.a = 1;
        GetComponent<Image>().color = temp;

        player = FindObjectOfType<AdditionalControls>();
    }
	
    // Update is called once per frame
    void Update () {
	    if (fadeOut)
        {
            Color temp = GetComponent<Image>().color;
            temp.a -= Time.deltaTime * (1 / tpsOut);

            if (temp.a <= 0.0f)
            {
                fadeOut = false;
                temp.a = 0;
            }

            GetComponent<Image>().color = temp;
            if (temp.a >= .8f)
                player.sleep();
        }
        
        if (fadeIn)
        {
            Color temp = GetComponent<Image>().color;
            temp.a += Time.deltaTime * (1 / tpsIn);

            if (temp.a >= 1.0f)
            {
                fadeIn = false;
                temp.a = 1;
            }

            GetComponent<Image>().color = temp;
            player.sleep();
        }

	}

    public void activateFadeIn()
    { fadeIn = true; }

    public void activateFadeOut()
    { fadeOut = true; }

    public float tpsFadeIn()
    { return tpsIn; }

    public float tpsFadeOut()
    { return tpsOut; }
}
