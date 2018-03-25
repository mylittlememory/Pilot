using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	enum ACTION
	{
		IDLE,
		RUN,
		ATTACK,
		HIT,
	}

	public float Speed;

	private Animator anime;

	private void Awake()
	{
		anime = GetComponent<Animator>();
	}
	void Update ()
	{
		Move();	 
	}
	void Move()
	{
		if (InputManager.MoveDir.x > 0)
		{
			anime.SetInteger("Action", (int)ACTION.RUN);
			transform.eulerAngles = new Vector3(0, 0, 0);
		}			
		if(InputManager.MoveDir.x < 0)
		{
			anime.SetInteger("Action", (int)ACTION.RUN);
			transform.eulerAngles = new Vector3(0, 180, 0);
		}
		if(InputManager.MoveDir.x == 0)
		{
			anime.SetInteger("Action", (int)ACTION.IDLE);			
		}
		transform.position += (Vector3)InputManager.MoveDir * Time.deltaTime * Speed;		
	}


}
