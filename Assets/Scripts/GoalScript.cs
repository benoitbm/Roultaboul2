using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour {

    CollectItems player;
    public GameObject beacon;

    // Use this for initialization
    void Start () {
        beacon.SetActive(false);
        player = FindObjectOfType<CollectItems>();
	}
	
	// Update is called once per frame
	void Update () {
        if (player.percentageCollected() >= 1.0f)
            beacon.SetActive(true);
	}
}
