using System;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public float Damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
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
