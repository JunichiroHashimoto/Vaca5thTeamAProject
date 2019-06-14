using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ikebana : MonoBehaviour {

    public Transform kenzanTrans;
    public Transform flowerVaseTrans;

    public List<GameObject> flowers = new List<GameObject>();

    AppManager appManager;
    OVRGrabbable kenzanGrabbable;

    void Start()
    {
        appManager = AppManager.instance;
        kenzanGrabbable = kenzanTrans.GetComponent<OVRGrabbable>();
    }

    void Update()
    {
        // 剣山オブジェクトがOVRGrabberで掴んだ事によって親子階層が外れてしまっていたら子に戻す
        if(kenzanTrans.parent == null && !kenzanGrabbable.isGrabbed)
        {
            kenzanTrans.SetParent(this.transform);
        }
    }

    public void PutFlower(GameObject flowerObj)
    {
        Debug.Log("Ikebana:PutFlower()");

        flowers.Add(flowerObj);
        appManager.PutFlower(flowerObj);

        // 花を剣山の子に設定
        flowerObj.transform.SetParent(kenzanTrans);
    }

    public void PullOutFlower(GameObject flowerObj)
    {
        Debug.Log("Ikebana:PullOutFlower()");

        if(flowers.Contains(flowerObj))
        {
            flowers.Remove(flowerObj);
        }
        appManager.PutFlower(flowerObj);

        // もし何らかの理由で剣山が親のままだったら親設定を解除する
        // 通常はハンドコントローラーの操作で掴んで抜く時にコントローラーと親子階層になっているはず
        if(flowerObj.transform.parent == kenzanTrans)
        {
            Debug.Log("Ikebana:PullOutFlower() SetParent(null)");
            flowerObj.transform.parent.SetParent(null);
        }
    }
}
