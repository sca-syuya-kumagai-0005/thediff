using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ResultManager : MonoBehaviour
{
    [SerializeField]
    private Text TotalScoretext;
    [SerializeField]
    private Text Bonustext;//3
    [SerializeField]
    private Text NotFakeScoretext;//2
    [SerializeField]
    private Text Questiontext;//1
    [SerializeField]
    private float WaitTime;
    [SerializeField]
    private float t;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Result());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
       SceneManager.LoadScene("TitleScene");
    }

    IEnumerator Result()
    {
        Questiontext.text=(GameManager.QuestionCount*1).ToString();
        if(GameManager.NotFakeCount!=0)
        {
            yield return new WaitForSeconds(WaitTime);
            NotFakeScoretext.text=(GameManager.NotFakeCount*8).ToString();
        }
        if(GameManager.BonusCount!=0)
        {
            yield return new WaitForSeconds(WaitTime);
            Bonustext.text=(GameManager.BonusCount*15).ToString();
        }
        yield return new WaitForSeconds(WaitTime);
        TotalScoretext.text = ScoreCounter.TotalScore.ToString();
    }
}
