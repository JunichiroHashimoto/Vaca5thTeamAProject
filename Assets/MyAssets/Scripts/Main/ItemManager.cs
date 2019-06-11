using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {


    public Dictionary<int,ItemBase> itemMaster;
    public Dictionary<int,GameObject> itemPrefabs;

    [SerializeField]
    GameObject[] _itemPrefabs;


    // Use this for initialization
    void Start () {
        itemMaster.Add(1,new FlowerItem(1, "アジサイ"));
        itemMaster.Add(2,new FlowerItem(2, "アジサイ（葉）"));
        itemMaster.Add(3,new FlowerItem(3, "枝1"));
        itemMaster.Add(4,new FlowerItem(4, "枝2"));
        itemMaster.Add(51,new KenzanItem(51, "剣山"));
        itemMaster.Add(61,new FlowerVaseItem(61, "花器（紫）"));
        itemMaster.Add(62,new FlowerVaseItem(62, "花器（白）"));

        itemPrefabs.Add(1, _itemPrefabs[0]);
        itemPrefabs.Add(2, _itemPrefabs[1]);
        itemPrefabs.Add(3, _itemPrefabs[2]);
        itemPrefabs.Add(4, _itemPrefabs[3]);
        itemPrefabs.Add(5, _itemPrefabs[4]);
        itemPrefabs.Add(6, _itemPrefabs[5]);
        itemPrefabs.Add(7, _itemPrefabs[6]);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
