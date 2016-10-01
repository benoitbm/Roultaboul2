using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HPUi : MonoBehaviour {

    public Image self;
    public playerHP player;
    float fill = 0f;
    float a = 0f;
    float defaulta = 138f / 255f;

	// Update is called once per frame
	void Update () {
        fill = player.returnHP();

        if (fill == 1.0f)
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
