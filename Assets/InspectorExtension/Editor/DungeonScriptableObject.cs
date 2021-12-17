using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DungeonConfig", menuName = "MyProj/Dungeon Config")]
public class DungeonScriptableObject : ScriptableObject
{
    [Serializable]
    public class DungeonInfo
    {
        public string displayName;
        public string unitySceneName;
        public string levelLimitRange;
    }

    public DungeonInfo[] dungeonInfoArray;
}
