using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using HoloToolkit.Unity;
using System.Collections.Generic;
using Vuforia;
using System;
using UnityEngine.EventSystems;

public class GuidanceSet : Singleton<GuidanceSet>
{
    /*
    
    public Button HideGuidance;
    public Button StartGuide;
    public Button Course;
    public Button NextStep;
    public Button LastStep;
    public Button BackToMain;
    public Button HideMainMenu;
    public Button IfRecognized;
    public Button CourseToMain;
    public Button DrpButton;
    public Button GuidanceAnchor;
    public Button MainAnchor;
    public GameObject  DrpCanvas;
    public GameObject  TimeText;//系统时间显示窗口（Text)
    public  List<GameObject> ObjectsStatic; //维修时显示的物体
    public  List<GameObject> ObjectsAnimation; //播放动画时的物体
    public float ObjectDistance; //显示物体与人眼的距离
    public float ObjectDown; //显示物体与人眼的下边距
    public bool MainHideSet;
    public bool GuidanceHideSet;
    public bool MenuHideSet;
    public IEnumerable<DataSet> CurrentDataSets; //当前的所有识别数据库
    public IEnumerable<TrackableBehaviour> TBCurrent;
    public IEnumerable<TrackableBehaviour> tbs;
    public ObjectTracker objectTracker;          //物体跟踪管理器
    public DateTime DT ; //当前系统时间
    public GameObject MainCanvas;
    public GameObject GuidanceCanvas;
    public GameObject PictureCanvas;
    public bool MainCanvasEnable;
    public bool GuidanceCanvasEnable;
    public bool PictureCanvasEnable;
    public bool IfHitButton ;
    public bool IfGuidanceFix; //是否固定辅助菜单
    public bool IfMainFix; //是否固定主菜单
    public Button BtnSelected; //用户凝视的按钮
    public float RayCastLength ; //按钮最大识别距离
    public LayerMask UILayerMask;
    public List<GameObject > TargetChilds;

    private Vector3 uiRayCastOrigin;
    private Vector3 uiRayCastDirection;
    private Button BtnSelected_old; //记录用户之前凝视的按钮
    private Vector3 hitPos, hitNormal; //按钮位置，按钮法线方向
    private Vector3 CurrentCamPos; //相机当前位置
    private Vector3 CurrentCamRot; //相机当前旋转角度
    private ColorBlock cb; //设置按钮的颜色
    private float DistanceFromEyes; //界面离眼睛的距离
    private bool IfWeenMove;
    private IEnumerator Teacher1;
    private IEnumerator Teacher2;
    private bool IfDataSetActive;
    private VuforiaBehaviour vb;

    
    void Start ()
    {
        IfMainFix = false;
        IfGuidanceFix = false;
        ObjectsStatic = new List<GameObject>();
        ObjectsAnimation = new List<GameObject>();
        IfHitButton = false;
        IfDataSetActive = true;
        ObjectDistance = 1;
        ObjectDown = 0.1f;
        MainHideSet = false;
        GuidanceHideSet = false;
        MenuHideSet = false;
        DrpCanvas.SetActive(false);
        vb = GameObject.FindObjectOfType<VuforiaBehaviour>();
        vb.RegisterVuforiaStartedCallback(DynamicSet);
        Resources.UnloadUnusedAssets();
        cb = new ColorBlock();
        RayCastLength = 20f;    
        MainCanvasEnable = true;
        GuidanceCanvasEnable = false;
        PictureCanvasEnable = false;
        IfWeenMove = false;
        DistanceFromEyes = 1.2f;
        MainCanvas.transform.localScale = new Vector3(0.002f, 0.002f, 0.002f);
        GuidanceCanvas.transform.localScale = new Vector3(0.002f, 0.002f, 0.002f);
        PictureCanvas.transform.localScale = new Vector3(0.002f, 0.002f, 0.002f);
        MainCanvas.transform.position = Camera.main.transform.position + Camera.main.transform.forward * DistanceFromEyes;
        StartCoroutine(ChooseCanvasShow());
        StartCoroutine(MainCanvasShow());
        StartCoroutine(TimeToShow());


    }

    private void SetButton(Button btn, Color color)
    {
     
        cb.normalColor = color;
        cb.highlightedColor = Color.white;
        cb.pressedColor = Color.white;
        cb.disabledColor = Color.white;
        cb.colorMultiplier = 1;
        cb.fadeDuration = 0.1f;
        btn.colors = cb;
    }

    private bool CastUI(out Vector3 hitPos, out Vector3 hitNormal, out Button hitButton )
    {
        // Defaults
        hitPos = Vector3.zero;
        hitNormal = Vector3.zero;
        hitButton = null; //提前赋值为空
                      
        // Do the raycast
        RaycastHit hitInfo;

        uiRayCastOrigin = Camera.main.transform.position;
        uiRayCastDirection = Camera.main.transform.forward;
        if (Physics.Raycast(uiRayCastOrigin, uiRayCastDirection, out hitInfo, RayCastLength, UILayerMask))
        {
   
            Canvas canvas = hitInfo.collider.gameObject.GetComponent<Canvas>();
            if (canvas != null)
            {
                GraphicRaycaster canvasRaycaster = canvas.gameObject.GetComponent<GraphicRaycaster>();
                if (canvasRaycaster != null)
                {
                    
                    // Cast only against this canvas
                    PointerEventData pData = new PointerEventData(EventSystem.current);

                    pData.position = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
                    pData.delta = Vector2.zero;
                    pData.scrollDelta = Vector2.zero;

                    List<UnityEngine.EventSystems.RaycastResult> canvasHits = new List<UnityEngine.EventSystems.RaycastResult>();
                    canvasRaycaster.Raycast(pData, canvasHits);
                    for (int i = 0; i < canvasHits.Count; ++i)
                    {
                        Button button = canvasHits[i].gameObject.GetComponent<Button>();
                        // Dropdown.OptionData  dropdown = canvasHits[i].gameObject.GetComponent<Dropdown.OptionData >();
                        // Dropdown dropdown = canvasHits[i].gameObject.GetComponent<Dropdown>();
                        //  dropdown.Show();  
                        if (button != null)
                        {
                            hitPos = uiRayCastOrigin + uiRayCastDirection * canvasHits[i].distance;
                            hitNormal = canvasHits[i].gameObject.transform.forward;
                            hitButton = button;
                            return true;
                        }

                       //  if (dropdown != null)
                        // {
                        //     hitPos = uiRayCastOrigin + uiRayCastDirection * canvasHits[i].distance;
                        //     hitNormal = canvasHits[i].gameObject.transform.forward;
                        //     HitDrp  = dropdown;
                        //     return true;
                        // }
                    }

                    // No buttons, but hit canvas object
                    hitPos = hitInfo.point;
                    hitNormal = hitInfo.normal;
                    return false;
                }
            }
        }
        return false;
    }

    
    public IEnumerator MainCanvasShow()
    {
        while(true)
        {
            //主菜单显示
            if (!MainCanvasEnable)
            {
                MainCanvas.SetActive(false);
            }

            else if (MainCanvasEnable)
            {
                GuidanceCanvas.SetActive(false);
                PictureCanvas.SetActive(false);
                if (!MainCanvas.activeSelf)
                {
                    MainCanvas.SetActive(true);
                }

                if ((GazeManager.Instance.FocusedObject != MainCanvas) && (GazeManager.Instance.FocusedObject != DrpCanvas) && !IfMainFix)
                {

                    yield return new WaitForSeconds(0.5f);
                    CurrentCamPos = Camera.main.transform.position + Camera.main.transform.forward * DistanceFromEyes;
                    CurrentCamRot = Camera.main.transform.rotation.eulerAngles;

                    if (IfWeenMove == false)
                    {
                        IfWeenMove = true;
                        iTween.MoveTo(MainCanvas, CurrentCamPos, 1.2f);
                        iTween.RotateTo(MainCanvas, CurrentCamRot, 1.2f);
                        yield return new WaitForSeconds(1f);
                        IfWeenMove = false;
                    
                    }
                }
            }
            yield return null;
        }
    }

    
    public IEnumerator ChooseCanvasShow()
    {
        while (true)
        {
            //按钮显示
            
            if (CastUI(out hitPos, out hitNormal, out BtnSelected ) && BtnSelected != null)
            {
                if (IfHitButton == false)
                {
                    BtnSelected_old = BtnSelected;
                    IfHitButton = true;
                    SetButton(BtnSelected, Color.green);
                }

            }
            else if (BtnSelected == null)
            {
                if (BtnSelected_old != null && IfHitButton == true)
                {
                    IfHitButton = false;
                    if( (BtnSelected_old == GuidanceAnchor && IfGuidanceFix ==true) || (BtnSelected_old == MainAnchor  && IfMainFix == true) )
                        SetButton(BtnSelected_old, Color.yellow);
                    else
                    SetButton(BtnSelected_old, Color.white);
                }
            }
            // yield return null;

            //指导菜单显示
            if (!GuidanceCanvasEnable)
            {
                GuidanceCanvas.SetActive(false);
                StopCoroutine(TimeToShow());
            }

            else if (GuidanceCanvasEnable  )
            {
                PictureCanvas.SetActive(false);
                MainCanvas.SetActive(false);
                StartCoroutine(TimeToShow());

                if (!GuidanceCanvas.activeSelf)
                {
                    GuidanceCanvas.SetActive(true);
                }
               
                if (GazeManager.Instance.FocusedObject != GuidanceCanvas && !IfGuidanceFix )
                {

                    yield return new WaitForSeconds(0.5f);
                    CurrentCamPos = Camera.main.transform.position + Camera.main.transform.forward * DistanceFromEyes;
                    CurrentCamRot = Camera.main.transform.rotation.eulerAngles;
                    if (IfWeenMove == false)
                    {
                        IfWeenMove = true;
                        iTween.MoveTo(GuidanceCanvas, CurrentCamPos, 1.2f);
                        iTween.RotateTo(GuidanceCanvas, CurrentCamRot, 1.2f);
                        yield return new WaitForSeconds(1f);
                        IfWeenMove = false;
                    }

                    // CurrentCamPos = Camera.main.transform.position + Camera.main.transform.forward * DistanceFromEyes;
                    // Camera.main.transform.rotation
                    //  GuidanceCanvas.transform.position = Vector3.Slerp(GuidanceCanvas.transform.position, CurrentCamPos, 0.06f);
                    //  GuidanceCanvas.transform.rotation = Quaternion.Slerp(GuidanceCanvas.transform.rotation, Camera.main.transform.rotation, 0.06f);
                    // GuidanceCanvas.transform.forward = Camera.main.transform.forward;
                }
            }

            // yield return null;


            //提示图像显示
            if (!PictureCanvasEnable)
            {
                PictureCanvas.SetActive(false);
            }

            else if (PictureCanvasEnable)
            {
                GuidanceCanvas.SetActive(false);
                MainCanvas.SetActive(false);
                if (!PictureCanvas.activeSelf)
                {
                    PictureCanvas.SetActive(true);
                }
  
                if (GazeManager.Instance.FocusedObject != PictureCanvas)
                {
                    yield return new WaitForSeconds(0.5f);
                    CurrentCamPos = Camera.main.transform.position + Camera.main.transform.forward * DistanceFromEyes;
                    CurrentCamRot = Camera.main.transform.rotation.eulerAngles;
                    if (IfWeenMove == false)
                    {
                        IfWeenMove = true;
                        iTween.MoveTo(PictureCanvas, CurrentCamPos, 1.2f);
                        iTween.RotateTo(PictureCanvas, CurrentCamRot, 1.2f);
                        yield return new WaitForSeconds(1f);
                        IfWeenMove = false;
                    }
                    //  CurrentCamPos = Camera.main.transform.position + Camera.main.transform.forward * DistanceFromEyes;
                    //  PictureCanvas.transform.position = Vector3.Slerp(PictureCanvas.transform.position, CurrentCamPos, 0.06f);
                    //  PictureCanvas.transform.rotation = Quaternion.Slerp(PictureCanvas.transform.rotation, Camera.main.transform.rotation, 0.06f);
                    // PictureCanvas.transform.forward = Camera.main.transform.forward;
                }
            }

            // yield return null;

            //主菜单显示
            yield return null;
        }
    }

    private void DynamicSet()
    {
        CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO); //自动对焦
        CameraDevice.Instance.SetFlashTorchMode(true); //打开闪光灯                                                            
        tbs = TrackerManager.Instance.GetStateManager().GetTrackableBehaviours();
        if (IfDataSetActive == true)
        {

            for (int i = 0; i <= GuidanceManager.Instance.GuidanceCount - 1; i++)
            {             
                    TargetChilds[i].SetActive(true);                                     
            }

            foreach (TrackableBehaviour tb in tbs)
            {            
                if (tb.TrackableName == "AllMianBan")
                {

                    ImageTargetBehaviour itb = tb as ImageTargetBehaviour;
                    itb.ImageTarget.StartExtendedTracking();
                  

                }
        
            }
        }
    }

    //  if(tb.CurrentStatus==TrackableBehaviour.Status.DETECTED)
    //if (tb.name == "New Game Object")
    //  DataSet dataSet = objectTracker.CreateDataSet();
    // DataSet dataSet2 = objectTracker.CreateDataSet();

    //  dataSet.Load("StonesAndChips");
    //  objectTracker.Stop();
    //   objectTracker.ActivateDataSet(dataSet);
    //  objectTracker.Start();
    // objectTracker.

    //if (dataSet2.Load(dataSetName))
  //   {

  //       objectTracker.Stop();  // stop tracker so that we can add new dataset
  
      //   if (!objectTracker.ActivateDataSet(dataSet2))
      //   {
             // Note: ImageTracker cannot have more than 100 total targets activated
       //      Debug.Log("<color=yellow>Failed to Activate DataSet: " + dataSetName + "</color>");
      //   }

      //   if (!objectTracker.Start())
      //   {
      //       Debug.Log("<color=yellow>Tracker Failed to Start.</color>");
      //   }
    //IEnumerable<TrackableBehaviour> tbs = TrackerManager.Instance.GetStateManager().GetTrackableBehaviours();
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
 

    //扩展追踪
    //扩展追踪         
    // tb.GetComponent<ImageTarget>().StartExtendedTracking();


    public void SetChildShow()
    {
       // tbs = TrackerManager.Instance.GetStateManager().GetTrackableBehaviours();
        if (IfDataSetActive == true)
        {
            // foreach (TrackableBehaviour tb in tbs)
            // {
            //   if (tb.TrackableName == "AllMianBan")
            //   {

            //  Transform[] AllChildren = tb.gameObject.GetComponentsInChildren<Transform>();
            //       foreach(var child in TargetChilds )
            //       {
            //          Debug.Log("Line" + ((GuidanceManager.Instance.GuidanceStep + 1).ToString()));
            for (int i = 0; i <= GuidanceManager.Instance.GuidanceCount - 1; i++)
            {
                if (i== GuidanceManager.Instance.GuidanceStep )
                {

                    TargetChilds[i].SetActive(true); 
                }
                else
                    TargetChilds[i].SetActive(false);
            }
   
        }
    }


    public void SetButtonClicked() //点击按钮的响应事件
    {
        //用户点击下拉菜单
        if (BtnSelected == DrpButton)
        {
            if (!MenuHideSet)
            {
                DrpCanvas.SetActive(true);
                MenuHideSet = true;
            }
            else
            {
                DrpCanvas.SetActive(false);
                MenuHideSet = false;
            }
        }

        //隐藏主菜单按钮
        if (BtnSelected == HideMainMenu)
        {

             MainHideSet = true;
             MainCanvasEnable = false;
             GuidanceCanvasEnable = false;
        }

        //固定指导菜单
        if (BtnSelected == GuidanceAnchor )
        {
            
            IfGuidanceFix = !IfGuidanceFix ;

            if (IfGuidanceFix == true)
            {
                BtnSelected.transform.GetChild(0).GetComponent<Text>().text = "已固定";
                SetButton(BtnSelected, Color.yellow);
            }
            else
            {
                BtnSelected.transform.GetChild(0).GetComponent<Text>().text = "固定";
                SetButton(BtnSelected, Color.white);
            }

        }

        //固定主菜单
        if (BtnSelected == MainAnchor )
        {

            IfMainFix  = !IfMainFix;

            if (IfMainFix == true)
            {
                BtnSelected.transform.GetChild(0).GetComponent<Text>().text = "已固定";
                SetButton(BtnSelected, Color.yellow);
            }
            else
            {
                BtnSelected.transform.GetChild(0).GetComponent<Text>().text = "固定";
                SetButton(BtnSelected, Color.white);
            }

        }

        //是否识别按钮
        if ( BtnSelected == IfRecognized)
        {
            objectTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
            CurrentDataSets = objectTracker.GetDataSets();
            foreach (DataSet dataset in CurrentDataSets)
            {
            
                if ( (dataset.Path == "QCAR/YuanZhu.xml") && (IfDataSetActive == true) )
                {
                   // Debug.Log("注销");
                    //Debug.Log("注销");
                    objectTracker.Stop();          
                    objectTracker.DeactivateDataSet (dataset);
                    objectTracker.Start();
                    IfDataSetActive = false;
                }
                else if ( (dataset.Path == "QCAR/YuanZhu.xml") && (IfDataSetActive == false) )
                {
                   // Debug.Log("激活");
                   // Debug.Log("激活");            
                    objectTracker.Stop();
                    objectTracker.ActivateDataSet(dataset);                
                    objectTracker.Start();
                    IfDataSetActive = true; 
                }
                
            }
        }




        //教程按钮
        if (BtnSelected == Course)
        {

            MainCanvasEnable = false;

            // 显示教程图片
            PictureCanvasEnable = true;

            GameObject ObjectShowed = CreateObjects(0, 2, "MeTank", ObjectsAnimation);
            GameObject Child1 = ObjectShowed.transform.FindChild("Tower").gameObject;
            GameObject Child2 = ObjectShowed.transform.FindChild("Body").gameObject;
            Child1.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            Child2.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

            //开启协程
            Teacher1 = Manipulation.Instance.move(Child1, Child1.transform.position, 0.05f, Time.time, Time.time, 3, 10, Manipulation.Operation.forward);
            Teacher2 = Manipulation.Instance.move(Child2, Child2.transform.position, 0.05f, Time.time, Time.time, 3, 10, Manipulation.Operation.down);
            StartCoroutine(Teacher1);
            StartCoroutine(Teacher2);  
       
        }

        //隐藏维修菜单按钮
        else if (BtnSelected == HideGuidance)
        {
            GuidanceHideSet = true;
            ClearOriginObjects(ObjectsStatic);
            MainCanvasEnable = false;
            GuidanceCanvasEnable = false;
            PictureCanvasEnable = false;
        }


        //教程返回主菜单按钮
        if (BtnSelected == CourseToMain )
        {
            GuidanceCanvasEnable = false;
            PictureCanvasEnable = false;
            MainCanvasEnable = true;
            StopCoroutine(Teacher1);
            StopCoroutine(Teacher2);
        
            ClearOriginObjects(ObjectsAnimation);

        }


        //开始维修按钮
        else if (BtnSelected == StartGuide)
        {
            ClearOriginObjects(ObjectsStatic);
            MainCanvasEnable = false;
            PictureCanvasEnable = false;
            GuidanceCanvasEnable = true;
            if (GuidanceManager.Instance.GuidanceStep == 0)
            {
          
                CreateObjects(ObjectDown, ObjectDistance, "PaoTa", ObjectsStatic);
            }
            if (GuidanceManager.Instance.GuidanceStep == 1)
            {
                CreateObjects(ObjectDown, ObjectDistance, "DiZuo", ObjectsStatic);
            }
            SetChildShow();
        }

        //下一步按钮
        else if (BtnSelected == NextStep)
        {
            ClearOriginObjects(ObjectsStatic);
            GuidanceManager.Instance.GuidanceStep += 1;
            GuidanceManager.Instance.GuidanceStep = GuidanceManager.Instance.GuidanceStep % GuidanceManager.Instance.GuidanceCount;
            GuidanceManager.Instance.GuidanceText.GetComponent<Text>().text = GuidanceManager.Instance.GuideSource[GuidanceManager.Instance.GuidanceStep];
            if (GuidanceManager.Instance.GuidanceStep == 0)
            {
                CreateObjects(ObjectDown, ObjectDistance, "PaoTa", ObjectsStatic);
          
            }

            if (GuidanceManager.Instance.GuidanceStep == 1)
            {
                CreateObjects(ObjectDown, ObjectDistance, "DiZuo", ObjectsStatic);
       
            }

            SetChildShow();



            //用加载得到的资源对象，实例化游戏对象，实现游戏物体的动态加载

        }

        //上一步按钮
        else if (BtnSelected == LastStep)
        {
            ClearOriginObjects(ObjectsStatic);
            if (GuidanceManager.Instance.GuidanceStep == 0)
            {
                GuidanceManager.Instance.GuidanceStep = GuidanceManager.Instance.GuidanceCount - 1;
                GuidanceManager.Instance.GuidanceText.GetComponent<Text>().text = GuidanceManager.Instance.GuideSource[GuidanceManager.Instance.GuidanceCount - 1];
            }
            else
            {
                GuidanceManager.Instance.GuidanceStep -= 1;
                GuidanceManager.Instance.GuidanceText.GetComponent<Text>().text = GuidanceManager.Instance.GuideSource[GuidanceManager.Instance.GuidanceStep % GuidanceManager.Instance.GuidanceCount];
            }

            if (GuidanceManager.Instance.GuidanceStep == 0)
            {
                CreateObjects(ObjectDown, ObjectDistance, "PaoTa", ObjectsStatic);
        
            }

            if (GuidanceManager.Instance.GuidanceStep == 1)
            {
                CreateObjects(ObjectDown, ObjectDistance, "DiZuo", ObjectsStatic);
         
            }

            SetChildShow();

        }

        //维修指导返回主菜单按钮
        else if (BtnSelected == BackToMain)
        {
            ClearOriginObjects(ObjectsStatic);
            MainCanvasEnable = true;
            GuidanceCanvasEnable = false;

            for (int i = 0; i <= GuidanceManager.Instance.GuidanceCount - 1; i++)
            {
                TargetChilds[i].SetActive(true);
            }
        }

        
    }

    private void ClearOriginObjects(List<GameObject> ObjectsToClear)
    {
        if (ObjectsToClear.Count > 0)
        {
            foreach (var Originobject in ObjectsToClear)
            {
                Originobject.SetActive(false);
                DestroyImmediate(Originobject);
            }
            ObjectsToClear.Clear();
           // Resources.UnloadUnusedAssets();
        }
    }

    public GameObject CreateObjects(float down, float Forward,string ObjectName, List<GameObject> ListToAdd)
    {
      
        UnityEngine.Object ObjectVisual = Resources.Load(ObjectName, typeof(GameObject));
        GameObject ObjectReal = Instantiate(ObjectVisual, Camera.main.transform.position + Camera.main.transform.up * down + Camera.main.transform.forward * Forward, Quaternion.identity ) as GameObject;
        ListToAdd.Add(ObjectReal);
        return ObjectReal;
    }

    public IEnumerator TimeToShow()
    {
        while (true)
        {
            DT = System.DateTime.Now;
            string front = DT.ToString().Substring(0, DT.ToString().LastIndexOf(':'));
            string last = DT.ToString().Substring(DT.ToString().LastIndexOf(' '), DT.ToString().Length - DT.ToString().LastIndexOf(' '));
            TimeText.GetComponent<Text>().text = front + last;
            yield return new WaitForSeconds(1);
        }
    }

    // Update is called once per frame
    void Update ()
    {
 
       
               
    }
    */
}
