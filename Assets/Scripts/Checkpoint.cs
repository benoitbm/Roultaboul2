using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    public GameObject Beacon;

    public void setCheckpointActive(bool set)
    { Beacon.SetActive(set); }

}
