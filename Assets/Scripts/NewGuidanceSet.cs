using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using HoloToolkit.Unity;
using System.Collections.Generic;
using Vuforia;
using System;
using UnityEngine.EventSystems;

public class NewGuidanceSet : Singleton<NewGuidanceSet>
{
    public Button MoveAll;  //移动模型部分
    public Button MoveOne;  //旋转模型Z轴
    public Button MoveX;  //旋转模型X轴
    public Button ReConstruct; //重新建模
    public Button HideGuidance;
    public Button StartGuide; //开始部件认知教学
    public Button StartWelcome; //开始部件认知教学
    public Button StartNavigation; //开始部件认知教学
    public Button StartHowToUse; //开始操作使用教学
    public Button Diagnose; //开始故障诊断
    public Button MaintainGuide; //开始维修引导
    public Button MaintainToMain; //操作指导返回主界面

    public Button OpenSystem; //开启系统
    public Button CloseSystem; //开启系统

    public Button FixMaintan; 
    public Button HideMaintan;
    public Button NextStepMaintan; //操作使用的下一步
    public Button LastStepMaintan; //操作使用的上一步


    public Button NextStep;
    public Button LastStep;
    public Button BackToMain;  //部件认知返回主界面
    public Button welcomeToMain; //欢迎界面返回主界面
    public Button NavigationToMain; //欢迎界面返回主界面
    public Button HideMainMenu;

    public Button CourseToMain;
    public Button DrpButton;
    public Button GuidanceAnchor;
    public Button MainAnchor;
    public Button SetPlace; //确定放置包络面

    public float ObjectDistance; //显示物体与人眼的距离
    public float ObjectDown; //显示物体与人眼的下边距
    public bool MainHideSet;
    public bool GuidanceHideSet;
    public bool StartRecognization; //是否已经开始部件认知教学
    public bool IfMoveAll;//是否是平移，不是平移则是旋转
    public bool IfRotateZ;//是否绕Z轴旋转，不是绕Z轴则是绕X轴
    public bool IfVoiceRecog; //是否语音识别

    private bool MenuHideSet;
    public bool IfMaintainFixed;
    public bool IfMaintainHide;
    public bool IfDiagnose; //是否开始故障诊断

    public bool IfOpenSystem;
    private bool IfHitButton;
    private bool HasTbset;
    public bool IfGuidanceFix; //是否固定辅助菜单
    public bool IfMainFix; //是否固定主菜单
    public Button BtnSelected; //用户凝视的按钮
    public float RayCastLength; //按钮最大识别距离
    public LayerMask UILayerMask;

    public GameObject SwitchUp;  //向上扳动开关动画
    public List<GameObject> AnimationList; //所有动画组件

    private Vector3 uiRayCastOrigin;
    private Vector3 uiRayCastDirection;
    private Button BtnSelected_old; //记录用户之前凝视的按钮
    private Vector3 hitPos, hitNormal; //按钮位置，按钮法线方向

    private ColorBlock cb; //设置按钮的颜色

    private bool IfDataSetActive;


    void Start()
    {
        SwitchUp.SetActive(false);
       // SwitchUp.GetComponent<Animation>().Play();
        SetButton(MoveAll , Color.yellow);
        SetButton(OpenSystem, Color.yellow);
        IfOpenSystem = true;
        IfDiagnose = false;
        IfMoveAll = true;
        IfRotateZ = true;
        IfVoiceRecog = false;
        StartRecognization = false;
        AnimationList = new List<GameObject>();
        AnimationList.Add(SwitchUp);
        //  StepList = new List<List<GameObject>>();
        //  StepList.Add(StepList1);
        // StepList.Add(StepList2);
        // StepList.Add(StepList3);
        // StepList.Add(StepList4);
        //  DiZuo = Instantiate(Resources.Load<GameObject>("DiZuo"));
        //   PaoTa = Instantiate(Resources.Load<GameObject>("PaoTa"));
        //  DiZuo.SetActive(false);
        //  PaoTa.SetActive(true);
        //  PaoTa.transform.position = Camera.main.transform.position + Camera.main.transform.up * ObjectDown + Camera.main.transform.forward * ObjectDistance;
        //    PaoTa.transform.position = Camera.main.transform.position  + Camera.main.transform.forward * 1f;

        // PaoTa.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
        //   if (PaoTa.activeSelf)
        //  {
        //       Debug.Log("激活了！！！");
        //       Debug.Log("激活了！！！");
        //       Debug.Log("激活了！！！");
        //  }
        //  else
        //  {
        //      Debug.Log("没有激活了！！！");
        //      Debug.Log("没有激活了！！！");
        //      Debug.Log("没有激活了！！！");
        //   }

        IfMainFix = false;
        IfGuidanceFix = false;
    //    ObjectsStatic = new List<GameObject>();
    //    ObjectsAnimation = new List<GameObject>();
        IfHitButton = false;
        IfDataSetActive = true;
        ObjectDistance = 1f;
        ObjectDown = 0.1f;
        MainHideSet = false;
        GuidanceHideSet = false;
        MenuHideSet = true;
        HasTbset = false;
        // DrpCanvas.SetActive(false);
      //  tbs = TrackerManager.Instance.GetStateManager().GetTrackableBehaviours();
       // vb = GameObject.FindObjectOfType<VuforiaBehaviour>();
      //  vb.RegisterVuforiaStartedCallback(DynamicSet);
        Resources.UnloadUnusedAssets();

        cb = new ColorBlock();
        RayCastLength = 20f;     
      //  SetButton(IfRecognized, Color.green);  //一开始就默认开始识别
      //  PaoTa.SetActive(false);
       // DiZuo.SetActive(false);
      //  ObjectsStatic.Add(PaoTa);
      //  ObjectsStatic.Add(DiZuo);
        // MainCanvasEnable = true;
        //  GuidanceCanvasEnable = false;
        // PictureCanvasEnable = false;
        //IfWeenMove = false;
        // DistanceFromEyes = 1.2f;
        // MainCanvas.transform.localScale = new Vector3(0.002f, 0.002f, 0.002f);
        // GuidanceCanvas.transform.localScale = new Vector3(0.002f, 0.002f, 0.002f);
        // PictureCanvas.transform.localScale = new Vector3(0.002f, 0.002f, 0.002f);
        // MainCanvas.transform.position = Camera.main.transform.position + Camera.main.transform.forward * DistanceFromEyes;
        //  StartCoroutine(ChooseCanvasShow());
        // StartCoroutine(MainCanvasShow());
        //    StartCoroutine(TimeToShow());
        //    StartCoroutine(ChooseButtonShow());
       //  StartCoroutine(PlanePosition());
      //   TextPlane.transform.Rotate(-90, -20, 0);
        // TextPlane.transform.position = new Vector3 (-0.4f,-0.15f,-0.2f);
      //  TextPlane.transform.position = new Vector3(-0.5f, -0.3f, 0.2f);
      //  TextPlane.transform.localScale = new Vector3(TextPlane.transform.localScale.x* 0.7f, TextPlane.transform.localScale.y*0.7f, TextPlane.transform.localScale.z* 0.7f);
      //  TextPlane.transform .

    }




    private bool CastUI(out Vector3 hitPos, out Vector3 hitNormal, out Button hitButton /* out Dropdown HitDrp*/)
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
                        if (button != null)
                        {
                            hitPos = uiRayCastOrigin + uiRayCastDirection * canvasHits[i].distance;
                            hitNormal = canvasHits[i].gameObject.transform.forward;
                            hitButton = button;
                            return true;
                        }

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

    /*private IEnumerator ChooseButtonShow()
    {
        //按钮显示
        //while (true)
        {
            
           // yield return null;
        }
    }*/


    private IEnumerator PlanePosition()
    {
        while (true)
        {
            // if (GazeManager .Instance .FocusedObject ==TextPlane )
            //  {
            //  Debug.Log("解法iOS东方闪电");
            //  if (HasTbset == true)
         //   Debug.Log("凝视+"+GazeManager.Instance.Position);
         //   Debug.Log("凝视+" + GazeManager.Instance.Position);
         //   Debug.Log("凝视+" + GazeManager.Instance.Position);
            {
             //   foreach (TrackableBehaviour tb in tbs)
                {
               //     if (tb.TrackableName == "target1")
                    {
                        //    {
                        //       Debug.Log("已经在");
                        //      Debug.Log("已经在");
                        //      Debug.Log("已经在");
                        // tb.gameObject .transform .

                        //TextPlane.transform.SetParent(tb.gameObject.transform);
                        // TextPlane.transform.localPosition  = new Vector3(0,0,0);
                    //    TextPlane.transform.position = tb.gameObject.transform.FindChild("ChildIndex").transform.position;
                     //   TextPlane.transform.forward = Camera.main.transform.forward;
                        HasTbset = false;

                    //    Debug.Log("平面的位置是：" + TextPlane.transform.position);
                     //   Debug.Log("平面的位置是：" + TextPlane.transform.position);
                    //    Debug.Log("平面的位置是：" + TextPlane.transform.position);

                    }
                }
            }
            yield return new WaitForSeconds(1);
        }
    } 
                //     Debug.Log("已经在");
                //    Debug.Log("已经在");
                //    Debug.Log("已经在");
                //   }

                // }
         //   }
        //    yield return null;
           // Debug.Log("已经在协程");
          //  Debug.Log("已经在协程");
          //  Debug.Log("已经在协程");
         //   yield return new WaitForSeconds(2);

    //    }
 //   }

    private void DynamicSet()
    {
       // CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO); //自动对焦
       // CameraDevice.Instance.SetFlashTorchMode(true); //打开闪光灯                                                            
      //  tbs = TrackerManager.Instance.GetStateManager().GetTrackableBehaviours();
        HasTbset = true;
        if (IfDataSetActive == true)
        {

        //    for (int i = 0; i <= GuidanceManager.Instance.GuidanceCount - 1; i++)
         //   {
         //       TargetChilds[i].SetActive(true);
         //   }

         //   foreach (TrackableBehaviour tb in tbs)
            {
                // if (tb.TrackableName == "box")
                //  {
                //     ObjectTargetBehaviour otb = tb as ObjectTargetBehaviour;
                //      otb.ObjectTarget.StartExtendedTracking();
                //   }

                //if (tb.TrackableName == "stones")
               // {
              //      Debug.Log("已经在");
              //      Debug.Log("已经在");
              //      Debug.Log("已经在");
                    // tb.gameObject .transform .
              //      TextPlane.transform.forward = tb.gameObject.transform.up;
             //       // TextPlane.transform.SetParent(tb.gameObject.transform);
             //       // TextPlane.transform.localPosition  = new Vector3(0,0,0);
            //        TextPlane.transform.position = tb.gameObject.transform.FindChild("ImageChild").transform.position;
               //     tb. 
            //        Debug.Log("已经在");
            //    }
                //       if (tb.TrackableName == "stones")
                //    {
                //         TextPlane.transform.forward = tb.gameObject.transform.up;
                //          TextPlane.transform.position = new Vector3(tb.gameObject.transform.position.x, tb.gameObject.transform.position.y , tb.gameObject.transform.position.z );
                //          Debug.Log("已经在");
                //          Debug.Log("已经在");
                //           Debug.Log("已经在");

                //       }

              //  if (tb.TrackableName == "target1")
                {
                //    ImageTargetBehaviour itb2 = tb as ImageTargetBehaviour;
               //     itb2.ImageTarget.StartExtendedTracking();
                //    Transform[] AllChildren = tb.gameObject.GetComponentsInChildren<Transform>();
                 //   foreach (Transform child in AllChildren)
                    {
                        // child.gameObject.transform.localPosition  = Vector3.zero;
                 //       child.localPosition = new Vector3(child.localPosition.x, child.localPosition.y, child.localPosition.z);
                    }

                }


              //  if (tb.TrackableName == "AllMianBan")
                {

                 //   ImageTargetBehaviour itb = tb as ImageTargetBehaviour;
               //     itb.ImageTarget.StartExtendedTracking();
                //    SetChildShow();  //此时必须先动态注册？

                    /*Transform[] AllChildren = tb.gameObject.GetComponentsInChildren<Transform>();
            
                    for (int i=1;i<=AllChildren.Length-1;i++  )
                    {
                        if( i-1 == GuidanceManager.Instance.GuidanceStep)
                        {
                            AllChildren[i-1].gameObject.SetActive(true);
                            Debug.Log("Active!!!");
                            Debug.Log("Active!!!");
                            Debug.Log("Active!!!");
                        }
                        else
                        {
                            AllChildren[i-1].gameObject.SetActive(false);
                        }
                    }*/

                    /*if (GuidanceManager.Instance.GuidanceStep == 1)
                    {
                        tb.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    }
                    else
                    {
                        tb.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    }*/


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
    /*if (tb.TrackableName == "AllMianBan")
    {
        Vector3 LinePosition = tb.gameObject.transform.FindChild("One").localPosition;
        tb.gameObject.transform.FindChild("One").localPosition = new Vector3(LinePosition.x + 0.05f, LinePosition.y, LinePosition.z);
    }*/

    //扩展追踪
    //扩展追踪         
    // tb.GetComponent<ImageTarget>().StartExtendedTracking();


    /* public void SetChildShow()
     {
         // tbs = TrackerManager.Instance.GetStateManager().GetTrackableBehaviours();
         if (IfDataSetActive == true)
         {
             for (int i = 0; i <= GuidanceManager.Instance.GuidanceCount - 1; i++)
             {
                 if (i == GuidanceManager.Instance.GuidanceStep)
                 {
                     foreach (GameObject child in StepList[i])
                     {
                         child.SetActive(true);
                         Debug.Log("已经显示");
                     }
                 }
                 else
                 {
                     foreach (GameObject child in StepList[i])
                     {
                         child.SetActive(false);
                     }
                 }
             }



         }
     }*/
    
    private void SetObjectRender(GameObject ObjectToSet,bool ifset)
    {
        Transform[] AllChildren = ObjectToSet.transform.GetComponentsInChildren<Transform>();
        if (AllChildren.Length > 0)
        {
            foreach (Transform child in AllChildren)
            {
                child.gameObject.GetComponent<Renderer>().enabled = ifset;
            }
        }
    }

    private void PlayAnimation(String ani)
    {
        foreach (var Myani in AnimationList)
        {
            if (Myani.name.Equals(ani))
            {
                Myani.SetActive(true);
                //Myani.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.7f));
                Myani.transform.position = HitChildShow.Instance.TopJack.transform.position + Vector3.up * 0.2f;
                Myani.transform.localScale = new Vector3(5f, 5f, 5f);
                Myani.gameObject.GetComponent<Animation>().Play();
            }
            else
            {
                
                Myani.gameObject.GetComponent<Animation>().Stop();
                Myani.SetActive(false);
            }
        }
    }

    public void MaintainObjectShow() //显示相应步骤的方框，播放相应步骤的动画
    {
        if (IfOpenSystem == true)  // 开启系统
        {
            if (GuidanceManager.Instance.MaintainStep == 0)
            {
                SetObjectRender(HitChildShow.Instance.RightSwitch, true);
                SetObjectRender(HitChildShow.Instance.LeftSwitch , false);
                PlayAnimation("SwitchUp");
            }
            else if (GuidanceManager.Instance.MaintainStep == 1)
            {
                SetObjectRender(HitChildShow.Instance.RightSwitch, false);
                SetObjectRender(HitChildShow.Instance.LeftSwitch, false);
                //待补充
                PlayAnimation("0");
            }
            else if (GuidanceManager.Instance.MaintainStep == 2)
            {
                SetObjectRender(HitChildShow.Instance.RightSwitch, false);
                SetObjectRender(HitChildShow.Instance.LeftSwitch, true);
                PlayAnimation("SwitchUp");
            }

        }
        else //关闭系统
        {
            if (GuidanceManager.Instance.MaintainStep == 0)
            {
                SetObjectRender(HitChildShow.Instance.RightSwitch, false);
                SetObjectRender(HitChildShow.Instance.LeftSwitch, true);
                PlayAnimation("0");
            }
            else if (GuidanceManager.Instance.MaintainStep == 1)
            {
                SetObjectRender(HitChildShow.Instance.RightSwitch, false);
                SetObjectRender(HitChildShow.Instance.LeftSwitch, false);
                PlayAnimation("0");
                //待补充
            }
            else if (GuidanceManager.Instance.MaintainStep == 2)
            {
                SetObjectRender(HitChildShow.Instance.RightSwitch, true);
                SetObjectRender(HitChildShow.Instance.LeftSwitch, false);
                PlayAnimation("0");
            }
        }
    }

    public void SetButtonClicked() //点击按钮的响应事件
    {
        if( BtnSelected == MoveAll )//平移
        {
            IfMoveAll = true;
            IfRotateZ = false;
            SetButton(MoveAll, Color.yellow);
            SetButton(MoveOne, Color.cyan);
            SetButton(MoveX, Color.cyan);
        }

        else if( BtnSelected ==MoveOne )//Z轴旋转
        {
            IfMoveAll = false;
            IfRotateZ = true;
            SetButton(MoveOne, Color.yellow);
            SetButton(MoveAll, Color.cyan);
            SetButton(MoveX, Color.cyan);
        }

        else if (BtnSelected == MoveX)//X轴旋转
        {
            IfMoveAll = false;
            IfRotateZ = false;
            SetButton(MoveX, Color.yellow);
            SetButton(MoveAll, Color.cyan);
            SetButton(MoveOne, Color.cyan);
        }

        //用户选择重新建模
        else if (BtnSelected == ReConstruct)
        {
            if (HitChildShow.Instance.IfCoverSet == true)
            {
                //  HitChildShow.Instance.TextPlane.transform.position = LastHitPosition;
                HitChildShow.Instance.IfCoverSet = false;
                SetCanvas.Instance.PlaceCanvas.SetActive(true);
                SetCanvas.Instance.MainCanvasEnable = false;
                SetCanvas.Instance.GuidanceCanvasEnable = false;
                SetCanvas.Instance.WelcomeCanvasEnable = false;
                SetCanvas.Instance.NavigationCanvasEnable = false;
                SetCanvas.Instance.PictureCanvasEnable = false;

                Transform[] AllChildren = HitChildShow.Instance.TextPlane.GetComponentsInChildren<Transform>();
                foreach (Transform child in AllChildren)
                {
                   child.gameObject.GetComponent<Renderer>().enabled = true;
                  //  child.gameObject.GetComponent<MeshRenderer>().material = DefaultMaterial;
                }
            }
        }

        //用户确定包络面
        else if (BtnSelected == SetPlace )
        {
             if (HitChildShow.Instance.IfCoverSet == false)
             {
               //  HitChildShow.Instance.TextPlane.transform.position = LastHitPosition;
                 HitChildShow.Instance.IfCoverSet = true;
                 SetCanvas.Instance.PlaceCanvas.SetActive(false);
                 SetCanvas.Instance.MainCanvasEnable = true;
                 SetCanvas.Instance.GuidanceCanvasEnable = false;
                 SetCanvas.Instance.PictureCanvasEnable = false;

                Transform[] AllChildren = HitChildShow.Instance.TextPlane.GetComponentsInChildren<Transform>();
                foreach (Transform child in AllChildren)
                {
                      child.gameObject.GetComponent<Renderer>().enabled = false;
                  //  child.gameObject.GetComponent<MeshRenderer>().material = FontMaterial;
                }
            }
        }

        //用户点击下拉菜单
        else if (BtnSelected == DrpButton)
        {
            if (!MenuHideSet)
            {
                SetCanvas.Instance.DrpCanvas.SetActive(true);
                MenuHideSet = true;
            }
            else
            {
                SetCanvas.Instance.DrpCanvas.SetActive(true);
                MenuHideSet = true;
            }
        }

        //隐藏维修菜单
        else if (BtnSelected == HideMaintan ) 
        {
            IfMaintainHide  = true;
            SetCanvas.Instance.MainCanvasEnable = false;
            SetCanvas.Instance.GuidanceCanvasEnable = false;
            SetCanvas.Instance.PictureCanvasEnable = false;
        }

        //隐藏主菜单按钮
        else if (BtnSelected == HideMainMenu)
        {

            MainHideSet = true;
            SetCanvas.Instance.MainCanvasEnable = false;
            SetCanvas.Instance.GuidanceCanvasEnable = false;
        }

        //固定维修菜单
        else if (BtnSelected == FixMaintan) 
        {
            IfMaintainFixed = !IfMaintainFixed;
            if (IfMaintainFixed == true)
            {
                BtnSelected.transform.GetChild(0).GetComponent<Text>().text = "已固定";
                SetButton(BtnSelected, Color.yellow);
            }
            else
            {
                BtnSelected.transform.GetChild(0).GetComponent<Text>().text = "固定";
                SetButton(BtnSelected, Color.cyan);
            }
        }

        //操作使用 或 故障诊断 返回主界面
        else if (BtnSelected == MaintainToMain ) 
        {
            SetCanvas.Instance.GuidanceCanvasEnable = false;
            SetCanvas.Instance.PictureCanvasEnable = false;
            SetCanvas.Instance.MainCanvasEnable = true;
            IfDiagnose = false; //关闭故障诊断功能
            IfVoiceRecog = false; //关闭语音识别功能
            Transform[] AllChildren = HitChildShow.Instance.TextPlane.GetComponentsInChildren<Transform>();
            foreach (Transform child in AllChildren)
            {
                child.gameObject.GetComponent<Renderer>().enabled = false;
            }
        
            PlayAnimation("");
        }


        //固定指导菜单
        else if (BtnSelected == GuidanceAnchor)
        {

            IfGuidanceFix = !IfGuidanceFix;

            if (IfGuidanceFix == true)
            {
                BtnSelected.transform.GetChild(0).GetComponent<Text>().text = "已固定";
                SetButton(BtnSelected, Color.yellow);
            }
            else
            {
                BtnSelected.transform.GetChild(0).GetComponent<Text>().text = "固定";
                SetButton(BtnSelected, Color.cyan);
            }

        }

        //固定主菜单
        else if (BtnSelected == MainAnchor)
        {

            IfMainFix = !IfMainFix;

            if (IfMainFix == true)
            {
                BtnSelected.transform.GetChild(0).GetComponent<Text>().text = "已固定";
                SetButton(BtnSelected, Color.yellow);
            }
            else
            {
                BtnSelected.transform.GetChild(0).GetComponent<Text>().text = "固定";
                SetButton(BtnSelected, Color.cyan);
            }

        }

 

        //教程按钮
        /*  else if (BtnSelected == Course)
          {

              SetCanvas.Instance.MainCanvasEnable = false;

              // 显示教程图片
              SetCanvas.Instance.PictureCanvasEnable = true;

              GameObject ObjectShowed = CreateObjects(0, 2, "MeTank", ObjectsAnimation);
              GameObject Child1 = ObjectShowed.transform.FindChild("Tower").gameObject;
              GameObject Child2 = ObjectShowed.transform.FindChild("Body").gameObject;
             // Child1.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
             // Child2.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

              //开启协程
              Teacher1 = Manipulation.Instance.move(Child1, Child1.transform.position, 0.05f, Time.time, Time.time, 3, 10, Manipulation.Operation.forward);
              Teacher2 = Manipulation.Instance.move(Child2, Child2.transform.position, 0.05f, Time.time, Time.time, 3, 10, Manipulation.Operation.down);
              StartCoroutine(Teacher1);
              StartCoroutine(Teacher2);

          }*/
        
        //开始操作使用教程
        else if (BtnSelected == StartHowToUse)
        {
      
            GuidanceManager.Instance.MaintainTitle.GetComponent<Text>().text = "59坦克\r\n" + "炮控系统使用";
            OpenSystem.transform.GetChild(0).GetComponent<Text>().text = "开启系统";
            CloseSystem.transform.GetChild(0).GetComponent<Text>().text = "关闭系统";
            SetCanvas.Instance.MainCanvasEnable = false;
            // 显示操作使用或故障诊断界面
            NextStepMaintan.gameObject.SetActive(true);
            LastStepMaintan.gameObject.SetActive(true);
            SetCanvas.Instance.PictureCanvasEnable = true;
            SetButton(OpenSystem, Color.yellow);
            SetButton(CloseSystem, Color.cyan);
            IfVoiceRecog = true; //开启语音识别功能
            IfOpenSystem = true; //按步骤指导开启系统
            MaintainObjectShow();
        }

        //开启系统或开关诊断
        else if (BtnSelected == OpenSystem ) 
        {
            
            if (IfDiagnose == false) //开启系统
            {
                IfOpenSystem = true;
                SetButton(OpenSystem, Color.yellow);
                SetButton(CloseSystem, Color.cyan);
                MaintainObjectShow();
                GuidanceManager.Instance.MaintanGuidanceText.GetComponent<Text>().text = GuidanceManager.Instance.MaintainOpenSource[GuidanceManager.Instance.MaintainStep];
            }
            else //开关诊断
            {
                IfOpenSystem = true;
                SetButton(OpenSystem, Color.yellow);
                SetButton(CloseSystem, Color.cyan);
              //  MaintainObjectShow();
                GuidanceManager.Instance.MaintanGuidanceText.GetComponent<Text>().text = "操作步骤：\r\n"+"1、逐个打开操纵台上所有开关\r\n"+"2、分别按下操纵台上两个按钮";
            }
         }

        //关闭系统或滑环诊断
        else if (BtnSelected == CloseSystem) 
        {
            if (IfDiagnose == false) //关闭系统
            {
                IfOpenSystem = false;
                SetButton(OpenSystem, Color.cyan);
                SetButton(CloseSystem, Color.yellow);
                MaintainObjectShow();
                GuidanceManager.Instance.MaintanGuidanceText.GetComponent<Text>().text = GuidanceManager.Instance.MaintainCloseSource[GuidanceManager.Instance.MaintainStep];
            }
            else //滑环诊断
            {
                IfOpenSystem = false;
                SetButton(OpenSystem, Color.cyan);
                SetButton(CloseSystem, Color.yellow);
               // MaintainObjectShow();
                GuidanceManager.Instance.MaintanGuidanceText.GetComponent<Text>().text = "操作步骤：\r\n" + "1、缓慢旋转操纵台手柄，先向左旋转到底，再向右旋转到底\r\n" + "2、缓慢旋转操纵台手柄，先向上旋转到底，再向下旋转到底";
            }
        }

        //故障诊断
        else if (BtnSelected == Diagnose)
        {
            IfDiagnose = true;
            NextStepMaintan.gameObject.SetActive(false);
            LastStepMaintan.gameObject.SetActive(false);
            SetButton(OpenSystem, Color.yellow);
            SetButton(CloseSystem, Color.cyan );
            GuidanceManager.Instance.MaintainTitle.GetComponent<Text>().text = "59坦克操纵台\r\n" + "故障诊断";
            OpenSystem.transform.GetChild(0).GetComponent<Text>().text = "开关按钮诊断";
            CloseSystem.transform.GetChild(0).GetComponent<Text>().text = "滑环诊断";
            GuidanceManager.Instance.MaintanGuidanceText.GetComponent<Text>().text = "操作步骤：\r\n" + "1、逐个打开操纵台上所有开关\r\n" + "2、分别按下操纵台上两个按钮";
            SetCanvas.Instance.MainCanvasEnable = false;
            SetCanvas.Instance.GuidanceCanvasEnable = false;
            SetCanvas.Instance.PictureCanvasEnable = true;
        }

        //隐藏维修菜单按钮
        else if (BtnSelected == HideGuidance)
        {
            GuidanceHideSet = true;

            SetCanvas.Instance.MainCanvasEnable = false;
            SetCanvas.Instance.GuidanceCanvasEnable = false;
            SetCanvas.Instance.PictureCanvasEnable = false;
        }


        //教程返回主菜单按钮
        else if (BtnSelected == CourseToMain)
        {
            SetCanvas.Instance.GuidanceCanvasEnable = false;
            SetCanvas.Instance.PictureCanvasEnable = false;
            SetCanvas.Instance.MainCanvasEnable = true;


        }


        //开始部件认知
        else if (BtnSelected == StartGuide)
        {
     
            StartRecognization = true;
            SetCanvas.Instance.MainCanvasEnable = false;
            SetCanvas.Instance.PictureCanvasEnable = false;
            SetCanvas.Instance.GuidanceCanvasEnable = true;
            NextStep.gameObject.SetActive(false);  //   = false;
            LastStep.gameObject.SetActive(false);  // = false;

        }

            //开始欢迎界面
        else if (BtnSelected == StartWelcome)
        {

            StartRecognization = true;
            SetCanvas.Instance.MainCanvasEnable = false;
            SetCanvas.Instance.PictureCanvasEnable = false;
            SetCanvas.Instance.WelcomeCanvasEnable = true;
            IfGuidanceFix = false;
            NextStep.gameObject.SetActive(false);  //   = false;
            LastStep.gameObject.SetActive(false);  // = false;

        }

//开始导航界面
        else if (BtnSelected == StartNavigation)
        {

            StartRecognization = true;
            SetCanvas.Instance.MainCanvasEnable = false;
            SetCanvas.Instance.PictureCanvasEnable = false;
            SetCanvas.Instance.WelcomeCanvasEnable = false;
            SetCanvas.Instance.NavigationCanvasEnable = true;
            IfGuidanceFix = false;
            NextStep.gameObject.SetActive(false);  //   = false;
            LastStep.gameObject.SetActive(false);  // = false;

        }

        //下一步按钮
        else if (BtnSelected == NextStepMaintan)
        {
       
            GuidanceManager.Instance.MaintainStep  += 1;
            GuidanceManager.Instance.MaintainStep = GuidanceManager.Instance.MaintainStep % GuidanceManager.Instance.MaintainCount ;    
            if (IfOpenSystem == true)
            {
                GuidanceManager.Instance.MaintanGuidanceText.GetComponent<Text>().text = GuidanceManager.Instance.MaintainOpenSource[GuidanceManager.Instance.MaintainStep];
            }
            else
            {
                GuidanceManager.Instance.MaintanGuidanceText.GetComponent<Text>().text = GuidanceManager.Instance.MaintainCloseSource[GuidanceManager.Instance.MaintainStep];
            }

            MaintainObjectShow();

        }

        //上一步按钮
        else if (BtnSelected == LastStepMaintan)
        {
          //  ClearOriginObjects(ObjectsStatic);
            if (GuidanceManager.Instance.MaintainStep == 0)
            {
                GuidanceManager.Instance.MaintainStep = GuidanceManager.Instance.MaintainCount - 1;
                if (IfOpenSystem == true)
                {
                    GuidanceManager.Instance.MaintanGuidanceText.GetComponent<Text>().text = GuidanceManager.Instance.MaintainOpenSource[GuidanceManager.Instance.MaintainCount - 1];
                }
                else
                {
                    GuidanceManager.Instance.MaintanGuidanceText.GetComponent<Text>().text = GuidanceManager.Instance.MaintainCloseSource[GuidanceManager.Instance.MaintainCount - 1];
                }

            }
            else
            {
                GuidanceManager.Instance.MaintainStep -= 1;
                if (IfOpenSystem == true)
                {
                    GuidanceManager.Instance.MaintanGuidanceText.GetComponent<Text>().text = GuidanceManager.Instance.MaintainOpenSource[GuidanceManager.Instance.MaintainStep];
                }
                else
                {
                    GuidanceManager.Instance.MaintanGuidanceText.GetComponent<Text>().text = GuidanceManager.Instance.MaintainCloseSource[GuidanceManager.Instance.MaintainStep];
                }
            }
            MaintainObjectShow();



        }

        //部件认知返回主菜单按钮
        else if (BtnSelected == BackToMain)
        {


            LastStep.gameObject.SetActive(true);
            NextStep.gameObject.SetActive(true);
            //ClearOriginObjects(ObjectsStatic);
            SetCanvas.Instance.MainCanvasEnable = true;
            SetCanvas.Instance.GuidanceCanvasEnable = false;
            StartRecognization = false;
            foreach (var ObjectShow in HitChildShow .Instance .ObjectsToSelected )
            {
                ObjectShow.SetActive(false);
            }



        }
            //欢迎界面返回主菜单
        else if (BtnSelected == welcomeToMain)
        {


            LastStep.gameObject.SetActive(true);
            NextStep.gameObject.SetActive(true);
            //ClearOriginObjects(ObjectsStatic);
            SetCanvas.Instance.MainCanvasEnable = true;
            SetCanvas.Instance.WelcomeCanvasEnable = false;
            StartRecognization = false;
            foreach (var ObjectShow in HitChildShow.Instance.ObjectsToSelected)
            {
                ObjectShow.SetActive(false);
            }



        }
        //导航界面返回欢迎界面
        else if (BtnSelected == NavigationToMain)
        {


            LastStep.gameObject.SetActive(true);
            NextStep.gameObject.SetActive(true);
            //ClearOriginObjects(ObjectsStatic);
            SetCanvas.Instance.WelcomeCanvasEnable = true;
            SetCanvas.Instance.NavigationCanvasEnable = false;
            StartRecognization = false;
            foreach (var ObjectShow in HitChildShow.Instance.ObjectsToSelected)
            {
                ObjectShow.SetActive(false);
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
            Resources.UnloadUnusedAssets();
        }
    }



    private void SetButton(Button btn, Color color)
    {

        cb.normalColor = color;
        cb.highlightedColor = color;
        cb.pressedColor = color;
        cb.disabledColor = color;
        cb.colorMultiplier = 1;
        cb.fadeDuration = 0.1f;
        btn.colors = cb;
    }


    // Update is called once per frame
    void Update()
    {
        if (CastUI(out hitPos, out hitNormal, out BtnSelected /* out DrpSelected*/ ) && BtnSelected != null)
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
                if ((BtnSelected_old == GuidanceAnchor && IfGuidanceFix == true) || (BtnSelected_old == MainAnchor && IfMainFix == true))
                    SetButton(BtnSelected_old, Color.yellow);

                else if (BtnSelected_old == MoveAll && IfMoveAll == true)
                {
                    SetButton(BtnSelected_old, Color.yellow);
                }
                else if (BtnSelected_old == MoveOne && IfMoveAll == false && IfRotateZ == true)
                {
                    SetButton(BtnSelected_old, Color.yellow);
                }
                else if (BtnSelected_old == MoveX && IfMoveAll == false && IfRotateZ == false)
                {
                    SetButton(BtnSelected_old, Color.yellow);
                }
                else if(BtnSelected_old == OpenSystem  && IfOpenSystem  == true)
                {
                    SetButton(BtnSelected_old, Color.yellow);
                }
                else if(BtnSelected_old == CloseSystem && IfOpenSystem == false)
                {
                    SetButton(BtnSelected_old, Color.yellow);
                }
                else if (BtnSelected_old == FixMaintan  && IfMaintainFixed  == true)
                {
                    SetButton(BtnSelected_old, Color.yellow);
                }
                else
                    SetButton(BtnSelected_old, Color.cyan);
            }
        }


    }
}

