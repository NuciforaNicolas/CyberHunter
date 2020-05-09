using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MainGun, ISpawnBullet<int, float>{

	[SerializeField] GameObject[] bulletList;
	[SerializeField] Transform spawnPoint;
	[SerializeField] GameObject bullet;
	[SerializeField] int bulletLength;
	private int bulletCounter = 0;
	private bool bulletFound = false;

	void Awake(){
		bulletList = new GameObject[bulletLength];
		for(int i = 0; i < bulletLength; i++){
			bulletList[i] = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
			bulletList[i].SetActive(false);
		}
		gun = GunType.normal;
	}

	public void SpawnBullet(int bulletType, float flip){
		bulletFound = false;
		while(!bulletFound){
			for(int i = bulletCounter; i < bulletLength; i++){
				if(!bulletList[i].activeInHierarchy){
					bulletList[i].GetComponent<HitBullet>().SetBulletType(bulletType);
					Debug.Log("Bullet type: " + bulletType);
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
