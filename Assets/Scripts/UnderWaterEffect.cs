using UnityEngine;
using System.Collections;

//Script pour avoir un effet sous l'eau pour la caméra. Non utilisé pour l'instant.
public class UnderWaterEffect : MonoBehaviour {

    public GameObject eau;

    Color fogColor = new Color(0, 0.4f, 0.7f, 0.6f);
    float fogDensity = 0.04f;
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.position.y < eau.transform.position.y)
        {
            RenderSettings.fog = true;
            RenderSettings.fogColor = fogColor;
            RenderSettings.fogDensity = fogDensity;
        }
        else
            RenderSettings.fog = false;
	}
}
