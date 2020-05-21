using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo{
	public string name;
	public int score;
	public PlayerInfo(string name, int score){
		this.name = name;
		this.score = score;
	}
}

public class LeaderBoard : MonoBehaviour
{
	public InputField leaderBoard, name, score;

	List<PlayerInfo> collectedStats;

	private void Start()
	{
		collectedStats = new List<PlayerInfo>();
		LoadLeaderBoard();
	}

	public void SubmitButton(){
		PlayerInfo stats = new PlayerInfo(name.text, int.Parse(score.text));
		collectedStats.Add(stats);

		name.text = "";
		score.text = "";

		SortStats();
	}

	void SortStats(){
		for(int i = collectedStats.Count - 1; i > 0; i--){
			if(collectedStats[i].score > collectedStats[i-1].score){
				PlayerInfo temp = collectedStats[i - 1];
				collectedStats[i - 1] = collectedStats[i];
				collectedStats[i] = temp;
			}
		}

		UpdateLeaderBoard();
	}


	void UpdateLeaderBoard(){
		string stats = "";

		for(int i = 0; i < collectedStats.Count; i++){
			stats += collectedStats[i].name + ",";
			stats += collectedStats[i].score + ",";
		}

		SaveGame.SaveScore(stats);
		//PlayerPrefs.SetString("LEADERBOARDS", stats);

		UpdateLeaderBoardVisual();
	}

	void UpdateLeaderBoardVisual(){
		leaderBoard.text = "";

		for(int i = 0; i <= collectedStats.Count - 1; i++){
			leaderBoard.text += collectedStats[i].name + " : " + collectedStats[i].score + "\n";
		}
	}

	public void LoadLeaderBoard(){
		//string stats = PlayerPrefs.GetString("LEADERBOARDS", "");
		string stats = SaveGame.GetScore();

		string[] formattedStats = stats.Split(',');

		for(int i = 0; i < formattedStats.Length - 2; i += 2){
			PlayerInfo playerInfo = new PlayerInfo(formattedStats[i], int.Parse(formattedStats[i + 1]));
			collectedStats.Add(playerInfo);
			UpdateLeaderBoardVisual();
		}
	}

	public void ClearPrefs(){
		//PlayerPrefs.DeleteKey("LEADERBOARDS");
		SaveGame.ClearScore();
		leaderBoard.text = "";
	}
}
