using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour {

	public static CoinManager instance;
	public int coins;

	void Awake(){
		instance = this;
	}

	void Start () {
		coins = SaveGame.GetCoins();
	}
	
	public void AddCoins(int coins){
		this.coins += coins;
	}

	public void RemoveCoins(int coins){
		this.coins -= coins;
		if (this.coins <= 0)
			this.coins = 0;
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
