using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	public static UIManager current;
	public Inventory UiInven;

	public Sprite[] ItemSprites;

	private void Awake()
	{
		if (current == null)
			current = this;
		else
			Destroy(gameObject);
	}
	public void ItemEat(int type)
	{
		UiInven.InvenSet((ITEM_TYPE)type);
	}
}
