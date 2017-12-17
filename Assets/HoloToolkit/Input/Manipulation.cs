using UnityEngine;
using System.Collections;

using HoloToolkit.Unity;
using UnityEngine.UI;

public class Manipulation : Singleton<Manipulation>
{
    // public bool jj;
    //public int hh;
    // public Vector3 PosOrigin = GameObject.Find("Cube").transform.position;//  tr  transform.position;
    public enum Operation
    {
        up = 0,
        down = 1,
        left = 2,
        right = 3,
        forward = 4,
        back = 5,
    }
    // Use this for initialization
    void Start()
    {
        // Vector3 PosOrigin = transform.position;
        // float StartTime = Time.time;
        // float TimeBetweenUpdates = 2.5f;
        // StartCoroutine(move(gameObject ,PosOrigin, StartTime, TimeBetweenUpdates)); 
    }

    // Update is called once per frame
    void Update()
    {

    }



    public IEnumerator move(GameObject obj, Vector3 PosOrigin,float Speed, float StartTimeOrigin, float StartTimeUpdate, float TimeBetweenUpdates, float Duration, Operation way)
    {
        while ((Time.time - StartTimeOrigin) < Duration)
        {
            if (way == Operation.up)
            {
                obj.transform.Translate(Vector3.up * Speed * Time.deltaTime, Space.Self);
            }
        
            else if (way == Operation.down)
            {
                obj.transform.Translate(Vector3.down * Speed * Time.deltaTime, Space.Self);
            }

            else if (way == Operation.left)
            {
                obj.transform.Translate(Vector3.left * Speed * Time.deltaTime, Space.Self);
            }

            else if (way == Operation.right)
            {
                obj.transform.Translate(Vector3.right * Speed * Time.deltaTime, Space.Self);
            }

            else if (way == Operation.forward)
            {
                obj.transform.Translate(Vector3.forward  * Speed * Time.deltaTime, Space.Self);
            }

            else if (way == Operation.back)
            {
                obj.transform.Translate(Vector3.back  * Speed * Time.deltaTime, Space.Self);
            }

            if (Time.time - StartTimeUpdate > TimeBetweenUpdates)
            {
                obj.transform.position = PosOrigin;
                StartTimeUpdate = Time.time;
            }

            yield return 0;
        }
       // stop
      // StopAllCoroutines
    }
}
