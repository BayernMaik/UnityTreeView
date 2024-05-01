using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEditor.Treeview
{
    [Serializable]
    public class TreeView
    {
        #region Attributes 
        #region Items
        [SerializeField] private List<TreeViewItem> items = new List<TreeViewItem>();
        public List<TreeViewItem> Items
        {
            get { return this.items; }
            set { this.items = value; }
        }
        #endregion
        #endregion

        #region Constructors
        public TreeView() {}
        #endregion

        public void OnGUI()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                this.items[i].OnGUI();
            }
        }    
        public void Add(TreeViewItem item)
        {
            this.items.Add(item);
        }
    }
}