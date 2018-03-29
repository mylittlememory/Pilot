using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumeItem : MonoBehaviour {

	public CONSUME_TYPE ConsumeType;

	private void Start()
	{
		StartCoroutine("ItemMove");
	}
	IEnumerator ItemMove()
	{
		Vector3 currentPlus = Vector3.up;
		float maxY = transform.position.y + 0.25f;
		float minY = transform.position.y - 0.25f;
		while(gameObject.activeSelf)
		{
			if (transform.position.y >= maxY)
				currentPlus = Vector3.down;
			if (transform.position.y <= minY)
				currentPlus = Vector3.up;

			transform.position += currentPlus * Time.deltaTime;

			yield return null;
		}
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			UIManager.current.ItemEat(ConsumeType);
			Destroy(gameObject);
		}
	}
}
