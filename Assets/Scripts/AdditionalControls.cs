using UnityEngine;
using System.Collections;

public class AdditionalControls : MonoBehaviour {

    //Plan Y où la balle sera TP au dernier checkpoint
    public float voidZone = 7;
    public Transform Camera;

    Checkpoint lastCheckpoint = null;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
            Application.Quit();

        if (gameObject.transform.position.y <= voidZone)
        {
            var tempCheck = lastCheckpoint.transform.position;
            tempCheck.y += 1;
            gameObject.transform.position = tempCheck;
            tempCheck.y += 10;
            Camera.position = tempCheck;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero; //Re-initialise la vitesse à 0
        }
	}

    public void setCheckpoint(Checkpoint check)
    {
        print(check.name + " activé.");
        if (lastCheckpoint != null)
            lastCheckpoint.setCheckpointActive(true);

        lastCheckpoint = check;
        lastCheckpoint.setCheckpointActive(false);
    }
}
