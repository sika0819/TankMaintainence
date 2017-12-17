using UnityEngine;
using System.Collections;

public class letterlocation : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 10;


    }
	
	// Update is called once per frame
	void Update () {
        this.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 20;// - Camera.main.transform.up *5;
        this.transform.forward = Camera.main.transform.forward;
    }
}
