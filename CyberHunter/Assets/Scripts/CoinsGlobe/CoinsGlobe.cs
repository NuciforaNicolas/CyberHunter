using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsGlobe : MonoBehaviour
{
    public int coins;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            switch(gameObject.tag){
                case "RedGlobe" : 
                    coins = 10;
                    break;
                case "GreenGlobe":
                    coins = 20;
                    break;
                case "BlueGlobe":
                    coins = 50;
                    break;
                case "YellowGlobe":
                    coins = 100;
                    break;
            }
            CoinManager.instance.AddCoins(coins);
            SoundManager.instance.coinsGlobePickUpPlay();
            gameObject.SetActive(false);
        }
    }
}
