using UnityEngine;
using System.Collections;
using HoloToolkit.Unity;
using UnityEngine.UI;
using System.Collections.Generic;

public class HitChildShow : Singleton<HitChildShow>
{
    //public Material material1; //默认材质
    // public Material material2; //透明材质

    public GameObject CursorText; //光标旁边的提示文字
    //虚拟方框
    public GameObject RightJack;
    public GameObject LeftJack;
    public GameObject TopJack;
    public GameObject RightSwitch;
    public GameObject LeftSwitch;
    public GameObject LeftButton;
    public GameObject RightButton;
    public GameObject CircleJackTop;
    public GameObject RightFrontWrench;
    public GameObject LeftFrontWrench;
    public GameObject FrontPannel;
    public GameObject RightWrench;
    public GameObject BottomRightSwitch;
    public GameObject BottomLeftSwitch;
    public GameObject CircleJackBottom;
    public GameObject CircleBottomAnother;
    public GameObject LeftWrench;
    public GameObject CircleTopJackFront;
    public Material MyGreen;

    //展示物体
    //public GameObject RightJackShow;
   // public GameObject LeftJackShow;
   // public GameObject TopJackShow;
   // public GameObject RightSwitchShow;
   // public GameObject LeftSwitchShow;
   // public GameObject LeftButtonShow;
   // public GameObject RightButtonShow;
   // public GameObject CircleJackTopShow;
   // public GameObject RightFrontWrenchShow;
    //public GameObject LeftFrontWrenchShow;
   // public GameObject FrontPannelShow;
   // public GameObject RightWrenchShow;
   // public GameObject BottomRightSwitchShow;
   // public GameObject BottomLeftSwitchShow;
   // public GameObject CircleJackBottomShow;
   // public GameObject LeftWrenchShow;
   // public GameObject LeftHandShow;
   // public GameObject RightHandShow;
   // public GameObject BottomLeftSwitch;
    public List<GameObject> ObjectsToSelected;

    public bool IfCoverSet;
    public GameObject TextPlane;
    // Use this for initialization
    void Start () {
        CursorText.SetActive(false);
        StartCoroutine(SetChildHit());
        IfCoverSet = false;
        TextPlane.transform.Rotate(0, 0, 0);
        TextPlane.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 0.6f+ Camera.main.transform.up*0.1f;
        foreach (var ObjectToShow in ObjectsToSelected)
        {
            ObjectToShow.SetActive(false);
        }
    }

    private void SetSecectedShow(string ToShow, Vector3 setposition)
    {
        foreach (var ObjectToShow in ObjectsToSelected)
        {
            if (ObjectToShow.name.Equals(ToShow))
            {
                ObjectToShow.SetActive(true);
                ObjectToShow.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);

                CursorText.SetActive(true); //使辅助光标可见
                CursorText.GetComponentInChildren<TextMesh>().text = ToShow; //设置辅助光标的显示内容
                CursorText.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward, Vector3.up);
                CursorText.transform.position = CursorText.transform.parent.position + Camera.main.transform.right * 0.03f;


                if ( ToShow.Equals ("RightButtonShow") || ToShow.Equals("LeftButtonShow") )
                {
                    ObjectToShow.transform.localScale = new Vector3(ObjectToShow.transform.localScale.x * 2, ObjectToShow.transform.localScale.y * 2, ObjectToShow.transform.localScale.z * 2);
                }
                ObjectToShow.transform.position = setposition + transform.up * 0.05f ; //+ Vector3.up * 0.2f;
               
      
            }
            else
            {
                ObjectToShow.SetActive(false);
            }

        }
       // ToShow.SetActive
           
    }

   
    public IEnumerator SetChildHit()
    {
        while (true)
        {
            if (NewGuidanceSet.Instance.StartRecognization == true)
            {
                if (GazeManager.Instance.FocusedObject == RightJack) //右灯
                {
                    yield return new WaitForSeconds(1f);
                    if (GazeManager.Instance.FocusedObject == RightJack)
                    {
                        foreach (Transform child in RightJack.transform )
                        {
                            child.gameObject.GetComponent<Renderer>().material = MyGreen;
                        }
                        GuidanceManager.Instance.StepText.GetComponent<Text>().text = "稳定器指示灯";
                        GuidanceManager.Instance.GuidanceText.GetComponent<Text>().text = "稳定器工作后应点亮";
                        SetSecectedShow("RightJackShow", RightJack.transform .position );
                    }
                }

                else if (GazeManager.Instance.FocusedObject == LeftJack) //左灯
                {
                    yield return new WaitForSeconds(1f);
                    if (GazeManager.Instance.FocusedObject == LeftJack)
                    {
                        foreach (Transform child in LeftJack.transform)
                        {
                            child.gameObject.GetComponent<Renderer>().material = MyGreen;
                        }
                        GuidanceManager.Instance.StepText.GetComponent<Text>().text = "电传指示灯";
                        GuidanceManager.Instance.GuidanceText.GetComponent<Text>().text = "电传动装置工作后应点亮";
                        SetSecectedShow("LeftJackShow", LeftJack.transform .position );
                    }
                }
                else if (GazeManager.Instance.FocusedObject == TopJack) //上灯
                {
                    yield return new WaitForSeconds(1f);
                    if (GazeManager.Instance.FocusedObject == TopJack)
                    {
                        foreach (Transform child in TopJack.transform)
                        {
                            child.gameObject.GetComponent<Renderer>().material = MyGreen;
                        }
                        GuidanceManager.Instance.StepText.GetComponent<Text>().text = "目标指示器指示灯";
                        GuidanceManager.Instance.GuidanceText.GetComponent<Text>().text = "目标指示器工作后应点亮";
                        SetSecectedShow("TopJackShow", TopJack.transform .position );
                    }
                }
                else if (GazeManager.Instance.FocusedObject == LeftButton) //左按钮
                {
                    yield return new WaitForSeconds(1f);
                    if (GazeManager.Instance.FocusedObject == LeftButton)
                    {
                        foreach (Transform child in LeftButton.transform)
                        {
                            child.gameObject.GetComponent<Renderer>().material = MyGreen;
                        }
                        GuidanceManager.Instance.StepText.GetComponent<Text>().text = "机枪击发按钮";
                        GuidanceManager.Instance.GuidanceText.GetComponent<Text>().text = "";
                        SetSecectedShow("LeftButtonShow", LeftButton.transform .position );
                     //   LeftButtonShow
                    }
                }
                else if (GazeManager.Instance.FocusedObject == RightButton) //右按钮
                {
                    yield return new WaitForSeconds(1f);
                    if (GazeManager.Instance.FocusedObject == RightButton)
                    {
                        foreach (Transform child in RightButton.transform)
                        {
                            child.gameObject.GetComponent<Renderer>().material = MyGreen;
                        }
                        GuidanceManager.Instance.StepText.GetComponent<Text>().text = "火炮击发按钮";
                        GuidanceManager.Instance.GuidanceText.GetComponent<Text>().text = "";
                        SetSecectedShow("RightButtonShow", RightButton.transform .position );
                    }
                }
                else if (GazeManager.Instance.FocusedObject == LeftSwitch) //上盖左开关
                {
                    yield return new WaitForSeconds(1f);
                    if (GazeManager.Instance.FocusedObject == LeftSwitch)
                    {
                        foreach (Transform child in LeftSwitch.transform)
                        {
                            child.gameObject.GetComponent<Renderer>().material = MyGreen;
                        }
                        GuidanceManager.Instance.StepText.GetComponent<Text>().text = "电传装置开关";
                        GuidanceManager.Instance.GuidanceText .GetComponent<Text>().text = "向上开启火炮水平向电传装置";
                        SetSecectedShow("LeftSwitchShow", LeftSwitch.transform .position );
                    }
                }
                else if (GazeManager.Instance.FocusedObject == RightSwitch) //上盖右开关
                {
                    yield return new WaitForSeconds(1f);
                    if (GazeManager.Instance.FocusedObject == RightSwitch)
                    {
                        foreach (Transform child in RightSwitch.transform)
                        {
                            child.gameObject.GetComponent<Renderer>().material = MyGreen;
                        }
                        GuidanceManager.Instance.StepText.GetComponent<Text>().text = "电力传动装置开关";
                        GuidanceManager.Instance.GuidanceText.GetComponent<Text>().text = "向上开启火炮高低稳定器";
                        SetSecectedShow("RightSwitchShow", RightSwitch.transform .position );
                    }
                }
                else if (GazeManager.Instance.FocusedObject == LeftFrontWrench ) //左手柄
                {
                    yield return new WaitForSeconds(1f);
                    if (GazeManager.Instance.FocusedObject == LeftFrontWrench)
                    {
                        foreach (Transform child in LeftFrontWrench.transform)
                        {
                            child.gameObject.GetComponent<Renderer>().material = MyGreen;
                        }
                        GuidanceManager.Instance.StepText.GetComponent<Text>().text = "操纵台手柄";
                        GuidanceManager.Instance.GuidanceText.GetComponent<Text>().text = "可以上下和左右旋转，完成调炮";
                        SetSecectedShow("LeftHandShow", LeftFrontWrench.transform .position+transform .up*0.09f );
                    }
                }
                else if (GazeManager.Instance.FocusedObject == LeftWrench) //左手柄
                {
                    yield return new WaitForSeconds(1f);
                    if (GazeManager.Instance.FocusedObject == LeftWrench)
                    {
                        foreach (Transform child in LeftWrench.transform)
                        {
                            child.gameObject.GetComponent<Renderer>().material = MyGreen;
                        }
                        GuidanceManager.Instance.StepText.GetComponent<Text>().text = "操纵台手柄";
                        GuidanceManager.Instance.GuidanceText.GetComponent<Text>().text = "可以上下和左右旋转，完成调炮";
                        SetSecectedShow("LeftHandShow", LeftFrontWrench.transform.position + transform.up * 0.09f);
                    }
                }
                else if (GazeManager.Instance.FocusedObject == RightWrench) //右手柄
                {
                    yield return new WaitForSeconds(1f);
                    if (GazeManager.Instance.FocusedObject == RightWrench)
                    {
                        foreach (Transform child in RightWrench.transform)
                        {
                            child.gameObject.GetComponent<Renderer>().material = MyGreen;
                        }
                        GuidanceManager.Instance.StepText.GetComponent<Text>().text = "操纵台手柄";
                        GuidanceManager.Instance.GuidanceText.GetComponent<Text>().text = "可以上下和左右旋转，完成调炮";
                        SetSecectedShow("RightHandShow", RightFrontWrench.transform.position + transform.up * 0.09f);
                    }
                }
                else if (GazeManager.Instance.FocusedObject == RightFrontWrench ) //右手柄
                {
                    yield return new WaitForSeconds(1f);
                    if (GazeManager.Instance.FocusedObject == RightFrontWrench)
                    {
                        foreach (Transform child in RightFrontWrench.transform)
                        {
                            child.gameObject.GetComponent<Renderer>().material = MyGreen;
                        }
                        GuidanceManager.Instance.StepText.GetComponent<Text>().text = "操纵台手柄";
                        GuidanceManager.Instance.GuidanceText.GetComponent<Text>().text = "可以上下和左右旋转，完成调炮";
                        SetSecectedShow("RightHandShow", RightFrontWrench.transform .position + transform.up * 0.09f);
                    }
                }
                else if (GazeManager.Instance.FocusedObject == FrontPannel) //前盖
                {
                    yield return new WaitForSeconds(1f);
                    if (GazeManager.Instance.FocusedObject == FrontPannel)
                    {
                        foreach (Transform child in FrontPannel.transform)
                        {
                            child.gameObject.GetComponent<Renderer>().material = MyGreen;
                        }
                        GuidanceManager.Instance.StepText.GetComponent<Text>().text = "电传装置电位计";
                        GuidanceManager.Instance.GuidanceText.GetComponent<Text>().text = "用于水平向瞄准和调炮";
                        SetSecectedShow("FrontPannelShow", FrontPannel.transform .position );
                    }
                }
                else if (GazeManager.Instance.FocusedObject == CircleJackTop) //前插座
                {
                    yield return new WaitForSeconds(1f);
                    if (GazeManager.Instance.FocusedObject == CircleJackTop)
                    {
                        foreach (Transform child in CircleJackTop.transform)
                        {
                            child.gameObject.GetComponent<Renderer>().material = MyGreen;
                        }
                        GuidanceManager.Instance.StepText.GetComponent<Text>().text = "插座XS1";
                        GuidanceManager.Instance.GuidanceText.GetComponent<Text>().text = "主要连接稳定器电路";
                        SetSecectedShow("CircleJackTopShow", CircleJackTop.transform .position+transform .right *0.07f );
                    }
                }
                else if (GazeManager.Instance.FocusedObject == CircleTopJackFront) //前插座的前面片
                {
                    yield return new WaitForSeconds(1f);
                    if (GazeManager.Instance.FocusedObject == CircleTopJackFront)
                    {
                        foreach (Transform child in CircleTopJackFront.transform)
                        {
                            child.gameObject.GetComponent<Renderer>().material = MyGreen;
                        }
                        GuidanceManager.Instance.StepText.GetComponent<Text>().text = "插座XS1";
                        GuidanceManager.Instance.GuidanceText.GetComponent<Text>().text = "主要连接稳定器电路";
                        SetSecectedShow("CircleJackTopShow", CircleJackTop.transform.position + transform.right * 0.07f);
                    }
                }
                

                else if (GazeManager.Instance.FocusedObject == CircleBottomAnother ) //后插座上面片
                {
                    yield return new WaitForSeconds(1f);
                    if (GazeManager.Instance.FocusedObject == CircleBottomAnother)
                    {
                        foreach (Transform child in CircleBottomAnother.transform)
                        {
                            child.gameObject.GetComponent<Renderer>().material = MyGreen;
                        }
                        GuidanceManager.Instance.StepText.GetComponent<Text>().text = "插座XS2";
                        GuidanceManager.Instance.GuidanceText.GetComponent<Text>().text = "主要连接电传和电源电路";
                        SetSecectedShow("CircleJackBottomShow", CircleJackBottom.transform .position+transform.right * 0.07f);
                    }
                }

                else if (GazeManager.Instance.FocusedObject == CircleJackBottom) //后插座前面片
                {
                    yield return new WaitForSeconds(1f);
                    if (GazeManager.Instance.FocusedObject == CircleJackBottom)
                    {
                        foreach (Transform child in CircleJackBottom.transform)
                        {
                            child.gameObject.GetComponent<Renderer>().material = MyGreen;
                        }
                        GuidanceManager.Instance.StepText.GetComponent<Text>().text = "插座XS2";
                        GuidanceManager.Instance.GuidanceText.GetComponent<Text>().text = "主要连接电传和电源电路";
                        SetSecectedShow("CircleJackBottomShow", CircleJackBottom.transform .position + transform.right * 0.07f);
                    }
                }
                else if (GazeManager.Instance.FocusedObject == BottomLeftSwitch) //下左开关
                {
                    yield return new WaitForSeconds(1f);
                    if (GazeManager.Instance.FocusedObject == BottomLeftSwitch)
                    {
                        foreach (Transform child in BottomLeftSwitch.transform)
                        {
                            child.gameObject.GetComponent<Renderer>().material = MyGreen;
                        }
                        GuidanceManager.Instance.StepText.GetComponent<Text>().text = "机枪射击开关";
                        GuidanceManager.Instance.GuidanceText.GetComponent<Text>().text = "为射击保险，开启后机枪射击电路才能接通";
                        SetSecectedShow("BottomLeftSwitchShow", BottomLeftSwitch.transform .position );
                    }
                }
                else if (GazeManager.Instance.FocusedObject == BottomRightSwitch) //下右开关
                {
                    yield return new WaitForSeconds(1f);
                    if (GazeManager.Instance.FocusedObject == BottomRightSwitch)
                    {
                        foreach (Transform child in BottomRightSwitch.transform)
                        {
                            child.gameObject.GetComponent<Renderer>().material = MyGreen;
                        }
                        GuidanceManager.Instance.StepText.GetComponent<Text>().text = "火炮射击开关";
                        GuidanceManager.Instance.GuidanceText.GetComponent<Text>().text = "为射击保险，开启后火炮射击电路才能接通";
                        SetSecectedShow("BottomRightSwitchShow", BottomRightSwitch.transform .position );
                    }
                }
                // yield return null;
            }
            yield return null;
        }
    }
	// Update is called once per frame
	
}
