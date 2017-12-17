using UnityEngine;
using System.Collections;

public class swordlocation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 20 - Camera.main.transform.up * 0.5f;
        this.transform.forward = Camera.main.transform.forward;
    }
}
