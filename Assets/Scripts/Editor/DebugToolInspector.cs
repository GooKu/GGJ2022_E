using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DebugTool))]
public class DebugToolInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        DebugTool debugTool = (DebugTool) target;

        if (GUILayout.Button("Clear Data"))
        {
            debugTool.ClearData();
        }
    }
}