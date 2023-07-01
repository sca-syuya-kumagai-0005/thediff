using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Number0 : MonoBehaviour
{
    public static int TotalScore = 0;
    int Contents = 0;
    [SerializeField] Text SCORE;
    public static int[] Score = new int[8];

    bool millionflag = false;
    [SerializeField]
    GameObject[] Number;//-1~9を格納
    [SerializeField]
    GameObject Numbers;
    [SerializeField]
    GameObject[] Numberschild;

    //int Contents

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            if (i == 0) Score[0] = 0;
            else Score[i] = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Score[0]);
        if (Score[4] >= 0) SCORE.text = "億　　　万";
        else SCORE.text = "　　　　万";

        if ((int)GameManager.Totalscore > TotalScore)
        {
            if (TotalScore >= 99999999)
            {
                TotalScore = 99999999;
            }
            TotalScore += 1;
            Score[0] += 1;

            for (int i = 0; i < 8; i++)
            {
                if (Score[i] >= 10)
                {

                    if (Score[i + 1] <= -1)
                    {
                        Score[i + 1] = 0;
                    }
                    Score[i] = 0;
                    Score[i + 1] += 1;
                }
            }
        }
        //Score=TotalScore.ToString().ToCharArray();


    }
}
