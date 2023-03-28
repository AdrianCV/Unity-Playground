using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;
using UnityEngine.Networking;

[CustomEditor(typeof(TakeDamageEditorEvent))]
public class TakeDamageButton : Editor
{
    public override void OnInspectorGUI()
    {
        var ButtonStyle = new GUIStyle(GUI.skin.button);
        ButtonStyle.normal.textColor = Color.white;
        //ButtonStyle.fontStyle = FontStyle.Bold;
        ButtonStyle.fontSize = 16;

        if (GUILayout.Button("Spawn Damage Number", ButtonStyle, GUILayout.Height(24)))
        {
            Instantiate(Resources.Load("DamageNumber"), new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
}
