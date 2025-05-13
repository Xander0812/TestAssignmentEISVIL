using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GridManager))]
public class CustomInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GridManager gridManager = (GridManager)target;
        if(GUILayout.Button("Spawn Grid"))
        {
            gridManager.SpawnGrid();
        }

        if(GUILayout.Button("Clear Grid"))
        {
            gridManager.ClearGrid();
        }
    }

}
