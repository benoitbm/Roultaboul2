using UnityEngine;
using System.Collections;

//Script pour les zones de dégâts (mettre script sur les zones de dégâts)
public class damageZone : MonoBehaviour {

    public playerHP player;
    public float DegatsParSecondes = 10.0f;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            { player.enteringDmgZone(DegatsParSecondes); }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
            { player.leavingDmgZone(); }
    }
}
