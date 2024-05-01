using System.Collections.Generic;
using UnityEngine;

namespace UnityEditor.Treeview
{
    public class TreeViewItem
    {
        #region Attributes
        #region Parent
        private TreeViewItem parent;
        public TreeViewItem Parent
        {
            get { return this.parent; }
        }
        #endregion
        #region Children
        private List<TreeViewItem> children = new List<TreeViewItem>();
        public List<TreeViewItem> Children
        {
            get { return this.children; }
        }
        #endregion
        #region Fields
        private List<TreeViewItemField> datas = new List<TreeViewItemField>();
        public List<TreeViewItemField> Data
        {
            get { return this.datas; }
            set { this.datas = value; }
        }
        #endregion
        #region GUI
        private bool foldout = false;

        private GUIContent guiContent = new GUIContent("Element", "Tree View Element");
        public string Name
        {
            get { return this.guiContent.text; }
            set { this.guiContent.text = value; }
        }
        public string toolTip
        {
            get { return this.guiContent.tooltip; }
            set { this.guiContent.tooltip = value; }
        }
        #endregion
        #endregion

        #region Constructors
        public TreeViewItem(){}
        public TreeViewItem(TreeViewItem parent)
        {
            this.parent = parent;
        }
        public TreeViewItem(string name)
        {
            this.guiContent.text = name;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Check recursive if child structure contains item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(TreeViewItem item)
        {
            if (this.children != null)
            {
                if (this.children.Contains(item))
                {
                    return true;
                }
                for (int i = 0; i < this.children.Count; i++)
                {
                    this.children[i].Contains(item);
                }
            }
            return false;
        }
        /// <summary>
        /// Check recursive if parent structure contains item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Inherits(TreeViewItem item)
        {
            if (this.parent != null)
            {
                if (this.parent == item)
                {
                    return true;
                }
                this.parent.Inherits(item);
            }
            return false;
        }
        /// <summary>
        /// Add item to children
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        public bool Add(TreeViewItem child)
        {
            if (!this.children.Contains(child))
            {
                this.children.Add(child);
                child.SetParent(this);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Add(TreeViewItemField field)
        {
            this.datas.Add(field);
        }
        public void SetParent(TreeViewItem parent)
        {
            this.parent = parent;
        }
        /// <summary>
        /// Layout item in editor
        /// </summary>
        public void OnGUI()
        {
            // Begin Horizontal
            EditorGUILayout.BeginHorizontal();

            // Foldout
            if (this.children.Count > 0)
            {
                // Foldout
                this.foldout = EditorGUILayout.Foldout(this.foldout, this.guiContent, true);
            }
            else
            {
                // Label
                EditorGUILayout.LabelField(this.guiContent);
            }

            // Data
            for (int i = 0; i < this.datas.Count; i++)
            {
                this.datas[i].OnGUI();
            }

            // End Horizontal
            EditorGUILayout.EndHorizontal();

            // Draw Child Elements
            if (this.foldout)
            {
                // Increase Indent
                EditorGUI.indentLevel++;
                for (int i = 0; i < this.children.Count; i++)
                {
                    this.children[i].OnGUI();
                }
                // Decrease Indent
                EditorGUI.indentLevel--;
            }
        }
        #endregion
    }
}