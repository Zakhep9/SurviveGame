
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public int id;
    public Sprite icon;
    public void SetVolues(Item i)
    {
        id = i.id;
        icon = i.icon;
    }
    // Start is called before the first frame update
   
}

//[CreateAssetMenu]
public abstract class UsefullItem: Item
{
    public int volue;
    public abstract bool UpdateItem();
}

public class Food: UsefullItem
{
    public override bool UpdateItem()
    {
        return true;
    }
}

public class UpdatedFood: Food
{
    public int healh;
}