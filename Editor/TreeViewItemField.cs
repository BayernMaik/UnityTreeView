using PlasticPipe.PlasticProtocol.Messages;
using System;
using UnityEngine;

namespace UnityEditor.Treeview
{
    [Serializable]
    public abstract class TreeViewItemField
    {
        #region Label
        private GUIContent label = GUIContent.none;
        public GUIContent Label
        {
            get { return this.label; }
            set { this.label = value; }
        }
        #endregion
        public TreeViewItemField() { }
        public TreeViewItemField(string name)
        {
            this.label.text = name;
        }
        public TreeViewItemField(string name, string tooltip)
        {
            this.label.text = name;
            this.label.tooltip = tooltip;
        }
        public TreeViewItemField(GUIContent label)
        {
            this.label = label;
        }
        public abstract void OnGUI();
        #region Delegates
        private Delegate changeCallback;
        public Delegate ChangeCallback
        {
            get { return this.changeCallback; }
            set { this.changeCallback = value; }
        }
        #endregion
    }

    /// <summary>
    /// Tree View Item Field for Integer
    /// </summary>
    [Serializable]
    public class TreeViewItemIntField : TreeViewItemField
    {
        #region Attributes
        [SerializeField] private int value;
        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        #endregion

        #region Constructors
        public TreeViewItemIntField(string name) : base(name)
        {
            
        }
        public TreeViewItemIntField(string name, string tooltip) : base(name, tooltip)
        {

        }
        public TreeViewItemIntField(GUIContent label) : base(label)
        {

        }
        #endregion

        #region Methods
        public override void OnGUI()
        {
            // Begin Change Check
            EditorGUI.BeginChangeCheck();
            // Int Field
            this.value = EditorGUILayout.IntField(this.Label, this.value);
            // End Change Check
            if (EditorGUI.EndChangeCheck())
            {
                // Invoke Callback
                this.ChangeCallback?.Invoke();
            }
        }
        #endregion
    }
    /// <summary>
    /// Tree View Item Field for Float
    /// </summary>
    [Serializable]
    public class TreeViewItemFloatField : TreeViewItemField
    {
        #region Attributes
        [SerializeField] private float value;
        public float Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        #endregion

        #region Constructors
        public TreeViewItemFloatField(string name) : base(name)
        {

        }
        public TreeViewItemFloatField(string name, string tooltip) : base(name, tooltip)
        {

        }
        public TreeViewItemFloatField(GUIContent label) : base(label)
        {

        }
        #endregion

        #region Methods
        public override void OnGUI()
        {
            // Begin Change Check
            EditorGUI.BeginChangeCheck();
            // Int Field
            this.value = EditorGUILayout.FloatField(this.Label, this.value);
            // End Change Check
            if (EditorGUI.EndChangeCheck())
            {
                // Invoke Callback
                this.ChangeCallback?.Invoke();
            }
        }
        #endregion
    }
    /// <summary>
    /// Tree View Item Field for Double
    /// </summary>
    [Serializable]
    public class TreeViewItemDoubleField : TreeViewItemField
    {
        #region Attributes
        [SerializeField] private double value;
        public double Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        #endregion

        #region Constructors
        public TreeViewItemDoubleField(string name) : base(name)
        {

        }
        public TreeViewItemDoubleField(string name, string tooltip) : base(name, tooltip)
        {

        }
        public TreeViewItemDoubleField(GUIContent label) : base(label)
        {

        }
        #endregion

        #region Methods
        public override void OnGUI()
        {
            // Begin Change Check
            EditorGUI.BeginChangeCheck();
            // Int Field
            this.value = EditorGUILayout.DoubleField(this.Label, this.value);
            // End Change Check
            if (EditorGUI.EndChangeCheck())
            {
                // Invoke Callback
                this.ChangeCallback?.Invoke();
            }
        }
        #endregion
    }
    [Serializable]
    public class TreeViewItemTextField : TreeViewItemField
    {
        #region Attributes
        #region Object
        [SerializeField] private string value;
        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        #endregion
        #endregion

        #region Constructors
        public TreeViewItemTextField(){}
        public TreeViewItemTextField(GUIContent label, UnityEngine.Object value, System.Type type) : base(label)
        {
        }
        #endregion

        #region Methods
        public override void OnGUI()
        {
            // Begin Change Check
            EditorGUI.BeginChangeCheck();
            // Object Field
            this.value = EditorGUILayout.TextField(this.Label, this.value);
            // End Change Check
            if (EditorGUI.EndChangeCheck())
            {
                // Invoke Callback
                this.ChangeCallback?.Invoke();
            }
        }
        #endregion
    }
    /// <summary>
    /// Tree View Item Field for Objects filtered by Type.
    /// </summary>
    [Serializable]
    public class TreeViewItemDataObject : TreeViewItemField
    {
        #region Attributes
        #region Object
        [SerializeField] private UnityEngine.Object value;
        public UnityEngine.Object Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        #endregion
        #region Type
        private Type type;
        public Type Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
        #endregion
        #endregion

        #region Constructors
        public TreeViewItemDataObject()
        {
            this.type = typeof(UnityEngine.Object);
        }
        public TreeViewItemDataObject(GUIContent label, UnityEngine.Object value, System.Type type) : base(label)
        {
            this.value = value;
            this.type = type;
        }
        #endregion

        public override void OnGUI()
        {
            // Begin Change Check
            EditorGUI.BeginChangeCheck();
            // Object Field
            this.value = EditorGUILayout.ObjectField(this.Label, this.value, this.type, true);
            // End Change Check
            if (EditorGUI.EndChangeCheck())
            {
                // Invoke Callback
                this.ChangeCallback?.Invoke();
            }
        }
    }
    /// <summary>
    /// Tree View Item Property Field
    /// </summary>
    [SerializeField]
    public class TreeViewItemPropertyField : TreeViewItemField
    {
        #region Attributes
        [SerializeField] private SerializedProperty serializedProperty;
        public SerializedProperty SerializedProperty
        {
            get { return this.serializedProperty; }
            set { this.serializedProperty = value; }
        }
        #endregion

        #region Constructors
        public TreeViewItemPropertyField(){}
        public TreeViewItemPropertyField(GUIContent label, SerializedProperty serializedProperty) : base(label)
        {
            this.serializedProperty = serializedProperty;
        }
        #endregion

        public override void OnGUI()
        {
            // Begin Change Check
            EditorGUI.BeginChangeCheck();
            // Object Field
            EditorGUILayout.PropertyField(this.serializedProperty);
            // End Change Check
            if (EditorGUI.EndChangeCheck())
            {
                // Invoke Callback
                this.ChangeCallback?.Invoke();
            }
        }
    }

    public delegate void Delegate();
    public delegate void Delegate<T>();
}