using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public ItemBox itemBox;

    public Ikebana ikebanaRoot;

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
        ikebanaRoot = GameObject.FindObjectOfType<Ikebana>();

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
        ClearIkebana();

        gameObject.AddComponent<MainFreePart>();

        Destroy(gameObject.GetComponent<MainGuidePart>());
    }

    // ガイドパートに戻る（デバッグ用）
    public void ChangeGuidePart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
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
    void ClearIkebana()
    {
        foreach(Transform ch in ikebanaRootObj.transform)
        {
            Destroy(ch.gameObject);
        }

        GameObject leftGrabObject = null;
        GameObject rightGrabObject = null;

        if (leftHandState.isFlowerGrabbing)
        {
            leftGrabObject = leftHandState.GetComponent<OVRGrabber>().grabbedObject.gameObject;
        }
        if (rightHandState.isFlowerGrabbing)
        {
            rightGrabObject = rightHandState.GetComponent<OVRGrabber>().grabbedObject.gameObject;
        }

        // 生けてない花を削除
        foreach (ItemObject itemObj in Resources.FindObjectsOfTypeAll<ItemObject>())
        {
            GameObject targetObj = itemObj.gameObject;
            // 手に持っていない花またはアイテムを削除
            if (leftGrabObject != targetObj && rightGrabObject != targetObj)
            {
                Destroy(itemObj.gameObject);
            }
        }
    }

}
