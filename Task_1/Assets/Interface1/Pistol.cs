using UnityEngine;

public class Pistol : MonoBehaviour, IAttack
{
    public void Attack()
    {
        Debug.Log("You picked Pistol");
    }
}
