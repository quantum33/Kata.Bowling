using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Bowling
{
    public static class RankedFramesExtentions
    {
        public static bool HasNoElement(this IEnumerable<RankedFrame> frames)
            => !frames.Any();

        public static void AddTo(this RankedFrame frame, List<RankedFrame> frames)
        {
            if (frame != null)
            {
                frames.Add(frame);
            }
        }
    }
}

