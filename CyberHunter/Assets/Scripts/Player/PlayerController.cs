using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerController : MonoBehaviour {

	[SerializeField] float speed;
	[SerializeField] float force;
	[SerializeField] Animator anim;
	[SerializeField] protected float timeToSpawn;
	[SerializeField] protected float timePowerUp;
	[SerializeField] int power1_Cost;
	[SerializeField] int power2_Cost;
	[SerializeField] int power3_Cost;
	float tSpawnCounter = 0;
	public bool isJumping = false;
	bool isPowerActive = false;

	void Awake(){
		anim = GetComponent<Animator>();
	}

	void Update(){
		

		if(Time.timeScale != 0){
			/*if(Input.GetKey(KeyCode.D)){
				MoveRight();
				Flip(1);
			}
			if (Input.GetKeyUp(KeyCode.D))
				anim.SetFloat("running", 0);

			if (Input.GetKey(KeyCode.A)){
				MoveLeft();
				Flip(-1);
			}
			if(Input.GetKeyUp(KeyCode.A))
				anim.SetFloat("running", 0);*/

			if(CrossPlatformInputManager.GetButton("Right")){
				MoveRight();
				Flip(1);
			}
			if (CrossPlatformInputManager.GetButton("Left"))
			{
				MoveLeft();
				Flip(-1);
			}
			if (CrossPlatformInputManager.GetButtonUp("Left") || CrossPlatformInputManager.GetButtonUp("Right"))
			{
				anim.SetFloat("running", 0);
			}

			/*if (Input.GetKeyDown(KeyCode.W)){
				Jump();
			}*/

			if(CrossPlatformInputManager.GetButtonDown("Jump"))
				Jump();


			tSpawnCounter += Time.deltaTime / timeToSpawn;
			/*if (Input.GetKey(KeyCode.Space) && tSpawnCounter > timeToSpawn){
				StartShoot();
				SoundManager.instance.GunShootPlay();
				Shoot();
				tSpawnCounter = 0;
			}*/
			
			if(CrossPlatformInputManager.GetButton("Fire") && tSpawnCounter >= timeToSpawn){
				StartShoot();
				SoundManager.instance.GunShootPlay();
				Shoot();
				tSpawnCounter = 0;
			}

			/*if (Input.GetKeyUp(KeyCode.Space)){
				StopShoot();
				SoundManager.instance.GunShootStop();
			}*/

			if(CrossPlatformInputManager.GetButtonUp("Fire")){
				StopShoot();
				SoundManager.instance.GunShootStop();
			}

			/*if(Input.GetKeyDown(KeyCode.X))
			{
				//isPowerActive = true;
				SetPowerUp(1);
			}*/

			if(CrossPlatformInputManager.GetButtonDown("Power1")){
				SetPowerUp(1);
			}

			/*if (Input.GetKeyDown(KeyCode.C))
			{
				//isPowerActive = true;
				SetPowerUp(2);
			}*/

			if (CrossPlatformInputManager.GetButtonDown("Power2"))
			{
				SetPowerUp(2);
			}

			/*if (Input.GetKeyDown(KeyCode.V))
			{
				//isPowerActive = true;
				SetPowerUp(3);
			}*/

			if (CrossPlatformInputManager.GetButtonDown("Power3"))
			{
				SetPowerUp(3);
			}

			/*if (Input.GetKeyDown(KeyCode.E) && Player.instance.GetHealth() < Player.instance.GetMaxHealth() && CoinManager.instance.GetCoins() > 0){
				Player.instance.Heal();
			}*/

			if(CrossPlatformInputManager.GetButtonDown("Heal") && Player.instance.GetHealth() < Player.instance.GetMaxHealth() && CoinManager.instance.GetCoins() > 0)
				Player.instance.Heal();
		}

			
	}

	public void MoveLeft(){
		transform.Move(-speed);
		anim.SetFloat("running", 1f);
	}

	public void MoveRight(){
		transform.Move(speed);
		anim.SetFloat("running", 1f);
	}

	public void SetPowerUp(int type){
		if(!isPowerActive){
			bool toActive = false;

			switch(type){
				case 1:
					if (CoinManager.instance.GetCoins() > power1_Cost)
						toActive = true;
					break;
				case 2:
					if (CoinManager.instance.GetCoins() > power2_Cost)
						toActive = true;
					break;
				case 3:
					if (CoinManager.instance.GetCoins() > power3_Cost)
						toActive = true;
					break;
			}
			if(toActive){
				isPowerActive = true;
				StartCoroutine("PowerUp", type);
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

	public void Shoot(){
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

	public void Jump(){
		if(!isJumping){ //se il giocatore è ancora in aria, non sarà possibile saltare ulteriormente 
			SoundManager.instance.PlayerJumpPlay();
			gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * force, ForceMode2D.Impulse); //effettua il salto
			anim.SetBool("isJumping", true);
			isJumping = true;
		}
	}

	void Flip(int pos){
		transform.localScale = new Vector3(pos,1,1);
	}

	void OnBecameInvisible()
	{
		Debug.Log("on invisible");
		if(gameObject.activeInHierarchy)
			FallingDown();
	}

	void FallingDown()
	{
		Player.instance.TakeDamage(Player.instance.GetMaxHealth());
	}

	public void setDeath(){
		anim.SetBool("isDeath", true);
	}

	/*void Move(float _speed, bool _flipX){
		transform.position += Vector3.right * Time.deltaTime * _speed;
		gameObject.GetComponent<SpriteRenderer>().flipX = _flipX; 
	}*/

}
