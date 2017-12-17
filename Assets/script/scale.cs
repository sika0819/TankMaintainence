using UnityEngine;
using System.Collections;

public class scale : MonoBehaviour {

    public GameObject Text;
    public GameObject Sword;
    public GameObject Flag;

    // Use this for initialization
    void Start () {
        Text.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        Sword.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        Flag.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        StartCoroutine(LoadScene());

    }
	
	// Update is called once per frame
	void Update () {
        Flag.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 50 + Camera.main.transform.up * 3.5f;
        Flag.transform.forward = Camera.main.transform.forward;
        Text.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 20 - Camera.main.transform.up *1.2f;
        Text.transform.forward = Camera.main.transform.forward;
        Sword.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 20 - Camera.main.transform.up * 0.2f;
        Sword.transform.forward = Camera.main.transform.forward;
    }

    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(10f);
        Application.LoadLevel("BasicCursor");
    }
}
