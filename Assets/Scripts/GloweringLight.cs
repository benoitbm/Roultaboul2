using UnityEngine;
using System.Collections;

//Script pour faire un effet de style avec la lumière augmentant et diminuant.
public class GloweringLight : MonoBehaviour {

    public Light lum;
    public float min, max, step;
    bool grow = true;
    public bool randomColor = false;

	// Use this for initialization
	void Start () {
        lum.intensity = (min + max) / 2;

        if (randomColor)
        {
            var rend = GetComponent<Renderer>();
            var mat = rend.material;

            Color tempColor = new Color(Random.Range(128.0f, 255.0f)/255.0f, Random.Range(128.0f, 255.0f) / 255.0f, Random.Range(128.0f, 255.0f) / 255.0f);

            mat.SetColor("_EmissionColor", tempColor);            
            lum.color = tempColor;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (grow)
        {
            lum.intensity += Time.deltaTime * step;
            grow = lum.intensity < max;
        }
        else
        {
            lum.intensity -= Time.deltaTime * step;
            grow = lum.intensity <= min;
        }
	}
}
