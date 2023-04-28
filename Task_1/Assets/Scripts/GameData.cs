using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    public string playerName;
    public int playerExp;
    public Vector3 playerPos, playerScale;
    public List<ExpData> expDatas = new List<ExpData>();
}
