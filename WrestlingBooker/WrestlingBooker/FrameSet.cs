using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WrestlingBooker
{
    /// <summary>
    /// Set of frames for a single animation
    /// </summary>
    class FrameSet
    {
        List<Tuple<int, int>> _frames;  // Set of frames of animation
        bool _loop = false; // True if this animation should loop
        int _fps;   // Frames per second in the animation cycle

        /// <summary>
        /// Frames per second of the animation cycle
        /// </summary>
        public int FPS
        {
            get { return _fps; }
            set { _fps = value; }
        }
        /// <summary>
        /// Frames of animation
        /// </summary>
        public List<Tuple<int, int>> Frames
        {
            get { return _frames; }
            set { _frames = value; }
        }

        /// <summary>
        /// Whether or not the animation should loop
        /// </summary>
        public bool Loop
        {
            get { return _loop; }
            set { _loop = value; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="frames">List of frames in the animation</param>
        /// <param name="loop">True if the animation should loop upon completion, else false</param>
        /// <param name="fps">Frames per second of the animation cycle</param>
        public FrameSet(List<Tuple<int, int>> frames, bool loop, int fps)
        {
            _frames = frames;
            _loop = loop;
            _fps = fps;
        }

        /// <summary>
        /// Gets a specific frame of animation
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Tuple<int, int> GetFrame(int index)
        {
            if (index < 0 && index >= Frames.Count)
            {
                throw new IndexOutOfRangeException("Unable to get animation frame using index " + index);
            }

            return _frames[index];
        }
    }
}
