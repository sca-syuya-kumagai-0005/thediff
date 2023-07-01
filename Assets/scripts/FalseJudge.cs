using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseJudge : MonoBehaviour
{
    
    public void OnClick()
    {
        if(!GameManager.poseflag)
        TimeBarController.time-=5;
        if(GameManager.Trueflag) {
            Debug.Log("‘¦Ž€");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
