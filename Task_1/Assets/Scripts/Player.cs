using UnityEngine;

public class Player : MonoBehaviour, ISaveState
{
    
    [SerializeField] float speed = 3f;
    public string playerName;
    public int exp { get; set; }

    bool isAnimating = true;
    Rigidbody rb;
    Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Start() => playerName = Menu.GetPlayerName();

    void Update()
    {
        //player movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 velocity = new Vector3(horizontal, 0, vertical).normalized;
        rb.velocity = velocity * speed;

        // Check if the user pressed the spacebar
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Check if the animation is playing
            if (isAnimating)
            {
                // Stop the animation
                animator.enabled = false;
                isAnimating = false;
            }
            else
            {
                // Play the animation
                animator.enabled = true;
                animator.Play("cubeAnim");
                isAnimating = true;
            }
        }
    }

    public void Save(int gameNumber)
    {
        //convert vector3 to json
        string jsonPos = JsonUtility.ToJson(transform.position);
        string jsonScale = JsonUtility.ToJson(transform.localScale);

        //save jsaon in playerPrefs
        PlayerPrefs.SetString(gameNumber + "PlayerName", playerName);
        PlayerPrefs.SetString(gameNumber + "PlayerPos", jsonPos);
        PlayerPrefs.SetString(gameNumber + "PlayerScale", jsonScale);
        PlayerPrefs.SetInt(gameNumber + "PlayerExp", exp);
    }

    public void Load(int gameNumber)
    {
        if (PlayerPrefs.HasKey(gameNumber + "PlayerPos"))
        {
            transform.position = JsonUtility.FromJson<Vector3>(PlayerPrefs.GetString(gameNumber + "PlayerPos"));
            transform.localScale = JsonUtility.FromJson<Vector3>(PlayerPrefs.GetString(gameNumber + "PlayerScale"));
            exp = PlayerPrefs.GetInt(gameNumber + "PlayerExp");
            playerName = PlayerPrefs.GetString(gameNumber + "PlayerName");
        }
    }

    public void AddExp()
    {
        exp++;
    }
}
