using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WrestlingBooker
{
    /// <summary>
    /// Defines a node in a simple tree
    /// </summary>
    class TreeNode
    {
        private TreeNode _parent;          // Parent node
        private List<TreeNode> _children;  // Child nodes

        /// <summary>
        /// Parent node
        /// </summary>
        public TreeNode Parent
        {
            get { return _parent; }
            set
            {
                // Remove me from my existing parent
                if (null != _parent)
                {
                    _parent.Children.Remove(this);
                }

                // Set my new parent and add me to its children
                _parent = value;
                if (null != _parent)
                {
                    _parent.Children.Add(this);
                }
            }
        }

        /// <summary>
        /// Child nodes
        /// </summary>
        public List<TreeNode> Children
        {
            get { return _children; }
        }

        /// <summary>
        /// Root of the tree
        /// </summary>
        public TreeNode Root
        {
            get
            {
                // If I have no parent, I'm the root
                if (_parent == null)
                {
                    return this;
                }
                else // Otherwise, return the root of my parent
                {
                    return _parent.Root;
                }
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parent">Parent node</param>
        public TreeNode(TreeNode parent)
        {
            Parent = parent;
            _children = new List<TreeNode>();
        }
    }
}
