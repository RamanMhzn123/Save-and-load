using UnityEngine;

public class Barrel : MonoBehaviour, ITakeDamage
{
    public void TakeDamage(int damage)
    {
        Destroy(gameObject);
        //barrelParticle.Play();
    }
}
