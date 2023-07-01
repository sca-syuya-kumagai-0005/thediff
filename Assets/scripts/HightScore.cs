using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HightScore : MonoBehaviour
{
    [SerializeField]
    private int[] HighScore = new int[6];
    private bool firstF = false;
    [SerializeField]
    private string[] data = new string[6];
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<5;i++)
        {
            PlayerPrefs.SetInt(data[i],HighScore[i]);
        }
        for(int i=0;i<5;i++)
        {
            HighScore[i]=PlayerPrefs.GetInt(data[i]);
        }
    }

    void Update()
    {
        HighScore[5] = ScoreCounter.TotalScore;
        if (Input.GetKeyDown(KeyCode.Return))
        { 
                sort();
        }
    }


    void sort()
    {
        int n = 0;
        for (int i = 5; i > 0; i--)
        {
            n++;
            Debug.Log("ŒÄ‚Î‚ê‚½‚¨");
            if (HighScore[i] > HighScore[5-n])
            {
                int tmpscore = HighScore[5-n];
                HighScore[5-n] = HighScore[i];
                HighScore[i] = tmpscore;
            }
           
        }
        for(int i=0;i<5;i++)
        {
            PlayerPrefs.SetInt(data[i],HighScore[i]);
        }
    }
}
