using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WrestlingBooker
{
    /// <summary>
    /// Operations that can be hooked into by attachments
    /// </summary>
    enum SceneNodeOperation
    {
        Update,
        Render,
        GUI,
        Collision
    }

    /// <summary>
    /// A node in the scenegraph
    /// </summary>
    class SceneNode : TreeNode
    {
        private String _name = "";       // Name of of the scene node
        private Vector2 _position = Vector2.Zero;  // Location of the centre of the scene node
        private List<SceneNodeAttachment> _attachments; // Attachments for the given node

        /// <summary>
        /// Name of the scene node
        /// </summary>
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Position of the scene node
        /// </summary>
        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parent">Parent node</param>
        /// <param name="name">Name of the node</param>
        public SceneNode(SceneNode parent, String name)
            : base(parent)
        {
            _name = name;
            _attachments = new List<SceneNodeAttachment>();
        }

        /// <summary>
        /// Retrieves a list of all attachments supporting a given scene-node operation
        /// </summary>
        /// <param name="operation">The operation to query for</param>
        /// <returns></returns>
        public List<SceneNodeAttachment> FindAttachmentsSupporting(SceneNodeOperation operation)
        {
            List<SceneNodeAttachment> attachments = new List<SceneNodeAttachment>();

            // Check through all attachments for any supporting the operation
            foreach (SceneNodeAttachment attachment in _attachments)
            {
                if (attachment.Supports(operation))
                {
                    attachments.Add(attachment);
                }
            }

            return attachments;
        }

        /// <summary>
        /// Adds an attachment to the scene node.
        /// 
        /// Reserved for use almost exclusively by SceneNodeAttachment because it 
        /// doesn't change the Owner property of the attachment itself.
        /// 
        /// If you need add an attachment to a scene-node, set the Owner property of the attachment instead
        /// </summary>
        /// <param name="attachment">The attachment to add</param>
        public void AddAttachment(SceneNodeAttachment attachment)
        {
            if (null == attachment)
            {
                throw new NullReferenceException("Tried to add a null attachment to the SceneNode named '" + Name + "'");
            }

            _attachments.Add(attachment);
        }

        /// <summary>
        /// Removes an attachment from the scene node.
        /// 
        /// Reserved for use almost exclusively by SceneNodeAttachment because it 
        /// doesn't change the Owner property of the attachment itself.
        /// 
        /// If you need remove an attachment from a scene-node, set the Owner property of the attachment to null instead
        /// </summary>
        /// <param name="attachment"></param>
        public void RemoveAttachment(SceneNodeAttachment attachment)
        {
            if (null == attachment)
            {
                throw new NullReferenceException("Tried to remove a null attachment from the SceneNode named '" + Name + "'");
            }

            _attachments.Remove(attachment);
        }

        /// <summary>
        /// Processes an update to the scene node
        /// </summary>
        /// <param name="gameTime">Elapsed game time</param>
        public virtual void OnUpdate(GameTime gameTime)
        {
            // Update all the attachments
            foreach (SceneNodeAttachment attachment in _attachments)
            {
                attachment.OnUpdate(gameTime);
            }

            // Update the children
            foreach (SceneNode child in Children)
            {
                child.OnUpdate(gameTime);
            }
        }

        /// <summary>
        /// Renders the scene node
        /// </summary>
        /// <param name="gameTime">Elapsed game time</param>
        /// <param name="renderer">Renderer</param>
        /// <param name="batch">SpriteBatch used for rendering</param>
        public virtual void OnRender(GameTime gameTime, Renderer renderer, SpriteBatch batch)
        {
            // Render all the attachments
            foreach (SceneNodeAttachment attachment in _attachments)
            {
                attachment.OnRender(gameTime, renderer, batch);
            }

            // Render the children
            foreach (SceneNode child in Children)
            {
                child.OnRender(gameTime, renderer, batch);
            }
        }

        /// <summary>
        /// Renders the GUI
        /// </summary>
        /// <param name="gameTime">Elapsed game time</param>
        /// <param name="renderer">Renderer</param>
        /// <param name="batch">SpriteBatch used for rendering</param>
        public virtual void OnGUI(GameTime gameTime, Renderer renderer, SpriteBatch batch)
        {
            // Render the GUI for all the attachments
            foreach (SceneNodeAttachment attachment in _attachments)
            {
                attachment.OnGUI(gameTime, renderer, batch);
            }

            // Render the children
            foreach (SceneNode child in Children)
            {
                child.OnGUI(gameTime, renderer, batch);
            }
        }

        /// <summary>
        /// Processes a collision with the scene node
        /// </summary>
        /// <param name="gameTime">Elapsed game time</param>
        public virtual void OnCollision(GameTime gameTime, SceneNode collider)
        {
            // Notify all attachments of the collision
            foreach (SceneNodeAttachment attachment in _attachments)
            {
                attachment.OnCollision(gameTime, collider);
            }
        }
    }
}
