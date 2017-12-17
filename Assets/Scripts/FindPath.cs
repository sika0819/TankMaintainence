using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FindPath : MonoBehaviour {
    public Transform target;
    public Transform myPos;
    LineRenderer linedrawer;
    float distance;
    Vector3[] path;
    private Vector2 size;
    SpatialMappingManager manager;
    public GameObject GroundAnchor;
    NavMeshAgent player;
    // Use this for initialization
    void Start () {
        linedrawer = GetComponent<LineRenderer>();
        path = new Vector3[2];
        path[0] = new Vector3(myPos.transform.position.x,target.transform.position.y, myPos.transform.position.z);
        path[1] = target.transform.position;
        linedrawer.SetPositions(path);
        manager = SpatialMappingManager.Instance;
        player = Camera.main.GetComponent<NavMeshAgent>();
        player.SetDestination(target.transform.position);
        
	}
	
	// Update is called once per frame
	void Update () {

        path[0] = new Vector3(myPos.transform.position.x, GroundAnchor.transform.position.y, myPos.transform.position.z);
        path[1] = target.transform.position;
        linedrawer.SetPositions(path);
        distance =Mathf.Abs(Vector3.Distance(myPos.transform.position, target.transform.position));
        size = new Vector2(Mathf.CeilToInt(distance*10),1);
        linedrawer.material.SetTextureScale("_MainTex", size);
       
    }
}
