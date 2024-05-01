using UnityEngine;

namespace UnityEditor.Treeview
{
    [CreateAssetMenu(fileName = "TreeView", menuName = "ScriptableObjects/TreeView", order = 1)]
    public class Asset : ScriptableObject
    {
        [SerializeField] private Asset[] assets;
        public Asset[] Children
        {
            get { return this.assets; }
            set { this.assets = value; }
        }

        public void AddToTree(TreeView treeView, TreeViewItem parent)
        {
            TreeViewItem item = new TreeViewItem(this.name);
            if (parent == null)
            {
                treeView.Add(item);
            }
            else
            {
                parent.Add(item);
            }
            if (this.assets != null)
            {
                for (int i = 0; i < this.assets.Length; i++)
                {
                    this.assets[i].AddToTree(treeView, item);
                }
            }
        }
    }
}