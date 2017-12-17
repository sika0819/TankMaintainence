using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using HoloToolkit.Unity;
using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class SetCanvas : Singleton<SetCanvas>
{


 //   private Vector3 uiRayCastOrigin;
  //  private Vector3 uiRayCastDirection;
   // private Button BtnSelected_old; //记录用户之前凝视的按钮
   // private Vector3 hitPos, hitNormal; //按钮位置，按钮法线方向
   // public Button BtnSelected; //用户凝视的按钮
   // public float RayCastLength; //按钮最大识别距离
   // public LayerMask UILayerMask;
    private float MoveSpeed;
    private DateTime DT; //当前系统时间
    // Use this for initialization
   // private bool IfHitButton;
   // private bool IfGuidanceFix; //是否固定辅助菜单
   // private bool IfMainFix; //是否固定主菜单
    public GameObject MainCanvas;
    public GameObject GuidanceCanvas;
    public GameObject WelcomeCanvas;
    public GameObject NavigationCanvas;
    public GameObject PictureCanvas;
    public GameObject DrpCanvas;
    public GameObject PlaceCanvas;
    //public GameObject testCanvas;

    public GameObject TimeText;//系统时间显示窗口（Text)
    private Vector3 CurrentCamPos; //相机当前位置
    private Vector3 CurrentCamRot; //相机当前旋转角度
   // private ColorBlock cb; //设置按钮的颜色
    private float DistanceFromEyes; //界面离眼睛的距离
    private bool IfWeenMove;
    public bool MainCanvasEnable;
    public bool GuidanceCanvasEnable;
    public bool WelcomeCanvasEnable;
    public bool NavigationCanvasEnable;
    public bool PictureCanvasEnable;

    void Start () {

        //  IfMainFix = false;
        //  IfGuidanceFix = false;
        //  ObjectsStatic = new List<GameObject>();
        //   ObjectsAnimation = new List<GameObject>();
        //   IfHitButton = false;
        //  IfDataSetActive = true;
        //   ObjectDistance = 1;
        //  ObjectDown = 0.1f;
        //  MainHideSet = false;
        //  GuidanceHideSet = false;
        //   MenuHideSet = false;
        MoveSpeed = 0.1f;
        DrpCanvas.SetActive(false);
      //  vb = GameObject.FindObjectOfType<VuforiaBehaviour>();
     //   vb.RegisterVuforiaStartedCallback(DynamicSet);
        Resources.UnloadUnusedAssets();
      //  cb = new ColorBlock();
      //  RayCastLength = 20f;
        MainCanvasEnable = false;
        GuidanceCanvasEnable = false;
        WelcomeCanvasEnable = false;
        NavigationCanvasEnable = false;
        PictureCanvasEnable = false;
        IfWeenMove = false;
        DistanceFromEyes = 1.2f;
        MainCanvas.transform.localScale = new Vector3(0.002f, 0.002f, 0.002f);
        GuidanceCanvas.transform.localScale = new Vector3(0.002f, 0.002f, 0.002f);
        WelcomeCanvas.transform.localScale = new Vector3(0.002f, 0.002f, 0.002f);
        NavigationCanvas.transform.localScale = new Vector3(0.002f, 0.002f, 0.002f);
        PictureCanvas.transform.localScale = new Vector3(0.002f, 0.002f, 0.002f);
        PlaceCanvas.transform.localScale = new Vector3(0.002f, 0.002f, 0.002f);
        //testCanvas.transform.localScale = new Vector3(0.002f, 0.002f, 0.002f);

        PlaceCanvas.transform.position = Camera.main.transform.position + Camera.main.transform.forward * DistanceFromEyes;
        PlaceCanvas.transform.forward = Camera.main.transform.forward;
        //   GuidanceCanvas.transform.position = Camera.main.transform.position + Camera.main.transform.forward * DistanceFromEyes;
        StartCoroutine(ChooseCanvasShow());
        StartCoroutine(TimeToShow());

        // StartCoroutine(MainCanvasShow());
    }


   

    public IEnumerator ChooseCanvasShow()
    {
        while (true)
        {
        
            //指导菜单显示
            if (!GuidanceCanvasEnable)
            {
                GuidanceCanvas.SetActive(false);

               // if(TimeToShow.)
              //  StopCoroutine(TimeToShow());
            }

            else if (GuidanceCanvasEnable)
            {
                PictureCanvas.SetActive(false);
                MainCanvas.SetActive(false);
               // StartCoroutine(TimeToShow());

                if (!GuidanceCanvas.activeSelf)
                {
                    GuidanceCanvas.SetActive(true);
                }

                if (GazeManager.Instance.FocusedObject != GuidanceCanvas && !NewGuidanceSet.Instance.IfGuidanceFix ) //&& NewBasicCursor.Instance.IfHit == true)
                {

                    yield return new WaitForSeconds(MoveSpeed);
                    if (GazeManager.Instance.FocusedObject != GuidanceCanvas && !NewGuidanceSet.Instance.IfGuidanceFix )//&& NewBasicCursor.Instance.IfHit == true)
                    {
                        CurrentCamPos = Camera.main.transform.position + Camera.main.transform.forward * DistanceFromEyes;
                        CurrentCamRot = Camera.main.transform.rotation.eulerAngles;

                        if (IfWeenMove == false)
                        {
                           // if (GazeManager.Instance.Hit || NewBasicCursor.Instance.NotHit)
                          //  if(NewBasicCursor .Instance .IfHit == true)
                            {
                                IfWeenMove = true;
                             //   Debug.Log("在移动");
                                iTween.MoveTo(GuidanceCanvas, CurrentCamPos, MoveSpeed);
                                iTween.RotateTo(GuidanceCanvas, CurrentCamRot, MoveSpeed);
                                yield return new WaitForSeconds(1f);
                                IfWeenMove = false;
                            }
                        }
                    }

                }
            }

            // yield return null;


            //欢迎菜单显示
            if (!WelcomeCanvasEnable)
            {
                WelcomeCanvas.SetActive(false);

                // if(TimeToShow.)
                //  StopCoroutine(TimeToShow());
            }

            else if (WelcomeCanvasEnable)
            {
                PictureCanvas.SetActive(false);
                MainCanvas.SetActive(false);
                GuidanceCanvas.SetActive(false);
                // StartCoroutine(TimeToShow());

                if (!WelcomeCanvas.activeSelf)
                {
                    WelcomeCanvas.SetActive(true);
                }

                if (GazeManager.Instance.FocusedObject != WelcomeCanvas) //&& NewBasicCursor.Instance.IfHit == true)
                {

                    yield return new WaitForSeconds(MoveSpeed);
                    if (GazeManager.Instance.FocusedObject != WelcomeCanvas)//&& NewBasicCursor.Instance.IfHit == true)
                    {
                        CurrentCamPos = Camera.main.transform.position + Camera.main.transform.forward * DistanceFromEyes;
                        CurrentCamRot = Camera.main.transform.rotation.eulerAngles;

                        if (IfWeenMove == false)
                        {
                            // if (GazeManager.Instance.Hit || NewBasicCursor.Instance.NotHit)
                            //  if(NewBasicCursor .Instance .IfHit == true)
                            {
                                IfWeenMove = true;
                                //   Debug.Log("在移动");
                                iTween.MoveTo(WelcomeCanvas, CurrentCamPos, MoveSpeed);
                                iTween.RotateTo(WelcomeCanvas, CurrentCamRot, MoveSpeed);
                                yield return new WaitForSeconds(1f);
                                IfWeenMove = false;
                            }
                        }
                    }

                }
            }


            //导航菜单显示
            if (!NavigationCanvasEnable)
            {
                NavigationCanvas.SetActive(false);

                // if(TimeToShow.)
                //  StopCoroutine(TimeToShow());
            }

            else if (NavigationCanvasEnable)
            {
                PictureCanvas.SetActive(false);
                MainCanvas.SetActive(false);
                GuidanceCanvas.SetActive(false);
                // StartCoroutine(TimeToShow());

                if (!NavigationCanvas.activeSelf)
                {
                    NavigationCanvas.SetActive(true);
                }

                if (GazeManager.Instance.FocusedObject != NavigationCanvas) //&& NewBasicCursor.Instance.IfHit == true)
                {

                    yield return new WaitForSeconds(MoveSpeed);
                    if (GazeManager.Instance.FocusedObject != NavigationCanvas)//&& NewBasicCursor.Instance.IfHit == true)
                    {
                        CurrentCamPos = Camera.main.transform.position + Camera.main.transform.forward * DistanceFromEyes;
                        CurrentCamRot = Camera.main.transform.rotation.eulerAngles;

                        if (IfWeenMove == false)
                        {
                            // if (GazeManager.Instance.Hit || NewBasicCursor.Instance.NotHit)
                            //  if(NewBasicCursor .Instance .IfHit == true)
                            {
                                IfWeenMove = true;
                                //   Debug.Log("在移动");
                                iTween.MoveTo(NavigationCanvas, CurrentCamPos, MoveSpeed);
                                iTween.RotateTo(NavigationCanvas, CurrentCamRot, MoveSpeed);
                                yield return new WaitForSeconds(1f);
                                IfWeenMove = false;
                            }
                        }
                    }

                }
            }

            //操作使用界面显示
            if (!PictureCanvasEnable)
            {
                PictureCanvas.SetActive(false);
            }

            else if (PictureCanvasEnable)
            {
                GuidanceCanvas.SetActive(false);
                WelcomeCanvas.SetActive(false);
                MainCanvas.SetActive(false);
                if (!PictureCanvas.activeSelf)
                {
                    PictureCanvas.SetActive(true);
                }

                if (GazeManager.Instance.FocusedObject != PictureCanvas && !NewGuidanceSet.Instance.IfMaintainFixed)
                {
                    yield return new WaitForSeconds(MoveSpeed);
                    if (GazeManager.Instance.FocusedObject != PictureCanvas && !NewGuidanceSet .Instance .IfMaintainFixed   )//&& !NewGuidanceSet.Instance.IfGuidanceFix )
                    {
                        CurrentCamPos = Camera.main.transform.position + Camera.main.transform.forward * DistanceFromEyes;
                        CurrentCamRot = Camera.main.transform.rotation.eulerAngles;
                        if (IfWeenMove == false)
                        {
                            //if (GazeManager.Instance.Hit || NewBasicCursor.Instance.NotHit)
                            {
                                IfWeenMove = true;
                                iTween.MoveTo(PictureCanvas, CurrentCamPos, MoveSpeed);
                                iTween.RotateTo(PictureCanvas, CurrentCamRot, MoveSpeed);
                                yield return new WaitForSeconds(1f);
                                IfWeenMove = false;
                            }
                        }
                    }
                }
            }

            // yield return null;

            //主菜单显示
            if (!MainCanvasEnable)
            {
                MainCanvas.SetActive(false);
            }

            else if (MainCanvasEnable)
            {
                GuidanceCanvas.SetActive(false);
                WelcomeCanvas.SetActive(false);
                PictureCanvas.SetActive(false);
                if (!MainCanvas.activeSelf)
                {
                    MainCanvas.SetActive(true);
                    SetCanvas.Instance.DrpCanvas.SetActive(true);
                }
      
                if ((GazeManager.Instance.FocusedObject != MainCanvas) && (GazeManager.Instance.FocusedObject != DrpCanvas) && !NewGuidanceSet.Instance.IfMainFix)
                {
 
                    yield return new WaitForSeconds(MoveSpeed);
                    if ((GazeManager.Instance.FocusedObject != MainCanvas) && (GazeManager.Instance.FocusedObject != DrpCanvas) && !NewGuidanceSet.Instance.IfMainFix)
                    {
                        CurrentCamPos = Camera.main.transform.position + Camera.main.transform.forward * DistanceFromEyes;
                        CurrentCamRot = Camera.main.transform.rotation.eulerAngles;

                        if (IfWeenMove == false)
                        {
                            IfWeenMove = true;
                            iTween.MoveTo(MainCanvas, CurrentCamPos, MoveSpeed);
                            iTween.RotateTo(MainCanvas, CurrentCamRot, MoveSpeed);
                            yield return new WaitForSeconds(1f);
                            IfWeenMove = false;

                        }
                    }
                }
            }

            yield return null;
        }
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
    void Update () {
	
	}
}
