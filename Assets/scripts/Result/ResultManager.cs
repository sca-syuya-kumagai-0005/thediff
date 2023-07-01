using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ResultManager : MonoBehaviour
{
    [SerializeField]
    private Text TotalScoretext;
    // Start is called before the first frame update
    void Start()
    {
        TotalScoretext.text=ScoreCounter.TotalScore.ToString()+"–œ‰~";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
       SceneManager.LoadScene("TitleScene");
    }
}
