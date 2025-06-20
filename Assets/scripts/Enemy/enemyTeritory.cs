using UnityEngine;

public class enemyTeritory : MonoBehaviour
{
    public GameObject enemy;
    public enemy enemyScript;

    Vector2 positioin;
    void Start()
    {
        positioin = transform.position;
        enemyScript = enemy.GetComponent<enemy>();
    }
    private void FixedUpdate()
    {
        transform.position = positioin;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            enemyScript.changeMove = 1;
            enemyScript.isPlayer = false;
            enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, other.transform.position, enemyScript.speedonCatch * Time.deltaTime);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        enemyScript.isPlayer = true;
    }
}
