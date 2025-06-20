using System.Security.Cryptography;
using NUnit.Framework.Constraints;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject fx;
    public GameObject territory;
    Animator fxAnimator;

    Rigidbody2D enemy_rigidbody2D;
    Animator animator;
    Vector2 movement;

    public float speedonWatch;
    public float speedonCatch;
    public float changeMove;
    public float HP;
    public float Damage;
    float latePosititonX;
    float latePosititonY;
    float enemyVelocityX;
    float enemyVelocityY;

    public bool isPlayer = true;


    void Start()
    {
        enemy_rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        movement.Set(1, 0);
        fxAnimator = fx.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        changeMove -= Time.deltaTime;
        if (changeMove <= 0)
        {
            if (movement.x == 1)
            {
                movement.Set(-1, 0);
            }
            else
            {
                movement.Set(1, 0);
            }
            changeMove = 1f;
        }




        if (isPlayer)
        {
            enemy_rigidbody2D.position += movement * Time.deltaTime * speedonWatch;

        }
        enemyVelocityX = (enemy_rigidbody2D.position.x - latePosititonX) / Time.deltaTime;
        enemyVelocityY = (enemy_rigidbody2D.position.y - latePosititonY) / Time.deltaTime;
        animator.SetFloat("MoveX", enemyVelocityX);
        animator.SetFloat("MoveY", enemyVelocityY);

        latePosititonX = enemy_rigidbody2D.position.x;
        latePosititonY = enemy_rigidbody2D.position.y;


    }

    void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.name == "Player")
        {
            PlayerMove playerScript = collision.GetComponent<PlayerMove>();

            if (playerScript.inframes <= 0)
            {
                fxAnimator.SetBool("isHurt", true);
                Debug.Log(playerScript);
                playerScript.HP -= Damage;
                playerScript.inframes = 0.8f;
            }
        }
    }


}
