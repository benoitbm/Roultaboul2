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
        {
            enPause = !enPause;
            PauseMenu.SetActive(enPause); //Activé (ou désactivé) ici pour éviter qu'il soit tout le temps actif lorsqu'il y aura les sous menus et autres.
        }

        if (enPause)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            background.gameObject.SetActive(true);
            UIGame.SetActive(false);

            Time.timeScale = 0; //ZA WARUDO

            var musiques = FindObjectsOfType<AudioSource>(); //On cherche toutes les musiques...
            foreach (AudioSource musique in musiques)
                musique.Pause(); //Pour les mettre en pause, ce qui est normal quand tu fais pause.
        }
        else
        { //Penser à désactiver tous les UI et réactiver celui du jeu (aka UIGame)
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;

            background.gameObject.SetActive(false);
            PauseMenu.SetActive(false);
            UIGame.SetActive(true);

            Time.timeScale = 1; //TOKITO TOMAE (je sais définitivement pas l'écrire.)

            var musiques = FindObjectsOfType<AudioSource>(); //cf. au dessus.
            foreach (AudioSource musique in musiques)
                musique.UnPause(); //Mais pour reprendre la musique. (surtout si elle est bonne, bonne, bonne...)
        }
	}

    /// <summary>
    /// Fonction appellée quand la souris passe par dessus d'un event trigger "Pointer Enter" (Voir éditeur)
    /// </summary>
    /// <param name="texte">Le texte où la souris rentre dedans.</param>
    public void HoverEnter(Text texte)
    { texte.color = Color.green; }

    public void HoverExit(Text texte)
    { texte.color = Color.white; }

    public void ReprendrePartie()
    { enPause = false; }

    public void RecommencerNiveau()
    { SceneManager.LoadScene(SceneManager.GetActiveScene().name); } //TODO : Rajouter écran confirmation

    public void options()
    { ReprendrePartie(); }

    public void menuPrincipal()
    { SceneManager.LoadScene("menuPrincipal"); } //TODO : Voir le todo au dessus et en dessous. J'appelle ça le todo sandwich.

    public void QuitterJeu()
    { Application.Quit(); } //TODO : Rajouter Ecran Confirmation

}
