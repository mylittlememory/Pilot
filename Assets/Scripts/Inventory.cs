using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ITEM_TYPE
{
	Empty,
	HpPotion,
	SteminaPotion,

}

public class Inventory : MonoBehaviour {

	public RoomData[] InvenRoom;

	void Start () {
		InvenRoom = new RoomData[transform.childCount];
		for(int i=0; i<InvenRoom.Length; ++i)
		{
			InvenRoom[i] = transform.GetChild(i).GetComponent<RoomData>();
		}
	}
	public void InvenDataSet(ITEM_TYPE type)
	{
		for (int i = 0; i < InvenRoom.Length; ++i)
		{
			if(InvenRoom[i].ItemType == type)
			{
				InvenRoom[i].KeepItem();
				return;
			}
			else if(InvenRoom[i].ItemType == ITEM_TYPE.Empty)
			{
				InvenRoom[i].NoGotItem(type);
				return;
			}

		}
	}

}
