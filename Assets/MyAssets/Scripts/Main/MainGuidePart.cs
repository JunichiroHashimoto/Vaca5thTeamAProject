using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainGuidePart : MonoBehaviour {

    AppManager appManager;
    MessageManager msgManager;

    GameObject sinFlower;
    GameObject soeFlower;
    GameObject hikaeFlower;

    IEnumerator Start()
    {
        appManager = AppManager.instance;
        msgManager = MessageManager.instance;

        Initialize();

        yield return StartCoroutine(PutFlower());

    }

    void Initialize()
    {
        // 花を机に用意
        Debug.Log("MainGuidePart:Initialize()");
    }

    IEnumerator PutFlower()
    {
        GuideFirstGrabFlower();

        yield return (WaitFirstFlowerGrab());

        Debug.Log("真の位置へ花が生けられるのを待ちます");
        yield return (WaitPutFlowerSin());
        Debug.Log("副えの位置へ花が生けられるのを待ちます");
        yield return (WaitPutFlowerSoe());
        Debug.Log("副えの位置へ花が生けられるのを待ちます");
        yield return (WaitPutFlowerHikae());

        Debug.Log("ガイド終了メッセージ、UI操作を待って次のフリー配置へ移行");
        //yield return (WaitUIOK());
        yield return new WaitForSeconds(3);

        Debug.Log("フリー配置パートへ");
        appManager.ChangePartFree();

    }

    void GuideFirstGrabFlower()
    {
        // ガイドテキスト表示
        msgManager.DisplayMessage("花を手に取って花器に花を生けてみましょう");
        msgManager.ChangeMessage("ガイドにそって花を生けて見ましょう", 6f);
    }


    // 最初の花を掴むのを待つ
    IEnumerator WaitFirstFlowerGrab()
    {
        for( ; ; )
        {
            if(appManager.isGrabbingFlower)
            {
                Debug.Log("最初の花をが掴まれた");
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
                yield break;
            }
            yield return null;
        }
    }
}
