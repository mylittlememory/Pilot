using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public static UIManager current;
	public Inventory UIInven;

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
		UIInven.InvenDataSet((ITEM_TYPE)type);
	}

}
