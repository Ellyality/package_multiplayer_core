using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Elly.Multiplayer
{
    [CustomEditor(typeof(MonsterStructureScriptableObject))]
    [CanEditMultipleObjects]
    public class MonsterStructureEditor : Editor
    {
        MonsterStructureScriptableObject comp;

        public void OnEnable()
        {
            comp = (MonsterStructureScriptableObject)target;
        }

        public override void OnInspectorGUI()
        {
            SerializedProperty Structure = serializedObject.FindProperty("Structure");
            EditorGUILayout.PropertyField(Structure.FindPropertyRelative("Name"));
            EditorGUILayout.PropertyField(Structure.FindPropertyRelative("Keyword"));
            EditorGUILayout.PropertyField(Structure.FindPropertyRelative("Image"));
            EditorGUILayout.PropertyField(Structure.FindPropertyRelative("Description"));
            EditorGUILayout.PropertyField(Structure.FindPropertyRelative("Race"));
            EditorGUILayout.PropertyField(Structure.FindPropertyRelative("Aggressive"));
            EditorGUILayout.PropertyField(Structure.FindPropertyRelative("StatusString"));

            MonsterRaceStructureScriptableObject monster_race = comp.Structure.Race;

            if (monster_race != null)
            {
                CreatureStatus[] int_status = monster_race.Structure.Status.ToList()
                    .Where(x => x != null)
                    .Select(x => x.Status)
                    .Where(x =>  x.DataType == DataType.Integer)
                    .ToArray();
                CreatureStatus[] float_status = monster_race.Structure.Status.ToList()
                    .Where(x => x != null)
                    .Select(x => x.Status)
                    .Where(x => x.DataType == DataType.Float)
                    .ToArray();
                CreatureStatus[] str_status = monster_race.Structure.Status.ToList()
                    .Where(x => x != null)
                    .Select(x => x.Status)
                    .Where(x => x.DataType == DataType.String)
                    .ToArray();

                if (str_status.Length > 0) DrawStr(str_status);
                if (int_status.Length > 0) DrawInt(int_status);
                if (float_status.Length > 0) DrawFloat(float_status);
            }

            serializedObject.ApplyModifiedProperties();
            EditorUtility.SetDirty(comp);
        }

        void DrawStr(CreatureStatus[] str_status)
        {
            GUILayout.Label("String Property");
            EditorGUI.indentLevel++;
            List<Pair<string>> count = new List<Pair<string>>();
            for (int i = 0; i < str_status.Length; i++)
            {
                int index = comp.Structure.StatusString.FindIndex(x => x.Key == str_status[i].Name);
                if (index == -1)
                {
                    Pair<string> buffer = new Pair<string>();
                    buffer.Key = str_status[i].Name;
                    buffer.Value = EditorGUILayout.TextField(str_status[i].Name, buffer.Value);
                    comp.Structure.StatusString.Add(buffer);
                    count.Add(buffer);
                }
                else
                {
                    Pair<string> buffer = comp.Structure.StatusString[index];
                    buffer.Value = EditorGUILayout.TextField(str_status[i].Name, buffer.Value);
                    count.Add(buffer);
                }
            }
            comp.Structure.StatusString = count;
            EditorGUI.indentLevel--;
        }

        void DrawInt(CreatureStatus[] int_status)
        {
            GUILayout.Label("Integer Property");
            EditorGUI.indentLevel++;
            List<Pair<int>> count = new List<Pair<int>>();
            for (int i = 0; i < int_status.Length; i++)
            {
                int index = comp.Structure.StatusInt.FindIndex(x => x.Key == int_status[i].Name);
                if (index == -1)
                {
                    Pair<int> buffer = new Pair<int>();
                    buffer.Key = int_status[i].Name;
                    buffer.Value = EditorGUILayout.IntField(int_status[i].Name, buffer.Value);
                    comp.Structure.StatusInt.Add(buffer);
                    count.Add(buffer);
                }
                else
                {
                    Pair<int> buffer = comp.Structure.StatusInt[index];
                    buffer.Value = EditorGUILayout.IntField(int_status[i].Name, buffer.Value);
                    count.Add(buffer);
                }
            }
            comp.Structure.StatusInt = count;
            EditorGUI.indentLevel--;
        }

        void DrawFloat(CreatureStatus[] float_status)
        {
            GUILayout.Label("Float Property");
            EditorGUI.indentLevel++;
            List<Pair<float>> count = new List<Pair<float>>();
            for (int i = 0; i < float_status.Length; i++)
            {
                int index = comp.Structure.StatusFloat.FindIndex(x => x.Key == float_status[i].Name);
                if (index == -1)
                {
                    Pair<float> buffer = new Pair<float>();
                    buffer.Key = float_status[i].Name;
                    buffer.Value = EditorGUILayout.FloatField(float_status[i].Name, buffer.Value);
                    comp.Structure.StatusFloat.Add(buffer);
                    count.Add(buffer);
                }
                else
                {
                    Pair<float> buffer = comp.Structure.StatusFloat[index];
                    buffer.Value = EditorGUILayout.FloatField(float_status[i].Name, buffer.Value);
                    count.Add(buffer);
                }
            }
            comp.Structure.StatusFloat = count;
            EditorGUI.indentLevel--;
        }
    }
}
