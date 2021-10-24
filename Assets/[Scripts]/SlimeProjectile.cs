using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SlimeProjectile : MonoBehaviour
{

    public float speed = 5f;
    public float rotateSpeed = 2f;
    private Transform player;
    private Vector2 target;

    //homing portions
    private Rigidbody2D rb;
    public Transform ArrowTarg;

    [SerializeField]
    private float Maxlifetime = 2.0f;

    [SerializeField]
    private float Activetime;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        rb = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        Vector2 direction = (Vector2)ArrowTarg.position - rb.position;
        float rotateAmount = Vector3.Cross(direction, transform.up).z;


        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = transform.up * speed;

        Activetime += Time.deltaTime;

        if (Activetime > Maxlifetime || transform.position.x == ArrowTarg.position.x && transform.position.y == ArrowTarg.position.y)
        {
            Debug.Log("Destroyed Arrow");
            DistroyProjectile();
        }
    }

    public void OnCollisionEnter2D(Collider2D other)
    {
       if (other.gameObject.CompareTag("Enemy"))
        {
        pInfo.score++;
        Debug.Log("Collided with:" + other.gameObject.name);
        DistroyProjectile();

        }
    }

    void DistroyProjectile()
    {
        Destroy(gameObject);
    }
}

