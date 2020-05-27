using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : Enemy
{
	[SerializeField] float speed;
	bool toMove;

	protected override void Start(){
		base.Start();
		toMove = false;
	}

	protected override void OnTriggerEnter2D(Collider2D other)
	{
		base.OnTriggerEnter2D(other);

		if (other.tag == "CheckPointA")
		{
			speed *= -1;
			transform.localScale = new Vector3(-1, 1, 1);
			healthBar.transform.localScale = new Vector3(-1, 1, 1);
		}
		if (other.tag == "CheckPointB")
		{
			speed *= -1;
			transform.localScale = new Vector3(1, 1, 1);
			healthBar.transform.localScale = new Vector3(1, 1, 1);
		}
	}
	void Update()
	{
		if(toMove)
			Move(-speed);
	}

	public override void Death()
	{
		base.Death();
		GameManager.instance.Complete();
	}

	public void StartMoving(){
		toMove = true;
	}

	protected virtual void Move(float speed)
	{
		transform.parent.Move(speed);
	}
}
