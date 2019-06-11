using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Kenzan : MonoBehaviour {

    Ikebana ikebanaRoot;

	void Start () {
        ikebanaRoot = GetComponentInParent<Ikebana>();
        if (ikebanaRoot == null)
        {
            Debug.LogError("Ikebanaコンポーネントが見つかりませんでした");
        }
    }
	
    // TODO
    // 途中で剣山から抜いた時の処理を追加

    void OnTriggerStay(Collider other)
    {
        // 既に剣山に刺さっている花は処理しない
        if(ikebanaRoot.flowers.Contains(other.transform.parent.gameObject))
        {
            return;
        }


        if (other.transform.parent.gameObject.CompareTag(CommonDefine.TagFlower))
        {
            // 親が無い（Grabberが離されている）
            if (other.transform.parent.parent == null)
            {
                // 剣山を親に設定
                ikebanaRoot.PutFlower(other.transform.parent.gameObject);
            }
        }
    }

}
