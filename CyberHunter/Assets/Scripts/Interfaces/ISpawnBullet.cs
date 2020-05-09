using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawnBullet <T, H>
{
	void SpawnBullet(T spawnPoint, H flip);
}
