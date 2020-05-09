using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWall : MonoBehaviour
{

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 8){
            transform.parent.GetChild(0).GetComponent<AlienBug>().StartChase();
            gameObject.SetActive(false);
        }
    }
}
