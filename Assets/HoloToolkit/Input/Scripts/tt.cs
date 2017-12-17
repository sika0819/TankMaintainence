using UnityEngine;
using System.Collections;
using HoloToolkit.Unity;
using UnityEngine.UI;
using System.Runtime.InteropServices;
//using Emgu.CV;
//using Emgu.CV.CvEnum;
//using Emgu.CV.Structure;
//using ConsoleApplication1.dll;
//using OpenCvSharp;
//using OpenCvSharp.XFeatures2D;
//using SampleBase;

namespace HoloToolkit.Unity
{
    

    public class tt : MonoBehaviour
    {
        private delegate void del1(int a, int b);
        private void addd( del1 del)
        {
            
            del(1,2);
        }

        /* public void run()
         {
             var src1 = new Mat(FilePath.Image.Match1, ImreadModes.Color);
             var src2 = new Mat(FilePath.Image.Match2, ImreadModes.Color);

             MatchBySift(src1, src2);
             //MatchBySurf(src1, src2);
         }

         private void MatchBySift(Mat src1, Mat src2)
         {
             var gray1 = new Mat();
             var gray2 = new Mat();

             Cv2.CvtColor(src1, gray1, ColorConversionCodes.BGR2GRAY);
             Cv2.CvtColor(src2, gray2, ColorConversionCodes.BGR2GRAY);

             var sift = SIFT.Create();

             // Detect the keypoints and generate their descriptors using SIFT
             KeyPoint[] keypoints1, keypoints2;
             var descriptors1 = new MatOfFloat();
             var descriptors2 = new MatOfFloat();
             sift.Compute(gray1, null, out keypoints1, descriptors1);
             sift.Compute(gray2, null, out keypoints2, descriptors2);

             // Match descriptor vectors
             var bfMatcher = new BFMatcher(NormTypes.L2, false);
             var flannMatcher = new FlannBasedMatcher();
             DMatch[] bfMatches = bfMatcher.Match(descriptors1, descriptors2);
             DMatch[] flannMatches = flannMatcher.Match(descriptors1, descriptors2);

             // Draw matches
             var bfView = new Mat();
             Cv2.DrawMatches(gray1, keypoints1, gray2, keypoints2, bfMatches, bfView);
             var flannView = new Mat();
             Cv2.DrawMatches(gray1, keypoints1, gray2, keypoints2, flannMatches, flannView);

             using (new Window("SIFT matching (by BFMather)", WindowMode.AutoSize, bfView))
             using (new Window("SIFT matching (by FlannBasedMatcher)", WindowMode.AutoSize, flannView))
             {
                 Cv2.WaitKey();
             }
         }*/

        public IEnumerator haha()
        {
            Debug.Log("sgsfg");
            yield return 0;
            
        }

        private void addte(int a, int b)
        {
            Debug .Log (a + b);
        }
       // [DllImport(@"F:\hololensproject\dll\ConsoleApplication1\Release\ConsoleApplication1.dll", EntryPoint = "AddTest", CallingConvention = CallingConvention.Cdecl)]
       // extern static int AddTest(int a, int b);
       // public Vector3 position = gameObject.transform.position;
        public int gs;
        public int Gs
        {
            get
            {
                return gs;
            }
            set
            {
                gs= value;
               // objectPlacementDescription = "";
            }
        }

        public tt2 ttt2=new tt2();
        // Use this for initialization
        public static tt Instance;
        public delegate void kk();
        public void test2()
        {
            Gs = 5;
            gs = 6;
            Gs = 8;
            // Debug.Log("test2");
            Debug.Log("gs=:" + gs);
            Debug.Log("Gs=:" + Gs);
        }// Use this for initialization
        void Start()
        {
           // var position = Camera.main.transform.position + Camera.main.transform.right * 100 + Camera.main.transform.forward * 400;
           //  Object cubePreb = Resources.Load("PaoTa", typeof(GameObject));
 
            //用加载得到的资源对象，实例化游戏对象，实现游戏物体的动态加载
            
             
           // GameObject PouioaoTa = Instantiate(cubePreb, Vector3.zero, Quaternion.identity) as GameObject;
           // DestroyImmediate(PouioaoTa);
            // GameObject obj1 = GameObject.Find("Cube2");
            //GameObject obj2 = GameObject.Find("Cube3");
            //obj1.transform.LookAt(obj2.transform);
            // obj1.transform.rotation.SetLookRotation()
            // obj1.transform.rotation = Quaternion.LookRotation(obj2.transform.forward, obj2.transform.up);
            // obj1.transform.rotation = obj2.transform.rotation;


            //  Quaternion.LookRotation(result.Forward, result.Up)
            //var cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            //cylinder.transform.position = new Vector3(0, 0, 0);

            // run();
            //  Image<Bgra, byte> a = new Image<Bgra, byte>("C:\\Users\\lenovo\\Desktop\\picture\\pen2.jpg").Resize(0.2, Inter.Area);
            // Image<Bgra, byte> b = new Image<Bgra, byte>("C:\\Users\\lenovo\\Desktop\\picture\\pen1.jpg").Resize(0.2, Inter.Area);
            // EmguCvManager.Instance.MatchTwoPictures(a, b);
            //   addd(addte);
            // Debug.Log("我调用初始" );
            // Debug.Log("我调用了dll" + AddTest(5, 10));
            // GetComponent<tt2>().xian();
            //    kk haha = new kk(test2);
            //  haha();
            //  test2();
            // ttt2.xian();
            //   GameObject obj = GameObject.Find("Cube");
            //    obj.GetComponent<Text>().text = "123";
            //    Vector3 pos = Camera.main.WorldToViewportPoint(obj.transform .position );
            //   Debug.Log(pos);
            //Debug.Log(Camera.main.ViewportToWorldPoint(new Vector3 (0.5f,0.5f,494)));

            IEnumerator heihei = haha();
            StartCoroutine(heihei);
           // StopAllCoroutines();
        }
        public void show()
        {
            Debug.Log("succeed");
        }

        /// <summary>
        /// 哈哈好的发
        /// </summary>
        [Tooltip("fgdfgd")]
        public int jja;
        private void Awake()
        {
            Instance = this;
        }
        // Update is called once per frame
        void Update()
        {
           // Debug.DrawLine(GameObject.Find("Cube2").transform.position, GameObject.Find("Cube3").transform.position, Color.red);

        }
    }
}