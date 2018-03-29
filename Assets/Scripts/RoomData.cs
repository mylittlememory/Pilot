using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RoomData : MonoBehaviour {

	public CONSUME_TYPE ConsumeType;
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
	public void NoGotItem(CONSUME_TYPE type)
	{
		itemCountText.gameObject.SetActive(true);
		itemSprite.sprite = UIManager.current.ItemSprites[(int)type];
		itemSprite.enabled = true;
		ConsumeType = type;
		itemCount = 1;
		itemCountText.text = string.Format("{0}", itemCount);
	}


}
