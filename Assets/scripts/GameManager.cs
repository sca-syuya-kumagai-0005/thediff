using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject[] ChildObject;
    [SerializeField]
    private GameObject Gamemanager;
    private GameObject[] GameManagement;
    private int problemCount;
    private static int problemrand;
    private static bool changeFlag=false;
    public static bool OKflag=false;
    public static bool Trueflag=false;  

    public static int NotFakeCount=0;
    public static int BonusCount=0;
    public int BonusJudge;
    public static int QuestionCount=0;

    public static int Plusscore = 0;
    [SerializeField]
    private int tmppluss;
    public static int Totalscore=0;
    public int ClearCount = 0;
    public static int QuestionValue=0;
    public static  bool Checkflag;
    public static bool poseflag=false;
    public static bool startflag{get;set;}
    private int Qmax=0;
    private int tmprand;
    private int AddTime=0;
    public float timeController = 0.0f;

    [SerializeField] private int EasyQuestionAddScore = 3000;
    [SerializeField] private int HardQuestionAddScore = 8;
    [SerializeField] private int BonusScore=15;
    [SerializeField] private float Bonus=5;
    [SerializeField] private int EasyQuestionAddTime = 5;
    [SerializeField] private int HardQuestionAddTime = 8;
    [SerializeField] private GameObject pose;


    void Start()
    {
        GameManagement = new GameObject[Gamemanager.transform.childCount];
        Problem();
        ProblemRand();
        GetAllChildObject();
        poseflag=false;
    }

    void Update()
    {
        if(startflag)
        { 
            if (timeController <= Bonus&&Trueflag)
            {
                Plusscore = HardQuestionAddScore + BonusScore;
            }
            else if(Trueflag)
            {
                Plusscore = HardQuestionAddScore;
            }
            if (timeController <= Bonus&&!Trueflag)
            {
                Plusscore = EasyQuestionAddScore + BonusScore;
            }
            else if(!Trueflag)
            {
                Plusscore = EasyQuestionAddScore;
            }
            if (timeController<=5)
            {
                BonusScore = 15;
                BonusJudge=1;
            }
            else
            {
                BonusScore=0;
                BonusJudge=0;
            }
            if(poseflag)
            {
                pose.SetActive(true);
            }
            else
            {
                pose.SetActive(false);
            }
            tmppluss=Plusscore;
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                FlagSwhitch(poseflag);
                poseflag = FlagSwhitch(poseflag);
            }

            if(!poseflag&& !TimeBarController.TimeUpFlag)
            { 
                timeController+=Time.deltaTime;
                  Checkflag=CheckButton.Check();

                if (OKflag)//間違いボタンを押した
                {
                    ClearCount += 1;
                    Totalscore += Plusscore;
                    TimeBarController.time += AddTime;
                    changeFlag = true;
                    FakeActivetrue();
                    FakeActivefalse();
                    ProblemRand();
                    Trueflag =false;
                    QuestionCount+=1;
                    BonusCount+=BonusJudge;

                    GetAllChildObject();

                }
                else if(Checkflag&&!OKflag)//間違いボタンを押してない時にチェックボタンを押した
                {
                    if (Trueflag)//本物だった
                    {
                        ClearCount += 1;
                        Totalscore += Plusscore;
                        TimeBarController.time += AddTime;
                        changeFlag = true;
                        NotFakeCount+=1;
                        BonusCount += BonusJudge;
                        FakeActivetrue();
                        FakeActivefalse();
                        ProblemRand();
                        Trueflag=false;
                        GetAllChildObject();
                    }
                    else//偽物だった
                    {
                        GameOver.GameSet=true;
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
        }
    }

    //fakeに置き換える抽選を行う関数
    private void GetAllChildObject()
    {
            
        ChildObject = new GameObject[GameManagement[problemrand].transform.childCount];
        //画像をそのまま表示するか、偽物も混ぜるかを抽選　現時点では5分の1でそのまま表示
        
        if(QuestionCount<10)
        {
            Qmax=1;
        }
        else
        {
            Qmax=0;
        }
        int a =Random.Range(1,11);
        if(a==10&&QuestionCount>=10)
        {
            Debug.Log("notfake");
            for (int n=0;n< GameManagement[problemrand].transform.childCount;n++)
            {
                ChildObject[n]= GameManagement[problemrand].transform.GetChild(n).gameObject;
                ChildObject[n].gameObject.SetActive(false);
                OKflag=false;

                AddTime=HardQuestionAddTime;
                timeController=0.0f;
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
            rnd = Random.Range(0, GameManagement[problemrand].transform.childCount-Qmax);
           // Debug.Log(rnd);
            ChildObject[rnd].SetActive(true);

            AddTime =EasyQuestionAddTime;
            timeController=0.0f;
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
         
        for(problemCount = 0; problemCount < Gamemanager.transform.childCount; problemCount++)
        {
            GameManagement[problemCount]=Gamemanager.transform.GetChild(problemCount).gameObject;
            GameManagement[problemCount].gameObject.SetActive(false);
        }
    }

    private void ProblemRand()
    {
        while(problemrand==tmprand)
        { 
            problemrand = Random.Range(0, problemCount);
        }
        tmprand=problemrand;
        for(int n = 0; n < Gamemanager.transform.childCount; n++)
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

    private bool FlagSwhitch(bool flag)

    {
        Debug.Log("呼ばれたyo");
        if(flag)
        {
            flag=false;
            Debug.Log("falseになりました");
        }
       else if(!flag)
        {
            flag=true;
            Debug.Log("trueになりました");
        }
        return flag;
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

    public static bool CheckFalse(bool flg)
    {
        if(flg)
        { flg=false;}
        return flg;
    }
     public static bool PoseFlag()
    {
        return poseflag;
    }
}
