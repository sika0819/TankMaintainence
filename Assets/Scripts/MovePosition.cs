using UnityEngine;
using System.Collections;
using HoloToolkit.Unity;

public class MovePosition : MonoBehaviour {

    //  public Material MyGreen;
    public GameObject CursorText2;
    private Vector3 manipulationPreviousPosition;
    public float RotationSensitivity = 0.5f;
    //  public GameObject PictureCanvas;
    private float rotationFactorX;
    private float rotationFactorY;
    private float rotationFactorZ;

    // Use this for initialization  
    void Start()
    {
  
    }

    // Update is called once per frame  
    void Update()
    {

    }

    private void OnGazeEnter() //用户目光注视到某个虚拟面片
    {    
        if ( HitChildShow .Instance.IfCoverSet == true && NewGuidanceSet .Instance .StartRecognization ==true)
        {
           
                foreach (Transform child in transform)
                {
                  
                    child.gameObject.GetComponent<Renderer>().enabled = true;                
                }
   
        }          
    }
    private void OnGazeLeave() //用户目光离开某个虚拟面片
    {
        if (HitChildShow.Instance.IfCoverSet == true && NewGuidanceSet.Instance.StartRecognization == true )
        {
       
                foreach (Transform child in transform)
                {
                    child.gameObject.GetComponent<Renderer>().enabled = false;
                    child.gameObject.GetComponent<Renderer>().material = null;
                }

            CursorText2.SetActive(false); //使辅助光标不可见


        }
     
    }

    void PerformManipulationStart(Vector3 position)
    {
        //设置初始位置  
        manipulationPreviousPosition = position;
    }

    void PerformRotate(Vector3 NavigationPosition)
    {
        if (!HitChildShow.Instance.IfCoverSet && NewGuidanceSet.Instance.IfMoveAll == false)
        {
            rotationFactorX = NavigationPosition.x * RotationSensitivity;
            rotationFactorY = NavigationPosition.y * RotationSensitivity;
            rotationFactorZ = NavigationPosition.z * RotationSensitivity;
            //绕着x轴和y轴进行旋转
            if (NewGuidanceSet.Instance.IfRotateZ == true)
                this.transform.parent.Rotate(new Vector3(0, 0, 1 * rotationFactorX));//绕Z轴
            else
                this.transform.parent.Rotate(new Vector3(1 * rotationFactorY, 0, 0));//绕X轴
        }
    }

    void PerformManipulationUpdate(Vector3 position)
    {
        if (GestureManager.Instance.IsManipulating && HitChildShow .Instance .IfCoverSet == false && NewGuidanceSet.Instance.IfMoveAll == true)
        {
            //计算相对位移，然后更新物体的位置     
            Vector3 moveVector = Vector3.zero;
            moveVector = position - manipulationPreviousPosition;
            manipulationPreviousPosition = position;
            if (NewGuidanceSet.Instance.IfMoveAll == true)
            {
                transform.parent.position += moveVector;
            }
   
        }
    }
}
