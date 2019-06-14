using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFreePart : MonoBehaviour {

    AppManager appManager;
    MessageManager msgManager;

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
        msgManager.ChangeMessage("ここからは好きな花器・花材を選んで自由に生け花を" +
            "楽しんでください" +
            "右手のリスト画面の中からアイテムを選んでください",0.5f);

        // スクロールビューを表示

    }

    // 判定ボタンが選択された時に呼ばれる
    public void OnClickJudgment()
    {
        Debug.Log("MainFreePart:OnClickJudgment()");

        AppManager.instance.ChangeResultPart();
    }
}
