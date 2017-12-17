using UnityEngine;
using System.Collections;

public class linedrawer : MonoBehaviour {

    private LineRenderer lineRenderer=new LineRenderer ();
   // lineRenderer.
    //设置线段的个数，标示一个曲线由几条线段组成  
    private int lineLength = 4;
    private Vector3 v0 = new Vector3(100f, 0f, -100f);
    private Vector3 v1 = new Vector3(100f, 100f, -100f);
    private Vector3 v2 = new Vector3(0f, 0.0f, -100f);
    private Vector3 v3 = new Vector3(100f, 0.0f, -100f);
    // private Vector3 v3 = new Vector3(1.0f, 0.0f, 0.0f);


    // Use this for initialization
    void Start () {
        Bounds mybounds = this.GetComponent<Renderer>().bounds;
     //   mybounds .
        //GameObject.Find("Canvas").SetActive(false);
        GameObject oo = new GameObject("LineDrawerTest");
        oo.AddComponent<LineRenderer>();
        //lineRenderer = GameObject.Find("line").GetComponent<LineRenderer>();
        lineRenderer = oo.GetComponent<LineRenderer>();
        lineRenderer.SetVertexCount(lineLength);
        lineRenderer.SetColors(Color.green , Color.white);
        lineRenderer.SetWidth(2, 2);
        lineRenderer.useWorldSpace = false;
        lineRenderer.SetPosition(0, v0);
        lineRenderer.SetPosition(1, v1);
        lineRenderer.SetPosition(2, v2);
        lineRenderer.SetPosition(3, v3);
        oo.transform.position = new Vector3(-100, -100, -100);
        oo.transform.forward = Camera.main.transform.forward ;

        oo.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        
       // lineRenderer.SetPosition(3, v3);
    }
}
