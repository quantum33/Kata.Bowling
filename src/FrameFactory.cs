namespace Kata.Bowling
{
    public static class FrameFactory
    {
        public static RankedFrame CreateIf(bool predicate, int frameRank)
            => predicate
            ? new RankedFrame(frameRank)
            : null;
    }
}

