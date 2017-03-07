using UnityEngine;
using System.Collections;

//Fonction pour simuler le mouvement de la texture 
public class MovingTexture : MonoBehaviour {

    Renderer rend;
    Material mat;
    float y = 0;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        mat = rend.material;
	}
	
	// Update is called once per frame
	void Update () {
        y -= Time.deltaTime/3;
        if (y < -1)
            y %= 1;
        mat.SetTextureOffset("_MainTex", new Vector2(0, y));
	}
}
