using UnityEngine;
using System.Collections;

namespace HoloToolkit.Unity
{ 
    public class CreateObject : Singleton<CreateObject>
    {
       // public Vector3 pos= Camera.main.ViewportToWorldPoint(new Vector3(0.2f, 0.2f, 200));
       
        public GameObject obj;
        // Use this for initialization
        void Start()
        {
           
            //IEnumerator hh = Create();
           // StartCoroutine(Create());
            //Debug.Log("已经开始产生物体协程");
        }

        // Update is called once per frame
        void Update()
        {
            
           // pos = Camera.main.ViewportToWorldPoint(new Vector3(0.2f, 0.2f, 200));
        }
     
        public IEnumerator Create()
        {
            while (true)
            {
            
           
                //   Instantiate(obj, Camera.main.transform.position + Camera.main.transform.forward * 200, Quaternion.identity);
                GameObject NewObj=Instantiate(obj, Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 300)), Quaternion.identity) as GameObject;
                Debug.Log(Camera.main.WorldToViewportPoint(NewObj.transform .position).z );
                // Debug.Log("已经产生物体");
               // Debug.Log("pos="+pos);
                yield return new WaitForSeconds(2);
            }
        }
    }
}