using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine.UI;
//using Visual C++ 2015 Runtime

namespace HoloToolkit.Unity
{
    public class dlltest : MonoBehaviour
    {
        //[DllImport(@"F:\hololensproject\dll\ConsoleApplication1\Debug\ConsoleApplication1.dll", EntryPoint = "AddTest", CallingConvention = CallingConvention.Cdecl)]
        // [DllImport(@"F:\hololensproject\dll\ConsoleApplication1\Release\ConsoleApplication1.dll", EntryPoint = "AddTest", CallingConvention = CallingConvention.Cdecl)]
       // [DllImport(@"F:\hololensproject\dll\ConsoleApplication1\Debug\ConsoleApplication1.dll", EntryPoint = "AddTest", CallingConvention = CallingConvention.Cdecl)]
        [DllImportAttribute("F:\\hololensproject\\dll3\\testdll\\Release\\testdll.dll", EntryPoint = "fntestdll")]//, CallingConvention = CallingConvention.Cdecl)]
        extern static int fntestdll();
        // Use this for initialization
        void Start()
        {
            Debug.Log("我调用初始lelelele");
            //Debug.Log(AddTest(5, 2)); hfg
           // int a = AddTest(5, 2);
            //GameObject.Find("Textt").GetComponent<Text>().text = fntestdll().ToString() ;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}