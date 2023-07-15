using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    [SerializeField] public GameObject rulemage;
    [SerializeField] public GameObject backButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Onclick()
    {
        rulemage.SetActive(false);
        backButton.SetActive(false);
    }
}
