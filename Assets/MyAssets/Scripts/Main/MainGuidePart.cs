using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainGuidePart : MonoBehaviour {

    AppManager appManager;
    MessageManager msgManager;
    FlowerPosGuide flowerGuide;

    GameObject sinFlower;
    GameObject soeFlower;
    GameObject hikaeFlower;

    GameObject guideHand;

    IEnumerator Start()
    {
        appManager = AppManager.instance;
        msgManager = MessageManager.instance;
        flowerGuide = FlowerPosGuide.instance;

        Initialize();

        yield return StartCoroutine(PutFlower());
    }

    void Initialize()
    {
        GameObject handPrefab = Resources.Load("Prefabs/Guide/GuideRHand") as GameObject;
        guideHand = Instantiate(handPrefab);

        guideHand.SetActive(false);

        // 花を机に用意
        Debug.Log("MainGuidePart:Initialize()");
    }

    IEnumerator PutFlower()
    {
        GuideStartPushButton();
        Debug.Log("ユーザーがボタンを押すのを待ちます");
        yield return (WaitPushAnyButton());

        GuideFirstGrabFlower();
        yield return new WaitForSeconds(3f);
        Debug.Log("ユーザーが最初の花を掴むのを待ちます");
        yield return (WaitFirstFlowerGrab());

        GuidePutFlowerPositionSin();
        Debug.Log("真の位置へ花が生けられるのを待ちます");
        yield return (WaitPutFlowerSin());

        GuidePutFlowerPositionSoe();
        Debug.Log("副えの位置へ花が生けられるのを待ちます");
        yield return (WaitPutFlowerSoe());

        GuidePutFlowerPositionHikae();
        Debug.Log("控えの位置へ花が生けられるのを待ちます");
        yield return (WaitPutFlowerHikae());

        Debug.Log("ガイド終了メッセージ、UI操作を待って次のフリー配置へ移行");
        //yield return (WaitUIOK());
        yield return new WaitForSeconds(3);

        GuideCongratulationsAndNextPart();

        yield return new WaitForSeconds(5f);
        yield return (WaitPushAnyButton());
        Debug.Log("フリー配置パートへ");
        appManager.ChangePartFree();

    }

    void GuideStartPushButton()
    {
        // ガイドテキスト表示
        msgManager.DisplayMessage("生け花VRへ ようこそ！\n\n" +
            "準備が良ければコントローラーのボタンを押してください");
    }

    // ガイド表示：最初の花を掴む 
    void GuideFirstGrabFlower()
    {
        // ガイドテキスト表示
        msgManager.ChangeMessage("表示されるガイドに沿ってお花の生け方\n"
            + "基本の「型」を体験してみましょう");
        msgManager.ChangeMessage("花に手を近づけて、親指と人差し指で摘むように\n"
            +"ボタンを押すと花を掴む事が出来ます", 6f);
    }

    // ガイド表示：真の位置の花を生ける
    void GuidePutFlowerPositionSin()
    {
        // 生ける位置の半透明ガイドを表示
        AppManager.DelayInvoke(flowerGuide.DisplaySin, 2f);

        msgManager.ChangeMessage("そうです、上手く掴めましたね", 0.3f);
        msgManager.ChangeMessage("ではその花を生けてみましょう",2f);
        msgManager.ChangeMessage("最初に一番長い枝を真ん中に生けます\n"
            + "10～15度程度傾けて配置します\n"
            + "生ける位置に透明なガイドが表示されています\n"
            + "そこで花を掴んでいる指を離してみましょう", 2f);

    }

    // ガイド表示：副えの位置の花を生ける
    void GuidePutFlowerPositionSoe()
    {
        // 生ける位置の半透明ガイドを表示
        AppManager.DelayInvoke(flowerGuide.DisplaySoe,3.3f);

        msgManager.ChangeMessage("上手に生けられましたね", 0.3f);
        msgManager.ChangeMessage("次に少し短めの枝を45度程度左に傾けて生けます\n"
            + "少し前傾になるよう立体的に配置しましょう", 3f);

    }

    // ガイド表示：控えの位置の花を生ける
    void GuidePutFlowerPositionHikae()
    {
        // 生ける位置の半透明ガイドを表示
        AppManager.DelayInvoke(flowerGuide.DisplayHikae, 3.3f);

        msgManager.ChangeMessage("お見事です！",0.3f);
        msgManager.ChangeMessage("では最後に今度は花を右に75度と\n大きく傾けて生けてみましょう", 3f);

    }

    void GuideCongratulationsAndNextPart()
    {
        msgManager.ChangeMessage("素晴らしい！あなたには素質があるかもしれません", 0.5f);
        msgManager.ChangeMessage("次は自由に花を生けてみましょう\n\n" +
            "準備が良ければコントローラーのボタンを押してください", 5f);
    }


    // ボタンが押されるのを待つ
    IEnumerator WaitPushAnyButton()
    {
        for (; ; )
        {
            if (OVRInput.GetDown(OVRInput.Button.One)
               || OVRInput.GetDown(OVRInput.Button.Two)
               || OVRInput.GetDown(OVRInput.Button.Three)
               || OVRInput.GetDown(OVRInput.Button.Four)
               || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)
               || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)
            )
            {
                yield break;
            }
            yield return null;
        }
    }

    // 最初の花を掴むのを待つ
    IEnumerator WaitFirstFlowerGrab()
    {
        yield return new WaitForSeconds(3f);
        // 花を掴むガイド（手）表示
        guideHand.SetActive(true);

        for ( ; ; )
        {
            if(appManager.isGrabbingFlower)
            {
                Debug.Log("最初の花が掴まれた");
                guideHand.SetActive(false);
                yield break;
            }
            yield return null;
        }

    }

    // 真の花を生けるのを待つ
    IEnumerator WaitPutFlowerSin()
    {

        appManager.PutWaitInit();
        for (;;)
        {
            if (appManager.isPut)
            {
                Debug.Log("真の花が生けられました");
                sinFlower = appManager.lastPutFlower;

                // 半透明ガイドを消去
                AppManager.DelayInvoke(flowerGuide.Hide, 0.2f);
                yield break;
            }
            yield return null;
        }
    }

    // 副えの花を生けるのを待つ
    IEnumerator WaitPutFlowerSoe()
    {
        appManager.PutWaitInit();
        for (;;)
        {
            if (appManager.isPut && appManager.lastPutFlower != sinFlower)
            {
                Debug.Log("副えの花が生けられました");
                soeFlower = appManager.lastPutFlower;

                // 半透明ガイドを消去
                AppManager.DelayInvoke(flowerGuide.Hide, 0.2f);
                yield break;
            }
            yield return null;
        }
    }

    // 控えの花を生けるのを待つ
    IEnumerator WaitPutFlowerHikae()
    {
        appManager.PutWaitInit();
        for (;;)
        {
            if (appManager.isPut && appManager.lastPutFlower != sinFlower && appManager.lastPutFlower != soeFlower)
            {
                Debug.Log("控えの花が生けられました");
                hikaeFlower = appManager.lastPutFlower;

                // 半透明ガイドを消去
                AppManager.DelayInvoke(flowerGuide.Hide, 0.2f);
                yield break;
            }
            yield return null;
        }
    }

}
