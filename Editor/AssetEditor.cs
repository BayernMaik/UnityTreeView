using UnityEditor;
using UnityEngine;
using UnityEditor.Treeview;

[CustomEditor(typeof(Asset))]
[CanEditMultipleObjects]
public class AssetEditor : Editor
{
    private Asset asset;
    SerializedProperty serializedProperty;

    private TreeView treeView = new TreeView();

    void OnEnable()
    {
        Debug.Log("Enable");
        this.asset = (Asset)target;
        this.serializedProperty = this.serializedObject.FindProperty("assets");

        this.Init();
    }

    public override void OnInspectorGUI()
    {
        this.serializedObject.Update();

        EditorGUILayout.PropertyField(this.serializedProperty);

        this.treeView.OnGUI();

        this.serializedObject.ApplyModifiedProperties();
    }

    private void Init()
    {
        for (int i = 0; i < this.asset.Children.Length; i++)
        {
            this.asset.Children[i].AddToTree(this.treeView, null);
        }
    }
}