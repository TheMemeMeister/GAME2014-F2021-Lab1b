using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltController : MonoBehaviour
{
    //[Header("Assignment 1 part 2 101270509")]
    public float horizontalSpeed;
    public float horizontalBoundary;
    public SaltManager saltManager;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        saltManager = FindObjectOfType<SaltManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }
    private void _Move()
    {
        //changed bullets to go left to right here 
        transform.position += new Vector3(horizontalSpeed, 0.0f, 0.0f) * Time.deltaTime;
    }

    private void _CheckBounds()
    {
        if (transform.position.x > horizontalBoundary)
        {
            saltManager.ReturnSalt(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        saltManager.ReturnSalt(gameObject);
    }
    public int ApplyDamage()
    {
        return damage;
    }
}
