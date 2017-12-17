using UnityEngine;
using System.Collections;

public class canvaslocation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 50; //+ Camera.main.transform.up * 20;
        this.transform.forward = Camera.main.transform.forward;
    }
}
