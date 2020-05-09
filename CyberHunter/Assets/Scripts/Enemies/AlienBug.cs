using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class AlienBug : Enemy
{
    public Transform target;
    public float speed = 200f;
    public float nextWayPointDistance = 3f;
    
    Path path;
    int currentWayPoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    protected override void Start()
    {
        health = maxHealth;
        anim = transform.GetChild(0).GetComponent<Animator>();

        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void StartChase(){
        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    void UpdatePath(){
        if(seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p){
        if(!p.error){
            path = p;
            currentWayPoint = 0;
        }
    }

    void FixedUpdate()
    {
        if (path == null)
            return;

        if(currentWayPoint >= path.vectorPath.Count){
            reachedEndOfPath = true;
            return;
        }
        else{
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);

        if(distance < nextWayPointDistance){
            currentWayPoint++;
        }

        FlipAlienBug();
    }


    void FlipAlienBug(){
       if (rb.velocity.x >= 0.01)
            transform.localScale = new Vector3(-1, 1, 1);
        else
           if(rb.velocity.x <= -0.01)
              transform.localScale = new Vector3(1, 1, 1);
    }
}
