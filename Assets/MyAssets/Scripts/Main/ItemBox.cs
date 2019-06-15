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

    public void SetItemList(Dictionary<int, ItemBase> itemDict)
    {
        foreach (var item in itemDict)
        {
            // リストの親要素の下に複製
            var node = Instantiate(nodePrefab, nodeParent);
            // アイテムデータから名称、画像ファイル等設定
            node.GetComponentInChildren<TextMeshProUGUI>().text = item.Value.jpName;
            // アイテムID をファイル名.png としてResourcesフォルダのImagesフォルダに保存
            node.GetComponent<Image>().sprite = Resources.Load("Images/" + item.Value.id.ToString(), typeof(Sprite)) as Sprite;
            node.GetComponent<ItemBoxNode>().itemData = item.Value;
        }
    }

    public void DisplayItem(GameObject itemObj)
    {
        foreach(Transform ch in showCase.transform)
        {
            Destroy(ch.gameObject);
        }
        itemObj.transform.SetParent(showCase.transform);
        itemObj.transform.localPosition = Vector3.zero;

    }
}
