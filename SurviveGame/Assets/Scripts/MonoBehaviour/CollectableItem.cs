using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    [SerializeField] private Item _item;
    [SerializeField] private int _count;

    public void SetCount(int count)
    {
        _count = count;
    }
    public void SetItem(Item item)
    {
        _item = item;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!_item)
        {
            return;
        }
        var inventory = other.GetComponent<InventoryClass>();
        if (inventory)
        {
            if(inventory.AddItem(_item, _count))
                Destroy(gameObject);
        }
    } 
    // Start is called before the first frame update
  
}
