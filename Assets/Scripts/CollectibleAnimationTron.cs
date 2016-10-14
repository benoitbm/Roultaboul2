using UnityEngine;
using System.Collections;

public class CollectibleAnimationTron : MonoBehaviour {

    float originy;
    bool ascend = true;
    public float moveVFork = 0.2f;

	// Use this for initialization
	void Start () {
        originy = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, Time.deltaTime * 50, 0);

        if (ascend)
        {
            transform.Translate(0, Time.deltaTime/2, 0);
            if (transform.position.y > originy + moveVFork)
                ascend = false;
        }
        else
        {
            transform.Translate(0, -Time.deltaTime/2, 0);
            if (transform.position.y < originy - moveVFork)
                ascend = true;
        }
	}
}
