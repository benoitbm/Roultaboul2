using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CollectingUI : MonoBehaviour {

    Image self;
    CollectItems player;
    float fill = 0f;
	
    void Start()
    {
        player = FindObjectOfType<CollectItems>();
        self = GetComponent<Image>();
    }

	// Update is called once per frame
	void Update ()
    {
        fill = player.percentageCollected();
        self.fillAmount = fill;
    }
	
}
