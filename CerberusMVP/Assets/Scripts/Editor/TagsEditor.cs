
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class TagsEditor : EditorWindow
{
    [Serializable]
    public struct Tag{
        public string tagName;
        public bool tagBool;
    }
    public Tag[] tags = new Tag[10];
    public List<Tag> tags2 = new List<Tag>(5);


    [MenuItem("Window/TagsEditor")]
    public static void ShowWindow() {
        GetWindow<TagsEditor>("Tags Editor");
    }
    private void OnGUI() {

        GUILayout.Label("Allows setting of tags for objects", EditorStyles.boldLabel);

        foreach(Tag tag in tags) {
            GUILayout.BeginHorizontal();
            EditorGUILayout.TextArea(tag.tagName);
            EditorGUILayout.Toggle(tag.tagBool);
            GUILayout.EndHorizontal() ;
        }


        if (GUILayout.Button("Add Tag")) {
            //code when button is clicked
            

        }


        if (GUILayout.Button("Set Tags")) {
            //code when button is clicked
            SetTags();
            
        }
    }

    void SetTags() {

        foreach (GameObject obj in Selection.gameObjects) {
            Tags tags = obj.GetComponent<Tags>();
            if (tags != null) {
                
            }
            else {
                obj.AddComponent<Tags>();
            }

        }
    }
}
