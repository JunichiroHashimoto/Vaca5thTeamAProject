using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Kenzan : MonoBehaviour {

    Ikebana ikebanaRoot;
    bool isGrabEnter = false;

	void Start () {
        ikebanaRoot = GetComponentInParent<Ikebana>();
        if (ikebanaRoot == null)
        {
            // フリーパートで剣山を選択した時はこちら
            ikebanaRoot = AppManager.instance.ikebanaRoot;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // 花オブジェクト以外は処理しない
        if ( !other.transform.parent.gameObject.CompareTag(CommonDefine.TagFlower) )
        {
            return;
        }

        if(other.transform.parent.GetComponent<OVRGrabbable>().isGrabbed)
        {
            Debug.Log("isGrabEnter = true");
            isGrabEnter = true;
        }

    }

    void OnTriggerStay(Collider other)
    {
        // 花オブジェクト以外は処理しない
        if ( !other.transform.parent.gameObject.CompareTag(CommonDefine.TagFlower) )
        {
            return;
        }

        // 既に剣山に刺さっている花は処理しない
        if (ikebanaRoot.flowers.Contains(other.transform.parent.gameObject))
        {
            return;
        }

        other.transform.parent.GetComponent<Rigidbody>().isKinematic = true;

        if (other.transform.parent.gameObject.CompareTag(CommonDefine.TagFlower))
        {
            // 親が無い（Grabberが離されている）
            if (other.transform.parent.parent == null)
            {
                // 剣山を親に設定
                ikebanaRoot.PutFlower(other.transform.parent.gameObject);
                isGrabEnter = false;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // 花オブジェクト以外は処理しない
        if (!other.transform.parent.gameObject.CompareTag(CommonDefine.TagFlower))
        {
            return;
        }

        // ↓OVRGrabber側で掴んでる間、isKinematicをTrueにして離すとfalseになるようになっているので
        // 余計な事はしない
        //if (other.transform.parent.GetComponent<Rigidbody>().isKinematic)
        //{
        //    Debug.Log("isKinematic true -> false");
        //    other.transform.parent.GetComponent<Rigidbody>().isKinematic = false;
        //}

        // 花を掴んだまま剣山に抜き差ししても、「抜いた」という処理はしない
        if (!isGrabEnter)
        {
            ikebanaRoot.PullOutFlower(other.transform.parent.gameObject);
        }

    }

}
