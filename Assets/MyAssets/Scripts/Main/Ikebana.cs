using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ikebana : MonoBehaviour {

    public GameObject kenzanObj;

    public List<GameObject> flowers = new List<GameObject>();

    AppManager appManager;

	// Use this for initialization
	void Start () {
        appManager = AppManager.instance;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PutFlower(GameObject flowerObj)
    {
        Debug.Log("Ikebana:PutFlower()");

        flowers.Add(flowerObj);
        appManager.PutFlower();

        /// 花を剣山の子に設定
        flowerObj.transform.SetParent(kenzanObj.transform);
    }
}
