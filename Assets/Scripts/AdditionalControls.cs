using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Classe contenant les éléments de contrôle supplémentaires, comme les checkpoints.
/// </summary>
public class AdditionalControls : MonoBehaviour {

    //Plan Y où la balle sera TP au dernier checkpoint
    public float voidZone = 7;
    public Transform Camera;

    float timePressedToRestart = 0.0f;
    public float tempsRedemarrer = 2.0f;
    public Image RestartClock;

    Checkpoint lastCheckpoint = null;

    Fading fade;
    bool respawning = false;

    void Start()
    {
        fade = FindObjectOfType<Fading>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.R) && !respawning) //TODO : Rajouter un gestionnaire de touches + manettes
            timePressedToRestart += Time.deltaTime;
        else if (timePressedToRestart > 0)
            timePressedToRestart -= Time.deltaTime * 3;
        else
            timePressedToRestart = 0.0f;

        RestartClock.fillAmount = (timePressedToRestart / tempsRedemarrer);
        if (timePressedToRestart / tempsRedemarrer >= 1.0f)
        {
            respawn();
            timePressedToRestart = 0f;
        }

        if (gameObject.transform.position.y <= voidZone) //On teste si le joueur passe en dessous de la zone de jeu
            respawn();
	}

    /// <summary>
    /// Enregistre le checkpoint rencontré par le joueur.
    /// </summary>
    /// <param name="check">Checkpoint qui va devenir le point de réapparaition du joueur.</param>
    public void setCheckpoint(Checkpoint check)
    {
        if (lastCheckpoint != null)
            lastCheckpoint.setCheckpointActive(true);

        lastCheckpoint = check;
        lastCheckpoint.setCheckpointActive(false);
    }

    /// <summary>
    /// Fonction faisant ré-apparaître le joueur au dernier checkpoint activé
    /// </summary>
    public void respawn()
    {
        respawning = true;
        StartCoroutine(attenteRespawn());
    }

    /// <summary>
    /// Fonction pour bloquer les mouvements du joueur
    /// </summary>
    public void sleep()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    IEnumerator attenteRespawn()
    {
        fade.activateFadeIn();
        yield return new WaitForSeconds(fade.tpsFadeIn());
        fade.activateFadeOut();
        
        var tempCheck = lastCheckpoint.transform.position;
        tempCheck.y += .5f;
        gameObject.transform.position = tempCheck; //Déplacement du joueur
        Camera.position = tempCheck; //Déplacement de la caméra

        yield return new WaitForSeconds(fade.tpsFadeOut());
        respawning = false;
    }
}
