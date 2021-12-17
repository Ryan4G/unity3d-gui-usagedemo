using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Enemy_Type1))]
public class Enemy_Type1Inspector : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        //var concertTarget = base.target as Enemy_Type1;

        //if (GUILayout.Button("preset1"))
        //{
        //    concertTarget.hp = 100;
        //    concertTarget.speed = 600;
        //    concertTarget.atk = 6;
        //}

        //if (GUILayout.Button("preset2"))
        //{
        //    concertTarget.hp = 200;
        //    concertTarget.speed = 550;
        //    concertTarget.atk = 4;
        //}

        serializedObject.Update();

        var hpProp = serializedObject.FindProperty("hp");
        var speedProp = serializedObject.FindProperty("speed");
        var atkProp = serializedObject.FindProperty("atk");

        // inspect the GUI content change
        using (var change = new EditorGUI.ChangeCheckScope())
        {
            EditorGUILayout.PropertyField(hpProp, new GUIContent("Enemy hp"));
            EditorGUILayout.PropertyField(speedProp, new GUIContent("Enemy speed"));
            EditorGUILayout.PropertyField(atkProp, new GUIContent("Enemy atk"));

            if (GUILayout.Button("preset1"))
            {
                hpProp.intValue = 100;
                speedProp.floatValue = 600;
                atkProp.intValue = 6;
            }

            if (GUILayout.Button("preset2"))
            {
                hpProp.intValue = 200;
                speedProp.floatValue = 550;
                atkProp.intValue = 4;
            }

            if (change.changed)
            {
                serializedObject.ApplyModifiedProperties();
            }
        }
    }

    public override bool HasPreviewGUI()
    {
        return true;
    }

    public override GUIContent GetPreviewTitle()
    {
        return new GUIContent("Enemy_Type1 Debug");
    }

    public override void OnPreviewGUI(Rect r, GUIStyle background)
    {
        base.OnPreviewGUI(r, background);

        GUILayout.Box("Enemy State...");
    }
}
