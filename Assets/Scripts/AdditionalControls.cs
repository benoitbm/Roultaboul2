using UnityEngine;
using System.Collections;

public class AdditionalControls : MonoBehaviour {

    //Plan Y où la balle sera TP au dernier checkpoint
    public float voidZone = 7;
    public Transform Camera;

	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
            Application.Quit();

        if (gameObject.transform.position.y <= voidZone)
        {
            var tempCheck = GameObject.FindGameObjectWithTag("Checkpoint").transform.position; //TODO : Ajouter gestions checkpoints
            tempCheck.y += 1;
            gameObject.transform.position = tempCheck;
            tempCheck.y += 10;
            Camera.position = tempCheck;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero; //Re-initialise la vitesse à 0
        }
	}
}
