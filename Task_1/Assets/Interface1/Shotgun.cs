using UnityEngine;

public class Shotgun : MonoBehaviour, IAttack
{
    public void Attack()
    {
        Debug.Log("You picked shortgun");
    }
}
