using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

using System.Collections.Generic;
using HoloToolkit.Unity;

public class GuidanceManager : Singleton<GuidanceManager>
{
    public GameObject StepText;//文字显示窗口（Text)
    public GameObject  GuidanceText;//文字显示窗口（Text)

    public GameObject MaintanStepText;//文字显示窗口2（Text)
    public GameObject MaintanGuidanceText;//文字显示窗口2（Text)
    public GameObject MaintainTitle;

    public int MaintainStep;
    public int MaintainCount;

    //  public int GuidanceStep; //当前维修步骤
    // public int GuidanceCount; //
    //  public List<string> GuideSource = new List<string>(); //维修步骤内容
    public List<string> MaintainOpenSource = new List<string>(); //开启系统步骤内容
    public List<string> MaintainCloseSource = new List<string>(); //关闭系统步骤内容

    void Start () {

        MaintainStep = 0;
        MaintainCount = 3;

        MaintainOpenSource.Add("第一步：\r\n"+"向上打开操纵台上的稳定器开关CZ，等待1.5分钟");
        MaintainOpenSource.Add("第二步：\r\n" + "拔出解脱子，旋转至下方解脱位置");
        MaintainOpenSource.Add("第三步：\r\n" + "向上打开操纵台上的电传开关SP");

        MaintainCloseSource.Add("第一步：\r\n" + "向下关闭操纵台上的电传开关SP");
        MaintainCloseSource.Add("第二步：\r\n" + "拔出解脱子，旋转至上方闭锁位置");
        MaintainCloseSource.Add("第三步：\r\n" + "向下关闭操纵台上的稳定器开关CZ\r\n" +"注意：\r\n"+"关闭开关CZ后，如系统仍处于工作状态，请检查解脱子");
        //    GuidanceStep = 0;
        //     GuidanceCount = 4;
        //     GuideSource.Add("第一步："+"\r\n"+"。。。。。。");
        //     GuideSource.Add("第二步：" + "\r\n" + "。。。。。。");
        //     GuideSource.Add("第三步：" + "\r\n" + "。。。。。。");
        //     GuideSource.Add("维修完毕！" + "\r\n" + "。。。。。。");
        GuidanceText.GetComponent<Text>().text = "";
        StepText.GetComponent<Text>().text = "";
        MaintanStepText.GetComponent<Text>().text = "";
        MaintanGuidanceText.GetComponent <Text>().text = MaintainOpenSource[0];
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
