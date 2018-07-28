namespace Kata.Bowling
{
    public class RankedFrame : Frame
    {
        public RankedFrame(int rank)
        {
            Rank = rank;
        }

        public int Rank { get; }

        public bool IsTenthFrame
            => Rank == Constants.MaxFrameCount - 1;

        public bool NotIsTenthFrame
            => !IsTenthFrame;

        public new RankedFrame AddRoll(Roll roll)
        {
            if (!IsTenthFrame)
            {
                base.AddRoll(roll);
            }
            else
            {
                if (!IsMaxRollsLimitReached)
                {
                    base.AddRoll(roll);
                }
                else if (IsEligibleForExtraBall)
                {
                    base.AddRoll(roll);
                }
            }
            return this;
        }

        private bool IsMaxRollsLimitReached
            => Rolls.Count == Constants.MaxRollCount;

        private bool IsEligibleForExtraBall
            => IsTenthFrame
            && (IsStrike || IsSpare);
    }
}
