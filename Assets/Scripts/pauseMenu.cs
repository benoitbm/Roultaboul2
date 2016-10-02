using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour {

    public Image background;
    public GameObject PauseMenu;
    public GameObject UIGame;

    bool enPause = false;

    private int choix = 0;

	// Use this for initialization
	void Start () {
        background.gameObject.SetActive(false);
        PauseMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            enPause = !enPause;

        if (enPause)
        {
            background.gameObject.SetActive(true);
            PauseMenu.SetActive(true);
            UIGame.SetActive(false);

            Time.timeScale = 0; //Arrêt du temps en jeu
        }
        else
        {
            background.gameObject.SetActive(false);
            PauseMenu.SetActive(false);
            UIGame.SetActive(true);

            Time.timeScale = 1;
        }
	}

    /// <summary>
    /// Fonction appellée quand la souris passe par dessus d'un event trigger "Pointer Enter" (Voir éditeur)
    /// </summary>
    /// <param name="texte">Le texte où la souris rentre dedans.</param>
    public void HoverEnter(Text texte)
    { texte.color = Color.green; print("Entrée sur " + texte.gameObject.name); }

    public void HoverExit(Text texte)
    { texte.color = Color.white; print("Sortie de " + texte.gameObject.name); }

    public void ReprendrePartie()
    { enPause = false; }

    public void RecommencerNiveau()
    { SceneManager.LoadScene(SceneManager.GetActiveScene().name); } //TODO : Rajouter écran confirmation

    public void QuitterJeu()
    { Application.Quit(); } //TODO : Rajouter Ecran Confirmation

}
