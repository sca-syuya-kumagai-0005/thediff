using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fakebutton : MonoBehaviour
{
    private static bool OKflag=false;
    private static int OKcount;
    private bool poseflag;
    public int Score = 0;
    public int PlusScore = 0;
    

    // Start is called before the first frame update
    void OnEnable()
    {
       OKflag=false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    //�{�^�����������Ƃ��̏���
    //���ꂼ��̃{�^���ŏ����͓Ɨ����Ă��邽�ߒ���
    public void OnClick()
    {
        poseflag = GameManager.PoseFlag();
        if (!poseflag&&!TimeBarController.TimeUpFlag)
        {
            if(!OKflag)
            { 
                OKflag = true;
            }
        }
    }

    public static bool OKJudge()
    {
        return OKflag;
    }
    
}
