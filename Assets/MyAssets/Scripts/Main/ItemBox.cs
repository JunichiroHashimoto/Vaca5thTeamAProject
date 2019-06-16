using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemBox : MonoBehaviour {


    [SerializeField]
    GameObject nodePrefab;
    [SerializeField]
    Transform nodeParent;
    [SerializeField]
    GameObject showCase;

    Camera playerCamera;

    void Start()
    {
        var player = GameObject.FindObjectOfType<OVRSceneSampleController>();
        playerCamera = player.GetComponentInChildren<Camera>();
    }

    // アイテムリスト（スクロールビュー要素）作成
    public void SetItemList(Dictionary<int, ItemBase> itemDict)
    {
        foreach (var item in itemDict)
        {
            // リストの親要素の下に複製
            var node = Instantiate(nodePrefab, nodeParent);
            // アイテムデータから名称、画像ファイル等設定
            node.GetComponentInChildren<TextMeshProUGUI>().text = item.Value.jpName;
            // アイテム画像ファイル名：アイテムID.png
            node.GetComponent<Image>().sprite = Resources.Load("Images/" + item.Value.id.ToString(), typeof(Sprite)) as Sprite;
            node.GetComponent<ItemBoxNode>().itemData = item.Value;
        }

        // スクロールビュー初期位置設定
        nodeParent.GetComponentInParent<ScrollRect>().horizontalNormalizedPosition = 0;
    }

    // 指定のアイテム（３Dオブジェクト）を表示する
    public void DisplayItem(GameObject itemObj)
    {
        foreach (Transform ch in showCase.transform)
        {
            Destroy(ch.gameObject);
        }
        itemObj.transform.SetParent(showCase.transform);

        // プレイヤーの前、手の届く位置ぐらいに出現させる
        Debug.Log(playerCamera.transform.position);

        //itemObj.transform.position = playerCamera.transform.position
        //                            + playerCamera.transform.forward * 0.7f
        //                            - playerCamera.transform.up * 0.2f
        //                            + itemObj.transform.localPosition;
        itemObj.transform.localPosition = Vector3.zero;
        itemObj.transform.position
            = new Vector3(
                showCase.transform.position.x,
                showCase.transform.position.y,
                playerCamera.transform.position.z
            );
    }

}
