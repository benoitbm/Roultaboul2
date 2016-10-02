using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class pauseMenu : MonoBehaviour {

    public Image background;
    public GameObject PauseMenu;
    public GameObject UIGame;

    bool enPause = false;

    private int choix = 0;
    public Text Reprendre;
    public Text Quitter;

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

    public void HoverEnter(Text texte)
    { texte.color = Color.green; print("Entrée sur " + texte.gameObject.name); }

    public void HoverExit(Text texte)
    { texte.color = Color.white; print("Sortie de " + texte.gameObject.name); }

    public void ReprendrePartie()
    { enPause = false; }

    public void QuitterJeu()
    { Application.Quit(); }

}
