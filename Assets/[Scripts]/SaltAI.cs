using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class SaltAI : MonoBehaviour
{
    public Transform target;
    public float speed = 200f;

    public float NextWayPointDistance = 3f;

    public Transform GhostGFX;

    Path path;
    int CurrentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;


    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0.0f, 0.5f);

    }

    void UpdatePath()
    {
        if (seeker.IsDone()) //not currently calculating a path 
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
            return;
        if (CurrentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[CurrentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);
        float distance = Vector2.Distance(rb.position, path.vectorPath[CurrentWaypoint]);

        if (distance < NextWayPointDistance) //reached next waypoint, onto the next 
        {
            CurrentWaypoint++;
        }

        if (rb.velocity.x > 0.01f)
        {
            GhostGFX.localScale = new Vector3(-5f, 5f, 1f);
        }
        else if (rb.velocity.x < -0.01f)
        {
            GhostGFX.localScale = new Vector3(5f, 5f, 1f);
        }
    }
    void OnPathComplete(Path P)
    {
        if (!P.error)
        {
            path = P;
            CurrentWaypoint = 0;
        }
    }
}
