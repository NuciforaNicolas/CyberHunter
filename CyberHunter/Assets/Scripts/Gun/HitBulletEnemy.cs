using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBulletEnemy : MonoBehaviour {
	[SerializeField] float damage;
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == 8)
		{
			Debug.Log("Player hit");
			Player.instance.TakeDamage(damage);
			CoinManager.instance.RemoveCoins((int)damage);
			transform.gameObject.SetActive(false);
		}
	}
}
