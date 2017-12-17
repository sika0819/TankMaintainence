
using UnityEngine;

using Vuforia;
using System.Collections.Generic;


public class DynamicDataSetLoader : MonoBehaviour
{
    // Use this for initialization

    // Update is called once per frame

    // specify these in Unity Inspector
    public GameObject augmentationObject;  // you can use teapot or other object
    public string dataSetName = "Test2";  //  Assets/StreamingAssets/QCAR/DataSetName
                                
    // public Material mSimpleMat; //检测出物体轮廓的材质
                                          // int counter = 0;
                                          // Use this for initialization
    List<GameObject> CurrentGameObject;
    void Start()
    {
       // dataSetName = "Test2";
        VuforiaBehaviour vb = GameObject.FindObjectOfType<VuforiaBehaviour>();
        vb.RegisterVuforiaStartedCallback(DynamicSet);

       // Debug.Log("fsdf");
    }
    void Update()
    {
        //  RecogRunTime();
    }

    void DynamicSet()
    {
        CameraDevice.Instance.SetFocusMode( CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO); //自动对焦
        CameraDevice.Instance.SetFlashTorchMode(true); //打开闪光灯

        ObjectTracker objectTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
        IEnumerable<TrackableBehaviour> tbs = TrackerManager.Instance.GetStateManager().GetTrackableBehaviours();
     
        //  DataSet dataSet = objectTracker.CreateDataSet();
        // DataSet dataSet2 = objectTracker.CreateDataSet();

        //  dataSet.Load("StonesAndChips");
        //  objectTracker.Stop();
        //   objectTracker.ActivateDataSet(dataSet);
        //  objectTracker.Start();
        // objectTracker.


        /* if (dataSet2.Load(dataSetName))
         {

             objectTracker.Stop();  // stop tracker so that we can add new dataset

             if (!objectTracker.ActivateDataSet(dataSet2))
             {
                 // Note: ImageTracker cannot have more than 100 total targets activated
                 Debug.Log("<color=yellow>Failed to Activate DataSet: " + dataSetName + "</color>");
             }

             if (!objectTracker.Start())
             {
                 Debug.Log("<color=yellow>Tracker Failed to Start.</color>");
             }*/
        //IEnumerable<TrackableBehaviour> tbs = TrackerManager.Instance.GetStateManager().GetTrackableBehaviours();
     //   if (GuidanceSet.Instance.IfRecognized == true)
        {
            foreach (TrackableBehaviour tb in tbs)
            {
                //  if(tb.CurrentStatus==TrackableBehaviour.Status.DETECTED)
                //if (tb.name == "New Game Object")
                
                    if (tb.TrackableName == "AllMianBan")
                    {
                    //tb.GetType 
                    // if( (int)tb.CurrentStatus>1 )
                    //  {

                    //  }
                    //  ImageTargetBehaviour itb = tb as ImageTargetBehaviour;
                    //  itb.ImageTarget.
                    // tb.gameObject.name = ++counter + ":DynamicImageTarget-" + tb.TrackableName;
                    // tb.gameObject.AddComponent<DefaultTrackableEventHandler>();
                    // tb.gameObject.AddComponent<TurnOffBehaviour>();
                    //    List <>
                    /* Transform[] AllChildren = tb.gameObject.GetComponentsInChildren<Transform>();
                     foreach (Transform child in AllChildren)
                     {
                         // child.gameObject.transform.localPosition  = Vector3.zero;
                         child.localPosition = new Vector3(child.localPosition.x, -3f, child.localPosition.z-0.4f);
                     }
                     Vector3 TextPosition = tb.gameObject.transform.FindChild("3DText2").localPosition;
                     tb.gameObject.transform.FindChild("3DText2").localPosition = new Vector3(TextPosition.x + 0.05f, TextPosition.y, TextPosition.z);*/
                    // CurrentGameObject = tb.gameObject.transform .get
                    // if (augmentationObject != null)
                    // {
                    // instantiate augmentation object and parent to trackable

                    // tb.GetComponent <ImageTargetBehaviour >().
                    // Child.GetComponent<Renderer>().material.color = Color.yellow;
                    // augmentation.transform.localPosition = new Vector3(0f, 0f, 0.2f);
                    //  }
                    tb.GetComponent<ImageTarget>().StartExtendedTracking();
                }    

                /*if (tb.TrackableName == "AllMianBan")
                {
                    Vector3 LinePosition = tb.gameObject.transform.FindChild("One").localPosition;
                    tb.gameObject.transform.FindChild("One").localPosition = new Vector3(LinePosition.x + 0.05f, LinePosition.y, LinePosition.z);
                }*/

                //扩展追踪
                //扩展追踪         
               // tb.GetComponent<ImageTarget>().StartExtendedTracking();
              
            }
        }
    }
}
/*     GameObject augmentation = (GameObject)GameObject.Instantiate(augmentationObject);
     augmentation.GetComponent<TextMesh>().text = "这是一本书";                                                                   
     augmentation.GetComponent<Renderer>().material.color = Color.green;                        
     augmentation.transform.localScale = new Vector3(20f, 30f, 20f);                                              
     augmentation.transform.forward = tb.gameObject.transform.up;
     augmentation.transform.Rotate(0, 180, 180, Space.Self);
     augmentation.transform.parent = tb.gameObject.transform;
     augmentation.transform.position = tb.gameObject.transform.position + tb.gameObject.transform.right * 70;



     #region Draw a line
     //指示线
     LineRenderer GuideLineRenderer = new LineRenderer();
     GameObject GuideLine = new GameObject("GuideLine");
     GuideLine.AddComponent<LineRenderer>();
     GuideLineRenderer = GuideLine.GetComponent<LineRenderer>();

     //轮廓线
     LineRenderer BoundaryRenderer = new LineRenderer();
     GameObject BoundaryLine = new GameObject("BoundaryLine");
     BoundaryLine.AddComponent<LineRenderer>();
     BoundaryRenderer = BoundaryLine.GetComponent<LineRenderer>();

     //指示线顶点
     Vector3 GuideV0 = tb.gameObject.transform.position; //线起点
     Vector3 GuideV1 = tb.gameObject.transform.position + tb.gameObject.transform.right * 70; //线终点

     //轮廓线顶点
     Vector3 BoundaryV0 = tb.gameObject.transform.position - tb.gameObject.transform.right * tb.gameObject.transform.localScale.x / 2 - tb.gameObject.transform.forward * tb.gameObject.transform.localScale.z / 2;   //左下角                                                             
     Vector3 BoundaryV1 = tb.gameObject.transform.position + tb.gameObject.transform.right * tb.gameObject.transform.localScale.x / 2 - tb.gameObject.transform.forward * tb.gameObject.transform.localScale.z / 2;   //右下角                                                                               
     Vector3 BoundaryV2 = tb.gameObject.transform.position + tb.gameObject.transform.right * tb.gameObject.transform.localScale.x / 2 + tb.gameObject.transform.forward * tb.gameObject.transform.localScale.z / 2;   //右上角
     Vector3 BoundaryV3 = tb.gameObject.transform.position - tb.gameObject.transform.right * tb.gameObject.transform.localScale.x / 2 + tb.gameObject.transform.forward * tb.gameObject.transform.localScale.z / 2;   //左上角
     Vector3 BoundaryV4 = tb.gameObject.transform.position - tb.gameObject.transform.right * tb.gameObject.transform.localScale.x / 2 - tb.gameObject.transform.forward * tb.gameObject.transform.localScale.z / 2;   //左下角

     //画轮廓线
     BoundaryRenderer.SetVertexCount(5);
     BoundaryRenderer.SetColors(Color.green, Color.white);
     BoundaryRenderer.SetWidth(0.5f, 0.5f);
     BoundaryRenderer.useWorldSpace = false;                                  
     BoundaryLine.transform.parent = tb.gameObject.transform;
     BoundaryRenderer.SetPosition(0, BoundaryV0);
     BoundaryRenderer.SetPosition(1, BoundaryV1);
     BoundaryRenderer.SetPosition(2, BoundaryV2);
     BoundaryRenderer.SetPosition(3, BoundaryV3);
     BoundaryRenderer.SetPosition(4, BoundaryV4);
     BoundaryLine.SetActive(true);

     //画指示线
     GuideLineRenderer.SetVertexCount(2);
     GuideLineRenderer.SetColors(Color.green, Color.white);
     GuideLineRenderer.SetWidth(0.5f, 0.5f);
     GuideLineRenderer.useWorldSpace = false;                                     
     GuideLine.transform.parent = tb.gameObject.transform;
     GuideLineRenderer.SetPosition(0, GuideV0);
     GuideLineRenderer.SetPosition(1, GuideV1);
     GuideLine.SetActive(true);                 
     #endregion

 }
 else
 {
     Debug.Log("<color=yellow>Warning: No augmentation object specified for: " + tb.TrackableName + "</color>");
 }
}
}
}
// int counter = 0;
//while (true)

}
else
{
Debug.LogError("<color=yellow>Failed to load dataset: '" + dataSetName + "'</color>");
}
}*/

// void RecogRunTime()
//{

// }




