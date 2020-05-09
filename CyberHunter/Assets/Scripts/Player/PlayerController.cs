using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField] float speed;
	[SerializeField] float force;
	[SerializeField] float push;
	[SerializeField] Animator anim;
	[SerializeField] protected float timeToSpawn;
	[SerializeField] protected float timePowerUp;
	[SerializeField] int power1_Cost;
	[SerializeField] int power2_Cost;
	[SerializeField] int power3_Cost;
	float tSpawnCounter = 0;
	bool isJumping = false;
	bool isPowerActive = false;

	void Awake(){
		anim = GetComponent<Animator>();
	}

	void Update(){
		if(Time.timeScale != 0){
			if(Input.GetKey(KeyCode.D)){
				transform.Move(speed);
				Flip(1);
				anim.SetFloat("running", 1f);
			}
			if (Input.GetKeyUp(KeyCode.D))
				anim.SetFloat("running", 0);

			if (Input.GetKey(KeyCode.A)){
				transform.Move(-speed);
				Flip(-1);
				anim.SetFloat("running", 1f);
			}
			if(Input.GetKeyUp(KeyCode.A))
				anim.SetFloat("running", 0);

			if (Input.GetKeyDown(KeyCode.W)){
				Jump();
				anim.SetBool("isJumping", true);
			}

			tSpawnCounter += Time.deltaTime / timeToSpawn;
			if (Input.GetKey(KeyCode.Space) && tSpawnCounter > timeToSpawn){
				StartShoot();
				SoundManager.instance.GunShootPlay();
				Shoot();
				tSpawnCounter = 0;
			}
			
			if (Input.GetKeyUp(KeyCode.Space)){
				StopShoot();
				SoundManager.instance.GunShootStop();
			}

			if(Input.GetKeyDown(KeyCode.X) && !isPowerActive && CoinManager.instance.GetCoins() >= power1_Cost)
			{
				isPowerActive = true;
				StartCoroutine("PowerUp", 1);
			}
			if (Input.GetKeyDown(KeyCode.C) && !isPowerActive && CoinManager.instance.GetCoins() >= power2_Cost)
			{
				isPowerActive = true;
				StartCoroutine("PowerUp", 2);
			}
			if (Input.GetKeyDown(KeyCode.V) && !isPowerActive && CoinManager.instance.GetCoins() >= power3_Cost)
			{
				isPowerActive = true;
				StartCoroutine("PowerUp", 3);
			}

			if (Input.GetKeyDown(KeyCode.E) && Player.instance.GetHealth() < Player.instance.GetMaxHealth() && CoinManager.instance.GetCoins() > 0){
				Player.instance.Heal();
			}
		}

			
	}

	IEnumerator PowerUp(int type){
		transform.GetChild(0).GetComponent<Gun>().SetPowerUp(type);
		SoundManager.instance.powerUpPlay();
		switch(type){
			case 1: { //power up 1
					transform.GetComponent<SpriteRenderer>().color = new Color(255, 0, 200);
					CoinManager.instance.RemoveCoins(power1_Cost); //il power up 1 costa 10
					break;
				}
				
			case 2:{ //power up 2
					transform.GetComponent<SpriteRenderer>().color = new Color(255, 255, 0);
					CoinManager.instance.RemoveCoins(power2_Cost); //il power up 2 costa 25
					break;
				}
				
			case 3:{ //power up 3
					transform.GetComponent<SpriteRenderer>().color = new Color(0, 255, 255);
					CoinManager.instance.RemoveCoins(power3_Cost); //il power up 3 costa 50
					break;
				}
		}
		yield return new WaitForSeconds(timePowerUp);
		transform.GetChild(0).GetComponent<Gun>().SetPowerUp(0);
		transform.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
		isPowerActive = false;
	}

	void Shoot(){
		transform.GetChild(0).GetComponent<Gun>().Shoot(transform.localScale.x);
	}

	void StartShoot(){
		anim.SetBool("isShooting", true);
	}

	void StopShoot(){
		anim.SetBool("isShooting", false);
	}

	void OnTriggerEnter2D(Collider2D other){  //il giocatore è su una piattaforma
		if (other.gameObject.layer == 9){
			isJumping = false; //sarà possibile saltare
			anim.SetBool("isJumping", false);
		}
	}

	void Jump(){
		if(!isJumping){ //se il giocatore è ancora in aria, non sarà possibile saltare ulteriormente 
			SoundManager.instance.PlayerJumpPlay();
			gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * force, ForceMode2D.Impulse); //effettua il salto
			isJumping = true;
		}
	}

	void Flip(int pos){
		transform.localScale = new Vector3(pos,1,1);
	}

	void OnBecameInvisible()
	{
		FallingDown();
	}

	void FallingDown()
	{
		Player.instance.TakeDamage(100);
	}


	/*void Move(float _speed, bool _flipX){
		transform.position += Vector3.right * Time.deltaTime * _speed;
		gameObject.GetComponent<SpriteRenderer>().flipX = _flipX; 
	}*/

}
