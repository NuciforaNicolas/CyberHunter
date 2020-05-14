using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : Enemy
{
	[SerializeField] float speed;
	
	protected override void OnTriggerEnter2D(Collider2D other){
		base.OnTriggerEnter2D(other);

		if (other.tag == "CheckPointA"){
			speed *= -1;
			transform.localScale = new Vector3(-1, 1, 1);
			healthBar.transform.localScale = new Vector3(-1, 1, 1);
		}
		if(other.tag == "CheckPointB"){
			speed *= -1;
			transform.localScale = new Vector3(1, 1, 1);
			healthBar.transform.localScale = new Vector3(1, 1, 1);
		}
	}
	void Update(){
		Move(-speed);
	}

	public override void TakeDamage(float damage)
	{
		base.TakeDamage(damage);
		Debug.Log("Drone hit");
		anim.Play("DroneHit");
	}


	protected virtual void Move(float speed){
		transform.Move(speed);
	}

}
