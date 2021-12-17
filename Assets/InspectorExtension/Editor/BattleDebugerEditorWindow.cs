using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BattleDebugerEditorWindow : EditorWindow
{
    struct EnemyInfo
    {
        public Vector3 Position { get; set; }
    }

    [MenuItem("Tools/Battle Debuger")]
    static void Setup()
    {
        GetWindow<BattleDebugerEditorWindow>();
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Create Enemy_Type1"))
        {

        }

        if (GUILayout.Button("Create Enemy_Type1 x10"))
        {

        }

        if (GUILayout.Button("Killed All Enemy"))
        {

        }
    }

    private void Awake()
    {
        SceneView.duringSceneGui += DuringSceneGuiBind;
    }

    private void OnDestroy()
    {
        SceneView.duringSceneGui -= DuringSceneGuiBind;
    }

    private void DuringSceneGuiBind(SceneView sceneView)
    {
        var enemies = GetEnemies();
        
        for(int i = 0; i < enemies.Length; i++)
        {
            var enemy = enemies[i];

            Handles.DrawWireCube(enemy.Position, new Vector3(.5f, 1f, .5f));
        }
    }

    EnemyInfo[] GetEnemies()
    {
        return new EnemyInfo[]
        {
            new EnemyInfo{
                Position = Vector3.zero
            },

            new EnemyInfo
            {
                Position = Vector3.left * 1.5f
            }
        };
    }
}
