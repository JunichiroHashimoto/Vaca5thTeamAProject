using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPosGuide : MonoBehaviour {

    [SerializeField]
    GameObject guideSin;
    [SerializeField]
    GameObject guideSoe;
    [SerializeField]
    GameObject guideHikae;

    public static FlowerPosGuide instance;

    void Awake()
    {
        instance = this;
    }

    public void DisplaySin()
    {
        guideSin.SetActive(true);
        guideSoe.SetActive(false);
        guideHikae.SetActive(false);
    }

    public void DisplaySoe()
    {
        guideSin.SetActive(false);
        guideSoe.SetActive(true);
        guideHikae.SetActive(false);
    }

    public void DisplayHikae()
    {
        guideSin.SetActive(false);
        guideSoe.SetActive(false);
        guideHikae.SetActive(true);
    }

    public void Hide()
    {
        guideSin.SetActive(false);
        guideSoe.SetActive(false);
        guideHikae.SetActive(false);
    }

}
