//parent class
using UnityEngine;

public class EnemyParent : MonoBehaviour
{

    [SerializeField] string enemyName;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float distance;
    [SerializeField] float maxHealth;
    float health;

    protected Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        health = maxHealth;
        Intro();
    }

    void Update()
    {
        Move();   
    }

    protected virtual void Intro()
    {
        Debug.Log("This is " + enemyName + " with HP:" + health + " and MoveSpeed: " + moveSpeed);
    }

    protected virtual void  Move()
    {
        //Follow player if in range
        if(Vector3.Distance(transform.position, player.position) < distance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }
}
