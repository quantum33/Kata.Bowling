namespace Kata.Bowling
{
    public static class FrameFactory
    {
        public static Frame CreateIf(bool predicate, int frameRank)
            => predicate
            ? new Frame(frameRank)
            : null;
    }
}

