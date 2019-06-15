using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFreePart : MonoBehaviour {

    AppManager appManager;
    MessageManager msgManager;

    ItemBox itemBox;

    // Use this for initialization
    IEnumerator Start () {
        appManager = AppManager.instance;
        msgManager = MessageManager.instance;
        itemBox = appManager.itemBox;

        GuideItemBoxUsage();

        yield return new WaitForSeconds(10f);
        itemBox.gameObject.SetActive(true);

    }
	
	// Update is called once per frame
	void Update () {
	    	
	}

    void GuideItemBoxUsage()
    {

        Debug.Log("MainFreePart; Initialize()");

        // 右のスクロールビューから花器、花を選ぶガイドを表示
        msgManager.ChangeMessage("ここからは好きな花器・花材を選んで自由に生け花を" +
            "楽しんでください" +
            "右手側に表示されるリスト画面の中から素材を選んでください",0.5f);

        msgManager.ChangeMessage("コントローラーを右ボードの画像に向けると青い輪が表示されますでの" +
            "使いたい花の画像に向かって右手人差し指のトリガーを引いてください"+
            "目の前に表示される花が気に入ればそのまま手で掴んめます", 15f);


    }

    // 判定ボタンが選択された時に呼ばれる
    public void OnClickJudgment()
    {
        Debug.Log("MainFreePart:OnClickJudgment()");

        AppManager.instance.ChangeResultPart();
    }
}
