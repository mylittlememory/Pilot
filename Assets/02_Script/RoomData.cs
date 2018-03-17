using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RoomData : MonoBehaviour {

	public ITEM_TYPE ItemType;
	private Image ItemSprite;
	private Text ItemCountText;
	private int ItemCount;


	private void Awake()
	{
		ItemType = ITEM_TYPE.Empty;
		ItemSprite = transform.GetChild(0).GetComponent<Image>();
		ItemCountText = transform.GetChild(1).GetComponent<Text>();
	}
	private void Start()
	{
		ItemCount = 0;
		ItemCountText.text = string.Format("{0}", ItemCount);
		ItemSprite.enabled = false;
	}

	public void CountPlus()
	{
		++ItemCount;
		ItemCountText.text = string.Format("{0}", ItemCount);
	}
	public void RoomInit(ITEM_TYPE type)
	{
		ItemSprite.enabled = true;
		ItemType = type;
		ItemSprite.sprite = UIManager.current.ItemSprites[(int)type];
		ItemCount = 1;
		ItemCountText.text = string.Format("{0}", ItemCount);
	}

}
