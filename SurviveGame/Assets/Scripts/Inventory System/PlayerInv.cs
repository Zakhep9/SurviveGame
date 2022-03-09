using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInv : InventoryClass
{
	// Start is called before the first frame update
	public GameObject prefab;
	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
			_col = other;

	}
	public void OnTriggerExit(Collider other)
	{
		if (other.gameObject.layer == 9)
			_col = null;

	}
	public void DropItem(int index)
	{
		//Collider other = gameObject.OnBoxStay();

		if (items.Count >= (index + 1) && items.Count != 0)
		{
			Vector3 position = new Vector3(3, 2, 3);
			Quaternion rotation = new Quaternion(1, 1, 1, 1);
			GameObject obj = Instantiate(prefab, this.gameObject.transform.position + position, rotation) as GameObject;
			var i = obj.GetComponent<CollectableItem>();
			i.SetCount(1);
			i.SetItem(items[index]._item);
			if (items[index]._count > 1)
				items[index]._count--;
			else
				items.RemoveAt(index);
			//OnDropItem.Invoke();
			OnInventoryChanged.Invoke();
			//return true;
			
		}
		
		//return false;
	}
	public void GiveItem(int index)
    {
		if (items.Count >= (index + 1) && items.Count != 0)
		{
			if (_col)
			{
				var inventory = _col.GetComponent<BoxInv>();
				if (inventory)
				{
					inventory.AddItem(items[index]._item, 1);

					//	//Destroy(gameObject);
				}
				if (items[index]._count > 1)
					items[index]._count--;
				else
					items.RemoveAt(index);
				//OnDropItem.Invoke();
				OnInventoryChanged.Invoke();
			}

		}
		
	}
}
