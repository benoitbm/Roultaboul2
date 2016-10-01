using UnityEngine;
using System.Collections;

public class playerHP : MonoBehaviour {

    public int HPMax = 100;
    float currentHP;

	// Use this for initialization
	void Start () {
        currentHP = HPMax;
	}
	
	// Update is called once per frame
	void Update () {
        if (currentHP >= HPMax)
            currentHP = (float)HPMax;
        else if (currentHP < 0)
            currentHP = 0;
        else
            currentHP += Time.deltaTime * 2;

        if (Input.GetKey(KeyCode.M))
            currentHP -= 1;
	}

    public float returnHP()
    { return currentHP / (float)HPMax; }
}
