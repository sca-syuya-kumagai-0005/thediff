using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number1 : MonoBehaviour
{
    [SerializeField]
    private int num;
    [SerializeField]
    private GameObject[] Numbers;
    // Start is called before the first frame update
    void Start()
    {
        Numbers = new GameObject[this.transform.childCount];
        for (int i = 0; i < this.transform.transform.childCount; i++)
        {
            Numbers[i] = this.transform.GetChild(i).gameObject;
            Numbers[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        num = ScoreCounter.Score[1];
        for (int i = 0; i < this.transform.childCount; i++)
        {
            if (num == i)
            {
                Numbers[i].SetActive(true);
            }
            else
            {
                Numbers[i].SetActive(false);
            }
        }
    }

}
