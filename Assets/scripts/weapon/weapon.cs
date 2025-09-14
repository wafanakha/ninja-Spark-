using System;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public float Damage;

    // weapons

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Enemy")
        {
            enemy enemy = collision.GetComponent<enemy>();
            enemy.HP -= Damage;

            if (enemy.HP <= 0)
            {
                Destroy(collision.gameObject);
                Destroy(enemy.territory);
            }
            Debug.Log("bam");
            Debug.Log(enemy.HP);
        }
    }
}
