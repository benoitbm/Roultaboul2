using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//Script gérant la collecte des objets pour finir le niveau.
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
        else if (other.tag == "Goal" && percentageCollected() >= 1) //TODO : Rajouter un effet de transition
            SceneManager.LoadScene(nextLevel);
        else if (other.tag == "Checkpoint")
            GetComponent<AdditionalControls>().setCheckpoint(other.GetComponentInParent<Checkpoint>());
        else if (other.tag == "Fire")
            GetComponent<AdditionalControls>().respawn();

    }
	
    /// <summary>
    /// Fonction renvoyant le pourcentage entre 0 et 1 d'éléments collectés par le joueur.
    /// </summary>
    /// <returns>Float qui representé le pourcentage d'objets collectés du niveau.</returns>
	public float percentageCollected()
    { return (float)collected / (float)toCollect; }
}
