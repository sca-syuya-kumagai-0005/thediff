using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class start3sec : MonoBehaviour
{
    [SerializeField]
    private int waittime;
    public static int waittmptime;
    [SerializeField]
    private Text waittext;
    [SerializeField]
    private GameObject WAIT;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startwait());
        waittmptime=waittime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator startwait()
    {
        for (int i = waittime; i > 0; i--)
        {
            waittext.text=i.ToString();
            yield return new WaitForSeconds(1);
        }
        //waittext.text = "START";
        //yield return new WaitForSeconds(2);
        GameManager.startflag=true;
        WAIT.SetActive(false);
    }
}
