using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CollectingUI : MonoBehaviour {

    public Image self;
    public CollectItems player;
    float fill = 0f;
	
	// Update is called once per frame
	void Update ()
    {
        fill = player.percentageCollected();
        self.fillAmount = fill;
    }
	
}
