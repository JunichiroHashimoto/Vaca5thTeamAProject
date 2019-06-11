using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFreePart : MonoBehaviour {



	// Use this for initialization
	void Start () {
        Initialize();
    }
	
	// Update is called once per frame
	void Update () {
	    	
	}

    void Initialize()
    {
        Debug.Log("MainFreePart; Initialize()");

        // 右のスクロールビューから花器、花を選ぶガイドを表示

        // スクロールビューを表示

    }

    // 判定ボタンが選択された時に呼ばれる
    public void OnClickJudgment()
    {
        Debug.Log("MainFreePart:OnClickJudgment()");

        AppManager.instance.ChangeResultPart();
    }
}
