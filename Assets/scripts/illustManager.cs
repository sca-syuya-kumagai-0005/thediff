using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class illustManager : MonoBehaviour
{
    [SerializeField]
    private GameObject illust;
    private GameObject[] illusts;
    private int illustCount=0;
    private static int illustrand;
    private static bool changeFlag;


    private bool flag=true;

    
    // Start is called before the first frame update
    void Start()
    {
        illusts=new GameObject[illust.transform.childCount];
        illustration();
        //illustrand = childrenget.IllustRand();
        //illusts[illustrand].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(flag)
        {
            illustrand=GameManager.IllustRand();
            illusts[illustrand].SetActive(true);
            flag=false;
        }
        changeFlag = GameManager.change();
        if(changeFlag)
        {
            illusts[illustrand].SetActive(false);
            illustrand = GameManager.IllustRand();
            illusts[illustrand].SetActive(true);
        }

    }

    void illustration()
    {
        for(illustCount=0;illustCount<illust.transform.childCount;illustCount++)
        {
            illusts[illustCount] = illust.transform.GetChild(illustCount).gameObject;
            illusts[illustCount].gameObject.SetActive(false);
        }
    }
}
