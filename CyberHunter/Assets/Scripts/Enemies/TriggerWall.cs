using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWall : MonoBehaviour
{

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 8){
            if (gameObject.tag == "AlienBug")
            {
                transform.parent.GetChild(0).GetComponent<AlienBug>().StartChase();
            }
            else
                if (gameObject.tag == "Boss")
                transform.parent.GetChild(0).GetChild(0).GetComponent<SpaceShip>().StartMoving();
            gameObject.SetActive(false);
        }
    }
}
