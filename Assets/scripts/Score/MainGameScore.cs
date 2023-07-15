using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameScore : MonoBehaviour
{
    [SerializeField]
    Text Under;
    [SerializeField]
    Text Over;
    int totalScore;
    int UnderScore;
    int OverScore=0;
    // Start is called before the first frame update
    void Start()
    {
        Over.text="";
    }

    // Update is called once per frame
    void Update()
    {
        totalScore=(int)GameManager.Totalscore;
        UnderScore=totalScore-(OverScore*10000);
        if(UnderScore>=10000)
        {
            UnderScore-=10000;
            OverScore++;
        }
        Under.text=UnderScore.ToString();
        if(OverScore!=0)
        Over.text=OverScore.ToString();
    }
}
