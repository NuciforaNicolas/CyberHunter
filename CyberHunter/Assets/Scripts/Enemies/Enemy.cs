using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IKillabble<float> {

	public float health;
	[SerializeField] public float maxHealth;
	[SerializeField] protected int coins;
	[SerializeField] float damage;
	bool isDeath = false;
	protected Animator anim;

	protected virtual void Start(){
		health = maxHealth;
		anim = GetComponent<Animator>();
	}

	//protected virtual void Reset(){
	//	health = maxHealth;
	//}

	//protected virtual void OnEnable(){
	//	Reset();
	//}

	protected virtual void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.layer == 8){
			Debug.Log("Player hit");
			CoinManager.instance.RemoveCoins((int)damage);
			Player.instance.TakeDamage(damage);
		}
	}

	protected IEnumerator DeathAnimation(){
		GetComponent<Collider2D>().enabled = false;
		anim.SetBool("isDeath", true);
		if(gameObject.tag == "Turret" || gameObject.tag == "Drone" || gameObject.tag == "Boss")
			SoundManager.instance.EnemyDestroyPlay();
		else if(gameObject.tag == "AlienBug")
			SoundManager.instance.AlienBugDeathPlay();

		yield return new WaitForSeconds(0.5f);
		gameObject.SetActive(false);
		CoinManager.instance.AddCoins(coins);
	}

	void StartDeathRoutine(){
		if(!isDeath){
			isDeath = true; //la chiamata verrà eseguita una sola volta 
			StartCoroutine("DeathAnimation");
		}
	}

	public void Death(){
		Debug.Log("Enemy destroyed");
		StartDeathRoutine();
	}

	public virtual void TakeDamage(float damage){
		Debug.Log("Enemy hit");
		if(!isDeath)
			SoundManager.instance.EnemyHitPlay();
		health -= damage;
		if(health <= 0){
			Death();
		}
	}
}
