using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class InventorySlot: ScriptableObject
{
	public Item _item;
	public int _count;
	public void init(Item i, int c)
    {
		this._item = i;
		this._count = c;
    }
}

public class InventoryClass : MonoBehaviour
{
	[SerializeField] protected List<InventorySlot> items = new List<InventorySlot>();
	
	[SerializeField] protected int Size = 5;
	[SerializeField] protected UnityEvent OnInventoryChanged;
	[SerializeField] protected Collider _col;
	//[SerializeField] public UnityEvent BoxInvChanged;

	//public int count; 
	//[SerializeField] public UnityEvent OnDropItem;

	public bool AddItem(Item _i, int _c)
    {
		
		foreach(InventorySlot slot in items)
        {
			if(slot._item.id == _i.id)
            {
				slot._count += _c;
				OnInventoryChanged.Invoke();
				return true;
            }
        }
		if (items.Count >= Size)
			return false;
		InventorySlot new_slot = ScriptableObject.CreateInstance<InventorySlot>();
		new_slot.init(_i, _c);
		items.Add(new_slot);
		OnInventoryChanged.Invoke();
		return true;
    }
	//[SerializeField]
	//[SerializeField]
	//public void OnDropItem(int index)
 //   {
	//	DropItem(index, other);
 //   }
	void Start()
    {
		OnInventoryChanged.Invoke();
	}
	
	public Collider OnBoxStay(Collider other)
    {
		return other;
    }
	public Item GetItem(int i)
    {
		return (i < items.Count ? items[i]._item : null);
    }
	public int GetCount(int i)
    {
		return (i < items.Count ? items[i]._count : 0); 
    }
	public int GetSize() {
		return items.Count;
	}
	
}
