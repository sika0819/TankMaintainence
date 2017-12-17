using UnityEngine;

public class Mymaterial : MonoBehaviour {

    public Material  green;
	// Use this for initialization
	void Start () {
        //this.gameObject .GetComponentsInChildren
        //  Transform[] AllChildren = this.GetComponentInChildren<Transform>().gameObject .GetComponentsInChildren <Transform >() ;
       // Transform[] AllChildren =this.transform.FindChild   this.GetComponentsInChildren(Transform);
        foreach (Transform child in transform )
        {
           // child.gameObject.GetComponent<Renderer>().enabled = false;
          //  child.gameObject.GetComponent<MeshRenderer>().material = green;
            child.gameObject.GetComponent<Renderer>().material = null;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
