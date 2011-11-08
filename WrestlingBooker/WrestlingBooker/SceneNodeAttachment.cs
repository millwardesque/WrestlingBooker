using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WrestlingBooker
{
    /// <summary>
    /// Attaches to a scene-node to provide additional functionality
    /// </summary>
    abstract class SceneNodeAttachment {
        protected SceneNode _owner;   // Node that owns this attachment

        /// <summary>
        /// Node that owns the attachment
        /// </summary>
        public SceneNode Owner {
            get { return _owner; }
            set
            {
                // Remove this from the existing owner's list of attachment
                if (null != _owner)
                {
                    _owner.RemoveAttachment(this);
                }

                // Set the new owner and add this to its list of attachments
                _owner = value;
                if (null != _owner)
                {
                    _owner.AddAttachment(this);
                }
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_owner">Node that owns this attachment</param>
        public SceneNodeAttachment(SceneNode owner)
        {
            Owner = owner;
        }

        /// <summary>
        /// Checks whether this attachment supports the given operation
        /// 
        /// Note that all attachments define all of the operations, but this
        /// method is instead intended to provide a 'hint' as to whether or not this
        /// attachment does anything meaningful during that operation
        /// </summary>
        /// <param name="operation">The operation to check for</param>
        /// <returns>True if this attachment supports the operation, else false</returns>
        public abstract bool Supports(SceneNodeOperation operation);

        /// <summary>
        /// Processes an update to the scene node
        /// </summary>
        /// <param name="gameTime">Elapsed game time</param>
        public virtual void OnUpdate(GameTime gameTime) { }

        /// <summary>
        /// Renders the scene node
        /// </summary>
        /// <param name="gameTime">Elapsed game time</param>
        /// <param name="renderer">Renderer</param>
        /// <param name="batch">SpriteBatch used for rendering</param>
        public virtual void OnRender(GameTime gameTime, Renderer renderer, SpriteBatch batch) { }

        /// <summary>
        /// Renders the GUI
        /// </summary>
        /// <param name="gameTime">Elapsed game time</param>
        /// <param name="renderer">Renderer</param>
        /// <param name="batch">SpriteBatch used for rendering</param>
        public virtual void OnGUI(GameTime gameTime, Renderer renderer, SpriteBatch batch) { }

        /// <summary>
        /// Processes a collision to the scene node
        /// </summary>
        /// <param name="gameTime">Elapsed game time</param>
        /// <param name="collider">The object colliding with the node</param>
        public virtual void OnCollision(GameTime gameTime, SceneNode collider) { }
    };
}
