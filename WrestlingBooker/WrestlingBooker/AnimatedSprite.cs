using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WrestlingBooker
{
    /// <summary>
    /// Animated sprite
    /// </summary>
    class AnimatedSprite : Sprite
    {
        private int _cellWidth;     // Width of a single animation cell
        private int _cellHeight;    // Height of a single animation cell
        private Dictionary<String, FrameSet> _animations;   // Map of animations
        private String _activeAnimation;    // Active animation
        private int _currentFrameIndex;   // Index of the current frame of animation
        private float _elapsedOverflow;     // Overflow from the previous update call

        /// <summary>
        /// Width of the sprite
        /// </summary>
        public override int Width
        {
            get { return _cellWidth; }
        }

        /// <summary>
        /// Height of the sprite
        /// </summary>
        public override int Height
        {
            get { return _cellHeight; }
        }

        /// <summary>
        /// Active animation
        /// </summary>
        public String ActiveAnimation
        {
            get { return _activeAnimation; }
            set
            {
                _activeAnimation = value;
                _currentFrameIndex = 0;
            }
        }

        /// <summary>
        /// Current frame index
        /// </summary>
        protected int CurrentFrameIndex
        {
            get { return _currentFrameIndex; }
            set
            {
                _currentFrameIndex++;

                // Check to make sure the animation can loop if the index is now out of bounds
                FrameSet frames = CurrentFrames;
                if (_currentFrameIndex >= frames.Frames.Count)
                {
                    if (frames.Loop)    // If we can loop, circle back to the beginning
                    {
                        _currentFrameIndex %= frames.Frames.Count;
                    }
                    else // If we can't loop, decrement the counter back to it's original value
                    {
                        _currentFrameIndex--;
                    }
                }
            }
        }
        
        /// <summary>
        /// Gets the current set of animation frames
        /// </summary>
        public FrameSet CurrentFrames
        {
            get
            {
                FrameSet frames;
                _animations.TryGetValue(ActiveAnimation, out frames);
                return frames;
            }
        }

        /// <summary>
        /// Gets the current animation frame
        /// </summary>
        private Tuple<int, int> CurrentFrame
        {
            get
            {
                FrameSet frames;
                _animations.TryGetValue(ActiveAnimation, out frames);
                return frames.GetFrame(CurrentFrameIndex);
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="texture">Texture of the sprite</param>
        /// <param name="cellWidth">Width of a single cell</param>
        /// <param name="cellHeight">Height of a single cell</param>
        public AnimatedSprite(Texture2D texture, int cellWidth, int cellHeight, Dictionary<String, FrameSet> animations)
            : base(texture)
        {
            _cellWidth = cellWidth;
            _cellHeight = cellHeight;
            _animations = animations;

            ActiveAnimation = _animations.Keys.First();
        }

        /// <summary>
        /// Renders the sprite
        /// </summary>
        /// <param name="gameTime">Game time</param>
        /// <param name="renderer">Renderer</param>
        /// <param name="batch">SpriteBatch to draw the sprite</param>
        /// <param name="position">The position </param>
        public override void Render(GameTime gameTime, Renderer renderer, SpriteBatch batch, Vector2 position)
        {
            Tuple<int, int> frame = CurrentFrame;
            int row = frame.Item1;
            int column = frame.Item2;

            Rectangle destination = new Rectangle((int)position.X, (int)position.Y, Width, Height);
            Rectangle source = new Rectangle(Width * column, Height * row, Width, Height);
            batch.Draw(Texture, destination, source, Color.White);
        }

        /// <summary>
        /// Updates the sprite
        /// </summary>
        /// <param name="gameTime">Game time</param>
        public override void Update(GameTime gameTime)
        {
            _elapsedOverflow += gameTime.ElapsedGameTime.Milliseconds / 1000.0f;
            float secondsPerFrame = 1.0f / CurrentFrames.FPS;

            // Update the animation frame index whenever the cumulative amount of time over a series of frames has passed the number of frames per second
            while (_elapsedOverflow - secondsPerFrame > 0)
            {
                _elapsedOverflow -= secondsPerFrame;
                CurrentFrameIndex++;
            }
        }
    }
}
