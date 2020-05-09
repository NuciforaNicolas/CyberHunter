using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IKillabble<float> {
	public float health;
	[SerializeField] float maxHealth;
	[SerializeField] float heal;
	[SerializeField] int healCost;
	public static Player instance;

	
	void Awake(){
		instance = this;
		health = maxHealth;
		Debug.Log("health" + health);
	}

	public void Heal(){
		if(health < maxHealth){
			Debug.Log("Healing...");
			SoundManager.instance.PlayerHealPlay();
			health += heal;
			CoinManager.instance.RemoveCoins(healCost);
			if (health > maxHealth)
				health = maxHealth;
		}
			
	}

	public float GetHealth(){
		return health;
	}

	public float GetMaxHealth(){
		return maxHealth;
	}

	public void Death(){
		Debug.Log("You died");
		if(SoundManager.instance != null){
			SoundManager.instance.PlayerDeathPlay();
			SoundManager.instance.GunShootStop();
		}
		CoinManager.instance.RemoveCoins((int)((CoinManager.instance.GetCoins() * 20) / 100)); //rimuove il 20% delle monete alla morte del giocatore
		CoinManager.instance.SaveCoins();
		Time.timeScale = 0;
	}

	public void TakeDamage(float damage){
		health -= damage;
		if(SoundManager.instance != null)
			SoundManager.instance.PlayerHitPlay();
		if(health <= 0){
			Death();
		}
	}
}
