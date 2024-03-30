using Ellyality.Sqlite;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Ellyality.RPG
{
    public class MultiplayerDatabaseWindow : EditorWindow
    {
        int select = 0;
        readonly string[] tabs = new string[] { "Setting", "Database" };
        bool address_from_setting = true;
        string database_address = "127.0.0.1";
        SQLiteConnection conn = null;
        MultiplayerSetting setting;

        bool isconnect => conn != null;
        string address
        {
            get
            {
                return address_from_setting ? setting.Database_Address : database_address;
            }
        }

        [MenuItem("Window/Multiplayer/Database Management")]
        static void CreateWindow()
        {
            MultiplayerDatabaseWindow wnd = GetWindow<MultiplayerDatabaseWindow>();
            wnd.titleContent = new GUIContent("Multiplayer Database");
        }

        void OnEnable()
        {
            setting = MultiplayerSetting.Load();
        }

        void OnGUI()
        {
            EditorGUILayout.Space();
            select = GUILayout.Toolbar(select, tabs);
            EditorGUILayout.Space();
            if (select == 0) RenderSetting();
            else if (select == 1) RenderDatabase();
        }

        void RenderSetting()
        {
            address_from_setting = EditorGUILayout.Toggle("Address From Setting", address_from_setting);
            if (address_from_setting)
            {
                GUI.enabled = false;
                EditorGUILayout.TextField("Database Address", setting.Database_Address);
                GUI.enabled = true;
            }
            else
            {
                database_address = EditorGUILayout.TextField("Database Address", database_address);
            }
            EditorGUILayout.BeginHorizontal();
            bool click1 = GUILayout.Button(isconnect ? "Disconnect" : "Connect");
            GUI.enabled = isconnect;
            bool click2 = GUILayout.Button("Migrate");
            GUI.enabled = true;
            EditorGUILayout.EndHorizontal();
            if (click1) Click1();
            if (click2) Click2();
            if (isconnect)
            {
                var player = conn.GetTableInfo("player");
                var monster = conn.GetTableInfo("monster");
                var item = conn.GetTableInfo("item");
                var _event = conn.GetTableInfo("event");
                GUILayout.Label("Tables list:");
                EditorGUI.indentLevel++;
                GUI.enabled = false;
                EditorGUILayout.Toggle("player table exist", player.Count > 0);
                EditorGUILayout.Toggle("monster table exist", monster.Count > 0);
                EditorGUILayout.Toggle("item table exist", item.Count > 0);
                EditorGUILayout.Toggle("event table exist", _event.Count > 0);
                GUI.enabled = true;
                EditorGUI.indentLevel--;
            }
        }

        void Click1()
        {
            if (isconnect)
            {
                conn.Close();
                conn = null;
            }
            else
            {
                conn = new SQLiteConnection(address, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
            }
        }

        void Click2()
        {
            if(setting.PlayerTemplate == null)
            {
                Debug.LogWarning("Player template is null, cannot migrate this table");
            }
            else
            {
                PlayerStructure ps = setting.PlayerTemplate.Structure;
                List<TableMapping> tables = conn.TableMappings.ToList();
                bool havetable = tables.Exists(x => x.TableName == "player");
                Debug.Log($"Table Exist: {havetable} player");
                if (havetable)
                {
                    var tb = tables.Find(x => x.TableName == "player");
                }
                else
                {
                    string command = "CREATE TABLE IF NOT EXISTS player(id INTEGER PRIMARY KEY ASC,";
                    for(int i = 0; i < ps.Status.Length; i++)
                    {
                        CreatureStatus cs = ps.Status[i].Status;
                        command += $"{cs.Keyword} {DataTypeToString(cs.DataType)}";
                        if (cs.Unique) command += $" UNIQUE";
                        if (cs.NotNull) command += $" NOT NULL";
                        if(i != ps.Status.Length - 1)
                        {
                            command += ",";
                        }
                    }
                    command += ");";
                    conn.Execute(command);
                }
            }
        }

        void RenderDatabase()
        {
            
        }

        string DataTypeToString(DataType dt)
        {
            switch (dt)
            {
                default:
                case DataType.String:
                    return "TEXT";
                case DataType.Float:
                    return "REAL";
                case DataType.Integer:
                    return "INT";
                case DataType.Byte:
                    return "BLOB";
            }
        }
    }
}
