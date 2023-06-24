using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckButton : MonoBehaviour
{
    public static bool Checkflag;

    //int f=0;

    // Start is called before the first frame update

    void Start()
    {
    }

    public static bool Check()
    {
        return Checkflag;
    }

    // Update is called once per frame
    void Update()
    {
        if (Checkflag)
        {
            //f++;
            //if (f == 1)
            //{
                //f=0;
                Checkflag = false;
            //}
        }
    }

     void OnClick()
    {
        Checkflag = true;
    }

}
