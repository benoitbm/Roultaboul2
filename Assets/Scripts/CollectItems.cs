using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CollectItems : MonoBehaviour {

    private int collected = 0;
    private int toCollect = 1;

    public string nextLevel;

	// Use this for initialization
	void Start () {
        toCollect = GameObject.FindGameObjectsWithTag("Collect").Length;
        print(toCollect + " elements found");
    }

    void OnTriggerEnter(Collider other)
    {
        print("Collision with "+other.gameObject.name);
        if (other.tag == "Collect")
        {
            ++collected;
            print(collected + "/" + toCollect);
            Destroy(other.gameObject);
        }

        if (other.tag == "Goal" && percentageCollected() >= 1)
        {
            SceneManager.LoadScene(nextLevel);
        }

    }
	
	public float percentageCollected()
    { return (float)collected / (float)toCollect; }
}
