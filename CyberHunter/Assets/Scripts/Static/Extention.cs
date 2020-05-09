using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extention {

	public static void Spawn(this Transform trans, Transform spawnPoint){
		trans.position = spawnPoint.position;
		trans.rotation = spawnPoint.rotation;
		trans.gameObject.SetActive(true);
	}

	public static void Move(this Transform trans, float _speed)
	{
		trans.position += Vector3.right * Time.deltaTime * _speed;
	}
}
