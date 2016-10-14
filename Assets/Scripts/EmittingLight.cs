using UnityEngine;
using System.Collections;

//Script à la base pour utiliser les matériaux "Emetteurs" (pour la lumière) et faire un niveau basé que sur ça. J'ai du changer le système et plutôt utiliser des lumières intégrés, ce qui rend l'effet similaire. 
public class EmittingLight : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        DynamicGI.UpdateMaterials(gameObject.GetComponent<Renderer>());
        DynamicGI.UpdateEnvironment();
	}
}
