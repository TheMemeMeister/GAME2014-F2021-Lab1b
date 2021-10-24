using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public static class pInfo // Player Info, accessible anywhere. Makes things a lot easier without the need of instancing.
{
    [SerializeField] public static int score = 0;
    [SerializeField] public static int Lives = 3;
}
public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI livesText;
    public float moveSpeed = 5f;
    public float JumpForce;
    public float MoveInput;
    public Animator animator;
    private Rigidbody2D SlayerBody;

    private bool FaceingRight = true;
    public bool bIsGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask WhatIsGround;

    private int doubleJump;
    public int DoubleJumpVal;

    //JoyStick to move, JoyButton to shoot
    private Joystick joystick;
    //private Joystick AttackStick;

    //public GameObject spawnPoint;

    [SerializeField]
    private GameObject FrostArrow;
    public float attackSpeed = 0.5f;
    public float coolDown;
    public float projectileSpeed = 500;
    protected bool shooting = false;


    void Awake()
    {
        SlayerBody = GetComponent<Rigidbody2D>();
        doubleJump = DoubleJumpVal;
        animator = gameObject.GetComponent<Animator>();
        joystick = GameObject.FindWithTag("JoyStick").GetComponent<FixedJoystick>();
        //AttackStick = GameObject.FindWithTag("JoyButton").GetComponent<FixedJoystick>();
        GameObject.Find("Attack Button").GetComponent<Button>().onClick.AddListener(PlayerAttack);
        //Activetime = 0.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bIsGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, WhatIsGround);


        MoveInput = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(joystick.Horizontal));
        SlayerBody.velocity = new Vector2(joystick.Horizontal * moveSpeed, SlayerBody.velocity.y);
        //Jump();

        if (FaceingRight == false && joystick.Horizontal > 0)
        {
            Flip();
        }
        else if (FaceingRight == true && joystick.Horizontal < 0)
        {
            Flip();
        }

    }
    void Update()
    {
        if (bIsGrounded == true)
        {
            Debug.Log("test");
            doubleJump = DoubleJumpVal;
            animator.SetBool("bJumping", false);
        }

        if (joystick.Vertical > 0 && doubleJump > 0)
        {
            SlayerBody.velocity = Vector2.up * JumpForce;
            doubleJump--;
            animator.SetTrigger("Jump");
        }
        else if (joystick.Vertical > 0 && doubleJump == 0 && bIsGrounded == true)
        {
            SlayerBody.velocity = Vector2.up * JumpForce;
            animator.SetTrigger("Jump");
        }
        //if(Mathf.Abs(AttackStick.Horizontal) > 0)
        //   {
        //       PlayerAttack();
        //   }
        //else if(AttackStick.Vertical > 0)
        //   {
        //       PlayerAttackUP();
        //   }
    }

    void Flip()
    {
        FaceingRight = !FaceingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    public void PlayerAttack()
    {
        Debug.Log("Shoot Pressed");
        animator.SetTrigger("Shoot");
        animator.Play("Shoot");
        GameObject arrow = Instantiate(FrostArrow, new Vector3(transform.position.x, transform.position.y, transform.position.z), FrostArrow.transform.rotation) as GameObject;

        //arrow.GetComponent<Rigidbody2D>().AddForce(transform.right * projectileSpeed);

        coolDown = Time.time + attackSpeed;

    }


    //public void PlayerAttackUP()
    //{
    //    Debug.Log("Shoot Up Pressed");
    //    animator.SetTrigger("Shoot Up");
    //    animator.Play("ShootUp");
    //    GameObject arrow = Instantiate(FrostArrow, new Vector3(transform.position.x, transform.position.y, transform.position.z), FrostArrow.transform.rotation) as GameObject;

    //    arrow.GetComponent<Rigidbody2D>().AddForce(transform.right * projectileSpeed);

    //    coolDown = Time.time + attackSpeed;

    //}
}
