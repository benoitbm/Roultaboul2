using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuPrincipal : MonoBehaviour {

    /// <summary>
    /// Fonction appellée quand la souris passe par dessus d'un event trigger "Pointer Enter" (Voir éditeur)
    /// </summary>
    /// <param name="texte">Le texte où la souris rentre dedans.</param>
    public void HoverEnter(Text texte)
    { texte.color = Color.green; }

    public void HoverExit(Text texte)
    { texte.color = Color.white; }

    public void NouvellePartie(string niveau)
    { SceneManager.LoadScene(niveau); }

    public void QuitterJeu()
    { Application.Quit(); } //TODO : Rajouter Ecran Confirmation
}
