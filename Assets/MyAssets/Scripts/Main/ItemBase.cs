using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class ItemBase {

    public int id;
    public ItemKind itemKind;
    public string resourceName;
    public string jpName;

    public ItemBase(int id, ItemKind kind, string rcName, string jpName)
    {
        this.id = id;
        this.itemKind = kind;
        this.resourceName = rcName;
        this.jpName = jpName;
    }

    public ItemBase(string csv)
    {
        string[] tmp = csv.Split(',');
        int _id;
        int.TryParse(tmp[0], out _id);

        this.id = int.Parse(tmp[0]);
        this.itemKind = (ItemKind)int.Parse(tmp[1]);
        this.resourceName = tmp[2];
        this.jpName = tmp[3];
    }


}
