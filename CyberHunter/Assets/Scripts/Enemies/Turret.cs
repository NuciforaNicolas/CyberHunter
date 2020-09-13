using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Enemy {
	bool insideTrigger = false;
	[SerializeField] float timeToShoot;
	IEnumerator Shoot(){
		while(true){
			yield return new WaitForSeconds(timeToShoot);
			SoundManager.instance.TurretShootPlay();
			SpawnBullet();
			anim.Play("TurretShooting");
		}
	}


	protected override void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.layer == 8 && !insideTrigger){
			StartCoroutine("Shoot");
			insideTrigger = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.layer == 8 && insideTrigger){
			StopCoroutine("Shoot");
			insideTrigger = false;
		}
	}


	public override void TakeDamage(float damage)
	{
		anim.Play("TurretHit");
		base.TakeDamage(damage);
	}

	void SpawnBullet(){
		TurretController.instance.SpawnBullet(transform.GetChild(0).transform, -1);
	}
}
