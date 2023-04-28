using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    public string playerName;

    // The player's experience points (can be read and written to)
    public int exp { get; set; }

    Rigidbody rb;
    Animator animator;
    
    bool isAnimating = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        playerName = Menu.GetPlayerName();
    }

    void Update()
    {
        // player movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 velocity = new Vector3(horizontal, 0, vertical).normalized;
        rb.velocity = velocity * speed;

        // check if the user pressed the spacebar
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // toggle animation
            if (isAnimating)
            {
                animator.enabled = false;
                isAnimating = false;
            }
            else
            {
                animator.enabled = true;
                animator.Play("cubeAnim");
                isAnimating = true;
            }
        }
    }

    public void AddExp()
    {
        exp++;
    }
}
