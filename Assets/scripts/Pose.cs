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
    Image feedalpha;
    [SerializeField]
    private float alpha=0;
    [SerializeField]
    private GameObject IllustFeedPanel;
    // Start is called before the first frame update
    void Start()
    {
        feedalpha=feedpanel.GetComponent<Image>();
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
            IllustFeedPanel.SetActive(true);
            alpha=0.8f;
            feedalpha.color=new Color(0.0f,0.0f,0.0f,alpha);
            alpha=1.0f;
        }
        if(!pose)
        {
            IllustFeedPanel.SetActive(false);
            alpha=0;
            feedalpha.color=new Color(0.0f,0.0f,0.0f,alpha);
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
