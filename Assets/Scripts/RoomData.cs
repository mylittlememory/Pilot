using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RoomData : MonoBehaviour {

	public ITEM_TYPE ItemType;
	private Image itemSprite;
	private Text itemCountText;
	private int itemCount;

	private void Awake()
	{
		itemSprite = transform.GetChild(0).GetComponent<Image>();
		itemCountText = transform.GetChild(1).GetComponent<Text>();
	}
	private void Start()
	{
		itemCount = 0;
		itemCountText.text = string.Format("{0}", itemCount);
	}
	public void KeepItem()
	{
		++itemCount;
		itemCountText.text = string.Format("{0}",itemCount);
	}
	public void NoGotItem(ITEM_TYPE type)
	{
		itemSprite.sprite = UIManager.current.ItemSprites[(int)type];
		itemSprite.enabled = true;
		ItemType = type;
		itemCount = 1;
		itemCountText.text = string.Format("{0}", itemCount);
	}


}
