using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public InputField input;
    public string playerName;

    private static Menu instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void EnterButton()
    {
        playerName = input.text;
        PlayerPrefs.SetString("PlayerName", playerName);
        SceneManager.LoadScene(1);
    }

    public static string GetPlayerName()
    {
        return PlayerPrefs.GetString("PlayerName");
    }
}
