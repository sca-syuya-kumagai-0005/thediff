using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class childrenget : MonoBehaviour
{
    private GameObject[] ChildObject;
    [SerializeField]
    private GameObject GameManager;
    private GameObject[] GameManagement;
    private int problemCount;
    private static int problemrand;
    private static bool changeFlag=false;
    public bool OKflag=false;
    private bool Trueflag=false;  

    [SerializeField]
    private int fakecount;
    [SerializeField]
    private int OKcountprovisional;

    public static int Plusscore = 0;
    public static int Totalscore=0;
    public int ClearCount = 0;
    public static int QuestionValue=0;
    public static  bool Checkflag;
    private int Qmax=0;

    void Start()
    {
        GameManagement = new GameObject[GameManager.transform.childCount];
        Problem();
        ProblemRand();
        GetAllChildObject();
    }

    void Update()
    {

        Checkflag=CheckButton.Check();

        if (Totalscore < 10000)
        {
            QuestionValue=5;
        }
        else
        {
            QuestionValue=6;
        }

        //見つけたfakeの数と抽選されたfakeの数が同じだと行われる処理

        if (OKflag)//間違いボタンを押した
        {
            ClearCount += 1;
            Totalscore += Plusscore;
            changeFlag = true;
            FakeActivetrue();
            FakeActivefalse();
            ProblemRand();
            Trueflag =false;

            GetAllChildObject();
        }
        else if(Checkflag&&!OKflag)//間違いボタンを押してない時にチェックボタンを押した
        {
            if (Trueflag)//本物だった
            {
                ClearCount += 1;
                Totalscore += Plusscore;
                changeFlag = true;
                FakeActivetrue();
                FakeActivefalse();
                ProblemRand();
                Trueflag=false;
                GetAllChildObject();
            }
            else//偽物だった
            {
                Debug.Log("即死");
            }
            CheckFalse(changeFlag);
        }
        OKflag = fakebutton.OKJudge();



        ////見つけたfakeの数をカウントするプログラム
        //else
        //{ 
        //    OKcountprovisional = fakebutton.OKCount();
        //    OKcount=OKcountprovisional;
        //    changeFlag=false;
        //}
    }

    //fakeに置き換える抽選を行う関数
    private void GetAllChildObject()
    {
            
        ChildObject = new GameObject[GameManagement[problemrand].transform.childCount];
        //画像をそのまま表示するか、偽物も混ぜるかを抽選　現時点では5分の1でそのまま表示
        
        if(Totalscore<10000)
        {
            Qmax=1;
        }
        else
        {
            Qmax=0;
        }
        int a =Random.Range(1,QuestionValue);
        if(a==5)
        {
            Debug.Log("notfake");
            for (int n=0;n< GameManagement[problemrand].transform.childCount;n++)
            {
                ChildObject[n]= GameManagement[problemrand].transform.GetChild(n).gameObject;
                ChildObject[n].gameObject.SetActive(false);
                OKflag=false;
                Plusscore = 8000;
            }
            Trueflag=true;
        }
        //偽物も混ぜるように抽選された際、どの部分を置き換えるか抽選
        else
        {
            for (int i = 0; i < GameManagement[problemrand].transform.childCount; i++)
            {
                ChildObject[i] = GameManagement[problemrand].transform.GetChild(i).gameObject;
            }
            int rnd = 0;
            rnd = Random.Range(0, GameManagement[problemrand].transform.childCount);
            Debug.Log(rnd);
            ChildObject[rnd].SetActive(true);
            //if (ClearCount <= 1)
            //{
            //    Plusscore = 0;
            //}
            //else if (ClearCount > 1)
            //{
            Plusscore = 1000;
            //}
        }
    }
    //全てのfakeをSetActive(true)に変更する関数
    private void FakeActivetrue()
    {
        for (int n = 0; n < GameManagement[problemrand].transform.childCount; n++)
        {
            ChildObject[n] = GameManagement[problemrand].transform.GetChild(n).gameObject;
            ChildObject[n].gameObject.SetActive(true);
        }
    }
    //全てのfakeをSetActive(false)に変更する関数
    private void FakeActivefalse()
    {
        for (int n = 0; n < GameManagement[problemrand].transform.childCount; n++)
        {
            ChildObject[n] = GameManagement[problemrand].transform.GetChild(n).gameObject;
            ChildObject[n].gameObject.SetActive(false);
        }
    }
    //問題を格納している関数
    private void Problem()
    {
        //GameManagementに問題を格納
         
        for(problemCount = 0; problemCount < GameManager.transform.childCount; problemCount++)
        {
            GameManagement[problemCount]=GameManager.transform.GetChild(problemCount).gameObject;
            GameManagement[problemCount].gameObject.SetActive(false);
        }
    }

    private void ProblemRand()
    {
        problemrand = Random.Range(0, problemCount);
        for(int n = 0; n < GameManager.transform.childCount; n++)
        {
            if(problemrand==n)

            {
                GameManagement[problemrand].SetActive(true);
            }
            else
            {
                GameManagement[n].SetActive(false);
            }
        }
    }


    //抽選した値をillustManagerに渡すための関数
    public static int IllustRand()
    {
        return problemrand;
    }

    public static bool change()
    {
        return changeFlag;
    }

    public static int PlusScore()
    {
        return Plusscore;
    } 

    public static int TotalScore()
    {
        return Totalscore; 
    }


    public static bool CheckFalse(bool flg)
    {
        if(flg)
        { flg=false;}
        return flg;
    }

}
