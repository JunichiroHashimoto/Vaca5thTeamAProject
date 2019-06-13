using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour {

    public static AppManager instance;

    bool _isPut = false;
    public bool isPut
    {
        get
        {
            return _isPut;
        }
    }

    [SerializeField]
    HandState leftHandState;
    [SerializeField]
    HandState rightHandState;

    [SerializeField]
    GameObject ikebanaRootObj;

    public bool isGrabbingFlower
    {
        get
        {
            return leftHandState.isFlowerGrabbing || rightHandState.isFlowerGrabbing;
        }
    }

    public GameObject lastPutFlower { get; private set; }

    void Awake()
    {
        instance = this;
    }


    void Start()
    {
        StartGuidePart();
    }

    // ガイドパート開始
    void StartGuidePart()
    {
        gameObject.AddComponent<MainGuidePart>();
    }

    // フリー配置へ移行
    public void ChangePartFree()
    {
        ClearIkebanaWithVase();

        gameObject.AddComponent<MainFreePart>();

        Destroy(gameObject.GetComponent<MainGuidePart>());
    }

    // 結果表示へ移行
    public void ChangeResultPart()
    {

        gameObject.AddComponent<MainResultPart>();

        Destroy(gameObject.GetComponent<MainFreePart>());
    }



    public void PutWaitInit()
    {
        _isPut = false;
    }

    public void PutFlower(GameObject flowerObj)
    {
        _isPut = true;
        lastPutFlower = flowerObj;
    }

    // 生け花を花器毎削除
    void ClearIkebanaWithVase()
    {
        foreach(Transform ch in ikebanaRootObj.transform)
        {
            Destroy(ch.gameObject);
        }
    }

}
