using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//Script gérant la collecte des objets pour finir le niveau.
public class CollectItems : MonoBehaviour {

    int collected = 0;
    int toCollect = 1;

    public string nextLevel;

    Fading fade;

	// Use this for initialization
	void Start () {
        toCollect = GameObject.FindGameObjectsWithTag("Collect").Length;
        print(toCollect + " elements found");
        fade = FindObjectOfType<Fading>();
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
        else if (other.tag == "Goal" && percentageCollected() >= 1)
            StartCoroutine(toNextLevel());
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

    /// <summary>
    /// Timer pour passer au niveau suivant.
    /// </summary>
    /// <returns></returns>
    IEnumerator toNextLevel()
    {
        yield return new WaitForSeconds(0.5f);
        fade.activateFadeIn();
        yield return new WaitForSeconds(fade.tpsFadeIn());
        SceneManager.LoadScene(nextLevel);
    }
}
