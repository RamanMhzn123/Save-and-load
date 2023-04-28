using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData 
{
    public string playerName;
    public int playerExp;
    public Vector3 playerPos;
    public Vector3 playerScale;
    public List<ExpData> expDatas = new List<ExpData>();
}
