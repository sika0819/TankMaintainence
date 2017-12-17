using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {
    public GameObject earth;//声明游戏对象earth
    public GameObject sun;//声明游戏对象sun
                           // Use this for initialization
    void Start () {
      //  sun.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        earth.transform.RotateAround(sun.transform.position, Vector3.up, 2f);
        //Debug.Log("旋转");
    }
}
