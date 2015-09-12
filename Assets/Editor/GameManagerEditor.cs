using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        GameManager manager = (GameManager)target;

        EditorGUILayout.Separator();
        EditorGUILayout.LabelField("References to machines' gameobjects");
        EditorGUILayout.Space();

        manager.Machine01 = (GameObject)EditorGUILayout.ObjectField("Piła", manager.Machine01, typeof(GameObject), false);
        manager.Machine02 = (GameObject)EditorGUILayout.ObjectField("Magnes", manager.Machine02, typeof(GameObject), false);
        manager.Machine03 = (GameObject)EditorGUILayout.ObjectField("Tesla", manager.Machine03, typeof(GameObject), false);
        manager.Machine04 = (GameObject)EditorGUILayout.ObjectField("Strzykawka", manager.Machine04, typeof(GameObject), false);
        manager.Machine05 = (GameObject)EditorGUILayout.ObjectField("Wałek", manager.Machine05, typeof(GameObject), false);

        EditorGUILayout.Separator();
        EditorGUILayout.LabelField("Music related variables");
        EditorGUILayout.Space();

        manager.BeatsPerMinute = EditorGUILayout.FloatField("Beats Per Minute", manager.BeatsPerMinute);
        manager.Beats = EditorGUILayout.IntField("Beats In Bar", manager.Beats);

        EditorGUILayout.Separator();
        EditorGUILayout.LabelField("Machines activation and deactivation");
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Activation");
        EditorGUILayout.Space();

        manager.StartBar = EditorGUILayout.IntField("Start Bar", manager.StartBar);
        manager.StartBeat = EditorGUILayout.IntField("Start Beat", manager.StartBeat);
        
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Deactivation");
        EditorGUILayout.Space();

        manager.EndBar = EditorGUILayout.IntField("End Bar", manager.EndBar);
        manager.EndBeat = EditorGUILayout.IntField("End Beat", manager.EndBeat);
    }
}



