using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePicture : MonoBehaviour
{
    private int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed=PicturesChildren.s;
        this.gameObject.transform.Translate(new Vector3(-speed * Time.deltaTime, 0));
        if (this.gameObject.transform.position.x <= -15.0)
        {
            Destroy(this.gameObject);
        }
    }
}
