using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFreePart : MonoBehaviour {

    AppManager appManager;
    MessageManager msgManager;

    ItemBox itemBox;

    // Use this for initialization
    void Start () {
        appManager = AppManager.instance;
        msgManager = MessageManager.instance;
        itemBox = appManager.itemBox;

        // アイテム選択スクロールビューを表示
        itemBox.gameObject.SetActive(true);

        // ガイドメッセージ表示
        GuideItemBoxUsage();

    }
	
	// Update is called once per frame
	void Update () {
	    	
	}

    void GuideItemBoxUsage()
    {

        Debug.Log("MainFreePart; Initialize()");

        // 右のスクロールビューから花器、花を選ぶガイドを表示
        msgManager.ChangeMessage("ここからは自由に生け花を楽しんでください\n\n" +
            "右手側のボードから好きな花器・花材を選んで使えます",0.5f);

        msgManager.ChangeMessage("コントローラーを、右側のボードに向けると\n" +
            "青いリングが表示されます\n" + 
            "使いたい花を選んで人差し指のトリガーを引いてください" +
            "花が目の前に現れますそのまま掴んで生けてください", 15f);

    }

    // 判定ボタンが選択された時に呼ばれる
    public void OnClickJudgment()
    {
        Debug.Log("MainFreePart:OnClickJudgment()");

        AppManager.instance.ChangeResultPart();
    }
}
