using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class subtitleMenu : MonoBehaviour {
    string[] phrases =
    {
        "Parce qu'il fallait une suite.",
        "Comment ça les phrases sont générés aléatoirement ?",
        "Avec plus de contenu belge, gratuit !",
        "SAMPLE TEXT",
        "SUPER ULTRA ARCADE REMIX HYPER EDITION EX PLUS ALPHA GOTY",
        "7.8 - IGN \"Too much water.\"",
        "Salut, ça va ?",
        "L'idée des textes aléatoires dans le menu ne vient pas de Minecraft.",
        "L'EPIQUE AVENTURE DE RAOUL TABOUL"
    };

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = phrases[Random.Range(0, phrases.Length)];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
