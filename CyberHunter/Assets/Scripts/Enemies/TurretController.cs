using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour, ISpawnBullet<Transform, float> {
	public static TurretController instance;
	[SerializeField] GameObject[] bulletList;
	[SerializeField] GameObject bullet;
	[SerializeField] int bulletLength;
	int bulletCounter = 0;
	bool bulletFound = false;

	// Use this for initialization
	void Awake () {
		bulletList = new GameObject[bulletLength];
		for (int i = 0; i < bulletLength; i++)
		{
			bulletList[i] = Instantiate(bullet);
			bulletList[i].SetActive(false);
		}
	}

	void Start(){
		instance = this;
	}

	public void SpawnBullet(Transform spawnPoint, float flip)
	{
		bulletFound = false;
		while (!bulletFound)
		{
			for (int i = bulletCounter; i < bulletLength; i++)
			{
				if (!bulletList[i].activeInHierarchy)
				{
					bulletList[i].GetComponent<Bullet>().Spawn(spawnPoint, flip);
					bulletCounter = i + 1;
					bulletFound = true;
					break;
				}
				if (i == bulletLength - 1)
					bulletCounter = 0;
			}
			if (bulletCounter == bulletLength)
				bulletCounter = 0;
		}
	}
}
