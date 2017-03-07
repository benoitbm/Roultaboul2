using UnityEngine;
using System.Collections;

//Script gérant la santé du joueur.
public class playerHP : MonoBehaviour {

    public int HPMax = 100;
    float currentHP;
    bool takingDamage = false;
    float dps = 60;

	// Use this for initialization
	void Start () {
        currentHP = HPMax;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (! GetComponent<AdditionalControls>().isRespawning())
        {
            if (takingDamage)
                currentHP -= Time.deltaTime * dps;
            else if (!takingDamage && Input.GetAxis("Sprint") < 0.1)
                currentHP += Time.deltaTime * 2;

            if (Input.GetAxis("Sprint") >= 0.1)
                currentHP -= Time.deltaTime * Input.GetAxis("Sprint") * 20;

            if (Input.GetKey(KeyCode.M))
                currentHP -= 1;

            if (currentHP >= HPMax)
                currentHP = (float)HPMax;
            else if (currentHP < 0)
                dying();
        }
  
	}

    /// <summary>
    /// Fonction retournant le pourcentage de santé du joueur.
    /// </summary>
    /// <returns>Renvoie le pourcentage de santé du joueur (à multiplier par 100 pour avoir le pourcentage)</returns>
    public float returnHP()
    { return currentHP / (float)HPMax; }

    /// <summary>
    /// Fonction pour enlever de la santé au joueur d'un coup.
    /// </summary>
    /// <param name="dmg">Dégâts à infliger.</param>
    public void takeDMG(float dmg)
    { currentHP -= Mathf.Abs(dmg); }

    public void restoreHP(float HP)
    { currentHP += Mathf.Abs(HP); }

    public void restoreFullLife()
    { currentHP = HPMax; }

    /// <summary>
    /// Fonction pour activer la prise de dégâts du joueur.
    /// </summary>
    public void enteringDmgZone()
    { takingDamage = true; }

    /// <summary>
    /// Fonction pour activer la prise de dégâts du joueur et de régler combien de santé il perd par seconde.
    /// </summary>
    /// <param name="dmg">Le nombre de dégâts que le joueur perd par secondes.</param>
    public void enteringDmgZone(float dmg)
    {
        takingDamage = true;
        dps = dmg;
    }

    /// <summary>
    /// Fonction pour désactiver la prise de dégâts du joueur.
    /// </summary>
    public void leavingDmgZone()
    { takingDamage = false; }

    /// <summary>
    /// Fonction pour faire mourir le joueur.
    /// </summary>
    public void dying()
    {
        currentHP = HPMax;
        takingDamage = false;
        GetComponent<AdditionalControls>().respawn();
    }

}
