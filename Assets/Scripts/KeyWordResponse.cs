using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KeyWordResponse : MonoBehaviour {

    public void NextStepResponse()
    {
        if (NewGuidanceSet.Instance.IfVoiceRecog == true)
        {
            GuidanceManager.Instance.MaintainStep += 1;
            GuidanceManager.Instance.MaintainStep = GuidanceManager.Instance.MaintainStep % GuidanceManager.Instance.MaintainCount;
            if (NewGuidanceSet.Instance.IfOpenSystem == true)
            {
                GuidanceManager.Instance.MaintanGuidanceText.GetComponent<Text>().text = GuidanceManager.Instance.MaintainOpenSource[GuidanceManager.Instance.MaintainStep];
            }
            else
            {
                GuidanceManager.Instance.MaintanGuidanceText.GetComponent<Text>().text = GuidanceManager.Instance.MaintainCloseSource[GuidanceManager.Instance.MaintainStep];
            }

            NewGuidanceSet.Instance.MaintainObjectShow();
        }
    }

    public void LastStepResponse()
    {
        if (NewGuidanceSet.Instance.IfVoiceRecog == true)
        {
            if (GuidanceManager.Instance.MaintainStep == 0)
            {
                GuidanceManager.Instance.MaintainStep = GuidanceManager.Instance.MaintainCount - 1;
                if (NewGuidanceSet.Instance.IfOpenSystem == true)
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
                if (NewGuidanceSet.Instance.IfOpenSystem == true)
                {
                    GuidanceManager.Instance.MaintanGuidanceText.GetComponent<Text>().text = GuidanceManager.Instance.MaintainOpenSource[GuidanceManager.Instance.MaintainStep];
                }
                else
                {
                    GuidanceManager.Instance.MaintanGuidanceText.GetComponent<Text>().text = GuidanceManager.Instance.MaintainCloseSource[GuidanceManager.Instance.MaintainStep];
                }
            }
            NewGuidanceSet.Instance.MaintainObjectShow();
        }
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
