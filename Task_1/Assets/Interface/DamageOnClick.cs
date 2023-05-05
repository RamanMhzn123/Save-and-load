using UnityEngine;

public class DamageOnClick : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;
            if(Physics.Raycast(ray, out hitInfo)) //if ray hit object
            {
                ITakeDamage damagable = hitInfo.collider.GetComponent<ITakeDamage>();
                if(damagable != null )
                {
                    damagable.TakeDamage(1);
                }
            }
        }
    }
}
