using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour {

	public static CoinManager instance;
	public int coins;
	[SerializeField] Text coinsCounter;
	void Awake(){
		instance = this;
	}

	void Start () {
		coins = SaveGame.GetCoins();
		coinsCounter.text = coins.ToString();
	}
	
	public void AddCoins(int coins){
		this.coins += coins;
		if (coinsCounter != null)
			coinsCounter.text = this.coins.ToString();
	}

	public void RemoveCoins(int coins){
		this.coins -= coins;
		if (this.coins <= 0)
			this.coins = 0;
		if(coinsCounter != null)
			coinsCounter.text = this.coins.ToString();
	}

	public void SaveCoins(){
		SaveGame.SaveCoins(coins);
	}

	public int GetCoins(){
		return coins;
	}

	public void ResetCoins(){
		SaveGame.ResetCoins();
	}
}
