using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicturesChildren: MonoBehaviour
{
    [SerializeField]private int speed;
    public static int s;
    public static GameObject[] Picture;

    [SerializeField]private GameObject Pictures;
    private int ChildCount;
    // Start is called before the first frame update
    void Start()
    {
        ChildCount=this.transform.childCount;
        Picture=new GameObject[ChildCount];
        for (int i = 0; i < ChildCount; ++i)
        {
            Picture[i] = Pictures.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
       s=speed;
    }
}
