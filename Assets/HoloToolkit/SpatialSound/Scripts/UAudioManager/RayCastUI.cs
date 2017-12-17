using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using HoloToolkit.Unity;

public class RayCastUI : Singleton<RayCastUI>
{

    // Use this for initialization

    //  public static new RayCastUI Instance;
    public float RayCastLength = 1000.0f; //按钮最大识别距离
    public LayerMask UILayerMask;
    // public Button btn;
    private Vector3 hitPos, hitNormal;
    private Vector3 uiRayCastOrigin;
    private Vector3 uiRayCastDirection;
    ColorBlock cb;//= new ColorBlock();
    void Start()
    {
        cb = new ColorBlock();

        // Button hh = GameObject.Find("Button") as Button;
        //  GameObject btnObj = GameObject.Find("Canvas/Panel/Button");
        //  Button btn = (Button)btnObj.GetComponent<Button>();
        //  SetButton(btn);
        // ColorBlock cb = new ColorBlock();
        // cb.normalColor = Color.white;
        //  cb.highlightedColor = Color.green ;
        //  cb.pressedColor = Color.yellow;
        // cb.disabledColor = Color.white;
        // cb.colorMultiplier = 1;
        //  cb.fadeDuration = 0.1f;
        //  btn.colors = cb;
        //hh.GetComponent<Renderer>().material.color = Color.green;  
    }
    public void SetButton(Button btn, Color color)
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

    public void SetDrp(Dropdown Drp, Color color)
    {
        //ColorBlock cb = new ColorBlock();
        cb.normalColor = color;
        cb.highlightedColor = Color.white;
        cb.pressedColor = Color.white;
        cb.disabledColor = Color.white;
        cb.colorMultiplier = 1;
        cb.fadeDuration = 0.1f;
        Drp.colors = cb;
    }


    public bool CastUI(out Vector3 hitPos, out Vector3 hitNormal, out Button hitButton /* out Dropdown HitDrp*/)
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

    // Update is called once per frame
    void Update()
    {
        // if (CastUI(out hitPos, out hitNormal, out btn) && (btn != null))
        // {
        // ColorBlock cb = new ColorBlock();
        // cb.normalColor = Color.red;
        //hit.colors = cb;        
        // SetButton(btn);
        // Debug.Log("hit a button!!!");
        //if (hit.onClick != null)
        // {
        //    hit.onClick.Invoke();
        //}
        //}
    }
}
