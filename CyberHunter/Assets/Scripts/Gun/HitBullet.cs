using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBullet : MonoBehaviour {

	[SerializeField] float damage;
	[SerializeField] Animator anim;

	public void SetBulletType(int damage){
		this.damage = damage;
		Debug.Log("Hit bullet damage: " + this.damage);
	}

	IEnumerator HitAnimation(){
		anim.SetBool("hit", true);
		yield return new WaitForSeconds(0.3f);
		transform.gameObject.SetActive(false);
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.layer == 10 && other.gameObject != null){
			Debug.Log("Enemy hit: " + damage);
			other.GetComponent<Enemy>().TakeDamage(damage);
			StartCoroutine("HitAnimation");
		}
	}
}
