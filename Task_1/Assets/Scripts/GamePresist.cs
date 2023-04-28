using System.Linq;
using UnityEngine;

public class GamePresist : MonoBehaviour
{
    GameData gameData = new GameData();
    Player player;

    void Awake() => player = FindObjectOfType<Player>();

    public void Load(int gameNumber)//load button
    {
        string json = PlayerPrefs.GetString("GameData" + gameNumber);
        gameData = JsonUtility.FromJson<GameData>(json);
        
        foreach (var exp in FindObjectsOfType<Exp>(true))//loop through all exp object 
        {
            //comparing expdata name with gameObject(exp) name 
            var expData = gameData.expDatas.FirstOrDefault(t => t.expName == exp.name);
            exp.Load(expData);
        }

        player.transform.position = gameData.playerPos;
        player.transform.localScale = gameData.playerScale;
        player.exp = gameData.playerExp;
        player.playerName = gameData.playerName;

        Debug.Log("Load Player Scale:" + gameData.playerScale);
    }

    public void Save(int gameNumber)//save button
    {
        gameData.expDatas.Clear();//empty the list then save

        foreach(var exp in FindObjectsOfType<Exp>(true))//looping through all exp object
        {
            gameData.expDatas.Add(exp.ExpData); //saving exp data in list expDatas
        }

        //populating gameData from player class
        gameData.playerName = player.playerName;
        gameData.playerExp = player.exp;
        gameData.playerPos = player.transform.position;

        gameData.playerScale = player.transform.localScale;

        //serealizing gamedata(expDatas, playerPos, PlayerScale, PlayerName)
        var json = JsonUtility.ToJson(gameData);
        PlayerPrefs.SetString("GameData" + gameNumber, json);
    }
}
