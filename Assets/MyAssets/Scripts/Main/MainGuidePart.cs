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
        Resources.UnloadAsset(handPrefab);

        guideHand.SetActive(false);

        // 花を机に用意
        Debug.Log("MainGuidePart:Initialize()");
    }

    IEnumerator PutFlower()
    {
        GuideFirstGrabFlower();
        yield return new WaitForSeconds(15f);
        Debug.Log("ユーザーが最初の花を掴むのを待ちます");
        yield return (WaitFirstFlowerGrab());

        GuidePutFlowerPositionSin();
        Debug.Log("真の位置へ花が生けられるのを待ちます");
        yield return (WaitPutFlowerSin());


        GuidePutFlowerPositionSoe();
        Debug.Log("副えの位置へ花が生けられるのを待ちます");
        yield return (WaitPutFlowerSoe());


        GuidePutFlowerPositionHikae();
        Debug.Log("副えの位置へ花が生けられるのを待ちます");
        yield return (WaitPutFlowerHikae());

        Debug.Log("ガイド終了メッセージ、UI操作を待って次のフリー配置へ移行");
        //yield return (WaitUIOK());
        yield return new WaitForSeconds(3);

        GuideCongratulationsAndNextPart();

        yield return new WaitForSeconds(10);
        yield return (WaitGoFreePart());
        Debug.Log("フリー配置パートへ");
        appManager.ChangePartFree();

    }

    // ガイド表示：最初の花を掴む 
    void GuideFirstGrabFlower()
    {
        // ガイドテキスト表示
        msgManager.DisplayMessage("これから表示されるガイドに沿って\n"
            + "基本的なお花の生け方を体験してみましょう");
        msgManager.ChangeMessage("花に手を近づけて親指と人差し指で摘むように\n"
            +"コントローラーのボタンを押すと花を掴む事が出来ます", 15f);
    }

    // ガイド表示：真の位置の花を生ける
    void GuidePutFlowerPositionSin()
    {
        msgManager.ChangeMessage("そうです、上手く掴めましたね",0.3f);
        msgManager.ChangeMessage("最初に一番長い枝を真ん中に生けます\n"
            + "10～15度程度傾けて配置します\n"
            + "筒状の透明なガイドの位置で\n"
            + "花を掴んでいる指を離してみましょう", 3f);

    }

    // ガイド表示：副えの位置の花を生ける
    void GuidePutFlowerPositionSoe()
    {
        msgManager.ChangeMessage("上手に生けられましたね", 0.3f);
        msgManager.ChangeMessage("次に少し短めの枝を45度程度左に傾けて生けます\n"
            + "少し前傾になるよう立体的に配置しましょう", 5f);

    }

    // ガイド表示：控えの位置の花を生ける
    void GuidePutFlowerPositionHikae()
    {
        msgManager.ChangeMessage("お見事です！", 3f);
        msgManager.ChangeMessage("では最後に今度は花を右に75度と\n大きく傾けて生けてみましょう", 5f);

    }

    void GuideCongratulationsAndNextPart()
    {
        msgManager.ChangeMessage("素晴らしい！あなたには素質があるかもしれません", 0.5f);
        msgManager.ChangeMessage("しばらく出来映えを眺めたら、次は自由に花を\n" +
            "生けてみましょう" +
            "次のパートへ進むにはコントローラーのボタンを押してください", 5f);
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
        yield return new WaitForSeconds(3f);
        // 生ける位置の半透明ガイドを表示
        flowerGuide.DisplaySin();

        appManager.PutWaitInit();
        for (;;)
        {
            if (appManager.isPut)
            {
                Debug.Log("真の花が生けられました");
                sinFlower = appManager.lastPutFlower;
                yield break;
            }
            yield return null;
        }
    }

    // 副えの花を生けるのを待つ
    IEnumerator WaitPutFlowerSoe()
    {
        yield return new WaitForSeconds(3f);
        // 生ける位置の半透明ガイドを表示
        flowerGuide.DisplaySoe();

        appManager.PutWaitInit();
        for (;;)
        {
            if (appManager.isPut && appManager.lastPutFlower != sinFlower)
            {
                Debug.Log("副えの花が生けられました");
                soeFlower = appManager.lastPutFlower;
                yield break;
            }
            yield return null;
        }
    }

    // 控えの花を生けるのを待つ
    IEnumerator WaitPutFlowerHikae()
    {
        yield return new WaitForSeconds(3f);
        // 生ける位置の半透明ガイドを表示
        flowerGuide.DisplayHikae();

        appManager.PutWaitInit();
        for (;;)
        {
            if (appManager.isPut && appManager.lastPutFlower != sinFlower && appManager.lastPutFlower != soeFlower)
            {
                Debug.Log("控えの花が生けられました");
                hikaeFlower = appManager.lastPutFlower;

                // 半透明ガイドを消去
                flowerGuide.Hide();
                yield break;
            }
            yield return null;
        }
    }

    // 次のパートへ進むボタンが押されるのを待つ
    IEnumerator WaitGoFreePart()
    {
        for (;;)
        {
            if(OVRInput.GetDown(OVRInput.Button.Any))
            {
                yield break;
            }
            yield return null;
        }
    }
}
