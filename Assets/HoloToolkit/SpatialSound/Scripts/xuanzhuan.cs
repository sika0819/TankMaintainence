using UnityEngine;
using System.Collections;

public class xuanzhuan : MonoBehaviour {

    public float rotationSpeedX = 0;
    public float rotationSpeedY = 0;
    public float rotationSpeedZ = 50;

    void Update()
    {
       // transform.Translate(Vector3.right * 90 * Time.deltaTime);
        transform.Rotate(Vector3 .forward  *90 * Time.deltaTime);
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame

}
