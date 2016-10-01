using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour {

    public CollectItems player;
    public GameObject beacon;

    // Use this for initialization
    void Start () {
        beacon.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (player.percentageCollected() >= 1.0f)
            beacon.SetActive(true);
	}
}
