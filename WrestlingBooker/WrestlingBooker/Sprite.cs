using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WrestlingBooker
{
    /// <summary>
    /// A sprite
    /// </summary>
    class Sprite
    {
        protected Texture2D _texture; // Sprite texture
        protected Vector2 _dimensions;  // Dimensions of the sprite

        /// <summary>
        /// Width of the sprite
        /// </summary>
        public virtual int Width
        {
            get { return (int)_dimensions.X; }
        }

        /// <summary>
        /// Height of the sprite
        /// </summary>
        public virtual int Height
        {
            get { return (int)_dimensions.Y; }
        }

        /// <summary>
        /// Gets the texture of the sprite
        /// </summary>
        public Texture2D Texture
        {
            get { return _texture; }
        }

        /// <summary>
        /// Dimensions of the texture
        /// </summary>
        public Vector2 Dimensions
        {
            get { return _dimensions; }
            set { _dimensions = value; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="texture">Texture of the sprite</param>
        public Sprite(Texture2D texture)
        {
            _texture = texture;
            _dimensions = new Vector2(_texture.Bounds.Width, _texture.Bounds.Height);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="texture">Texture of the sprite</param>
        public Sprite(Texture2D texture, Vector2 dimensions)
        {
            _texture = texture;
            _dimensions = dimensions;
        }

        /// <summary>
        /// Renders the sprite
        /// </summary>
        /// <param name="gameTime">Game time</param>
        /// <param name="renderer">Renderer</param>
        /// <param name="batch">SpriteBatch to draw the sprite</param>
        /// <param name="position">The position </param>
        public virtual void Render(GameTime gameTime, Renderer renderer, SpriteBatch batch, Vector2 position)
        {
            batch.Draw(Texture, new Rectangle((int)position.X, (int)position.Y, Width, Height), Color.White);
        }

        /// <summary>
        /// Updates the sprite
        /// </summary>
        /// <param name="gameTime">Game time</param>
        public virtual void Update(GameTime gameTime)
        { }
    }
}
