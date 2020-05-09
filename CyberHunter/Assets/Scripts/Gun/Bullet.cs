using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	[SerializeField] float speed;
	public void Spawn(Transform spawnPoint, float flip){
		speed = Mathf.Abs(speed);
		if (flip == -1)
			speed *= -1;
		Debug.Log("Flip: " + flip);
		transform.Spawn(spawnPoint);
	}

	void Update(){
		transform.Move(speed);
	}

	void OnBecameInvisible()
	{
		Debug.Log("Bullet disabled");
		gameObject.SetActive(false);
	}
}
