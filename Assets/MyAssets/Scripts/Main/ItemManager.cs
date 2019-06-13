using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemManager : MonoBehaviour {

    Dictionary<int, ItemBase> allItemDict;
 
    void Start () {

        TextAsset textAsset = Resources.Load("Data/ItemData") as TextAsset;
        string[] itemDataArr = textAsset.text.Replace("\r", "").Split('\n');

        allItemDict = new Dictionary<int, ItemBase>();
        for (int i = 0; i < itemDataArr.Length; i++)
        {
            int id = int.Parse(itemDataArr[i].Split(',')[0]);
            allItemDict.Add(id, new ItemBase(itemDataArr[i]));
        }

        Resources.UnloadUnusedAssets();

    }

}
