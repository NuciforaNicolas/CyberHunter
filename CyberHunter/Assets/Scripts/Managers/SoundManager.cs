using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    AudioSource musicSource, enemySource, gunSource, turretSource, playerSource, powerUpSource;
    [SerializeField] AudioClip soundTrack, enemyHit, playerDeath, gunShoot, turretShoot, playerJump, playerHeal, powerUp, coinsGlobe, alienBugDeath;
    [SerializeField] AudioClip[] playerHit, enemyDestroy;
    
    void Awake()
    {
        instance = this;
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;
        musicSource.clip = soundTrack;
        musicSource.volume = SaveGame.GetMusicVolume();
        musicSource.Play();

        enemySource = gameObject.AddComponent<AudioSource>();
        enemySource.volume = SaveGame.GetSoundVolume();

        gunSource = gameObject.AddComponent<AudioSource>();
        gunSource.clip = gunShoot;
        gunSource.volume = SaveGame.GetSoundVolume();
        gunSource.priority = 0;

        turretSource = gameObject.AddComponent<AudioSource>();
        turretSource.volume = SaveGame.GetSoundVolume();

        powerUpSource = gameObject.AddComponent<AudioSource>();
        powerUpSource.volume = SaveGame.GetSoundVolume();

        playerSource = gameObject.AddComponent<AudioSource>();
        playerSource.volume = SaveGame.GetSoundVolume();
        playerSource.priority = 0;
    }

    private void Update()
    {
        if(MenuManager.volumeChanged){
            musicSource.volume = SaveGame.GetMusicVolume();
            enemySource.volume = SaveGame.GetSoundVolume();
            gunSource.volume = SaveGame.GetSoundVolume();
            powerUpSource.volume = SaveGame.GetSoundVolume();
            turretSource.volume = SaveGame.GetSoundVolume();
            playerSource.volume = SaveGame.GetSoundVolume();
            MenuManager.volumeChanged = false;
        }
    }

    public void GunShootPlay(){
        gunSource.Play();
    }

    public void GunShootStop(){
        gunSource.Stop();
    }

    public void PlayerJumpPlay(){
        playerSource.clip = playerJump;
        playerSource.Play();
    }

    public void PlayerHealPlay(){
        powerUpSource.clip = playerHeal;
        powerUpSource.Play();
    }

    public void powerUpPlay(){
        powerUpSource.clip = powerUp;
        powerUpSource.Play();
    }

    public void coinsGlobePickUpPlay(){
        powerUpSource.clip = coinsGlobe;
        powerUpSource.Play();
    }

    public void PlayerHitPlay(){
        playerSource.clip = playerHit[Random.Range(0, playerHit.Length)];
        playerSource.Play();
    }

    public void PlayerDeathPlay(){
        playerSource.clip = playerDeath;
        playerSource.Play();
    }

    public void TurretShootPlay(){
        turretSource.clip = turretShoot;
        turretSource.Play();
    }
    public void AlienBugDeathPlay(){
        enemySource.clip = alienBugDeath;
        enemySource.Play();
    }

    public void EnemyHitPlay(){
        enemySource.clip = enemyHit;
        enemySource.Play();
    }

    public void EnemyDestroyPlay(){
        enemySource.clip = enemyDestroy[Random.Range(0, enemyDestroy.Length)];
        enemySource.Play();
    }
}
