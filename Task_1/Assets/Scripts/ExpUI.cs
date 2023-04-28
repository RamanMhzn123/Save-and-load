using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExpUI : MonoBehaviour
{
    Player player;
    Text expText;

    public Text playerName;

    void Awake()
    {
        player = FindObjectOfType<Player>();
        expText= GetComponent<Text>();
    }

    void Update()
    {
        expText.text = player.exp +" EXP";
        playerName.text = player.playerName;
    }

    public void BackButton() 
    {
        SceneManager.LoadScene(0);
    }
}
