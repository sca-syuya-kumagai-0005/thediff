using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pose : MonoBehaviour
{
    [SerializeField]
    private bool pose;
    [SerializeField]
    private GameObject feedpanel;
    [SerializeField]
    private GameObject feedPanel;
    Image feedAlpha;
    Image feedalpha;
    [SerializeField]
    private float alpha=0;
    private float Alpha=0;
    // Start is called before the first frame update
    void Start()
    {
        feedalpha=feedpanel.GetComponent<Image>();
        feedAlpha=feedPanel.GetComponent<Image>();
    }

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        pose=GameManager.poseflag;
            posefeed();
    }

    void posefeed()
    {
        if(pose)
        {
            alpha=0.8f;

            feedalpha.color=new Color(0.0f,0.0f,0.0f,alpha);
            Alpha=1;
            feedAlpha.color=new Color(0.0f, 0.0f, 0.0f, Alpha);
        }
        if(!pose)
        {
            alpha=0;
            feedalpha.color=new Color(0.0f,0.0f,0.0f,alpha);
            feedAlpha.color = new Color(0.0f, 0.0f, 0.0f, Alpha);
            Alpha =0;
            alpha=0.0f;
        }
    }

    public void OnclickResume()
    {
       GameManager.poseflag=false;
    }

    public void OnclickTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
