using UnityEngine;
using System.Collections;
using HoloToolkit.Unity;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class Initialization : Singleton<Initialization>
{
    
    public GameObject MainCanvas;
    public GameObject GuidanceCanvas;
    public GameObject PictureCanvas;
    public GameObject DrpCanvas;
    public bool MainCanvasEnable ;
    public bool GuidanceCanvasEnable ;
    public bool PictureCanvasEnable;
    public bool IfHitButton = false;
  //  public Dropdown DrpSelected; //用户凝视的下拉菜单
    public Button BtnSelected; //用户凝视的按钮

    public float RayCastLength = 20f; //按钮最大识别距离
    public LayerMask UILayerMask;
    // public Button btn;
   // private Vector3 hitPos, hitNormal;
    private Vector3 uiRayCastOrigin;
    private Vector3 uiRayCastDirection;
    //  private Dropdown DrpSelected_old; //记录用户之前凝视的下拉菜单
    private Button BtnSelected_old; //记录用户之前凝视的按钮
    private Vector3 hitPos, hitNormal; //按钮位置，按钮法线方向
    private Vector3 CurrentCamPos; //相机当前位置
    private Vector3 CurrentCamRot; //相机当前旋转角度
    private ColorBlock cb; //设置按钮的颜色
    private float DistanceFromEyes; //界面离眼睛的距离
    private bool IfWeenMove;
    // Use this for initialization
    void Start ()
    {
        cb = new ColorBlock();
        RayCastLength = 20f;
       // DrpCanvas.SetActive(false); 
        MainCanvasEnable = false;
        GuidanceCanvasEnable = true;
        PictureCanvasEnable = false;
        IfWeenMove = false;
        //MainCanvas.transform.position = Camera.main.transform.position + Camera.main.transform.forward * DistanceFromEyes;
        DistanceFromEyes = 1.2f;
        MainCanvas.transform.localScale = new Vector3(0.002f,0.002f,0.002f) ;
        GuidanceCanvas.transform.localScale = new Vector3(0.002f, 0.002f, 0.002f);
        PictureCanvas.transform.localScale = new Vector3(0.002f, 0.002f, 0.002f);
        MainCanvas.transform.position = Camera.main.transform.position + Camera.main.transform.forward * DistanceFromEyes;
        StartCoroutine(ChooseCanvasShow());
    }

    private void SetButton(Button btn, Color color)
    {
        //ColorBlock cb = new ColorBlock();
        cb.normalColor = color;
        cb.highlightedColor = Color.white;
        cb.pressedColor = Color.white;
        cb.disabledColor = Color.white;
        cb.colorMultiplier = 1;
        cb.fadeDuration = 0.1f;
        btn.colors = cb;
    }

    private bool CastUI(out Vector3 hitPos, out Vector3 hitNormal, out Button hitButton /* out Dropdown HitDrp*/)
    {
        // Defaults
        hitPos = Vector3.zero;
        hitNormal = Vector3.zero;
        hitButton = null; //提前赋值为空
                          // HitDrp = null;

        // Do the raycast
        RaycastHit hitInfo;

        uiRayCastOrigin = Camera.main.transform.position;
        uiRayCastDirection = Camera.main.transform.forward;
        if (Physics.Raycast(uiRayCastOrigin, uiRayCastDirection, out hitInfo, RayCastLength, UILayerMask))
        {
            // Debug.Log("hit !!!");
            // Canvas canvas = hitInfo.collider.gameObject.GetComponent<Canvas>();
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
                            Debug.Log("碰撞到了按钮！！！");
                            return true;
                        }

                        /* if (dropdown != null)
                         {
                             hitPos = uiRayCastOrigin + uiRayCastDirection * canvasHits[i].distance;
                             hitNormal = canvasHits[i].gameObject.transform.forward;
                             HitDrp  = dropdown;
                             return true;
                         }*/
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

    #region UpdateCavans
    private void UpdateCavans()
    {
        //如果选择了Button
        if (CastUI(out hitPos, out hitNormal, out BtnSelected /* out DrpSelected*/ )&& BtnSelected!=null)
        {
            if (IfHitButton == false)
            {          
                BtnSelected_old = BtnSelected;
                IfHitButton = true;
                SetButton(BtnSelected, Color.green);
            }
       
        }
        else if(BtnSelected==null)
        {                
            if (BtnSelected_old != null && IfHitButton == true)
            {     
                IfHitButton = false;
                SetButton(BtnSelected_old, Color.white);
            }
        }

        //如果选择了DropDown
        /*if (RayCastUI.Instance.CastUI(out hitPos, out hitNormal, out BtnSelected, out DrpSelected) && DrpSelected != null)
        {
            if (IfHitButton == false)
            {
                DrpSelected_old = DrpSelected;
                IfHitButton = true;
                RayCastUI.Instance.SetDrp(DrpSelected, Color.green);
            }

        }
        else if(DrpSelected==null)
        {
            if (DrpSelected_old != null && IfHitButton == true)
            {
                IfHitButton = false;
                RayCastUI.Instance.SetDrp(DrpSelected_old, Color.white);
            }
        }*/


        /*if (MainCanvasEnable)
        {
            if (!MainCanvas.activeSelf)
            {
                MainCanvas.SetActive(true);
            }
                 
            if (GazeManager.Instance.FocusedObject != MainCanvas)
            {
                //if Mathf.Abs(MainCanvas.transform.position.x - Camera.main.transform.forward.x) > 0.1)
                
                    CurrentCam = Camera.main.transform.position + Camera.main.transform.forward * 2f;
                    MainCanvas.transform.position = Vector3.Slerp(MainCanvas.transform.position, CurrentCam, 0.06f);
                    MainCanvas.transform.forward = Camera.main.transform.forward;
                
            }
        }
        else if(MainCanvas.activeSelf)
        {
            MainCanvas.SetActive(false);
        }*/


        if (GuidanceCanvasEnable)
        {
            if (!GuidanceCanvas.activeSelf)
            {
                GuidanceCanvas.SetActive(true);
            }
           
            if (GazeManager.Instance.FocusedObject != GuidanceCanvas)
            {
                CurrentCamPos = Camera.main.transform.position + Camera.main.transform.forward * DistanceFromEyes;
                GuidanceCanvas.transform.position = Vector3.Slerp(GuidanceCanvas.transform.position, CurrentCamPos, 0.06f);
                GuidanceCanvas.transform.forward = Camera.main.transform.forward;
            }
        }
        else if(GuidanceCanvas.activeSelf)
        {
            GuidanceCanvas.SetActive(false);
        }


        if (PictureCanvasEnable)
        {
            if (!PictureCanvas.activeSelf)
            {
                PictureCanvas.SetActive(true);
            }

            if (GazeManager.Instance.FocusedObject != PictureCanvas)
            {
                CurrentCamPos = Camera.main.transform.position + Camera.main.transform.forward * DistanceFromEyes;
                PictureCanvas.transform.position = Vector3.Slerp(PictureCanvas.transform.position, CurrentCamPos, 0.06f);
                PictureCanvas.transform.forward = Camera.main.transform.forward;
            }
        }
        else if (PictureCanvas.activeSelf)
        {
            PictureCanvas.SetActive(false);
        }


    }
    #endregion
    // Update is called once per frame
    void Update ()
    {
      //  UpdateCavans();
        

    }

    public IEnumerator ChooseCanvasShow()
    {
        while (true)
        {
            //按钮显示
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
                    SetButton(BtnSelected_old, Color.white);
                }
            }
            // yield return null;

            //指导菜单显示
            if (!GuidanceCanvasEnable)
            {
                GuidanceCanvas.SetActive(false);
            }

            else if (GuidanceCanvasEnable)
            {
                if (!GuidanceCanvas.activeSelf)
                {
                    GuidanceCanvas.SetActive(true);
                }
                PictureCanvas.SetActive(false);
                MainCanvas.SetActive(false);

                if (GazeManager.Instance.FocusedObject != GuidanceCanvas)
                {

                    yield return new WaitForSeconds(0.5f);
                    CurrentCamPos = Camera.main.transform.position + Camera.main.transform.forward * DistanceFromEyes;
                    CurrentCamRot = Camera.main.transform.rotation.eulerAngles;
                    if (IfWeenMove == false)
                    {
                        IfWeenMove = true;
                        iTween.MoveTo(GuidanceCanvas, CurrentCamPos, 1f);
                        iTween.RotateTo(GuidanceCanvas, CurrentCamRot, 1f);
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
            if(!PictureCanvasEnable)
            {
                PictureCanvas.SetActive(false);
            }

            else if (PictureCanvasEnable)
            {
                if (!PictureCanvas.activeSelf)
                {
                    PictureCanvas.SetActive(true);
                }

                GuidanceCanvas.SetActive(false);
                MainCanvas.SetActive(false);
                if (GazeManager.Instance.FocusedObject != PictureCanvas)
                {
                    yield return new WaitForSeconds(0.5f);
                    CurrentCamPos = Camera.main.transform.position + Camera.main.transform.forward * DistanceFromEyes;
                    CurrentCamRot = Camera.main.transform.rotation.eulerAngles;
                    if (IfWeenMove == false)
                    {
                        IfWeenMove = true;
                        iTween.MoveTo(PictureCanvas, CurrentCamPos, 1f);
                        iTween.RotateTo(PictureCanvas, CurrentCamRot, 1f);
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
            if (!MainCanvasEnable)
            {
                MainCanvas.SetActive(false);
            }

            else if (MainCanvasEnable)
            {
                if (!MainCanvas.activeSelf)
                {
                    MainCanvas.SetActive(true);
                }
                GuidanceCanvas.SetActive(false);
                PictureCanvas.SetActive(false);
                if ((GazeManager.Instance.FocusedObject != MainCanvas) && (GazeManager.Instance.FocusedObject != DrpCanvas))
                {
                    //if Mathf.Abs(MainCanvas.transform.position.x - Camera.main.transform.forward.x) > 0.1)
                    yield return new WaitForSeconds(0.5f);
                    CurrentCamPos = Camera.main.transform.position + Camera.main.transform.forward * DistanceFromEyes;
                    CurrentCamRot = Camera.main.transform.rotation.eulerAngles;
                   
                    /*if (MainCanvas.transform.position != CurrentCam)
                    {
                        Debug.Log("Move开始" + MainCanvas.transform.position);
                        iTween.MoveTo(MainCanvas, CurrentCam, 0.1f);
                        Debug.Log("Move结束" + MainCanvas.transform.position);
                    }*/
                     if (IfWeenMove == false)
                     {
                        IfWeenMove = true;
                        iTween.MoveTo(MainCanvas, CurrentCamPos, 1f);
                        iTween.RotateTo(MainCanvas, CurrentCamRot, 1f);
                        yield return  new WaitForSeconds(1f) ;
                        IfWeenMove = false;
                        // iTween.MoveBy(MainCanvas, iTween.Hash("x", CurrentCam.x - MainCanvas.transform.position.x, "y", CurrentCam.y - MainCanvas.transform.position.y, "z", CurrentCam.z - MainCanvas.transform.position.z, "easeType", "easeInOutExpo", /*"loopType",*/"onceType", "pingPong", "speed", 0.5f, "delay", .5));

                    }
                    // if (IfWeenMove == true)
                    // {
                       //  IfWeenMove = false;
                    // }

                    //iTween.m
                    // iTween.MoveBy(gameObject, iTween.Hash("y", CurrentCam.y - MainCanvas.transform.position.y, "easeType", "easeInOutExpo", /*"loopType",*/"onceType", "pingPong", "delay", .0));
                    // iTween.MoveBy(gameObject, iTween.Hash("z", CurrentCam.z - MainCanvas.transform.position.z, "easeType", "easeInOutExpo", /*"loopType",*/"onceType", "pingPong", "delay", .0));
                    //MainCanvas.transform.position = Vector3.Slerp(MainCanvas.transform.position, CurrentCam, 0.06f);                   
                    //  MainCanvas.transform.forward = Camera.main.transform.forward;

                }
              //  else
              //  {
              //      IfWeenMove = false;
             //   }


            }              
            yield return null;
        }
    }

}
