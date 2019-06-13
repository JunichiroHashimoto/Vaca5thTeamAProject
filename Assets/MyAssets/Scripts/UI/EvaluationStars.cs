using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvaluationStars : MonoBehaviour
{
    public GameObject starPrefab;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    void Evaluation_flower(int starsNum)
    {
        GameObject starObj = (GameObject)Resources.Load("star");
        GameObject No_starObj = (GameObject)Resources.Load("No_star");
       
        float x = 0;
        int minu_point = 5 - starsNum;

        for (int i = 0; i < starsNum; i++)
        {
            x += 2.5f;
            Instantiate(starObj, new Vector3(x, 2.0f, 0.0f), Quaternion.identity);
        }

        for (int i = 0; i < minu_point; i++)
        {
            x += 2.5f;
            Instantiate(No_starObj, new Vector3(x, 2.0f, 0.0f), Quaternion.identity);
        }

    }
}
