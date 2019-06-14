using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour {

    ItemBase item;

    public void SetItem(ItemBase item)
    {
        this.item = item;
    }

    // 今のところ初期化時対象として検索するためのタグ代わりとして使用
}
