using UnityEngine;

public class Minigun : MonoBehaviour, IAttack
{
    public void Attack()
    {
        Debug.Log("You picked Minigun");
    }
}
