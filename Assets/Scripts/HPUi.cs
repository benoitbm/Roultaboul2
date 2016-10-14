using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HPUi : MonoBehaviour {

    Image self;
    playerHP player;
    float fill = 0f; //Pourcentage de santé du joueur.
    float a = 0f; //Variable servant à contenir et modifier les valeurs de transparence de la barre de santé.
    float defaulta = 138f / 255f;

    void Start()
    {
        player = FindObjectOfType<playerHP>();
        self = GetComponent<Image>();
    }

	// Update is called once per frame
	void Update () {
        fill = player.returnHP();

        if (fill >= 1.0f)
        {
            if (a > 0)
                a = a - Time.deltaTime/3;
            else
                a = 0f;

            var temp = Color.green;
            temp.a = a;
            self.color = temp;
        }
        else
        {
            a = defaulta;
            if (fill > .66f)
            {
                var temp = Color.green;
                temp.a = a;
                self.color = temp;
            }
            else if (fill <= .33f)
            {
                var temp = Color.red;
                temp.a = a;
                self.color = temp;
            }
            else
            {
                var temp = Color.yellow;
                temp.a = a;
                self.color = temp;
            }
        }
        self.fillAmount = fill;
	}
}
