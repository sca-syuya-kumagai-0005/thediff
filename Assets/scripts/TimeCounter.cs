using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    [SerializeField]private float time=6000;
    [SerializeField]Text Timer;
    int t;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time-=Time.deltaTime;
        t=(int)time;
    }
}
