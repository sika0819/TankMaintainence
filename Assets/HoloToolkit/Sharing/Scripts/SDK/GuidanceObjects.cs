using UnityEngine;
using System.Collections.Generic;
//using UnityEngine;


namespace HoloToolkit.Unity
{
    public class GuidanceObjects : Singleton<GuidanceObjects>
    {
       
        public Dictionary<string, GameObject> GuideObjects = new Dictionary<string, GameObject>();
        
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
