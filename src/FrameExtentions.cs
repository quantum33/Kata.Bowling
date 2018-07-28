using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Bowling
{
    public static class FrameExtentions
    {
        public static bool HasNoElement(this IEnumerable<Frame> frames)
            => !frames.Any();

        public static void AddTo(this Frame frame, List<Frame> frames)
        {
            if (frame != null)
            {
                frames.Add(frame);
            }
        }
    }
}

