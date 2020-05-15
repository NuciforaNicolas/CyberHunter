using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, IKillabble<float> {
	public float health;
	[SerializeField] float maxHealth;
	[SerializeField] float heal;
	[SerializeField] int healCost;
	[SerializeField] Image healthBar;
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
			float fill = heal / maxHealth;
			healthBar.fillAmount += fill;
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

	IEnumerator PlayerDeathAnim(GameObject player){
		if(player != null){
			player.GetComponent<PlayerController>().setDeath();
			if (SoundManager.instance != null)
			{
				SoundManager.instance.PlayerDeathPlay();
				SoundManager.instance.GunShootStop();
			}
			yield return new WaitForSeconds(0.5f);
			CoinManager.instance.SaveCoins();
			player.SetActive(false);
			Time.timeScale = 0;
		}
	}

	public void Death(){
		Debug.Log("You died");
		//CoinManager.instance.RemoveCoins((int)((CoinManager.instance.GetCoins() * 20) / 100)); //rimuove il 20% delle monete alla morte del giocatore
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if(player != null)
			StartCoroutine("PlayerDeathAnim", player);
		GameManager.instance.GameOver();
	}

	public void TakeDamage(float damage){
		health -= damage;
		float fill = health / maxHealth;
		if(healthBar != null) //rimuove un errore in cui l'immagine viene usata quando è distrutta
			healthBar.fillAmount = fill;
		if(SoundManager.instance != null)
			SoundManager.instance.PlayerHitPlay();
		if(health <= 0){
			Death();
		}
	}
}
