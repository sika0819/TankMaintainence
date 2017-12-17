using UnityEngine;
using System.Collections;
using HoloToolkit.Unity;

public class cameratest : Singleton<cameratest>
{
    public bool IfMainCameraWork = true;
    bool change = false;
    public Camera MainCamera;
    public Camera Camera2;
  //  GameObject Camera2 = GameObject.FindWithTag("Camera");
    // Use this for initialization
    void Start () {
        //Camera2.transform.position = MainCamera.transform.position;
        // Camera2.transform.localScale = MainCamera.transform.localScale;
        // Camera2.transform .rotation = MainCamera.transform.rotation;
        
       
    }
	
	// Update is called once per frame
	void Update () {
        //GameObject.Find("Cube").transform.Translate(Vector3.right * 20 * Time.deltaTime);
        //Camera2.transform.LookAt(GameObject.Find("Cube").transform);
        if (Input.GetMouseButtonDown(0))
        {
          // Camera.allCameras.
            Debug.Log("已点击鼠标");
            if (change)
            {
                MainCamera.enabled = false;
                Camera2.enabled = true;          
                change = !change;
                IfMainCameraWork = false;
            }
            else
            {
                MainCamera.enabled = true;
                Camera2.enabled = false;
                change = !change;
                IfMainCameraWork = true;
            }
            
//Camera.SetupCurrent(MainCamera);
            //SecurityCamera.ChangeCamera("Main Camera");
        }
	}
}
