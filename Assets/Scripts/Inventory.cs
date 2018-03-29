using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ITEM_TYPE
{
	Consume,
	Weapone,
}

public enum CONSUME_TYPE
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
	public void InvenDataSet(CONSUME_TYPE type)
	{
		for (int i = 0; i < InvenRoom.Length; ++i)
		{
			if(InvenRoom[i].ConsumeType == type)
			{
				InvenRoom[i].KeepItem();
				return;
			}
			else if(InvenRoom[i].ConsumeType == CONSUME_TYPE.Empty)
			{
				InvenRoom[i].NoGotItem(type);
				return;
			}
		}
	}

}
