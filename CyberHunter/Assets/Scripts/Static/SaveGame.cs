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

	public static void SaveScore(string score){
		PlayerPrefs.SetString("LEADERBOARDS", score);
		PlayerPrefs.Save();
	}

	public static string GetScore(){
		return PlayerPrefs.GetString("LEADERBOARDS", "");
	}

	public static void ClearScore(){
		PlayerPrefs.DeleteKey("LEADERBOARDS");
	}

	public static void SaveMusicVolume(float music)
	{
		PlayerPrefs.SetFloat("MUSIC", music);
		PlayerPrefs.Save();
	}
	public static void SaveSoundVolume(float sound)
	{
		PlayerPrefs.SetFloat("SOUND", sound);
		PlayerPrefs.Save();
	}

	public static float GetMusicVolume()
	{
		return PlayerPrefs.GetFloat("MUSIC");
	}

	public static float GetSoundVolume()
	{
		return PlayerPrefs.GetFloat("SOUND");
	}


}
