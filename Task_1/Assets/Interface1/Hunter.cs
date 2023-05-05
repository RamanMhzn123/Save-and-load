using UnityEngine;

public class Hunter : MonoBehaviour
{
    public float speed;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 velocity = new Vector3(horizontal, 0, vertical).normalized;
        rb.velocity = velocity * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        IAttack attack = other.GetComponent<IAttack>();
        if (attack != null)
        {
            attack.Attack();
        }
    }
}
