using UnityEngine;
using System.Collections;

public class instanse : MonoBehaviour {

    public static instanse Instance;
    // Use this for initialization
    void Start () {
	
	}

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
