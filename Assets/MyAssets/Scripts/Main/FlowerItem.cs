using System.Collections;
using System.Collections.Generic;

public class FlowerItem : ItemBase
{
    public FlowerItem(int id, string name)
    {
        this.itemKind = ItemKind.Flower;
        this.itemId   = id;
        this.itemName = name;
    }
}
