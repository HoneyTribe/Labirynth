using UnityEngine;
using System;
using System.Collections.Generic;
namespace AssemblyCSharp
{
		public class Inventory
		{
			private List<GameObject> inventory = new List<GameObject>();
			private GameObject availableItem;

			public GameObject getAvailablItem()
			{
				return availableItem;
			}

			public void setAvailableItem(GameObject item)
			{
				this.availableItem = item;
			}

			public void putItemIntoInventory()
			{
				this.inventory.Add(availableItem);
				this.availableItem = null;
			}

			public void clearInventory()
			{
				this.inventory.Clear();
			}	

			public GameObject getInventoryItem()
			{
				if (this.inventory.Count != 0)
				{
					return this.inventory[0];
				}
				else
				{
					return null;
				}
			}
		}
}

