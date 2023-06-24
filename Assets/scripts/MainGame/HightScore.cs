using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HightScore : MonoBehaviour
{
    public int score;
    public int[] highScore;
    public int tmps;
    // Start is called before the first frame update
    void Start()
    {
        highScore=new int[6];
        for(int i=0;i<6;i++)
        {
            highScore[i]=0;
        }
        for(int i=0;i<6;i++)
        {
            highScore[0] = PlayerPrefs.GetInt("one");
            highScore[1] = PlayerPrefs.GetInt("two");
            highScore[2] = PlayerPrefs.GetInt("three");
            highScore[3] = PlayerPrefs.GetInt("four");
            highScore[4] = PlayerPrefs.GetInt("five");
            highScore[5] = PlayerPrefs.GetInt("now");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        highScore[5]=ScoreCounter.TotalScore;
        //PlayerPrefs.GetInt("now",highScore[5]);
        //var ranking=highScore.OrderBy(a=>-a);
    }
}
