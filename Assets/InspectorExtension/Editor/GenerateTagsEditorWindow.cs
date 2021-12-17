using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public class GenerateTagsEditorWindow : EditorWindow
{
    struct EnemyInfo
    {
        public Vector3 Position { get; set; }
    }

    [MenuItem("Tools/Generate Tags")]
    static void Setup()
    {
        GetWindow<GenerateTagsEditorWindow>();
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Generate"))
        {
            var sb = new StringBuilder();
            sb.AppendLine("public class _Const");
            sb.AppendLine("{");

            for(var i = 0; i < 32; i++)
            {
                var name = LayerMask.LayerToName(i);

                // filter special charecter
                name = name
                    .Replace(" ", "_")
                    .Replace("&", "_")
                    .Replace("/", "_")
                    .Replace(".", "_")
                    .Replace(",", "_")
                    .Replace(";", "_")
                    .Replace("-", "_");

                if (!string.IsNullOrEmpty(name))
                {
                    sb.AppendFormat("\tpublic const int LAYER_{0} = {1};\n", name.ToUpper(), i);
                }
            }

            sb.AppendLine("\tpublic const string " + "Tag_Untagged".ToUpper() + " = " + "\"Untagged\";");
            sb.AppendLine("\tpublic const string " + "Tag_Respawn".ToUpper() + " = " + "\"Respawn\";");
            sb.AppendLine("\tpublic const string " + "Tag_Finish".ToUpper() + " = " + "\"Finish\";");
            sb.AppendLine("\tpublic const string " + "Tag_EditorOnly".ToUpper() + " = " + "\"EditorOnly\";");
            sb.AppendLine("\tpublic const string " + "Tag_MainCamera".ToUpper() + " = " + "\"MainCamera\";");
            sb.AppendLine("\tpublic const string " + "Tag_Player".ToUpper() + " = " + "\"Player\";");
            sb.AppendLine("\tpublic const string " + "Tag_GameController".ToUpper() + " = " + "\"GameController\";");

            var asset = UnityEditor.AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset");

            if ((asset != null) && (asset.Length > 0))
            {
                for (int i = 0; i < asset.Length; i++)
                {
                    var so = new UnityEditor.SerializedObject(asset[i]);
                    var tags = so.FindProperty("tags");

                    for (int j = 0; j < tags.arraySize; ++j)
                    {
                        var item = tags.GetArrayElementAtIndex(j).stringValue;
                        sb.AppendFormat("\tpublic const string TAG_{0} = \"{1}\";\n", item.ToUpper(), item);
                    }
                }
            }

            sb.AppendLine("}");
            File.WriteAllText("Assets/GeneratedConst.cs", sb.ToString());
            UnityEditor.AssetDatabase.Refresh();
        }
    }
}
