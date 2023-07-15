using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBarController : MonoBehaviour
{
    [SerializeField] Image WhiteBar;
    [SerializeField] Image RedBar;
    [SerializeField] Image GreenBar;

    [SerializeField] Image Smile;
    [SerializeField] Image Impatience;

    public static bool TimeUpFlag;
    public static float time;


    [SerializeField] float Maxtime=45.0f;

    // Start is called before the first frame update
    void Start()
    {
        time=Maxtime;
        TimeUpFlag=false;
    }

    // Update is called once per frame
    void Update()
    {
       
        if(GameManager.startflag)
        { 
            if (!GameManager.poseflag)
                time -= Time.deltaTime;
            if (time > Maxtime)
            {
                time = Maxtime;
            }
            RedBar.fillAmount = time / Maxtime;
            if (Maxtime / 4 >= time)
            {
                GreenBar.fillAmount=0;
                Smile.fillAmount=0;
            }
            else
            {
                GreenBar.fillAmount = time / Maxtime;
                Smile.fillAmount=1;
            }
            if(time<=0)
            {
                time=0;
                TimeUpFlag=true;
                GameOver.GameSet=true;
                time = Maxtime;
            }
        }
    }
   
}
