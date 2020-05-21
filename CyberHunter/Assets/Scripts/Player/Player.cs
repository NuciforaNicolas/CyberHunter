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
			ChangeHealthBarColor(fill, true);

			CoinManager.instance.RemoveCoins(healCost);
			if (health > maxHealth)
				health = maxHealth;
		}
			
	}

	void ChangeHealthBarColor(float fill, bool isToFill){
		if(!isToFill){
			if (healthBar.fillAmount >= 0.5)
				healthBar.color = Color.Lerp(Color.green, Color.yellow, 1 - fill);
			if (healthBar.fillAmount < 0.5)
				healthBar.color = Color.Lerp(Color.yellow, Color.red, 1 - fill);
		}
		if(isToFill){
			if (healthBar.fillAmount >= 0.5)
				healthBar.color = Color.Lerp(Color.yellow, Color.green, 1 - fill);
			if (healthBar.fillAmount < 0.5)
				healthBar.color = Color.Lerp(Color.red, Color.yellow, 1 - fill);
		}
	}

	public float GetHealth(){
		return health;
	}

	public float GetMaxHealth(){
		return maxHealth;
	}

	public int GetHealCost(){
		return healCost;
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
			//CoinManager.instance.SaveCoins(); //TO IMPLEMENT WITH CHECKPOINTS
			player.SetActive(false);
			GameManager.instance.GameOver();
		}
	}

	public void Death(){
		Debug.Log("You died");
		//CoinManager.instance.RemoveCoins((int)((CoinManager.instance.GetCoins() * 20) / 100)); //rimuove il 20% delle monete alla morte del giocatore
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if(player != null)
			StartCoroutine("PlayerDeathAnim", player);
	}

	public void TakeDamage(float damage){
		health -= damage;
		float fill = health / maxHealth;
		if(healthBar != null) //rimuove un errore in cui l'immagine viene usata quando è distrutta
			healthBar.fillAmount = fill;
		ChangeHealthBarColor(fill, false);

		if(SoundManager.instance != null)
			SoundManager.instance.PlayerHitPlay();
		if(health <= 0){
			Death();
		}
	}
}
