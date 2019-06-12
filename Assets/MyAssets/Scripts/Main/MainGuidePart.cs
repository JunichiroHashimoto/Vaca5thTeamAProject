using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainGuidePart : MonoBehaviour {

    AppManager appManager;
    MessageManager msgManager;

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

        Debug.Log("真待ち");
        yield return (WaitPutFlowerSin());
        Debug.Log("副え待ち");
        yield return (WaitPutFlowerSoe());
        Debug.Log("控え待ち");
        yield return (WaitPutFlowerHikae());

        Debug.Log("ガイド終了メッセージ、UI操作を待って次のフリー配置へ移行");
        //yield return (WaitUIOK());
        yield return new WaitForSeconds(3);

        Debug.Log("フリー配置へ");
        appManager.ChangePartFree();

    }

    void GuideFirstGrabFlower()
    {
        // ガイドテキスト表示
        msgManager.DisplayMessage("花を取って机の上の花器に花を生けてみましょう");
        msgManager.ChangeMessage("ガイドにそって花を生けていってください", 6f);
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
        for (; ; )
        {
            if (appManager.isPut)
            {
                yield break;
            }
            yield return null;
        }
    }

    // 副えの花を生けるのを待つ
    IEnumerator WaitPutFlowerSoe()
    {
        appManager.PutWaitInit();
        for (; ; )
        {
            if (appManager.isPut)
            {
                yield break;
            }
            yield return null;
        }
    }

    // 控えの花を生けるのを待つ
    IEnumerator WaitPutFlowerHikae()
    {
        appManager.PutWaitInit();
        for (; ; )
        {
            if (appManager.isPut)
            {
                yield break;
            }
            yield return null;
        }
    }
}
