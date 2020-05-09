using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveGame {

	public static void SaveCoins(int coins){
		PlayerPrefs.SetInt("COINS", coins);
		PlayerPrefs.Save();
	}
	
	public static int GetCoins(){
		return PlayerPrefs.GetInt("COINS");
	}

	public static void ResetCoins(){
		PlayerPrefs.DeleteKey("COINS");
	}

}
