using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBuilding : MonoBehaviour
{
    [SerializeField] float speed;
    // Update is called once per frame
    void Update()
    {
        transform.Move(-speed);
    }

    private void OnBecameInvisible()
    {
        Debug.Log("Building destroyed");
        Destroy(this.gameObject);
    }

    public void setSpeed(float speed){
        this.speed = speed;
    }
}
