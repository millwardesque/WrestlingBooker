using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WrestlingBooker
{
    /// <summary>
    /// Renderer for the engine
    /// </summary>
    class Renderer
    {
        private GraphicsDeviceManager _graphics = null;    // Graphics Device Manager used in the system
        private Color _clearColour = Color.Black;  // Color used to clear the screen
        private SpriteFont _font = null;    // Font for rendering text

        /// <summary>
        /// Width of the render surface
        /// </summary>
        public int Width
        {
            get { return _graphics.GraphicsDevice.PresentationParameters.BackBufferWidth; }
        }

        /// <summary>
        /// Height of the render surface
        /// </summary>
        public int Height
        {
            get { return _graphics.GraphicsDevice.PresentationParameters.BackBufferHeight; }
        }

        /// <summary>
        /// Color used to clear the screen
        /// </summary>
        public Color ClearColour
        {
            get { return _clearColour; }
            set { _clearColour = value; }
        }

        /// <summary>
        /// Rendering font
        /// </summary>
        public SpriteFont Font
        {
            get { return _font; }
            set { _font = value; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="graphics">Graphics device manager</param>
        public Renderer(GraphicsDeviceManager graphics)
        {
            _graphics = graphics;
        }

        /// <summary>
        /// Renders the game
        /// </summary>
        /// <param name="gameTime"></param>
        public void Render(GameTime gameTime)
        {
            _graphics.GraphicsDevice.Clear(_clearColour);
        }

        /// <summary>
        /// Converts a point from a coordinate space where (0, 0) is at the top-left to one where (0, 0) is at the bottom-left
        /// </summary>
        /// <param name="point">The point to convert</param>
        /// <returns>The converted point</returns>
        public Vector2 YCoordinateFlip(Vector2 point)
        {
            Vector2 flipped = new Vector2(point.X, this.Height - point.Y);
            return flipped;
        }

        /// <summary>
        /// Writes text to the screen
        /// </summary>
        /// <param name="batch">Sprite batch</param>
        /// <param name="position">Position to render the text</param>
        /// <param name="text">Text to render</param>
        public void WriteText(SpriteBatch batch, Vector2 position, String text)
        {
            if (null == _font)
            {
                throw new NullReferenceException("Failed rendering text '" + text + "': Font is null");
            }

            // Draws the text
            batch.DrawString(_font, text, position, Color.White);
        }
    }
}
