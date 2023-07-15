using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameObject[] Picture;
    [SerializeField]private float Interval=0;
    private float t=0;
    private int c=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Picture= PicturesChildren.Picture;
        t+=Time.deltaTime;
        if (Interval <= t)
        {
            t=0.0f;
            Instantiate(Picture[c], new Vector3(15.0f, 0.0f, 0.0f), Quaternion.identity);
            ++c;
            if (c == Picture.Length)
            {
                c=0;
            }
        }
    }
}
