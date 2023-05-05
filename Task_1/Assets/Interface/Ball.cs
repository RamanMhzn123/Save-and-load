using UnityEngine;

public class Ball : MonoBehaviour, ITakeDamage
{
    public int health = 10;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
            Destroy(gameObject);
    }
}
