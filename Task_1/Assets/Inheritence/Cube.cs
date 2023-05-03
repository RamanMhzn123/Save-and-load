using UnityEngine;

public class Cube : EnemyParent
{
    [SerializeField] float X, Z;

    float moveRate = 2.0f;
    float moveTimer;


    protected override void Move()
    {
        //base.Move();
        RandomMove();
    }

    //Teleport to random position
    public void RandomMove()
    {
        moveTimer += Time.deltaTime;

        if(moveTimer >= moveRate)
        {
            float randomX = Random.Range(-X, X);
            float randomZ = Random.Range(-Z, Z);

            transform.position = new Vector3(randomX, transform.position.y, randomZ);
            moveTimer = 0;
        }
    }
}
