using System.Linq;
using UnityEngine;

public class GamePresist : MonoBehaviour
{
    GameData gameData = new GameData();
    Player player;

    void Awake() => player = FindObjectOfType<Player>();

    public void Load(int gameNumber)
    {
        string json = PlayerPrefs.GetString("GameData" + gameNumber);
        gameData = JsonUtility.FromJson<GameData>(json);

        foreach (var exp in FindObjectsOfType<Exp>(true))
        {
            var expData = gameData.expDatas.FirstOrDefault(t => t.expName == exp.name);
            exp.Load(expData);
        }

        player.transform.position = gameData.playerPos;
        player.transform.localScale = gameData.playerScale;
        player.exp = gameData.playerExp;
        player.playerName = gameData.playerName;
    }

    public void Save(int gameNumber)
    {
        gameData.expDatas.Clear();

        foreach (var exp in FindObjectsOfType<Exp>(true))
        {
            gameData.expDatas.Add(exp.ExpData);
        }

        gameData.playerName = player.playerName;
        gameData.playerExp = player.exp;
        gameData.playerPos = player.transform.position;
        gameData.playerScale = player.transform.localScale;

        var json = JsonUtility.ToJson(gameData);
        PlayerPrefs.SetString("GameData" + gameNumber, json);
    }
}
