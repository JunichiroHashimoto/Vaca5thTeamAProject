using System.Collections;
using System.Collections.Generic;

public class KenzanItem : ItemBase
{
    public KenzanItem(int id, string name)
    {
        this.itemKind = ItemKind.Kenzan;
        this.itemId = id;
        this.itemName = name;
    }
}
