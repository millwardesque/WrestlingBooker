using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WrestlingBooker
{
    /// <summary>
    /// An attachment that links a sprite with a scene-node
    /// </summary>
    class SpriteAttachment : SceneNodeAttachment
    {
        private Sprite _sprite;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="sprite"></param>
        public SpriteAttachment(SceneNode owner, Sprite sprite)
            : base(owner)
        {
            _sprite = sprite;
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
        public override bool Supports(SceneNodeOperation operation)
        {
            bool doesSupport = false;

            // Check to see if the operation is supported
            switch (operation)
            {
                case SceneNodeOperation.Render:
                case SceneNodeOperation.Update:
                    doesSupport = true;
                    break;
                default:
                    doesSupport = false;
                    break;
            }

            return doesSupport;
        }

        /// <summary>
        /// Renders the sprite
        /// </summary>
        /// <param name="gameTime">Game time</param>
        /// <param name="renderer">Renderer</param>
        /// <param name="batch">Sprite batch</param>
        public override void OnRender(GameTime gameTime, Renderer renderer, SpriteBatch batch)
        {
            // Calculate the position of the sprite by flipping the y-coordinate
            Vector2 renderPosition = renderer.YCoordinateFlip(_owner.Position);
            renderPosition.Y -= _sprite.Height / 2.0f;
            renderPosition.X -= _sprite.Width / 2.0f;

            // Render the sprite
            _sprite.Render(gameTime, renderer, batch, renderPosition);

            base.OnRender(gameTime, renderer, batch);
        }

        /// <summary>
        /// Updates the sprite
        /// </summary>
        /// <param name="gameTime">Game time</param>
        public override void OnUpdate(GameTime gameTime)
        {
            // Update the sprite
            _sprite.Update(gameTime);

            base.OnUpdate(gameTime);
        }

        /// <summary>
        /// Renders the GUI for the sprite
        /// </summary>
        /// <param name="gameTime">Game time</param>
        /// <param name="renderer">Renderer</param>
        /// <param name="batch">Sprite batch</param>
        public override void OnGUI(GameTime gameTime, Renderer renderer, SpriteBatch batch)
        {
            // Calculate the position of the sprite by flipping the y-coordinate
            Vector2 renderPosition = renderer.YCoordinateFlip(_owner.Position);
            renderPosition.Y -= _sprite.Height / 2.0f;

            // Render the sprite
            renderer.WriteText(batch, renderPosition, Owner.Name);

            base.OnRender(gameTime, renderer, batch);
        }
    }
}
