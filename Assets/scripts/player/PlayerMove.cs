using System;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
public class PlayerMove : MonoBehaviour
{
    public GameObject fx;
    public GameObject weapon;
    Animator fxAnimator;
    Animator weaponAnimator;
    InputAction move;
    InputAction attack;
    Rigidbody2D Player_rigidbody;
    Animator animator;

    public int speed;
    public float HP;
    public float Attacktimer = 0.4f;
    public float inframes;

    // value of last player movement
    Vector2 lateValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // import component
        move = InputSystem.actions.FindAction("Move");
        attack = InputSystem.actions.FindAction("Attack");
        Player_rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        fxAnimator = fx.GetComponent<Animator>();
        weaponAnimator = weapon.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        // attack cooldown
        Attacktimer -= Time.deltaTime;
        inframes -= Time.deltaTime;

        // read input
        Vector2 moveValue = move.ReadValue<Vector2>();
        float attackValue = attack.ReadValue<float>();

        // set variable from animator controller
        animator.SetFloat("latex", lateValue.x);
        animator.SetFloat("latey", lateValue.y);

        animator.SetFloat("velx", moveValue.x);
        animator.SetFloat("vely", moveValue.y);


        // init weapon position and rotation
        Vector2 weaponPos = Vector2.zero;
        float weaponRot = 0;
        Vector2 weaponValue = Vector2.zero;

        // change weapon according to motion direction
        if (attackValue == 1 && Attacktimer <= 0)
        {
            if (moveValue != Vector2.zero)
            {
                weaponValue = moveValue;
            }
            else
            {
                weaponValue = lateValue;
            }

            // change weapon pos and rot according weapon direction
            if (weaponValue.x >= 0.1)
            {
                weaponPos.Set(0.94f, -0.35f);
                weaponRot = -270;
            }
            else if (weaponValue.x <= -0.1)
            {
                weaponPos.Set(-0.95f, -0.35f);
                weaponRot = -450;

            }
            else if (weaponValue.y >= 0.1)
            {
                weaponPos.Set(-0.35f, 0.77f);
                weaponRot = -180f;
            }
            else if (weaponValue.y <= -0.1)
            {
                weaponPos.Set(-0.3f, -1.22f);
            }
            // set animation to attack
            weapon.SetActive(true);
            weapon.transform.position = new Vector2(transform.position.x, transform.position.y) + weaponPos;
            weapon.transform.Rotate(0, 0, weaponRot);
            animator.SetBool("isAttack", true);
            weaponAnimator.SetBool("isAttack", true);
            Attacktimer = 0.4f;
        }
        // attack animation cancel
        if (Attacktimer <= 0.2f)
        {
            weapon.transform.rotation = quaternion.Euler(0, 0, 0);
            weapon.transform.position = new Vector2(transform.position.x, transform.position.y);
            animator.SetBool("isAttack", false);
            weaponAnimator.SetBool("isAttack", false);
            weapon.SetActive(false);
        }

        // set motion if player stop moving
        if (moveValue == Vector2.zero)
        {
            animator.SetBool("isStop", true);

        }
        else
        {
            animator.SetBool("isStop", false);

        }
        // set animator value if get hit
        if (inframes <= 0.6f)
        {
            fxAnimator.SetBool("isHurt", false);
        }
        // move
        Player_rigidbody.position += moveValue * Time.deltaTime * speed;

        // update the last motion value
        if (moveValue != Vector2.zero)
        {
            lateValue = moveValue;
        }
    }
}
