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

        //������fake�̐��ƒ��I���ꂽfake�̐����������ƍs���鏈��

        if (OKflag)//�ԈႢ�{�^����������
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
        else if(Checkflag&&!OKflag)//�ԈႢ�{�^���������ĂȂ����Ƀ`�F�b�N�{�^����������
        {
            if (Trueflag)//�{��������
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
            else//�U��������
            {
                Debug.Log("����");
            }
            CheckFalse(changeFlag);
        }
        OKflag = fakebutton.OKJudge();



        ////������fake�̐����J�E���g����v���O����
        //else
        //{ 
        //    OKcountprovisional = fakebutton.OKCount();
        //    OKcount=OKcountprovisional;
        //    changeFlag=false;
        //}
    }

    //fake�ɒu�������钊�I���s���֐�
    private void GetAllChildObject()
    {
            
        ChildObject = new GameObject[GameManagement[problemrand].transform.childCount];
        //�摜�����̂܂ܕ\�����邩�A�U���������邩�𒊑I�@�����_�ł�5����1�ł��̂܂ܕ\��
        
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
        //�U����������悤�ɒ��I���ꂽ�ہA�ǂ̕�����u�������邩���I
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
    //�S�Ă�fake��SetActive(true)�ɕύX����֐�
    private void FakeActivetrue()
    {
        for (int n = 0; n < GameManagement[problemrand].transform.childCount; n++)
        {
            ChildObject[n] = GameManagement[problemrand].transform.GetChild(n).gameObject;
            ChildObject[n].gameObject.SetActive(true);
        }
    }
    //�S�Ă�fake��SetActive(false)�ɕύX����֐�
    private void FakeActivefalse()
    {
        for (int n = 0; n < GameManagement[problemrand].transform.childCount; n++)
        {
            ChildObject[n] = GameManagement[problemrand].transform.GetChild(n).gameObject;
            ChildObject[n].gameObject.SetActive(false);
        }
    }
    //�����i�[���Ă���֐�
    private void Problem()
    {
        //GameManagement�ɖ����i�[
         
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


    //���I�����l��illustManager�ɓn�����߂̊֐�
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
