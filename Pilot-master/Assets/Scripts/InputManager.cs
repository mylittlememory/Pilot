using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class InputManager : MonoBehaviour
{
	enum PUSH
	{
		Begin,
		Pressing,
	}
	public static Vector2 MoveDir;
	public RectTransform JoyFront;
	public RectTransform JoyBack;
	public float DisBetweenTwo;
	public float currentDis;
	
	private PUSH mousePush;

	private void Start()
	{
		mousePush = PUSH.Begin;
	}
	private void Update()
	{

#if UNITY_EDITOR
		if (Input.GetMouseButton(0))
		{
			Vector2 convertPos = Input.mousePosition;

			if (mousePush == PUSH.Begin)
			{
				JoyBack.position = convertPos;
				JoyStickInit(true);
			}

			if(DistanceCheck() == true)
				JoyFront.position = convertPos;
			if(DistanceCheck() == false)
				JoyFront.position = (Vector2)JoyBack.position + (convertPos - (Vector2)JoyBack.position).normalized * DisBetweenTwo;

			MoveDir = (JoyFront.position - JoyBack.position).normalized;
		}
		if(Input.GetMouseButtonUp(0))
		{
			JoyStickInit(false);
		}
#elif UNITY_ANDROID
		if(Input.touchCount > 0)
		{
			

		}
#endif
	}
	private void JoyStickInit(bool isActive)
	{
		if(isActive)
		{
			JoyBack.gameObject.SetActive(true);
			JoyFront.gameObject.SetActive(true);
			mousePush = PUSH.Pressing;
		}
		else
		{
			JoyBack.gameObject.SetActive(false);
			JoyFront.gameObject.SetActive(false);
			MoveDir = Vector2.zero;
			mousePush = PUSH.Begin;
		}
	}
	private bool DistanceCheck()
	{
		currentDis = Vector2.Distance(JoyBack.position, JoyFront.position);
		if (currentDis <= DisBetweenTwo)
			return true;
		else
			return false;
	}
}




