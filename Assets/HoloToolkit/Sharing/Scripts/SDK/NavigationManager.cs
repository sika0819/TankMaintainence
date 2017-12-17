using UnityEngine;
using System.Collections;
using HoloToolkit.Unity;

public class NavigationManager : MonoBehaviour
{
    public float RotationSensitivity = 10.0f;
  //  public GameObject PictureCanvas;
    private float rotationFactorX;
    private float rotationFactorY;
    private float rotationFactorZ;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
      // PerformRotation();
    }

    private void PerformRotation()
    {
        //当处于Navigating Gesture时且当前物体为被手势识别追踪的物体时进行旋转  
      //  if (GestureManager.Instance.IsNavigating && NewGuidanceSet.Instance.ObjectsStatic.Contains (HandsManager.Instance.FocusedGameObject))
        {
            if (!HitChildShow.Instance.IfCoverSet && NewGuidanceSet .Instance .IfMoveAll ==false)
            {
                //计算旋转角度  
                rotationFactorX = GestureManager.Instance.NavigationPosition.x * RotationSensitivity;
                rotationFactorY = GestureManager.Instance.NavigationPosition.y * RotationSensitivity;
                rotationFactorZ = GestureManager.Instance.NavigationPosition.z * RotationSensitivity;
                //绕着x轴和y轴进行旋转  
                if (NewGuidanceSet.Instance.IfRotateZ == true)
                {
                    //HandsManager.Instance.FocusedGameObject.transform.parent.Rotate(new Vector3(0, -1 * rotationFactorY, 0));
                }
                else if (NewGuidanceSet.Instance.IfRotateZ == false)
                {
                    //HandsManager.Instance.FocusedGameObject.transform.parent.Rotate(new Vector3(0, -1 * rotationFactorX,  0));
                }
            }
        }

        /*
        if (GestureManager.Instance.IsNavigating && HandsManager.Instance.FocusedGameObject == SetCanvas.Instance.PictureCanvas)
        {
            Vector3 deltaScale = Vector3.zero;
            float ScaleValue = 0.0002f;
            //设置每一帧缩放的大小  
            if (GestureManager.Instance.NavigationPosition.x < 0)
            {
                ScaleValue = -1 * ScaleValue;
            }

            //不可超出缩放范围
            if (SetCanvas.Instance.PictureCanvas.transform.localScale.x >= 0.003f && SetCanvas.Instance.PictureCanvas.transform.localScale.x <= 0.008f)
            {
                //根据比例计算每个方向上的缩放大小  
                deltaScale.x = ScaleValue;
                deltaScale.y = (SetCanvas.Instance.PictureCanvas.transform.localScale.y / SetCanvas.Instance.PictureCanvas.transform.localScale.x) * ScaleValue;
                deltaScale.z = (SetCanvas.Instance.PictureCanvas.transform.localScale.z / SetCanvas.Instance.PictureCanvas.transform.localScale.x) * ScaleValue;
                SetCanvas.Instance.PictureCanvas.transform.localScale += deltaScale;
            }
            if (SetCanvas.Instance.PictureCanvas.transform.localScale.x > 0.008f)
            {
                SetCanvas.Instance.PictureCanvas.transform.localScale =new Vector3 ( 0.008f, 0.008f, 0.008f);
            }
            if (SetCanvas.Instance.PictureCanvas.transform.localScale.x < 0.003f)
            {
                SetCanvas.Instance.PictureCanvas.transform.localScale = new Vector3(0.003f, 0.003f, 0.003f);
            }

        }
        */
    }
}
