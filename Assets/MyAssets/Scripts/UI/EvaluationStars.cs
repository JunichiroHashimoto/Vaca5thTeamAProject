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
        if (starsNum <= 0)
        {
            for (int i = 0; i < starsNum; i++)
            {
                GameObject ball = Instantiate(starPrefab) as GameObject;
                ball.transform.position = new Vector3(i, 0, 0);
            }
        }

        if (starsNum == 3)
        {
            for (int i = 0; i < starsNum; i++)
            {
                GameObject ball = Instantiate(starPrefab) as GameObject;
                ball.transform.position = new Vector3(i, 0, 0);
            }
        }

        if (starsNum == 4)
        {
            for (int i = 0; i < starsNum; i++)
            {
                GameObject ball = Instantiate(starPrefab) as GameObject;
                ball.transform.position = new Vector3(i, 0, 0);
            }
        }

        if (starsNum == 5)
        {
            for (int i = 0; i < starsNum; i++)
            {
                GameObject ball = Instantiate(starPrefab) as GameObject;
                ball.transform.position = new Vector3(i, 0, 0);
            }
        }
    }
}
