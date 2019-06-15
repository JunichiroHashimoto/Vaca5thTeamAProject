using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBoxNode : MonoBehaviour {

    public ItemBase itemData;
    ItemBox itemBox;

    void Start()
    {
        itemBox = GetComponentInParent<ItemBox>();
    }

    public void OnClick()
    {
        if (itemData == null)
        {
            Debug.Log("OnClick Node Item null");
            return;
        }
        Debug.Log("OnClick Node");

        var itemPrefab = Resources.Load("Prefabs/Prop/" + itemData.resourceName) as GameObject;
        var item = Instantiate(itemPrefab) as GameObject;

        var rigid = item.GetComponent<Rigidbody>();
        if(rigid)
        {
            rigid.isKinematic = true;
        }
        //var collider = item.GetComponent<Collider>();
        //if(collider)
        //{
        //    collider.enabled = false;
        //}

        itemBox.DisplayItem(item);

    }
}
