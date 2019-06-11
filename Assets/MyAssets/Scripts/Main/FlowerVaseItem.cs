using System.Collections;
using System.Collections.Generic;

public class FlowerVaseItem : ItemBase
{
    public FlowerVaseItem(int id, string name)
    {
        this.itemKind = ItemKind.Vase;
        this.itemId = id;
        this.itemName = name;
    }
}
