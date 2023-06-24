using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static bool GameSet ;
    // Update is called once per frame
    void Update()
    {
        Debug.Log(GameSet);
        if(GameSet)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
