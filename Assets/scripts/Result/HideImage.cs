using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideImage : MonoBehaviour
{
    //Images
    [SerializeField]
    GameObject _TotalHide;//合計金額の億を隠しているイメージ

    [SerializeField]
    GameObject _5secondsHide;//5秒以内ボーナスを隠しているイメージ
    [SerializeField]
    GameObject _5seconds10000;
    [SerializeField]
    Text _5secondsText;
    int _5secondsCount;

    [SerializeField]
    GameObject _RealHide;//本物の仕分けを隠しているイメージ
    [SerializeField]
    GameObject _Real10000;
    int _RealCount;

    [SerializeField]
    GameObject _Question10000;
    int _QuestionCount;

    //texts

    [SerializeField]
    float waitTime;


    int TotalScore;
    int OverTotal;
    int UnderTotal;
    [SerializeField]
    Text _UnderTotalText;
    [SerializeField]
    Text _OverTotalText;

    int BonusScore=0;
    int OverBonus=0;
    int UnderBonus=0;
    [SerializeField]
    Text _UnderBonusText;
    [SerializeField]
    Text _OverBonusText;

    int NotFakeScore=0;
    int OverNotFake=0;
    int UnderNotFake=0;
    [SerializeField]
    Text _UnderNotFakeText;
    [SerializeField]
    Text _OverNotFakeText;


    int QuestionScore=0;
    int OverQuestion=0;
    int UnderQuestion=0;
    [SerializeField]
    Text _UnderQuestionText;
    [SerializeField]
    Text _OverQuestionText;
    // Start is called before the first frame update
    void Start()
    {
        _QuestionCount=0;
        _RealCount=0;
        _5secondsCount=0;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.BonusCount!=0)
        {
            _5secondsHide.SetActive(false);
        }
        if(GameManager.Totalscore>=10000)
        {
            _TotalHide.SetActive(false);
        }
        if(GameManager.NotFakeCount!=0)
        {
            _RealHide.SetActive(false); 
        }
        StartCoroutine(Score());
       



    }

    void score(int Score,int GMScore,int UnderScore,int OverScore,Text Under,Text Over,GameObject obj)
    {
        Score = GMScore;
        if(Score!=0)
        { 
            UnderScore = Score - (OverScore * 10000);
        }
        if (UnderScore >= 10000)
        {
            UnderScore -= 10000;
            OverScore++;
        }
        Under.text = UnderScore.ToString();
        if (OverScore != 0)
        { 
            Over.text = OverScore.ToString();
            obj.SetActive(true);
        }
        else
            Over.text="";
    }
    IEnumerator Score()
    {
        score(QuestionScore, GameManager.QuestionCount, UnderQuestion, OverQuestion, _UnderQuestionText, _OverQuestionText, _Question10000);
        yield return new WaitForSeconds(waitTime);
        if (GameManager.NotFakeCount != 0)
            score(NotFakeScore, GameManager.NotFakeCount * 8, UnderNotFake, OverNotFake, _UnderNotFakeText, _OverNotFakeText, _Real10000);
        yield return new WaitForSeconds(waitTime);
        if (GameManager.BonusCount != 0)
            score(BonusScore, GameManager.BonusCount * 15, UnderBonus, OverBonus, _UnderBonusText, _OverBonusText, _5seconds10000);//BonusScore;
        yield return new WaitForSeconds(waitTime);
        score(TotalScore, GameManager.Totalscore, UnderTotal, OverTotal, _UnderTotalText, _OverTotalText, null);//TotalScore
    }

}
