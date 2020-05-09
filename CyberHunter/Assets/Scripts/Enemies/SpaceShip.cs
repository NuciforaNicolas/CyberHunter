using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : Enemy
{
	[SerializeField] float speed;

	protected override void OnTriggerEnter2D(Collider2D other)
	{
		base.OnTriggerEnter2D(other);

		if (other.tag == "CheckPointA")
		{
			speed *= -1;
			transform.localScale = new Vector3(-1, 1, 1);
		}
		if (other.tag == "CheckPointB")
		{
			speed *= -1;
			transform.localScale = new Vector3(1, 1, 1);
		}
	}
	void Update()
	{
		Move(-speed);
	}

	protected virtual void Move(float speed)
	{
		transform.parent.Move(speed);
	}
}
