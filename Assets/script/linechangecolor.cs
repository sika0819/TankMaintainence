using UnityEngine;
using System.Collections;

public class linechangecolor : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(changecolor());
        
	}
	
	// Update is called once per frame
    private IEnumerator changecolor()
    {
        while (true)
        {
            this.GetComponent<Renderer>().material.color = Color.green ;
            yield return new WaitForSeconds(0.5f);
            this.GetComponent<Renderer>().material.color = Color.red;
            yield return new WaitForSeconds(0.5f);
        }
    }
	void Update () {
	
	}
}
