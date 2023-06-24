using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RollingTitleImage : MonoBehaviour
{
    [SerializeField]GameObject Title;
    Vector2 pos;
    [SerializeField]int Speed=1000;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 StartPos=new Vector2(4200+1920,150+1080);
        Title.transform.position=StartPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (Title.transform.position.x <= -3180+960)
        {
            pos.x = 1940+1920;
        }
        else
        {

            pos = Title.transform.position;
        }
        pos.x-=Time.deltaTime*Speed;
        Title.transform.position=pos;
       
    }
}
